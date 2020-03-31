Imports System
Public Class D13F2025
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_NewTypeID As Integer = 0             ' Loại
    Private Const COL_InheritResourceID As Integer = 1     ' Nguồn kế thừa
    Private Const COL_MonthYear As Integer = 2             ' Kỳ
    Private Const COL_InheritTranMonth As Integer = 3      ' InheritTranMonth
    Private Const COL_InheritTranYear As Integer = 4       ' InheritTranYear
    Private Const COL_Description As Integer = 5           ' Phiếu kế thừa
    Private Const COL_InheritVoucherNo As Integer = 6      ' InheritVoucherNo
    Private Const COL_InheritVoucherID As Integer = 7      ' InheritVoucherID
    Private Const COL_MethodID As Integer = 8              ' MethodID
    Private Const COL_InheritTypeName As Integer = 9       ' InheritTypeName
    Private Const COL_InheritTypeID As Integer = 10        ' Loại kế thừa
    Private Const COL_Formular As Integer = 11             ' Công thức
    Private Const COL_Decimals As Integer = 12             ' Làm tròn
    Private Const COL_SQLFind As Integer = 13              ' SQLFind
    Private Const COL_IsObInheritVoucherID As Integer = 14 ' IsObInheritVoucherID
    Private Const COL_IsObInheritTypeID As Integer = 15    ' IsObInheritTypeID
    Private Const COL_IsObFormular As Integer = 16         ' IsObFormular
    Private Const COL_IsObPeriod As Integer = 17           ' IsObPeriod
    Private Const COL_IsObDecimals As Integer = 18         ' IsObDecimals
#End Region


    Private _absentVoucherID As String = ""
    Public Property AbsentVoucherID() As String 
        Get
            Return _absentVoucherID
        End Get
        Set(ByVal Value As String )
            _absentVoucherID = Value
        End Set
    End Property

    Private _mode As Integer = 0
    Public Property Mode() As Integer
        Get
            Return _mode
        End Get
        Set(ByVal Value As Integer)
            _mode = Value
        End Set
    End Property

    Private _transTypeID As String = ""
    Public WriteOnly Property TransTypeID() As String
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Dim dtInheritVoucherNo As DataTable
    Dim dtInheritTypeID As DataTable
    Dim dtShortName As DataTable
    Dim dtEvaShortName As DataTable
    Dim dtEvaResultVoucherNo As DataTable

    Private Sub D13F2025_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        '  D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", _bSaved.ToString())
        ' update 27/3/2013 id 55260 - Delete dữ liệu bảng tạm sau khi đóng form
        Dim sSQL As String
        sSQL = "-- Delete bang tam" & vbCrLf
        sSQL &= "DELETE D09T6666 "
        sSQL &= "WHERE 	FormID = 'D13F2025' "
        sSQL &= " AND UserID = " & SQLString(gsUserID)
        sSQL &= " AND HostID = " & SQLString(My.Computer.Name) & vbCrLf
        ExecuteSQLNoTransaction(sSQL)
    End Sub

    'Private iMode As Integer = 0 '0 Addnew; 1 Edit k dùng nên bỏ biến này 23/09/09

    Private Sub D13F2025_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D13F2025_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        'btnEdit.Left = btnSave.Left
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        LoadTDBCombo()
        LoadTDBDropDown()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBoxG4(txtDataTemplateID, txtDataTemplateID.MaxLength)
        '      CheckIdTDBGrid(tdbg, COL_Formular, True)
        If CheckDataTemplateID() Then
            'Edit
            'iMode = 1
            tdbcDataTemplateID.Visible = True
            Try
                tdbcDataTemplateID.SelectedIndex = 1
            Catch ex As Exception

            End Try
            txtDataTemplateID.Visible = False
            btnDelete.Enabled = True

            'tdbg.Enabled = False 'MO RA CHO SUA 22/09/09
        Else
            'AddNew
            'iMode = 0
            tdbcDataTemplateID.Text = ""
            txtDataTemplateID.Left = tdbcDataTemplateID.Left
            tdbcDataTemplateID.Visible = False
            txtDataTemplateID.Visible = True
            optPeriodMode3.Checked = True
            'btnSave.Enabled = True
            btnDelete.Enabled = False
            'btnInherit.Enabled = False

            '==================================
            'btnEdit.Visible = False
            'btnSave.Visible = True
            tdbg.Enabled = True
        End If
        LoadTDBGrid()

        SetBackColorObligatory()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Ke_thua_du_lieu_-_D13F2025") & UnicodeCaption(gbUnicode) 'KÕ thôa dö liÖu - D13F2025
        '================================================================ 
        lblDataTemplateID.Text = rl3("Mau_ke_thua_du_lieu") 'Mẫu kế thừa dữ liệu
        lblPeriodMode.Text = rl3("Ky_ke_thua") 'Kỳ kế thừa
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnDelete.Text = rl3("_Xoa") '&Xóa
        btnInherit.Text = rl3("Ke_thu__a") 'Kế thừ&a
        '================================================================ 
        optPeriodMode1.Text = rl3("Ky_truoc") 'Kỳ trước
        optPeriodMode2.Text = rl3("Ky_hien_hanh") 'Kỳ hiện hành
        optPeriodMode3.Text = rl3("Ky_goc") 'Kỳ gốc
        '================================================================ 
        tdbcDataTemplateID.Columns("DataTemplateID").Caption = rl3("Ma") 'Mã
        '================================================================ 
        tdbdInheritResourceID.Columns("InheritResourceID").Caption = rl3("Ma") 'Mã
        tdbdInheritResourceID.Columns("InheritResourceName").Caption = rl3("Ten") 'Tên
        tdbdMonthYear.Columns("MonthYear").Caption = rl3("Ky") 'Kỳ
        tdbdInheritVoucherNo.Columns("InheritVoucherNo").Caption = rl3("Ma") 'Mã
        tdbdInheritVoucherNo.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbdInheritTypeID.Columns("InheritTypeName").Caption = rl3("Ma") 'Mã
        tdbdInheritTypeID.Columns("Description").Caption = rl3("Ten") 'Tên
        tdbdNewTypeID.Columns("NewTypeID").Caption = rl3("Ma") 'Mã
        tdbdNewTypeID.Columns("NewTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("NewTypeID").Caption = rl3("Loai") 'Loại
        tdbg.Columns("InheritResourceID").Caption = rl3("Nguon_ke_thua") 'Nguồn kế thừa
        tdbg.Columns("MonthYear").Caption = rl3("Ky") 'Kỳ
        tdbg.Columns("Description").Caption = rl3("Phieu_ke_thua") 'Phiếu kế thừa
        tdbg.Columns("InheritTypeID").Caption = rl3("Loai_ke_thua") 'Loại kế thừa
        tdbg.Columns("Formular").Caption = rl3("Cong_thuc") 'Công thức
        tdbg.Columns("Decimals").Caption = rl3("Lam_tron") 'Làm tròn
    End Sub

    Private Sub LoadTDBGrid()
        Dim dt As DataTable = ReturnDataTable(SQLStoreD13P2100)
        If dt.Rows.Count > 0 Then
            If Number(dt.Rows(0).Item("PeriodMode")) = 1 Then
                optPeriodMode1.Checked = True
            ElseIf Number(dt.Rows(0).Item("PeriodMode")) = 2 Then
                optPeriodMode2.Checked = True
            ElseIf Number(dt.Rows(0).Item("PeriodMode")) = 3 Then
                optPeriodMode3.Checked = True
            End If
        End If
        LoadDataSource(tdbg, dt, gbUnicode)
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcDataTemplateID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtDataTemplateID.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Function CheckDataTemplateID() As Boolean
        Dim sSQL As String = ""
        sSQL &= "SELECT TOP 1 1" & vbCrLf
        sSQL &= "FROM   D13T2025" & vbCrLf
        sSQL &= "WHERE  ISNULL(DataTemplateID,'') <> ''"
        If ExistRecord(sSQL) Then
            Return True
        Else
            Return False
        End If
    End Function

#Region "Events tdbcDataTemplateID"

    Private Sub tdbcDataTemplateID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDataTemplateID.KeyDown
        If gbUnicode Then Exit Sub
        Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        Select Case e.KeyCode
            Case Keys.A, Keys.D, Keys.E, Keys.I, Keys.O, Keys.U, Keys.Y, Keys.Back
                tdbcName.AutoCompletion = False
            Case Else
                tdbcName.AutoCompletion = True
        End Select
    End Sub

    'Private Sub tdbcDataTemplateID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDataTemplateID.Leave
    '    If gbUnicode Then Exit Sub
    '    Dim tdbcName As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)

    '    If tdbcName.SelectedIndex <> -1 Then
    '        tdbcName.Text = tdbcName.Columns("DivisionName").Text
    '    End If
    'End Sub

    Private Sub tdbcDataTemplateID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDataTemplateID.Close
        If tdbcDataTemplateID.Text = "+" Then
            tdbcDataTemplateID.Visible = False
            txtDataTemplateID.Visible = True
            txtDataTemplateID.Text = ""
            btnDelete.Enabled = False
            'btnInherit.Enabled = False
            txtDataTemplateID.Left = tdbcDataTemplateID.Left
            '==========================
            'btnEdit.Visible = False
            'btnSave.Visible = True
            tdbg.Enabled = True

            'tdbg.Focus()
            tdbg.SplitIndex = 0
            tdbg.Col = COL_NewTypeID
            tdbg.Bookmark = 0

            txtDataTemplateID.Focus()
        End If
    End Sub

    Private Sub tdbcDataTemplateID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDataTemplateID.LostFocus
        If tdbcDataTemplateID.FindStringExact(tdbcDataTemplateID.Text) = -1 Then
            tdbcDataTemplateID.Text = ""
        End If
    End Sub

    Private Sub tdbcDataTemplateID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDataTemplateID.SelectedValueChanged
        If Not (tdbcDataTemplateID.Tag Is Nothing OrElse tdbcDataTemplateID.Tag.ToString = "") Then
            tdbcDataTemplateID.Tag = ""
            Exit Sub
        End If
        If tdbcDataTemplateID.SelectedValue Is Nothing Then
            Exit Sub
        End If
        If tdbcDataTemplateID.Text = "+" Then
            Exit Sub
        End If

        LoadTDBGrid()
    End Sub
#End Region

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcDataTemplateID
        sSQL = "SELECT     '+' AS DataTemplateID" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT     DISTINCT DataTemplateID" & vbCrLf
        sSQL &= "FROM       D13T2025" & vbCrLf
        sSQL &= "WHERE      isnull(DataTemplateID,'') <> '' " & vbCrLf
        sSQL &= "           AND Mode = " & Number(_mode) & vbCrLf
        sSQL &= "ORDER BY   DataTemplateID"
        LoadDataSource(tdbcDataTemplateID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdNewTypeID
        'sSQL = "SELECT     AbsentTypeDateID AS NewTypeID, " & vbCrLf
        'sSQL &= "			AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " AS NewTypeName, 0 AS Mode" & vbCrLf
        'sSQL &= "FROM 		D13T0118 " & vbCrLf
        'sSQL &= "WHERE 		Disabled = 0 " & vbCrLf
        'sSQL &= "UNION	" & vbCrLf
        'sSQL &= "SELECT 	HandAttendanceID AS NewTypeID, " & vbCrLf
        'sSQL &= "			Description" & UnicodeJoin(gbUnicode) & " AS NewTypeName, 1 AS Mode" & vbCrLf
        'sSQL &= "FROM 		D29T1070 " & vbCrLf
        'sSQL &= "WHERE 		Disabled = 0 AND IsSalaryType = 1" & vbCrLf
        'sSQL &= "ORDER BY 	Mode, NewTypeID" & vbCrLf
        'LoadDataSource(tdbdNewTypeID, ReturnTableFilter(ReturnDataTable(sSQL), "Mode = " & Number(_mode)), gbUnicode)

        If _transTypeID = "" Then
            sSQL = "SELECT     AbsentTypeDateID AS NewTypeID, Lookup" & UnicodeJoin(gbUnicode) & " As ShortName, " & vbCrLf
            sSQL &= "			AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " AS NewTypeName, 0 AS Mode" & vbCrLf
            sSQL &= "FROM 		D13T0118 T1" & vbCrLf
            sSQL &= "WHERE 		Disabled = 0 " & vbCrLf
        Else
            sSQL = "SELECT     AbsentTypeDateID AS NewTypeID, Lookup" & UnicodeJoin(gbUnicode) & " As ShortName, " & vbCrLf
            sSQL &= "			AbsentTypeDateName" & UnicodeJoin(gbUnicode) & " AS NewTypeName, 0 AS Mode" & vbCrLf
            sSQL &= "FROM 		D13T0118 T1" & vbCrLf
            sSQL &= "WHERE 		Disabled = 0 " & vbCrLf
            sSQL &= "           AND T1.AbsentTypeDateID IN (SELECT  AbsentTypeID" & vbCrLf
            sSQL &= "                                       FROM    D13T1131" & vbCrLf
            sSQL &= "                                       WHERE   TransTypeID = " & SQLString(_transTypeID) & ")" & vbCrLf
        End If
        LoadDataSource(tdbdNewTypeID, sSQL, gbUnicode)

        'Load tdbdInheritResourceID
        sSQL = "SELECT InheritResourceID,InheritResourceName" & UnicodeJoin(gbUnicode) & " as InheritResourceName, Mode, " & vbCrLf
        ' update 9/5/2013 id 55911
        sSQL &= "IsObInheritVoucherID, IsObInheritTypeID, IsObFormular, IsObPeriod, IsObDecimals" & vbCrLf
        sSQL &= "FROM		D13V2025" & vbCrLf
        sSQL &= "ORDER BY 	InheritResourceID" & vbCrLf
        LoadDataSource(tdbdInheritResourceID, ReturnTableFilter(ReturnDataTable(sSQL), "Mode = " & Number(_mode)), gbUnicode)

        'Load tdbdMonthYear
        sSQL = "Select      REPLACE(STR(TranMonth, 2), ' ', '0') + '/' + STR(TranYear, 4) AS MonthYear, TranMonth AS InheritTranMonth, TranYear AS InheritTranYear" & vbCrLf
        sSQL &= "From       D09T9999" & vbCrLf
        sSQL &= "Where      DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "Order By   TranYear DESC, TranMonth DESC"
        LoadDataSource(tdbdMonthYear, sSQL, gbUnicode)

        'Load tdbdInheritVoucherNo
        sSQL = "SELECT	 	InheritVoucherID, " & vbCrLf
        sSQL &= "			InheritVoucherNo, " & vbCrLf
        sSQL &= "Description" & UnicodeJoin(gbUnicode) & " as	Description, " & vbCrLf
        sSQL &= "			TranMonth, " & vbCrLf
        sSQL &= "			TranYear," & vbCrLf
        sSQL &= "			MethodID," & vbCrLf
        sSQL &= "           InheritResourceID," & vbCrLf
        sSQL &= "			Mode" & vbCrLf
        sSQL &= "FROM 		D13V2026" & vbCrLf
        sSQL &= "WHERE		(DivisionID = '%' OR DivisionID = " & SQLString(gsDivisionID) & ")" & vbCrLf
        sSQL &= "			AND (Isnull(DAGroupID,'') = ''" & vbCrLf
        sSQL &= "	          		OR  Isnull(DAGroupID,'') In (Select 	DAGroupID " & vbCrLf
        sSQL &= "	                      						From    LemonSys.dbo.D00V0080" & vbCrLf
        sSQL &= "	                       						Where   UserID = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "OR 'LEMONADMIN' = " & SQLString(gsUserID) & ")" & vbCrLf
        sSQL &= "ORDER BY	Mode, InheritVoucherID, InheritVoucherNo" & vbCrLf
        dtInheritVoucherNo = ReturnTableFilter(ReturnDataTable(sSQL), "Mode = " & Number(_mode), gbUnicode)

        'Load tdbdInheritTypeID
        sSQL = "SELECT 		InheritTypeID," & vbCrLf
        sSQL &= "InheritTypeName" & UnicodeJoin(gbUnicode) & " as	InheritTypeName," & vbCrLf
        sSQL &= "Description" & UnicodeJoin(gbUnicode) & " as	Description," & vbCrLf
        sSQL &= "			MethodID," & vbCrLf
        sSQL &= "			InheritResourceID," & vbCrLf
        sSQL &= "			Mode" & vbCrLf
        sSQL &= "FROM 		D13V2027 " & vbCrLf
        sSQL &= "ORDER BY	Mode, InheritResourceID,  InheritTypeID" & vbCrLf
        dtInheritTypeID = ReturnTableFilter(ReturnDataTable(sSQL), "Mode = " & Number(_mode), gbUnicode)

        'Load tdbdDecimals
        sSQL = "SELECT '-3' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'-2' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'-1' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'0' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'1' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'2' AS Decimals" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT	'3' AS Decimals"
        LoadDataSource(tdbdDecimals, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbdInheritVoucherNo(ByVal iTranMonth As String, ByVal iTranYear As String, ByVal sInheritResourceID As String)
        If sInheritResourceID = "4" Then
            LoadDataSource(tdbdInheritVoucherNo, ReturnTableFilter(dtInheritVoucherNo, "((TranMonth = " & Number(iTranMonth) & " And TranYear = " & Number(iTranYear) & ") OR (TranMonth = 0 And TranYear = 0))" & " And InheritResourceID = " & SQLString(sInheritResourceID), True), gbUnicode)
        Else
            LoadDataSource(tdbdInheritVoucherNo, ReturnTableFilter(dtInheritVoucherNo, "TranMonth = " & Number(iTranMonth) & " And TranYear = " & Number(iTranYear) & " And InheritResourceID = " & SQLString(sInheritResourceID), True), gbUnicode)
        End If
    End Sub

    Private Sub LoadtdbdInheritTypeID(ByVal sInheritResourceID As String, ByVal sMethodID As String)
        LoadDataSource(tdbdInheritTypeID, ReturnTableFilter(dtInheritTypeID, "InheritResourceID = " & SQLString(sInheritResourceID) & " And MethodID = " & SQLString(sMethodID), True), gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtDataTemplateID.Visible = True Then
            If txtDataTemplateID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Mau_ke_thua_du_lieu"))
                txtDataTemplateID.Focus()
                Return False
            End If

            Dim sSQL As String = ""
            sSQL &= "SELECT TOP 1 1" & vbCrLf
            sSQL &= "FROM   D13T2025" & vbCrLf
            sSQL &= "WHERE  DataTemplateID = " & SQLString(txtDataTemplateID.Text)
            sSQL &= "       AND Mode = " & Number(_mode)
            If ExistRecord(sSQL) Then
                D99C0008.MsgDuplicatePKey()
                txtDataTemplateID.Focus()
                Return False
            End If
        Else
            If tdbcDataTemplateID.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Mau_ke_thua_du_lieu"))
                tdbcDataTemplateID.Focus()
                Return False
            End If
        End If

        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_NewTypeID
            tdbg.Row = 0
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_NewTypeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_NewTypeID
                tdbg.Row = i
                Return False
            End If

            If tdbg(i, COL_InheritResourceID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Nguon_ke_thua"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_InheritResourceID
                tdbg.Row = i
                Return False
            End If
            ' update 10/5/2013 id 55911
            If L3Bool(tdbg(i, COL_IsObPeriod)) AndAlso tdbg(i, COL_MonthYear).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ky_ke_toan"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_MonthYear
                tdbg.Row = i
                Return False
            End If
            ' 10/1/2014 - 61847
            '            If L3Bool(tdbg(i, COL_IsObInheritVoucherID)) AndAlso tdbg(i, COL_InheritVoucherNo).ToString = "" Then
            '                D99C0008.MsgNotYetEnter(rl3("Phieu_ke_thua"))
            '                tdbg.Focus()
            '                tdbg.SplitIndex = SPLIT1
            '                tdbg.Col = COL_Description
            '                tdbg.Row = i
            '                Return False
            '            End If
            If L3Bool(tdbg(i, COL_IsObInheritTypeID)) AndAlso tdbg(i, COL_InheritTypeID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Loai_ke_thua"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_InheritTypeID
                tdbg.Row = i
                Return False
            End If
            If L3Bool(tdbg(i, COL_IsObFormular)) AndAlso tdbg(i, COL_Formular).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Cong_thuc"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_Formular
                tdbg.Row = i
                Return False
            End If
            If L3Bool(tdbg(i, COL_IsObDecimals)) AndAlso tdbg(i, COL_Decimals).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Lam_tron"))
                tdbg.Focus()
                tdbg.SplitIndex = SPLIT1
                tdbg.Col = COL_Decimals
                tdbg.Row = i
                Return False
            End If
            '            If tdbg(i, COL_MonthYear).ToString = "" And tdbg(i, COL_InheritResourceID).ToString <> "5" And tdbg(i, COL_InheritResourceID).ToString <> "" Then
            '                D99C0008.MsgNotYetEnter(rl3("Ky_ke_toan"))
            '                tdbg.SplitIndex = SPLIT1
            '                tdbg.Col = COL_MonthYear
            '                tdbg.Bookmark = i
            '                Return False
            '            End If
            '            If tdbg(i, COL_InheritVoucherNo).ToString = "" And tdbg(i, COL_InheritResourceID).ToString <> "2" And tdbg(i, COL_InheritResourceID).ToString <> "5" Then
            '                D99C0008.MsgNotYetEnter(rl3("Phieu_ke_thua"))
            '                tdbg.SplitIndex = SPLIT1
            '                tdbg.Col = COL_InheritVoucherNo
            '                tdbg.Bookmark = i
            '                Return False
            '            End If
            '            If tdbg(i, COL_InheritTypeName).ToString = "" And tdbg(i, COL_InheritResourceID).ToString <> "5" Then
            '                D99C0008.MsgNotYetEnter(rl3("Loai_ke_thua"))
            '                tdbg.SplitIndex = SPLIT1
            '                tdbg.Col = COL_InheritTypeName
            '                tdbg.Bookmark = i
            '                Return False
            '            End If
            '            If tdbg(i, COL_Formular).ToString = "" And tdbg(i, COL_InheritResourceID).ToString = "5" Then
            '                D99C0008.MsgNotYetEnter(rl3("Cong_thuc"))
            '                tdbg.SplitIndex = SPLIT1
            '                tdbg.Col = COL_Formular
            '                tdbg.Bookmark = i
            '                Return False
            '            End If
        Next
        Return True
    End Function

#Region "tdbg event"

    Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
        ' update 9/5/2013 id 55911
        Select Case tdbg.Col
            Case COL_MonthYear
                e.Cancel = Not L3Bool(tdbg.Columns(COL_IsObPeriod).Text)
            Case COL_Description
                e.Cancel = Not L3Bool(tdbg.Columns(COL_IsObInheritVoucherID).Text)
            Case COL_InheritTypeID
                e.Cancel = Not L3Bool(tdbg.Columns(COL_IsObInheritTypeID).Text)
            Case COL_Formular
                e.Cancel = Not L3Bool(tdbg.Columns(COL_IsObFormular).Text)
            Case COL_Decimals
                e.Cancel = Not L3Bool(tdbg.Columns(COL_IsObDecimals).Text)
        End Select
        Select Case tdbg.Col
            Case COL_MonthYear
                If tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Or tdbg.Columns(COL_InheritResourceID).Value.ToString = "" Then
                    e.Cancel = True
                End If
            Case COL_Description
                If tdbg.Columns(COL_InheritResourceID).Value.ToString = "2" Or tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Then
                    e.Cancel = True
                End If
            Case COL_InheritTypeName
                If tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Then
                    e.Cancel = True
                End If
            Case COL_Formular
                If tdbg.Columns(COL_InheritResourceID).Value.ToString <> "5" Then
                    e.Cancel = True
                End If
            Case COL_Decimals
                If tdbg.Columns(COL_InheritResourceID).Value.ToString <> "5" Then
                    e.Cancel = True
                End If
        End Select
    End Sub

    '    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
    '        Select Case e.ColIndex
    '            Case COL_Formular
    '                e.Cancel = L3IsFormula(tdbg, e.ColIndex)
    '            Case COL_NewTypeID
    '
    '                If tdbg.Columns(COL_NewTypeID).Text <> tdbdNewTypeID.Columns("NewTypeID").Text Then
    '                    tdbg.Columns(COL_NewTypeID).Text = ""
    '                End If
    '                If Not CheckDupplicate() Then tdbg.Columns(COL_NewTypeID).Text = "" : e.Cancel = True
    '
    '            Case COL_InheritResourceID
    '                If tdbg.Columns(COL_InheritResourceID).Value.ToString <> tdbdInheritResourceID.Columns("InheritResourceID").Text Then
    '                    tdbg.Columns(COL_InheritResourceID).Value = ""
    '
    '                    For i As Integer = COL_MonthYear To COL_Decimals
    '                        tdbg.Columns(i).Text = ""
    '                    Next
    '                    ' update 9/5/2013 id 55911
    '                    For i As Integer = COL_IsObInheritVoucherID To COL_IsObDecimals
    '                        tdbg.Columns(i).Text = "0"
    '                    Next
    '                End If
    '            Case COL_MonthYear
    '                If tdbg.Columns(COL_MonthYear).Text <> tdbdMonthYear.Columns("MonthYear").Text Then
    '                    tdbg.Columns(COL_MonthYear).Text = ""
    '                    tdbg.Columns(COL_InheritTranMonth).Text = ""
    '                    tdbg.Columns(COL_InheritTranYear).Text = ""
    '
    '                    tdbg.Columns(COL_InheritVoucherNo).Text = ""
    '                    tdbg.Columns(COL_InheritVoucherID).Text = ""
    '                    tdbg.Columns(COL_MethodID).Text = ""
    '
    '                    tdbg.Columns(COL_InheritTypeID).Text = ""
    '                    tdbg.Columns(COL_InheritTypeName).Text = ""
    '                End If
    '            Case COL_InheritVoucherNo
    '                If tdbg.Columns(COL_InheritVoucherNo).Text <> tdbdInheritVoucherNo.Columns("InheritVoucherNo").Text Then
    '                    tdbg.Columns(COL_InheritVoucherNo).Text = ""
    '                    tdbg.Columns(COL_InheritVoucherID).Text = ""
    '                    tdbg.Columns(COL_MethodID).Text = ""
    '
    '                    tdbg.Columns(COL_InheritTypeID).Text = ""
    '                    tdbg.Columns(COL_InheritTypeName).Text = ""
    '                End If
    '            Case COL_InheritTypeName
    '                If tdbg.Columns(COL_InheritTypeName).Text <> tdbdInheritTypeID.Columns("InheritTypeName").Text Then
    '                    tdbg.Columns(COL_InheritTypeID).Text = ""
    '                    tdbg.Columns(COL_InheritTypeName).Text = ""
    '                End If
    '            Case COL_Decimals
    '                If tdbg.Columns(COL_Decimals).Text <> tdbdDecimals.Columns("Decimals").Text Then
    '                    tdbg.Columns(COL_Decimals).Text = "0"
    '                End If
    '        End Select
    '    End Sub

    Private Function CheckDupplicate() As Boolean
        For j As Integer = 0 To tdbg.RowCount - 1
            If j <> tdbg.Row And tdbg.Columns(COL_NewTypeID).Text = tdbg(j, COL_NewTypeID).ToString Then
                D99C0008.MsgL3(rl3("Du_lieu_nay_da_duoc_nhap"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_NewTypeID
                tdbg.Row = tdbg.Bookmark
                Return False
            End If
        Next j
        Return True
    End Function

    Dim bNotInList As Boolean = False
    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_Formular
                e.Cancel = L3IsFormula(tdbg, e.ColIndex)
            Case COL_NewTypeID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
                If Not CheckDupplicate() Then tdbg.Columns(COL_NewTypeID).Text = ""
            Case COL_Decimals
                If tdbg.Columns(COL_Decimals).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(COL_Decimals).Text = "0"
                End If
            Case COL_MonthYear, COL_InheritTypeID
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                End If
            Case COL_InheritResourceID, COL_Description
                If tdbg.Columns(e.ColIndex).Text <> tdbg.Columns(e.ColIndex).DropDown.Columns(tdbg.Columns(e.ColIndex).DropDown.DisplayMember).Text Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = True
                End If
        End Select
    End Sub


    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        '        '--- Gán giá trị cột sau khi tính toán và giá trị phụ thuộc từ Dropdown
        Select Case e.ColIndex
            Case COL_InheritResourceID
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    For i As Integer = COL_MonthYear To COL_Decimals
                        tdbg.Columns(i).Text = ""
                    Next
                    tdbg.Columns(COL_IsObInheritVoucherID).Text = "0"
                    tdbg.Columns(COL_IsObInheritTypeID).Text = "0"
                    tdbg.Columns(COL_IsObFormular).Text = "0"
                    tdbg.Columns(COL_IsObPeriod).Text = "0"
                    tdbg.Columns(COL_IsObDecimals).Text = "0"
                    Exit Select
                End If
                Select Case tdbdInheritResourceID.Columns("InheritResourceID").Text
                    Case "1", "2", "3", "4", "6", "7"
                        For i As Integer = COL_Description To COL_Decimals
                            tdbg.Columns(i).Text = ""
                        Next
                    Case "5"
                        For i As Integer = COL_MonthYear To COL_Decimals
                            tdbg.Columns(i).Text = ""
                        Next
                End Select
                tdbg.Columns(COL_IsObInheritVoucherID).Text = tdbdInheritResourceID.Columns("IsObInheritVoucherID").Text
                tdbg.Columns(COL_IsObInheritTypeID).Text = tdbdInheritResourceID.Columns("IsObInheritTypeID").Text
                tdbg.Columns(COL_IsObFormular).Text = tdbdInheritResourceID.Columns("IsObFormular").Text
                tdbg.Columns(COL_IsObPeriod).Text = tdbdInheritResourceID.Columns("IsObPeriod").Text
                tdbg.Columns(COL_IsObDecimals).Text = tdbdInheritResourceID.Columns("IsObDecimals").Text
            Case COL_MonthYear
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InheritTranMonth).Text = ""
                    tdbg.Columns(COL_InheritTranYear).Text = ""
                    tdbg.Columns(COL_InheritVoucherNo).Text = ""
                    tdbg.Columns(COL_Description).Text = ""
                    tdbg.Columns(COL_InheritVoucherID).Text = ""
                    tdbg.Columns(COL_MethodID).Text = ""
                    tdbg.Columns(COL_InheritTypeID).Text = ""
                    tdbg.Columns(COL_InheritTypeName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_MonthYear).Text = tdbdMonthYear.Columns("MonthYear").Text
                tdbg.Columns(COL_InheritTranMonth).Text = tdbdMonthYear.Columns("InheritTranMonth").Text
                tdbg.Columns(COL_InheritTranYear).Text = tdbdMonthYear.Columns("InheritTranYear").Text

                tdbg.Columns(COL_InheritVoucherNo).Text = ""
                tdbg.Columns(COL_Description).Text = ""
                tdbg.Columns(COL_InheritVoucherID).Text = ""
                tdbg.Columns(COL_MethodID).Text = ""

                tdbg.Columns(COL_InheritTypeID).Text = ""
                tdbg.Columns(COL_InheritTypeName).Text = ""
            Case COL_Description
                If tdbg.Columns(e.ColIndex).Text = "" OrElse bNotInList Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    bNotInList = False
                    'Gắn rỗng các cột liên quan
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InheritVoucherNo).Text = ""
                    tdbg.Columns(COL_InheritVoucherID).Text = ""
                    tdbg.Columns(COL_MethodID).Text = ""

                    tdbg.Columns(COL_InheritTypeID).Text = ""
                    tdbg.Columns(COL_InheritTypeName).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_InheritVoucherNo).Text = tdbdInheritVoucherNo.Columns("InheritVoucherNo").Text
                tdbg.Columns(COL_InheritVoucherID).Text = tdbdInheritVoucherNo.Columns("InheritVoucherID").Text
                tdbg.Columns(COL_MethodID).Text = tdbdInheritVoucherNo.Columns("MethodID").Text

                tdbg.Columns(COL_InheritTypeID).Text = ""
                tdbg.Columns(COL_InheritTypeName).Text = ""

                '                If tdbg.Columns(e.ColIndex).Text = "" Then
                '                    tdbg.Columns(e.ColIndex).Text = ""
                '                    'Gắn rỗng các cột liên quan
                '                    tdbg.Columns(COL_InheritVoucherNo).Text = ""
                '                    tdbg.Columns(COL_InheritVoucherID).Text = ""
                '                    tdbg.Columns(COL_MethodID).Text = ""
                '
                '                    tdbg.Columns(COL_InheritTypeID).Text = ""
                '                    tdbg.Columns(COL_InheritTypeName).Text = ""
                '                    Exit Select
                '                End If
                '                tdbg.Columns(COL_InheritVoucherNo).Text = tdbdInheritVoucherNo.Columns("InheritVoucherNo").Text
                '                tdbg.Columns(COL_InheritVoucherID).Text = tdbdInheritVoucherNo.Columns("InheritVoucherID").Text
                '                tdbg.Columns(COL_MethodID).Text = tdbdInheritVoucherNo.Columns("MethodID").Text
                '
                '                tdbg.Columns(COL_InheritTypeID).Text = ""
                '                tdbg.Columns(COL_InheritTypeName).Text = ""
            Case COL_InheritTypeID
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_InheritTypeName).Text = ""
                    Exit Select
                    tdbg.Columns(COL_InheritTypeName).Text = tdbdInheritTypeID.Columns("InheritTypeName").Text
                End If
            Case COL_Decimals
                If tdbg.Columns(e.ColIndex).Text = "" Then
                    tdbg.Columns(e.ColIndex).Text = ""
                    'Gắn rỗng các cột liên quan
                    tdbg.Columns(COL_Decimals).Text = ""
                    Exit Select
                End If
                tdbg.Columns(COL_Decimals).Text = tdbdDecimals.Columns("Decimals").Text
        End Select
        bNotInList = False
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_DataSourceChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DataSourceChanged
        tdbg.Col = 0
        tdbg.Row = 0
    End Sub

    Private Sub tdbg_FetchCellTips(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellTipsEventArgs) Handles tdbg.FetchCellTips
        Select Case e.ColIndex
            Case COL_Formular
                If tdbg(e.Row, COL_InheritResourceID).ToString = "5" Then
                    Dim sTemp As String = IIf(gsLanguage = "84", "AÁn <Ctrl + T> ñeå choïn coâng thöùc", "Press <Ctrl + T> to choose Formula").ToString

                    If gbUnicode Then sTemp = ConvertVniToUnicode(sTemp)
                    e.CellTip = sTemp
                Else
                    e.CellTip = ""
                End If
        End Select

    End Sub

    ' update 10/5/2013 id 55911
    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        If tdbg(e.Row, COL_NewTypeID).ToString = "" And tdbg(e.Row, COL_InheritResourceID).ToString = "" Then
            Exit Sub
        End If
        Select Case e.Col
            Case COL_NewTypeID
                e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
            Case COL_InheritResourceID
                e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
            Case COL_MonthYear
                If L3Bool(tdbg(e.Row, COL_IsObPeriod)) Then
                    e.CellStyle.Locked = False
                    e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
                Else
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL_Description
                If L3Bool(tdbg(e.Row, COL_IsObInheritVoucherID)) Then
                    e.CellStyle.Locked = False
                    e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
                Else
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL_InheritTypeID
                If L3Bool(tdbg(e.Row, COL_IsObInheritTypeID)) Then
                    e.CellStyle.Locked = False
                    e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
                Else
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL_Formular
                If L3Bool(tdbg(e.Row, COL_IsObFormular)) Then
                    e.CellStyle.Locked = False
                    e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
                Else
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
            Case COL_Decimals
                If L3Bool(tdbg(e.Row, COL_IsObDecimals)) Then
                    e.CellStyle.Locked = False
                    e.CellStyle.BackColor = COLOR_BACKCOLOROBLIGATORY
                Else
                    e.CellStyle.Locked = True
                    e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.T
                    If tdbg.Col = COL_Formular Then
                        If tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Then
                            Dim f As New D13F2024
                            f.ShowDialog()
                            f.Dispose()
                            tdbg.Columns(COL_Formular).Text &= f.Formular
                            tdbg.UpdateData()
                            tdbg.Focus()
                            tdbg.SplitIndex = SPLIT1
                            tdbg.Col = COL_Formular
                        End If
                    End If
            End Select
        End If

        If e.KeyCode = Keys.F8 Then
            Select Case tdbg.Col
                Case COL_InheritResourceID
                    HotKeyF8(tdbg)
            End Select
        End If

        If e.KeyCode = Keys.F2 Then
            If Not tdbg.Col = COL_Description Then Exit Sub
            If tdbg.Columns(COL_InheritResourceID).Value.ToString = "4" And tdbg.Columns(COL_InheritVoucherNo).Text = "%" Then
                Dim sSQL As String = "Select Cast(0 as bit) as Selected, SalaryVoucherNo as SelectionID, Description as SelectionName"
                sSQL &= " From D13T2600"
                sSQL &= " Where TranMonth = " & SQLNumber(tdbg.Columns(COL_InheritTranMonth).Text)
                sSQL &= " and TranYear = " & SQLNumber(tdbg.Columns(COL_InheritTranYear).Text)
                sSQL &= " order by SalaryVoucherID"

                Dim arrPro() As StructureProperties = Nothing
                SetProperties(arrPro, "ModeSelect", L3Byte(0))
                SetProperties(arrPro, "SQLSelection", sSQL)
                Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6020", arrPro)
                Dim sKey As String = GetProperties(frm, "ReturnField").ToString
                'Load dữ liệu
                tdbg.Columns(COL_SQLFind).Value = sKey

                '                Dim frm As New D91F6020
                '                frm.ModeSelect = "0"
                '                frm.FormPermision = ""
                '                frm.SQLSelection = sSQL
                '                frm.ShowDialog()
                '                frm.Dispose()
                '                tdbg.Columns(COL_SQLFind).Value = frm.OutPut01
            End If
        End If

        HotKeyDownGrid(e, tdbg, COL_NewTypeID, 0, 1)
    End Sub

    Private Sub LockRow(ByVal bNewStatus As Boolean, Optional ByVal tdbd As C1.Win.C1TrueDBGrid.C1TrueDBDropdown = Nothing)
        If bNewStatus Then
            tdbg.Columns(tdbg.Col).DropDown = Nothing
            'tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Button = False
            tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoDropDown = False
            tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = False
        Else
            tdbg.Columns(tdbg.Col).DropDown = tdbd
            'tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Button = True
            tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoDropDown = True
            tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).AutoComplete = True
        End If
        tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Button = True
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Formular
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
            Case COL_Decimals
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberSign)
        End Select

    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_MonthYear
                If Not L3Bool(tdbg.Columns(COL_IsObPeriod).Text) Then
                    LockRow(True)
                Else
                    LockRow(False, tdbdMonthYear)
                End If
                ' update 10/5/2013 id 55911
                '                If tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Or tdbg.Columns(COL_InheritResourceID).Value.ToString = "" Then
                '                    LockRow(True)
                '                Else
                '                    LockRow(False, tdbdMonthYear)
                '                End If

            Case COL_Description
                If Not L3Bool(tdbg.Columns(COL_IsObInheritVoucherID).Text) Then
                    LockRow(True)
                Else
                    LockRow(False, tdbdInheritVoucherNo)
                    LoadtdbdInheritVoucherNo(tdbg(tdbg.Row, COL_InheritTranMonth).ToString, tdbg(tdbg.Row, COL_InheritTranYear).ToString, tdbg(tdbg.Row, COL_InheritResourceID).ToString)
                End If
                ' update 10/5/2013 id 55911
                '                If tdbg.Columns(COL_InheritResourceID).Value.ToString = "2" Or tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Then
                '                    LockRow(True)
                '                Else
                '                    LockRow(False, tdbdInheritVoucherNo)
                '                    LoadtdbdInheritVoucherNo(tdbg(tdbg.Row, COL_InheritTranMonth).ToString, tdbg(tdbg.Row, COL_InheritTranYear).ToString, tdbg(tdbg.Row, COL_InheritResourceID).ToString)
                '                End If

            Case COL_InheritTypeID
                If Not L3Bool(tdbg.Columns(COL_IsObInheritTypeID).Text) Then
                    LockRow(True)
                Else
                    LockRow(False, tdbdInheritTypeID)
                    LoadtdbdInheritTypeID(tdbg(tdbg.Row, COL_InheritResourceID).ToString, tdbg(tdbg.Row, COL_MethodID).ToString)
                End If
                ' update 10/5/2013 id 55911
                '                 If tdbg.Columns(COL_InheritResourceID).Value.ToString = "5" Then
                '                    LockRow(True)
                '                Else
                '                    LockRow(False, tdbdInheritTypeID)
                '                    LoadtdbdInheritTypeID(tdbg(tdbg.Row, COL_InheritResourceID).ToString, tdbg(tdbg.Row, COL_MethodID).ToString)
                '                End If

            Case COL_Decimals
                If Not L3Bool(tdbg.Columns(COL_IsObDecimals).Text) Then
                    LockRow(True)
                Else
                    LockRow(False, tdbdDecimals)
                End If
                ' update 10/5/2013 id 55911
                '                 If tdbg.Columns(COL_InheritResourceID).Value.ToString <> "5" Then
                '                    LockRow(True)
                '                Else
                '                    LockRow(False, tdbdDecimals)
                '                End If
            Case Else
                tdbg.Splits(1).DisplayColumns(tdbg.Col).Locked = False
        End Select
    End Sub

#End Region

    Private Function SQLStoreD13P2100() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2100 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text)) & COMMA 'DataTemplateID, varchar[50], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA
        sSQL &= SQLNumber(giTranYear) & COMMA
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA 'CodeTable, tinyint, NOT NULL
        sSQL &= SQLString(_transTypeID) 'TransTypeID, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2025
    '# Created User: DUCTRONG
    '# Created Date: 03/08/2009 07:56:18
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2025() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2025"
        sSQL &= " Where DataTemplateID = " & SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text))
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2025s
    '# Created User: DUCTRONG
    '# Created Date: 20/01/2010 09:39:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2025s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T2025(")
            sSQL.Append("Formular, Decimals, DataTemplateID, PeriodMode, InheritResourceID, ")
            sSQL.Append("NewTypeID, InheritVoucherID, InheritTypeID, Mode, InheritTranMonth, ")
            sSQL.Append("InheritTranYear, SQLFind, SQLFindU")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_Formular)) & COMMA) 'Formular, varchar[500], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Decimals)) & COMMA) 'Decimals, int, NOT NULL
            sSQL.Append(SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text)) & COMMA) 'DataTemplateID, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(IIf(optPeriodMode1.Checked, 1, IIf(optPeriodMode2.Checked, 2, 3))) & COMMA) 'PeriodMode, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InheritResourceID)) & COMMA) 'InheritResourceID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_NewTypeID)) & COMMA) 'NewTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InheritVoucherID)) & COMMA) 'InheritVoucherID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_InheritTypeID)) & COMMA) 'InheritTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(_mode) & COMMA) 'Mode, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_InheritTranMonth)) & COMMA) 'InheritTranMonth, tinyint, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_InheritTranYear)) & COMMA) 'InheritTranYear, smallint, NOT NULL
            Dim sFind As String = SQLString(tdbg(i, COL_SQLFind).ToString)
            If sFind <> "" Then
                sFind = sFind.Remove(0, 1)
                sFind = sFind.Remove(sFind.Length - 1)
            Else
                sFind = "''"
            End If
            sSQL.Append(SQLStringUnicode(sFind, gbUnicode, False) & COMMA)
            sSQL.Append(SQLStringUnicode(sFind, gbUnicode, True))
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLInsertD13T2025s
    ''# Created User: DUCTRONG
    ''# Created Date: 11/05/2009 09:39:08
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLInsertD13T2025s() As StringBuilder
    '    Dim sRet As New StringBuilder
    '    Dim sSQL As New StringBuilder
    '    For i As Integer = 0 To tdbg.RowCount - 1
    '        sSQL.Append("Insert Into D13T2025(")
    '        sSQL.Append("TypeID, Formular, Decimals, OldTranMonth, ")
    '        sSQL.Append("OldTranYear, OldAbsentVoucherID, OldAbsentTypeID, LeaveTypeID, LeaveIndexID, ")
    '        sSQL.Append("SalaryVoucherID, NewAbsentTypeID, CalNo, DataTemplateID, EvaResultVoucherID, EvaluationCriterionNo, PeriodMode")
    '        sSQL.Append(") Values(")
    '        'sSQL.Append(SQLNumber(tdbg(i, COL_Order)) & COMMA) 'Order, tinyint, NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_TypeID)) & COMMA) 'TypeID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_Formular)) & COMMA) 'Formular, varchar[500], NOT NULL
    '        sSQL.Append(SQLNumber(tdbg(i, COL_Decimals)) & COMMA) 'Decimals, tinyint, NOT NULL
    '        sSQL.Append(SQLNumber(tdbg(i, COL_OldTranMonth)) & COMMA) 'OldTranMonth, tinyint, NOT NULL
    '        sSQL.Append(SQLNumber(tdbg(i, COL_OldTranYear)) & COMMA) 'OldTranYear, smallint, NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_OldAbsentVoucherID)) & COMMA) 'OldAbsentVoucherID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_OldAbsentTypeID)) & COMMA) 'OldAbsentTypeID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_LeaveTypeID)) & COMMA) 'LeaveTypeID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_LeaveIndexID)) & COMMA) 'LeaveIndexID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_SalaryVoucherID)) & COMMA) 'SalaryVoucherID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_NewAbsentTypeID)) & COMMA) 'NewAbsentTypeID, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_CalNo)) & COMMA) 'CalNo, varchar[20], NOT NULL
    '        sSQL.Append(SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text)) & COMMA) 'DataTemplateID, varchar[50], NOT NULL
    '        sSQL.Append(SQLString(tdbg(i, COL_EvaResultVoucherID)) & COMMA)
    '        sSQL.Append(SQLString(tdbg(i, COL_EvaluationCriterionNo)) & COMMA)
    '        sSQL.Append(SQLNumber(IIf(optPeriodMode1.Checked, 1, IIf(optPeriodMode2.Checked, 2, 3))))
    '        sSQL.Append(")")

    '        sRet.Append(sSQL.ToString & vbCrLf)
    '        'sRet.Append(SQLStoreD13P2120() & vbCrLf)
    '        sSQL.Remove(0, sSQL.Length)
    '    Next
    '    Return sRet
    'End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2120
    '# Created User: DUCTRONG
    '# Created Date: 11/05/2009 09:39:55
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2120() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2120 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text)) & COMMA  'DataTemplateID, varchar[50], NOT NULL
        sSQL &= SQLNumber(_mode) & COMMA 'Mode, tinyint, NOT NULL
        sSQL &= SQLNumber(gbUnicode) & COMMA
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString("D13F2020") & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name)
        Return sSQL
    End Function

    Private Sub btnInherit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInherit.Click
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        'If tdbcDataTemplateID.Visible = False Then
        '    If ExistRecord("SELECT TOP 1 1 FROM D13T2025 WHERE DataTemplateID = " & SQLString(IIf(tdbcDataTemplateID.Visible, tdbcDataTemplateID.Text, txtDataTemplateID.Text)) & " AND Mode = " & Number(_mode)) Then
        '        D99C0008.MsgDuplicatePKey()
        '        Exit Sub
        '    End If
        'End If

        Me.Cursor = Cursors.WaitCursor
        btnInherit.Enabled = False

        Dim sSQL As New StringBuilder()

        sSQL.Append(SQLDeleteD13T2025() & vbCrLf)
        sSQL.Append(SQLInsertD13T2025s.ToString() & vbCrLf)
        sSQL.Append(SQLStoreD13P2120())

        If ExecuteSQL(sSQL.ToString) Then
            _bSaved = True
            D99C0008.MsgL3(rl3("Ke_thua_thanh_congU"))
            Me.Close()
            Exit Sub

            '***kế thừa xong đóng form,bỏ qua các bước sau
            If tdbcDataTemplateID.Visible = False Then
                LoadTDBCombo()
                'Mở combo tdbcDataTemplateID lại
                tdbcDataTemplateID.Visible = True
                Try
                    tdbcDataTemplateID.SelectedIndex = 1
                Catch
                End Try

                txtDataTemplateID.Visible = False
                btnDelete.Enabled = True
            End If

        End If
        btnInherit.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If D99C0008.MsgAskDelete = Windows.Forms.DialogResult.No Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        btnDelete.Enabled = False
        Dim sSQL As String = ""
        sSQL &= SQLDeleteD13T2025()
        If ExecuteSQL(sSQL) = True Then
            DeleteOK()
            If tdbcDataTemplateID.Visible Then
                LoadTDBCombo()
            Else
                txtDataTemplateID.Text = ""
            End If
            LoadTDBGrid()
        Else
            DeleteNotOK()
        End If
        btnDelete.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

End Class