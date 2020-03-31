''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D25X0002

    Public Const MaskFormatTime As String = "__:__:__"

    Public Function IsUseAppRecruitProposal() As Boolean
        Dim sSQL As String = "    SELECT 	NumValue as IsUseAppRecruitProposal" & vbCrLf & _
                "FROM 	D09T0009" & vbCrLf & _
                "WHERE	ModuleID = 'D25'" & vbCrLf & _
                "AND TransTypeID	= 'RecruitmentRequest'" & vbCrLf & _
                "AND FormID = 'D25F2000'"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Return False
        Return L3Bool(dt.Rows(0).Item(0))
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLStoreD25P1042
    ''# Created User: Nguyễn Thị Ánh
    ''# Created Date: 21/11/2007 02:19:37
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: Đổ nguồn cho ứng viên - D25F1042, D25F1044
    ''#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD25P1042(ByVal sRecruitmentFileID As String, Optional ByVal sRecDepartmentIDFrom As String = "", Optional ByVal sRecDepartmentIDTo As String = "" _
                                      , Optional ByVal sRecTeamIDFrom As String = "", Optional ByVal sRecTeamIDTo As String = "" _
                                      , Optional ByVal sRecPositionIDFrom As String = "", Optional ByVal sRecPositionIDTo As String = "" _
                                      , Optional ByVal sRecsourceIDFrom As String = "", Optional ByVal sRecsourceIDTo As String = "" _
                                      , Optional ByVal sCandidateID As String = "%", Optional ByVal sFind As String = "" _
                                      ) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P1042 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(sRecruitmentFileID) & COMMA 'RecruitmentFileID, varchar[20], NOT NULL
        sSQL &= SQLString(sRecDepartmentIDFrom) & COMMA 'RecDepartmentIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sRecDepartmentIDTo) & COMMA 'RecDepartmentIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sRecTeamIDFrom) & COMMA 'RecTeamIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sRecTeamIDTo) & COMMA 'RecTeamIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sRecPositionIDFrom) & COMMA 'RecPositionIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sRecPositionIDTo) & COMMA 'RecPositionIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sRecsourceIDFrom) & COMMA 'RecsourceIDFrom, varchar[20], NOT NULL
        sSQL &= SQLString(sRecsourceIDTo) & COMMA 'RecsourceIDTo, varchar[20], NOT NULL
        sSQL &= SQLString(sCandidateID) & COMMA 'CandidateID, varchar[20], NOT NULL
        sSQL &= SQLString(sFind) 'WhereClause, varchar[1000], NOT NULL
        Return sSQL
    End Function


    '''' <summary>
    '''' Load trường dữ liệu ảnh từ DataBase: truờng dữ liệu kiểu Image 
    '''' 
    '''' Câu SQL chứa field ảnh 
    '''' Trả về một image 
    '''' </summary>
    Public Function WriteImage(ByVal sImageData As Object, ByVal sFileName As String) As System.Drawing.Image
        If sImageData.ToString = "" Then Return Nothing
        Try
            Dim byarrImg As Byte() = DirectCast(sImageData, Byte())
            My.Computer.FileSystem.WriteAllBytes(sFileName, byarrImg, False)
            Return System.Drawing.Image.FromFile(sFileName)
        Catch ex As Exception
            Return Nothing
        Finally
        End Try
    End Function

    Public Function ReturnImage(ByVal objExpression As Object) As Image
        If IsDBNull(objExpression) = False Then
            Dim ms As New System.IO.MemoryStream(CType(objExpression, Byte()))
            Dim img As Image = Image.FromStream(ms)
            Return img
        Else
            Return Nothing
        End If
    End Function

    '''' <summary>
    '''' Format dạng giờ trên lưới
    '''' </summary>
    '''' <param name="sTime "></param>
    '''' <returns>Chuỗi giờ dạng HH:MM:SS</returns>
    '''' <remarks></remarks>
    Public Function ConvertTime(ByVal sTime As String) As Object
        Dim sResult As String
        Dim arr() As String
        Dim sSeparator As String = ":"
        arr = Microsoft.VisualBasic.Split(sTime, sSeparator)
        For i As Integer = 0 To arr.Length - 1
            If arr(i) = "__" Or arr(i).Substring(0, 1) = "_" Or arr(i).Substring(1, 1) = "_" Then
                arr(i) = arr(i).Replace("_", "0")
            End If
        Next
        'Giờ
        If Convert.ToInt32(arr(0)) < 0 Or Convert.ToInt32(arr(0)) > 23 Then
            Return MaskFormatTime
        Else
            sResult = Convert.ToInt32(arr(0)).ToString("00")
        End If
        For i As Integer = 1 To arr.Length - 1

            If CType(arr(i), Integer) < 0 Or CType(arr(i), Integer) > 59 Then
                Return MaskFormatTime
            Else
                sResult &= sSeparator & CInt(arr(i)).ToString("00")
            End If
        Next


        Return sResult
    End Function

    Public Function ConvertTimeToString(ByVal sTime As String) As String
        Try
            If sTime = "" Then Return ""
            Return Microsoft.VisualBasic.Replace(sTime, ":", "")
        Catch ex As Exception
            Return sTime
        End Try
    End Function

    Public Function InsertFormat(ByVal ONumber As Object) As String
        Dim iNumber As Int16
        If ONumber.ToString = "" Then
            iNumber = 0
        Else
            iNumber = Convert.ToInt16(ONumber)
        End If

        Dim sRet As String = "#,##0"
        If iNumber = 0 Then
        Else
            sRet &= "." & Strings.StrDup(iNumber, "0")
        End If
        Return sRet
    End Function

    Public Function MyFooterSum(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, ByVal sFormat As String) As String
        Dim dblSum As Double = 0
        For i As Integer = 0 To c1Grid.RowCount() - 1
            'dblSum += Number(SQLMoney(c1Grid(i, iCol).ToString, sFormat))
            dblSum += Number(Format(Number(c1Grid(i, iCol)), sFormat))
        Next i
        Return Format(dblSum, sFormat)
    End Function

    Public Function HotKeyF7_ColDepend(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid) As Boolean
        Try
            If c1Grid.RowCount < 1 Then Exit Function

            If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.UpdateData()
                Else
                    Return False
                End If
            Else ' Chuỗi hoặc Ngày
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.UpdateData()
                Else
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyF7: " & ex.Message)
        End Try
    End Function

    Public Function CreateTable(ByVal colCollection() As String, Optional ByVal rowCollection1() As String = Nothing, Optional ByVal rowCollection2(,) As String = Nothing) As DataTable
        Dim dtMines As New DataTable
        For i As Integer = 0 To colCollection.Length - 1
            Dim col As New DataColumn(colCollection(i), GetType(System.String))
            dtMines.Columns.Add(col)
        Next

        Dim dr As DataRow
        If Not rowCollection1 Is Nothing Then
            For i As Integer = 0 To rowCollection1.Length() - 1
                dr = dtMines.NewRow
                dr(0) = rowCollection1(i)
                dtMines.Rows.Add(dr)
            Next
            Return dtMines
        End If

        If Not rowCollection2 Is Nothing Then
            For i As Integer = 0 To rowCollection2.GetLength(0) - 1
                dr = dtMines.NewRow
                For j As Integer = 0 To rowCollection2.GetLength(1) - 1
                    dr(j) = rowCollection2(i, j)
                Next
                dtMines.Rows.Add(dr)
            Next
            Return dtMines
        End If

        Return dtMines
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P0050
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 09/01/2009 02:16:52
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD25P0050(ByVal sTableName As String, Optional ByVal bUseUnioce As Boolean = False) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D25P0050 "
        sSQL &= SQLString(sTableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLNumber(bUseUnioce) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Sub LoadTdbcDutyID(ByVal tdbc As C1.Win.C1List.C1Combo)
        Dim sSQL As String = String.Empty
        'Load tdbcDutyID
        sSQL = " Select DutyID, DutyName" & UnicodeJoin(gbUnicode) & " AS DutyName" & vbCrLf
        sSQL &= " From D09T0211  WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled=0  Order by DutyID"
        LoadDataSource(tdbc, sSQL, gbUnicode)
    End Sub

    Public Function F7More(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ParamArray ColumnMore() As Integer) As Boolean
        Try
            If c1Grid.RowCount < 1 Then Return False

            If c1Grid(c1Grid.Row, c1Grid.Col).ToString() = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString
                For i As Integer = 0 To ColumnMore.Length - 1
                    c1Grid.Columns(ColumnMore(i)).Text = c1Grid(c1Grid.Row - 1, ColumnMore(i)).ToString
                Next i
                c1Grid.UpdateData()
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function F7More(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColumnMore As Integer) As Boolean
        Try
            If c1Grid.RowCount < 1 Then Return False

            If c1Grid(c1Grid.Row, c1Grid.Col).ToString() = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString
                c1Grid.Columns(ColumnMore).Text = c1Grid(c1Grid.Row - 1, ColumnMore).ToString
                c1Grid.UpdateData()
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Public Function ReturnTableDutyIDRec(Optional ByVal bHavePercent As Boolean = True, Optional ByVal bUseUnicode As Boolean = False) As DataTable
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, bUseUnicode)
        '***************
        Dim sSQL As String = ""
        If bHavePercent Then
            sSQL = "SELECT '%' AS RecPositionID, " & sLanguage & " AS RecPositionName, 0 as DisplayOrder" & vbCrLf
            sSQL &= "UNION" & vbCrLf
        End If
        sSQL &= "SELECT	DutyID As RecPositionID, DutyName" & sUnicode & " AS RecPositionName, 1 as DisplayOrder" & vbCrLf
        sSQL &= "FROM D09T0211  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE	Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, RecPositionName" & vbCrLf

        Return ReturnDataTable(sSQL)

    End Function

    ''#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P5555
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 24/07/2013 03:06:47
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD25P5555(ByVal iMode As Integer, ByVal iType As Integer, ByVal FormID As String, ByVal sDesc As String _
            , Optional ByVal Key01ID As String = "", Optional ByVal Key02ID As Object = "", Optional ByVal Key03ID As Object = "" _
            , Optional ByVal Key04ID As String = "", Optional ByVal Key05ID As String = "" _
                                        ) As String
        Dim sSQL As String = ""
        sSQL &= ("-- " & sDesc & vbCrLf)
        sSQL &= "Exec D25P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(FormID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[10], NOT NULL
        sSQL &= SQLString(Key01ID) & COMMA 'Key01ID, varchar[20], NOT NULL
        sSQL &= SQLString(Key02ID) & COMMA 'key02ID, varchar[20], NOT NULL
        sSQL &= SQLString(Key03ID) & COMMA 'key03ID, varchar[20], NOT NULL
        sSQL &= SQLString(Key04ID) & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString(Key05ID) & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(iType) & COMMA 'Type, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Public Sub LoadtdbdSexName(ByVal tdbdSexName As C1.Win.C1TrueDBGrid.C1TrueDBDropdown)
        Dim sNu As String = "Nöõ"
        Dim sNam As String = "Nam"
        If geLanguage = EnumLanguage.English Then
            sNu = "Female"
            sNam = "Male"
        ElseIf gbUnicode Then
            sNu = "Nữ"
        End If
        Dim sSQL As String = "--- Combo Gioi tinh" & vbCrLf & _
        "SELECT	0 AS Sex, N'" & sNam & "' AS SexName" & vbCrLf & _
        "UNION" & vbCrLf & _
        "SELECT	1 AS Sex, N'" & sNu & "' AS SexName"
        LoadDataSource(tdbdSexName, sSQL, gbUnicode)
    End Sub

    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rL3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay") 'rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg

    End Function
    'Public Function CallFormD25F2010(ByVal frmCall As Form, ByVal frmState As EnumFormState, ByVal InterviewFileID As String, ByVal RecruitPhaseNo As String) As String
    '    Dim arrPro() As StructureProperties = Nothing
    '    SetProperties(arrPro, "InterviewFileID", InterviewFileID)
    '    SetProperties(arrPro, "RecruitPhaseNo", RecruitPhaseNo)
    '    SetProperties(arrPro, "FormState", frmState)
    '    Dim frm As Form = CallFormShowDialog("D25D1040", "D25F2010", arrPro)
    '    Dim bSavedOK As Boolean = L3Bool(GetProperties(frm, "SavedOK"))
    '    If bSavedOK Then
    '        Return GetProperties(frm, "InterviewFileID").ToString
    '    Else
    '        Return ""
    '    End If
    'End Function

    Public Sub RunAuditLog(ByVal sAuditCode As String, ByVal sEventID As String, ByVal sDesc1 As String, ByVal sDesc2 As String, ByVal sDesc3 As String, ByVal sDesc4 As String, ByVal sDesc5 As String)
        ''Ghi Audit cho mỗi nghiệp vụ
        'Dim sSQL As String = ""
        'sSQL &= "Exec D91P9106 "
        'sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        'sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        'sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        'sSQL &= SQLString(D25) & COMMA 'ModuleID, varchar[2], NOT NULL
        'sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        'sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        'sSQL &= SQLString(sDesc1) & COMMA 'Desc1, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc2) & COMMA 'Desc2, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc3) & COMMA 'Desc3, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc4) & COMMA 'Desc4, varchar[250], NOT NULL
        'sSQL &= SQLString(sDesc5) 'Desc5, varchar[250], NOT NULL
        'ExecuteSQLNoTransaction(sSQL)
        Lemon3.D91.RunAuditLog("25", sAuditCode, sEventID, sDesc1, sDesc2, sDesc3, sDesc4, sDesc5) 'ID 84813 02/03/2016
    End Sub
End Module
