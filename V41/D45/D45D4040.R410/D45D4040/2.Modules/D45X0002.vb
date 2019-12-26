''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Imports System
Module D45X0002

    ''' <summary>
    ''' Lấy chuỗi dữ liệu của những dòng được chọn
    ''' </summary>
    ''' <param name="iCol">Cột lấy dữ liệu</param>
    ''' <param name="Grid">lưới C1</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Function GetDataSelectRows(ByVal iCol As Integer, ByVal Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As String
        Dim sResult As String = ""
        Dim aSelectRows As C1.Win.C1TrueDBGrid.SelectedRowCollection = Grid.SelectedRows
        Dim aSelectCol As Int32 = 1
        If aSelectRows.Count > 0 Then
            If Grid(Grid.Row, iCol).ToString <> Grid(aSelectRows.Item(0), iCol).ToString Then
                sResult &= SQLString(Grid(Grid.Row, iCol).ToString) & ","
            End If
            For i As Integer = 0 To aSelectRows.Count - 2
                sResult &= SQLString(Grid(aSelectRows.Item(i), iCol)) & ","
            Next
            sResult &= SQLString(Grid(aSelectRows.Item(aSelectRows.Count - 1), iCol))
        Else
            sResult = SQLString(Grid.Columns(iCol).Text)
        End If
        Return sResult
    End Function

    ''' <summary>
    ''' Kiểm tra xem có tồn tại tên file chỉ định hay không
    ''' </summary>
    ''' <param name="sFileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsExistFile(ByVal sFileName As String) As Boolean
        Dim PathEXE As String = gsApplicationSetup & "\" & sFileName
        If Not System.IO.File.Exists(PathEXE) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CbVal(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.Text = "" Then
            Return ""
        End If
        Return tdbc.SelectedValue.ToString
    End Function

    Public Sub LoadUseBlock()
        Dim sSQL As String = ""
        D45Systems.IsUseBlock = False

        sSQL = "Select IsUseBlock From D09T0000 WITH(NOLOCK) "
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            D45Systems.IsUseBlock = L3Bool(dt.Rows(0).Item("IsUseBlock").ToString)
        End If

    End Sub

#Region "KeyboardCues"

    Private Declare Function SystemParametersInfoSet Lib "user32.dll" Alias "SystemParametersInfoW" (ByVal action As Integer, ByVal param As Integer, ByVal value As Integer, ByVal winini As Boolean) As Boolean
    Private Const SPI_SETKEYBOARDCUES As Integer = &H100B

    Public Sub KeyboardCues()
        SystemParametersInfoSet(SPI_SETKEYBOARDCUES, 0, 1, False)
    End Sub
#End Region
End Module
