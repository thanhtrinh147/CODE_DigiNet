Imports System
Public Class D13F2044

#Region "Const of tdbg"
    Private Const COL_IsCheck As Integer = 0      ' Đã kiểm tra
    Private Const COL_DepartmentID As Integer = 1 ' Phòng ban
    Private Const COL_TeamID As Integer = 2       ' Tổ nhóm
    Private Const COL_EmployeeID As Integer = 3   ' Mã NV
    Private Const COL_FullName As Integer = 4     ' Tên nhân viên
    Private Const COL_Note As Integer = 5         ' Ghi chú
#End Region

    Private _salaryVoucherID As String = ""
    Public Property SalaryVoucherID() As String
        Get
            Return _salaryVoucherID
        End Get
        Set(ByVal Value As String)
            _salaryVoucherID = value
        End Set
    End Property

    Private dtDataTable As New DataTable
    Public Property GetDataTable() As DataTable
        Get
            Return dtDataTable
        End Get
        Set(ByVal value As DataTable)
            If dtDataTable Is value Then
                Return
            End If
            dtDataTable = value
        End Set
    End Property

    Private Sub D13F2044_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetSplitDividerSize(tdbg)
        ResetFooterGrid(tdbg)
        tdbg_LockedColumns()
        LoadTDBGrid()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Kiem_tra_bang_luong_-_D13F2044") 'KiÓm tra b¶ng l§¥ng - D13F2044
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("IsCheck").Caption = rl3("Da_kiem_tra") 'Đã kiểm tra
        tdbg.Columns("DepartmentID").Caption = rl3("Phong_ban") 'Phòng ban
        tdbg.Columns("TeamID").Caption = rl3("To_nhom") 'Tổ nhóm
        tdbg.Columns("EmployeeID").Caption = rl3("Ma_NV") 'Mã NV
        tdbg.Columns("FullName").Caption = rl3("Ten_nhan_vien") 'Tên nhân viên
        tdbg.Columns("Note").Caption = rl3("Ghi_chu") 'Ghi chú
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = COL_DepartmentID To COL_FullName
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns(i).Locked = True
        Next
    End Sub

    Private Sub LoadTDBGrid()
        LoadDataSource(tdbg, dtDataTable)
        FooterTotalGrid(tdbg, COL_FullName)
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsCheck
                Dim bCheck As Boolean = CBool(tdbg(0, COL_IsCheck))
                For i As Integer = 0 To tdbg.RowCount - 1
                    tdbg(i, COL_IsCheck) = Not bCheck
                Next i
            Case COL_Note
                CopyColumns(tdbg, tdbg.Col, tdbg.Columns(tdbg.Col).Text, tdbg.Row)
        End Select
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        sSQL.Append(SQLUpdateD13T2601s)

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2601s
    '# Created User: DUCTRONG
    '# Created Date: 16/02/2009 11:56:19
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2601s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Update D13T2601 Set ")
            sSQL.Append("IsCheck = " & SQLNumber(tdbg(i, COL_IsCheck)) & COMMA) 'tinyint, NOT NULL
            sSQL.Append("Note = " & SQLString(tdbg(i, COL_Note))) 'varchar[500], NOT NULL
            sSQL.Append(" Where ")
            sSQL.Append("SalaryVoucherID = " & SQLString(_salaryVoucherID) & " And ")
            sSQL.Append("EmployeeID = " & SQLString(tdbg(i, COL_EmployeeID)))
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

End Class