''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
Module D25X0002

    ''' <summary>
    ''' Tạo caption cho menu Period và kiểm tra tình trạng khóa, mở sổ cho biến gbClosed
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Function MakeMenuPeriod() As String
        Dim sRet As String = rl3("_Ky_ke_toan") & ":" & Space(1) & giTranMonth.ToString("00") & "/" & giTranYear & Space(3) & rl3("Don_vi") & ":" & Space(1) & gsDivisionID
        Dim sSQL As String = ""
        sSQL = "Select Closing From D09T9999 WITH(NOLOCK) Where TranMonth = " & SQLNumber(giTranMonth) & " And TranYear = " & SQLNumber(giTranYear) & " And DivisionID = " & SQLString(gsDivisionID)
        Dim sClosing As String = ReturnScalar(sSQL)
        gbClosed = Convert.ToBoolean(IIf(sClosing = "0", False, True))
        Return sRet
    End Function

    Public Function SumInTDBGrid(ByVal TDBGrid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer) As Double
        Dim dSum As Double = 0
        For i As Integer = 0 To TDBGrid.RowCount - 1
            If IsDBNull(TDBGrid(i, iCol).ToString()) Then TDBGrid(i, iCol) = 0
            dSum += Number(TDBGrid(i, iCol))
        Next
        Return dSum
    End Function

    ''' <summary>
    ''' Nếu con trỏ tại cột tên thì phải copy luôn cột mã (cột mã ẩn)
    ''' </summary>
    ''' <param name="c1Grid"></param>
    ''' <remarks></remarks>
    Public Sub HotKeyF8_Name(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Try
            If c1Grid.RowCount < 1 Then Exit Sub

            If c1Grid(c1Grid.Row, c1Grid.Col).ToString() = "" Then
                For j As Integer = c1Grid.Col - 1 To c1Grid.Columns.Count - 1
                    c1Grid.Columns(j).Text = c1Grid(c1Grid.Row - 1, j).ToString()
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1042
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 21/11/2007 02:19:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: Đổ nguồn cho ứng viên - D25F1042, D25F1044
    '#---------------------------------------------------------------------------------------------------
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


    ''' <summary>
    ''' Load trường dữ liệu ảnh từ DataBase: truờng dữ liệu kiểu Image 
    ''' 
    ''' Câu SQL chứa field ảnh 
    ''' Trả về một image 
    ''' </summary>
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

    ''' <summary>
    ''' Kiểm tra ngày giờ nhập vào
    ''' </summary>
    ''' <param name="sDateTime "></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function L3DateTimeValue(ByVal sDateTime As String) As String
        If sDateTime = MaskFormatDateTime Then Return MaskFormatDateTime

        'If sDate.IndexOf("/") = -1 Then Return MaskFormatDateTime
        Dim arr() As Object = Microsoft.VisualBasic.Split(sDateTime, " ")
        Dim dDate As Object = ConvertDate(arr(0).ToString)
        Dim dTime As Object = ConvertTime(arr(1).ToString)
        sDateTime = dDate.ToString & " " & dTime.ToString
        If IsDate(sDateTime) Then
            Return sDateTime.ToString
        Else
            Return MaskFormatDateTime
        End If
    End Function

    ''' <summary>
    ''' Format dạng giờ trên lưới
    ''' </summary>
    ''' <param name="sTime "></param>
    ''' <returns>Chuỗi giờ dạng HH:MM:SS</returns>
    ''' <remarks></remarks>
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


    Public Function SQL_CancelApproveRecruitProposal(ByVal sRecruitProposalID As String) As String

        Dim sSQL As String = ""
        sSQL = "Update D25T2000 Set "
        sSQL &= "ApprovedDate = NULL " & COMMA 'datetime, NULL
        sSQL &= "ApproverID = " & SQLString("") & COMMA 'varchar[20], NOT NULL
        sSQL &= "AppNumber = " & SQLNumber(0) & COMMA 'int, NOT NULL
        sSQL &= "AppCost = " & SQLMoney(0) & COMMA 'money, NOT NULL
        sSQL &= "AppCCost = " & SQLMoney(0) & COMMA 'money, NOT NULL

        sSQL &= "AppNote = " & SQLString("") & COMMA 'varchar[250], NOT NULL
        sSQL &= "Approved = " & SQLNumber(0) & COMMA 'tinyint, NOT NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NOT NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where "
        sSQL &= "RecruitProposalID = " & SQLString(sRecruitProposalID)
        sSQL &= vbCrLf


        sSQL &= "Update D25T2001 "
        sSQL &= "Set AppNumber=0, ProApproved=0 "
        sSQL &= "Where RecruitProposalID=" & SQLString(sRecruitProposalID)

        Return sSQL
    End Function


    'Public Function GetConvertedCost(ByVal sOperator As String, ByVal sOriginalCost As String, ByVal sExchangeRate As String) As String
    '    Dim sConvertedCost As String = ""

    '    Select Case sOperator
    '        Case "0"
    '            sConvertedCost = Format(Number(sOriginalCost) * Number(sExchangeRate), D25Format.D90_Converted)

    '        Case "1"
    '            sConvertedCost = Format(Number(sOriginalCost) / Number(sExchangeRate), D25Format.D90_Converted)
    '    End Select

    '    Return sConvertedCost
    'End Function

    Public Function GetConvertedCost(ByVal sOperator As String, ByVal sOriginalCost As String, ByVal sExchangeRate As String) As String
        Dim sConvertedCost As String = ""
        If Number(sExchangeRate) = 0 Then
            Return ""
        End If
        Select Case sOperator
            Case "0"
                sConvertedCost = Format0(Number(sOriginalCost) * Number(sExchangeRate), D25Format.D90_Converted)

            Case "1"
                sConvertedCost = Format0(Number(sOriginalCost) / Number(sExchangeRate), D25Format.D90_Converted)
        End Select

        Return sConvertedCost
    End Function

    Public Function AllowEdit_D25F3020(ByVal sRecruitmentFileID As String, ByVal sInterviewFileID As String) As Boolean
        Dim sSQL As String = ""
        Try

            sSQL = "Select 1 From D25T2011 WITH(NOLOCK) Where DivisionID=" & SQLString(gsDivisionID) & " And RecruitmentFileID = " & SQLString(sRecruitmentFileID) & " And InterviewFileID = " & SQLString(sInterviewFileID) & " And isnull(IntStatusID,'') <>''"
            Dim sResult As String = ReturnScalar(sSQL)
            If sResult = "1" Then
                'D99C0008.MsgCanNotEdit()
                EditPermission_D25F2012 = False
                Return False
            End If
            EditPermission_D25F2012 = True
            Return True
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
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

    Public Function Format0(ByVal sNum As String, ByVal sFormat As String) As String
        If Number(sNum) = 0 Then
            Return ""
        Else
            Return Format(Number(sNum), sFormat)
        End If

    End Function

    Public Function Format0(ByVal sNum As Double, ByVal sFormat As String) As String
        If sNum = 0 Then
            Return ""
        Else
            Return Format(sNum, sFormat)
        End If

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

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        Return c1Combo.SelectedValue.ToString
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

    Public Sub DisableMenuBeforeFilter(ByRef Menu1 As C1.Win.C1Command.C1Command, ByRef Menu2 As C1.Win.C1Command.C1Command, Optional ByRef Menu3 As C1.Win.C1Command.C1Command = Nothing, Optional ByRef Menu4 As C1.Win.C1Command.C1Command = Nothing, Optional ByRef Menu5 As C1.Win.C1Command.C1Command = Nothing, Optional ByVal Menu6 As C1.Win.C1Command.C1Command = Nothing, Optional ByVal Menu7 As C1.Win.C1Command.C1Command = Nothing, Optional ByVal Menu8 As C1.Win.C1Command.C1Command = Nothing)
        Menu1.Enabled = False
        Menu2.Enabled = False
        If Menu3 IsNot Nothing Then Menu3.Enabled = False
        If Menu4 IsNot Nothing Then Menu4.Enabled = False
        If Menu5 IsNot Nothing Then Menu5.Enabled = False
        If Menu6 IsNot Nothing Then Menu6.Enabled = False
        If Menu7 IsNot Nothing Then Menu7.Enabled = False
        If Menu8 IsNot Nothing Then Menu8.Enabled = False
    End Sub

    Public Sub MyLoadTdbcCustomizeReport(ByVal tdbc As C1.Win.C1List.C1Combo, ByVal sReportTypeID As String, Optional ByVal bUnicode As Boolean = False)
        Dim sSQL As String
        If bUnicode Then
            sSQL = "Select ReportID, TitleU As Title " & vbCrLf
        Else
            sSQL = "Select ReportID, Title " & vbCrLf
        End If
        sSQL &= "From D89T1000 WITH(NOLOCK) Where ModuleID = '25' And ReportTypeID = " & SQLString(sReportTypeID) & vbCrLf
        sSQL &= " AND (DAGroupID = '' OR " & vbCrLf
        sSQL &= " DAGroupID IN " & vbCrLf
        sSQL &= "    (SELECT DAGroupID " & vbCrLf
        sSQL &= "    FROM LEMONSYS.DBO.D00V0080 " & vbCrLf
        sSQL &= "    WHERE UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= " OR " & SQLString(gsUserID) & " = 'LEMONADMIN')" & vbCrLf
        sSQL &= "Order by ReportID"
        LoadDataSource(tdbc, sSQL, bUnicode)
    End Sub

    Public Sub HotKeyF7_Name(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal NameCol As Integer)
        Try
            If c1Grid.RowCount < 1 Then Exit Sub

            If c1Grid.Splits(c1Grid.SplitIndex).DisplayColumns.Item(c1Grid.Col).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far Then ' Số
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse Val(c1Grid(c1Grid.Row, c1Grid.Col).ToString) = 0 Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.Columns(NameCol).Text = c1Grid(c1Grid.Row - 1, NameCol).ToString()
                    c1Grid.UpdateData()
                End If
            Else ' Chuỗi hoặc Ngày
                If c1Grid(c1Grid.Row, c1Grid.Col).ToString = "" OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDateShort OrElse c1Grid(c1Grid.Row, c1Grid.Col).ToString = MaskFormatDate Then
                    c1Grid.Columns(c1Grid.Col).Text = c1Grid(c1Grid.Row - 1, c1Grid.Col).ToString()
                    c1Grid.Columns(NameCol).Text = c1Grid(c1Grid.Row - 1, NameCol).ToString()
                    c1Grid.UpdateData()
                End If
            End If

        Catch ex As Exception
            D99C0008.Msg("Lỗi HotKeyF7: " & ex.Message)
        End Try
    End Sub

    Public Function SQLDeleteD91T9009() As String
        Return "Delete From D91T9009 Where HostID=" & SQLString(My.Computer.Name) & " And UserID=" & SQLString(gsUserID) & vbCrLf
    End Function

    Public Function SQLInsertD91T9009(ByVal sKey1 As String, ByVal sKey2 As String, ByVal sKey3 As String, ByVal sKey4 As String, ByVal sKey5 As String) As String
        Dim sSQL As New StringBuilder
        sSQL.Append("INSERT INTO D91T9009(HostID,UserID, Key01ID, Key02ID, Key03ID, Key04ID, Key05ID) VALUES(")
        sSQL.Append(SQLString(My.Computer.Name) & COMMA)
        sSQL.Append(SQLString(gsUserID) & COMMA)
        sSQL.Append(SQLString(sKey1) & COMMA)
        sSQL.Append(SQLString(sKey2) & COMMA)
        sSQL.Append(SQLString(sKey3) & COMMA)
        sSQL.Append(SQLString(sKey4) & COMMA)
        sSQL.Append(SQLString(sKey5))
        sSQL.Append(")" & vbCrLf)

        Return sSQL.ToString
    End Function

    Public Sub LoadTdbcDutyID(ByVal tdbc As C1.Win.C1List.C1Combo)
        Dim sSQL As String = String.Empty
        'Load tdbcDutyID
        sSQL = " Select DutyID, DutyName" & UnicodeJoin(gbUnicode) & " AS DutyName" & vbCrLf
        sSQL &= " From D09T0211 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Where Disabled=0  Order by DutyID"
        LoadDataSource(tdbc, sSQL, gbUnicode)
    End Sub

    Public Function SafeCBool(ByVal objVal As Object) As Boolean
        If objVal.ToString = "" Then Return False
        If objVal Is Nothing Then Return False

        Return CBool(objVal)
    End Function

    Public Sub MsgNoPermissionAdd()
        D99C0008.MsgL3(rl3("Ban_khong_co_quyen_them_moi"))
    End Sub

    Public Function ReturnPermission_OldVersion(ByVal FormName As String) As Integer
        '#If DEBUG Then
        Try
            'Chỉ có tác dụng giúp cho chạy DEBUG dễ dàng hơn
            Dim sConnectionStringLEMONSYS As String = "Data Source=" & gsServer & ";Initial Catalog=LEMONSYS;User ID=" & gsConnectionUser & ";Password=" & gsPassword & ";Connect Timeout = 0"
            Dim sSQL As String = ""
            sSQL &= "Select Permission From D00V0001"
            sSQL &= " Where "
            sSQL &= "ScreenID = " & SQLString(FormName) & " And "
            sSQL &= "UserID = " & SQLString(gsUserID) & " And "
            sSQL &= "CompanyID = " & SQLString(gsCompanyID) & " And "
            sSQL &= "ModuleID = " & SQLString(FormName.Substring(0, 3))
            Dim conn As SqlConnection = New SqlConnection(sConnectionStringLEMONSYS)
            Dim cmd As SqlCommand = New SqlCommand(sSQL, conn)
            cmd.CommandTimeout = 0
            conn.Open()
            Dim sRet As Object = cmd.ExecuteScalar
            conn.Close()
            conn.Dispose()
            conn = Nothing
            If sRet Is Nothing Then
                Return -1 'Chưa tạo fix phân quyền, nên mặc định là không có quyền và = -1
            Else
                Return Convert.ToInt16(sRet) 'Có fix phân quyền và trả về quyền
            End If
        Catch
            Return -1
        End Try

    End Function

    Public Function InserZero(ByVal NumZero As Byte) As String
        If NumZero = 0 Then
            InserZero = ""
        Else
            InserZero = "."
            InserZero &= StrDup(NumZero, "0")
        End If
    End Function

    Public Function SafeCint(ByVal sVal As String) As Integer
        If sVal = "" Then
            Return 0
        Else
            Return CInt(sVal)
        End If
    End Function

    Public Function F7More(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColumnMore() As Integer) As Boolean
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


    Public Sub CopyColumnMore(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnMore As Integer)
        Dim i As Integer
        Dim sValue As String

        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            ' Copy them cot lien quan ở vị trí bất kỳ
            c1Grid.UpdateData()
            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult

            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                For i = RowCopy + 1 To c1Grid.RowCount - 1

                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        c1Grid(i, ColCopy) = sValue
                        c1Grid(i, ColumnMore) = c1Grid(RowCopy, ColumnMore)
                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                For i = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    c1Grid(i, ColumnMore) = c1Grid(RowCopy, ColumnMore)
                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub CopyColumnMore(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnMore() As Integer)
        Dim i As Integer
        Dim sValue As String

        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            ' Copy nhieu cot lien quan
            c1Grid.UpdateData()
            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult

            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                For i = RowCopy + 1 To c1Grid.RowCount - 1

                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                        c1Grid(i, ColCopy) = sValue
                        For k As Integer = 0 To ColumnMore.Length - 1
                            c1Grid(i, ColumnMore(k)) = c1Grid(RowCopy, ColumnMore(k))
                        Next k

                    End If
                Next
            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                For i = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                    For k As Integer = 0 To ColumnMore.Length - 1
                        c1Grid(i, ColumnMore(k)) = c1Grid(RowCopy, ColumnMore(k))
                    Next k
                Next

            End If

        Catch ex As Exception

        End Try
    End Sub

    Public Sub LoadDataSource_Own(ByVal C1Combo As C1.Win.C1List.C1Combo, ByVal dt As DataTable)
        Dim iMaxDropdownItems As Integer = 8
        Dim iColumnsCount As Integer = dt.Columns.Count - 1
        'For i As Integer = iColumnsCount To 0 Step -1
        '    If IsExistDataField(C1Combo, dt.Columns(i).ColumnName) = False Then dt.Columns.RemoveAt(i)
        'Next
        'If dt.Rows.Count < iMaxDropdownItems Then
        '    Dim dr As DataRow = Nothing
        '    For i As Integer = 0 To iMaxDropdownItems - dt.Rows.Count - 1
        '        dr = dt.NewRow
        '        dt.Rows.Add(dr)
        '    Next
        'End If
        Dim arrWidth(C1Combo.Splits(0).DisplayColumns.Count - 1) As Integer
        Dim arrVisible(C1Combo.Splits(0).DisplayColumns.Count - 1) As Boolean
        Dim arrHorizontalAlignment(C1Combo.Splits(0).DisplayColumns.Count - 1) As C1.Win.C1List.AlignHorzEnum
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            arrWidth(i) = C1Combo.Splits(0).DisplayColumns(i).Width
            arrVisible(i) = C1Combo.Splits(0).DisplayColumns(i).Visible
            arrHorizontalAlignment(i) = C1Combo.Splits(0).DisplayColumns(i).Style.HorizontalAlignment
        Next
        Dim arrCaption(C1Combo.Columns.Count - 1) As String
        For i As Integer = 0 To C1Combo.Columns.Count - 1
            arrCaption(i) = C1Combo.Columns(i).Caption
        Next

        C1Combo.DataSource = dt
        C1Combo.DisplayMember = C1Combo.DisplayMember
        C1Combo.ValueMember = C1Combo.ValueMember
        C1Combo.Font = New Font("Lemon3", 8.249999!)
        For i As Integer = 0 To C1Combo.Columns.Count - 1
            C1Combo.Columns(i).Caption = arrCaption(i)
        Next
        For i As Integer = 0 To C1Combo.Splits(0).DisplayColumns.Count - 1
            With C1Combo.Splits(0).DisplayColumns(i)
                .HeadingStyle.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.Center
                .Width = arrWidth(i)
                .Visible = arrVisible(i)
                .Style.HorizontalAlignment = arrHorizontalAlignment(i)
            End With
        Next
        C1Combo.HeadingStyle.Font = New Font("Microsoft Sans Serif", 8.25)
        C1Combo.HighLightRowStyle.BackColor = Color.Green
        C1Combo.HighLightRowStyle.ForeColor = SystemColors.HighlightText
        C1Combo.SelectedStyle.BackColor = Color.Green
        C1Combo.SelectedStyle.ForeColor = SystemColors.HighlightText
    End Sub

    Public Sub LoadDataSource_Own(ByVal C1DropDown As C1.Win.C1TrueDBGrid.C1TrueDBDropdown, ByVal dt As DataTable)
        'Dim iMaxDropdownItems As Integer = 8
        'Dim iColumnsCount As Integer = dt.Columns.Count - 1
        'For i As Integer = iColumnsCount To 0 Step -1
        '    If IsExistDataField(C1DropDown, dt.Columns(i).ColumnName) = False Then dt.Columns.RemoveAt(i)
        'Next
        'If dt.Rows.Count < iMaxDropdownItems Then
        '    Dim dr As DataRow = Nothing
        '    For i As Integer = 0 To iMaxDropdownItems - dt.Rows.Count - 1
        '        dr = dt.NewRow
        '        dt.Rows.Add(dr)
        '    Next
        'End If
        'Modify date: 31/08/2006: Set màu khi chọn
        C1DropDown.Styles.Item("Selected").BackColor = Color.Green
        'Dim dt1 As DataTable = dt.Copy
        C1DropDown.SetDataBinding(dt, "", True)
        'CType(C1DropDown.DataSource, DataTable).DataSet.Clear()
        'CType(C1DropDown.DataSource, DataTable).DataSet.AcceptChanges()
        'CType(C1DropDown.DataSource, DataTable).DataSet.Merge(dt1)
    End Sub

    Public Function CbVal(ByVal tdbc As C1.Win.C1List.C1Combo) As String
        If tdbc.SelectedValue Is Nothing OrElse tdbc.Text = "" Then Return ""

        Return tdbc.SelectedValue.ToString
    End Function

    Public Function ReturnTableDutyID(Optional ByVal bHavePercent As Boolean = True, Optional ByVal bUseUnicode As Boolean = False) As DataTable
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, bUseUnicode)
        '***************
        Dim sSQL As String = ""
        If bHavePercent Then
            sSQL = "SELECT		'%' AS PositionID, " & sLanguage & " AS PositionName" & vbCrLf
            sSQL &= "UNION" & vbCrLf
        End If
        sSQL &= "SELECT		DutyID As PositionID, DutyName" & sUnicode & " AS PositionName" & vbCrLf
        sSQL &= "FROM		D09T0211 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE		Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY	PositionID" & vbCrLf

        Return ReturnDataTable(sSQL)
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
        sSQL &= "FROM D09T0211  WITH(NOLOCK)" & vbCrLf
        sSQL &= "WHERE	Disabled = 0" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, RecPositionName" & vbCrLf

        Return ReturnDataTable(sSQL)
    End Function

    Public Sub Call_D39E0140(ByVal sFormActive As String, Optional ByVal sFormPermission As String = "", Optional ByVal bWait As Boolean = False)
        Dim arrPro() As StructureProperties = Nothing
        ' SetProperties(arrPro, xxxxxx, DxxFxxxxx)
        SetProperties(arrPro, "FormIDPermission", sFormPermission)
        CallFormShow("D39D0140", sFormActive, arrPro)
        '        Dim frm As New D39M0140
        '        With frm
        '            .FormActive = sFormActive
        '            .FormPermission = sFormPermission
        '            .bWait = bWait
        '            .ShowDialog()
        '            .Dispose()
        '        End With
    End Sub

    Public Function GetProjectID() As String
        Dim sSQL As String = ""
        sSQL = " -- Du an mac dinh theo User" & vbCrLf
        sSQL &= "SELECT  	ProjectID FROM	D09T0201 	T01  WITH(NOLOCK)" & vbCrLf
        sSQL &= "LEFT JOIN LEMONSYS..D00T0030 T02  WITH(NOLOCK) ON 	T01.EmployeeID = T02.HREmployeeID" & vbCrLf
        sSQL &= "WHERE 	UserID = " & SQLString(gsUserID)
        Return ReturnScalar(sSQL)
    End Function

    Public Function IsUseAppRecruitProposal(Optional ByVal FormID As String = "D25F2000") As Boolean
        Dim sSQL As String = "    SELECT 	NumValue as IsUseAppRecruitProposal" & vbCrLf & _
                "FROM 	D09T0009" & vbCrLf & _
                "WHERE	ModuleID = 'D25'" & vbCrLf & _
                "AND TransTypeID	= 'RecruitmentRequest'" & vbCrLf & _
                "AND FormID = " & SQLString(FormID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Return False
        Return L3Bool(dt.Rows(0).Item(0))
    End Function
End Module
