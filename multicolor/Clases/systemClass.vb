Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Printing
Imports System.Text
Imports System.Net

Public Class SystemClass

    Private Multihilo As New MultiHilo
    Public lv As ListView
    Public f As Form
    Public pgb As ProgressBar
    Public sql As String

    Dim sp_datosTabla As New sp_datosTabla

    'Pintar Listview
    Sub PintarLv(ByVal lv As ListView)

        Dim colorindex As Integer = 0

        Dim item As ListViewItem

        Dim subitem As ListViewItem.ListViewSubItem

        For Each item In lv.Items

            If (item.Index Mod 2) = 0 Then

                For Each subitem In item.SubItems

                    subitem.BackColor = Color.LightGray

                Next

            Else

                For Each subitem In item.SubItems

                    subitem.BackColor = Color.White

                Next

            End If

        Next

    End Sub

    '-- listar proveedor
    Public Sub SqlToLvProveedor(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)

            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            Dim CantidadActual, CantidadAnterior As Integer
            For i = 0 To Column
                CantidadActual = 0
                CantidadAnterior = 0
                For j = 0 To Field
                    CantidadAnterior = CantidadActual
                    CantidadActual = lv.Items(j).SubItems(i).Text.Length

                    If CantidadActual > CantidadAnterior Then
                        LengthColumnContent(i) = CantidadActual
                    Else
                        LengthColumnContent(i) = CantidadAnterior
                    End If

                    If CantidadActual > LengthHeader(i) Then
                        Exit For
                    End If

                Next
            Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next



            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    'LISTAR ITEMS 
    Public Sub SqlToLv(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(Conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)

            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Formato numero
            Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    If IsNumeric(lv.Items(j).SubItems(i).Text) = True Then

                        If lv.Items(j).SubItems(i).Text.Substring(0, 1) = 0 Then
                            lv.Columns(i).TextAlign = HorizontalAlignment.Left
                            Exit For
                        End If

                        Numero = lv.Items(j).SubItems(i).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(i).Text = Numero.ToString("###,###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(i).Text = "0"
                        End If

                        'If Numero > 0 And Numero < 999 Then
                        ' lv.Items(j).SubItems(i).Text = Numero.ToString("###.##")
                        'End If
                        lv.Columns(i).TextAlign = HorizontalAlignment.Right
                    Else
                        lv.Columns(i).TextAlign = HorizontalAlignment.Left
                        Exit For
                    End If
                Next
            Next

            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            'Dim CantidadActual, CantidadAnterior As Integer
            'For i = 0 To Column
            '    CantidadActual = 0
            '    CantidadAnterior = 0
            '    For j = 0 To FieldS
            '        CantidadAnterior = CantidadActual
            '        CantidadActual = lv.Items(j).SubItems(i).Text.Length

            '        If CantidadActual > CantidadAnterior Then
            '            LengthColumnContent(i) = CantidadActual
            '        Else
            '            LengthColumnContent(i) = CantidadAnterior
            '        End If

            '        If CantidadActual > LengthHeader(i) Then
            '            Exit For
            '        End If

            '    Next
            'Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next



            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    'LISTAR ITEMS de los detalles de mercaderias con descuento de fecha corta no canjeables
    Public Sub SqlToLv_mercaderiaDescuentoNoCanjeables(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la las columnas
            For y As Integer = 0 To lv.Items.Count - 1
                lv.Items(y).UseItemStyleForSubItems = False
                If lv.Items(y).SubItems.Count > 1 Then
                    '-- vencimiento
                    lv.Items(y).SubItems(4).BackColor = Color.Yellow
                    '-- descuento normal
                    lv.Items(y).SubItems(6).BackColor = Color.LightSkyBlue
                    '-- porcentaje canje
                    lv.Items(y).SubItems(7).BackColor = Color.Lime
                    '-- comision
                    lv.Items(y).SubItems(12).BackColor = Color.Aquamarine
                    '-- utilidad
                    lv.Items(y).SubItems(14).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)

            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer
            Dim bolTmpControlado As Boolean

            'Formato numero
            Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    '-- columnas
                    If i = 5 Then
                        '-- el stock
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 6 Then
                        '-- el porcentaje normal
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 7 Then
                        '-- el porcentaje canje
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 9 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 10 Then
                        '-- precio 
                        Numero = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 11 Then
                        '-- precio descuento
                        Numero = lv.Items(j).SubItems(11).Text
                        lv.Items(j).SubItems(11).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 12 Then
                        '-- comision
                        Numero = lv.Items(j).SubItems(12).Text
                        lv.Items(j).SubItems(12).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 13 Then
                        '-- porcentaje de comision
                        Numero = lv.Items(j).SubItems(13).Text
                        lv.Items(j).SubItems(13).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 14 Then
                        '-- porcentaje de utilidad
                        Numero = lv.Items(j).SubItems(14).Text
                        lv.Items(j).SubItems(14).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    bolTmpControlado = CBool(lv.Items(j).SubItems(18).Text)
                    If bolTmpControlado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.LimeGreen
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    Public Sub SqlToLv_mercaderiaCanjeCancelaNC(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)

            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Formato numero
            Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- cantidad
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 5 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 6 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 7 Then
                        '-- stock
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    '-- el stock
                    If lv.Items(j).SubItems(7).Text > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    If lv.Items(j).SubItems(7).Text = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    If lv.Items(j).SubItems(7).Text < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- listar los personales completos de la empresa
    Public Sub SqlToLvPersonalCompleto(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)

            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Formato numero
            Dim bolTmpActivo As Boolean

            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- color del fondo de los inactivos
                    bolTmpActivo = lv.Items(j).SubItems(4).Text
                    If bolTmpActivo = True Then
                        '- activos
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    Else
                        '-- inactivos
                        lv.Items(j).SubItems(i).BackColor = Color.Pink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- listar las cajas
    Public Sub SqlToLvConsultaCaja(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim bolTmpControlado As Boolean
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 1 Then
                        '-- total caja
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                    If i = 2 Then
                        '-- total sistema
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                    '-- color rojo de la fuente si no está controlado
                    bolTmpControlado = lv.Items(j).SubItems(5).Text
                    If bolTmpControlado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- consulta de los checkIm
    Public Sub SqlToLv_consultaCheckIn(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAbierto As Integer
            'Dim bolTmpActivo As Boolean
            'Dim bolTmpNotaCredito As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el idCompra
                        'lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###")
                    End If
                    '-------------------------------------
                    bolTmpAbierto = CBool(lv.Items(j).SubItems(5).Text)
                    '-- colocar el color la fuente
                    If bolTmpAbierto = True Then
                        '- abierto
                        lv.Items(j).SubItems(i).BackColor = Color.Lime
                    Else
                        '-- cerrado
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    ''--------------------------------------------------
                    ''-- color del fondo de los anulados
                    'bolTmpActivo = lv.Items(j).SubItems(8).Text
                    'If bolTmpActivo = True Then
                    '    '- no anulados
                    '    lv.Items(j).SubItems(i).BackColor = Color.White
                    'Else
                    '    '-- anulados
                    '    lv.Items(j).SubItems(i).BackColor = Color.Pink
                    'End If
                    '--------------------------------------
                    '--------------------------------------------------
                    '-- color del fondo de los que tienen nota de credito
                    'bolTmpNotaCredito = lv.Items(j).SubItems(9).Text
                    'If bolTmpNotaCredito = False Then
                    '    '- sin nota de credito
                    '    lv.Items(j).SubItems(i).ForeColor = Color.Black
                    'Else
                    '    '-- con nota de credito
                    '    lv.Items(j).SubItems(i).ForeColor = Color.Green
                    'End If
                    '--------------------------------------
                    If i = 4 Then
                        '-- total
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                    ''-- costo
                    'If i = 7 Then
                    '    Numero = lv.Items(j).SubItems(7).Text
                    '    lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,###.00")
                    'End If
                    ''-- precio
                    'If i = 8 Then
                    '    Numero = lv.Items(j).SubItems(8).Text
                    '    lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    'End If
                    ''-- subtotal
                    'If i = 9 Then
                    '    Numero = lv.Items(j).SubItems(9).Text
                    '    lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,###.00")
                    'End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' solo para listar el stock de los productos
    Public Sub SqlToLv_producto(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column

                'filas
                For j = 0 To Field
                    If IsNumeric(lv.Items(j).SubItems(i).Text) = True Then
                        ' solo dar formato al precio y al stock
                        If lv.Items(j).SubItems(i).Text.Substring(0, 1) = 0 Then
                            lv.Columns(i).TextAlign = HorizontalAlignment.Left
                            Exit For
                        End If
                        '-- formato para el precio
                        If lv.Items(i).Text = 4 Then
                            Numero = lv.Items(j).SubItems(i).Text
                            If Numero > 999 Then
                                lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,###")
                            End If

                            If Numero = 0 Then
                                lv.Items(j).SubItems(4).Text = "0"
                            End If

                            If Numero > 0 And Numero < 999 Then
                                lv.Items(j).SubItems(4).Text = Numero.ToString("###")
                            End If
                        End If
                        '-- formato para el stock
                        If lv.Items(i).Text = 5 Then
                            Numero = lv.Items(j).SubItems(i).Text
                            If Numero > 999 Then
                                lv.Items(j).SubItems(5).Text = Numero.ToString("###,###.##")
                            End If

                            If Numero = 0 Then
                                lv.Items(j).SubItems(5).Text = "0"
                            End If

                            If Numero > 0 And Numero < 999 Then
                                lv.Items(j).SubItems(5).Text = Numero.ToString("###.##")
                            End If
                        End If
                        lv.Columns(i).TextAlign = HorizontalAlignment.Right
                    Else
                        lv.Columns(i).TextAlign = HorizontalAlignment.Left
                        Exit For
                    End If
                Next
            Next

            ' Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            Dim CantidadActual, CantidadAnterior As Integer
            For i = 0 To Column
                CantidadActual = 0
                CantidadAnterior = 0
                For j = 0 To Field
                    CantidadAnterior = CantidadActual
                    CantidadActual = lv.Items(j).SubItems(i).Text.Length

                    If CantidadActual > CantidadAnterior Then
                        LengthColumnContent(i) = CantidadActual
                    Else
                        LengthColumnContent(i) = CantidadAnterior
                    End If

                    If CantidadActual > LengthHeader(i) Then
                        Exit For
                    End If

                Next
            Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next



            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    ' solo para listar el stock de los productos
    Public Sub SqlToLv_abmProducto(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            'lv.FullRowSelect = True
            'lv.GridLines = True
            'lv.AllowColumnReorder = True
            'lv.MultiSelect = False
            'lv.Columns.Clear()

            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            'lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim valorNumero As Integer
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(i).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0,##")
                    End If

                    valorNumero = lv.Items(j).SubItems(3).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '--------------------------------------

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    ' un datagridview para buscar productos
    Public Sub SqlToDg_producto(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'x("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Refresh()
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    ' solo para listar el stock de los productos
    Public Sub SqlToLv_producto_busqueda(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(7).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 5 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(5).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###,###,##0")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(5).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("##0")
                        End If

                    End If
                    If i = 7 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(7).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("###,##0.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(7).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("##0.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("#,##0.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar los pedidos entre sucursales
    Public Sub SqlToLv_consultaPedidoEntreSucursales(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(2).Text
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar el stock de los productos similares
    Public Sub SqlToLv_productoStockSimilar(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(5).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 4 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,##0")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("##0")
                        End If

                    End If
                    If i = 5 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(5).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###,##0.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(5).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("##0.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("#,##0.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar las drogas del producto
    Public Sub SqlToLv_drogasProducto(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            'lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text

                    If i = 1 Then
                        '-- cantidad
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Numero.ToString("#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar stock en la consulta de stock por mercaderia
    Public Sub SqlToLv_consultaStockMercaderia(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim bolTmpFueraLinea As Boolean
            Dim bolTmpControlado As Boolean
            'Dim bolTmpPendiente As Boolean
            'Dim bolTmpComision As Boolean

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(5).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 4 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,###")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###")
                        End If

                    End If
                    If i = 5 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(5).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(5).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("#,###.##")
                        End If
                    End If
                    '-- fuera de linea
                    bolTmpFueraLinea = lv.Items(j).SubItems(6).Text
                    If bolTmpFueraLinea = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                    '-- controlados
                    bolTmpControlado = lv.Items(j).SubItems(7).Text
                    If bolTmpControlado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.ForestGreen
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar el stock de los productos en canje
    Public Sub SqlToLv_producto_busquedaStockCanje(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'Dim bolTmpFueraLinea As Boolean
            'Dim bolTmpControlado As Boolean
            'Dim bolTmpPendiente As Boolean
            'Dim bolTmpComision As Boolean

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(5).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 4 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,##0")

                    End If
                    If i = 5 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(5).Text

                        lv.Items(j).SubItems(5).Text = Numero.ToString("#,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el stock de mercaderias en el restauratn
    Public Sub SqlToLv_stockResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato stock
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "###,##0.##")
                    End If

                    valorNumero = lv.Items(j).SubItems(3).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar los productos que tienen precio en bellini
    Public Sub SqlToLv_mercaderiaPrecioBellini(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        '-- formato precio anterior
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 4 Then
                        '-- formato precio actual
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "###,##0.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '-- listar los pedidos cargados en el resto
    Public Sub SqlToLv_pedidoCargadoResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '-- listar los pedidos a ser entregados
    Public Sub SqlToLv_listarPedidoEntrega(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantidad
                    lv.Items(i).SubItems(4).BackColor = Color.LimeGreen
                    '-- hora de pedido
                    lv.Items(i).SubItems(7).BackColor = Color.Yellow
                    '-- minutos de espera
                    lv.Items(i).SubItems(8).BackColor = Color.LightPink
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar los pedidos de los clentes en el resto
    Public Sub SqlToLv_listarPedidosClientesResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bol_valorNumero As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato total
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '- stock negativo
                    bol_valorNumero = lv.Items(j).SubItems(4).Text
                    If bol_valorNumero = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar los detalles de los pedidos del cliente
    Public Sub SqlToLv_listarDetallePedidoClienteResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- subTotal
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar los detalles de los pedidos del cliente en la factura
    Public Sub SqlToLv_listarDetallePedidoClienteRestoFactura(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- subTotal
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato porcentaje iva
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '-- listar los pedidos a factuar del cliente
    Public Sub SqlToLv_listarPedidoFacturarClienteResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato total
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar los pedidos eliminados del restaurante
    Public Sub SqlToLv_listarEliminaPedidoResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total
                    lv.Items(i).SubItems(1).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '-- listar los detalles de los huespedes a facturar en el restaurante panoramico
    Public Sub SqlToLv_listarHuespedesFacturacionResto(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub


    '-- listar el stock de mercaderias en el restante para facturacion
    Public Sub SqlToLv_stockRestoFacturacion(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(4).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 3 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###,##0")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###")
                        End If

                    End If
                    If i = 4 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(4).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("#,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar el stock de mercaderias en el restante para la tablet
    Public Sub SqlToLv_stockRestoFacturacionTablet(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(3).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 2 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###,##0")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###")
                        End If

                    End If
                    If i = 3 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(3).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("#,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("#,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar menu en la facturacion del restaurante
    Public Sub SqlToLv_menuRestoFacturacion(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    ' solo para listar el stock de los productos para la consumicion del hotel
    Public Sub SqlToLv_producto_busquedaConsumicionHotel(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(4).Text

                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el precio
                    If i = 3 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,###,##0")
                    End If
                    If i = 4 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(4).Text

                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' solo para listar los laboratorios del descuento del black friday
    Public Sub SqlToLv_laboratorioDescuentoBlackFriday(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar las divisiones de los porcentajes del black friday
    Public Sub SqlToLv_divisionDescuentoBlackFriday(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje actual
                    lv.Items(i).SubItems(3).BackColor = Color.LightSalmon
                    '-- porcentaje black friday
                    lv.Items(i).SubItems(4).BackColor = Color.Black
                    '-- porcentaje tarjeta
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    If i = 3 Then
                        '-- para el porcentaje actual
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 4 Then
                        '-- para el porcentaje del black friday
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                        lv.Items(j).SubItems(4).ForeColor = Color.White
                    End If
                    If i = 5 Then
                        '-- para el porcentaje de la tarjeta
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("#,##0.##")
                        lv.Items(j).SubItems(5).ForeColor = Color.Black
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar las mercaderias del descuento del black friday
    Public Sub SqlToLv_mercaderiaDescuentoBlackFriday(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje actual
                    lv.Items(i).SubItems(7).BackColor = Color.LightSalmon
                    '-- porcentaje black friday
                    lv.Items(i).SubItems(8).BackColor = Color.Black
                    '-- porcentaje de tarjeta
                    lv.Items(i).SubItems(9).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim tmpBolModificado As Boolean = False
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    If i = 6 Then
                        '-- para el porcentaje anterior
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 7 Then
                        '-- para el porcentaje actual
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 8 Then
                        '-- para el porcentaje black friday
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Numero.ToString("#,##0.##")
                        lv.Items(j).SubItems(8).ForeColor = Color.White
                    End If
                    If i = 9 Then
                        '-- para el porcentaje de la ganancia
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Numero.ToString("#,##0.##")
                    End If
                    '-- si es un producto con porcentaje diferenciado
                    tmpBolModificado = CBool(lv.Items(j).SubItems(10).Text)

                    If tmpBolModificado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar las mercaderias del descuento del black friday con fecha corta
    Public Sub SqlToLv_mercaderiaDescuentoBlackFridayFechaCorta(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje actual
                    lv.Items(i).SubItems(8).BackColor = Color.LightSalmon
                    '-- porcentaje black friday
                    lv.Items(i).SubItems(9).BackColor = Color.Black
                    '-- comision
                    lv.Items(i).SubItems(13).BackColor = Color.Cyan
                    '-- la utilidad
                    lv.Items(i).SubItems(15).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim tmpBolModificado As Boolean = False
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    If i = 6 Then
                        '-- stock
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 7 Then
                        '-- para el porcentaje anterior
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 8 Then
                        '-- para el porcentaje actual
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 9 Then
                        '-- para el porcentaje black friday
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Numero.ToString("#,##0.##")
                        lv.Items(j).SubItems(9).ForeColor = Color.White
                    End If
                    If i = 10 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 11 Then
                        '-- precio descuento
                        Numero = lv.Items(j).SubItems(11).Text
                        lv.Items(j).SubItems(11).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 12 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(12).Text
                        lv.Items(j).SubItems(12).Text = Numero.ToString("###,##0")
                    End If
                    If i = 13 Then
                        '-- comision
                        Numero = lv.Items(j).SubItems(13).Text
                        lv.Items(j).SubItems(13).Text = Numero.ToString("###,##0")
                    End If
                    If i = 14 Then
                        '-- porcentaje comision
                        Numero = lv.Items(j).SubItems(14).Text
                        lv.Items(j).SubItems(14).Text = Numero.ToString("##0.##")
                    End If
                    If i = 15 Then
                        '-- utilidad
                        Numero = lv.Items(j).SubItems(15).Text
                        lv.Items(j).SubItems(15).Text = Numero.ToString("#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el estado de los repartidores
    Public Sub SqlToLv_estadoRepartidor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            'MsgBox("Valor de la consulta  " & sql)
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim bolTmpOcupado As Boolean

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    bolTmpOcupado = lv.Items(j).SubItems(5).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If bolTmpOcupado = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    Else
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' solo para listar el stock de los productos por deposito
    Public Sub SqlToLv_producto_busqueda_deposito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            'MsgBox("Valor de la consulta  " & sql)
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim douTmpComision As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(2).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 2 Then
                        'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("#,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                    If i = 5 Then
                        '-- formato para la comision
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,##0")
                    End If
                    douTmpComision = CDbl(lv.Items(j).SubItems(5).Text)

                    If douTmpComision > 0 Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Blue
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' solo para listar el stock de los productos por deposito
    Public Sub SqlToLv_productoVencimientoSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            'MsgBox("Valor de la consulta  " & sql)
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmStock.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim bolTmpCanje As Boolean
            Dim douTmpComision As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(3).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '-- si es un deposito de canje
                    'bolTmpFueraLinea = lv.Items(j).SubItems(8).Text
                    bolTmpCanje = lv.Items(j).SubItems(5).Text
                    'MsgBox("Valor bolTmpCanje   " & CStr(lv.Items(j).SubItems(4).Text))
                    'MsgBox("Paso por aca")
                    If bolTmpCanje = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                        'lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 3 Then
                        'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("#,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                    If i = 4 Then
                        '-- formato para la comision
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0")
                    End If
                    douTmpComision = CDbl(lv.Items(j).SubItems(4).Text)

                    If douTmpComision > 0 Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Blue
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar la tabla de cotizacion
    Public Sub SqlToLv_tablaCotizacion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- para la cotizacion
                    If i = 1 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(i).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,##0.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("##0.##")
                        End If
                    End If
                    '-- para el subtotal
                    If i = 2 Then
                        '-- formato para el subtotal
                        Numero = lv.Items(j).SubItems(2).Text
                        'lv.Items(j).SubItems(2).Font = FontFamily("Arial"),18
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("#,###.##")
                        End If
                    End If
                    '-- para el descuento
                    If i = 3 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(3).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para el total
                    If i = 4 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(4).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###.##")
                        End If
                    End If

                Next
            Next

            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar la tabla de cotizacion para el check out del hotel
    Public Sub SqlToLv_tablaCotizacionCheckOut(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- para la cotizacion
                    If i = 1 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(i).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###")
                        End If
                    End If
                    '-- para el subtotal
                    If i = 2 Then
                        '-- formato para el subtotal
                        Numero = lv.Items(j).SubItems(2).Text
                        'lv.Items(j).SubItems(2).Font = FontFamily("Arial"),18
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("#,###.##")
                        End If
                    End If
                    '-- para el descuento
                    If i = 3 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(3).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para el total
                    If i = 4 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(4).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###.##")
                        End If
                    End If

                Next
            Next

            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' para listar la tabla premios del cliente
    Public Sub SqlToLv_tablaPuntajeCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- para la cotizacion
                    If i = 2 Then
                        '-- formato para el puntaje
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,##0")
                        End If
                    End If
                Next
            Next

            ' PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar el stock de las sucursales
    Public Sub SqlToLv_stockSucursales(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(3).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 3 Then
                        'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("#,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar la cabecera de los descuentos por laboratorio
    Public Sub SqlToLv_descuentoCabLaboratorio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento de deposito
    Public Sub SqlToLv_descuentoLaboratorioDeposito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento de Grupo de Cliente
    Public Sub SqlToLv_descuentoLaboratorioGrupoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje contado
                    lv.Items(i).SubItems(4).BackColor = Color.Lime
                    '-- porcentaje credito
                    lv.Items(i).SubItems(5).BackColor = Color.LightPink
                    '-- porcentaje tarjeta
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                    '-- porcentaje tarjeta de debito
                    lv.Items(i).SubItems(7).BackColor = Color.LightSteelBlue
                    '-- porcentaje cheque diferido
                    lv.Items(i).SubItems(8).BackColor = Color.MediumSpringGreen

                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpDouPorce As Double
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- porcentaje contado
                        tmpDouPorce = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 5 Then
                        '-- porcentaje credito
                        tmpDouPorce = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 6 Then
                        '-- porcentaje tarjeta de credito
                        tmpDouPorce = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 7 Then
                        '-- porcentaje tarjeta de debito
                        tmpDouPorce = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 8 Then
                        '-- porcentaje cheque diferido
                        tmpDouPorce = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = tmpDouPorce.ToString("##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento especial
    Public Sub SqlToLv_descuentoEspecial(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- contado
                    lv.Items(i).SubItems(5).BackColor = Color.Lime
                    '-- porcentaje credito
                    lv.Items(i).SubItems(6).BackColor = Color.LightPink
                    '-- porcentaje tarjeta
                    lv.Items(i).SubItems(7).BackColor = Color.Yellow
                    '-- porcentaje tarjeta de debito
                    lv.Items(i).SubItems(8).BackColor = Color.Cyan
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpDouPorce As Double
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        tmpDouPorce = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 5 Then
                        tmpDouPorce = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 6 Then
                        tmpDouPorce = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 7 Then
                        tmpDouPorce = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 8 Then
                        tmpDouPorce = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento de producto mayorista
    Public Sub SqlToLv_descuentoEspecialGrupoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- % contado
                    lv.Items(i).SubItems(5).BackColor = Color.Lime
                    '-- descuento contado mayo
                    lv.Items(i).SubItems(6).BackColor = Color.Lime
                    '-- % credito
                    lv.Items(i).SubItems(7).BackColor = Color.LightPink
                    '-- descuento credito mayo
                    lv.Items(i).SubItems(8).BackColor = Color.LightPink
                    '-- precio contado
                    lv.Items(i).SubItems(9).BackColor = Color.Lime
                    '-- precio credito
                    lv.Items(i).SubItems(10).BackColor = Color.LightPink
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpDouPorce As Double
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- precio
                        tmpDouPorce = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = tmpDouPorce.ToString("##,###,##0")
                    End If
                    If i = 5 Then
                        '--% contado
                        tmpDouPorce = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 6 Then
                        '-- contado mayorista
                        tmpDouPorce = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 7 Then
                        '-- % credito
                        tmpDouPorce = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = tmpDouPorce.ToString("##0.##")
                    End If
                    If i = 8 Then
                        '-- credito mayorista
                        tmpDouPorce = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 9 Then
                        '-- precio contado
                        tmpDouPorce = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                    If i = 10 Then
                        '-- precio credito
                        tmpDouPorce = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = tmpDouPorce.ToString("#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento de Laboratorio
    Public Sub SqlToLv_descuentoLaboratorio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento de division
    Public Sub SqlToLv_descuentoLaboratorioDivision(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje nacional
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                    lv.Items(i).SubItems(7).BackColor = Color.Yellow
                    '-- porcentaje importado
                    lv.Items(i).SubItems(8).BackColor = Color.LightCoral
                    lv.Items(i).SubItems(9).BackColor = Color.LightCoral

                End If
            Next
            '----------------------------------------------------------

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        '-- formato nacional normal
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##0.##")
                    End If
                    If i = 7 Then
                        '-- formato importado normal
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("##0.##")
                    End If
                    If i = 8 Then
                        '-- formato nacional delivery
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Numero.ToString("##0.##")
                    End If
                    If i = 9 Then
                        '-- formato importado delivery
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Numero.ToString("##0.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle del descuento por laboratorio nuevo en el grupo de cliente
    Public Sub SqlToLv_descLaboratorioGrupoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            ' frmDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- contado
                    lv.Items(i).SubItems(3).BackColor = Color.Lime
                    lv.Items(i).SubItems(4).BackColor = Color.Lime
                    '-- credito
                    lv.Items(i).SubItems(5).BackColor = Color.LightPink
                    lv.Items(i).SubItems(6).BackColor = Color.LightPink
                    '-- tarjeta
                    lv.Items(i).SubItems(7).BackColor = Color.Yellow
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                    '-- web
                    lv.Items(i).SubItems(9).BackColor = Color.Aqua
                    lv.Items(i).SubItems(10).BackColor = Color.Aqua
                End If
            Next
            '----------------------------------------------------------

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpIdGrupoCliente As Integer = 0
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- formato nacional normal
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##0.##")
                    End If
                    If i = 4 Then
                        '-- formato importado normal
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0.##")
                    End If
                    If i = 5 Then
                        '-- formato nacional delivery
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("##0.##")
                    End If
                    If i = 6 Then
                        '-- formato importado delivery
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##0.##")
                    End If
                    If i = 7 Then
                        '-- formato importado delivery
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("##0.##")
                    End If
                    If i = 8 Then
                        '-- formato importado delivery
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Numero.ToString("##0.##")
                    End If
                    If i = 9 Then
                        '-- formato nacional web
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Numero.ToString("##0.##")
                    End If
                    If i = 10 Then
                        '-- formato importado web
                        Numero = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = Numero.ToString("##0.##")
                    End If

                    tmpIdGrupoCliente = CInt(lv.Items(j).SubItems(1).Text)
                    If (tmpIdGrupoCliente = 4 Or tmpIdGrupoCliente = 12) Then
                        '-- cliente ocacional
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle de productos con descuento del laboratorio y division
    Public Sub SqlToLv_detalleProductoDescLab(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpDouStock As Double = 0
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- formato precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 4 Then
                        '-- formato stock
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0.##")
                    End If

                    tmpDouStock = CDbl(lv.Items(j).SubItems(4).Text)
                    If tmpDouStock > 0 Then
                        '-- con stock
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'para listar el detalle de productos que no estan en el descuento
    Public Sub SqlToLv_detalleProductoSinDescLab(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            ' frmDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpDouStock As Double = 0
            Dim tmpBolActivo As Boolean = False
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- formato precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 4 Then
                        '-- formato stock
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0.##")
                    End If

                    tmpDouStock = CDbl(lv.Items(j).SubItems(4).Text)
                    If tmpDouStock > 0 Then
                        '-- con stock
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If

                    tmpBolActivo = CBool(lv.Items(j).SubItems(9).Text)
                    If tmpBolActivo = True Then
                        '-- sin descuento
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar la forma de venta
    Public Sub SqlToLv_formaVenta(ByVal lv As ListView, ByVal sp_consulta As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar el stock de los lotes
    Public Sub SqlToLv_loteStock(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String, ByVal v_iddeposito As Integer)
        'Public Sub SqlToLv_loteStock(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String, ByVal v_iddeposito As Integer)
        Try

            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro

            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            ' MsgBox("Paso.... " & sql)
            'MsgBox("Valor de ds.Tables(Resultado).Rows  " & ds.Tables("Resultado").Rows)

            Dim intTmpContador As Integer

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                'MsgBox("Valor de drw  " & drw.ToString)
                intTmpContador = intTmpContador + 1
                'MsgBox("Valor del contador  " & intTmpContador)
                'MsgBox("Valor   " & (drw.Item(0).ToString))
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)

                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        'MsgBox("Valor de i  " & i)
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim valorIdDeposito As Integer
            'Dim intTmpIdDepositoCanje As Integer
            Dim douTmpComision As Double

            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- valor del stock
                    valorNumero = lv.Items(j).SubItems(2).Text
                    '-- valor del idDeposito
                    valorIdDeposito = lv.Items(j).SubItems(5).Text
                    valorIdDeposito = lv.Items(j).SubItems(6).Text
                    '        ' MsgBox("Valor de valorIdDepoito  " & valorIdDeposito)
                    '        ' MsgBox("Valor de v_iddeposito  " & v_iddeposito)
                    '-------------------------------
                    '-- colocar el color de la fuente
                    '-------------------------------
                    If valorIdDeposito <> v_iddeposito Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                        'lv.Items(j).SubItems(i).Font.Bold = True
                    End If
                    '-------------------------------
                    '-- colocar el color de fondo
                    '-------------------------------
                    '- cantidad positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 2 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("##,##0.##")
                    End If
                    If i = 4 Then
                        '-- formato para la comision
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0")
                    End If
                    douTmpComision = CDbl(lv.Items(j).SubItems(4).Text)

                    If douTmpComision > 0 Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Blue
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If

                Next
            Next
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)
            'columnas
            'For i = 0 To Column
            '    'MsgBox("Valor de i  " & i)
            '    'filas
            '    For j = 0 To Field
            '        ' MsgBox("Valor de j  " & j)
            '        '-- valor del stock
            '        valorNumero = lv.Items(j).SubItems(2).Text

            '        '-- valor del idDeposito
            '        valorIdDeposito = lv.Items(j).SubItems(6).Text
            '        ' MsgBox("Valor de valorIdDepoito  " & valorIdDeposito)
            '        ' MsgBox("Valor de v_iddeposito  " & v_iddeposito)
            '        '-------------------------------
            '        '-- colocar el color de la fuente
            '        '-------------------------------
            '        If valorIdDeposito <> v_iddeposito Then
            '            lv.Items(j).SubItems(i).ForeColor = Color.Red
            '            'lv.Items(j).SubItems(i).Font.Bold = True
            '        End If
            '        '-------------------------------
            '        '-- colocar el color de fondo
            '        '-------------------------------
            '        '- stock positivo
            '        If valorNumero > 0 Then
            '            lv.Items(j).SubItems(i).BackColor = Color.LightGreen
            '        End If
            '        '- stock en cero
            '        If valorNumero = 0 Then
            '            lv.Items(j).SubItems(i).BackColor = Color.White
            '        End If
            '        '- stock negativo
            '        If valorNumero < 0 Then
            '            lv.Items(j).SubItems(i).BackColor = Color.LightCoral
            '        End If

            '        '--------------------------------------
            '        '-- color de la letra si tiene comision
            '        intTmpIdDepositoCanje = lv.Items(j).SubItems(6).Text
            '        If intTmpIdDepositoCanje = (sp_datosTabla.consulta_valor("select idDeposito from deposito where canje=1")) Then
            '            lv.Items(j).SubItems(i).ForeColor = Color.Blue
            '            'lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
            '            lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
            '        End If

            '        '-- columnas
            '        If i = 2 Then
            '            'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
            '            '-- formato para el stock
            '            Numero = lv.Items(j).SubItems(2).Text
            '            If Numero > 999 Then
            '                lv.Items(j).SubItems(2).Text = Numero.ToString("###,##0.##")
            '            End If

            '            If Numero = 0 Then
            '                lv.Items(j).SubItems(2).Text = "0"
            '            End If

            '            If Numero > 0 And Numero < 999 Then
            '                lv.Items(j).SubItems(2).Text = Numero.ToString("##0.##")
            '            End If

            '            If Numero < 0 Then
            '                lv.Items(j).SubItems(2).Text = Numero.ToString("##,##0.###")
            '            End If

            '            '-- para el negativo

            '            'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
            '        End If


            '        douTmpComision = CDbl(lv.Items(j).SubItems(4).Text)
            '        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0")


            '        'If i = 4 Then
            '        '    lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0")
            '        'End If
            '        '-- valor de la comision
            '        'douTmpComision = CDbl(lv.Items(j).SubItems(4).Text)
            '        MsgBox("Valor de comision  " & douTmpComision)

            '        If douTmpComision > 0 Then
            '            lv.Items(j).SubItems(i).ForeColor = Color.Blue
            '            'lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
            '            lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
            '        End If

            '    Next
            'Next
            'MsgBox("Fin del contador")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' para listar todos los lotes del producto
    Public Sub SqlToLv_loteProductoGral(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        'Public Sub SqlToLv_loteStock(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String, ByVal v_iddeposito As Integer)
        Try

            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro

            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            ' MsgBox("Paso.... " & sql)
            'MsgBox("Valor de ds.Tables(Resultado).Rows  " & ds.Tables("Resultado").Rows)

            Dim intTmpContador As Integer

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                'MsgBox("Valor de drw  " & drw.ToString)
                intTmpContador = intTmpContador + 1
                'MsgBox("Valor del contador  " & intTmpContador)
                'MsgBox("Valor   " & (drw.Item(0).ToString))
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)

                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        'MsgBox("Valor de i  " & i)
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim valorIdDeposito As Integer
            'Dim intTmpIdDepositoCanje As Integer
            Dim douTmpComision As Double

            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- valor del stock
                    valorNumero = lv.Items(j).SubItems(2).Text
                    '-- valor del idDeposito
                    valorIdDeposito = lv.Items(j).SubItems(5).Text
                    valorIdDeposito = lv.Items(j).SubItems(6).Text
                    '        ' MsgBox("Valor de valorIdDepoito  " & valorIdDeposito)
                    '        ' MsgBox("Valor de v_iddeposito  " & v_iddeposito)
                    '-------------------------------
                    '-- colocar el color de la fuente
                    '-------------------------------
                    '-------------------------------
                    '-- colocar el color de fondo
                    '-------------------------------
                    '- cantidad positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 2 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("##,##0.##")
                    End If
                    If i = 4 Then
                        '-- formato para la comision
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0")
                    End If
                    douTmpComision = CDbl(lv.Items(j).SubItems(4).Text)

                    If douTmpComision > 0 Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Blue
                        lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    End If

                Next
            Next

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' para listar el stock de los lotes en control de envio
    Public Sub SqlToLv_loteStockControlEnvio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        'Public Sub SqlToLv_loteStock(ByVal lv As ListView, ByVal consulta As String, ByVal v_parametro As String, ByVal v_iddeposito As Integer)
        Try

            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro

            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            'MsgBox("Valor de ds.Tables(Resultado).Rows  " & ds.Tables("Resultado").Rows)

            Dim intTmpContador As Integer

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                'MsgBox("Valor de drw  " & drw.ToString)
                intTmpContador = intTmpContador + 1
                'MsgBox("Valor del contador  " & intTmpContador)
                'MsgBox("Valor   " & (drw.Item(0).ToString))
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)

                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        'MsgBox("Valor de i  " & i)
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim valorIdDeposito As Integer
            'MsgBox("Valor de column  " & Column)
            'MsgBox("Valor de field  " & Field)
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- valor del stock
                    valorNumero = lv.Items(j).SubItems(2).Text

                    '-- valor del idDeposito
                    valorIdDeposito = lv.Items(j).SubItems(5).Text
                    '-------------------------------
                    '-- colocar el color de fondo
                    '-------------------------------
                    '- cantidad positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- columnas
                    If i = 2 Then
                        'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("##,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                Next
            Next
            'MsgBox("Fin del contador")
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message & " " & Me.ToString, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '-- el detalle de la consulta de compras cargadas del detalle de compra temporal
    Public Sub SqlToLv_detalleCompraTmp(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- exenta
                    lv.Items(i).SubItems(8).BackColor = Color.PaleGreen
                    '-- gravada 5
                    lv.Items(i).SubItems(9).BackColor = Color.Pink
                    '-- gravada 10
                    lv.Items(i).SubItems(10).BackColor = Color.DarkTurquoise

                    '-- total costo
                    lv.Items(i).SubItems(11).BackColor = Color.Yellow
                    '-- % comprometido
                    lv.Items(i).SubItems(14).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpMalPorcentaje As Boolean
            Dim strTmpNotaCredito As String
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- cantidad
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                        lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato bonidicacion
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0")
                        lv.Items(j).SubItems(5).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato exenta
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        '-- formato gravada5
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 10 Then
                        Numero = lv.Items(j).SubItems(10).Text
                        '-- formato gravada10
                        lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 11 Then
                        Numero = lv.Items(j).SubItems(11).Text
                        '-- formato total costo
                        lv.Items(j).SubItems(11).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 12 Then
                        Numero = lv.Items(j).SubItems(12).Text
                        '-- formato precio
                        lv.Items(j).SubItems(12).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(9).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 13 Then
                        Numero = lv.Items(j).SubItems(13).Text
                        '-- formato porcentaje iva
                        lv.Items(j).SubItems(13).Text = Format(CDec(Numero), "##0")
                        'lv.Items(j).SubItems(10).Font = New Font(New FontFamily("Comic Sans MS"), 12, FontStyle.Regular)
                    End If
                    If i = 14 Then
                        Numero = lv.Items(j).SubItems(14).Text
                        '-- formato porcentaje comprometido
                        lv.Items(j).SubItems(14).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(11).Font = New Font(New FontFamily("Comic Sans MS"), 12, FontStyle.Regular)
                    End If

                    '-- si tiene un error de porcentaje comprometido
                    bolTmpMalPorcentaje = lv.Items(j).SubItems(15).Text
                    If bolTmpMalPorcentaje = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    Else
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If

                    '-- si tiene nota de credito
                    strTmpNotaCredito = lv.Items(j).SubItems(16).Text
                    If strTmpNotaCredito = "S" Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    Else
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de la compra de mercaderias
    Public Sub SqlToLv_detalleCompra(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    If j = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- el porcentaje del impuesto
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##")
                    End If
                    If j = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- el porcentaje comprometido
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##.00")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- el precio
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###.00")
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- el costo
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        '-- la cantidad
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    If i = 10 Then
                        Numero = lv.Items(j).SubItems(10).Text
                        '-- bonificacion
                        lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "###")
                    End If
                    If i = 11 Then
                        Numero = lv.Items(j).SubItems(11).Text
                        '-- el subtotal
                        lv.Items(j).SubItems(11).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    If i = 12 Then
                        Numero = lv.Items(j).SubItems(12).Text
                        '-- exenta
                        lv.Items(j).SubItems(12).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 13 Then
                        Numero = lv.Items(j).SubItems(13).Text
                        '-- gravada 5
                        lv.Items(j).SubItems(13).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 14 Then
                        Numero = lv.Items(j).SubItems(14).Text
                        '-- gravada 10
                        lv.Items(j).SubItems(14).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de la consulta del seguimiento de stock
    Public Sub SqlToLv_detalleConsultaSeguimientoStock(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim i As Integer = 0
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmSeguimientoStock.txtSql.Text = sql

            ' MsgBox("Paso 1")

            Dim Adapter As New SqlDataAdapter(sql, conn)
            ' MsgBox("Paso 1.1")
            Dim ds As New DataSet
            ' MsgBox("Paso 1.1.1")
            Adapter.Fill(ds, "Resultado")
            ' MsgBox("Paso 1.1.1.1")
            Dim objListItem As New ListViewItem
            ' MsgBox("Paso 1.2")

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                        ' MsgBox("Valor  " & ds.Tables(0).Columns.ToString)
                    Next
                End If
            Next

            For i2 As Integer = 0 To lv.Items.Count - 1

                lv.Items(i2).UseItemStyleForSubItems = False

                If lv.Items(i2).SubItems.Count > 1 Then
                    lv.Items(i2).SubItems(3).BackColor = Color.LightGreen
                    lv.Items(i2).SubItems(4).BackColor = Color.LightSkyBlue
                    lv.Items(i2).SubItems(5).BackColor = Color.LightCoral

                    'lv.Items(i).SubItems(1).Font = New Font(lv.Items(i).SubItems(1).Font.Size, 10) ', FontStyle.Bold)

                End If

            Next
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim intTmpContador As Integer = 0
            'Formato numero
            Dim Numero As Decimal
            Dim saldoStock As Decimal
            Dim saldoStock1 As Decimal
            Dim bolTmpNoImp As Boolean
            Dim totalEntrada As Decimal = 0
            Dim totalSalida As Decimal = 0

            'saldoStock1 = sp_datosTabla.sp_double("sp_insSaldoProductoDeposito_nuevo", intGl_idConfigPc & "," & intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(frmSeguimientoStock.dtpDesdeFecha) & "'" & "," & CInt(frmSeguimientoStock.txtIdDeposito.Text))
            ' MsgBox("Paso por el ultimo")

            frmSeguimientoStock.txtSaldoStock.Text = saldoStock1
            frmSeguimientoStock.txtSaldoStock.Text = FormatNumber(frmSeguimientoStock.txtSaldoStock.Text, "000,000.00")
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 0 Then
                        '-- colocar el nro
                        intTmpContador = intTmpContador + 1
                        lv.Items(j).SubItems(0).Text = intTmpContador
                        '-- colocar el saldo
                        If intTmpContador = 1 Then
                            saldoStock = saldoStock1 + lv.Items(j).SubItems(3).Text - lv.Items(j).SubItems(4).Text
                        Else
                            saldoStock = (lv.Items(j).SubItems(3).Text - lv.Items(j).SubItems(4).Text) + saldoStock
                        End If
                        lv.Items(j).SubItems(5).Text = saldoStock
                        '----------------------------------------
                    End If

                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- entrada
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0.##")
                        totalEntrada = totalEntrada + Numero
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- salida  
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                        totalSalida = totalSalida + Numero
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    bolTmpNoImp = lv.Items(j).SubItems(12).Text
                    If bolTmpNoImp = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next

            frmSeguimientoStock.txtTotalEntrada.Text = totalEntrada
            frmSeguimientoStock.txtTotalEntrada.Text = FormatNumber(frmSeguimientoStock.txtTotalEntrada.Text, "000,000.00")
            frmSeguimientoStock.txtTotalSalida.Text = totalSalida
            frmSeguimientoStock.txtTotalSalida.Text = FormatNumber(frmSeguimientoStock.txtTotalSalida.Text, "000,000.00")

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de nota de credito
    Public Sub SqlToLv_detalleNotaCredito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    If j = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- el porcentaje del impuesto
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- el precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###.00")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- el costo
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- la cantidad
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- bonificacion
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "###")
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- el subtotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la nota de debito
    Public Sub SqlToLv_detalleNotaDebito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- el precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- la cantidad
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,##0")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- el subtotal
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las modificaciones de precios enteros en consulta
    Public Sub SqlToLv_detalleModificaPrecioEnteroConsulta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 2 Then
                        '-- el precio anterior
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 3 Then
                        '-- precio actual
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 4 Then
                        '-- porcentaje
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "#,##0.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de mercaderia con fecha corta canjeable para descuentos
    Public Sub SqlToLv_detalleMercaderiaFechaCorta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- vencimiento
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                    '-- porcentaje nacional
                    lv.Items(i).SubItems(6).BackColor = Color.Lime
                    '-- porcentaje importado
                    lv.Items(i).SubItems(7).BackColor = Color.Aquamarine
                    '-- precio con descuento
                    lv.Items(i).SubItems(10).BackColor = Color.LightSkyBlue
                    '-- utilidad
                    lv.Items(i).SubItems(11).BackColor = Color.Cyan
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 5 Then
                        '-- el stock
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 6 Then
                        '-- el porcentaje nacional
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 7 Then
                        '-- el porcentaje importado
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##0.##")
                    End If
                    If i = 9 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 10 Then
                        '-- precio descuento
                        Numero = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 11 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(11).Text
                        lv.Items(j).SubItems(11).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    If i = 12 Then
                        '-- utilidad
                        Numero = lv.Items(j).SubItems(12).Text
                        lv.Items(j).SubItems(12).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de mercaderia con fecha corta canjeable para descuentos cargado
    Public Sub SqlToLv_detalleMercaderiaFechaCortaCarga(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- vencimiento
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 5 Then
                        '-- el stock
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 7 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la compra
    Public Sub SqlToLv_consultaCompra(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el idCompra
                        'lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###")
                    End If
                    '-------------------------------------
                    valorNumero = lv.Items(j).SubItems(7).Text
                    '-- colocar el color la fuente
                    If valorNumero = 1 Then
                        '- si es no impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    Else
                        '-- para el impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    End If
                    '--------------------------------------
                    '-- cantidad
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###.00")
                    End If
                    '-- costo
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- precio
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- subtotal
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consutla de venta
    Public Sub SqlToLv_consultaVentaFactura(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el idCompra
                        'lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###")
                    End If
                    '--------------------------------------
                    '-- total
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la compra de la devolucion
    Public Sub SqlToLv_consultaCompraDevolucion(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 6 Then
                        '-- total
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la compra
    Public Sub SqlToLv_consultaDetalleConceptoGasto(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- porcentaje impuesto
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "###.##")
                    End If
                    '-- factor del impuesto
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "###.##")
                    End If
                    '-- costo
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle del delivery
    Public Sub SqlToLv_consultaDeliveryEnviar(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolDeliveryExt As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el idCompra
                        'lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###")
                    End If
                    '-- idVenta
                    If i = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###,###")
                    End If
                    '-- total de venta
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    bolDeliveryExt = CBool(lv.Items(j).SubItems(7).Text)
                    If bolDeliveryExt = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- la consulta de la nota de debito
    Public Sub SqlToLv_consultaDevolucion(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el idVenta
                        lv.Items(j).SubItems(0).Text = Format(CDec(Numero), "###,###")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- el total
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detallde la venta para la busqueda por producto
    Public Sub SqlToLv_consultaVenta(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- el precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- la cantidad
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- el subtotal
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las ventas
    Public Sub SqlToLv_detalleVenta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(1).Text = Numero.ToString("######")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- % IVA
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "###")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "#,###,###.00")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- el subtotal
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos fraccionados
    Public Sub SqlToLv_fraccionado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 2 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- el precio del producto
                        lv.Items(j).SubItems(2).Text = Numero.ToString("###,####.00")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos con descuentos en abm producto
    Public Sub SqlToLv_productoDescuentoAbm(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcentaje nacional
                    lv.Items(i).SubItems(1).BackColor = Color.Yellow
                    '-- porcentaje importado
                    lv.Items(i).SubItems(2).BackColor = Color.LightSkyBlue
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 1 Then
                        '-- % nacional normal
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Numero.ToString("###.##")
                    End If
                    If i = 2 Then
                        '-- % nacional delivery
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los costos de los productos
    Public Sub SqlToLv_descuentoEspecialVenta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 0 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el costo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los costos de los productos
    Public Sub SqlToLv_costoProducto(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 1 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- el costo del producto
                        lv.Items(j).SubItems(1).Text = Numero.ToString("##,###,####")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los costos de los productos detallado
    Public Sub SqlToLv_costoProductoDetallado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 6 Then
                        '-- la cantidad
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 7 Then
                        '-- el costo 
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la lista de precio del hotel
    Public Sub SqlToLv_listaPrecioHotel(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el precio
                    lv.Items(i2).SubItems(3).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- el precio
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los costos de los productos del stock
    Public Sub SqlToLv_costoProductoStock(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 2 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- el costo del producto
                        lv.Items(j).SubItems(2).Text = Numero.ToString("##,###,####")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle las facturas asignadas a las computadoras
    Public Sub SqlToLv_detalleFacturaAsignada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de los nros de la promocion de samsung club
    Public Sub SqlToLv_detalleNrosPromoSamsung(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 1 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- el costo del producto
                        'lv.Items(j).SubItems(1).Text = Numero.ToString("###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de los productos para el descuento en la heladeria
    Public Sub SqlToLv_blackFridayProductoHeladeria(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Public Sub SqlToLv_descuentoTipoVenta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(i).Text
                    'MsgBox("Valor del numero  " & valorNumero)
                    '-- colocar el color de fondo
                    If valorNumero = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos referenciados
    Public Sub SqlToLv_productoReferenciado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 2 Then
                        'MsgBox("Valor de j  " & j)
                        'MsgBox("Valor   " & lv.Items(j).SubItems(2).Text)
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- la cantidad 
                        lv.Items(j).SubItems(2).Text = Numero.ToString("#,###.00")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los montos
    Public Sub SqlToLv_monto(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    '-- para el monto
                    If i = 1 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(1).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###,###")
                        End If
                        If Numero <= 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###")
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las tarjetas
    Public Sub SqlToLv_tarjeta(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de los pedidos de mercaderias de las sucursales
    Public Sub SqlToLv_pedidoSucursal(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim tmpBolFueraLinea As Boolean = False
            Dim tmpBolControlado As Boolean = False

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    '-- para la venta
                    If i = 1 Then
                        '-- formato de venta
                        Numero = lv.Items(j).SubItems(1).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                    '-- para el stock
                    If i = 2 Then
                        '-- formato de stock
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                    '-- para el pedido
                    If i = 3 Then
                        '-- formato del pedido
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                    '-- fuera de linea
                    tmpBolFueraLinea = CDbl(lv.Items(j).SubItems(6).Text)
                    If tmpBolFueraLinea = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                    '-- controlados
                    tmpBolControlado = CDbl(lv.Items(j).SubItems(7).Text)
                    If tmpBolControlado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Green
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de los pedidos de mercaderias pendientes por sucursal
    Public Sub SqlToLv_pedidoPendienteSucursal(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'MsgBox("Valor total de columnas  " & Column)
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de la columna " & i)
                'filas
                For j = 0 To Field
                    'valorNumero = lv.Items(j).SubItems(3).Text
                    '-- para la cantidad
                    If i = 3 Then
                        '-- formato de la cantidad
                        Numero = lv.Items(j).SubItems(3).Text
                        'MsgBox("Valor de la 3  " & Numero)
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If
                    End If

                    ' End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '- el detalle de la consulta de las sucursales
    Public Sub SqlToLv_sucursal(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el ddetalle de la consulta del pedido de sucursales
    Public Sub SqlToLv_detallePedidoSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el ddetalle de la consulta de los productos pendientes de las sucursales
    Public Sub SqlToLv_detallePedidoProductoPendiente(ByVal lv As ListView, ByVal v_consulta As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(v_consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- valor del stock
                    valorNumero = lv.Items(j).SubItems(5).Text
                    ' MsgBox("Valor de valorNumero  " & valorNumero)
                    '-------------------------------
                    '-- colocar el color de fondo
                    '-------------------------------
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- formato del stock
                    If i = 5 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(5).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(5).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("##,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                    '-- formato del pedido
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(4).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###")
                        End If
                    End If
                    '-- el formato del precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,###")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###")
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- para los aniversarios de los empleados
    Public Sub SqlToLv_cumplePersonal(ByVal lv As ListView, ByVal sp_consulta As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Integer
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    Numero = lv.Items(j).SubItems(2).Text
                    ' MsgBox("Valor del numero  " & Numero)
                    If Numero = 1 Then
                        '-- pintar la letra de los que cumplen años
                        lv.Items(j).SubItems(0).ForeColor = Color.Blue
                        lv.Items(j).SubItems(0).BackColor = Color.Yellow
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar el seguimiento de stock
    Public Sub SqlToLv_seguimientoStock(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            For i As Integer = 0 To lv.Items.Count - 1

                lv.Items(i).UseItemStyleForSubItems = False

                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(3).BackColor = Color.LightGreen
                    lv.Items(i).SubItems(4).BackColor = Color.LightSkyBlue
                    lv.Items(i).SubItems(5).BackColor = Color.LightCoral

                    'lv.Items(i).SubItems(1).Font = New Font(lv.Items(i).SubItems(1).Font.Size, 10) ', FontStyle.Bold)

                End If

            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim intTmpContador As Integer = 0
            'Formato numero
            Dim saldoStock As Decimal
            Dim saldoStock1 As Decimal = 0
            Dim numero As Decimal
            Dim totalEntrada As Decimal = 0
            Dim totalSalida As Decimal = 0
            Dim bolTmpNoImp As Boolean
            'Dim valorNumero As Decimal
            'MsgBox("Valor de la columna  " & Column)
            'columnas
            '-----------------------------------'
            '-- colocar el saldo del producto --'
            '-----------------------------------'
            'MsgBox("Paso 1")

            'saldoStock1 = sp_datosTabla.sp_double("sp_insSaldoProductoDeposito", intGl_idProductoSeguimientoStock & "," & "'" & FormatoFechaSoloDatePicker(frmSeguimientoStock.dtpDesdeFecha) & "'" & "," & CInt(frmSeguimientoStock.txtIdDeposito.Text))

            'saldoStock1 = sp_datosTabla.consulta_valorDouble("select saldo from tmpSaldoSeguimientoStock where idConfig=" & intGl_idConfigPc)
            'MsgBox("Paso 2")
            frmSeguimientoStock.txtSaldoStock.Text = saldoStock1
            frmSeguimientoStock.txtSaldoStock.Text = FormatNumber(frmSeguimientoStock.txtSaldoStock.Text, "000,000.00")
            For i = 0 To Column
                ' MsgBox("Valor de i  " & i.ToString)
                'valorNumero = lv.Items(j).SubItems(3).Text
                'filas
                For j = 0 To Field
                    bolTmpNoImp = lv.Items(j).SubItems(12).Text
                    If bolTmpNoImp = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                    If i = 0 Then
                        '-- colocar el nro
                        intTmpContador = intTmpContador + 1
                        lv.Items(j).SubItems(0).Text = intTmpContador
                        '-- colocar el saldo
                        If intTmpContador = 1 Then
                            saldoStock = saldoStock1 + lv.Items(j).SubItems(3).Text - lv.Items(j).SubItems(4).Text
                        Else
                            saldoStock = (lv.Items(j).SubItems(3).Text - lv.Items(j).SubItems(4).Text) + saldoStock
                        End If
                        lv.Items(j).SubItems(5).Text = saldoStock
                        '----------------------------------------
                    End If
                    'MsgBox("Paso por aca")
                    If i = 3 Then
                        '-- formato para la entrada
                        numero = lv.Items(j).SubItems(3).Text
                        totalEntrada = totalEntrada + numero
                        If numero < 1 And numero > 0 Then
                            lv.Items(j).SubItems(3).Text = numero.ToString("0.##")
                        Else
                            lv.Items(j).SubItems(3).Text = numero.ToString("###,##0.##")
                        End If

                        'MsgBox("Valor de entrada  " & numero.ToString)
                    End If
                    If i = 4 Then
                        '-- formato para la salida
                        numero = lv.Items(j).SubItems(4).Text
                        totalSalida = totalSalida + numero
                        If numero < 1 And numero > 0 Then
                            lv.Items(j).SubItems(4).Text = numero.ToString("0.##")
                        Else
                            lv.Items(j).SubItems(4).Text = numero.ToString("##,##0.##")
                        End If
                    End If
                    If i = 5 Then
                        '-- formato para el saldo
                        numero = lv.Items(j).SubItems(5).Text
                        If numero < 1 And numero > 0 Then
                            lv.Items(j).SubItems(5).Text = numero.ToString("0.##")
                        Else
                            lv.Items(j).SubItems(5).Text = numero.ToString("##,##0.##")
                        End If
                    End If
                Next
            Next
            frmSeguimientoStock.txtTotalEntrada.Text = totalEntrada
            frmSeguimientoStock.txtTotalEntrada.Text = FormatNumber(frmSeguimientoStock.txtTotalEntrada.Text, "000,000.00")
            frmSeguimientoStock.txtTotalSalida.Text = totalSalida
            frmSeguimientoStock.txtTotalSalida.Text = FormatNumber(frmSeguimientoStock.txtTotalSalida.Text, "000,000.00")
        Catch ex As Exception
            MessageBox.Show("Error al cargar el ListView", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    '-- listar las facturas 
    Public Sub SqlToLv_Factura(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Formato numero
            'Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    If IsNumeric(lv.Items(j).SubItems(i).Text) = True Then

                        If lv.Items(j).SubItems(i).Text.Substring(0, 1) = 0 Then
                            lv.Columns(i).TextAlign = HorizontalAlignment.Left
                            Exit For
                        End If

                        lv.Columns(i).TextAlign = HorizontalAlignment.Right
                    Else
                        lv.Columns(i).TextAlign = HorizontalAlignment.Left
                        Exit For
                    End If
                Next
            Next

            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            Dim CantidadActual, CantidadAnterior As Integer
            For i = 0 To Column
                CantidadActual = 0
                CantidadAnterior = 0
                For j = 0 To Field
                    CantidadAnterior = CantidadActual
                    CantidadActual = lv.Items(j).SubItems(i).Text.Length

                    If CantidadActual > CantidadAnterior Then
                        LengthColumnContent(i) = CantidadActual
                    Else
                        LengthColumnContent(i) = CantidadAnterior
                    End If

                    If CantidadActual > LengthHeader(i) Then
                        Exit For
                    End If

                Next
            Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next



            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- detalle del deposito bancario
    Public Sub SqlToLv_detalleDepositoBanco(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- formato del importe
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- el precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "###,###,###.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle del pedido de mercaderia
    Public Sub SqlToLv_detallePedidoMercaderia(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpPendiente As Boolean
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- formato del pedido
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato del pendiente
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,##0.##")
                    End If

                    bolTmpPendiente = CBool(lv.Items(j).SubItems(6).Text)
                    If bolTmpPendiente = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    'If valorStock < valorCantidad Then
                    '    lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    'End If

                    ''-- si la mercaderia sigue como pendiente
                    'If lv.Items(i).SubItems(5).Text > 0 Then
                    '    lv.Items(i).SubItems(j).BackColor = Color.LightCoral
                    'End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los envios controlados por la pc
    Public Sub SqlToLv_detalleControlEnvio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim Numero As Decimal
            Dim douTmptotalEnviado As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- enviado
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,##0.###")
                    End If
                    '-- cantidad
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,##0.###")
                    End If
                    '-- pintar en rojo si las cantidades no son iguales a los enviados
                    douTmptotalEnviado = lv.Items(j).SubItems(2).Text - lv.Items(j).SubItems(3).Text
                    If douTmptotalEnviado <> 0 Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar los productos de un envio
    Public Sub SqlToLv_productosEnvio(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(2).Text
                    '--------------------------------------
                    '-- para el precio
                    If i = 2 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###,###")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###")
                        End If

                    End If
                    If i = 3 Then
                        '-- formato para la cantidad
                        Numero = lv.Items(j).SubItems(3).Text

                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("##,##0.###")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("##0.###")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar los productos de un envio
    Public Sub SqlToLv_productosEnvioPendienteProblema(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(2).Text
                    '--------------------------------------
                    '-- para el precio
                    If i = 2 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("###,###,###")
                    End If
                    If i = 3 Then
                        '-- formato para la cantidad
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###.##")
                    End If
                    If i = 4 Then
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- la cabecera de las remisiones pendientes de los depositos
    Public Sub SqlToLv_cabRemisionPendiente(ByVal lv As ListView, ByVal consulta As String, ByVal v_columna As Integer)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    '-- para la venta
                    If i = 1 Then
                        '-- formato de venta
                        Numero = lv.Items(j).SubItems(1).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                    '-- para el stock
                    If i = 2 Then
                        '-- formato de stock
                        Numero = lv.Items(j).SubItems(2).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                    '-- para el pedido
                    If i = 3 Then
                        '-- formato del pedido
                        Numero = lv.Items(j).SubItems(3).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(3).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- los envios pendientes para colocar los repartidores
    Public Sub SqlToLv_colocarRepartidor(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    '-- para el idEnvio
                    If i = 1 Then
                        '-- formato de venta
                        Numero = lv.Items(j).SubItems(1).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###.##")
                        End If
                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("0")
                        End If
                        If Numero < 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("##,###.##")
                        End If
                    End If
                Next
            Next
            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de los remisiones pendientes
    Public Sub SqlToLv_remisionPendiente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'MsgBox("Paso por el for..!")
            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1

                lv.Items(i).UseItemStyleForSubItems = False

                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(6).BackColor = Color.LightCoral
                    'lv.Items(i).SubItems(4).BackColor = Color.LightSkyBlue
                    'lv.Items(i).SubItems(5).BackColor = Color.LightCoral

                    'lv.Items(i).SubItems(1).Font = New Font(lv.Items(i).SubItems(1).Font.Size, 10) ', FontStyle.Bold)

                End If

            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'MsgBox("Valor de la columna  " & Column)
            'MsgBox("Valor de la fila  " & Field)
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    '-- para el precio
                    If i = 4 Then
                        '-- formato de precio
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(4).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para la cantidad
                    If i = 5 Then
                        '-- formato de cantidad
                        Numero = lv.Items(j).SubItems(5).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("#,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(5).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para el pedido
                    If i = 6 Then
                        '-- formato del pedido
                        Numero = lv.Items(j).SubItems(6).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(6).Text = Numero.ToString("#,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(6).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para el subtotal
                    If i = 7 Then
                        '-- formato del subtotal
                        Numero = lv.Items(j).SubItems(7).Text
                        'MsgBox("Valor de la columna7  " & Numero)
                        If Numero > 999 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("##,###,###.##")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("###.##")
                        End If
                    End If
                    '-- para el nro de pedido
                    If i = 8 Then
                        '-- formato del subtotal
                        Numero = lv.Items(j).SubItems(8).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(8).Text = Numero.ToString("###,###")
                        End If
                        If Numero < 999 Then
                            lv.Items(j).SubItems(8).Text = Numero.ToString("###")
                        End If
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de las promociones de samsung club 
    Public Sub SqlToLv_consultaPromoSamsungClub(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- las recepciones pendientes
    Public Sub SqlToLv_recepcionesPendientesRepartidor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'MsgBox("Paso por el for..!")
            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).SubItems(6).BackColor = Color.LightCoral
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim bolTmpRepartidor As Boolean

            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(1).Text
                    If i = 1 Then
                        '-- formato de idenvio
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Numero.ToString("###,###,###")
                    End If

                    bolTmpRepartidor = lv.Items(j).SubItems(7).Text

                    If bolTmpRepartidor = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    Else
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la recepcion
    Public Sub SqlToLv_detalleRecepcion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(7).BackColor = Color.LightCoral
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    '-- precio
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- cantidad
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    '-- subtotal
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de cancelacion de canjes
    Public Sub SqlToLv_detalleConsultaCancelaCanje(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(7).BackColor = Color.LightCoral
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- costo
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###,##0")
                    End If
                    '-- cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    '-- subtotal
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "#,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de venta
    Public Sub SqlToLv_detalleConsultaVenta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        '-- formato precio
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 3 Then
                        '-- formato cantidad
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 4 Then
                        '-- formato subtotal
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los email de las facturas de los cliente
    Public Sub SqlToLv_detalleConsultaEmailFactura(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim tmpIntIdMov As Integer
            Dim tmpIntIdTransa As Integer
            Dim tmpStrCorreo As String
            'Formato numero
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- generar el archivo PDF
                        'MsgBox("Entro 111")
                        If banGl_generaFE = True Then


                            tmpIntIdMov = CInt(lv.Items(j).SubItems(5).Text)
                            tmpIntIdTransa = CInt(lv.Items(j).SubItems(6).Text)
                            'tmpStrCorreo = lv.Items(j).SubItems(4).Text
                            '-- para prueba
                            tmpStrCorreo = "ninofer80@yahoo.com"
                            '----------------------------------------------
                            ' Crea una nueva instancia de HttpClient
                            '----------------------------------------------
                            Dim strCodigoQR As String
                            Dim client As New WebClient()
                            'Dim response As String = client.DownloadString("http://192.168.0.104:9090/api/qr/get/" & tmpIntIdMov)
                            Dim response As String = client.DownloadString(strGl_direccionQR & tmpIntIdMov)
                            strCodigoQR = response

                            '-- insertar en la tabla temporal
                            If (fun_guardarSp("sp_actualizarCodigoQRTmp", intGl_idConfigPc & "," & tmpIntIdTransa & ",'" & Trim(strCodigoQR) & "'", "")) = 0 Then
                                '-- no se guardo los registros
                                MessageBox.Show("No existe registros...!", strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            End If
                            'MsgBox("Entro 2")

                            generarArchivoPdf(tmpIntIdMov, tmpStrCorreo)
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, strGl_nombreSistema, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    '-- el detalle de deliverys a seleccionar
    Public Sub SqlToLv_detalleDeliverySeleccion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 2 Then
                        '-- formato monto
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta del uso interno
    Public Sub SqlToLv_detalleConsultaUsoInterno(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    '-- cantidad
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    '-- subtotal
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de carga de pastas
    Public Sub SqlToLv_detalleConsultaCargaPastas(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- cantidad
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub



    '-- busqueda del timbrado
    Public Sub SqlToLv_timbradoContabilidad(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de premio
    Public Sub SqlToLv_detalleConsultaPremio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            ''----------------------------------------------------------
            ''Anchor
            'Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            'Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'Dim j As Integer
            ''Formato numero
            'Dim Numero As Decimal
            ''columnas
            'For i = 0 To Column
            '    'filas
            '    For j = 0 To Field
            '        '-- columnas
            '        If j = 0 Then
            '            Numero = lv.Items(j).SubItems(0).Text
            '            '-- el codigo del producto
            '            lv.Items(j).SubItems(0).Text = Numero.ToString("######")
            '        End If
            '        '-- precio
            '        If i = 5 Then
            '            Numero = lv.Items(j).SubItems(5).Text
            '            '-- formato precio
            '            lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
            '        End If
            '        '-- cantidad
            '        If i = 6 Then
            '            Numero = lv.Items(j).SubItems(6).Text
            '            '-- formato cantidad
            '            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,###.00")
            '        End If
            '        '-- subtotal
            '        If i = 7 Then
            '            Numero = lv.Items(j).SubItems(7).Text
            '            '-- formato subtotal
            '            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,###.00")
            '        End If

            '    Next
            'Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de premio otorgados al cliente
    Public Sub SqlToLv_detalleConsultaPremioCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- puntaje anterior
                    lv.Items(i).SubItems(5).BackColor = Color.LightPink
                    '-- total
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                    '-- putnaje
                    lv.Items(i).SubItems(7).BackColor = Color.LightSkyBlue
                    '-- puntahe otorgado
                    lv.Items(i).SubItems(8).BackColor = Color.Magenta
                    '-- saldo del puntaje
                    lv.Items(i).SubItems(9).BackColor = Color.Lime
                End If
            Next

            ''----------------------------------------------------------
            ''Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        '-- formato total
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de habitaciones en el checkIn
    Public Sub SqlToLv_detalleConsultaHabitacionCheckIn(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las entregas cargadas en el check out
    Public Sub SqlToLv_detalleConsultaEntregaEvento(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- nr de recibo
                    lv.Items(i).SubItems(1).BackColor = Color.Lime
                    '-- monto
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- monto
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la lista de precios aplicada a la habitacion del hotel
    Public Sub SqlToLv_detalleConsultaListaPrecioHabitacion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- early
                    lv.Items(i).SubItems(3).BackColor = Color.GreenYellow
                    '-- monto adulto
                    lv.Items(i).SubItems(5).BackColor = Color.Thistle
                    '-- monto menor
                    lv.Items(i).SubItems(6).BackColor = Color.Pink
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpTemporadaAlta As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 2 Then
                        '-- precio dolar
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("##,##0.##")
                    End If
                    If i = 3 Then
                        '-- early
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 4 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 5 Then
                        '-- monto adulto
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 6 Then
                        '-- monto menor
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##,###,##0")
                    End If

                    bolTmpTemporadaAlta = CBool(lv.Items(j).SubItems(7).Text)
                    If bolTmpTemporadaAlta = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                        'lv.Items(j).SubItems(i).Font = 
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de habitacion
    Public Sub SqlToLv_detalleConsultaTipoHabitacion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de busqueda de entregas de envento
    Public Sub SqlToLv_buscarEntregaEvento(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- monto
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consumicion
    Public Sub SqlToLv_detalleConsultaConsumicionHotel(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- subtotal
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 4 Then
                        '-- cantidad
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0")
                    End If
                    If i = 5 Then
                        '-- subtotal
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next
            '----------------------------------------------------------
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de facturacion por habitacion
    Public Sub SqlToLv_detalleConsultaFacturaCheckOutHuesped(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- dias
                    lv.Items(i).SubItems(6).BackColor = Color.LightCoral
                    '-- subtotal
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- los dias
                        lv.Items(j).SubItems(6).Text = Numero.ToString("#,##0.#")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- precio
                        lv.Items(j).SubItems(7).Text = Numero.ToString("###,###,##0")
                    End If
                    '-- subtotal
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato del subTotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de facturacion del detalle del evento
    Public Sub SqlToLv_detalleConsultaFacturaEventoDetalle(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- subtotal
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- precio
                        lv.Items(j).SubItems(1).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- exenta
                        lv.Items(j).SubItems(2).Text = Numero.ToString("#,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- 5%
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0")
                    End If
                    '-- 
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- 10%
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de facturacion por hospedaje
    Public Sub SqlToLv_detalleConsultaFacturaCheckOutHospedaje(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- precio con descuento
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,##0")
                    End If
                    If i = 4 Then
                        '-- precio con descuento
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- listar los pisos de la consulta gral del hotel
    Public Sub SqlToLv_detalleConsultaPisoHotel(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim tmpIntTipo As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    '-- color de la letra si tiene comision
                    'bolTmpComision = lv.Items(j).SubItems(12).Text
                    'If bolTmpComision = True Then
                    '    lv.Items(j).SubItems(i).ForeColor = Color.Blue
                    '    'lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    '    lv.Items(j).SubItems(i).Font = New Font(lv.Items(j).SubItems(i).Font, FontStyle.Bold)
                    'End If

                    '-- de acuerdo al tipo
                    tmpIntTipo = lv.Items(j).SubItems(3).Text
                    If tmpIntTipo = 1 Then
                        '-- disponible
                        lv.Items(j).SubItems(i).BackColor = Color.GreenYellow
                    End If
                    If tmpIntTipo = 2 Then
                        '-- ocupado
                        lv.Items(j).SubItems(i).BackColor = Color.Violet
                    End If
                    If tmpIntTipo = 3 Then
                        '-- reservada
                        lv.Items(j).SubItems(i).BackColor = Color.Aqua
                    End If
                    If tmpIntTipo = 4 Then
                        '-- consultada
                        lv.Items(j).SubItems(i).BackColor = Color.Orange
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar los recibos pendientes de as habitaciones
    Public Sub SqlToLv_detalleReciboPendiente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim intTmpCantidadDias As Integer
            Dim Numero As Decimal
            'Formato numero
            ' Dim tmpIntTipo As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    '-- de acuerdo al tipo
                    'tmpIntTipo = lv.Items(j).SubItems(3).Text
                    'If tmpIntTipo = 1 Then
                    '    '-- disponible
                    '    'lv.Items(j).SubItems(i).BackColor = Color.GreenYellow
                    'End If
                    '-- total
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato total
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- cantidad de dias pendientes
                    intTmpCantidadDias = CInt(lv.Items(j).SubItems(6).Text)
                    If intTmpCantidadDias > 15 Then
                        lv.Items(j).SubItems(i).BackColor = Color.Pink
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de venta
    Public Sub SqlToLv_detalleDeliveryRecepcion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(3).BackColor = Color.LightCoral
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- idVenta
                        lv.Items(j).SubItems(0).Text = Numero.ToString("###,###,###")
                    End If
                    '-- total
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato total
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- total que lleva el repartidor
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato total
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de venta farmacia
    Public Sub SqlToLv_detalleVentaFarmacia(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- porcetanje descuento
                    lv.Items(i).SubItems(3).BackColor = Color.Cyan
                    '-- cantidad
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                    '-- precio descuento
                    lv.Items(i).SubItems(8).BackColor = Color.Pink
                    '-- subtotal
                    lv.Items(i).SubItems(9).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim bolTmpDescuento As Boolean
            Dim bolTmpError As Boolean
            'Dim bolBlackFriday As Boolean
            ' Dim bolTmpComision As Boolean
            'Dim bolTmpFechaCorta As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- porcentaje de descuento
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#0")
                        lv.Items(j).SubItems(3).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- cantidad
                        lv.Items(j).SubItems(6).Text = Numero.ToString("#,##0")
                        lv.Items(j).SubItems(6).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato precio
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,##0.##")
                        lv.Items(j).SubItems(7).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato precio descuento
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0.##")
                        lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,##0.##")
                        lv.Items(j).SubItems(9).Font = New Font(New FontFamily("Comic Sans MS"), 12, FontStyle.Regular)
                    End If
                    '-- si tiene error
                    bolTmpError = lv.Items(j).SubItems(12).Text
                    If bolTmpError = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de las cajas cargadas
    Public Sub SqlToLv_detalleCajaCargada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total caja
                    lv.Items(i).SubItems(4).BackColor = Color.Pink
                    '-- total ingreso
                    lv.Items(i).SubItems(5).BackColor = Color.Lime
                    '-- diferencia
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim tmpDouDife As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- la caja
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,##0")
                    End If
                    If i = 5 Then
                        '-- el ingreso
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                    If i = 6 Then
                        '-- la diferencia
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                        lv.Items(j).SubItems(6).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    tmpDouDife = CInt(lv.Items(j).SubItems(1).Text) - CInt(lv.Items(j).SubItems(2).Text)
                    If tmpDouDife <> 0 Then
                        '-- si hay diferencia
                        lv.Items(j).SubItems(0).BackColor = Color.Pink
                        lv.Items(j).SubItems(1).BackColor = Color.Pink
                        lv.Items(j).SubItems(2).BackColor = Color.Pink
                        lv.Items(j).SubItems(3).BackColor = Color.Pink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- detalle de prueba para un listview de una consulta sp
    Public Sub SqlToLv_prueba(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            ''-- para pintar la columna de total
            'For i As Integer = 0 To lv.Items.Count - 1
            '    lv.Items(i).UseItemStyleForSubItems = False
            '    If lv.Items(i).SubItems.Count > 1 Then
            '        '-- total caja
            '        lv.Items(i).SubItems(4).BackColor = Color.Pink
            '        '-- total ingreso
            '        lv.Items(i).SubItems(5).BackColor = Color.Lime
            '        '-- diferencia
            '        lv.Items(i).SubItems(6).BackColor = Color.Yellow
            '    End If
            'Next
            ''----------------------------------------------------------
            ''Anchor
            'Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            'Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            'Dim j As Integer
            ''Formato numero
            'Dim Numero As Decimal
            'Dim tmpDouDife As Integer
            ''columnas
            'For i = 0 To Column
            '    'filas
            '    For j = 0 To Field
            '        '-- columnas
            '        If i = 4 Then
            '            '-- la caja
            '            Numero = lv.Items(j).SubItems(4).Text
            '            lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,##0")
            '        End If
            '        If i = 5 Then
            '            '-- el ingreso
            '            Numero = lv.Items(j).SubItems(5).Text
            '            lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "###,###,##0")
            '        End If
            '        If i = 6 Then
            '            '-- la diferencia
            '            Numero = lv.Items(j).SubItems(6).Text
            '            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
            '            lv.Items(j).SubItems(6).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
            '        End If
            '        tmpDouDife = CInt(lv.Items(j).SubItems(1).Text) - CInt(lv.Items(j).SubItems(2).Text)
            '        If tmpDouDife <> 0 Then
            '            '-- si hay diferencia
            '            lv.Items(j).SubItems(0).BackColor = Color.Pink
            '            lv.Items(j).SubItems(1).BackColor = Color.Pink
            '            lv.Items(j).SubItems(2).BackColor = Color.Pink
            '            lv.Items(j).SubItems(3).BackColor = Color.Pink
            '        End If
            '    Next
            'Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub



    '-- el detalle de la consulta de gastos particulares cargados en control de planilla de caja
    Public Sub SqlToLv_detalleGastoParticularPlanilla(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto
                    lv.Items(i).SubItems(3).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- monto
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta del porcentaje de utilidad para modificar los precios
    Public Sub SqlToLv_detallePorcentajePrecio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- precio
                    lv.Items(i).SubItems(7).BackColor = Color.GreenYellow
                    '-- % comprometido
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpModificado As Boolean
            'Dim strTmpNotaCredito As String
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- porcentaje
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0.##")
                        'lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 5 Then
                        '-- formato precio
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0")
                        'lv.Items(j).SubItems(5).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 6 Then
                        '-- formato costo
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 7 Then
                        '-- formato precio actual
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,##0")
                        'lv.Items(j).SubItems(9).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        '-- formato porcentaje utilidad
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Comic Sans MS"), 12, FontStyle.Regular)
                    End If

                    '-- si fue modificado su precio como mayor al actual
                    bolTmpModificado = lv.Items(j).SubItems(9).Text
                    If bolTmpModificado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    Else
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las drogas en la accion terapéutica de la mercaderia
    Public Sub SqlToLv_detalleDroga(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantidad
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim strTmpNotaCredito As String
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        '-- cantidad
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de nota de credito de cliente cargadas del detalle de nota de credito temporal
    Public Sub SqlToLv_detalleNotaDebitoTmp(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantidad
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                    '-- el subTotal
                    lv.Items(i).SubItems(9).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- cantidad
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0")
                        lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato precio
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de carga de la cancelacion de canjes por nc
    Public Sub SqlToLv_detalleCancelaCanjeNC(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantidad
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                    '-- el subTotal
                    lv.Items(i).SubItems(8).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- cantidad
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0")
                        lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato costo
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0.##")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las mercaderias fraccionadas cargadas y consultadas
    Public Sub SqlToLv_detalleFraccionadoDetalle(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- precio
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                    '-- cantidad
                    lv.Items(i).SubItems(3).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los menus del restaurante habilitados para el dia
    Public Sub SqlToLv_detalleMenuRestoDelDia(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- precio
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de mercaderias controladas cargadas
    Public Sub SqlToLv_detalleMercaderiaControlada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- saldo anterior
                    lv.Items(i).SubItems(5).BackColor = Color.LightGreen
                    '-- entrada
                    lv.Items(i).SubItems(6).BackColor = Color.GreenYellow
                    '-- salida
                    lv.Items(i).SubItems(7).BackColor = Color.LightPink
                    '-- saldo
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- saldo anterior
                        lv.Items(j).SubItems(5).Text = Numero.ToString("##0")
                        'lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- entrada
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##0")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- salida
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##0")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- saldo
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##0")
                        'lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de compras cargadas del detalle de compra temporal
    Public Sub SqlToLv_detalleRemisionTmp(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- la  cantidad
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                    '-- % comprometido
                    'lv.Items(i).SubItems(11).BackColor = Color.GreenYellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpError As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- precio
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##,###,##0")
                        'lv.Items(j).SubItems(4).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato de cantidad pedida
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0")
                        'lv.Items(j).SubItems(7).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato de la cantidad
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "#,##0.##")
                        lv.Items(j).SubItems(8).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    '-- si tiene un error de porcentaje comprometido
                    bolTmpError = lv.Items(j).SubItems(13).Text
                    If bolTmpError = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    Else
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de vuelto en delivery
    Public Sub SqlToLv_detalleVueltoDelivery(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(3).BackColor = Color.LightCoral
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- idVenta
                        lv.Items(j).SubItems(0).Text = Numero.ToString("###,###,###")
                    End If
                    '-- total venta
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato total
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- vuelto
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato vuelto
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las mercaderias como pendiente de una remision
    Public Sub SqlToLv_detalleRemisionPendienteRepartidor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato precio
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las mercaderias que tienen problema en la recepcion
    Public Sub SqlToLv_detalleMercaderiaProblemaRecepcionPendiente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(4).BackColor = Color.Lime
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- cantidad
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato stock
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de venta de sucursales
    Public Sub SqlToLv_detalleConsultaVentaSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    '-- IVA
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato IVA
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "###")
                    End If
                    '-- cantidad
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,##0.00")
                    End If
                    '-- subtotal
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar el las ventas a buscar en la consulta
    Public Sub SqlToLv_ventaBusqueda(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(7).Text
                    '-- colocar el color la fuente
                    If valorNumero = 2 Then
                        '- si es no impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    Else
                        '-- para el impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    End If
                    '--------------------------------------
                    '-- para el total
                    If i = 5 Then
                        '-- formato para el total
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,###,###.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la recepcion
    Public Sub SqlToLv_detalleCanje(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If j = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    '-- precio
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato precio
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- costo
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato precio
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    '-- subtotal
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle del ajuste de mercaderia
    Public Sub SqlToLv_detalleAjusteMercaderia(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(7).BackColor = Color.LightCoral
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato precio
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,###.00")
                    End If
                    '-- cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,###.00")
                    End If
                    '-- subtotal
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle en consulta de mercaderias controladas
    Public Sub SqlToLv_detalleConsultaMercaderiaControlada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- existencia anterior
                        lv.Items(j).SubItems(65).Text = Format(CDec(Numero), "##0")
                    End If
                    '-- entrada
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##0")
                    End If
                    '-- salida
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##0")
                    End If
                    '-- saldo
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle del pedido a proveedor
    Public Sub SqlToLv_detallePedidoProveedor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(4).BackColor = Color.LightCoral
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpPendiente As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- pintar las letras de las mercaderias que están como pendientes
                    bolTmpPendiente = lv.Items(j).SubItems(6).Text
                    If bolTmpPendiente = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                    '-- columnas
                    '-- cantidad
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.00")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- la cabecera de los creditos del cliente en el historico
    Public Sub SqlToLv_cabeceraHistoricoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i2).SubItems(3).BackColor = Color.PaleGreen
                    '-- la nota de credito
                    lv.Items(i2).SubItems(4).BackColor = Color.LightCoral
                    '-- el pago
                    lv.Items(i2).SubItems(5).BackColor = Color.Thistle
                    '-- el saldo
                    lv.Items(i2).SubItems(6).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim douTmpMonto As Integer = 0
            Dim douTmpNotaCr As Integer = 0
            Dim douTmpPagado As Integer = 0
            Dim douTmpSaldo As Integer = 0
            ' MsgBox("Valor de column  " & Column)
            ' MsgBox("Valor de field  " & Field)

            'Formato numero
            Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    '--  monto
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                        douTmpMonto = douTmpMonto + CDbl(lv.Items(j).SubItems(3).Text)
                    End If
                    '--  nota de credito
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,##0")
                        douTmpNotaCr = douTmpNotaCr + CDbl(lv.Items(j).SubItems(4).Text)
                    End If
                    '--  pagado
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                        douTmpPagado = douTmpPagado + CDbl(lv.Items(j).SubItems(5).Text)
                    End If
                    '-- saldo
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                        douTmpSaldo = douTmpSaldo + CDbl(lv.Items(j).SubItems(6).Text)
                    End If

                    lv.Columns(i).TextAlign = HorizontalAlignment.Center
                Next
            Next

            frmHistoricoCliente.txtTotalMonto.Text = douTmpMonto
            frmHistoricoCliente.txtTotalMonto.Text = Format(CDec(frmHistoricoCliente.txtTotalMonto.Text), "##,###,##0")
            frmHistoricoCliente.txtTotalPagado.Text = douTmpPagado
            frmHistoricoCliente.txtTotalPagado.Text = Format(CDec(frmHistoricoCliente.txtTotalPagado.Text), "##,###,##0")
            frmHistoricoCliente.txtTotalSaldo.Text = douTmpSaldo
            frmHistoricoCliente.txtTotalSaldo.Text = Format(CDec(frmHistoricoCliente.txtTotalSaldo.Text), "##,###,##0")
            frmHistoricoCliente.txtTotalNotaCredito.Text = douTmpNotaCr
            frmHistoricoCliente.txtTotalNotaCredito.Text = Format(CDec(frmHistoricoCliente.txtTotalNotaCredito.Text), "##,###,##0")

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los creditos del cliente en el historico
    Public Sub SqlToLv_detalleHistoricoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i2).SubItems(1).BackColor = Color.PaleGreen
                    '-- el pago
                    lv.Items(i2).SubItems(2).BackColor = Color.Thistle
                    '-- el saldo
                    lv.Items(i2).SubItems(3).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            ' MsgBox("Valor de column  " & Column)
            ' MsgBox("Valor de field  " & Field)

            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpVencido As Boolean
            For i = 0 To Column
                For j = 0 To Field
                    '--  cuota
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '--  pagado
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- saldo
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- pintar en rojo las cuotas vencidas
                    bolTmpVencido = lv.Items(j).SubItems(9).Text
                    If bolTmpVencido = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If

                    lv.Columns(i).TextAlign = HorizontalAlignment.Center
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de pedido a proveedor por envio
    Public Sub SqlToLv_detallePedidoProveedorEnvio(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            'Determinamos la cantidad de resultados
            'Dim i As Integer
            'For i = 0 To ds.Tables(0).Columns.Count - 1
            '    lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            'Next

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            ''-- pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- la venta
                    'lv.Items(i2).SubItems(1).BackColor = Color.LightGreen
                    '-- el envio
                    'lv.Items(i2).SubItems(2).BackColor = Color.LightSkyBlue
                    '-- el stock
                    'lv.Items(i2).SubItems(3).BackColor = Color.LightSeaGreen
                    '-- el stock total
                    lv.Items(i2).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            'Anchor()
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer
            Dim bolTmpFueraLinea As Boolean
            Dim bolTmpControlado As Boolean

            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- formato venta
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato envio
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato pendiente
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato de stock
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato de stock total
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato de pedido
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- fuera de linea
                    bolTmpFueraLinea = lv.Items(j).SubItems(11).Text
                    If bolTmpFueraLinea = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                    '-- controlados
                    bolTmpControlado = lv.Items(j).SubItems(14).Text
                    If bolTmpControlado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.ForestGreen
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de pedido a proveedor por envio
    Public Sub SqlToLv_detallePedidoSucursalEliminar(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer
            Dim tmpDouStock As Double = 0
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- stock
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- ventas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- pedido
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- envio
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- pendiente
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- el stock
                    tmpDouStock = CDbl(lv.Items(j).SubItems(2).Text)
                    If tmpDouStock > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LimeGreen
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    ' solo para listar el stock de los productos
    Public Sub SqlToLv_producto_busquedaCancelarCanje(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(6).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '-- para el costo
                    If i = 3 Then
                        '-- formato para el costo
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,###.##")
                    End If
                    '-- cantidad de canje
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,###.##")
                    End If
                    '-- cantidad recepciona
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("#,###.##")
                    End If
                    '-- stock
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("#,###.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de nota de credito
    Public Sub SqlToLv_detalleNotaCreditoCanje(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpNumero As Boolean
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 0 Then
                        Numero = lv.Items(j).SubItems(0).Text
                        '-- el codigo del producto
                        lv.Items(j).SubItems(0).Text = Numero.ToString("######")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- el porcentaje del impuesto
                        'MsgBox("Impuesto  " & Numero)
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##")
                    End If
                    '-- el costo
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        'MsgBox("Costo  " & Numero)
                        If Numero > 0 Then
                            lv.Items(j).SubItems(6).Text = Numero.ToString("#,###,###.##")
                        Else
                            lv.Items(j).SubItems(6).Text = 0
                        End If
                    End If
                    '-- costo original
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        'MsgBox("Costo Or  " & Numero)
                        '-- el costo
                        If Numero > 0 Then
                            lv.Items(j).SubItems(7).Text = Numero.ToString("#,###,###.##")
                        Else
                            lv.Items(j).SubItems(7).Text = 0
                        End If
                    End If
                    '-- la cantidad
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        'MsgBox("Cantidad  " & Numero)
                        lv.Items(j).SubItems(8).Text = Numero.ToString("###")
                    End If
                    '-- subtotal
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        'MsgBox("Subtotal  " & Numero)
                        lv.Items(j).SubItems(9).Text = Numero.ToString("##,###,###.##")
                    End If
                    bolTmpNumero = lv.Items(j).SubItems(10).Text
                    '-- colocar el color de fondo a los productos de canje que descontaron stock
                    If bolTmpNumero = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las compras de la nota de credito de canje
    Public Sub SqlToLv_detalleCompraNotaCreditoCanje(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- el total
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        'MsgBox("Costo  " & Numero)
                        If Numero > 0 Then
                            lv.Items(j).SubItems(2).Text = Numero.ToString("#,###,###.##")
                        Else
                            lv.Items(j).SubItems(2).Text = 0
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle dee cheques cargados para orden de pago a proveedores
    Public Sub SqlToLv_consultaChequePagoProveedor(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- el monto del cheque
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de movimientos de pago a proveedor 
    Public Sub SqlToLv_detallePagoProveedorMov(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- total factura
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- total nota de credito
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- total canje
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- total a pagar
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,###.##")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de movimientos de pago a proveedor 
    Public Sub SqlToLv_detallePagoProveedorEfectivo(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(1).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- total factura
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- formato cantidad
                        If Numero < 1 And Numero > 0 Then
                            lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "0.##")
                        Else
                            lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,###,###.##")
                        End If
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de movimientos de pago a proveedor 
    Public Sub SqlToLv_detallePagoProveedorCheque(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- monto
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de los gastos del proveedor
    Public Sub SqlToLv_detalleGastoProveedor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- el porcentaje de IVA
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "###")
                    End If
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- el costo
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la compra para la consulta ne la nota de credito de canje
    Public Sub SqlToLv_consultaCompraNotaCreditoCanje(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- el total
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar la cabecera de pago en el historico de clientes
    Public Sub SqlToLvCabeceraPagoHistoricoCliente(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i2).SubItems(3).BackColor = Color.PaleGreen
                    '-- la nota de credito
                    lv.Items(i2).SubItems(4).BackColor = Color.LightCoral
                    '-- el pago
                    lv.Items(i2).SubItems(5).BackColor = Color.Thistle
                    '-- el saldo
                    lv.Items(i2).SubItems(6).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            ' MsgBox("Valor de column  " & Column)
            ' MsgBox("Valor de field  " & Field)

            'Formato numero
            Dim Numero As Decimal
            For i = 0 To Column
                For j = 0 To Field
                    '--  monto
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '--  nota de credito
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '--  pagado
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '-- saldo
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,###")
                    End If

                    lv.Columns(i).TextAlign = HorizontalAlignment.Center
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- detalle del pedido de mercaderia
    Public Sub SqlToLv_detalleMercaderiaHistorico(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)
                    '-- formato de la cantidad
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,##0")
                    End If
                    '-- formato del subtotal
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "#,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el detalle de pago en el historico de clientes
    Public Sub SqlToLvDetallePagoHistoricoCliente(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i2).SubItems(1).BackColor = Color.PaleGreen
                    '-- el pago
                    lv.Items(i2).SubItems(2).BackColor = Color.Thistle
                    '-- el saldo
                    lv.Items(i2).SubItems(3).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            ' MsgBox("Valor de column  " & Column)
            ' MsgBox("Valor de field  " & Field)

            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpVencido As Boolean
            For i = 0 To Column
                For j = 0 To Field
                    '--  cuota
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '--  pagado
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '-- saldo
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '-- pintar en rojo las cuotas vencidas
                    bolTmpVencido = lv.Items(j).SubItems(9).Text
                    If bolTmpVencido = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If

                    lv.Columns(i).TextAlign = HorizontalAlignment.Center
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- listar el detalle de cobro a clientes
    Public Sub SqlToLvDetalleCobroCliente(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i2 As Integer = 0 To lv.Items.Count - 1
                lv.Items(i2).UseItemStyleForSubItems = False
                If lv.Items(i2).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i2).SubItems(5).BackColor = Color.PaleGreen
                    '-- nota de credito
                    lv.Items(i2).SubItems(6).BackColor = Color.Pink
                    '-- el pagado
                    lv.Items(i2).SubItems(8).BackColor = Color.Thistle
                    '-- el pago
                    lv.Items(i2).SubItems(9).BackColor = Color.Aquamarine
                    '-- el saldo
                    lv.Items(i2).SubItems(10).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            ' MsgBox("Valor de column  " & Column)
            ' MsgBox("Valor de field  " & Field)

            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpPagado As Boolean
            For i = 0 To Column
                For j = 0 To Field
                    '--  cuota
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '--  nota de credito
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- retencion
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- pagado
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- pago
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- saldo
                    If i = 10 Then
                        Numero = lv.Items(j).SubItems(10).Text
                        lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- pintar en rojo los pagos
                    bolTmpPagado = CBool(lv.Items(j).SubItems(11).Text)
                    If bolTmpPagado = True Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightPink
                    End If

                    'lv.Columns(i).TextAlign = HorizontalAlignment.Center
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    '-- el detalle de la retencion de proveedor
    Public Sub SqlToLv_detalleRetencionProveedor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                        'MsgBox("Valor  " & i)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total Venta
                    lv.Items(i).SubItems(3).BackColor = Color.GreenYellow
                    '-- el subTotal
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- totalVenta
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0")
                        'lv.Items(j).SubItems(3).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el orden de preparado de coral
    Public Sub SqlToLv_listarOrdenPreparadoCoral(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- onza
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                    '-- pulso
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow

                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 4 Then
                        '-- gramo
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 5 Then
                        '-- onza
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 6 Then
                        '-- pulso
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("###,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el detalle 
    Public Sub SqlToLv_listarDevolucionCompra(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantiad compra
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                    '-- cantidad cargada
                    lv.Items(i).SubItems(5).BackColor = Color.Pink
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0")
                    End If
                    If i = 4 Then
                        '-- cantidad de compra
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 5 Then
                        '-- cantidad cargada
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el detalle de la recepcion de compra comprometida
    Public Sub SqlToLv_listarRecepcionCompra(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantiad compra
                    lv.Items(i).SubItems(3).BackColor = Color.Yellow
                    '-- cantidad cargada
                    lv.Items(i).SubItems(4).BackColor = Color.Pink
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        '-- cantidad de compra
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 4 Then
                        '-- cantidad cargada
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 5 Then
                        '-- saldo
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listar el detalle de producto en la compra para la devolucion comprometida
    Public Sub SqlToLv_listarProductoDevolucionCompra(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantiad compra
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        '-- cantidad de compra
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 3 Then
                        '-- bonificacion
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 4 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("##,###,##0")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de la mercaderia comprada al proveedor
    Public Sub SqlToLv_detalleMercaderiaNotaCredito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- costo 
                    lv.Items(i).SubItems(6).BackColor = Color.LightPink
                    '-- costo nuevo
                    lv.Items(i).SubItems(8).BackColor = Color.Yellow
                    '-- descuento
                    lv.Items(i).SubItems(9).BackColor = Color.LightBlue
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    '-- columnas
                    If i = 6 Then
                        '-- formato costo
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "###,###,##0.##")
                    End If
                    If i = 7 Then
                        '-- formato de iva
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##")
                    End If
                    If i = 8 Then
                        '-- formato costo actual
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                    If i = 9 Then
                        '-- formato descuento
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de mercaderias compradas al proveedor
    Public Sub SqlToLv_consultaDetalleMercaderiaCompraProveedor(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        '-- costo
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "###,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- listar el detalle de producto en la devolucion de compra
    Public Sub SqlToLv_listarProductoRecepcionCompra(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantiad compra
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                    '-- cantiad saldo
                    lv.Items(i).SubItems(3).BackColor = Color.Cyan
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        '-- cantidad de compra
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 3 Then
                        '-- saldo
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- listar el orden de preparado de automotive
    Public Sub SqlToLv_listarOrdenPreparadoAutomotive(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- gramo
                    lv.Items(i).SubItems(2).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 2 Then
                        '-- gramo
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 3 Then
                        '-- acumulado
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 4 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 5 Then
                        '-- precio or
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- listar el orden de preparado de suvinil
    Public Sub SqlToLv_listarOrdenPreparadoSuvinil(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- pulso
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim bolTmpAnulada As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    If i = 3 Then
                        '-- precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 4 Then
                        '-- gramo
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,##0.##")
                    End If
                    If i = 5 Then
                        '-- pulso
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la cobranza en la consulta
    Public Sub SqlToLv_detalleCobranza(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- la cuota
                    lv.Items(i).SubItems(4).BackColor = Color.Aquamarine
                    '-- lo cobrado
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- cuota
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                    '-- cobrado
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el grupo de cliente con descuentos
    Public Sub SqlToLv_detalleGrupoClienteDescuento(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            'For i As Integer = 0 To lv.Items.Count - 1
            '    lv.Items(i).UseItemStyleForSubItems = False
            '    If lv.Items(i).SubItems.Count > 1 Then
            '        -- la cuota
            '        lv.Items(i).SubItems(4).BackColor = Color.Aquamarine
            '        -- lo cobrado
            '        lv.Items(i).SubItems(5).BackColor = Color.Yellow
            '    End If
            'Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de la consumicion de la habitacion
    Public Sub SqlToLv_detalleConsultaConsumeHabitacion(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- precio
                    lv.Items(i).SubItems(3).BackColor = Color.Aquamarine
                    '-- subtotal
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                    '-- cantidad
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##0.##")
                    End If

                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")

                        '-- subtotal
                        'tmpDouSubTotal = tmpDouSubTotal + CDbl(lv.Items(j).SubItems(5).Text)
                        'MsgBox("fila " & j)
                        'MsgBox("Suma de subTotal " & tmpDouSubTotal)
                        'MsgBox("Valor Nro " & lv.Items(j).SubItems(0).Text)
                        'MsgBox("Total " & Format(CDec(lv.Items(j).SubItems(5).Text), "##,###,##0"))
                        '-- sumar el total de la consumicion

                        'MsgBox("SubTotal " & Format(CDec(tmpDouSubTotal), "##,###,##0"))
                    End If

                Next
            Next
            'MsgBox("Total " & tmpDouSubTotal)
            'frmConsultaFacturaHotel.txtTotalDetalleConsume.Text = tmpDouSubTotal
            'frmConsultaFacturaHotel.txtTotalDetalleConsume.Text = Format(CDec(frmConsultaFacturaHotel.txtTotalDetalleConsume.Text), "###,###,###.##")
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de la consumicion de la habitacion
    Public Sub SqlToLv_detalleConsultaConsumicionHabitacionHuesped(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la cobranza en la consulta
    Public Sub SqlToLv_detalleProductoReferenciaMasLote(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- cantidad
                    lv.Items(i).SubItems(2).BackColor = Color.Aquamarine
                    '-- stock
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- cantidad
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- formato precio
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##0.##")
                    End If
                    '-- stock
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de checkIn
    Public Sub SqlToLv_detalleConsultaCheckIn(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        '-- formato precio dolar
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "###,##0.##")
                    End If
                    If i = 7 Then
                        '-- formato precio
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las compras y gastos de los cheques
    Public Sub SqlToLv_detalleCompraGastoCheque(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- el monto
                    lv.Items(i).SubItems(3).BackColor = Color.Aquamarine
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- total
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato total
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "###,###,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- consulta de todos los cliente en telemarketing
    Public Sub SqlToLv_consultaTodosClienteTeleMarketing(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- el nombre del grupo de cliente
                    lv.Items(i).SubItems(3).BackColor = Color.Aquamarine
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim intTmpTipo As Integer
            Dim bolTele As Boolean

            For i = 0 To Column
                For j = 0 To Field
                    '-- pintar en rojo los clientes que ya fueron llamados
                    intTmpTipo = lv.Items(j).SubItems(5).Text
                    If intTmpTipo = 1 Then
                        '-- nada
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    If intTmpTipo = 2 Then
                        '-- farmacia - heladeria
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    If intTmpTipo = 3 Then
                        '-- hotel
                        lv.Items(j).SubItems(i).BackColor = Color.Violet
                    End If
                    If intTmpTipo = 4 Then
                        '-- farmacia - heladeria - hortel
                        lv.Items(j).SubItems(i).BackColor = Color.DeepSkyBlue
                    End If
                    If intTmpTipo = 5 Then
                        '-- pendiente
                        lv.Items(j).SubItems(i).BackColor = Color.Gold
                    End If
                    bolTele = CBool(lv.Items(j).SubItems(4).Text)
                    If bolTele = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- consulta de todos los cliente en telemarketing
    Public Sub SqlToLv_consultaMaxiPuntoTelemarketing(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- el nombre del grupo de cliente
                    lv.Items(i).SubItems(3).BackColor = Color.Aquamarine
                End If
            Next
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- consulta de ABC de cliente
    Public Sub SqlToLv_consultaABCcliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            PintarLv(lv)
            '----------------------------------------------------------

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub



    '-- consulta del detalle de compras de cliente en telemarketing
    Public Sub SqlToLv_consultaCompraClienteTelemarketing(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("PAso 1")
            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            'MsgBox("PAso 2")

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            'MsgBox("Antes de contar los registros")
            'frmVentaTeleMark.ProgressBar1.Visible = True

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                        '-- incrementar el formulario
                        'frmBarraProgreso.ProgressBar1.Value = i
                    Next
                End If
            Next

            '-- para pintar las columnas
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- el nombre del grupo de cliente
                    lv.Items(i).SubItems(5).BackColor = Color.Aquamarine
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- formato precio
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###,###")
                    End If
                    '-- cantidad
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato cantidad
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "###")
                    End If
                    '-- subTotal
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- formato subTotal
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "#,###,###")
                    End If

                Next
            Next
            '-- salir del formulario de la barra de progreso
            'MsgBox("Fin del procedimiento")
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la cobranza en la consulta
    Public Sub SqlToLv_detalleConsultaOrdenCheque(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    '-- monto
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- formato precio
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de los gastos del proveedor
    Public Sub SqlToLv_detalleCuotaDescuentoCliente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmCargarDescuentos.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    ' MsgBox("Valor de j  " & j)

                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        '-- el monto de la cuota
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,###,##.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- listado de clientes
    Public Sub SqlToLv_Clientes(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            'MsgBox("Paso por aca")

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim valorNumero As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    valorNumero = lv.Items(j).SubItems(5).Text
                    ' MsgBox("Valor  " & valorNumero)
                    '-- colocar el color la fuente de acuerdo si es a credito
                    If valorNumero = True Then
                        '- si es no impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Black
                    Else
                        '-- para el impreso
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los inventarios abiertos del mismo usuario
    Public Sub SqlToLv_detalleInventarioDeposito(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los inventarios abiertos del mismo usuario
    Public Sub SqlToLv_detalleArchivoTxt(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmArchivoEstudioContable.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- la cabecera del archivo txt para el inventario
    Public Sub SqlToLv_cabeceraInventarioTxt(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- la cabecera del archivo txt para el inventario
    Public Sub SqlToLv_detalleInventarioTxt(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- archivo de venta para el estudio contable
    Public Sub SqlToLv_archivoTxtEstudio(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la retencion de la venta
    Public Sub SqlToLv_detalleConsultaRetencionProveedor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                        'MsgBox("Valor  " & i)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total Venta
                    lv.Items(i).SubItems(3).BackColor = Color.GreenYellow
                    '-- el subTotal
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- totalVenta
                        lv.Items(j).SubItems(3).Text = Numero.ToString("#,##0")
                        'lv.Items(j).SubItems(3).Font = New Font(New FontFamily("Arial"), 12, FontStyle.Regular)
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- formato subtotal
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las cuotas configuradas
    Public Sub SqlToLv_configuracionCuota(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del monto desde
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "###,###,###")
                    End If
                    '-- formato del monto hasta
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "###,###,###")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de los montos de proveedores cargados para los cheuqes
    Public Sub SqlToLv_detalleOrdenCheque(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del monto del cheque
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "###,###,###.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la remision express
    Public Sub SqlToLv_detalleRemisionExpress(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            ' MsgBox("PAso 1")

            'MsgBox("sql " & sql)
            'frmRemisionPendiente.txtSql.Text = sql

            'MsgBox("PAso 2")

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '  MsgBox("Cantidad " & lv.Items(j).SubItems(i).Text)
                    '-- formato de la cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text

                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "###,###,##0.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la remision entre las sucursales
    Public Sub SqlToLv_detalleRemisionEnteSucursalesPendiente(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato de la cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la remision express
    Public Sub SqlToLv_detallePrecioSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(6).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del precio
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "###,###,###")
                    End If
                    '-- formato del precio de descuento
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "###,###,###")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los agregados para bellini
    Public Sub SqlToLv_detalleAgregadoBellini(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    lv.Items(i).SubItems(4).BackColor = Color.Yellow
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del monto
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "###,###,##0")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los montos de proveedores cargados para los cheques para imprimir
    Public Sub SqlToLv_detalleOrdenChequeImprimir(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del monto del cheque
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "###,###,###.##")
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de las modificaciones de vencimientos
    Public Sub SqlToLv_detalleModiVence(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- formato del stock auditado
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad ingresada
                    If i = 10 Then
                        Numero = lv.Items(j).SubItems(10).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(10).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle del pedido de mercaderia
    Public Sub SqlToLv_detalleProductoInventario(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            'frmBuscarProductoInventario.txtSql.Text = sql
            'MsgBox("Valor de la consulta " & sql)

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorNumero As Integer
            Dim bolTmpAuditado As Boolean
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorNumero = lv.Items(j).SubItems(4).Text
                    '-- colocar el color de fondo
                    '- stock positivo
                    If valorNumero > 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- stock en cero
                    If valorNumero = 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- stock negativo
                    If valorNumero < 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- si está auditado la mercaderia
                    bolTmpAuditado = lv.Items(j).SubItems(6).Text
                    If bolTmpAuditado = True Then
                        lv.Items(j).SubItems(i).ForeColor = Color.Red
                    End If

                    '-- formato del precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###.##")
                    End If
                    '-- formato del stock
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero > 0 And Numero < 1 Then
                            lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos cargados en el inventario
    Public Sub SqlToLv_detalleInventarioCargado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorStock As Double
            Dim valorCantidad As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorStock = CDbl(lv.Items(j).SubItems(7).Text)
                    valorCantidad = CDbl(lv.Items(j).SubItems(8).Text)

                    '-- colocar el color de fondo
                    '- sobrantes
                    If valorStock < valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- sin diferencia
                    If valorStock = valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- faltantes
                    If valorStock > valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- formato del precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###.##")
                    End If
                    '-- formato del stock
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos cargados en el inventario para el procesamiento
    Public Sub SqlToLv_detalleInventarioProcesado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorStock As Double
            Dim valorCantidad As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorStock = CDbl(lv.Items(j).SubItems(5).Text)
                    valorCantidad = CDbl(lv.Items(j).SubItems(4).Text)

                    '-- colocar el color de fondo
                    '- sobrantes
                    If valorStock < valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- sin diferencia
                    If valorStock = valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- faltantes
                    If valorStock > valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- formato del stock
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos cargados en el inventario  en la consulta
    Public Sub SqlToLv_detalleInventarioConsulta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorStock As Double
            Dim valorCantidad As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorStock = CDbl(lv.Items(j).SubItems(8).Text)
                    valorCantidad = CDbl(lv.Items(j).SubItems(9).Text)

                    '-- colocar el color de fondo
                    '- sobrantes
                    If valorStock < valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- sin diferencia
                    If valorStock = valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- faltantes
                    If valorStock > valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- formato del precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###.##")
                    End If
                    '-- formato del stock Actual
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato del stock auditado
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad auditada
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(9).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar los productos inventariados dentro del inventario
    Public Sub SqlToLv_productoEnInventario(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorCantidad As Double
            Dim valorStock As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- la cantidad auditada
                    valorCantidad = lv.Items(j).SubItems(9).Text
                    '-- el stock auditado
                    valorStock = lv.Items(j).SubItems(8).Text
                    '-- colocar el color de fondo
                    '- los sobrantes
                    If valorCantidad > valorStock Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- los faltantes
                    If valorCantidad < valorStock Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If
                    '--------------------------------------
                    '--- formatos
                    '--------------------------------------
                    '-- para el precio
                    If i = 3 Then
                        '-- formato para el precio
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Numero.ToString("##,###,###.##")
                    End If
                    '-- para el stock
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("###,###.##")
                    End If
                    '-- para el stock auditado
                    If i = 8 Then
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Numero.ToString("###,###.##")
                    End If
                    '-- para la cantidad
                    If i = 9 Then
                        Numero = lv.Items(j).SubItems(9).Text
                        lv.Items(j).SubItems(9).Text = Numero.ToString("###,###.##")
                    End If


                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos no inventariados a cargar
    Public Sub SqlToLv_detalleNoInventariadoACargar(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmNoInventariado.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorStock As Double
            Dim valorCantidad As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorStock = CDbl(lv.Items(j).SubItems(6).Text)
                    valorCantidad = CDbl(lv.Items(j).SubItems(7).Text)

                    '-- colocar el color de fondo
                    '- sobrantes
                    If valorStock < valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- sin diferencia
                    If valorStock = valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- faltantes
                    If valorStock > valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- formato del precio
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,###.##")
                    End If
                    '-- formato del stock
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- detalle de los cierres de inventario habilitados
    Public Sub SqlToLv_cierreHabilitados(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los canjes con la misma compra
    Public Sub SqlToLv_detalleCanjeCompra(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- el total
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,###,###.##")
                        lv.Items(j).SubItems(2).BackColor = Color.Aqua
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos cargados en el inventario para el procesamiento
    Public Sub SqlToLv_detalleProductoInventariado(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim valorStock As Double
            Dim valorCantidad As Double
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field

                    valorStock = CDbl(lv.Items(j).SubItems(7).Text)
                    valorCantidad = CDbl(lv.Items(j).SubItems(6).Text)

                    '-- colocar el color de fondo
                    '- sobrantes
                    If valorStock < valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightGreen
                    End If
                    '- sin diferencia
                    If valorStock = valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.White
                    End If
                    '- faltantes
                    If valorStock > valorCantidad Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightCoral
                    End If

                    '-- formato del stock
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If
                    '-- formato de la cantidad
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        If Numero < 1 Then
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,##0.##")
                        Else
                            lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "##,###.##")
                        End If
                    End If

                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos pendientes de sucursales en el pedido a proveedor
    Public Sub SqlToLv_detallePedidoPendienteSucursal(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer
            Dim bolTmpFueraLinea As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'MsgBox("Valor de i  " & i)
                'filas
                For j = 0 To Field
                    '-- si está fuera de linea
                    If i = 9 Then
                        bolTmpFueraLinea = CBool(lv.Items(j).SubItems(9).Text)
                        If bolTmpFueraLinea = True Then
                            lv.Items(j).SubItems(i).ForeColor = Color.Red
                        End If
                    End If
                    '-- formato venta
                    If i = 1 Then
                        Numero = lv.Items(j).SubItems(1).Text
                        lv.Items(j).SubItems(1).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato envio
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato de stock
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                    '-- formato de pedido
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "##,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar el stock de las sucursal para el pedido al proveedor
    Public Sub SqlToLv_stockSucursalPedidoProveedor(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 1 Then
                        'MsgBox("Entro en la columna 3", MsgBoxStyle.Information)
                        '-- formato para el stock
                        Numero = lv.Items(j).SubItems(1).Text
                        If Numero > 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###,###.##")
                        End If

                        If Numero = 0 Then
                            lv.Items(j).SubItems(1).Text = "0"
                        End If

                        If Numero > 0 And Numero < 999 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("###.##")
                        End If

                        If Numero < 0 Then
                            lv.Items(j).SubItems(1).Text = Numero.ToString("#,###.##")
                        End If
                        'MsgBox("Fin de la columna 3", MsgBoxStyle.Information)
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar las mercaderias a pedir de la sucursal
    Public Sub SqlToLv_mercaderiaAPedirSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        lv.Items(j).SubItems(4).Text = Format(CDec(Numero), "#,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar las mercaderias pendientes en los pedidos entre sucursales
    Public Sub SqlToLv_mercaderiaPendienteEntreSucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim douTmpStock As Double = 0
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    If i = 7 Then
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                    douTmpStock = CDbl(lv.Items(j).SubItems(7).Text)
                    If douTmpStock <= 0 Then
                        lv.Items(j).SubItems(i).BackColor = Color.LightPink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' para listar las mercaderias pedidas de Sucursal a sucursal
    Public Sub SqlToLv_mercaderiaPedidoDeSucursalASucursal(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        '-- cantidad
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,##0.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los productos controlados en la venta de la farmacia
    Public Sub SqlToLv_detalleMercaderiaControladoVenta(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- la cantidad
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,###.##")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los los recibos de cobranzas
    Public Sub SqlToDg_detalleCompraGasto(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                dg.Rows(i).Cells(13).Value = CBool(ds.Tables("resultado").Rows(i).Item(13).ToString)
                dg.Rows(i).Cells(14).Value = CBool(ds.Tables("resultado").Rows(i).Item(14).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los los recibos de cobranzas
    Public Sub SqlToDg_detalleVentaManual(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                dg.Rows(i).Cells(13).Value = CBool(ds.Tables("resultado").Rows(i).Item(13).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los inventarios abiertos del mismo usuario
    Public Sub SqlToLv_detalleUltimosProductosVendidos(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmHabilitarCorreccionInventario.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'Dim valorNumero As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- la cantidad
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        lv.Items(j).SubItems(2).Text = Format(CDec(Numero), "#,###.##")
                    End If
                    '-- el subtotal
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        lv.Items(j).SubItems(3).Text = Format(CDec(Numero), "#,###,###.##")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub
    '***********************'
    '-- PARA LOS DATAGRID --'
    '***********************'
    '-- el detalle de los productos referenciados encontrados para rellenar el datagridview
    Public Sub SqlToDg_productoRef(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los descuentos por grupo de cliente
    Public Sub SqlToDg_descuentoGrupoCliente(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- cargar el descuento de grupo de cliente temporal
    Public Sub SqlToDg_descuentoGrupoClienteTmp(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                '-- idDescuentoGrupoCliente
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                '-- nombre del grupo de cliente
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                '-- habilitado
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                '-- idGrupoCliente
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- cargar el descuento de tipo de venta
    Public Sub SqlToDg_descuentoTipoVentaTmp(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                '-- idTipoVenta
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                '-- nombre del tipo de Venta
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                '-- habilitado
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los pedidos de mercaderias
    Public Sub SqlToDg_pedidoMercaderia(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del menu principal
    Public Sub SqlToDg_detalleMenuPrincipal(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            'frmPermisoUsuario.txtBuscarGrupoUsuario.Text = consulta
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                '-- idGrupoUsuario
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                '-- nombre del formulario
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                '-- explicacion del formulario
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                '-- nombre del tipo de menu
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                '-- habilitado
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- una prueba de como llenar un datagridview desde una sp
    Public Sub SqlToDg_datagrid(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                'MsgBox("llego a este punto", MsgBoxStyle.Information)
                'dg.Refresh()
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- cargar los codigos de barras que están pendientes de impresion
    Public Sub SqlToDg_codigoBarraPendiente(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            ' MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de la Cotizacion de las monedas
    Public Sub SqlToDg_tablaCotiza(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = CDbl(ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = CDbl(ds.Tables("resultado").Rows(i).Item(4))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de la Cotizacion de las monedas
    Public Sub SqlToDg_formaVentaConvenio(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = CBool((ds.Tables("resultado").Rows(i).Item(2).ToString))
                dg.Rows(i).Cells(3).Value = CInt(ds.Tables("resultado").Rows(i).Item(3))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del tipo de producto del descuento de convenio
    Public Sub SqlToDg_tipoProductoConvenio(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = CDbl((ds.Tables("resultado").Rows(i).Item(2)))
                dg.Rows(i).Cells(3).Value = CDbl(ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = CInt((ds.Tables("resultado").Rows(i).Item(4)))
                dg.Rows(i).Cells(5).Value = CInt(ds.Tables("resultado").Rows(i).Item(5))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle del pedido a la casa matriz de la susursal
    Public Sub SqlToDg_pedidoASucursalFaltante(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = CDbl(ds.Tables("resultado").Rows(i).Item(4))
                dg.Rows(i).Cells(5).Value = CInt(ds.Tables("resultado").Rows(i).Item(5))
                dg.Rows(i).Cells(6).Value = CInt(ds.Tables("resultado").Rows(i).Item(6))
                dg.Rows(i).Cells(7).Value = CDbl(ds.Tables("resultado").Rows(i).Item(7))
                dg.Rows(i).Cells(8).Value = CDbl(ds.Tables("resultado").Rows(i).Item(8))

                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de la Cotizacion de las monedas
    Public Sub SqlToDg_configuracionCuota(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = CDbl(ds.Tables("resultado").Rows(i).Item(3))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los puntajes de clientes en la venta
    Public Sub SqlToDg_detallePuntajeCliente(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = CDbl(ds.Tables("resultado").Rows(i).Item(3))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los premios de los puntajes de los clientes
    Public Sub SqlToDg_detallePremioPuntajeCliente(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = CDbl(ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = CDbl(ds.Tables("resultado").Rows(i).Item(4))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub



    '-- el detalle de las facturas a credito a controlar
    Public Sub SqlToDg_controlarFacturaVenta(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Entro al ciclo")
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4))
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6))
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7))
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los cheques a entregar al personal
    Public Sub SqlToDg_entregaChequePersonal(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Entro al ciclo")
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4))
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6))
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7))
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8))
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9))
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del control de cheques
    Public Sub SqlToDg_controlCheque(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Entro al ciclo")
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4))
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6))
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7))
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle para seleccionar la impresion de las cajas
    Public Sub SqlToDg_imprimirCaja(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Entro al ciclo")
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4))
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6))
                'MsgBox("Valor  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los usuarios para generar el codigo de barras
    Public Sub SqlToDg_codigoBarraUsuario(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")

            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Entro al ciclo")
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0))
                'MsgBox("Valor de nro  " & (ds.Tables("Resultado").Rows(i).Item(0)))
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1))
                'MsgBox("Valor de idusuario  " & (ds.Tables("Resultado").Rows(i).Item(1)))
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2))
                'MsgBox("Valor de nick  " & (ds.Tables("Resultado").Rows(i).Item(2)))
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3))
                'MsgBox("Valor de nombre  " & (ds.Tables("Resultado").Rows(i).Item(3)))
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4))
                'MsgBox("Valor de apellido  " & (ds.Tables("Resultado").Rows(i).Item(0)))
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5))
                'MsgBox("Valor de grupo  " & (ds.Tables("Resultado").Rows(i).Item(5)))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6))
                'MsgBox("Valor de imprimir  " & (ds.Tables("Resultado").Rows(i).Item(6)))
            Next
        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los los movimientos de Proveedores para la Orden de Pago
    Public Sub SqlToDg_ordenPago(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                'MsgBox("Valor del total  " & (ds.Tables("resultado").Rows(i).Item(5).ToString))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                '-- total factura
                'dg.Rows(i).Cells(5).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(5).ToString), "##,###,###.##")
                '-- total nota de credito proveedor
                'dg.Rows(i).Cells(6).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(6).ToString), "##,###,###.##")
                '-- total nota de credito canje
                'dg.Rows(i).Cells(7).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(7).ToString), "##,###,###.##")

                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de las drogas consultadas en el vademecum
    Public Sub SqlToDg_drogaConsultada(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                'dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los los movimientos historicos de los descuentos por fecha corta del dia M
    Public Sub SqlToDg_fechaCortaDiaM(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los productos de cancelacion de canjes
    Public Sub SqlToDg_detalleCancelaCanje(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State
            'frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                'MsgBox("Valor del total  " & (ds.Tables("resultado").Rows(i).Item(5).ToString))
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                '-- total factura
                'dg.Rows(i).Cells(5).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(5).ToString), "##,###,###.##")
                '-- total nota de credito proveedor
                'dg.Rows(i).Cells(6).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(6).ToString), "##,###,###.##")
                '-- total nota de credito canje
                'dg.Rows(i).Cells(7).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(7).ToString), "##,###,###.##")
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                dg.Rows(i).Cells(13).Value = (ds.Tables("resultado").Rows(i).Item(13).ToString)
                dg.Rows(i).Cells(14).Value = (ds.Tables("resultado").Rows(i).Item(14).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del descuento de laboratorio por grupo de cliente
    Public Sub SqlToDg_descuentoLaboratorioGrupoCliente(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor " & sql)

            'frmGuardarDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del descuento de division y laboratorio 
    Public Sub SqlToDg_descuentoDivisionLaboratorio(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor " & sql)

            'frmGuardarDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle del descuento del black friday por tipo de venta
    Public Sub SqlToDg_descuentoLaboratorio(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmGuardarDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                'dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del descuento del black friday por tipo de venta
    Public Sub SqlToDg_descuentoBlackFridayTipoVenta(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmGuardarDescuentoLaboratorio.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle del descuento de laboratorio por deposito
    Public Sub SqlToDg_descuentoLaboratorioDeposito(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los detalles de la promocion de samsung club
    Public Sub SqlToDg_detallePromoSamsungClub(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            frmPagoProveedor.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los las compras para reutilizar y cargar en la grilla
    Public Sub SqlToDg_detalleCompra(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmVentaFarmacia.txtSql.Text = sql

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                '-- cantidad
                dg.Rows(i).Cells(4).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(4).ToString), "#,###.00")
                '-- bonificacion
                dg.Rows(i).Cells(5).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(5).ToString), "#,##0")
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                '-- el costo
                dg.Rows(i).Cells(8).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(8).ToString), "#,###,###.00")
                '-- precio
                dg.Rows(i).Cells(9).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(9).ToString), "#,###,###.00")
                '-- % IVA
                dg.Rows(i).Cells(10).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(10).ToString), "##")
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                dg.Rows(i).Cells(13).Value = (ds.Tables("resultado").Rows(i).Item(13).ToString)
                '-- el costo original
                dg.Rows(i).Cells(14).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(8).ToString), "#,###,###.00")
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los las compras para reutilizar y cargar en la grilla
    Public Sub SqlToDg_detalleEnvio(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Entro al proceso", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'frmRemisionMercaderia.txtSql.Text = sql


            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                '-- nro
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                '-- codigo
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                '-- nombre de mercaderia
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                '-- forma
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                '-- lote
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                '-- vence
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                '-- %iva
                dg.Rows(i).Cells(6).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(6).ToString), "###")
                '-- precio
                dg.Rows(i).Cells(7).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(7).ToString), "##,###,###.00")
                '-- pedido
                dg.Rows(i).Cells(8).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(8).ToString), "#,###.00")
                '-- cantidad
                dg.Rows(i).Cells(9).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(9).ToString), "#,###.00")
                '-- idstock
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                '-- cantidad fraccionada
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                '-- idusuario pedido
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                '-- idPedido
                dg.Rows(i).Cells(13).Value = (ds.Tables("resultado").Rows(i).Item(13).ToString)

                ' MsgBox("Valor del codigo  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los descuentos por grupo de cliente
    Public Sub SqlToDg_detalleConfigEmail(ByVal dg As DataGridView, ByVal consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los los movimientos de cuentas pendientes de los clientes
    Public Sub SqlToDg_cobroCliente(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor del sql  " & sql)

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los los desayunos pendientes en el restaurante
    Public Sub SqlToDg_desayunoPendienteResto(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor del sql  " & sql)

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los los menus cargados para el maxi punto
    Public Sub SqlToDg_detallemaxiPuntoResto(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor del sql  " & sql)

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub


    '-- el detalle de los las cuotas a cobrar 
    Public Sub SqlToDg_cobroPorCuota(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            'MsgBox("Valor del sql  " & sql)

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                'MsgBox("Valor de 0  " & (ds.Tables("Resultado").Rows(i).Item(0).ToString))
                'MsgBox("Valor de 1  " & (ds.Tables("resultado").Rows(i).Item(1).ToString))
                'MsgBox("Valor de 2  " & (ds.Tables("resultado").Rows(i).Item(2).ToString))
                'MsgBox("Valor de 3  " & (ds.Tables("resultado").Rows(i).Item(3).ToString))
                'MsgBox("Valor de 4  " & (ds.Tables("resultado").Rows(i).Item(4).ToString))
                'MsgBox("Valor de 5  " & (ds.Tables("resultado").Rows(i).Item(5).ToString))
                'MsgBox("Valor de 6  " & (ds.Tables("resultado").Rows(i).Item(6).ToString))
                'MsgBox("Valor de 7  " & (ds.Tables("resultado").Rows(i).Item(7).ToString))
                'MsgBox("Valor de 8  " & (ds.Tables("resultado").Rows(i).Item(8).ToString))

                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
                dg.Rows(i).Cells(8).Value = (ds.Tables("resultado").Rows(i).Item(8).ToString)
                dg.Rows(i).Cells(9).Value = (ds.Tables("resultado").Rows(i).Item(9).ToString)
                dg.Rows(i).Cells(10).Value = (ds.Tables("resultado").Rows(i).Item(10).ToString)
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los lotes para el inventario
    Public Sub SqlToDg_loteInventario(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                dg.Rows(i).Cells(4).Value = (ds.Tables("resultado").Rows(i).Item(4).ToString)
                dg.Rows(i).Cells(5).Value = (ds.Tables("resultado").Rows(i).Item(5).ToString)
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                dg.Rows(i).Cells(7).Value = (ds.Tables("resultado").Rows(i).Item(7).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '-- el detalle de los las ventas de farmacia para reutilizar y cargar en la grilla
    Public Sub SqlToDg_detalleVentaFarmacia(ByVal dg As DataGridView, ByVal sp_consulta As String)
        limpiarDataset()
        Try
            'MsgBox("Se cargó el dataGrid", MsgBoxStyle.Information)
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            'MsgBox("Cantidad de registros encontrados..!  " & ds.Tables("Resultado").Rows.Count - 1)
            '---------------------------
            For i = 0 To ds.Tables("Resultado").Rows.Count - 1
                '-- nro
                dg.Rows.Add(ds.Tables("Resultado").Rows(i).Item(0).ToString)
                'MsgBox("Valor 0  " & ds.Tables("Resultado").Rows(i).Item(0).ToString)
                '-- codigo
                dg.Rows(i).Cells(1).Value = (ds.Tables("resultado").Rows(i).Item(1).ToString)
                'MsgBox("Valor 1  " & ds.Tables("Resultado").Rows(i).Item(1).ToString)
                '-- nombre de la mercaderia
                dg.Rows(i).Cells(2).Value = (ds.Tables("resultado").Rows(i).Item(2).ToString)
                'MsgBox("Valor 2  " & ds.Tables("Resultado").Rows(i).Item(2).ToString)
                '-- nombre del descuento
                dg.Rows(i).Cells(3).Value = (ds.Tables("resultado").Rows(i).Item(3).ToString)
                'MsgBox("Valor 3  " & ds.Tables("Resultado").Rows(i).Item(3).ToString)
                '-- % del IVA
                dg.Rows(i).Cells(4).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(4).ToString), "###,##")
                'MsgBox("Valor 4  " & ds.Tables("Resultado").Rows(i).Item(4).ToString)
                '-- nombre de la forma
                dg.Rows(i).Cells(5).Value = ds.Tables("resultado").Rows(i).Item(5).ToString
                'MsgBox("Valor 5  " & ds.Tables("Resultado").Rows(i).Item(5).ToString)
                '-- vencimiento
                dg.Rows(i).Cells(6).Value = (ds.Tables("resultado").Rows(i).Item(6).ToString)
                'MsgBox("Valor 6  " & ds.Tables("Resultado").Rows(i).Item(6).ToString)
                '-- cantidad
                dg.Rows(i).Cells(7).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(7).ToString), "#,###")
                'MsgBox("Valor 7  " & ds.Tables("Resultado").Rows(i).Item(7).ToString)
                '-- precio
                dg.Rows(i).Cells(8).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(8).ToString), "#,###,###")
                'MsgBox("Valor 8  " & ds.Tables("Resultado").Rows(i).Item(8).ToString)
                '-- precio descuento
                dg.Rows(i).Cells(9).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(9).ToString), "#,###,###")
                'MsgBox("Valor 9  " & ds.Tables("Resultado").Rows(i).Item(9).ToString)
                '-- subtotal
                dg.Rows(i).Cells(10).Value = Format(CDec(ds.Tables("resultado").Rows(i).Item(10).ToString), "##,###,###")
                'MsgBox("Valor 10  " & ds.Tables("Resultado").Rows(i).Item(10).ToString)
                '-- idStock
                dg.Rows(i).Cells(11).Value = (ds.Tables("resultado").Rows(i).Item(11).ToString)
                'MsgBox("Valor 11  " & ds.Tables("Resultado").Rows(i).Item(11).ToString)
                '-- % descuento
                dg.Rows(i).Cells(12).Value = (ds.Tables("resultado").Rows(i).Item(12).ToString)
                'MsgBox("Valor 12  " & ds.Tables("Resultado").Rows(i).Item(12).ToString)
                '-- idProducto
                dg.Rows(i).Cells(13).Value = (ds.Tables("resultado").Rows(i).Item(13).ToString)
                'MsgBox("Valor 13  " & ds.Tables("Resultado").Rows(i).Item(13).ToString)
            Next

        Catch ex As Exception
            MessageBox.Show("No se puede cargar el DataGridView", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    '*****************************************************************************************************
    'Poner bien el anchor de los Datos LV
    Sub AnchorListView(ByVal lv As ListView)

        Dim Column As Integer = lv.Columns.Count - 1
        Dim Field As Integer = lv.Items.Count - 1
        Dim j As Integer
        Dim LengthHeader(Column) As Integer
        Dim LengthColumnContent(Column) As Integer

        Try
            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            Try
                'Contabilizamos la longitud maxima de los content
                Dim CantidadActual, CantidadAnterior As Integer
                For i = 0 To Column
                    CantidadActual = 0
                    CantidadAnterior = 0
                    For j = 0 To Field
                        CantidadAnterior = CantidadActual
                        CantidadActual = lv.Items(j).SubItems(i).Text.Length

                        If CantidadActual > CantidadAnterior Then
                            LengthColumnContent(i) = CantidadActual
                        Else
                            LengthColumnContent(i) = CantidadAnterior
                        End If

                        If CantidadActual > LengthHeader(i) Then
                            Exit For
                        End If

                    Next
                Next
            Catch ex As Exception

            End Try

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next
        Catch ex As Exception

        End Try

    End Sub

    'LISTAR ITEMS PRODUCTOS
    Public Sub SqlToLvImage(ByVal lv As ListView, ByVal consulta As String, ByVal PosIndexImage As Integer)

        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()
            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next
            lv.View = View.Details

            lv.GridLines = False

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                'objListItem = lv.Items.Add(drw.Item(0).ToString, TipoVehiculoIndex(drw.Item(PosIndexImage).ToString).ToString)
                objListItem = lv.Items.Add(drw.Item(0).ToString, TipoVehiculoIndex(drw.Item(PosIndexImage).ToString))
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            Dim CantidadActual, CantidadAnterior As Integer
            For i = 0 To Column
                CantidadActual = 0
                CantidadAnterior = 0
                For j = 0 To Field
                    CantidadAnterior = CantidadActual
                    CantidadActual = lv.Items(j).SubItems(i).Text.Length

                    If CantidadActual > CantidadAnterior Then
                        LengthColumnContent(i) = CantidadActual
                    Else
                        LengthColumnContent(i) = CantidadAnterior
                    End If

                    If CantidadActual > LengthHeader(i) Then
                        Exit For
                    End If

                Next
            Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next


            PintarLv(lv)
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try


    End Sub

    ' Sql To Lv con Multihilo
    Sub SqlToLvHILO()

        'Crear la Conexion
        Dim Adapter As New SqlDataAdapter(sql, conn)
        Dim ds As New DataSet
        Adapter.Fill(ds, "Resultado")
        Dim Cantidad As Decimal = 0
        Dim Progrecion As Decimal

        'Limpiar el ListView
        Multihilo.ListViewClear(f, lv)

        'Cargamos las Columnas
        For i = 0 To ds.Tables(0).Columns.Count - 1
            Multihilo.ListViewAddColumns(f, lv, (ds.Tables(0).Columns(i).ToString))
        Next

        'Cargar los Row
        Progrecion = 100 / ds.Tables("Resultado").Rows.Count
        For Each drw As DataRow In ds.Tables("Resultado").Rows
            Dim objListItem As New ListViewItem()
            If ds.Tables(0).Columns.Count > 1 Then
                objListItem.Text = drw.Item(0).ToString
                For i = 1 To ds.Tables(0).Columns.Count - 1
                    objListItem.SubItems.Add(drw.Item(i).ToString)
                Next
            End If
            Cantidad = Cantidad + Progrecion
            Multihilo.ListViewAddRow(f, lv, objListItem, pgb, Cantidad)
        Next


    End Sub

    'LISTAR ITEMS PRODUCTOS
    Public Sub SqlToLvSinFormatoNumero(ByVal lv As ListView, ByVal consulta As String)

        Try
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Columns.Clear()

            'Determinamos la cantidad de resultados
            Dim i As Integer
            For i = 0 To ds.Tables(0).Columns.Count - 1
                lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
            Next

            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            Dim LengthHeader(Column) As Integer
            Dim LengthColumnContent(Column) As Integer

            'Contabilizamos la longitud de los Header
            For i = 0 To Column
                LengthHeader(i) = lv.Columns(i).Text.Length
            Next

            'Contabilizamos la longitud maxima de los content
            Dim CantidadActual, CantidadAnterior As Integer
            For i = 0 To Column
                CantidadActual = 0
                CantidadAnterior = 0
                For j = 0 To Field
                    CantidadAnterior = CantidadActual
                    CantidadActual = lv.Items(j).SubItems(i).Text.Length

                    If CantidadActual > CantidadAnterior Then
                        LengthColumnContent(i) = CantidadActual
                    Else
                        LengthColumnContent(i) = CantidadAnterior
                    End If

                    If CantidadActual > LengthHeader(i) Then
                        Exit For
                    End If

                Next
            Next

            For i = 0 To Column
                If LengthColumnContent(i) > LengthHeader(i) Then
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
                Else
                    lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
                End If
            Next


            'PintarLv(lv)
        Catch ex As Exception

        End Try


    End Sub

    'LISTAR ITEMS PRODUCTOS
    Public Sub SqlToLvSinFormato(ByVal lv As ListView, ByVal consulta As String)

        Dim Adapter As New SqlDataAdapter(consulta, conn)
        Dim ds As New DataSet
        Adapter.Fill(ds, "Resultado")
        Dim objListItem As New ListViewItem

        lv.FullRowSelect = True
        lv.GridLines = True
        lv.AllowColumnReorder = True
        lv.MultiSelect = False
        lv.Columns.Clear()

        'Determinamos la cantidad de resultados
        Dim i As Integer
        For i = 0 To ds.Tables(0).Columns.Count - 1
            lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
        Next

        lv.Items.Clear()
        lv.Show()

        For Each drw As DataRow In ds.Tables("Resultado").Rows
            objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
            If ds.Tables(0).Columns.Count > 1 Then
                For i = 1 To ds.Tables(0).Columns.Count - 1
                    objListItem.SubItems.Add(drw.Item(i).ToString)
                Next
            End If
        Next

        PintarLv(lv)

    End Sub

    '-- el detalle de la cuenta del item contable
    Public Sub SqlToLv_detalleItemContable(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- nroCuenta
                    lv.Items(i).SubItems(2).BackColor = Color.LightBlue
                End If
            Next
            '----------------------------------------------------------
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    ' solo para listar el las ventas contables a buscar
    Public Sub SqlToLv_ventaContableBusqueda(ByVal lv As ListView, ByVal consulta As String)
        Try
            Dim conn As New SqlConnection(conexion)
            Dim Adapter As New SqlDataAdapter(consulta, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()
            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- para el total
                    If i = 7 Then
                        '-- formato para el total
                        Numero = lv.Items(j).SubItems(6).Text
                        lv.Items(j).SubItems(6).Text = Numero.ToString("###,###,###,##0")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de las ventas contables
    Public Sub SqlToLv_detalleVentaContable(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- el subtotal
                    lv.Items(i).SubItems(5).BackColor = Color.Yellow
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- precio
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,###,###,##0.##")
                    End If
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- cantidad
                        lv.Items(j).SubItems(4).Text = Numero.ToString("#,##0.##")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- subtotal
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,###,###,##0.##")
                    End If
                    If i = 6 Then
                        Numero = lv.Items(j).SubItems(6).Text
                        '-- porcentaje iva
                        lv.Items(j).SubItems(6).Text = Numero.ToString("##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta de los desayunos servidos en el restaurante
    Public Sub SqlToLv_detalleDesayunoServido(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim tmpBolDesayuno As Boolean
            Dim j As Integer
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    tmpBolDesayuno = CBool(lv.Items(j).SubItems(3).Text)
                    'MsgBox("Valor  " & tmpBolDesayuno)
                    If tmpBolDesayuno = False Then
                        '-- pintar los que no desayunaron
                        lv.Items(j).SubItems(i).BackColor = Color.LightPink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta del plan de cuentas del gasto
    Public Sub SqlToLv_detallePlanCuentaGasto(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de las ventas contables
    Public Sub SqlToLv_detalleSucursalVenta(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next


        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de los timbrados de las sucursales
    Public Sub SqlToLv_detalleTimbradoSucursales(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- total
                    lv.Items(i).SubItems(7).BackColor = Color.Yellow
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 7 Then
                        '-- total
                        Numero = lv.Items(j).SubItems(7).Text
                        lv.Items(j).SubItems(7).Text = Numero.ToString("###,##0")
                    End If
                Next
            Next
        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta del asiento contable
    Public Sub SqlToLv_detalleAsientoContable(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto debe
                    lv.Items(i).SubItems(2).BackColor = Color.Moccasin
                    '-- monto haber
                    lv.Items(i).SubItems(3).BackColor = Color.LightGreen
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 2 Then
                        Numero = lv.Items(j).SubItems(2).Text
                        '-- debe
                        lv.Items(j).SubItems(2).Text = Numero.ToString("###,###,###,##0")
                    End If
                    If i = 3 Then
                        Numero = lv.Items(j).SubItems(3).Text
                        '-- haber
                        lv.Items(j).SubItems(3).Text = Numero.ToString("###,###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de la cabecera del asiento contable
    Public Sub SqlToLv_cabeceraAsientoContable(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- idAsiento
                    lv.Items(i).SubItems(1).BackColor = Color.Lime
                End If
            Next
            '----------------------------------------------------------
            'Anchor

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la consulta de las ventas contables
    Public Sub SqlToLv_detalleAsientoContableGenerar(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto debe
                    lv.Items(i).SubItems(4).BackColor = Color.Moccasin
                    '-- monto haber
                    lv.Items(i).SubItems(5).BackColor = Color.Turquoise
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- debe
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,###,##0")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- haber
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la consulta del asiento contable
    Public Sub SqlToLv_detalleAsientoContableNuevo(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '-- para pintar la columna de total
            For i As Integer = 0 To lv.Items.Count - 1
                lv.Items(i).UseItemStyleForSubItems = False
                If lv.Items(i).SubItems.Count > 1 Then
                    '-- monto debe
                    lv.Items(i).SubItems(4).BackColor = Color.Moccasin
                    '-- monto haber
                    lv.Items(i).SubItems(5).BackColor = Color.LightGreen
                End If
            Next
            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 4 Then
                        Numero = lv.Items(j).SubItems(4).Text
                        '-- debe
                        lv.Items(j).SubItems(4).Text = Numero.ToString("###,###,###,##0")
                    End If
                    If i = 5 Then
                        Numero = lv.Items(j).SubItems(5).Text
                        '-- haber
                        lv.Items(j).SubItems(5).Text = Numero.ToString("###,###,###,##0")
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    'LISTAR 
    Public Sub SqlToLvePathFinder(ByVal lv As ListView, ByVal consulta As String)

        'Dim connection As New SqlConnection("Server=(local);Database=ePathFinderSERVER;User Id=sa;Password=Abc1234")
        conn.ChangeDatabase("ePathFinderSERVER")
        Dim Adapter As New SqlDataAdapter(consulta, conn)
        Dim ds As New DataSet
        Adapter.Fill(ds, "Resultado")
        Dim objListItem As New ListViewItem

        lv.FullRowSelect = True
        lv.GridLines = True
        lv.AllowColumnReorder = True
        lv.MultiSelect = False
        lv.Columns.Clear()
        'Determinamos la cantidad de resultados
        Dim i As Integer
        For i = 0 To ds.Tables(0).Columns.Count - 1
            lv.Columns.Add(ds.Tables(0).Columns(i).ToString)
        Next

        lv.Items.Clear()
        lv.Show()

        For Each drw As DataRow In ds.Tables("Resultado").Rows
            objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
            If ds.Tables(0).Columns.Count > 1 Then
                For i = 1 To ds.Tables(0).Columns.Count - 1
                    objListItem.SubItems.Add(drw.Item(i).ToString)
                Next
            End If
        Next


        'Anchor
        Dim Column As Integer = ds.Tables(0).Columns.Count - 1
        Dim Field As Integer = ds.Tables(0).Rows.Count - 1
        Dim j As Integer
        Dim LengthHeader(Column) As Integer
        Dim LengthColumnContent(Column) As Integer

        'Formato numero
        Dim Numero As Decimal
        For i = 0 To Column
            For j = 0 To Field
                If IsNumeric(lv.Items(j).SubItems(i).Text) = True Then
                    Numero = lv.Items(j).SubItems(i).Text
                    If Numero > 999 Then
                        lv.Items(j).SubItems(i).Text = Numero.ToString("###,###,###.##")
                    End If

                    If Numero = 0 Then
                        lv.Items(j).SubItems(i).Text = "0"
                    End If

                    If Numero > 0 And Numero < 999 Then
                        lv.Items(j).SubItems(i).Text = Numero.ToString("###.##")
                    End If
                    lv.Columns(i).TextAlign = HorizontalAlignment.Right
                Else
                    lv.Columns(i).TextAlign = HorizontalAlignment.Left
                    Exit For
                End If
            Next
        Next

        'Contabilizamos la longitud de los Header
        For i = 0 To Column
            LengthHeader(i) = lv.Columns(i).Text.Length
        Next

        'Contabilizamos la longitud maxima de los content
        Dim CantidadActual, CantidadAnterior As Integer
        For i = 0 To Column
            CantidadActual = 0
            CantidadAnterior = 0
            For j = 0 To Field
                CantidadAnterior = CantidadActual
                CantidadActual = lv.Items(j).SubItems(i).Text.Length

                If CantidadActual > CantidadAnterior Then
                    LengthColumnContent(i) = CantidadActual
                Else
                    LengthColumnContent(i) = CantidadAnterior
                End If

                If CantidadActual > LengthHeader(i) Then
                    Exit For
                End If

            Next
        Next

        For i = 0 To Column
            If LengthColumnContent(i) > LengthHeader(i) Then
                lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            Else
                lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next



        PintarLv(lv)

        conn.ChangeDatabase("CUSAT")

    End Sub

    'Formato ListView
    Public Sub FormatoListView(ByVal lv As ListView, ByVal Column As Integer, ByVal Field As Integer)

        lv.FullRowSelect = True
        lv.GridLines = True
        lv.AllowColumnReorder = True
        lv.MultiSelect = False

        'Anchor
        Dim j As Integer
        Dim LengthHeader(Column) As Integer
        Dim LengthColumnContent(Column) As Integer

        'Formato numero
        Dim Numero As Decimal
        For i = 0 To Column
            For j = 0 To Field
                If IsNumeric(lv.Items(j).SubItems(i).Text) = True Then
                    Numero = lv.Items(j).SubItems(i).Text
                    If Numero > 999 Then
                        lv.Items(j).SubItems(i).Text = Numero.ToString("###,###,###.##")
                    End If

                    If Numero = 0 Then
                        lv.Items(j).SubItems(i).Text = "0"
                    End If

                    If Numero > 0 And Numero < 999 Then
                        lv.Items(j).SubItems(i).Text = Numero.ToString("###.##")
                    End If
                    lv.Columns(i).TextAlign = HorizontalAlignment.Right
                Else
                    lv.Columns(i).TextAlign = HorizontalAlignment.Left
                    Exit For
                End If
            Next
        Next

        'Contabilizamos la longitud de los Header
        For i = 0 To Column
            LengthHeader(i) = lv.Columns(i).Text.Length
        Next

        'Contabilizamos la longitud maxima de los content
        Dim CantidadActual, CantidadAnterior As Integer
        For i = 0 To Column
            CantidadActual = 0
            CantidadAnterior = 0
            For j = 0 To Field
                CantidadAnterior = CantidadActual
                CantidadActual = lv.Items(j).SubItems(i).Text.Length

                If CantidadActual > CantidadAnterior Then
                    LengthColumnContent(i) = CantidadActual
                Else
                    LengthColumnContent(i) = CantidadAnterior
                End If

                If CantidadActual > LengthHeader(i) Then
                    Exit For
                End If

            Next
        Next

        For i = 0 To Column
            If LengthColumnContent(i) > LengthHeader(i) Then
                lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)
            Else
                lv.Columns(i).AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next



        PintarLv(lv)

    End Sub

    'INSTRUCCION SQL A UN COMBO BOX SOLO DOS CAMPOS VALUE Y DISPLAY
    Public Sub SqlToComboePathFinder(ByVal sql As String, ByVal combo As ComboBox)
        'Dim connection As New SqlConnection("Server=(local);Database=ePathFinderSERVER;User Id=sa;Password=Abc1234")
        conn.ChangeDatabase("ePathFinderSERVER")
        Dim Adapter As New SqlDataAdapter(sql, conn)
        Dim table As New DataTable
        Adapter.Fill(table)
        combo.ValueMember = table.Columns(0).ToString
        combo.DisplayMember = table.Columns(1).ToString
        combo.DataSource = table

        conn.ChangeDatabase("CUSAT")

    End Sub

    'INSTRUCCION SQL A UN COMBO BOX SOLO DOS CAMPOS VALUE Y DISPLAY
    Public Sub SqlToCombo(ByVal sql As String, ByVal combo As ComboBox)
        Try
            Dim Adapter As New SqlDataAdapter(sql, conexion)
            Dim table As New DataTable
            Adapter.Fill(table)
            combo.ValueMember = table.Columns(0).ToString
            combo.DisplayMember = table.Columns(1).ToString
            combo.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub SqlToComboTresCampos(ByVal sql As String, ByVal combo As ComboBox)
        Try
            Dim Adapter As New SqlDataAdapter(sql, conexion)
            Dim table As New DataTable
            Adapter.Fill(table)

            combo.ValueMember = table.Columns(0).ToString
            combo.DisplayMember = table.Columns(1).ToString
            combo.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'para el combo de cuenta corriente
    Public Sub SqlToComboCuentaCorriente(ByVal sql As String, ByVal combo As ComboBox)
        Try
            Dim Adapter As New SqlDataAdapter(sql, conexion)
            Dim table As New DataTable
            '-- datos a la varibale
            Adapter.Fill(table)
            combo.ValueMember = table.Columns(0).ToString
            combo.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    'INSTRUCCION SQL A UN COMBO BOX SOLO DOS CAMPOS VALUE Y DISPLAY DENTRO DE UN DATAGRIDVIEW
    Public Sub SqlToComboDataGridView(ByVal sql As String, ByVal combo As DataGridViewComboBoxColumn)
        Try
            Dim Adapter As New SqlDataAdapter(sql, conexion)
            Dim table As New DataTable
            Adapter.Fill(table)
            combo.ValueMember = table.Columns(0).ToString
            combo.DisplayMember = table.Columns(1).ToString
            combo.DataSource = table
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'INSTRUCCION SQL A UN COMBO BOX SOLO DOS CAMPOS VALUE Y DISPLAY
    Public Sub SqlTolbx(ByVal sql As String, ByVal lbx As ListBox)
        Dim Adapter As New SqlDataAdapter(sql, conexion)
        Dim table As New DataTable
        Adapter.Fill(table)
        lbx.ValueMember = table.Columns(0).ToString
        lbx.DisplayMember = table.Columns(1).ToString
        lbx.DataSource = table
    End Sub

    'Devuelve el numero ingresado con ceros a la izquierda (dependiendo del caso)
    Public Function FormatoNumero(ByVal valor As String) As String
        Select Case valor.Length
            Case 0
                valor = "00001"
            Case 1
                valor = "0000" & valor
            Case 2
                valor = "000" & valor
            Case 3
                valor = "00" & valor
            Case 4
                valor = "0" & valor
            Case 5
                valor = valor
        End Select
        Return valor
    End Function


    ''' <summary>
    ''' Devuelve un valor de 3 digitos Ej: 012
    ''' </summary>
    ''' <param name="valor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function FormatoNumero3Digitos(ByVal valor As String) As String

        If IsNumeric(valor) = False Then
            Return "001"
            Exit Function
        End If

        Select Case valor.Length
            Case 0
                valor = "001"
            Case 1
                valor = "00" & valor
            Case 2
                valor = "0" & valor
            Case 3
                valor = valor
        End Select

        Return valor

    End Function

    'Convierte el numero sin separador de miles para insertar a la Base de Datos
    Public Function FormatoNumeroIngresoBD(ByVal valor As String) As String
        FormatoNumeroIngresoBD = valor.Replace(".", "")
        FormatoNumeroIngresoBD = valor.Replace(",", "")
    End Function

    'Convierte el numero sin separador de miles para mostrar en pantalla
    Public Function convertirNumeroSeparado(ByVal valor As String) As Double
        Dim v_resultado As String = ""
        If IsNumeric(valor) Then
            '-- remplazar los . por espacio
            v_resultado = valor.Replace(".", "")
            convertirNumeroSeparado = v_resultado '.Replace(",", ".")
        End If
        Return v_resultado
    End Function

    'Retorna el formato de la fecha para insertar en la Base de datos
    Public Function formatofecha(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Day & "-" & Fecha.Value.Month & "-" & Fecha.Value.Year).ToString)
    End Function

    'Retorna el formato de la fecha para insertar en la Base de datos
    'Public Function formatofecha(ByVal Fecha As Date) As String
    '    Return ((Fecha.Month & "-" & Fecha.Day & "-" & Fecha.Year & " " & Fecha.Hour & ":" & Fecha.Minute & ":" & Fecha.Second & "." & Fecha.Millisecond).ToString)
    'End Function

    'Retorna el formato de la fecha para consulta desde
    Public Function FormatoFechaDesde(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Month & "-" & Fecha.Value.Day & "-" & Fecha.Value.Year & " 00:00:00.000"))
    End Function

    'Retorna el formato de la fecha para consulta desde
    Public Function FormatoFechaSolo(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Year & "-" & Fecha.Value.Month & "-" & Fecha.Value.Day))
    End Function

    'Retorna el formato de la fecha para consulta desde
    Public Function FormatoHoraSolo(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Hour & ":" & Fecha.Value.Minute & ":" & Fecha.Value.Second & ".000"))
    End Function

    'Retorna el formato de la fecha para consulta hasta
    Public Function FormatoFechaHasta(ByVal Fecha As DateTimePicker) As String
        Return ((Fecha.Value.Month & "-" & Fecha.Value.Day & "-" & Fecha.Value.Year & " 23:59:59.999"))
    End Function

    'Convierte un tipo de imagen a un Arrary de Byte()
    Public Shared Function Image2Bytes(ByVal img As Bitmap) As Byte()
        'Dim sTemp As String = Path.GetTempFileName
        ''Dim F As System.Security.AccessControl.FileSecurity = New System.Security.AccessControl.FileSecurity(sTemp, Security.AccessControl.AccessControlSections.All)
        'Dim fs As New FileStream(sTemp, FileMode.OpenOrCreate, FileAccess.ReadWrite)
        ''Dim fs As FileStream = New FileStream(sTemp, FileMode.Open, System.Security.AccessControl.FileSystemRights.CreateFiles, FileShare.Read, 32000, FileOptions.Asynchronous, F)
        'img.Save(fs, System.Drawing.Imaging.ImageFormat.Png)
        'fs.Position = 0
        ''
        'Dim imgLength As Integer = CInt(fs.Length)
        'Dim bytes(0 To imgLength - 1) As Byte
        'fs.Read(bytes, 0, imgLength)
        'fs.Close()
        'Return bytes

        Dim ms As New MemoryStream
        Try
            img.Save(ms, Imaging.ImageFormat.Jpeg)
            Return ms.GetBuffer
        Catch
            Return Convert.DBNull
        End Try

    End Function

    'Convierte un tipo de Arrary de Byte() a imagen
    Public Shared Function Bytes2Image(ByVal bytes() As Byte) As Image
        If bytes Is Nothing Then Return Nothing
        '
        Dim ms As New MemoryStream(bytes)
        Dim bm As Bitmap = Nothing
        Try
            ms.Write(bytes, 0, bytes.Length - 1)
            bm = New Bitmap(ms)
        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine(ex.Message)
        End Try
        Return bm
    End Function

    'Impresion de Cadena Simple = De Izquierda a Derecha
    Sub PrintCadenaSimple(ByVal PD As PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal EstiloFuente As FontStyle, ByVal Fuente As FontFamily, ByVal Tamaño As Integer, ByVal Cadena As String, ByVal X As Integer, ByVal Y As Integer, ByVal Duplicado As Boolean, ByVal DuplicadoX As Integer, ByVal DuplicadoY As Integer)
        Dim Formato As Font = New Font(Fuente.Name, Tamaño, EstiloFuente)
        e.Graphics.DrawString(Cadena, Formato, Brushes.Black, X, Y)
        If Duplicado = True Then
            e.Graphics.DrawString(Cadena, Formato, Brushes.Black, X + DuplicadoX, Y + DuplicadoY)
        End If
    End Sub

    'Impresion de Cadena Simple = De Izquierda a Derecha
    Sub PrintImage(ByVal PD As PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal Imagen As Bitmap, ByVal TamanhoImagenX As Integer, ByVal TamanhoImagenY As Integer, ByVal X As Integer, ByVal Y As Integer, ByVal Duplicado As Boolean, ByVal DuplicadoX As Integer, ByVal DuplicadoY As Integer)
        e.Graphics.DrawImage(Imagen, X, Y, TamanhoImagenX, TamanhoImagenY)
        If Duplicado = True Then
            e.Graphics.DrawImage(Imagen, X + DuplicadoX, Y + DuplicadoY, TamanhoImagenX, TamanhoImagenY)
        End If
    End Sub

    'Impresion de Numero = De Derecha a Izquierda
    Sub PrintNumero(ByVal PD As PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal EstiloFuente As FontStyle, ByVal Fuente As FontFamily, ByVal Tamaño As Integer, ByVal Cadena As String, ByVal X As Integer, ByVal Y As Integer, ByVal Duplicado As Boolean, ByVal DuplicadoX As Integer, ByVal DuplicadoY As Integer)
        Dim i As Integer
        Dim Longitud As Integer
        Dim Formato As Font = New Font(Fuente.Name, Tamaño, EstiloFuente)
        Longitud = Cadena.Length
        For i = 0 To (Longitud - 1)
            If Cadena.Chars((Longitud - 1) - i) = "." Then
                X = X - 4
            Else
                X = X - 6
            End If
            e.Graphics.DrawString((Cadena.Chars((Longitud - 1) - i)), Formato, Brushes.Black, X, Y)
            If Duplicado = True Then
                e.Graphics.DrawString((Cadena.Chars((Longitud - 1) - i)), Formato, Brushes.Black, X + DuplicadoX, Y + DuplicadoY)
            End If
        Next
    End Sub

    'Impresion de Cadena Parrafo = De Izquierda a derecha, varios renglones
    Function PrintCadenaParrafo(ByVal PD As PrintDocument, ByVal e As System.Drawing.Printing.PrintPageEventArgs, ByVal EstiloFuente As FontStyle, ByVal Fuente As FontFamily, ByVal Tamaño As Integer, ByVal Cadena As String, ByVal X As Integer, ByVal Y As Integer, ByVal Interlineado As Integer, ByVal LongitudDetalle As Integer, ByVal Duplicado As Boolean, ByVal DuplicadoX As Integer, ByVal DuplicadoY As Integer) As Integer

        PrintCadenaParrafo = 0

        'DECLARACION DE VARIABLES
        Dim j, i, k, Cantidad, CantidadPalabras As Integer
        Dim AnalizadorRenglon As String
        Dim Formato As Font = New Font(Fuente.Name, Tamaño, EstiloFuente)

        'Vector donde se cargan todas las palabras
        Dim Palabras() As String

        'Maxima longitud de cadena, pasando este se tendria que escribir en un nuevo renglon
        Dim Tope As Integer = LongitudDetalle

        'Vector donde se cargan los renglornes
        Dim Parrafo(0) As String

        'Cargamos en la Matriz palabra por palabra
        Palabras = Split(Cadena, " ")

        'Definimos la cantidad de palabras
        CantidadPalabras = Palabras.Length

        k = 0
        Cantidad = 0

        'Ciclo de carga parrafo por parrafo
        For i = 0 To CantidadPalabras - 1

            'Inicializamos El Vector
            ReDim Preserve Parrafo(i)
            Parrafo(i) = ""

            'Ciclo de carga palabra por palabra en el parrafo
            For j = k To CantidadPalabras - 1

                'Analizamos si la nueva cantidad de palabras sobrepasa el tope
                AnalizadorRenglon = Parrafo(i) & " " & Palabras(j)

                If Tope >= AnalizadorRenglon.Length Then

                    'En caso de que no se llegue al tope con la nueva palabra, cargamos en el renglon actual
                    Parrafo(i) = Parrafo(i) & " " & Palabras(j)
                    k = j
                    Cantidad = Cantidad + 1

                Else

                    'Caso contrario, vamos al proximo renglon
                    k = j
                    Exit For
                End If

            Next

            'Consulta necesaria para salir del ciclo
            If Cantidad = CantidadPalabras Then
                Exit For
            End If

        Next

        'Imprimimos
        Dim InterlineadoTemp As Integer = 0 'Interlineado
        For i = 0 To Parrafo.Length - 1

            e.Graphics.DrawString(Parrafo(i), Formato, Brushes.Black, X, Y + InterlineadoTemp)

            'Duplicado
            If Duplicado = True Then
                e.Graphics.DrawString(Parrafo(i), Formato, Brushes.Black, X + DuplicadoX, Y + InterlineadoTemp + DuplicadoY)
            End If

            InterlineadoTemp = InterlineadoTemp + 17 'Interlineado
            PrintCadenaParrafo = PrintCadenaParrafo + 1
        Next

    End Function

    'Retorna un numero con prefujos de 0 de tres digitos --> 001
    Function RetornarNumero3Digitos(ByVal valos As Decimal) As String

        RetornarNumero3Digitos = "000"
        If valos < 10 Then
            Return "00" & CStr(valos)
        End If

        If valos < 100 Then
            Return "0" & CStr(valos)
        End If

        If valos < 100 Then
            Return CStr(valos)
        End If

    End Function

    'Retornar Tipo de Vehiculo
    Function TipoVehiculoIndex(ByVal Tipo As String) As Integer

        TipoVehiculoIndex = 0

        Select Case Tipo
            Case "Sin definir"
                TipoVehiculoIndex = 0
            Case "Auto"
                TipoVehiculoIndex = 2
            Case "Camion"
                TipoVehiculoIndex = 3
            Case "Moto"
                TipoVehiculoIndex = 5
            Case Is = "Camioneta"
                TipoVehiculoIndex = 6
            Case "Omnibus"
                TipoVehiculoIndex = 4
            Case "Mini Van"
                TipoVehiculoIndex = 7
            Case "Semi Camion"
                TipoVehiculoIndex = 8
        End Select

        Return TipoVehiculoIndex

    End Function

    'Retornar Conexion
    Function ReturnConexion() As SqlConnection

        Dim conn As New SqlConnection
        Dim Valido As Boolean = False
        Dim previousConnectionState As ConnectionState
        previousConnectionState = conn.State
        Try

            'Conexion Lan
            conn.ConnectionString = "Data Source=SERVER-CUSAT;Initial Catalog=CUSAT;User ID=sa;Password=Abc1234"
            Try
                If conn.State = ConnectionState.Closed Then
                    conn.Open()
                End If
                Valido = True
            Catch ex As Exception
                Valido = False
            Finally
                If previousConnectionState = ConnectionState.Closed Then
                    conn.Close()
                End If
            End Try

            'Conexion Internet
            If Valido = False Then
                conn.ConnectionString = "Data Source=200.3.252.170;Initial Catalog=CUSAT;User ID=sa;Password=Abc1234"
                Try
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If
                    Valido = True
                Catch
                    Valido = False
                Finally
                    If previousConnectionState = ConnectionState.Closed Then
                        conn.Close()
                    End If
                End Try

            End If

        Catch ex As Exception
            MessageBox.Show(hayarConexion.ToString & ", produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return conn
        Finally
            If previousConnectionState = ConnectionState.Closed Then
                conn.Close()
            End If
        End Try

        Return conn

    End Function

    '-- el detalle de la facturas electronicas de la sucursal al generar
    Public Sub SqlToLv_detalleFacturaDTE(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            Dim tmpBolSel As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 5 Then
                        '-- formato total
                        Numero = lv.Items(j).SubItems(5).Text
                        lv.Items(j).SubItems(5).Text = Format(CDec(Numero), "##,###,##0")
                    End If

                    tmpBolSel = CBool(lv.Items(j).SubItems(7).Text)
                    If tmpBolSel = True Then
                        '-- pintar las filas seleccionadas
                        lv.Items(j).SubItems(i).BackColor = Color.LightPink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- el detalle de la facturas electronicas anuladads de la sucursal al generar
    Public Sub SqlToLv_detalleFacturaDTEAnulada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim tmpBolSel As Boolean = False
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    tmpBolSel = CBool(lv.Items(j).SubItems(7).Text)
                    If tmpBolSel = True Then
                        '-- pintar las filas seleccionadas
                        lv.Items(j).SubItems(i).BackColor = Color.LightPink
                    End If
                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub


    '-- el detalle de la facturas electronicas con errores
    Public Sub SqlToLv_detalleConsultaFacturaNoEnviada(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

            '----------------------------------------------------------
            'Anchor
            Dim Column As Integer = ds.Tables(0).Columns.Count - 1
            Dim Field As Integer = ds.Tables(0).Rows.Count - 1
            Dim j As Integer
            'Formato numero
            Dim Numero As Decimal
            'columnas
            For i = 0 To Column
                'filas
                For j = 0 To Field
                    '-- columnas
                    If i = 8 Then
                        '-- formato total
                        Numero = lv.Items(j).SubItems(8).Text
                        lv.Items(j).SubItems(8).Text = Format(CDec(Numero), "##,###,##0")
                    End If

                Next
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    '-- consulta del lote de la sifen
    Public Sub SqlToLv_consultaLoteSIFEN(ByVal lv As ListView, ByVal sp_consulta As String, ByVal v_parametro As String)
        Try
            limpiarDataset()
            Dim conn As New SqlConnection(conexion)
            Dim sql As String = "exec " & sp_consulta & " " & v_parametro
            Dim cmd As New SqlCommand(sql, conn)
            Dim previousConnectionState As ConnectionState
            previousConnectionState = conn.State

            Dim Adapter As New SqlDataAdapter(sql, conn)
            Dim ds As New DataSet
            Adapter.Fill(ds, "Resultado")
            Dim objListItem As New ListViewItem

            lv.FullRowSelect = True
            lv.GridLines = True
            lv.AllowColumnReorder = True
            lv.MultiSelect = False
            lv.Items.Clear()
            lv.Show()

            For Each drw As DataRow In ds.Tables("Resultado").Rows
                objListItem = lv.Items.Add(drw.Item(0).ToString, 0)
                If ds.Tables(0).Columns.Count > 1 Then
                    For i = 1 To ds.Tables(0).Columns.Count - 1
                        objListItem.SubItems.Add(drw.Item(i).ToString)
                    Next
                End If
            Next

        Catch ex As Exception
            'MessageBox.Show("No se encuentra ningun programa de calculo para exportar! Se requiere Microsoft Excel o Open Office para continuar", "ERP", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

End Class
