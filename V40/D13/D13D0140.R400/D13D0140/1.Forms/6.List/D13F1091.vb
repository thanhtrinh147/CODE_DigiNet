Imports System.Text
Public Class D13F1091
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property


#Region "Const of tdbgDetail"
    Private Const COL_PAnaID As Integer = 0    ' Mã
    Private Const COL_PAnaName As Integer = 1  ' Diễn giải
    Private Const COL_Amount01 As Integer = 2  ' Giá trị 01
    Private Const COL_Amount02 As Integer = 3  ' Giá trị 02
    Private Const COL_Amount03 As Integer = 4  ' Giá trị 03
    Private Const COL_Amount04 As Integer = 5  ' Giá trị 04
    Private Const COL_Amount05 As Integer = 6  ' Giá trị 05
    Private Const COL_Amount06 As Integer = 7  ' Giá trị 06
    Private Const COL_Amount07 As Integer = 8  ' Giá trị 07
    Private Const COL_Amount08 As Integer = 9  ' Giá trị 08
    Private Const COL_Amount09 As Integer = 10 ' Giá trị 09
    Private Const COL_Amount10 As Integer = 11 ' Giá trị 10
    Private Const COL_Disabled As Integer = 12 ' Không sử dụng
#End Region


    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit
                    LoadEdit()
                Case EnumFormState.FormView
                    LoadEdit()
                    btnSave.Enabled = False
            End Select
        End Set
    End Property

    Private _PAnaCategoryID As String = ""
    Public Property PAnaCategoryID() As String
        Get
            Return _PAnaCategoryID
        End Get
        Set(ByVal value As String)
            If PAnaCategoryID = value Then
                _PAnaCategoryID = ""
            End If
            _PAnaCategoryID = value
        End Set
    End Property

    Private _PAnaCategoryName01 As String = ""
    Public Property PAnaCategoryName01() As String
        Get
            Return _PAnaCategoryName01
        End Get
        Set(ByVal value As String)
            If PAnaCategoryName01 = value Then
                _PAnaCategoryName01 = ""
            End If
            _PAnaCategoryName01 = value
        End Set
    End Property

    Private _PAnaCategoryName84 As String = ""
    Public Property PAnaCategoryName84() As String
        Get
            Return _PAnaCategoryName84
        End Get
        Set(ByVal value As String)
            If PAnaCategoryName01 = value Then
                _PAnaCategoryName84 = ""
            End If
            _PAnaCategoryName84 = value
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        txtPAnaCategoryID.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPAnaCategoryName01.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtPAnaCategoryName84.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub tdbgDetail_NumberFormat()
        tdbgDetail.Columns(COL_Amount01).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount02).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount03).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount04).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount05).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount06).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount07).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount08).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount09).NumberFormat = D13Format.DefaultNumber2
        tdbgDetail.Columns(COL_Amount10).NumberFormat = D13Format.DefaultNumber2
    End Sub

    Private Sub D13F1091_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        SetBackColorObligatory()
        tdbgDetail_NumberFormat()
        Loadlanguage()
        UnicodeGridDataField(tdbgDetail, COL_PAnaName, gbUnicode)
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Cap_nhat_ma_phan_tich_tien_luong_-_D13F1091") & UnicodeCaption(gbUnicode) 'CËp nhËt mº ph¡n tÛch tiÒn l§¥ng - D13F1091
        '================================================================ 
        lblPAnaCategoryID.Text = rl3("Ma_loai_phan_tich") 'Mã loại phân tích
        lblPAnaCategoryName01.Text = rl3("Ten_loai_phan_tich") 'Tên loại phân tích
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbgDetail.Columns("PAnaID").Caption = rl3("Ma") 'Mã
        tdbgDetail.Columns("PAnaName").Caption = rl3("Dien_giai") 'Diễn giải
        tdbgDetail.Columns("Amount01").Caption = rl3("Gia_tri_01") 'Giá trị 01
        tdbgDetail.Columns("Amount02").Caption = rl3("Gia_tri_02") 'Giá trị 02
        tdbgDetail.Columns("Amount03").Caption = rl3("Gia_tri_03") 'Giá trị 03
        tdbgDetail.Columns("Amount04").Caption = rl3("Gia_tri_04") 'Giá trị 04
        tdbgDetail.Columns("Amount05").Caption = rl3("Gia_tri_05") 'Giá trị 05
        tdbgDetail.Columns("Amount06").Caption = rl3("Gia_tri_06") 'Giá trị 06
        tdbgDetail.Columns("Amount07").Caption = rl3("Gia_tri_07") 'Giá trị 07
        tdbgDetail.Columns("Amount08").Caption = rl3("Gia_tri_08") 'Giá trị 08
        tdbgDetail.Columns("Amount09").Caption = rl3("Gia_tri_09") 'Giá trị 09
        tdbgDetail.Columns("Amount10").Caption = rl3("Gia_tri_10") 'Giá trị 10
        tdbgDetail.Columns("Disabled").Caption = rl3("Khong_su_dung") 'Không sử dụng
    End Sub


    Private Sub LoadEdit()
        txtPAnaCategoryID.Enabled = False
        txtPAnaCategoryName01.Enabled = False
        txtPAnaCategoryName84.Enabled = False
        LoadMaster()
        LoadDetail()
        If gsLanguage = "84" Then
            txtPAnaCategoryName01.Visible = False
            txtPAnaCategoryName84.Visible = True
        ElseIf gsLanguage = "01" Then
            txtPAnaCategoryName01.Visible = True
            txtPAnaCategoryName84.Visible = False
        End If
    End Sub

    Private Sub LoadMaster()
        txtPAnaCategoryID.Text = _PAnaCategoryID.ToString
        txtPAnaCategoryName01.Text = _PAnaCategoryName01.ToString
        txtPAnaCategoryName84.Text = _PAnaCategoryName84.ToString
    End Sub

    Private Sub LoadDetail()
        Dim sSQL As String = ""
        sSQL = SQLSLoadD13T1050()
        LoadDataSource(tdbgDetail, sSQL, gbUnicode)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        tdbgDetail.UpdateData()
        If Not AllowSave() Then Exit Sub

        _bSaved = False
        btnSave.Enabled = False
        btnClose.Enabled = False

        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
            Case EnumFormState.FormEdit
                sSQL.Append(SQLDeleteD13T0150().ToString & vbCrLf)
                sSQL.Append(SQLInsertD13T1050s().ToString & vbCrLf)
        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            SaveOK()
            btnClose.Enabled = True
            _bSaved = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                Case EnumFormState.FormEdit

                    'Audit Log
                    Dim sDesc1 As String = txtPAnaCategoryID.Text
                    Dim sDesc2 As String = txtPAnaCategoryName84.Text
                    Dim sDesc3 As String = txtPAnaCategoryName01.Text
                    Dim sDesc4 As String = ""
                    Dim sDesc5 As String = ""
                    RunAuditLog(AuditCodePayrollAnalCode, "02", sDesc1, sDesc2, sDesc3, sDesc4, sDesc5)

                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Private Function AllowSave() As Boolean
        If tdbgDetail.RowCount <= 0 Then
            D99C0008.MsgNoDataInGrid()
            tdbgDetail.Focus()
            Return False
        End If
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            If tdbgDetail(i, COL_PAnaID).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Ma"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COL_PAnaID
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If
            If tdbgDetail(i, COL_PAnaName).ToString = "" Then
                D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
                tdbgDetail.SplitIndex = SPLIT0
                tdbgDetail.Col = COL_PAnaName
                tdbgDetail.Bookmark = i
                tdbgDetail.Focus()
                Return False
            End If
        Next
        Return True
    End Function

    Private Function SQLSLoadD13T1050() As String
        Dim sSQL As String = ""
        sSQL &= " SELECT PAnaID, PAnaName, PAnaNameU,"
        sSQL &= " Disabled,"
        sSQL &= " Amount01, Amount02, Amount03, Amount04, Amount05,"
        sSQL &= " Amount06, Amount07, Amount08, Amount09, Amount10"
        sSQL &= " FROM D13T1050 WITH (NOLOCK) "
        sSQL &= " WHERE PAnaCategoryID = " & SQLString(_PAnaCategoryID.ToString)
        sSQL &= " ORDER BY PAnaID"
        Return sSQL
    End Function

    Private Function SQLDeleteD13T0150() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1050"
        sSQL &= " Where"
        sSQL &= " PAnaCategoryID = " & SQLString(_PAnaCategoryID) & vbCrLf
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1050s
    '# Created User: 
    '# Created Date: 16/11/2007 11:17:49
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1050s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbgDetail.RowCount - 1
            sSQL.Append("Insert Into D13T1050(")
            sSQL.Append("PAnaID, PAnaCategoryID, PAnaName, PAnaNameU, Disabled, Amount01, ")
            sSQL.Append("Amount02, Amount03, Amount04, Amount05, Amount06, ")
            sSQL.Append("Amount07, Amount08, Amount09, Amount10, CreateUserID, ")
            sSQL.Append("CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbgDetail(i, COL_PAnaID)) & COMMA) 'PAnaID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLString(_PAnaCategoryID) & COMMA) 'PAnaCategoryID [KEY], varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgDetail(i, COL_PAnaName), gbUnicode, False) & COMMA) 'PAnaName, varchar[250], NOT NULL
            sSQL.Append(SQLStringUnicode(tdbgDetail(i, COL_PAnaName), gbUnicode, True) & COMMA) 'PAnaName, varchar[250], NOT NULL
            sSQL.Append(SQLNumber(tdbgDetail(i, COL_Disabled)) & COMMA) 'Disabled, tinyint, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount01)) & COMMA) 'Amount01, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount02)) & COMMA) 'Amount02, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount03)) & COMMA) 'Amount03, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount04)) & COMMA) 'Amount04, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount05)) & COMMA) 'Amount05, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount06)) & COMMA) 'Amount06, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount07)) & COMMA) 'Amount07, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount08)) & COMMA) 'Amount08, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount09)) & COMMA) 'Amount09, decimal, NOT NULL
            sSQL.Append(SQLMoney(tdbgDetail(i, COL_Amount10)) & COMMA) 'Amount10, decimal, NOT NULL
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbgDetail_BeforeColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.BeforeColUpdateEventArgs) Handles tdbgDetail.BeforeColUpdate
        If Exits(tdbgDetail.Columns(COL_PAnaID).Text, tdbgDetail.Bookmark) Then
            D99C0008.MsgL3(rl3("Ma_da_su_dung_roi"))
            tdbgDetail.Columns(COL_PAnaID).Text = ""
        End If

        Select Case e.ColIndex
            Case COL_PAnaID
                e.Cancel = L3IsID(tdbgDetail, e.ColIndex)
        End Select
    End Sub

    Private Function Exits(ByVal ref As String, ByVal nRow As Int32) As Boolean
        For i As Integer = 0 To tdbgDetail.RowCount - 1

            If i <> nRow And tdbgDetail.Item(i, COL_PAnaID).ToString = ref Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub tdbgDetail_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbgDetail.KeyPress
        Select Case tdbgDetail.Col
            Case COL_Amount01
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount02
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount03
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount04
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount05
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount06
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount07
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount08
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount09
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_Amount10
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
            Case COL_PAnaID
                e.KeyChar = UCase(e.KeyChar) 'Nhập các ký tự hoa

        End Select
    End Sub


End Class