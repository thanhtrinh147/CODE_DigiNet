'Imports System
Public Class D25F1081
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property



#Region "Const of tdbg"
    Private Const COL_TransTypeID As Integer = 0      ' Loại nghiệp vụ
    Private Const COL_OrderNo As Integer = 1          ' Số thứ tự
    Private Const COL_GroupDataName As Integer = 2    ' Nhóm dữ liệu
    Private Const COL_CaptionName As Integer = 3      ' Nội dung
    Private Const COL_FieldType As Integer = 4        ' Loại
    Private Const COL_CreateUserID As Integer = 5     ' CreateUserID
    Private Const COL_CreateDate As Integer = 6       ' CreateDate
    Private Const COL_LastModifyUserID As Integer = 7 ' LastModifyUserID
    Private Const COL_LastModifyDate As Integer = 8   ' LastModifyDate
    Private Const COL_GroupDataID As Integer = 9      ' GroupDataID
    Private Const COL_FieldName As Integer = 10       ' FieldName
    Private Const COL_FieldNameU As Integer = 11      ' FieldNameU
    Private Const COL_SaveType As Integer = 12        ' SaveType
    Private Const COL_Tab As Integer = 13             ' Thuộc Tab
    Private Const COL_Locked As Integer = 14          ' Locked
#End Region


#Region "Properties"
    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            LoadTDBDropDown()
            LoadTDBGrid()
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnNext.Enabled = False

                Case EnumFormState.FormEdit
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = True
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadMaster()
                    btnNext.Visible = False
                    btnSave.Left = btnNext.Left
                    btnSave.Enabled = False
                    btnClose.Focus()
            End Select
        End Set
    End Property

    Private _transTypeID As String = ""
    Public Property TransTypeID() As String
        Get
            Return _transTypeID
        End Get
        Set(ByVal Value As String)
            _transTypeID = Value
        End Set
    End Property

    Private _transTypeName As String
    Public Property transTypeName() As String
        Get
            Return _transTypeName
        End Get
        Set(ByVal Value As String)
            _transTypeName = Value
        End Set
    End Property
#End Region

    ' Update 23/05/2011 - Chuẩn unicode theo DC25 _ TIENDAU
    Dim dtData, dtCaption As DataTable

    Private Sub D25F1081_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D25F1081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Me.Cursor = Cursors.Cross
        SetBackColorObligatory()
        tdbg_LockedColumns()

        Loadlanguage()
        '*****
        InputbyUnicode(Me, gbUnicode)
        'UnicodeGridDataField(tdbg, UnicodeArrayCOL(), gbUnicode) 'sửa dataField và hằng của 1 cột
        'Update 27/07/2010: Kiểm tra nhập Mã
        CheckIdTextBox(txtTransTypeID)
        '***************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg.Splits(SPLIT0).DisplayColumns(COL_OrderNo).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_FieldType).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT0).DisplayColumns(COL_Tab).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_ho_so_ung_cu_vien_-_D25F1081") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa hä s¥ ÷ng cõ vi£n - D25F1081
        '================================================================ 
        lblTransTypeID.Text = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnNext.Text = rl3("_Nhap_tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        '================================================================ 
        tdbdCaptionName.Columns("FieldName").Caption = rl3("Ma") 'Mã
        tdbdCaptionName.Columns("CaptionName").Caption = rl3("Ten") 'Tên
        tdbdGroupDataID.Columns("GroupDataID").Caption = rl3("Ma") 'Mã
        tdbdGroupDataID.Columns("GroupDataName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("TransTypeID").Caption = rl3("Loai_nghiep_vu") 'Loại nghiệp vụ
        tdbg.Columns("OrderNo").Caption = rl3("So_thu_tu") 'Số thứ tự
        tdbg.Columns("GroupDataName").Caption = rl3("Nhom_du_lieu") 'Nhóm dữ liệu
        tdbg.Columns("CaptionName").Caption = rl3("Noi_dung") 'Nội dung
        tdbg.Columns("FieldType").Caption = rl3("Loai") 'Loại
        tdbg.Columns("Tab").Caption = rl3("Thuoc_Tab") 'Thuộc Tab
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""

        'Load tdbdCaptionName
        '        sSQL = " Select FieldType , FieldName" & UnicodeJoin(gbUnicode) & " as  FieldName , SaveType, GroupDataID, "
        '        sSQL &= " CaptionName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString & UnicodeJoin(gbUnicode) & " As CaptionName " & vbCrLf
        '        sSQL &= " From D25T0320" & vbCrLf
        '        sSQL &= " Order By OrderNo" & vbCrLf
        ' IncidentID	50853
        sSQL = "--Do nguon combo Noi dung" & vbCrLf
        sSQL &= " Select FieldType , FieldName, FieldNameU , SaveType, GroupDataID, "
        sSQL &= " CaptionName84" & UnicodeJoin(gbUnicode) & " As CaptionName " & vbCrLf
        sSQL &= " From D25T0320 WITH(NOLOCK) " & vbCrLf
        sSQL &= " Order By OrderNo" & vbCrLf
        dtCaption = ReturnDataTable(sSQL)

        'Load tdbdGroupDataID
        sSQL = " Select GroupDataID, Tab, "
        sSQL &= " GroupDataName" & IIf(geLanguage = EnumLanguage.Vietnamese, "84", "01").ToString & UnicodeJoin(gbUnicode) & " As GroupDataName " & vbCrLf
        sSQL &= " From D25T0310 WITH(NOLOCK)  Order by GroupDataID"
        LoadDataSource(tdbdGroupDataID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbdCaptionName(ByVal ID As String)
        LoadDataSource(tdbdCaptionName, ReturnTableFilter(dtCaption, "GroupDataID = " & SQLString(ID)), gbUnicode)
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL &= " SELECT TransTypeID,CreateUserID,CreateDate,LastModifyUserID,LastModifyDate" & vbCrLf
        sSQL &= " ,Disabled,TransTypeName" & UnicodeJoin(gbUnicode) & " as TransTypeName" & vbCrLf
        sSQL &= " FROM D25T1080  WITH(NOLOCK)  Where TransTypeID = " & SQLString(_transTypeID)
        dtData = ReturnDataTable(sSQL)
        If dtData.Rows.Count = 0 Then Exit Sub

        txtTransTypeID.Text = dtData.Rows(0).Item("TransTypeID").ToString
        txtTransTypeName.Text = dtData.Rows(0).Item("TransTypeName").ToString
        chkDisabled.Checked = Convert.ToBoolean(dtData.Rows(0).Item("Disabled"))
    End Sub

    Private Sub LoadEdit()
        LoadMaster()
        ReadOnlyControl(txtTransTypeID)
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        ' IncidentID	50853
        Dim sSQL As String = SQLStoreD25P1081()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
    End Sub
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD25P1081
    '# Created User: Phan Văn Thông
    '# Created Date: 05/09/2012 01:39:10
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD25P1081() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho form D25F1081" & vbCrlf)
        sSQL &= "Exec D25P1081 "
        sSQL &= SQLString(_transTypeID) & COMMA 'TransTypeID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub tdbg_FetchRowStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchRowStyleEventArgs) Handles tdbg.FetchRowStyle
        If L3Bool(tdbg(e.Row, COL_Locked)) Then e.CellStyle.Locked = True : e.CellStyle.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_OnAddNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.OnAddNew
        tdbg.Columns(COL_OrderNo).Text = (tdbg.Bookmark + 1).ToString
    End Sub

    Private Sub SetBackColorObligatory()
        txtTransTypeID.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

#Region "TDBG Events"

    Private Sub tdbg_BeforeInsert(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.CancelEventArgs) Handles tdbg.BeforeInsert
        If tdbg.RowCount >= 30 Then
            'D99C0008.MsgL3(rl3("Luoi_khong_duoc_nhap_qua_30_dong"))
            e.Cancel = True
            tdbg.AllowAddNew = False
        Else
            tdbg.AllowAddNew = True
        End If
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_GroupDataName
                tdbg.Columns(COL_GroupDataName).Text = tdbdGroupDataID.Columns("GroupDataName").Text
                tdbg.Columns(COL_GroupDataID).Text = tdbdGroupDataID.Columns("GroupDataID").Text
                tdbg.Columns(COL_CaptionName).Text = ""
                tdbg.Columns(COL_FieldName).Text = ""
                tdbg.Columns(COL_FieldNameU).Text = ""
                tdbg.Columns(COL_FieldType).Text = ""
                tdbg.Columns(COL_SaveType).Text = ""
                tdbg.Columns(COL_Tab).Text = tdbdGroupDataID.Columns("Tab").Text
                tdbg.Col = COL_CaptionName

            Case COL_CaptionName
                tdbg.Columns(COL_CaptionName).Text = tdbdCaptionName.Columns("CaptionName").Text
                tdbg.Columns(COL_FieldName).Text = tdbdCaptionName.Columns("FieldName").Text
                tdbg.Columns(COL_FieldNameU).Text = tdbdCaptionName.Columns("FieldNameU").Text
                tdbg.Columns(COL_FieldType).Text = tdbdCaptionName.Columns("FieldType").Text
                tdbg.Columns(COL_SaveType).Text = tdbdCaptionName.Columns("SaveType").Text
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_GroupDataName
                If tdbg.Columns(COL_GroupDataName).Text <> tdbdGroupDataID.Columns("GroupDataName").Text Then
                    tdbg.Columns(COL_GroupDataName).Text = ""
                    tdbg.Columns(COL_GroupDataID).Text = ""
                    tdbg.Columns(COL_FieldName).Text = ""
                    tdbg.Columns(COL_FieldNameU).Text = ""
                    tdbg.Columns(COL_CaptionName).Text = ""
                    tdbg.Columns(COL_FieldType).Text = ""
                    tdbg.Columns(COL_Tab).Text = ""
                End If
            Case COL_CaptionName
                If tdbg.Columns(COL_CaptionName).Text <> tdbdCaptionName.Columns("CaptionName").Text Then
                    tdbg.Columns(COL_FieldName).Text = ""
                    tdbg.Columns(COL_FieldNameU).Text = ""
                    tdbg.Columns(COL_CaptionName).Text = ""
                    tdbg.Columns(COL_FieldType).Text = ""
                    tdbg.Columns(COL_SaveType).Text = ""
                End If
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        Select Case e.KeyCode
            Case Keys.F7
                If tdbg.Col = COL_GroupDataName Then
                    Dim ColCopy() As Integer = {COL_GroupDataID, COL_Tab}
                    If F7More(tdbg, ColCopy) Then
                        tdbg.Columns(COL_CaptionName).Text = ""
                        tdbg.Columns(COL_FieldName).Text = ""
                        tdbg.Columns(COL_FieldNameU).Text = ""
                        tdbg.Columns(COL_FieldType).Text = ""
                        tdbg.Columns(COL_SaveType).Text = ""
                    End If
                End If
            Case Keys.Enter
                If tdbg.Col = COL_CaptionName Then
                    If tdbg.Columns(COL_CaptionName).Text <> tdbdCaptionName.Columns("CaptionName").Text Then
                        tdbg.Columns(COL_FieldName).Text = ""
                        tdbg.Columns(COL_FieldNameU).Text = ""
                        tdbg.Columns(COL_CaptionName).Text = ""
                        tdbg.Columns(COL_FieldType).Text = ""
                        tdbg.Columns(COL_SaveType).Text = ""
                    ElseIf tdbg.Item(tdbg.Row, COL_GroupDataName).ToString() <> "" Then
                        tdbg.Columns(COL_CaptionName).Text = tdbdCaptionName.Columns("CaptionName").Text
                        tdbg.Columns(COL_FieldName).Text = tdbdCaptionName.Columns("FieldName").Text
                        tdbg.Columns(COL_FieldNameU).Text = tdbdCaptionName.Columns("FieldNameU").Text
                        tdbg.Columns(COL_FieldType).Text = tdbdCaptionName.Columns("FieldType").Text
                        tdbg.Columns(COL_SaveType).Text = tdbdCaptionName.Columns("SaveType").Text
                        HotKeyEnterGrid(tdbg, COL_GroupDataName, e)
                    End If
                End If

            Case Else
                HotKeyDownGrid(e, tdbg, COL_OrderNo)
                If e.Control And e.KeyCode = Keys.Delete Then
                    UpdateTDBGOrderNum(tdbg, COL_OrderNo, COL_GroupDataName)
                End If
        End Select
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        If tdbg.Col = COL_CaptionName Then
            LoadtdbdCaptionName(tdbg.Columns(COL_GroupDataID).Text)
        End If
    End Sub

    Private Sub tdbg_AfterDelete(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterDelete
        UpdateTDBGOrderNum(tdbg, COL_OrderNo)
    End Sub

    Private Sub tdbg_AfterInsert(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.AfterInsert
        UpdateTDBGOrderNum(tdbg, COL_OrderNo)
    End Sub
#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbg.UpdateData()
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.AppendLine(SQLInsertD25T1080.ToString)
                sSQL.Append(SQLInsertD25T1081s.ToString)

            Case EnumFormState.FormEdit
                sSQL.AppendLine(SQLUpdateD25T1080.ToString)
                sSQL.AppendLine(SQLDeleteD25T1081())
                sSQL.Append(SQLInsertD25T1081s)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _transTypeID = txtTransTypeID.Text
                    btnSave.Enabled = False
                    btnNext.Enabled = True
                    btnNext.Focus()

                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        btnSave.Enabled = True
        btnNext.Enabled = False

        txtTransTypeID.Text = ""
        txtTransTypeName.Text = ""
        If Not D25Options.SaveLastRecent Then
            If dtGrid IsNot Nothing Then dtGrid.Clear() 'tdbg.Delete(0, tdbg.RowCount)
            chkDisabled.Checked = False
        End If

        txtTransTypeID.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Function AllowSave() As Boolean
        If txtTransTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Loai_nghiep_vu"))
            txtTransTypeID.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            If IsExistKey("D25T1080", "TransTypeID", txtTransTypeID.Text) Then
                D99C0008.MsgDuplicatePKey()
                txtTransTypeID.Focus()
                Return False
            End If
        End If
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        If tdbg.RowCount > 30 Then
            D99C0008.MsgL3(rl3("Luoi_khong_duoc_nhap_qua_30_dong"))
            tdbg.Focus()
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_GroupDataID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Nhom_du_lieu"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_GroupDataName
                tdbg.Bookmark = i

                Return False
            End If
            If tdbg(i, COL_FieldName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Noi_dung"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_CaptionName
                tdbg.Bookmark = i
                Return False
            End If
            If tdbg(i, COL_FieldNameU).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Noi_dung"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Focus()
                tdbg.Col = COL_CaptionName
                tdbg.Bookmark = i
                Return False
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            For j As Integer = i + 1 To tdbg.RowCount - 1
                'If tdbg(i, COL_GroupDataID).ToString = tdbg(j, COL_GroupDataID).ToString And tdbg(i, COL_FieldName).ToString = tdbg(j, COL_FieldName).ToString Then
                If tdbg(i, COL_FieldName).ToString = tdbg(j, COL_FieldName).ToString Then
                    D99C0008.MsgL3(rl3("Du_lieu_nay_da_duoc_nhap"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Focus()
                    tdbg.Col = COL_CaptionName
                    tdbg.Bookmark = j
                    Return False
                End If
                If tdbg(i, COL_FieldNameU).ToString = tdbg(j, COL_FieldNameU).ToString Then
                    D99C0008.MsgL3(rl3("Du_lieu_nay_da_duoc_nhap"))
                    tdbg.SplitIndex = SPLIT0
                    tdbg.Focus()
                    tdbg.Col = COL_CaptionName
                    tdbg.Bookmark = j
                    Return False
                End If
            Next j
        Next i
        Return True
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T1160
    '# Created User: Vũ Quang Thắng
    '# Created Date: 18/05/2009 10:38:01
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1080() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D25T1080(")
        sSQL.Append("TransTypeID, TransTypeName, TransTypeNameU, Disabled, CreateUserID, CreateDate, ")
        sSQL.Append("LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName.Text, gbUnicode, False) & COMMA) 'TransTypeName, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtTransTypeName.Text, gbUnicode, True) & COMMA) 'TransTypeNameU, varchar[250], NOT NULL
        sSQL.Append(SQLNumber(chkDisabled.Checked) & COMMA) 'Disabled, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")")

        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T1161s
    '# Created User: Vũ Quang Thắng
    '# Created Date: 18/05/2009 10:38:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T1081s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D25T1081(")
            sSQL.Append("TransTypeID, OrderNo, GroupDataID, FieldName, FieldNameU,  Tab, CreateUserID, ")
            sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(txtTransTypeID.Text) & COMMA) 'TransTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_OrderNo)) & COMMA) 'OrderNo, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_GroupDataID)) & COMMA) 'GroupDataID, varchar[20], NOT NULL
            'Không convert khi lưu, đặc thù của D25T1081
            'Trân gởi mail sửa lại
            ' IncidentID	50853
            sSQL.Append(SQLString(tdbg(i, COL_FieldName)) & COMMA) 'FieldName, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_FieldNameU)) & COMMA) 'FieldNameU, varchar[50], NOT NULL
            '***********
            'sSQL.Append(SQLString(tdbg(i, COL_SaveType)) & COMMA) 'SaveType, TinyInt, NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Tab)) & COMMA)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T1161
    '# Created User: Vũ Quang Thắng
    '# Created Date: 18/05/2009 11:26:56
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T1081() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T1081"
        sSQL &= " Where TransTypeID = " & SQLString(_transTypeID)
        Return sSQL
    End Function
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD09T1160
    '# Created User: Vũ Quang Thắng
    '# Created Date: 19/05/2009 10:41:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD25T1080() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D25T1080 Set ")
        sSQL.Append("TransTypeName = " & SQLStringUnicode(txtTransTypeName.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("TransTypeNameU = " & SQLStringUnicode(txtTransTypeName.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("Disabled = " & SQLNumber(chkDisabled.Checked) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("TransTypeID = " & SQLString(_transTypeID))

        Return sSQL
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
End Class