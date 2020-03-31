Imports System
Public Class D13F1002

#Region "Const of tdbg1"
    Private Const COL1_TransID As Integer = 0      ' TransID
    Private Const COL1_AbsentTypeID As Integer = 1 ' AbsentTypeID
    Private Const COL1_MinValue As Integer = 2     ' Thời gian
    Private Const COL1_MaxValue As Integer = 3     ' Thời gian
    Private Const COL1_Value As Integer = 4        ' Giá trị
    Private Const COL1_Mode As Integer = 5         ' Loại
#End Region

#Region "Const of tdbg2"
    Private Const COL2_TransID As Integer = 0      ' TransID
    Private Const COL2_AbsentTypeID As Integer = 1 ' AbsentTypeID
    Private Const COL2_MinValue As Integer = 2     ' Giá trị
    Private Const COL2_MaxValue As Integer = 3     ' Giá trị
    Private Const COL2_MethodName As Integer = 4   ' Phương pháp
    Private Const COL2_Method As Integer = 5       ' Method
    Private Const COL2_Value As Integer = 6        ' Giá trị
    Private Const COL2_Mode As Integer = 7         ' Loại
#End Region

    Private _methodID As String = ""
    Public Property MethodID() As String
        Get
            Return _methodID
        End Get
        Set(ByVal Value As String)
            _methodID = Value
        End Set
    End Property

    Private _cycle As String = ""
    Public Property Cycle() As String 
        Get
            Return _cycle
        End Get
        Set(ByVal Value As String )
            _cycle = Value
        End Set
    End Property

    Private _convertionHours As String = ""
    Public Property ConvertionHours() As String 
        Get
            Return _convertionHours
        End Get
        Set(ByVal Value As String )
            _convertionHours = Value
        End Set
    End Property

    Private _absentTypeDateID As String = ""
    Public Property AbsentTypeDateID() As String 
        Get
            Return _absentTypeDateID
        End Get
        Set(ByVal Value As String )
            _absentTypeDateID = Value
        End Set
    End Property

    Private _decimal1 As String = "0"
    Public Property Decimal1() As String 
        Get
            Return _decimal1
        End Get
        Set(ByVal Value As String )
            _decimal1 = Value
        End Set
    End Property

    Dim dt1 As New DataTable
    Dim dt2 As New DataTable

    Private Sub D13F1002_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then UseEnterAsTab(Me)
    End Sub

    Private Sub D13F1002_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetSplitDividerSize(tdbg2)
        tdbg_LockedColumns()
        tdbg_NumberFormat()
        SetBackColorObligatory()
        LoadTDBCombo()
        LoadTDBDropDown()
        LoadMaster()
        LoadTDBGrid()
    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Quy_doi_cong_tu_may_cham_cong_-_D13F1002") 'Quy ¢åi c¤ng tô mÀy chÊm c¤ng - D13F1002
        '================================================================ 
        lblDetail.Text = rl3("Chi_tiet") 'Chi tiết
        lblMethodID.Text = rl3("Phuong_phap_quy_doi") 'Phương pháp quy đổi
        lblCycle.Text = rl3("Chu_ky") 'Chu kỳ
        lblMinute.Text = "(" & rl3("phut") & ")" 'Phút
        lblConvertionHours.Text = rl3("So_gio_quy_doi") 'Số giờ quy đổi
        Label1.Text = rl3("Chi_tiet") 'Chi tiết
        lblDecimal1.Text = rl3("Lam_tron") 'Làm tròn
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        GroupBox1.Text = rl3("Quy_doi_tu_gio_sang_cong") 'Quy đổi từ giờ sang công
        GroupBox3.Text = rl3("Quy_doi_cong") 'Quy đổi công
        '================================================================ 
        tdbcMethodID.Columns("MethodID").Caption = rl3("Ma") 'Mã
        tdbcMethodID.Columns("MethodName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbdMethod.Columns("Method").Caption = rl3("Ma") 'Mã
        tdbdMethod.Columns("MethodName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg1.Columns("MinValue").Caption = "(>)" & rl3("Thoi_gian") & "(" & rl3("phut") & ")" 'Thời gian
        tdbg1.Columns("MaxValue").Caption = "(<=)" & rl3("Thoi_gian") & "(" & rl3("phut") & ")" 'Thời gian
        tdbg1.Columns("Value").Caption = rl3("Gia_tri_") 'Giá trị
        tdbg1.Columns("Mode").Caption = rl3("Loai") 'Loại
        tdbg2.Columns("MinValue").Caption = "(>)" & rl3("Gia_tri_") 'Giá trị
        tdbg2.Columns("MaxValue").Caption = "(<=)" & rl3("Gia_tri_") 'Giá trị
        tdbg2.Columns("MethodName").Caption = rl3("Phuong_phap") 'Phương pháp
        tdbg2.Columns("Value").Caption = rl3("Gia_tri_") 'Giá trị
        tdbg2.Columns("Mode").Caption = rl3("Loai") 'Loại
        tdbg2.Splits(SPLIT0).Caption = rl3("Dieu_kien") 'Điều kiện
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcMethodID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        txtCycle.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtConvertionHours.BackColor = COLOR_BACKCOLOROBLIGATORY
        cboDecimals.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbg_LockedColumns()
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_MinValue).Locked = True
        tdbg1.Splits(SPLIT0).DisplayColumns(COL1_MinValue).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MinValue).Locked = True
        tdbg2.Splits(SPLIT0).DisplayColumns(COL2_MinValue).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
    End Sub

    Private Sub tdbg_NumberFormat()
        tdbg1.Columns(COL1_MinValue).NumberFormat = D13Format.DefaultNumber2
        tdbg1.Columns(COL1_MaxValue).NumberFormat = D13Format.DefaultNumber2
        tdbg1.Columns(COL1_Value).NumberFormat = D13Format.DefaultNumber2

        tdbg2.Columns(COL2_MinValue).NumberFormat = D13Format.DefaultNumber2
        tdbg2.Columns(COL2_MaxValue).NumberFormat = D13Format.DefaultNumber2
        tdbg2.Columns(COL2_Value).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcMethodID
        sSQL = "SELECT 0 AS MethodID, 'Lieân tuïc' AS MethodName" & vbCrLf
        sSQL &= "UNION" & vbCrLf
        sSQL &= "SELECT 1 AS MethodID, 'Voøng laëp' AS MethodName"
        LoadDataSource(tdbcMethodID, sSQL)
    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdMethod
        sSQL = "Select 1 As Method, " & SQLString(rl3("Gia_tri")) & " As MethodName" & vbCrLf
        sSQL &= "UNION" & vbCrLf & vbCrLf
        sSQL &= "Select 2 As Method, " & SQLString(rl3("Ty_leV")) & "  As MethodName"
        LoadDataSource(tdbdMethod, sSQL)
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = "SELECT *, Case When Method = 1 then " & SQLString(rl3("Gia_tri")) & " When Method = 2 then " & SQLString(rl3("Ty_leV")) & " Else '' End As MethodName" & vbCrLf
        sSQL &= "FROM D13T0130 WITH (NOLOCK) " & vbCrLf
        sSQL &= "WHERE AbsentTypeID = " & SQLString(_absentTypeDateID)
        Dim dt As New DataTable
        dt = ReturnDataTable(sSQL)
        dt1 = ReturnTableFilter(dt, "Mode = 0")
        dt2 = ReturnTableFilter(dt, "Mode = 1")
        LoadDataSource(tdbg1, dt1)
        LoadDataSource(tdbg2, dt2)
    End Sub

    Private Sub LoadMaster()
        tdbcMethodID.SelectedValue = _methodID
        txtCycle.Text = _cycle
        txtConvertionHours.Text = _convertionHours
        cboDecimals.Text = _decimal1
    End Sub

#Region "Events tdbcMethodID"

    Private Sub tdbcMethodID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcMethodID.Close
        If tdbcMethodID.FindStringExact(tdbcMethodID.Text) = -1 Then tdbcMethodID.Text = ""
    End Sub

    Private Sub tdbcMethodID_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcMethodID.SelectedValueChanged
        If tdbcMethodID.Text = "" Or tdbcMethodID.SelectedValue Is Nothing Then
            txtCycle.Enabled = True
            tdbg1.Enabled = True
            Exit Sub
        End If

        If tdbcMethodID.SelectedValue.ToString = "0" Then
            txtCycle.Enabled = False
            txtCycle.Text = ""
            tdbg1.Enabled = False
            dt1.Clear()
            LoadDataSource(tdbg1, dt1)
        Else
            txtCycle.Enabled = True
            tdbg1.Enabled = True
        End If
    End Sub

    Private Sub tdbcMethodID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcMethodID.KeyDown
        'If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcMethodID.Text = ""
    End Sub

#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Dim bDelete As Boolean = False
    Private Function AllowSave() As Boolean
        If tdbcMethodID.Text.Trim = "" And txtCycle.Text.Trim = "" And txtConvertionHours.Text.Trim = "" Then
            'If tdbg1.RowCount <= 0 And tdbg2.RowCount <= 0 Then
            bDelete = True
            Return True
            'End If
        End If

        If tdbcMethodID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Phuong_phap_quy_doi"))
            tdbcMethodID.Focus()
            Return False
        End If

        If tdbcMethodID.SelectedValue.ToString = "1" Then
            If txtCycle.Text.Trim = "" Then
                D99C0008.MsgNotYetEnter(rl3("Chu_ky"))
                txtCycle.Focus()
                Return False
            End If
            If CInt(txtCycle.Text.Trim) < 0 Then
                D99C0008.MsgL3(rl3("Chu_ky_phai_lon_hon_hoac_bang_0"))
                txtCycle.Focus()
                Return False
            End If
        End If
        If txtConvertionHours.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_gio_quy_doi"))
            txtConvertionHours.Focus()
            Return False
        End If
        If cboDecimals.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Lam_tron"))
            cboDecimals.Focus()
            Return False
        End If

        If tdbcMethodID.SelectedValue.ToString <> "0" Then
            If tdbg1.RowCount <= 0 Then
                D99C0008.MsgNoDataInGrid()
                tdbg1.Focus()
                Return False
            End If
        End If

        If tdbcMethodID.SelectedValue.ToString = "1" Then
            For i As Integer = 0 To tdbg2.RowCount - 1
                If tdbg2(i, COL2_MinValue).ToString = "" Then
                    D99C0008.MsgNotYetEnter("(>)" & rl3("Gia_tri_"))
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_MinValue
                    tdbg2.Bookmark = i
                    tdbg2.Focus()
                    Return False
                End If
                If tdbg2(i, COL2_MaxValue).ToString = "" Then
                    D99C0008.MsgNotYetEnter("(<=)" & rl3("Gia_tri_"))
                    tdbg2.Focus()
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_MaxValue
                    tdbg2.Bookmark = i
                    Return False
                End If
                If CInt(tdbg2(i, COL2_MinValue)) > CInt(tdbg2(i, COL2_MaxValue)) Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri_tu_phai_nho_hon_hoac_bang_gia_tri_den"))
                    tdbg2.Focus()
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_MinValue
                    tdbg2.Bookmark = i
                    Return False
                End If
                If CInt(tdbg2(i, COL2_Value)) < 0 Then
                    D99C0008.MsgNotYetEnter(rl3("Gia_tri_phai_lon_hon_hoac_bang_0"))
                    tdbg2.Focus()
                    tdbg2.SplitIndex = SPLIT0
                    tdbg2.Col = COL2_Value
                    tdbg2.Bookmark = i
                    Return False
                End If
            Next
            If Number(tdbg1(tdbg1.RowCount - 1, COL1_MaxValue).ToString) <> Number(txtCycle.Text) Then
                D99C0008.MsgL3(rl3("Thoi_gian_cuoi_cung_phai_bang_chu_ky"))
                tdbg1.Focus()
                tdbg1.SplitIndex = SPLIT0
                tdbg1.Col = COL1_MaxValue
                tdbg1.Bookmark = tdbg1.RowCount - 1
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        If bDelete Then
            sSQL.Append(SQLDeleteD13T0130.ToString() & vbCrLf)
            sSQL.Append(SQLUpdateD13T0118.ToString())
            bDelete = False
        Else
            sSQL.Append(SQLUpdateD13T0118.ToString() & vbCrLf)
            sSQL.Append(SQLDeleteD13T0130.ToString() & vbCrLf)
            sSQL.Append(SQLInsertD13T0130s.ToString())
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Sub txtConvertionHours_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConvertionHours.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot, txtConvertionHours.Text)
    End Sub

    Private Sub txtConvertionHours_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConvertionHours.LostFocus
        If IsNumeric(txtConvertionHours.Text) Then
            txtConvertionHours.Text = SQLNumber(txtConvertionHours.Text, D13Format.DefaultNumber2)
            If Number(txtConvertionHours.Text) = 0 Then txtConvertionHours.Text = ""
        Else
            txtConvertionHours.Text = ""
        End If
    End Sub

    Private Sub txtCycle_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCycle.KeyPress
        e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot, txtCycle.Text)
    End Sub

    Private Sub txtCycle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCycle.LostFocus
        If IsNumeric(txtCycle.Text) Then
            txtCycle.Text = SQLNumber(txtCycle.Text, D13Format.DefaultNumber2)
            If Number(txtCycle.Text) = 0 Then txtCycle.Text = ""
        Else
            txtCycle.Text = ""
        End If
    End Sub

    Private Sub tdbg1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg1.Col = COL1_Value Then
                    HotKeyEnterGrid(tdbg1, COL1_MaxValue, e)
                End If
        End Select
    End Sub

    Private Sub tdbg1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg1.KeyPress
        Select Case tdbg1.Col
            Case COL1_MinValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL1_MaxValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL1_Value
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    Private Sub tdbg1_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg1.BeforeColUpdate
        Select Case e.ColIndex
            Case COL1_MaxValue
                If Not IsNumeric(tdbg1.Columns(COL1_MaxValue).Text) Then
                    e.Cancel = True
                    Exit Sub
                End If
                If Number(SQLNumber(tdbg1.Columns(COL1_MaxValue).Text, D13Format.DefaultNumber2)) > Number(txtCycle.Text) Then
                    e.Cancel = True
                    D99C0008.MsgL3(rl3("Thoi_gian_lon_hon_chu_ky"))
                    Exit Sub
                End If
                If tdbg1.RowCount > 1 And tdbg1.Bookmark > 0 Then
                    If Number(tdbg1.Columns(COL1_MaxValue).Text) <= Number(tdbg1(tdbg1.Bookmark - 1, COL1_MaxValue)) Then
                        e.Cancel = True
                        D99C0008.MsgL3(rl3("Thoi_gian_khong_hop_le"))
                        Exit Sub
                    End If
                End If
            Case COL1_Value
                If Not IsNumeric(tdbg1.Columns(COL1_Value).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg1_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg1.AfterColUpdate
        tdbg1.UpdateData()
        Select Case e.ColIndex
            Case COL1_MaxValue
                If tdbg1.Columns(COL1_MaxValue).Text <> "" Then
                    If tdbg1.RowCount = 1 Then
                        tdbg1(tdbg1.Bookmark, COL1_MinValue) = "0"
                    Else
                        If tdbg1.Bookmark = 0 Then
                            tdbg1(tdbg1.Bookmark, COL1_MinValue) = "0"
                            If tdbg1.Bookmark < tdbg1.RowCount - 1 Then
                                tdbg1(tdbg1.Bookmark + 1, COL1_MinValue) = tdbg1(tdbg1.Bookmark, COL1_MaxValue)
                            End If
                        Else
                            If tdbg1.Bookmark < tdbg1.RowCount - 1 Then
                                tdbg1(tdbg1.Bookmark, COL1_MinValue) = tdbg1(tdbg1.Bookmark - 1, COL1_MaxValue)
                                tdbg1(tdbg1.Bookmark + 1, COL1_MinValue) = tdbg1(tdbg1.Bookmark, COL1_MaxValue)
                            ElseIf tdbg1.Bookmark = tdbg1.RowCount - 1 Then
                                tdbg1(tdbg1.Bookmark, COL1_MinValue) = tdbg1(tdbg1.Bookmark - 1, COL1_MaxValue)
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg2_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.AfterColUpdate
        tdbg2.UpdateData()
        Select Case e.ColIndex
            Case COL2_MaxValue
                If tdbg2.Columns(COL2_MaxValue).Text <> "" Then
                    If tdbg2.RowCount = 1 Then
                        tdbg2(tdbg2.Bookmark, COL2_MinValue) = "0"
                    Else
                        If tdbg2.Bookmark = 0 Then
                            tdbg2(tdbg2.Bookmark, COL2_MinValue) = "0"
                            If tdbg2.Bookmark < tdbg2.RowCount - 1 Then
                                tdbg2(tdbg2.Bookmark + 1, COL2_MinValue) = tdbg2(tdbg2.Bookmark, COL2_MaxValue)
                            End If
                        Else
                            If tdbg1.Bookmark < tdbg1.RowCount - 1 Then
                                tdbg2(tdbg2.Bookmark, COL2_MinValue) = tdbg2(tdbg2.Bookmark - 1, COL2_MaxValue)
                                tdbg2(tdbg2.Bookmark + 1, COL2_MinValue) = tdbg2(tdbg2.Bookmark, COL2_MaxValue)
                            ElseIf tdbg1.Bookmark = tdbg1.RowCount - 1 Then
                                tdbg2(tdbg2.Bookmark, COL2_MinValue) = tdbg2(tdbg2.Bookmark - 1, COL2_MaxValue)
                            End If
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub tdbg2_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg2.BeforeColUpdate
        Select Case e.ColIndex
            Case COL2_MaxValue
                If Not IsNumeric(tdbg2.Columns(COL2_MaxValue).Text) Then
                    e.Cancel = True
                    Exit Sub
                End If
                If tdbg2.RowCount > 1 And tdbg2.Bookmark > 0 Then
                    If Number(tdbg2.Columns(COL2_MaxValue).Text) <= Number(tdbg2(tdbg2.Bookmark - 1, COL2_MaxValue)) Then
                        e.Cancel = True
                        D99C0008.MsgL3(rl3("Thoi_gian_khong_hop_le"))
                        Exit Sub
                    End If
                End If
            Case COL2_MethodName
                If tdbg2.Columns(COL2_MethodName).Text <> tdbdMethod.Columns("MethodName").Text Then
                    tdbg2.Columns(COL2_Method).Text = ""
                    tdbg2.Columns(COL2_MethodName).Text = ""
                End If
            Case COL2_Value
                If Not IsNumeric(tdbg2.Columns(COL2_Value).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg2_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg2.ComboSelect
        Select Case e.ColIndex
            Case COL2_MethodName
                tdbg2.Columns(COL2_Method).Text = tdbdMethod.Columns("Method").Text
                tdbg2.Columns(COL2_MethodName).Text = tdbdMethod.Columns("MethodName").Text
        End Select
    End Sub

    Private Sub tdbg2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg2.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                If tdbg2.Col = COL2_Value Then
                    HotKeyEnterGrid(tdbg2, COL2_MaxValue, e)
                End If
        End Select
    End Sub

    Private Sub tdbg2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg2.KeyPress
        Select Case tdbg2.Col
            Case COL2_MinValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL2_MaxValue
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL2_Value
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T0118
    '# Created User: DUCTRONG
    '# Created Date: 30/06/2009 03:18:31
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T0118() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T0118 Set ")
        sSQL.Append("MeThodID = " & SQLNumber(tdbcMethodID.SelectedValue.ToString) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("Cycle = " & SQLNumber(txtCycle.Text) & COMMA) 'int, NOT NULL
        sSQL.Append("ConvertionHours = " & SQLMoney(txtConvertionHours.Text, D13Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
        sSQL.Append("Decimal1 = " & SQLNumber(cboDecimals.Text)) 'int, NOT NULL
        sSQL.Append(" Where ")
        sSQL.Append("AbsentTypeDateID = " & SQLString(_absentTypeDateID))

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T0130
    '# Created User: DUCTRONG
    '# Created Date: 30/06/2009 03:19:37
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T0130() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T0130"
        sSQL &= " Where "
        sSQL &= "AbsentTypeID = " & SQLString(_absentTypeDateID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T0130s
    '# Created User: DUCTRONG
    '# Created Date: 01/07/2009 08:11:50
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T0130s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder

        Dim sTransID1 As String = ""
        Dim iCountIGE1 As Int32 = 0

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_TransID).ToString = "" Then
                iCountIGE1 += 1
            End If
        Next

        For i As Integer = 0 To tdbg1.RowCount - 1
            If tdbg1(i, COL1_TransID).ToString = "" Then
                sTransID1 = CreateIGEs("D13T0130", "TransID", "13", "CA", gsStringKey, sTransID1, iCountIGE1)
                tdbg1(i, COL1_TransID) = sTransID1
            End If

            sSQL.Append("Insert Into D13T0130(")
            sSQL.Append("TransID, AbsentTypeID, MinValue, MaxValue, Method, ")
            sSQL.Append("Value, Mode")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg1(i, COL1_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_absentTypeDateID) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_MinValue), D13Format.DefaultNumber2) & COMMA) 'MinValue, money, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_MaxValue), D13Format.DefaultNumber2) & COMMA) 'MaxValue, money, NOT NULL
            sSQL.Append(SQLNumber(0) & COMMA) 'Method, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg1(i, COL1_Value), D13Format.DefaultNumber2) & COMMA) 'Value, money, NOT NULL
            sSQL.Append(SQLNumber(0)) 'Mode, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next

        Dim sTransID2 As String = ""
        Dim iCountIGE2 As Int32 = 0

        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_TransID).ToString = "" Then
                iCountIGE2 += 1
            End If
        Next

        For i As Integer = 0 To tdbg2.RowCount - 1
            If tdbg2(i, COL2_TransID).ToString = "" Then
                sTransID2 = CreateIGEs("D13T0130", "TransID", "13", "CA", gsStringKey, sTransID2, iCountIGE2)
                tdbg2(i, COL2_TransID) = sTransID2
            End If

            sSQL.Append("Insert Into D13T0130(")
            sSQL.Append("TransID, AbsentTypeID, MinValue, MaxValue, Method, ")
            sSQL.Append("Value, Mode")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg2(i, COL2_TransID)) & COMMA) 'TransID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_absentTypeDateID) & COMMA) 'AbsentTypeID, varchar[20], NOT NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_MinValue), D13Format.DefaultNumber2) & COMMA) 'MinValue, money, NOT NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_MaxValue), D13Format.DefaultNumber2) & COMMA) 'MaxValue, money, NOT NULL
            sSQL.Append(SQLNumber(tdbg2(i, COL2_Method)) & COMMA) 'Method, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbg2(i, COL2_Value), D13Format.DefaultNumber2) & COMMA) 'Value, money, NOT NULL
            sSQL.Append(SQLNumber(1)) 'Mode, tinyint, NOT NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    ''#---------------------------------------------------------------------------------------------------
    ''# Title: SQLUpdateD13T0118
    ''# Created User: DUCTRONG
    ''# Created Date: 07/07/2009 01:25:29
    ''# Modified User: 
    ''# Modified Date: 
    ''# Description: 
    ''#---------------------------------------------------------------------------------------------------
    'Private Function SQLUpdateD13T0118() As StringBuilder
    '    Dim sSQL As New StringBuilder
    '    sSQL.Append("Update D13T0118 Set ")
    '    sSQL.Append("MeThodID = " & SQLNumber(tdbcMethodID.Text) & COMMA) 'tinyint, NOT NULL
    '    sSQL.Append("Cycle = " & SQLNumber(txtCycle.Text) & COMMA) 'int, NOT NULL
    '    sSQL.Append("ConvertionHours = " & SQLMoney(txtConvertionHours.Text, D13Format.DefaultNumber2) & COMMA) 'decimal, NOT NULL
    '    sSQL.Append("Decimal1 = " & SQLNumber(cboDecimals.Text)) 'int, NOT NULL
    '    sSQL.Append(" Where ")
    '    sSQL.Append("AbsentTypeDateID = " & SQLString(_absentTypeDateID))

    '    Return sSQL
    'End Function



End Class