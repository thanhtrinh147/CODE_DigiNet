Imports System
Public Class D13F2031
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbg"
    Private Const COL_IsUsed As Integer = 0             ' Chọn
    Private Const COL_DepartmentID As Integer = 1       ' Phòng ban
    Private Const COL_TeamID As Integer = 2             ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 3         ' Mã NV
    Private Const COL_EmployeeName As Integer = 4       ' Họ và tên
    Private Const COL_TransferAbsentType As Integer = 5 ' Loại công
    Private Const COL_TATValue As Integer = 6           ' Giá trị
    Private Const COL_TransferValue As Integer = 7      ' Giá trị chuyển
    Private Const COL_LeaveTypeID As Integer = 8        ' Loại phép
    Private Const COL_LeaveCoefficient As Integer = 9   ' Hệ số
    Private Const COL_AddLeaveQuantity As Integer = 10  ' Phép cộng thêm
    Private Const COL_RemainValue As Integer = 11       ' Giá trị còn lại
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

    Dim dtTeamID As DataTable
    Dim sTransTypeID As String = ""

    'Private Sub D13F2031_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    D99C0007.SaveOthersSetting(EXEMODULE, EXECHILD, "SavedOK", IIf(_bSaved, "1", "0").ToString)
    'End Sub

    Private Sub D13F2031_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        LoadMaster()
        LoadTDBCombo()
        LoadTDBDropDown()
        tdbcDepartmentID.AutoSelect = True
        tdbcTeamID.AutoSelect = True
        tdbcAbsentTypeDateID.AutoSelect = True
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Nghiep_vu_chuyen_cong_sang_phep_-_D13F2031") & UnicodeCaption(gbUnicode)  'NghiÖp vó chuyÓn c¤ng sang phÏp - D13F2031
        '================================================================ 
        lblDepartmentID.Text = rl3("Phong_ban") 'Phòng ban
        lblTeamID.Text = rl3("To_nhom") 'Tổ nhóm
        lblAbsentVoucherNo.Text = rl3("Cham_cong_nhat") 'Chấm công nhật
        lblAbsentTypeDateID.Text = rl3("Loai_cong") 'Loại công
        '================================================================ 
        btnFilter.Text = rl3("Lo_c") 'Lọ&c
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcDepartmentID.Columns("DepartmentID").Caption = rl3("Ma") 'Mã
        tdbcDepartmentID.Columns("DepartmentName").Caption = rl3("Ten") 'Tên
        tdbcTeamID.Columns("TeamID").Caption = rl3("Ma") 'Mã
        tdbcTeamID.Columns("TeamName").Caption = rl3("Ten") 'Tên
        tdbcAbsentTypeDateID.Columns("AbsentTypeDateID").Caption = rl3("Ma") 'Mã
        tdbcAbsentTypeDateID.Columns("AbsentTypeDateName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdLeaveTypeID.Columns("LeaveTypeID").Caption = rl3("Ma") 'Mã
        tdbdLeaveTypeID.Columns("LeaveTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("IsUsed").Caption = rl3("Chon") 'Chọn
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns("EmployeeName").Caption = rl3("Ho_va_ten") 'Họ và tên
        tdbg.Columns("TransferAbsentType").Caption = rl3("Loai_cong") 'Loại công
        tdbg.Columns("TATValue").Caption = rl3("Gia_tri_") 'Giá trị
        tdbg.Columns("TransferValue").Caption = rl3("Gia_tri_chuyen") 'Giá trị chuyển
        tdbg.Columns("LeaveTypeID").Caption = rl3("Loai_phep") 'Loại phép
        tdbg.Columns("LeaveCoefficient").Caption = rl3("He_so") 'Hệ số
        tdbg.Columns("AddLeaveQuantity").Caption = rl3("Phep_cong_them") 'Phép cộng thêm
        tdbg.Columns("RemainValue").Caption = rl3("Gia_tri_con_lai") 'Giá trị còn lại
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_DepartmentID To COL_EmployeeName
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(i).Locked = True
        Next
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TransferAbsentType).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TransferAbsentType).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AddLeaveQuantity).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_AddLeaveQuantity).Locked = True
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TATValue).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(SPLIT1).DisplayColumns(COL_TATValue).Locked = True
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_TransferValue).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_AddLeaveQuantity).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_TATValue).NumberFormat = D13Format.DefaultNumber2
        tdbg.Columns(COL_RemainValue).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub LoadMaster()
        Dim sSQL As String = ""
        sSQL = "SELECT 		AbsentVoucherNo, Remark" & UnicodeJoin(gbUnicode) & " as Remark, AbsentTypeFrom, AbsentTypeTo, TransTypeID" & vbCrLf
        sSQL &= "FROM       D13T0102 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE 		DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "AND TranMonth = " & giTranMonth & vbCrLf
        sSQL &= "AND TranYear = " & giTranYear & vbCrLf
        sSQL &= "AND AbsentVoucherID = " & SQLString(_absentVoucherID)
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        If dt.Rows.Count > 0 Then
            txtAbsentVoucherNo.Text = dt.Rows(0).Item("AbsentVoucherNo").ToString
            txtRemark.Text = dt.Rows(0).Item("Remark").ToString
            sTransTypeID = dt.Rows(0).Item("TransTypeID").ToString
        End If
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = SQLStoreD13P2033()
        Dim dt As DataTable
        dt = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dt, gbUnicode)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdLeaveTypeID
        sSQL = "SELECT     LeaveTypeID, LeaveTypeName" & UnicodeJoin(gbUnicode) & "  as LeaveTypeName" & vbCrLf
        sSQL &= "FROM       D15T1020  WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE      Disabled = 0 " & vbCrLf
        sSQL &= "ORDER BY   LeaveTypeID"

        LoadDataSource(tdbdLeaveTypeID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)
        '***************
        'Load tdbcDepartmentID
        
        sSQL = "SELECT DepartmentID, DepartmentName" & sUnicode & " as DepartmentName, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM D91T0012 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0 AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT '%' As DepartmentID, " & sLanguage & " As DepartmentName, 0 As DisplayOrder" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, DepartmentID"
        LoadDataSource(tdbcDepartmentID, sSQL, gbUnicode)

        'Load tdbcTeamID
        
        sSQL = "SELECT D01.TeamID, D01.TeamName" & sUnicode & " as TeamName, D01.DepartmentID, 1 As DisplayOrder" & vbCrLf
        sSQL &= "FROM D09T0227 D01 WITH (NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D91T0012 D02  WITH (NOLOCK) ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        sSQL &= "WHERE D01.Disabled = 0 AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "UNION All" & vbCrLf
        sSQL &= "SELECT '%' As TeamID, " & sLanguage & " As TeamName, '%' As DepartmentID, 0 As DisplayOrder" & vbCrLf
        sSQL &= "ORDER BY DisplayOrder, TeamID"
        dtTeamID = ReturnDataTable(sSQL)

        'Load tdbcAbsentTypeDateID
        If sTransTypeID = "" Then
            sSQL = "SELECT     DISTINCT T18.AbsentTypeDateID, T18.AbsentTypeDateName" & sUnicode & " as AbsentTypeDateName, T18.Orders" & vbCrLf
            sSQL &= "FROM       D13T0118 T18 WITH (NOLOCK) " & vbCrLf
            sSQL &= "WHERE      T18.Disabled = 0 " & vbCrLf
            sSQL &= "           AND IsTimeSheet = 1 " & vbCrLf
            sSQL &= "ORDER BY   T18.Orders"
        Else
            sSQL = "SELECT     DISTINCT T30.AbsentTypeID AS AbsentTypeDateID, T18.AbsentTypeDateName" & sUnicode & " as AbsentTypeDateName, T30.OrderNo" & vbCrLf
            sSQL &= "FROM       D13T1131 T30 WITH (NOLOCK) " & vbCrLf
            sSQL &= "INNER JOIN D13T0118 T18  WITH (NOLOCK) ON T30.AbsentTypeID = T18.AbsentTypeDateID" & vbCrLf
            sSQL &= "WHERE      TransTypeID = " & SQLString(sTransTypeID) & vbCrLf
            sSQL &= "           AND T18.Disabled = 0 " & vbCrLf
            sSQL &= "           AND T18.IsTimeSheet = 1" & vbCrLf
            sSQL &= "ORDER BY   T30.OrderNo"

        End If
        LoadDataSource(tdbcAbsentTypeDateID, sSQL, gbUnicode)
    End Sub

    Private Sub LoadtdbcTeamID(ByVal ID As String)
        If ID = "%" Then
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, ""), gbUnicode)
        Else
            LoadDataSource(tdbcTeamID, ReturnTableFilter(dtTeamID, "DepartmentID = '%' or DepartmentID = " & SQLString(ID)), gbUnicode)
        End If

        tdbcTeamID.SelectedIndex = 0
    End Sub

    Private Sub btnFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilter.Click
        LoadTDBGrid()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#Region "Events tdbcDepartmentID with txtDepartmentName load tdbcTeamID with txtTeamName"

    Private Sub tdbcDepartmentID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.Close
        If tdbcDepartmentID.FindStringExact(tdbcDepartmentID.Text) = -1 Then
            tdbcDepartmentID.Text = ""
            txtDepartmentName.Text = ""
        End If
    End Sub

    Private Sub tdbcDepartmentID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDepartmentID.SelectedValueChanged
        If Not (tdbcDepartmentID.Tag Is Nothing OrElse tdbcDepartmentID.Tag.ToString = "") Then
            tdbcDepartmentID.Tag = ""
            Exit Sub
        End If
        If tdbcDepartmentID.SelectedValue Is Nothing Then
            LoadtdbcTeamID("-1")
            Exit Sub
        End If
        txtDepartmentName.Text = tdbcDepartmentID.Columns(1).Text
        LoadtdbcTeamID(tdbcDepartmentID.SelectedValue.ToString())
    End Sub

    Private Sub tdbcDepartmentID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcDepartmentID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcDepartmentID.Text = ""
        '    txtDepartmentName.Text = ""
        'End If
    End Sub

    Private Sub tdbcTeamID_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.Close
        If tdbcTeamID.FindStringExact(tdbcTeamID.Text) = -1 Then
            tdbcTeamID.Text = ""
            txtTeamName.Text = ""
        End If
    End Sub

    Private Sub tdbcTeamID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTeamID.SelectedValueChanged
        txtTeamName.Text = tdbcTeamID.Columns(1).Value.ToString()
    End Sub

    Private Sub tdbcTeamID_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcTeamID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcTeamID.Text = ""
        '    txtTeamName.Text = ""
        'End If
    End Sub

#End Region

#Region "Events tdbcAbsentTypeDateID with txtAbsentTypeDateName"

    Private Sub tdbcAbsentTypeDateID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentTypeDateID.Close
        If tdbcAbsentTypeDateID.FindStringExact(tdbcAbsentTypeDateID.Text) = -1 Then
            tdbcAbsentTypeDateID.Text = ""
            txtAbsentTypeDateName.Text = ""
        End If
    End Sub

    Private Sub tdbcAbsentTypeDateID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcAbsentTypeDateID.SelectedValueChanged
        txtAbsentTypeDateName.Text = tdbcAbsentTypeDateID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcAbsentTypeDateID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcAbsentTypeDateID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
        '    tdbcAbsentTypeDateID.Text = ""
        '    txtAbsentTypeDateName.Text = ""
        'End If
    End Sub

#End Region

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLStoreD13P2031s)

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            _bSaved = True
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If

        Dim bFlag As Boolean = False
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) Then
                bFlag = True
                Exit For
            End If
        Next
        If Not bFlag Then
            D99C0008.MsgNotYetEnter(rl3("Chon"))
            tdbg.Focus()
            tdbg.SplitIndex = SPLIT0
            tdbg.Col = COL_IsUsed
            tdbg.Bookmark = 0
            Return False
        End If

        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) Then
                If Number(tdbg(i, COL_TransferValue).ToString) = 0 Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri_chuyen"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_TransferValue
                    tdbg.Bookmark = i
                    Return False
                End If
                If tdbg(i, COL_LeaveTypeID).ToString = "" Then
                    D99C0008.MsgNotYetEnter(rl3("Loai_phep"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_LeaveTypeID
                    tdbg.Bookmark = i
                    Return False
                End If
                If Number(tdbg(i, COL_LeaveCoefficient).ToString) = 0 Then
                    D99C0008.MsgNotYetEnter(rl3("He_so"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_LeaveCoefficient
                    tdbg.Bookmark = i
                    Return False
                End If
                If Number(tdbg(i, COL_RemainValue).ToString) = 0 Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri_con_lai"))
                    tdbg.Focus()
                    tdbg.SplitIndex = SPLIT1
                    tdbg.Col = COL_RemainValue
                    tdbg.Bookmark = i
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Sub tdbg_FetchCellStyle(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FetchCellStyleEventArgs) Handles tdbg.FetchCellStyle
        Select Case tdbg.Col
            Case COL_TransferValue, COL_LeaveCoefficient, COL_RemainValue
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Locked = False
                    e.CellStyle.Locked = False
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(tdbg.Col).Locked = True
                    e.CellStyle.Locked = True
                End If
            Case COL_LeaveTypeID
                If L3Bool(tdbg.Columns(COL_IsUsed).Text) Then
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).Locked = False
                    e.CellStyle.Locked = False
                    tdbg.Columns(COL_LeaveTypeID).DropDown = tdbdLeaveTypeID
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).AutoDropDown = True
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).AutoComplete = True
                Else
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).Locked = True
                    e.CellStyle.Locked = True
                    tdbg.Columns(COL_LeaveTypeID).DropDown = Nothing
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).AutoDropDown = False
                    tdbg.Splits(SPLIT1).DisplayColumns(COL_LeaveTypeID).AutoComplete = False
                End If
        End Select
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        If tdbg.RowCount <= 0 Then Exit Sub
        Select Case e.ColIndex
            Case COL_IsUsed
                Dim bFlag As Boolean = Not CBool(tdbg(0, COL_IsUsed))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsUsed) = bFlag
                Next
            Case COL_TransferValue, COL_LeaveTypeID, COL_LeaveCoefficient, COL_RemainValue
                CopyColumns_D13F2031(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.Control Then
            Select Case e.KeyCode
                Case Keys.S
                    Select Case tdbg.Col
                        Case COL_TransferValue, COL_LeaveTypeID, COL_LeaveCoefficient, COL_RemainValue
                            CopyColumns_D13F2031(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
                    End Select
            End Select
        End If
    End Sub

    Private Sub CopyColumns_D13F2031(ByVal c1Grid As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal ColCopy As Integer, ByVal sValue As String, ByVal RowCopy As Int32)
        Try
            'If sValue = "" Or c1Grid.RowCount < 2 Then Exit Sub
            c1Grid.UpdateData()
            If c1Grid.RowCount < 2 Then Exit Sub

            sValue = c1Grid(RowCopy, ColCopy).ToString

            Dim Flag As DialogResult
            Flag = MessageBox.Show(rl3("Copy_cot_du_lieu_cho") & vbCrLf & rl3("____-_Tat_ca_cac_cot_(nhan_Yes)") & vbCrLf & rl3("____-_Nhung_dong_con_trong_(nhan_No)"), MsgAnnouncement, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)

            If Flag = Windows.Forms.DialogResult.No Then ' Copy nhung dong con trong

                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If L3Bool(c1Grid(i, COL_IsUsed).ToString) Then
                        If c1Grid(i, ColCopy).ToString = "" OrElse c1Grid(i, ColCopy).ToString = MaskFormatDateShort OrElse c1Grid(i, ColCopy).ToString = MaskFormatDate OrElse (L3IsNumeric(c1Grid(i, ColCopy).ToString) And Val(c1Grid(i, ColCopy).ToString) = 0) Then
                            c1Grid(i, ColCopy) = sValue
                            Select Case ColCopy
                                Case COL_LeaveTypeID
                                    tdbg(i, COL_LeaveCoefficient) = SQLNumber(2, D13Format.DefaultNumber2)
                                    tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * Number(tdbg(i, COL_LeaveCoefficient)), D13Format.DefaultNumber2)
                                Case COL_LeaveCoefficient
                                    tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * Number(tdbg(i, COL_LeaveCoefficient)), D13Format.DefaultNumber2)
                                Case COL_TransferValue
                                    tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * 2, D13Format.DefaultNumber2)
                                    tdbg(i, COL_RemainValue) = SQLNumber(Number(tdbg(i, COL_TATValue)) - Number(tdbg(i, COL_TransferValue)), D13Format.DefaultNumber2)
                            End Select
                        End If
                    End If
                Next
                'c1Grid(RowCopy, ColCopy) = sValue

            ElseIf Flag = Windows.Forms.DialogResult.Yes Then ' Copy het
                For i As Integer = RowCopy + 1 To c1Grid.RowCount - 1
                    If L3Bool(c1Grid(i, COL_IsUsed).ToString) Then
                        c1Grid(i, ColCopy) = sValue
                        Select Case ColCopy
                            Case COL_LeaveTypeID
                                tdbg(i, COL_LeaveCoefficient) = SQLNumber(2, D13Format.DefaultNumber2)
                                tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * Number(tdbg(i, COL_LeaveCoefficient)), D13Format.DefaultNumber2)
                            Case COL_LeaveCoefficient
                                tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * Number(tdbg(i, COL_LeaveCoefficient)), D13Format.DefaultNumber2)
                            Case COL_TransferValue
                                tdbg(i, COL_AddLeaveQuantity) = SQLNumber(Number(tdbg(i, COL_TransferValue)) * 2, D13Format.DefaultNumber2)
                                tdbg(i, COL_RemainValue) = SQLNumber(Number(tdbg(i, COL_TATValue)) - Number(tdbg(i, COL_TransferValue)), D13Format.DefaultNumber2)
                        End Select
                    End If
                Next
                'c1Grid(0, ColCopy) = sValue
            Else
                Exit Sub
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_TransferValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_LeaveCoefficient
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_AddLeaveQuantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_RemainValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        '--- Kiểm tra giá trị hợp lệ
        Select Case e.ColIndex
            Case COL_TATValue
                If Not L3IsNumeric(tdbg.Columns(COL_TATValue).Text, EnumDataType.SmallMoney) Then e.Cancel = True
            Case COL_TransferValue
                If Not L3IsNumeric(tdbg.Columns(COL_TransferValue).Text, EnumDataType.SmallMoney) Then e.Cancel = True
            Case COL_LeaveTypeID
                If tdbg.Columns(COL_LeaveTypeID).Text <> tdbdLeaveTypeID.Columns("LeaveTypeID").Text Then
                    tdbg.Columns(COL_LeaveTypeID).Text = ""
                End If
            Case COL_LeaveCoefficient
                If Not L3IsNumeric(tdbg.Columns(COL_LeaveCoefficient).Text, EnumDataType.SmallMoney) Then e.Cancel = True
            Case COL_AddLeaveQuantity
                If Not L3IsNumeric(tdbg.Columns(COL_AddLeaveQuantity).Text, EnumDataType.SmallMoney) Then e.Cancel = True
            Case COL_RemainValue
                If Not L3IsNumeric(tdbg.Columns(COL_RemainValue).Text, EnumDataType.SmallMoney) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_TransferValue
                tdbg.Columns(COL_AddLeaveQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_TransferValue).Text) * 2, D13Format.DefaultNumber2)
                tdbg.Columns(COL_RemainValue).Text = SQLNumber(Number(tdbg.Columns(COL_TATValue).Text) - Number(tdbg.Columns(COL_TransferValue).Text), D13Format.DefaultNumber2)
            Case COL_LeaveTypeID
                tdbg.Columns(COL_LeaveCoefficient).Text = SQLNumber(2, D13Format.DefaultNumber2)
                tdbg.Columns(COL_AddLeaveQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_TransferValue).Text) * Number(tdbg.Columns(COL_LeaveCoefficient).Text), D13Format.DefaultNumber2)
            Case COL_LeaveCoefficient
                tdbg.Columns(COL_AddLeaveQuantity).Text = SQLNumber(Number(tdbg.Columns(COL_TransferValue).Text) * Number(tdbg.Columns(COL_LeaveCoefficient).Text), D13Format.DefaultNumber2)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2033
    '# Created User: DUCTRONG
    '# Created Date: 21/05/2009 04:22:29
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2033() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2033 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcDepartmentID.Text) & COMMA 'DepartmentID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcTeamID.Text) & COMMA 'TeamID, varchar[20], NOT NULL
        sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL '_absentVoucherID
        sSQL &= SQLString(tdbcAbsentTypeDateID.Text) & COMMA 'AbsentTypeID, varchar[20], NOT NULL 'NCCB'tdbcAbsentTypeDateID.Text
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2031s
    '# Created User: DUCTRONG
    '# Created Date: 22/05/2009 08:09:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2031s() As String
        Dim sRet As String = ""
        Dim sSQL As String
        Dim sVoucherID As String = ""
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) Then
                sVoucherID = CreateIGE("D13T2031", "VoucherID", "13", "MV", gsStringKey)
                sSQL = ""
                sSQL &= "Exec D13P2031 "
                sSQL &= SQLString("") & COMMA 'VoucherTypeID, varchar[20], NOT NULL
                sSQL &= SQLString(sVoucherID) & COMMA 'VoucherID, varchar[20], NOT NULL
                sSQL &= SQLString("") & COMMA 'VoucherNo, varchar[20], NOT NULL
                sSQL &= SQLDateSave(Date.Today) & COMMA 'VoucherDate, datetime, NOT NULL
                sSQL &= "N" & SQLString("") & COMMA 'Description, varchar[250], NOT NULL
                sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_EmployeeID)) & COMMA 'EmployeeID, varchar[20], NOT NULL
                sSQL &= SQLString(txtAbsentVoucherNo.Text) & COMMA 'AbsentVoucherNo, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_TransferAbsentType)) & COMMA 'TransferAbsentType, varchar[20], NOT NULL
                sSQL &= SQLMoney(tdbg(i, COL_TransferValue), D13Format.DefaultNumber2) & COMMA 'TransferValue, decimal, NOT NULL
                sSQL &= SQLString("") & COMMA 'ReceiveAbsentType, varchar[20], NOT NULL
                sSQL &= SQLMoney(0) & COMMA 'ReceiveValue, decimal, NOT NULL
                sSQL &= SQLMoney(tdbg(i, COL_AddLeaveQuantity), D13Format.DefaultNumber2) & COMMA 'AddLeaveQuantity, decimal, NOT NULL
                sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
                sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
                sSQL &= SQLString(gsUserID) & COMMA 'CreateUserID, varchar[20], NOT NULL
                sSQL &= SQLDateSave("") & COMMA 'CreateDate, datetime, NOT NULL
                sSQL &= SQLString(gsUserID) & COMMA 'LastModifyUserID, varchar[20], NOT NULL
                sSQL &= SQLDateSave("") & COMMA 'LastModifyDate, datetime, NOT NULL
                sSQL &= SQLString(_absentVoucherID) & COMMA 'AbsentVoucherID, varchar[20], NOT NULL
                sSQL &= SQLString(tdbg(i, COL_LeaveTypeID)) & COMMA 'LeaveTypeID, varchar[20], NOT NULL
                sSQL &= SQLMoney(tdbg(i, COL_LeaveCoefficient), D13Format.DefaultNumber2) & COMMA 'LeaveCoefficient, decimal, NOT NULL
                sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
                sSQL &= SQLNumber(gbUnicode)
                sRet &= sSQL & vbCrLf
            End If
        Next
        Return sRet
    End Function

End Class