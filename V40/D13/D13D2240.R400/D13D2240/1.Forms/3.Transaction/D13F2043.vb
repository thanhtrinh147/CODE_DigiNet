Imports System.Text
Imports System

Public Class D13F2043
	Dim report As D99C2003

#Region "Const of tdbg"
    Private Const COL_DepartmentID As Integer = 0 ' Phòng ban
    Private Const COL_TeamID As Integer = 1       ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 2   ' Mã nhân viên
    Private Const COL_EmployeeName As Integer = 3 ' Họ và tên
    Private Const COL_ProductID As Integer = 4    ' Sản phẩm
    Private Const COL_ProductName As Integer = 5  ' Tên sản phẩm
    Private Const COL_StageID As Integer = 6      ' Công đoạn
    Private Const COL_StageName As Integer = 7    ' Tên công đoạn
    Private Const COL_Quantity01 As Integer = 8   ' 
    Private Const COL_Quantity02 As Integer = 9   ' 
    Private Const COL_Quantity03 As Integer = 10  ' 
    Private Const COL_Quantity04 As Integer = 11  ' 
    Private Const COL_Quantity05 As Integer = 12  ' 
    Private Const COL_UnitPrice01 As Integer = 13 ' 
    Private Const COL_UnitPrice02 As Integer = 14 ' 
    Private Const COL_UnitPrice03 As Integer = 15 ' 
    Private Const COL_UnitPrice04 As Integer = 16 ' 
    Private Const COL_UnitPrice05 As Integer = 17 ' 
    Private Const COL_Amount01 As Integer = 18    ' 
    Private Const COL_Amount02 As Integer = 19    ' 
    Private Const COL_Amount03 As Integer = 20    ' 
    Private Const COL_Amount04 As Integer = 21    ' 
    Private Const COL_Amount05 As Integer = 22    ' 
    Private Const COL_Amount06 As Integer = 23    ' 
    Private Const COL_Amount07 As Integer = 24    ' 
    Private Const COL_Amount08 As Integer = 25    ' 
    Private Const COL_Amount09 As Integer = 26    ' 
    Private Const COL_Amount10 As Integer = 27    ' 
    Private Const COL_Amount11 As Integer = 28    ' 
    Private Const COL_Amount12 As Integer = 29    ' 
    Private Const COL_Amount13 As Integer = 30    ' 
    Private Const COL_Amount14 As Integer = 31    ' 
    Private Const COL_Amount15 As Integer = 32    ' 
    Private Const COL_Amount16 As Integer = 33    ' 
    Private Const COL_Amount17 As Integer = 34    ' 
    Private Const COL_Amount18 As Integer = 35    ' 
    Private Const COL_Amount19 As Integer = 36    ' 
    Private Const COL_Amount20 As Integer = 37    ' 
    Private Const COL_Amount21 As Integer = 38    ' 
    Private Const COL_Amount22 As Integer = 39    ' 
    Private Const COL_Amount23 As Integer = 40    ' 
    Private Const COL_Amount24 As Integer = 41    ' 
    Private Const COL_Amount25 As Integer = 42    ' 
    Private Const COL_Amount26 As Integer = 43    ' 
    Private Const COL_Amount27 As Integer = 44    ' 
    Private Const COL_Amount28 As Integer = 45    ' 
    Private Const COL_Amount29 As Integer = 46    ' 
    Private Const COL_Amount30 As Integer = 47    ' 
    Private Const COL_Amount31 As Integer = 48    ' 
    Private Const COL_Amount32 As Integer = 49    ' 
    Private Const COL_Amount33 As Integer = 50    ' 
    Private Const COL_Amount34 As Integer = 51    ' 
    Private Const COL_Amount35 As Integer = 52    ' 
    Private Const COL_Amount36 As Integer = 53    ' 
    Private Const COL_Amount37 As Integer = 54    ' 
    Private Const COL_Amount38 As Integer = 55    ' 
    Private Const COL_Amount39 As Integer = 56    ' 
    Private Const COL_Amount40 As Integer = 57    ' 
    Private Const COL_Amount41 As Integer = 58    ' 
    Private Const COL_Amount42 As Integer = 59    ' 
    Private Const COL_Amount43 As Integer = 60    ' 
    Private Const COL_Amount44 As Integer = 61    ' 
    Private Const COL_Amount45 As Integer = 62    ' 
    Private Const COL_Amount46 As Integer = 63    ' 
    Private Const COL_Amount47 As Integer = 64    ' 
    Private Const COL_Amount48 As Integer = 65    ' 
    Private Const COL_Amount49 As Integer = 66    ' 
    Private Const COL_Amount50 As Integer = 67    ' 
    Private Const COL_Amount51 As Integer = 68    ' 
    Private Const COL_Amount52 As Integer = 69    ' 
    Private Const COL_Amount53 As Integer = 70    ' 
    Private Const COL_Amount54 As Integer = 71    ' 
    Private Const COL_Amount55 As Integer = 72    ' 
    Private Const COL_Amount56 As Integer = 73    ' 
    Private Const COL_Amount57 As Integer = 74    ' 
    Private Const COL_Amount58 As Integer = 75    ' 
    Private Const COL_Amount59 As Integer = 76    ' 
    Private Const COL_Amount60 As Integer = 77    ' 
    Private Const COL_Amount61 As Integer = 78    ' 
    Private Const COL_Amount62 As Integer = 79    ' 
    Private Const COL_Amount63 As Integer = 80    ' 
    Private Const COL_Amount64 As Integer = 81    ' 
    Private Const COL_Amount65 As Integer = 82    ' 
    Private Const COL_Amount66 As Integer = 83    ' 
    Private Const COL_Amount67 As Integer = 84    ' 
    Private Const COL_Amount68 As Integer = 85    ' 
    Private Const COL_Amount69 As Integer = 86    ' 
    Private Const COL_Amount70 As Integer = 87    ' 
    Private Const COL_Amount71 As Integer = 88    ' 
    Private Const COL_Amount72 As Integer = 89    ' 
    Private Const COL_Amount73 As Integer = 90    ' 
    Private Const COL_Amount74 As Integer = 91    ' 
    Private Const COL_Amount75 As Integer = 92    ' 
    Private Const COL_Amount76 As Integer = 93    ' 
    Private Const COL_Amount77 As Integer = 94    ' 
    Private Const COL_Amount78 As Integer = 95    ' 
    Private Const COL_Amount79 As Integer = 96    ' 
    Private Const COL_Amount80 As Integer = 97    ' 
    Private Const COL_Amount81 As Integer = 98    ' 
    Private Const COL_Amount82 As Integer = 99    ' 
    Private Const COL_Amount83 As Integer = 100   ' 
    Private Const COL_Amount84 As Integer = 101   ' 
    Private Const COL_Amount85 As Integer = 102   ' 
    Private Const COL_Amount86 As Integer = 103   ' 
    Private Const COL_Amount87 As Integer = 104   ' 
    Private Const COL_Amount88 As Integer = 105   ' 
    Private Const COL_Amount89 As Integer = 106   ' 
    Private Const COL_Amount90 As Integer = 107   ' 
    Private Const COL_Amount91 As Integer = 108   ' 
    Private Const COL_Amount92 As Integer = 109   ' 
    Private Const COL_Amount93 As Integer = 110   ' 
    Private Const COL_Amount94 As Integer = 111   ' 
    Private Const COL_Amount95 As Integer = 112   ' 
    Private Const COL_Amount96 As Integer = 113   ' 
    Private Const COL_Amount97 As Integer = 114   ' 
    Private Const COL_Amount98 As Integer = 115   ' 
    Private Const COL_Amount99 As Integer = 116   ' 
#End Region

    Private dtGrid As DataTable
    Private dtQuantity As DataTable
    Private dtUnitPrice As DataTable
    Private dtAmount As DataTable

    Private _salaryVoucherID As String = ""
    Public Property SalaryVoucherID() As String
        Get
            Return _salaryVoucherID
        End Get
        Set(ByVal value As String)
            If SalaryVoucherID = value Then
                _salaryVoucherID = ""
                Return
            End If
            _salaryVoucherID = value
        End Set
    End Property

    Private _salCalMethodID As String = ""
    Public Property SalCalMethodID() As String 
        Get
            Return _salCalMethodID
        End Get
        Set(ByVal Value As String )
            _salCalMethodID = Value
        End Set
    End Property

    Private _sFind As String = ""
    Public Property SFind() As String
        Get
            Return _sFind
        End Get
        Set(ByVal Value As String)
            _sFind = Value
        End Set
    End Property

    Private Sub D13F2043_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        SetShortcutPopupMenu(Me.C1CommandHolder)
        ResetColorGrid(tdbg, 0, 1)
        ResetSplitDividerSize(tdbg)
        Loadlanguage()
        tdbg_NumberFormat()
        CreateTableCaption()
        LoadCaption()
        LoadTDBGrid()
        SetResolutionForm(Me, Me.C1ContextMenu)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_bang_luong_san_pham_-_D13F2043") & UnicodeCaption(gbUnicode) 'Chi tiÕt b¶ng l§¥ng s¶n phÈm - D13F2043
        '================================================================ 
        btnAction.Text = rl3("_Thuc_hien_") '&Thực hiện...
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_nhan_vien") 'Mã nhân viên
        tdbg.Columns("FullName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("ProductID").Caption = rl3("San_pham") 'Sản phẩm
        tdbg.Columns("ProductName").Caption = rl3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns("StageID").Caption = rl3("Cong_doan") 'Công đoạn
        tdbg.Columns("StageName").Caption = rL3("Ten_cong_doan") 'Tên công đoạn
    End Sub

    Private Sub tdbg_NumberFormat()
        For i As Integer = COL_Quantity01 To COL_Amount99
            tdbg.Columns(i).NumberFormat = D13Format.DefaultNumber2
        Next
    End Sub

    Private gbEnabledUseFind As Boolean = False

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P3602()
        dtGrid = ReturnDataTable(sSQL)
        gbEnabledUseFind = dtGrid.Rows.Count > 0

        LoadDataSource(tdbg, dtGrid, gbUnicode)
        CheckMenu(Me.Name, C1CommandHolder, tdbg.RowCount, gbEnabledUseFind, True)
    End Sub

    Private Sub CreateTableCaption()
        Dim sSQL As String = ""
        sSQL = "SELECT Code, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Disabled " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'QTY'" & vbCrLf
        sSQL &= "ORDER BY Code"
        dtQuantity = ReturnDataTable(sSQL)

        sSQL = "SELECT Code, ShortName" & UnicodeJoin(gbUnicode) & " as ShortName, Disabled " & vbCrLf
        sSQL &= "FROM D45T0010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Type = 'PRICE'" & vbCrLf
        sSQL &= "ORDER BY Code"
        dtUnitPrice = ReturnDataTable(sSQL)

        sSQL = "SELECT Code, Isnull(ShortName" & UnicodeJoin(gbUnicode) & " + '(' + Code + ')','') AS Short, T1.Disabled, Type, Isnull(T2.CalculationType,0) As CalculationType " & vbCrLf
        sSQL &= "FROM D13T9000 T1  WITH(NOLOCK) " & vbCrLf
        sSQL &= "LEFT JOIN D13T2501 T2  WITH(NOLOCK) ON T2.CALNo = T1.CODE AND T2.Disabled = 0" & vbCrLf
        sSQL &= "AND SalCalMethodID = " & SQLString(_salCalMethodID) & vbCrLf
        sSQL &= "WHERE Type = 'PRCAL' " & vbCrLf
        sSQL &= "ORDER BY Code"
        dtAmount = ReturnDataTable(sSQL)
    End Sub

    Private Sub LoadCaption()
        For i As Integer = 0 To 4
            tdbg.Columns(COL_Quantity01 + i).Caption = dtQuantity.Rows(i).Item("ShortName").ToString
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_Quantity01 + i).Visible = Not CBool(dtQuantity.Rows(i).Item("Disabled"))
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Quantity01 + i).HeadingStyle.Font = FontUnicode(gbUnicode) 'New Font("Lemon3", 8.249999)
        Next

        For i As Integer = 0 To 4
            tdbg.Columns(COL_UnitPrice01 + i).Caption = dtUnitPrice.Rows(i).Item("ShortName").ToString
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_UnitPrice01 + i).Visible = Not CBool(dtUnitPrice.Rows(i).Item("Disabled"))
            tdbg.Splits(SPLIT1).DisplayColumns(COL_UnitPrice01 + i).HeadingStyle.Font = FontUnicode(gbUnicode) 'New Font("Lemon3", 8.249999)
        Next

        For i As Integer = 0 To 98
            tdbg.Columns(COL_Amount01 + i).Caption = dtAmount.Rows(i).Item("Short").ToString
            tdbg.Splits(SPLIT1).DisplayColumns.Item(COL_Amount01 + i).Visible = CBool(dtAmount.Rows(i).Item("CalculationType")) And (Not CBool(dtAmount.Rows(i).Item("Disabled")))
            tdbg.Splits(SPLIT1).DisplayColumns(COL_Amount01 + i).HeadingStyle.Font = FontUnicode(gbUnicode) 'New Font("Lemon3", 8.249999)
        Next
    End Sub

    Private Sub mnuPrint_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuPrint.Click
        If CallMenuFromGrid(tdbg, e) = False Then Exit Sub
        If Not AllowNewD99C2003(report, Me) Then Exit Sub

        'Dim report As New D99C1003
        Me.Cursor = Cursors.WaitCursor
        '************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D13R2043"
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rL3("In_chi_tiet_luong_san_pham") & " - " & sReportName
        sPathReport = UnicodeGetReportPath(gbUnicode, D13Options.ReportLanguage, "") & sReportName & ".rpt"

        'sSQL = SQLStoreD13P3602()
        sSQLSub = "SELECT * FROM D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(dtGrid.DefaultView.ToTable) '(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        C1ContextMenu.ShowContextMenu(btnAction, btnAction.PointToClient(New Point(btnAction.Left, btnAction.Top)))
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P3602
    '# Created User: DUCTRONG
    '# Created Date: 18/09/2008 11:13:54
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P3602() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P3602 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_salaryVoucherID) & COMMA 'SalaryVoucherID, varchar[20], NOT NULL
        sSQL &= "N" & SQLString(_sFind) & COMMA 'WhereClause, nvarchar, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

End Class