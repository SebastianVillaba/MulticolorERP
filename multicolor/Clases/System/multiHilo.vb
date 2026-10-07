Imports System.Threading
Imports System.Data.SqlClient

Public Class MultiHilo

    'Sql
    Function RunCommandAsynchronously(ByVal cmd As SqlCommand, ByVal conn As SqlConnection) As String

        Try
            Dim result As IAsyncResult = cmd.BeginExecuteNonQuery()
            While Not result.IsCompleted
                Threading.Thread.Sleep(10)
            End While
            Return ("Command complete. Affected rows." & cmd.EndExecuteNonQuery(result))
        Catch ex As SqlException
            Return ("Error ({0}): {1} " & ex.Number & " " & ex.Message)
        Catch ex As InvalidOperationException
            Return ("Error ({0}): {1} " & ex.Message)
        Catch ex As Exception
            ' You might want to pass these errors
            ' back out to the caller.
            Return ("Error ({0}): {1} " & ex.Message)
        End Try

    End Function

    '********** - LISTVIEW - *************** 
    ' ListView - Clear
    Delegate Sub ListViewClearCallBack(ByVal form As Form, ByVal lv As ListView)

    Public Sub ListViewClear(ByVal form As Form, ByVal lv As ListView)
        If lv.InvokeRequired Then
            Dim d As New ListViewClearCallBack(AddressOf ListViewClear)
            form.Invoke(d, New Object() {form, lv})
        Else
            lv.Clear()
        End If

    End Sub

    ' ListView - Items Clear
    Delegate Sub ListViewItemsClearCallBack(ByVal form As Form, ByVal lv As ListView)

    Public Sub ListViewItemsClear(ByVal form As Form, ByVal lv As ListView)
        If lv.InvokeRequired Then
            Dim d As New ListViewItemsClearCallBack(AddressOf ListViewItemsClear)
            form.Invoke(d, New Object() {form, lv})
        Else
            lv.Items.Clear()
        End If

    End Sub

    ' ListView - SelectedItems Collections
    Delegate Function ListViewSelectedItemsCollectionsCallBack(ByVal form As Form, ByVal lv As ListView) As ListView.SelectedListViewItemCollection

    Public Function ListViewSelectedItemsCollections(ByVal form As Form, ByVal lv As ListView) As ListView.SelectedListViewItemCollection
        If lv.InvokeRequired Then
            Dim d As New ListViewSelectedItemsCollectionsCallBack(AddressOf ListViewSelectedItemsCollections)
            form.Invoke(d, New Object() {form, lv})
            Return lv.SelectedItems
        Else
            Return lv.SelectedItems
        End If

    End Function

    ' ListView - BeginUpdate
    Delegate Sub ListViewBeginUpdateCallBack(ByVal form As Form, ByVal lv As ListView)

    Public Sub ListViewBeginUpdate(ByVal form As Form, ByVal lv As ListView)
        If lv.InvokeRequired Then
            Dim d As New ListViewBeginUpdateCallBack(AddressOf ListViewBeginUpdate)
            form.Invoke(d, New Object() {form, lv})
        Else
            lv.BeginUpdate()
        End If

    End Sub

    ' ListView - EndUpdate
    Delegate Sub ListViewEndUpdateCallBack(ByVal form As Form, ByVal lv As ListView)

    Public Sub ListViewEndUpdate(ByVal form As Form, ByVal lv As ListView)
        If lv.InvokeRequired Then
            Dim d As New ListViewEndUpdateCallBack(AddressOf ListViewEndUpdate)
            form.Invoke(d, New Object() {form, lv})
        Else
            lv.EndUpdate()
        End If

    End Sub

    ' ListView - Add Columns
    Delegate Sub ListViewAddColumnsCallBack(ByVal form As Form, ByVal lv As ListView, ByVal Valor As String)

    Public Sub ListViewAddColumns(ByVal form As Form, ByVal lv As ListView, ByVal Valor As String)
        If lv.InvokeRequired Then
            Dim d As New ListViewAddColumnsCallBack(AddressOf ListViewAddColumns)
            form.Invoke(d, New Object() {form, lv, Valor})
        Else
            lv.Columns.Add(Valor)
        End If

    End Sub

    ' ListView - Add Rows
    Delegate Sub ListViewAddRowCallBack(ByVal form As Form, ByVal lv As ListView, ByVal Row As ListViewItem, ByVal ProgressBar As ProgressBar, ByVal Cantidad As Decimal)

    Public Sub ListViewAddRow(ByVal form As Form, ByVal lv As ListView, ByVal Row As ListViewItem, ByVal ProgressBar As ProgressBar, ByVal Cantidad As Decimal)
        If lv.InvokeRequired Then
            Dim d As New ListViewAddRowCallBack(AddressOf ListViewAddRow)
            form.Invoke(d, New Object() {form, lv, Row, ProgressBar, Cantidad})
            ProgressBarValue(form, ProgressBar, Cantidad)
            If ProgressBar.Value = 100 Then
                ProgressBarVisible(form, ProgressBar, False)
            Else
                If ProgressBar.Visible = False Then
                    ProgressBarVisible(form, ProgressBar, True)
                End If
            End If
        Else
            lv.Items.Add(Row)
        End If

    End Sub

    '********** - PROGRESSBAR - ***************
    ' ProgressBar - Visible
    Delegate Sub ProgressBarVisibleCallBack(ByVal Form As Form, ByVal ProgressBar As ProgressBar, ByVal Valor As Boolean)

    Public Sub ProgressBarVisible(ByVal Form As Form, ByVal ProgressBar As ProgressBar, ByVal Valor As Boolean)
        Try
            If ProgressBar.InvokeRequired Then
                Dim d As New ProgressBarVisibleCallBack(AddressOf ProgressBarVisible)
                Form.Invoke(d, New Object() {Form, ProgressBar, Valor})
            Else
                ProgressBar.Visible = Valor
            End If
        Catch ex As Exception

        End Try

    End Sub

    ' ProgressBar - Value
    Delegate Sub ProgressBarValueCallBack(ByVal Form As Form, ByVal ProgressBar As ProgressBar, ByVal Valor As Decimal)

    Public Sub ProgressBarValue(ByVal Form As Form, ByVal ProgressBar As ProgressBar, ByVal Valor As Decimal)
        If ProgressBar.InvokeRequired Then
            Dim d As New ProgressBarValueCallBack(AddressOf ProgressBarValue)
            Form.Invoke(d, New Object() {Form, ProgressBar, Valor})
        Else
            ProgressBar.Value = Valor
        End If

    End Sub

#Region "********** - TEXTBOX - ***************"

    ' TextBox - Text
    Delegate Sub TextBoxTextCallBack(ByVal Form As Form, ByVal txt As TextBox, ByVal Valor As String)

    Public Sub TextBoxText(ByVal Form As Form, ByVal txt As TextBox, ByVal Valor As String)
        Try
            If txt.InvokeRequired Then
                Dim d As New TextBoxTextCallBack(AddressOf TextBoxText)
                Form.Invoke(d, New Object() {Form, txt, Valor})
            Else
                txt.Text = Valor
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

#End Region

#Region "********** - LABEL - ***************"

    ' Label - Text
    Delegate Sub LabelTextCallBack(ByVal Form As Form, ByVal lbl As Label, ByVal Valor As String)

    Public Sub LabelText(ByVal Form As Form, ByVal lbl As Label, ByVal Valor As String)
        Try
            If lbl.InvokeRequired Then
                Dim d As New LabelTextCallBack(AddressOf LabelText)
                Form.Invoke(d, New Object() {Form, lbl, Valor})
            Else
                lbl.Text = Valor
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    ' Label - Visible
    Delegate Sub LabelVisibleCallBack(ByVal Form As Form, ByVal lbl As Label, ByVal Valor As Boolean)

    Public Sub LabelVisible(ByVal Form As Form, ByVal lbl As Label, ByVal Valor As Boolean)
        Try
            If lbl.InvokeRequired Then
                Dim d As New LabelVisibleCallBack(AddressOf LabelVisible)
                Form.Invoke(d, New Object() {Form, lbl, Valor})
            Else
                lbl.Visible = Valor
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

#End Region

#Region "********** - FORM - ***************"

    ' Form - Close
    Delegate Sub FormCloseCallBack(ByVal Form As Form)

    Public Sub FormClose(ByVal Form As Form)
        Try
            If Form.InvokeRequired Then
                Dim d As New FormCloseCallBack(AddressOf FormClose)
                Form.Invoke(d, New Object() {Form})
            Else
                Form.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

    ' Form - Visible
    Delegate Sub FormVisibleCallBack(ByVal Form As Form, ByVal Value As Boolean)

    Public Sub FormVisible(ByVal Form As Form, ByVal Value As Boolean)
        Try
            If Form.InvokeRequired Then
                Dim d As New FormVisibleCallBack(AddressOf FormVisible)
                Form.Invoke(d, New Object() {Form, Value})
            Else
                Form.Visible = Value
            End If
        Catch ex As Exception
            MessageBox.Show("Se produjo el siguiente error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Sub

#End Region

End Class
