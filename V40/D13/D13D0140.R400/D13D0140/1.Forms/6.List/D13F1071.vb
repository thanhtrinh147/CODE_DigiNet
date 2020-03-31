Imports System
Public Class D13F1071
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbgDetail"
    Private Const COLS_Code As Integer = 0        ' Mã
    Private Const COLS_Type As Integer = 1        ' Mã loại
    Private Const COLS_Description As Integer = 2 ' Diễn giải
    Private Const COLS_Value As Integer = 3       ' Giá trị
    Private Const COLS_Detail As Integer = 4      ' Chi tiết NV
#End Region

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Private _ClassificationID As String = ""
    Private DT As DataTable
    Dim iLastCol As Integer
    Dim iDeatail As Boolean
    Dim sCreateDate As String = ""
    Dim sCreateUserID As String = ""

    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                    iDeatail = False
                    LoadAddNew()
                    btnNext.Enabled = False
                Case EnumFormState.FormEdit
                    iDeatail = True
                    LoadEdit()
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                Case EnumFormState.FormView
                    iDeatail = True
                    LoadEdit()
                    btnSave.Left = btnNext.Left
                    btnNext.Visible = False
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Public Property ClassificationID() As String
        Get
            Return _ClassificationID
        End Get
        Set(ByVal value As String)
            _ClassificationID = value
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        txtClassificationID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtClassificationName.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbgDetail_NumberFormat()
        tdbgDetail.Columns(COLS_Value).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub LoadEdit()
        txtClassificationID.Enabled = False
        chkDisabled.Visible = True

        Dim s As String = ""
        s = "Select Code, ClassificationID,ClassificationName, ClassificationNameU , Type,Description, DescriptionU, Value, Disabled, Mode,"
        s &= " '' as Detail, CreateDate, CreateUserID" & vbCrLf
        s &= "From D13T0120  WITH (NOLOCK) Where ClassificationID = " & SQLString(_ClassificationID)
        DT = ReturnDataTable(s)
        If DT.Rows.Count <> 0 Then
            sCreateDate = SQLDateTimeSave(DT.Rows(0)("CreateDate").ToString)
            sCreateUserID = DT.Rows(0)("CreateUserID").ToString
            txtClassificationID.Text = DT.Rows(0)("ClassificationID").ToString
            txtClassificationName.Text = DT.Rows(0)("ClassificationName" & UnicodeJoin(gbUnicode)).ToString
            chkDisabled.Checked = Convert.ToBoolean(DT.Rows(0)("Disabled"))
            chkDetail.Checked = Convert.ToBoolean(DT.Rows(0)("Mode"))
        End If
        LoadDataSource(tdbgDetail, DT, gbUnicode)
        tdbgDetail_NumberFormat()
        txtClassificationName.Focus()

        For i As Integer = 0 To tdbgDetail.RowCount - 1
            tdbgDetail(i, COLS_Detail) = "..."
        Next
    End Sub

    Private Sub LoadAddNew()
        txtClassificationID.Focus()
        txtClassificationID.Text = ""
        txtClassificationName.Text = ""
        chkDisabled.Visible = False

        Dim s As String = ""
        s = "select Code,ClassificationID,ClassificationName, Type, Description, DescriptionU, Value,Disabled,Mode,'' as Detail  " & vbCrLf
        s &= "from D13T0120  WITH (NOLOCK) where ClassificationID = " & SQLString(txtClassificationID.Text)
        DT = ReturnDataTable(s)
        LoadDataSource(tdbgDetail, DT, gbUnicode)
        tdbgDetail_NumberFormat()
        tdbgDetail.Columns(COLS_Detail).Text = "..."
    End Sub

    Private Function AllowSave() As Boolean
        If txtClassificationID.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ma_DGXL"))
            txtClassificationID.Focus()
            Return False
        End If
        If txtClassificationName.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ten_DGXL"))
            txtClassificationName.Focus()
            Return False
        End If
        If _FormState = EnumFormState.FormAdd Then
            Dim s As String = ""
            s = "select TOP 1 1 from D13T0120  WITH (NOLOCK) where ClassificationID = " & SQLString(txtClassificationID.Text)
            If ExistRecord(s) Then
                D99C0008.MsgDuplicatePKey()
                txtClassificationID.Focus()
                Return False
            End If
        End If
        If tdbgDetail.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgDetail.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COLS_Type).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma_loai"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COLS_Type
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If
            If Len(Trim(tdbgDetail(i, COLS_Type).ToString)) > 20 Then
                D99C0008.MsgL3(rl3("Chieu_dai_Ma_loai_khong_duoc_lon_hon_20"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COLS_Type
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If

            If tdbgDetail(i, COLS_Description).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COLS_Description
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If
            If Len(Trim(tdbgDetail(i, COLS_Description).ToString)) > 250 Then
                D99C0008.MsgL3(rl3("Chieu_dai_Dien_giai_khong_duoc_lon_hon_250"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COLS_Description
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If

            If tdbgDetail(i, COLS_Value).ToString <> "" Then
                If Number(tdbgDetail(i, COLS_Value).ToString) > MaxMoney Then
                    D99C0008.MsgL3(rl3("Gia_tri_khong_duoc_lon_hon_") & MaxMoney)
                    tdbgDetail.SplitIndex = SPLIT0
                    tdbgDetail.Col = COLS_Value
                    tdbgDetail.Bookmark = i
                    tdbgDetail.Focus()
                    Return False
                End If
            End If
        Next
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
  
    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0120s
    '# Created User: Lý Anh Vĩ
    '# Created Date: 12/01/2007 09:30:44
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0120s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            sSQL = ""
            sSQL &= "Delete From D13T0120"
            sSQL &= " Where ClassificationID = " & SQLString(_ClassificationID)
            sRet &= sSQL & vbCrLf
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1071
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/10/2007 10:08:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1071() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1071"
        sSQL &= " Where ClassificationID = " & SQLString(_ClassificationID) & vbCrLf
        If chkDetail.Checked Then
            sSQL &= "And Type Not In" & vbCrLf
            sSQL &= "(Select Type From D13T0120  WITH (NOLOCK) Where ClassificationID = " & SQLString(_ClassificationID) & ")"
        End If
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0120s
    '# Created User: Lý Anh Vĩ
    '# Created Date: 12/01/2007 09:32:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0120s() As String

        Dim sSQL As String = ""
        Dim sCode As String = ""
        Dim sCount As Integer = 0

        If _FormState = EnumFormState.FormAdd Then
            sCreateUserID = gsUserID
            sCreateDate = "GetDate()"
        End If

        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COLS_Code).ToString = "" Then sCount += 1
        Next
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COLS_Code).ToString = "" Then
                sCode = CreateIGEs("D13T0120", "Code", "13", "CE", gsStringKey, sCode, sCount)
                tdbgDetail(i, COLS_Code) = sCode
            End If
            sSQL &= "Insert Into D13T0120("
            sSQL &= "Code, ClassificationID, ClassificationName, ClassificationNameU, Type, Description, DescriptionU, "
            sSQL &= "Value, Disabled, CreateUserID, CreateDate, LastModifyUserID, "
            sSQL &= "LastModifyDate, Mode"
            sSQL &= ") Values ("
            sSQL &= SQLString(tdbgDetail(i, COLS_Code)) & COMMA 'Code, varchar[20], NULL
            sSQL &= SQLString(txtClassificationID.Text) & COMMA 'ClassificationID, varchar[20], NULL
            sSQL &= SQLStringUnicode(txtClassificationName, False) & COMMA 'ClassificationName, varchar[250], NULL
            sSQL &= SQLStringUnicode(txtClassificationName, True) & COMMA 'ClassificationName, varchar[250], NULL
            sSQL &= SQLString(tdbgDetail(i, COLS_Type)) & COMMA 'Type, varchar[20], NULL
            sSQL &= SQLStringUnicode(tdbgDetail(i, COLS_Description).ToString, gbUnicode, False) & COMMA 'Description, varchar[250], NULL
            sSQL &= SQLStringUnicode(tdbgDetail(i, COLS_Description).ToString, gbUnicode, True) & COMMA 'Description, varchar[250], NULL
            If tdbgDetail(i, COLS_Value).ToString = "" Then
                sSQL &= SQLMoney(0) & COMMA 'Value, money, NULL
            Else
                sSQL &= SQLMoney(tdbgDetail(i, COLS_Value)) & COMMA 'Value, money, NULL
            End If
            sSQL &= SQLNumber(IIf(chkDisabled.Checked = True, 1, 0)) & COMMA 'Disabled, tinyint, NULL
            sSQL &= SQLString(sCreateUserID) & COMMA 'CreateUserID, varchar[20], NULL
            sSQL &= sCreateDate & COMMA 'CreateDate, datetime, NULL
            sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NULL
            sSQL &= "GetDate()" & COMMA 'LastModifyDate, datetime, NULL
            sSQL &= SQLNumber(IIf(chkDetail.Checked = True, 1, 0))  'Disabled, tinyint, NULL
            sSQL &= ")" & vbCrLf
        Next
        Return sSQL
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
                sSQL = SQLInsertD13T0120s()
            Case EnumFormState.FormEdit
                sSQL = SQLDeleteD13T0120s() & vbCrLf
                sSQL &= SQLInsertD13T0120s() & vbCrLf
                sSQL &= SQLDeleteD13T1071()
        End Select
        Me.Cursor = Cursors.WaitCursor
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    _ClassificationID = txtClassificationID.Text
                    btnNext.Enabled = True
                    btnClose.Enabled = True
                    btnNext.Focus()
                    iDeatail = True
                Case EnumFormState.FormEdit
                    'Audit Log
                    Dim sDesc1 As String = txtClassificationID.Text
                    Dim sDesc2 As String = txtClassificationName.Text
                    Dim sDesc3 As String = SQLNumber(chkDisabled.Checked)
                    Dim sDesc4 As String = ""
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodeEvaluationTypes, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

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

    Private Sub tdbgDetail_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.AfterColUpdate
        Select Case tdbgDetail.Col
            Case COLS_Type
                Dim k As Integer = tdbgDetail.Row
                For i As Integer = 0 To tdbgDetail.RowCount - 1
                    If i <> k And tdbgDetail(i, COLS_Type).ToString = tdbgDetail.Columns(COLS_Type).Text Then
                        D99C0008.MsgL3(rL3("Khong_duoc_trung_ma_loai"))
                        tdbgDetail.Columns(COLS_Type).Text = ""
                        Exit For
                    End If
                Next
                tdbgDetail.Columns(COLS_Detail).Text = "..."
            Case COLS_Description, COLS_Value
                If tdbgDetail.Columns(COLS_Detail).Text <> "" Then tdbgDetail.Columns(COLS_Detail).Text = "..."
        End Select
    End Sub

    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COLS_Value
                If Not L3IsNumeric(tdbgDetail.Columns(COLS_Value).Text, EnumDataType.Number) Then e.Cancel = True
            Case COLS_Type
                e.Cancel = L3IsID(tdbgDetail, e.ColIndex)
        End Select
    End Sub


    Private Sub tdbgDetail_ButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.ButtonClick
        Select Case tdbgDetail.Col
            Case COLS_Detail
                If _FormState = EnumFormState.FormAdd And iDeatail = False Then Exit Sub
                If tdbgDetail.Row = tdbgDetail.RowCount Then Exit Sub
                If tdbgDetail.Columns(COLS_Type).Text = "" And tdbgDetail.Columns(COLS_Description).Text = "" And tdbgDetail.Columns(COLS_Value).Text = "" Then Exit Sub
                Dim f As New D13F1072
                f.ClassificationID = _ClassificationID
                f.Type = tdbgDetail.Columns(COLS_Type).Text
                f.Description = tdbgDetail.Columns(COLS_Description).Text
                f.ShowDialog()
                f.Dispose()
        End Select

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

    Private Sub tdbgDetail_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbgDetail.HeadClick
        Select Case e.ColIndex
            Case COLS_Description
                CopyColumns(tdbgDetail, e.ColIndex, tdbgDetail.Columns(e.ColIndex).Value.ToString, tdbgDetail.Row)
        End Select

    End Sub

    Private Sub tdbgDetail_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbgDetail.KeyDown
        If e.KeyCode = Keys.F7 Then
            HotKeyF7(tdbgDetail)
            Exit Sub
        ElseIf e.KeyCode = Keys.F8 Then
            HotKeyF8(tdbgDetail)
            Exit Sub
        ElseIf e.Control And e.KeyCode = Keys.S Then
            tdbgDetail_HeadClick(sender, Nothing)
            Exit Sub
        ElseIf e.KeyCode = Keys.Enter Then
            If tdbgDetail.Col = iLastCol Then HotKeyEnterGrid(tdbgDetail, COLS_Code, e)
            Exit Sub
        ElseIf e.Shift And (e.KeyCode = Keys.Insert) Then
            HotKeyShiftInsert(tdbgDetail, 0, COLS_Code, tdbgDetail.Columns.Count)
            Exit Sub

        End If

        HotKeyDownGrid(e, tdbgDetail, COLS_Code, 0, 0)
       
    End Sub

    Private Sub tdbgDetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        Select Case tdbgDetail.Col
            Case COLS_Value
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COLS_Type
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa
        End Select
    End Sub

    Private Sub D13F1071_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
            Exit Sub
        ElseIf e.KeyCode = Keys.F11 Then
            If tdbgDetail.Enabled = True Then
                HotKeyF11(Me, tdbgDetail)
            End If
        End If
    End Sub

    Private Sub D13F1071_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        UnicodeGridDataField(tdbgDetail, COLS_Description, gbUnicode)
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBoxG4(txtClassificationID)
        SetBackColorObligatory()
        If _FormState = EnumFormState.FormAdd Then
            chkDetail.Checked = False
        End If
        chkDetail_CheckedChanged(sender, Nothing)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_danh_gia_xep_loai_-_D13F1071") & UnicodeCaption(gbUnicode) 'CËp nhËt ¢Ành giÀ xÕp loÁi - D13F1071
        '================================================================ 
        lblClassificationID.Text = rl3("Ma") 'Mã
        lblClassificationName.Text = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnNext.Text = rl3("Nhap__tiep") 'Nhập &tiếp
        '================================================================ 
        chkDisabled.Text = rl3("Khong_su_dung") 'Không sử dụng
        chkDetail.Text = rl3("Chi_tiet_theo_nhan_vien") 'Chi tiết theo nhân viên
        '================================================================ 
        tdbgDetail.Columns("Code").Caption = rl3("Ma") 'Mã
        tdbgDetail.Columns("Type").Caption = rl3("Ma") 'Mã 
        tdbgDetail.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgDetail.Columns("Value").Caption = rl3("Gia_tri_") 'Giá trị
        tdbgDetail.Columns("Detail").Caption = rl3("Chi_tiet_NV") 'Chi tiết NV
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadAddNew()
        btnNext.Enabled = False
        btnSave.Enabled = True
    End Sub

    Private Sub tdbgDetail_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbgDetail.RowColChange
        If tdbgDetail.AddNewMode = C1.Win.C1TrueDBGrid.AddNewModeEnum.AddNewCurrent Then
            tdbgDetail.Columns(COLS_Type).Text = "" ' Gán 1 cột bất kỳ ="" cho lưới
        End If
    End Sub

    Private Sub chkDetail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetail.CheckedChanged
        If chkDetail.Checked Then
            tdbgDetail.Splits(0).DisplayColumns(COLS_Value).Visible = False 'an cot gtri
            tdbgDetail.Splits(0).DisplayColumns(COLS_Detail).Visible = True 'hien cot chi tiet NV
            tdbgDetail.Splits(0).DisplayColumns(COLS_Description).Width = 290
            tdbgDetail.Splits(0).DisplayColumns(COLS_Detail).Width = 80
        Else
            tdbgDetail.Splits(0).DisplayColumns(COLS_Value).Visible = True 'hien cot gtri
            tdbgDetail.Splits(0).DisplayColumns(COLS_Detail).Visible = False 'an cot chi tiet NV
            tdbgDetail.Splits(0).DisplayColumns(COLS_Description).Width = 250
            tdbgDetail.Splits(0).DisplayColumns(COLS_Value).Width = 120
        End If
    End Sub
End Class