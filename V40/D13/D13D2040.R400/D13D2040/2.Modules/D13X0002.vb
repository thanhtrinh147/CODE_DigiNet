''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho mở lại hồ sơ lương
    ''' </summary>
    Public Function MsgNotReOpenSalaryFile() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_mo_lai")
        Return sMsg
    End Function

    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg
    End Function

    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function



#Region "Thực hiện AuditLog"

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2011 03:22:34
    '# Modified User:
    '# Modified Date:
    '# Description: 0(Gia tri cũ)/1(Gia tri mới)
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6200(ByVal TableName As String, ByVal ColVoucherID As String, ByVal VoucherID As String, ByVal iMode As Integer, ByVal ColTransID As String) As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(TableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(ColVoucherID) & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(VoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(ColTransID) & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6200s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2011 03:35:48
    '# Modified User:
    '# Modified Date:
    '# Description: 0(Gia tri cũ)/1(Gia tri mới)
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6200s(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal TableName As String, ByVal ColVoucherID As String, ByVal VoucherID As String, ByVal iMode As Integer, ByVal ColTransID As String) As String
        Dim sRet As String = ""
        Dim sSQL As String
        sSQL = ""
        sSQL &= "Exec D09P6200 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(TableName) & COMMA 'TableName, varchar[20], NOT NULL
        sSQL &= SQLString(ColVoucherID) & COMMA 'ColVoucherID, varchar[20], NOT NULL
        sSQL &= SQLString(VoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(iMode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLString(ColTransID) & COMMA 'ColTransID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'ColType, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        sRet &= sSQL & vbCrLf
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210
    '# Created User: Nguyễn Đức Trọng
    '# Created Date: 20/10/2011 08:08:00
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6210(ByVal sAuditCode As String, ByVal sAuditItemID As String, ByVal sEventID As String _
                    , Optional ByVal sDesc01 As String = "", Optional ByVal sDesc02 As String = "", Optional ByVal sDesc03 As String = "" _
                    , Optional ByVal sDesc04 As String = "", Optional ByVal sDesc05 As String = "") As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL'"03"
        sSQL &= SQLString(sAuditItemID) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(sDesc01) & COMMA 'Desc01, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc02) & COMMA 'Desc02, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc03) & COMMA 'Desc03, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc04) & COMMA 'Desc04, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc05) 'Desc05, nvarchar, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P6210s
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2011 03:34:18
    '# Modified User:
    '# Modified Date:
    '# Description:  So sanh Gia tri cũ và giá trị mới (TH Sửa)
    '#---------------------------------------------------------------------------------------------------
    Public Function SQLStoreD09P6210s(ByVal sAuditCode As String, ByVal sAuditItemID As String _
                    , ByVal sEventID As String, Optional ByVal sDesc01 As String = "", Optional ByVal sDesc02 As String = "", Optional ByVal sDesc03 As String = "" _
                    , Optional ByVal sDesc04 As String = "", Optional ByVal sDesc05 As String = "") As String
        Dim sRet As String = ""
        Dim sSQL As String

        sSQL = ""
        sSQL &= "Exec D09P6210 "
        sSQL &= SQLDateTimeSave(Now) & COMMA 'AuditDate, datetime, NOT NULL
        sSQL &= SQLString(sAuditCode) & COMMA 'AuditCode, varchar[20], NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString("13") & COMMA 'ModuleID, varchar[2], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(sEventID) & COMMA 'EventID, varchar[20], NOT NULL
        sSQL &= SQLString(sAuditItemID) & COMMA 'AuditItemID, varchar[50], NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(sDesc01) & COMMA 'Desc01, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc02) & COMMA 'Desc02, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc03) & COMMA 'Desc03, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc04) & COMMA 'Desc04, nvarchar, NOT NULL
        sSQL &= SQLString(sDesc05) 'Desc05, nvarchar, NOT NULL
        sRet &= sSQL & vbCrLf

        Return sRet
    End Function




#End Region

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

    'Kiểm tra là kỳ lớn nhất
    Public Function CheckMaxPeriod() As Boolean
        Dim iMaxPeriod As Integer = 0
        Dim sSQL As String = ""
        sSQL = "SELECT 	MAX(Tranmonth  + Tranyear *100)  FROM D09T9999 WITH (NOLOCK) WHERE DivisionID =  " & SQLString(gsDivisionID)
        iMaxPeriod = L3Int(ReturnScalar(sSQL))

        Return iMaxPeriod = (giTranMonth + giTranYear * 100)
    End Function
End Module
