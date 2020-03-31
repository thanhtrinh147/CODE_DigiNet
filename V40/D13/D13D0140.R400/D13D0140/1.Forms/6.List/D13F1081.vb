'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:44:19 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 08/05/2007 4:44:19 PM
'# Modify User: Trần Thị Ái Trâm
'#-------------------------------------------------------------------------------------
Public Class D13F1081
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


    Dim iLastCol As Integer
    Dim bFlagShiftInsert As Boolean = False

#Region "Const of tdbg"
    Private Const COL_RewardID As Integer = 0       ' Mã tiền thưởng
    Private Const COL_DetailRewardID As Integer = 1 ' Mã chi tiết
    Private Const COL_MinSalary As Integer = 2      ' > Thời gian (tháng)
    Private Const COL_MaxSalary As Integer = 3      ' <= Thời gian (tháng)
    Private Const COL_MinDate As Integer = 4        ' > Thời gian (ngày)
    Private Const COL_MaxDate As Integer = 5        ' <= Thời gian (ngày)
    Private Const COL_Amount As Integer = 6         ' Giá trị
#End Region

    Private _rewardID As String = ""
    Public Property RewardID() As String
        Get
            Return _rewardID
        End Get
        Set(ByVal value As String)
            If RewardID = value Then
                _rewardID = ""
                Return
            End If
            _rewardID = value
        End Set
    End Property

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    CheckIdTextBox(txtRewardID)
                    btnNext.Enabled = False
                    btnSave.Enabled = True
                    LoadAdd()
                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    LoadEdit()
                Case EnumFormState.FormView
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    LoadEdit()
                    btnClose.Focus()
            End Select
        End Set
    End Property

    Private Sub LoadAdd()
        txtRewardID.Text = ""
        chkDisabled.Visible = False

        txtRewardName.Text = ""
        optMonthReward.Checked = True
        optPartProgressive.Checked = True

        LoadTDBGrid(txtRewardID.Text)
        tdbg.Splits(0).DisplayColumns(COL_MinDate).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_MaxDate).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_MinSalary).Visible = True
        tdbg.Splits(0).DisplayColumns(COL_MaxSalary).Visible = True

        tdbg_LockedColumns()
    End Sub

    Private Sub LoadEdit()
        txtRewardID.Enabled = False
        chkDisabled.Visible = True
        LoadMaster()
        LoadTDBGrid(txtRewardID.Text)
        tdbg_LockedColumns()
    End Sub
    Private Sub tdbg_LockedColumns()
        If optMonthReward.Checked Then
            tdbg.Splits(0).DisplayColumns(COL_MinSalary).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(0).DisplayColumns(COL_MinSalary).Locked = True
        Else
            tdbg.Splits(0).DisplayColumns(COL_MinDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(0).DisplayColumns(COL_MinDate).Locked = True
        End If
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= "Select RewardID, RewardName, RewardNameU, Progressive, TimeReward, Disabled From D13T0301 WITH (NOLOCK) "
        sSQL &= " Where RewardID =  " & SQLString(_rewardID)
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If dt.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dt.Rows.Count - 1
            txtRewardID.Text = dt.Rows(i).Item("RewardID").ToString
            chkDisabled.Checked = Convert.ToBoolean(dt.Rows(i).Item("Disabled").ToString)
            txtRewardName.Text = dt.Rows(i).Item("RewardName" & UnicodeJoin(gbUnicode)).ToString

            If Convert.ToBoolean(dt.Rows(i).Item("TimeReward").ToString) = False Then
                optDateReward.Checked = True
                tdbg.Splits(0).DisplayColumns(COL_MinDate).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_MaxDate).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_MinSalary).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_MaxSalary).Visible = False

            Else
                optMonthReward.Checked = True
                tdbg.Splits(0).DisplayColumns(COL_MinDate).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_MaxDate).Visible = False
                tdbg.Splits(0).DisplayColumns(COL_MinSalary).Visible = True
                tdbg.Splits(0).DisplayColumns(COL_MaxSalary).Visible = True
            End If
            If Convert.ToBoolean(dt.Rows(i).Item("Progressive").ToString) = False Then
                optPartProgressive.Checked = True
            Else
                optFullProgressive.Checked = True
            End If

        Next

    End Sub
    Private Sub LoadTDBGrid(ByVal sRewardID As String)
        Dim sSQL As String = ""
        'sSQL &= "Select RewardID, DetailRewardID, MaxSalary, MinSalary,Convert(varchar(10), MaxDate,103) As MaxDate, Convert(varchar(10), MinDate,103) As  MinDate, Amount From D13T0302  WITH (NOLOCK) "
        sSQL &= "Select RewardID, DetailRewardID, MaxSalary, MinSalary, MaxDate, MinDate, Amount From D13T0302  WITH (NOLOCK) "
        sSQL &= "Where RewardID= " & SQLString(sRewardID)
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtRewardID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_tien_thuong"))
            txtRewardID.Focus()
            Return False
        End If
        If txtRewardID.Text <> "" And txtRewardID.Text.Trim.Length > 20 Then
            D99C0008.MsgL3(rl3("Do_dai_ma_tien_thuong__20_ky_tu"))
            txtRewardID.Focus()
            Return False
        End If
        If txtRewardName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_tien_thuong"))
            txtRewardName.Focus()
            Return False
        End If
        If txtRewardName.Text <> "" And txtRewardName.Text.Trim.Length > 50 Then
            D99C0008.MsgL3(rl3("Do_dai_ten_tien_thuong__50_ky_tu"))
            txtRewardID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D13T0301", "RewardID", txtRewardID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtRewardID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        If optMonthReward.Checked = True Then
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_MaxSalary).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("_Thoi_gian_(thang)U"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_MaxSalary
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If Convert.ToDouble(tdbg(i, COL_MinSalary).ToString) > Convert.ToDouble(tdbg(i, COL_MaxSalary).ToString) Then
                    D99C0008.MsgL3(rl3("_Thoi_gian_(thang)_khong_duoc_lon_hon__Thoi_gian_(thang)"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_MaxSalary
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
                If tdbg(i, COL_MaxSalary).ToString <> "" And Val(tdbg(i, COL_MaxSalary).ToString) > MaxMoney Then
                    D99C0008.MsgL3(rl3("_Muc_luong_khong_duoc_vuot_qua_") & MaxMoney)
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_MaxSalary
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If
            Next
        Else
            For i As Integer = 0 To tdbg.RowCount - 1
                If tdbg(i, COL_MaxDate).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("_Thoi_gian_(ngay)U"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Col = COL_MaxDate
                    tdbg.Bookmark = i
                    tdbg.Focus()
                    Return False
                End If

                If tdbg(i, COL_MaxDate).ToString <> "" Then
                    If CDate(tdbg(i, COL_MaxDate)) > Date.Today Then
                        D99C0008.MsgL3(rl3("_Thoi_gian_(ngay)_khong_duoc_lon_hon_ngay_hien_tai"))
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_MaxDate
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If
                If tdbg(i, COL_MinDate).ToString <> "" And tdbg(i, COL_MaxDate).ToString <> "" Then
                    If CDate(tdbg(i, COL_MinDate)) > CDate(tdbg(i, COL_MaxDate)) Then
                        D99C0008.MsgL3(rl3("_Thoi_gian_(ngay)_khong_duoc_lon_hon__Thoi_gian_(ngay)"))
                        tdbg.SplitIndex = SPLIT0
                        tdbg.Col = COL_MinDate
                        tdbg.Bookmark = i
                        tdbg.Focus()
                        Return False
                    End If
                End If
            Next
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_Amount).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Gia_tri_"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Amount
                tdbg.Bookmark = i
                tdbg.Focus()
                Dim lNewVariable As Boolean = False
                Return lNewVariable
            End If
            If tdbg(i, COL_Amount).ToString <> "" And Val(tdbg(i, COL_Amount).ToString) > MaxMoney Then
                D99C0008.MsgL3(rl3("Gia_tri_khong_duoc_vuot_qua_") & MaxMoney)
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Amount
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""
        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL &= SQLInsertD13T0301()
                sSQL &= SQLInsertD13T0302s()
            Case EnumFormState.FormEdit
                sSQL &= SQLUpdateD13T0301()
                sSQL &= SQLDeleteD13T0302()
                sSQL &= SQLInsertD13T0302s()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _rewardID = txtRewardID.Text()
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtRewardID.Text
                    Dim sDesc2 As String = txtRewardName.Text
                    Dim sDesc3 As String = IIf(optPartProgressive.Checked, "0", "1").ToString
                    Dim sDesc4 As String = IIf(optDateReward.Checked, "0", "1").ToString
                    Dim sDesc5 As String = SQLNumber(chkDisabled.Checked)
                    RunAuditLog(AuditCodeSeniorityBonuses, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnSave.Enabled = True
            btnClose.Enabled = True
        End If
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0301
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 17/01/2007 04:47:09
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0301() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D13T0301("
        sSQL &= "RewardID, RewardName, RewardNameU, Progressive, TimeReward, Disabled, "
        sSQL &= "CreateUserID, CreateDate, LastModifyUserID, LastModifyDate"
        sSQL &= ") Values ("
        sSQL &= SQLString(txtRewardID.Text) & COMMA 'RewardID, varchar[20], NULL
        sSQL &= SQLStringUnicode(txtRewardName, False) & COMMA 'RewardName, varchar[50], NULL
        sSQL &= SQLStringUnicode(txtRewardName, True) & COMMA 'RewardName, varchar[50], NULL
        If optPartProgressive.Checked Then
            sSQL &= SQLNumber("0") & COMMA 'Progressive, bit, NOT NULL
        Else
            sSQL &= SQLNumber("1") & COMMA 'Progressive, bit, NOT NULL
        End If
        If optDateReward.Checked Then
            sSQL &= SQLNumber("0") & COMMA 'TimeReward, bit, NOT NULL
        Else
            sSQL &= SQLNumber("1") & COMMA 'TimeReward, bit, NOT NULL
        End If
        sSQL &= SQLNumber(chkDisabled.Checked) & COMMA 'Disabled, bit, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NULL
        sSQL &= "GetDate()" & COMMA 'CreateDate, datetime, NULL
        sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
        sSQL &= "GetDate()" 'LastModifyDate, datetime, NULL
        sSQL &= ")"
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0301
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 18/01/2007 09:04:16
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0301() As String
        Dim sSQL As String = ""
        sSQL &= "Update D13T0301 Set "
        sSQL &= "RewardName = " & SQLStringUnicode(txtRewardName, False) & COMMA 'varchar[50], NULL
        sSQL &= "RewardNameU = " & SQLStringUnicode(txtRewardName, True) & COMMA 'varchar[50], NULL
        If optPartProgressive.Checked Then
            sSQL &= "Progressive = " & SQLNumber("0") & COMMA 'bit, NOT NULL
        Else
            sSQL &= "Progressive = " & SQLNumber("1") & COMMA 'bit, NOT NULL
        End If
        If optDateReward.Checked Then
            sSQL &= "TimeReward = " & SQLNumber("0") & COMMA 'bit, NOT NULL
        Else
            sSQL &= "TimeReward = " & SQLNumber("1") & COMMA 'bit, NOT NULL
        End If
        sSQL &= "Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA 'bit, NULL
        sSQL &= "LastModifyUserID = " & SQLString(gsUserID) & COMMA 'varchar[20], NULL
        sSQL &= "LastModifyDate = GetDate()" 'datetime, NULL
        sSQL &= " Where RewardID =" & SQLString(_rewardID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0302
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 18/01/2007 09:14:05
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0302() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0302"
        sSQL &= " Where RewardID = " & SQLString(_rewardID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0302s
    '# Created User: Trần Thị Ái Trâm
    '# Created Date: 18/01/2007 09:16:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0302s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim sDetailRewardID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DetailRewardID).ToString = "" Then
                iCountIGE += 1
            End If
        Next
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DetailRewardID).ToString = "" Then
                sDetailRewardID = CreateIGEs("D13T0302", "DetailRewardID", "13", "SR", gsStringKey, sDetailRewardID, iCountIGE)
                tdbg(i, COL_DetailRewardID) = sDetailRewardID
            End If
            sSQL = ""
            sSQL &= "Insert Into D13T0302("
            sSQL &= "DetailRewardID, RewardID, MaxSalary, MinSalary, MaxDate, "
            sSQL &= "MinDate, Amount"
            sSQL &= ") Values ("
            sSQL &= SQLString(tdbg(i, COL_DetailRewardID)) & COMMA 'DetailRewardID, varchar[20], NULL
            sSQL &= SQLString(txtRewardID.Text) & COMMA 'RewardID, varchar[20], NULL
            sSQL &= SQLMoney(tdbg(i, COL_MaxSalary)) & COMMA 'MaxSalary, money, NULL
            sSQL &= SQLMoney(tdbg(i, COL_MinSalary)) & COMMA 'MinSalary, money, NULL
            sSQL &= SQLDateSave(tdbg(i, COL_MaxDate)) & COMMA 'MaxDate, datetime, NULL
            sSQL &= SQLDateSave(tdbg(i, COL_MinDate)) & COMMA 'MinDate, datetime, NULL
            sSQL &= SQLMoney(tdbg(i, COL_Amount)) 'Amount, money, NULL
            sSQL &= ")"
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    Private Sub optDateReward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDateReward.Click
        tdbg.Splits(0).DisplayColumns(COL_MinSalary).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_MaxSalary).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_MinDate).Visible = True
        tdbg.Splits(0).DisplayColumns(COL_MaxDate).Visible = True
        tdbg_LockedColumns()
    End Sub

    Private Sub optMonthReward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optMonthReward.Click
        tdbg.Splits(0).DisplayColumns(COL_MinSalary).Visible = True
        tdbg.Splits(0).DisplayColumns(COL_MaxSalary).Visible = True
        tdbg.Splits(0).DisplayColumns(COL_MinDate).Visible = False
        tdbg.Splits(0).DisplayColumns(COL_MaxDate).Visible = False
        tdbg_LockedColumns()
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_MinSalary).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_MaxSalary).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_Amount).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub D13F1081_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.Control And (e.KeyCode = Keys.NumPad1 Or e.KeyCode = Keys.D1) Then
            optDateReward.Focus()
            Exit Sub
        ElseIf e.Control And (e.KeyCode = Keys.NumPad2 Or e.KeyCode = Keys.D2) Then
            optPartProgressive.Focus()
            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbg.Enabled = True Then
                HotKeyF11(Me, tdbg)
                Exit Sub
            End If
        End If
    End Sub

    Private Sub D13F1081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        SetBackColorObligatory()
        tdbg_NumberFormat()
        InputbyUnicode(Me, gbUnicode)
        InputDateInTrueDBGrid(tdbg, COL_MinDate, COL_MaxDate)

        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_tien_thuong_theo_tham_nien_-__D13F1081") & UnicodeCaption(gbUnicode) 'CËp nhËt tiÒn th§êng theo th¡m ni£n -  D13F1081
        '================================================================ 
        lblRewardID.Text = rl3("Ma") 'Mã 
        lblRewardName.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        optFullProgressive.Text = rl3("Luy_tien_toan_phan") 'Lũy tiến toàn phần
        optPartProgressive.Text = rl3("Luy_tien_tung_phan") 'Lũy tiến từng phần
        optMonthReward.Text = rl3("Thang_U") 'Tháng
        optDateReward.Text = rl3("Ngay") 'Ngày
        '================================================================ 
        GroupBox3.Text = "2. " & rl3("Phuong_phap") 'Phương pháp
        grp2.Text = "1. " & rl3("Thoi_gian_lam_viec") 'Thời gian làm việc
        '================================================================ 
        tdbg.Columns("RewardID").Caption = rl3("Ma_tien_thuong") 'Mã tiền thưởng
        tdbg.Columns("DetailRewardID").Caption = rl3("Ma_chi_tiet") 'Mã chi tiết
        tdbg.Columns("MinSalary").Caption = rl3("_Thoi_gian_(thang)") '> Thời gian (tháng)
        tdbg.Columns("MaxSalary").Caption = rl3("_Thoi_gian_(thang)1") '<= Thời gian (tháng)
        tdbg.Columns("MinDate").Caption = rl3("_Thoi_gian_(ngay)") '> Thời gian (ngày)
        tdbg.Columns("MaxDate").Caption = rl3("_Thoi_gian_(ngay)1")  '<= Thời gian (ngày)
        tdbg.Columns("Amount").Caption = rl3("Gia_tri_") 'Giá trị
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        If optMonthReward.Checked Then
            If tdbg.Columns(COL_MaxSalary).Text <> "" Then
                If tdbg.Bookmark = 0 Then
                    tdbg(tdbg.Bookmark, COL_MinSalary) = "0"
                Else
                    tdbg(tdbg.Bookmark, COL_MinSalary) = tdbg(tdbg.Bookmark - 1, COL_MaxSalary)
                End If
            End If
        ElseIf optDateReward.Checked Then
            If tdbg.Columns(COL_MaxDate).Text <> "" Then
                If tdbg.Bookmark = 0 Then
                    tdbg(tdbg.Bookmark, COL_MinDate) = Convert.ToDateTime("01/01/1900")
                Else
                    tdbg(tdbg.Bookmark, COL_MinDate) = tdbg(tdbg.Bookmark - 1, COL_MaxDate)
                End If
            End If
        End If
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_MinSalary
                If Not IsNumeric(tdbg.Columns(COL_MinSalary).Text) Then e.Cancel = True
            Case COL_MaxSalary
                If Not IsNumeric(tdbg.Columns(COL_MaxSalary).Text) Then e.Cancel = True
                '            Case COL_MaxDate
                '                tdbg.Columns(e.ColIndex).Text = L3DateValue(tdbg.Columns(e.ColIndex).Text)
            Case COL_Amount
                If Not IsNumeric(tdbg.Columns(COL_Amount).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.UpdateData()
        Select Case e.ColIndex
            Case COL_MaxSalary
                tdbg_CalUpdateColumn(e.ColIndex)
            Case COL_MaxDate
                tdbg.Columns(e.ColIndex).Value = tdbg.Columns(e.ColIndex).Text
                tdbg_CalUpdateColumn(e.ColIndex)
            Case COL_Amount
                tdbg_CalUpdateColumn(e.ColIndex)
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_MinSalary
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_MaxSalary
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        bFlagShiftInsert = False
        Select Case e.KeyCode
            Case Keys.F7
                If tdbg.Splits(0).DisplayColumns(tdbg.Col).Locked = False Then
                    HotKeyF7(tdbg)
                End If

            Case Keys.S
                If e.Control Then
                    If tdbg.Splits(0).DisplayColumns(tdbg.Col).Locked = False Then
                        tdbg_HeadClick(sender, Nothing)
                    End If
                End If

            Case Keys.Insert
                If e.Shift Then
                    bFlagShiftInsert = True
                    HotKeyShiftInsert(tdbg, 0, COL_MinSalary, tdbg.Columns.Count)
                End If

            Case Keys.Enter
                If tdbg.Col = COL_Amount Then
                    HotKeyEnterGrid(tdbg, COL_MaxSalary, e)
                End If

            Case Else
                HotKeyDownGrid(e, tdbg, COL_MinSalary)
        End Select

    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If bFlagShiftInsert And tdbg.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbg.Columns(COL_MinSalary).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_MinSalary, COL_MaxSalary, COL_MinDate, COL_MaxDate, COL_Amount
                CopyColumns(tdbg, e.ColIndex, tdbg.Columns(e.ColIndex).Value.ToString, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_CalUpdateColumn(ByVal iCol As Integer)
        Select Case iCol
            Case COL_MaxSalary
                If optMonthReward.Checked Then
                    If tdbg.Columns(COL_MaxSalary).Text <> "" Then
                        If tdbg.RowCount = 1 Then
                            tdbg(tdbg.Bookmark, COL_MinSalary) = "0"
                        Else
                            If tdbg.Bookmark = 0 Then
                                tdbg(tdbg.Bookmark, COL_MinSalary) = "0"
                                If tdbg.Bookmark < tdbg.RowCount - 1 Then
                                    tdbg(tdbg.Bookmark + 1, COL_MinSalary) = tdbg(tdbg.Bookmark, COL_MaxSalary)
                                End If
                            ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark < tdbg.RowCount - 1 Then
                                tdbg(tdbg.Bookmark, COL_MinSalary) = tdbg(tdbg.Bookmark - 1, COL_MaxSalary)
                                tdbg(tdbg.Bookmark + 1, COL_MinSalary) = tdbg(tdbg.Bookmark, COL_MaxSalary)
                            ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark = tdbg.RowCount - 1 Then
                                tdbg(tdbg.Bookmark, COL_MinSalary) = tdbg(tdbg.Bookmark - 1, COL_MaxSalary)
                            End If
                        End If
                    End If
                End If

            Case COL_MaxDate
                If optDateReward.Checked Then
                    If tdbg.Columns(COL_MaxDate).Text <> "" Then
                        If tdbg.RowCount = 1 Then
                            tdbg(tdbg.Bookmark, COL_MinDate) = Convert.ToDateTime("01/01/1900")
                        Else
                            If tdbg.Bookmark = 0 Then
                                tdbg(tdbg.Bookmark, COL_MinDate) = Convert.ToDateTime("01/01/1900")
                                If tdbg.Bookmark < tdbg.RowCount - 1 Then
                                    tdbg(tdbg.Bookmark + 1, COL_MinDate) = tdbg(tdbg.Bookmark, COL_MaxDate)
                                End If
                            ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark < tdbg.RowCount - 1 Then
                                tdbg(tdbg.Bookmark, COL_MinDate) = tdbg(tdbg.Bookmark - 1, COL_MaxDate)
                                tdbg(tdbg.Bookmark + 1, COL_MinDate) = tdbg(tdbg.Bookmark, COL_MaxDate)
                            ElseIf tdbg.Bookmark <> 0 And tdbg.Bookmark = tdbg.RowCount - 1 Then
                                tdbg(tdbg.Bookmark, COL_MinDate) = tdbg(tdbg.Bookmark - 1, COL_MaxDate)
                            End If
                        End If

                    End If
                End If
        End Select
    End Sub

    Private Sub SetBackColorObligatory()
        txtRewardID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtRewardName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAdd()
        btnNext.Enabled = False
        btnSave.Enabled = True
        txtRewardID.Focus()
    End Sub

    'Hai hàm này chép từ D99X0000 ra
    ''' <summary>
    ''' Copy giá trị trong 1 cột (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="sValue">Giá trị cần copy</param>
    ''' <param name="RowCopy">Dòng đang copy</param>
    ''' <remarks>Chỉ dùng copy những cột dữ liệu không liên quan đến các cột khác, copy cả giá trị ''</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            If c1Grid.RowCount < 2 Then Exit Sub

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                c1Grid.UpdateData()
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    c1Grid(i, ColCopy) = sValue
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    ''' <summary>
    ''' Copy giá trị trong 1 cột có liên quan đến các cột kế nó (khi nhấn Head_Click)
    ''' </summary>
    ''' <param name="c1Grid">Lưới C1</param>
    ''' <param name="ColCopy">Cột cần copy</param>
    ''' <param name="RowCopy">Dòng cần copy</param>
    ''' <param name="ColumnCount">Số cột liên quan khi cần copy</param>
    ''' <remarks>Chỉ copy những cột ở vị trí liên tục nhau</remarks>

    Private Sub CopyColumns(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal RowCopy As Integer, ByVal ColumnCount As Integer, ByVal sValue As String)
        Dim i, j As Integer
        Try
            If c1Grid.RowCount < 2 Then Exit Sub

            If ColumnCount = 1 Then ' Copy trong 1 cot
                CopyColumns(c1Grid, ColCopy, sValue, RowCopy)
            ElseIf ColumnCount > 1 Then ' Copy nhieu cot lien quan
                Dim Flag As DialogResult
                'Flag = D99C0008.MsgCopyColumn()
                Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse Val(c1Grid(i, ColCopy).ToString) = 0 Then
                            c1Grid(i, ColCopy) = sValue
                            While j < ColumnCount
                                c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                                j += 1
                            End While
                        End If
                    Next
                ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy hết
                    c1Grid.UpdateData()
                    For i = RowCopy + 1 To c1Grid.RowCount - 1
                        j = 1
                        c1Grid(i, ColCopy) = sValue
                        While j < ColumnCount
                            c1Grid(i, ColCopy + j) = c1Grid(RowCopy, ColCopy + j)
                            j += 1
                        End While
                    Next
                    'c1Grid(0, ColCopy) = sValue
                Else
                    Exit Sub
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    'Khi nào chuẩn hóa theo người dùng đơn vị xong thì trở về hàm dùng chung
End Class