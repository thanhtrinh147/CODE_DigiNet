Imports System
Public Class D25F2081


#Region "Const of tdbg"
    Private Const COL_TransID As Integer = 0      ' TransID
    Private Const COL_DepartmentID As Integer = 1 ' Phòng ban
    Private Const COL_TeamID As Integer = 2       ' Tổ nhóm
    Private Const COL_PositionID As Integer = 3   ' Vị trí
    Private Const COL_Ref01 As Integer = 4        ' Ref01
    Private Const COL_Ref02 As Integer = 5        ' Ref02
    Private Const COL_Ref03 As Integer = 6        ' Ref03
    Private Const COL_Ref04 As Integer = 7        ' Ref04
    Private Const COL_Ref05 As Integer = 8        ' Ref05
    Private Const COL_Ref06 As Integer = 9        ' Ref06
    Private Const COL_Ref07 As Integer = 10       ' Ref07
    Private Const COL_Ref08 As Integer = 11       ' Ref08
    Private Const COL_Ref09 As Integer = 12       ' Ref09
    Private Const COL_Ref10 As Integer = 13       ' Ref10
    Private Const COL_Number As Integer = 14      ' Số lượng
    Private Const COL_Note As Integer = 15        ' Ghi chú
#End Region


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            LoadTDBDropDown()
            bFlagSave = False
            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadData()
                Case EnumFormState.FormEdit
                    LoadData()
                Case EnumFormState.FormView
                    LoadData()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private _generalPlanID As String = ""
    Public Property GeneralPlanID() As String
        Get
            Return _generalPlanID
        End Get
        Set(ByVal Value As String)
            _generalPlanID = Value
        End Set
    End Property

    Private _generalPlanName As String= ""
    Public Property GeneralPlanName() As String
        Get
            Return _generalPlanName
        End Get
        Set(ByVal Value As String)
            _generalPlanName = Value
        End Set
    End Property

    Private _generalPlanDate As String= ""
    Public Property GeneralPlanDate() As String
        Get
            Return _generalPlanDate
        End Get
        Set(ByVal Value As String)
            _generalPlanDate = Value
        End Set
    End Property

    Private _fullName As String= ""
    Public Property FullName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal Value As String)
            _fullName = Value
        End Set
    End Property

    Dim bFlagSave As Boolean

    'Private Sub D25F2081_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    'Hỏi trước khi đóng 
    '    If _FormState = EnumFormState.FormEdit Then
    '        If Not bFlagSave Then
    '            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
    '        End If
    '    ElseIf _FormState = EnumFormState.FormAdd Then
    '        If btnSave.Enabled Then
    '            If Not AskMsgBeforeClose() Then e.Cancel = True : Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub D25F2081_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me, True)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D25F2081_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        Loadlanguage()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chi_tiet_ke_hoach_tuyen_dung_tong_the_-_D25F2081") 'Chi tiÕt kÕ hoÁch tuyÓn dóng tång thÓ - D25F2081
        '================================================================ 
        lblGeneralPlanID.Text = rl3("Ke_hoach_TD") 'Kế hoạch TD
        lblGeneralPlanDate.Text = rl3("Ngay_lap") 'Ngày lập
        lblFullName.Text = rl3("Nguoi_lap") 'Người lập
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("TransID").Caption = rl3("TransID") 'TransID
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("PositionID").Caption = rl3("Vi_tri") 'Vị trí
        tdbg.Columns("Number").Caption = rl3("So_luong") 'Số lượng
        tdbg.Columns("Note").Caption = rl3("Ghi_chu")
    End Sub

    Private Sub LoadData()
        txtGeneralPlanID.Text = _generalPlanID
        txtGeneralPlanName.Text = _generalPlanName
        txtGeneralPlanDate.Text = _generalPlanDate
        txtFullName.Text = _fullName

        Dim sSQL As String = ""
        sSQL = "SELECT *" & vbCrLf
        sSQL &= "FROM D25T2081 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE GeneralPlanID = " & SQLString(_generalPlanID) & vbCrLf
        sSQL &= "ORDER BY TransID"

        Dim dtDetail As New DataTable
        dtDetail = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtDetail)
        LoadRefCaption()
    End Sub

    Private Sub LoadRefCaption()
        Dim sSQL As String = ""
        Dim dtSpec As New DataTable

        sSQL = SQLStoreD25P0050("D25T2001")
        dtSpec = ReturnDataTable(sSQL)

        If dtSpec.Rows.Count <= 0 Then Exit Sub


        For i As Integer = 0 To 9
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Ref01 + i).Visible = Not CBool(dtSpec.Rows(i).Item("Disabled").ToString)
            tdbg.Splits(SPLIT0).DisplayColumns(COL_Ref01 + i).HeadingStyle.Font = New Font("Lemon3", 8.249999)
            tdbg.Columns(COL_Ref01 + i).Caption = dtSpec.Rows(i).Item("RefCaption").ToString
        Next

    End Sub

    Private Sub LoadTDBDropDown()
        Dim sSQL As String = ""
        'Load tdbdDepartmentID
        sSQL = "SELECT 	DepartmentID, DepartmentName" & vbCrLf
        sSQL &= "FROM D91T0012 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0" & vbCrLf
        sSQL &= "AND DivisionID = " & SQLString(gsDivisionID)
        LoadDataSource(tdbdDepartmentID, sSQL)
       
        'Load tdbdPositionID
        sSQL = "SELECT RecPositionID AS PositionID , RecPositionName AS PositionName" & vbCrLf
        sSQL &= "FROM D25T1020 WITH(NOLOCK) " & vbCrLf
        sSQL &= "WHERE Disabled = 0"
        LoadDataSource(tdbdPositionID, sSQL)
    End Sub

    Public Sub LoadtdbdTeamID(ByVal ID As String)
        Dim sSQL As String = ""
        'Load tdbdTeamID
        sSQL = "SELECT D01.TeamID, D01.TeamName, D01.DepartmentID" & vbCrLf
        sSQL &= "FROM D09T0227 D01 WITH(NOLOCK) " & vbCrLf
        sSQL &= "INNER JOIN D91T0012 D02  WITH(NOLOCK) " & vbCrLf
        sSQL &= "ON D02.DepartmentID = D01.DepartmentID" & vbCrLf
        sSQL &= "WHERE D01.Disabled = 0" & vbCrLf
        sSQL &= "AND DivisionID = " & SQLString(gsDivisionID) & vbCrLf
        sSQL &= "AND D02.DepartmentID = " & SQLString(ID)

        LoadDataSource(tdbdTeamID, sSQL)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                sSQL.Append(SQLInsertD25T2081s().ToString)

                'Lưu LastKey của Số phiếu xuống Database (gọi hàm CreateIGEVoucherNo bật cờ True)
                'Kiểm tra trùng Số phiếu (gọi hàm CheckDuplicateVoucherNo)
                'Nếu tra trùng Số phiếu thì bật
                'btnSave.Enabled = True
                'btnClose.Enabled = True

            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD25T2081() & vbCrLf)
                sSQL.Append(SQLInsertD25T2081s().ToString)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            bFlagSave = True
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd

                Case EnumFormState.FormEdit
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
            btnClose.Focus()
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
            btnSave.Focus()
        End If

    End Sub

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_DepartmentID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Phong_ban"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_DepartmentID
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
            If tdbg(i, COL_Number).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("So_luong"))
                tdbg.SplitIndex = SPLIT0
                tdbg.Col = COL_Number
                tdbg.Bookmark = i
                tdbg.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    'Private Sub tdbg_BeforeColEdit(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColEditEventArgs) Handles tdbg.BeforeColEdit
    '    Select Case e.ColIndex
    '        Case COL_TeamID
    '            LoadtdbdTeamID(tdbg.Columns(COL_DepartmentID).Text)
    '    End Select
    'End Sub

    Private Sub tdbg_BeforeColUpdate(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbg.BeforeColUpdate
        Select Case e.ColIndex
            Case COL_DepartmentID
                If tdbg.Columns(COL_DepartmentID).Text <> tdbdDepartmentID.Columns("DepartmentID").Text Then
                    tdbg.Columns(COL_DepartmentID).Text = ""
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_TeamID
                If tdbg.Columns(COL_TeamID).Text <> tdbdTeamID.Columns("TeamID").Text Then
                    tdbg.Columns(COL_TeamID).Text = ""
                End If
            Case COL_PositionID
                If tdbg.Columns(COL_PositionID).Text <> tdbdPositionID.Columns("PositionID").Text Then
                    tdbg.Columns(COL_PositionID).Text = ""
                End If
            Case COL_Number
                If Not L3IsNumeric(tdbg.Columns(COL_Number).Text) Then e.Cancel = True
        End Select
    End Sub

    Private Sub tdbg_ComboSelect(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.ComboSelect
        Select Case e.ColIndex
            Case COL_DepartmentID
                tdbg.Columns(COL_DepartmentID).Text = tdbdDepartmentID.Columns("DepartmentID").Text
                tdbg.Columns(COL_TeamID).Text = ""
            Case COL_TeamID
                tdbg.Columns(COL_TeamID).Text = tdbdTeamID.Columns("TeamID").Text
            Case COL_PositionID
                tdbg.Columns(COL_PositionID).Text = tdbdPositionID.Columns("PositionID").Text
        End Select
    End Sub

    Private Sub tdbg_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Number
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD25T2081s
    '# Created User: DUCTRONG
    '# Created Date: 07/08/2008 09:46:46
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD25T2081s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim sTranID As String = ""
        Dim iCountIGE As Int32 = 0

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                iCountIGE += 1
            End If
        Next

        For i As Integer = 0 To tdbg.RowCount - 1
            If tdbg(i, COL_TransID).ToString = "" Then
                sTranID = CreateIGEs("D25T2081", "TransID", "25", "GP", gsStringKey, sTranID, iCountIGE)
                tdbg(i, COL_TransID) = sTranID
            End If
            sSQL.Append("Insert Into D25T2081(")
            sSQL.Append("TransID, GeneralPlanID, DivisionID, DepartmentID, TeamID, ")
            sSQL.Append("PositionID, Ref01, Ref02, Ref03, Ref04, ")
            sSQL.Append("Ref05, Ref06, Ref07, Ref08, Ref09, ")
            sSQL.Append("Ref10, Number, Note")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_TransID)) & COMMA) 'TransID, varchar[20], NOT NULL
            sSQL.Append(SQLString(_generalPlanID) & COMMA) 'GeneralPlanID, varchar[20], NOT NULL
            sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_DepartmentID)) & COMMA) 'DepartmentID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_TeamID)) & COMMA) 'TeamID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_PositionID)) & COMMA) 'PositionID, varchar[20], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref01)) & COMMA) 'Ref01, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref02)) & COMMA) 'Ref02, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref03)) & COMMA) 'Ref03, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref04)) & COMMA) 'Ref04, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref05)) & COMMA) 'Ref05, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref06)) & COMMA) 'Ref06, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref07)) & COMMA) 'Ref07, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref08)) & COMMA) 'Ref08, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref09)) & COMMA) 'Ref09, varchar[50], NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Ref10)) & COMMA) 'Ref10, varchar[50], NOT NULL
            sSQL.Append(SQLNumber(tdbg(i, COL_Number)) & COMMA) 'Number, int, NOT NULL
            sSQL.Append(SQLString(tdbg(i, COL_Note)))
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD25T2081
    '# Created User: DUCTRONG
    '# Created Date: 07/08/2008 09:48:07
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD25T2081() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D25T2081"
        sSQL &= " Where GeneralPlanID = " & SQLString(_generalPlanID)
        Return sSQL
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles tdbg.RowColChange
        Select Case tdbg.Col
            Case COL_TeamID
                LoadtdbdTeamID(tdbg.Columns(COL_DepartmentID).Text)
        End Select
    End Sub
End Class