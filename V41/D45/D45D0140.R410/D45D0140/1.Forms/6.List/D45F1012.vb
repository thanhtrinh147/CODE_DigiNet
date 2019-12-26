'#-------------------------------------------------------------------------------------
'# Created Date: 21/05/2007 2:35:08 PM
'# Created User: Nguyễn Lê Phương
'# Modify Date: 21/05/2007 2:35:08 PM
'# Modify User: Nguyễn Lê Phương
'#-------------------------------------------------------------------------------------
Public Class D45F1012
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Dim bCheck As Boolean = False

#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0     ' Chọn
    Private Const COL_StageID As Integer = 1    ' Mã công đoạn
    Private Const COL_StageName As Integer = 2  ' Diễn giải
    Private Const COL_CreateDate As Integer = 3 ' Ngày tạo
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As New StringBuilder
        sSQL.Append("SELECT CAST(0 AS bit) AS IsUsed, WorkCenterID as StageID,")
        sSQL.Append(" MAX(WorkCenterName" & UnicodeJoin(gbUnicode) & ") AS StageName,")
        sSQL.Append(" MAX(CreateDate) AS CreateDate")
        sSQL.Append(" FROM D32T1210 WITH(NOLOCK) ")
        sSQL.Append(" WHERE Disabled = 0 AND WorkCenterID NOT IN ")
        sSQL.Append(" (SELECT StageID FROM D45T1010 WITH(NOLOCK) )")
        sSQL.Append(" GROUP BY WorkCenterID")
        sSQL.Append(" ORDER BY WorkCenterID")
        LoadDataSource(tdbg, sSQL.ToString, gbUnicode)
    End Sub

    Private Sub D45F1012_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        LoadTDBGrid()
        Loadlanguage()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_cong_doan_-_D45F1012") & UnicodeCaption(gbUnicode) 'KÕ thôa c¤ng ¢oÁn - D45F1012
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnAction.Text = rl3("Ke_thu__a")
        '================================================================ 
        chkCheckAll.Text = rl3("Chon_tat_ca") 'Chọn tất cả
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbg.Columns("CreateDate").Caption = rl3("Ngay_tao") 'Ngày tạo

    End Sub

    Private Sub chkCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCheckAll.CheckedChanged
        If chkCheckAll.Checked Then
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUsed) = True
            Next i
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                tdbg(i, COL_IsUsed) = False
            Next i
        End If

    End Sub

    Private Sub btnAction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAction.Click
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            Exit Sub
        End If

        _bSaved = False
        Dim sSQL As New StringBuilder
        sSQL.Append("CREATE TABLE #D45T1010(StageID Varchar(20))")
        sSQL.Append(vbCrLf)

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) = True Then
                sSQL.Append("Insert INTO #D45T1010(StageID) VALUES (")
                sSQL.Append(SQLString(tdbg(i, COL_StageID).ToString))
                sSQL.Append(")")
                sSQL.Append(vbCrLf)
            End If
        Next

        sSQL.Append(SQLStoreD45P1010() & vbCrLf)

        sSQL.Append("DROP TABLE #D45T1010")
        Dim bResult As Boolean = ExecuteSQL(sSQL.ToString)
        If bResult Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Ke_thua_thanh_cong"))
            Me.Close()
        Else
            D99C0008.MsgL3(rl3("Ke_thua_khong_thanh_cong"))
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P1010
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 14/05/2007 08:31:11
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P1010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P1010 " & SQLNumber(gbUnicode)
        Return sSQL
    End Function


End Class
