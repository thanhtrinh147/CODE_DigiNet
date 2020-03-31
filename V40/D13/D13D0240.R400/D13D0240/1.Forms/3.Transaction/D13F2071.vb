Imports System.Windows.Forms
Imports System
Public Class D13F2071
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

#Region "Const of tdbg - Total of Columns: 3"
    Private Const COL_IsUsed As Integer = 0          ' Chọn
    Private Const COL_Description As Integer = 1     ' Diễn giải
    Private Const COL_SalaryVoucherID As Integer = 2 ' 
#End Region



    Dim sEditVoucherTypeID As String = ""
    Dim dtM, dtM_Temp As DataTable

    Dim bLoadFormState As Boolean = False
	Private _FormState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal value As EnumFormState)
	bLoadFormState = True
	LoadInfoGeneral()
            _FormState = value

            Select Case _FormState
                Case EnumFormState.FormAdd
                    LoadTdbc()
                    LoadDefault()
                    btnCalculate.Enabled = False

                Case EnumFormState.FormEdit
                    LoadEdit()

                Case EnumFormState.FormView
                    btnSave.Enabled = False
                    LoadEdit()
                    btnCalculate.Enabled = False
            End Select
        End Set
    End Property

    Private _IsCalculated As Boolean = False
    Public Property IsCalculated() As Boolean
        Get
            Return _IsCalculated
        End Get
        Set(ByVal Value As Boolean)
            _IsCalculated = Value
        End Set
    End Property

    Private _pITVoucherID As String = ""
    Public Property PITVoucherID() As String 
        Get
            Return _pITVoucherID
        End Get
        Set(ByVal Value As String )
            _pITVoucherID = Value
        End Set
    End Property

    Private Sub SetBackColorObligatory()
        tdbcVoucherTypeID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        c1dateVoucherDate.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtVoucherNo.BackColor = COLOR_BACKCOLOROBLIGATORY
        txtDescription.BackColor = COLOR_BACKCOLOROBLIGATORY

    End Sub


    Private Sub LoadDefault()
        tdbcPeriodFrom.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        tdbcPeriodTo.SelectedValue = giTranMonth.ToString("00") & "/" & giTranYear.ToString
        c1dateVoucherDate.Value = Now.Date
        LoadTdbg()
    End Sub

    Private Sub D13F2071_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F11
                HotKeyF11(Me, tdbg, 0, COL_IsUsed)

            Case Keys.Enter
                UseEnterAsTab(Me)
        End Select

        If e.Control = True Then
            Select Case e.KeyCode
                Case Keys.D1, Keys.NumPad1
                    tdbcVoucherTypeID.Focus()
                    'Case Keys.D2, Keys.NumPad2
                    '    tdbcGeneralIncomeCode.Focus()
            End Select
        End If
    End Sub

    Private Sub D13F2071_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	If bLoadFormState = False Then FormState = _formState
        SetBackColorObligatory()
        Loadlanguage()
        InputbyUnicode(Me, gbUnicode)
        CheckIdTextBox(txtVoucherNo)
        _bSaved = False
InputDateCustomFormat(c1dateVoucherDate)

    SetResolutionForm(Me)
Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Thiet_lap_chung_tu_khai_thue_-_D13F2071") & UnicodeCaption(gbUnicode) 'ThiÕt lËp ch÷ng tô khai thuÕ - D13F2071
        '================================================================ 
        lblteVoucherDate.Text = rl3("Ngay_phieu") 'Ngày phiếu
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblVoucherNo.Text = rl3("So_phieu") 'Số phiếu
        lblVoucherTypeID.Text = rl3("Loai_phieu") 'Loại phiếu
        lblPeriodFrom.Text = rL3("Tu_ky") 'Từ kỳ

        grp2.Text = 2 & ". " & rL3("Phieu_luong")
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        btnSave.Text = rl3("_Luu") '&Lưu
        btnCalculate.Text = rl3("_Tinh") '&Tính
        '================================================================ 
        GroupBox2.Text = "1. " & rl3("Chung_tu") 'Chứng từ

        '================================================================ 
        tdbcVoucherTypeID.Columns("VoucherTypeID").Caption = rl3("Ma") 'Mã
        tdbcVoucherTypeID.Columns("VoucherTypeName").Caption = rl3("Dien_giai") 'Diễn giải
       
        '================================================================ 
        tdbg.Columns(COL_IsUsed).Caption = rL3("Chon") 'Chọn
        tdbg.Columns(COL_Description).Caption = rL3("Phieu_luong") 'Phiếu lương

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2073
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 15/09/2009 02:42:51
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2073() As String
        Dim sSQL As String = ""

        Dim PeriodFrom As Integer
        Dim PeriodTo As Integer

        If tdbcPeriodFrom.Text <> "" Then
            PeriodFrom = L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
        Else
            PeriodFrom = 0
        End If

        If tdbcPeriodTo.Text <> "" Then
            PeriodTo = L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text)
        Else
            PeriodTo = 0
        End If

        sSQL &= "Exec D13P2073 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(PeriodFrom) & COMMA 'PeriodFrom, int, NOT NULL
        sSQL &= SQLNumber(PeriodTo) & COMMA 'PeriodTo, int, NOT NULL
        sSQL &= SQLString(_pITVoucherID) & COMMA 'PITVoucherID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Sub LoadTdbg()
        Dim PeriodFrom As Integer
        Dim PeriodTo As Integer

        If tdbcPeriodFrom.Text <> "" Then
            PeriodFrom = L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
        Else
            PeriodFrom = 0
        End If

        If tdbcPeriodTo.Text <> "" Then
            PeriodTo = L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text)
        Else
            PeriodTo = 0
        End If

        tdbg.UpdateData()
        dtM_Temp = ReturnDataTable(SQLStoreD13P2073())
        If dtM_Temp Is Nothing Then Exit Sub

        If dtM Is Nothing Then
            dtM = dtM_Temp.Copy
        Else
            SaveLastChoose(dtM, dtM_Temp, "SalaryVoucherID")
        End If

        LoadDataSource(tdbg, dtM, gbUnicode)
    End Sub

    Private Sub LoadEdit()
        Dim sSQL As New StringBuilder(701)
        sSQL.Append(" SELECT	D13.PITVoucherID, D13. PITVoucherNo, D13.VoucherTypeID," & vbCrLf)
        sSQL.Append(" D13.VoucherDate, D13.Description" & UnicodeJoin(gbUnicode) & " as Description, D13.PeriodFrom, D13.PeriodTo, " & vbCrLf)
        sSQL.Append(" D13.GeneralIncomeCode, D13. TaxableIncomeCode," & vbCrLf)
        sSQL.Append(" D13.TempPITCode," & vbCrLf)
        sSQL.Append(" D13.NumPersonCode" & vbCrLf)
        sSQL.Append(" FROM	D13T2070 D13" & vbCrLf)
        sSQL.Append(" WHERE	D13.DivisionID = " & SQLString(gsDivisionID) & vbCrLf)
        sSQL.Append(" And 		D13.TranMonth = " & SQLNumber(giTranMonth) & vbCrLf)
        sSQL.Append(" And 		D13.TranYear = " & SQLNumber(giTranYear) & vbCrLf)
        sSQL.Append(" And  		D13.PITVoucherID = " & SQLString(_pITVoucherID) & vbCrLf)

        Dim dtEdit As DataTable = ReturnDataTable(sSQL.ToString)
        If dtEdit.Rows.Count > 0 Then
            Dim dr As DataRow = dtEdit.Rows(0)
            sEditVoucherTypeID = dr("VoucherTypeID").ToString
            LoadTdbc()
            tdbcVoucherTypeID.Text = dr("VoucherTypeID").ToString
            txtVoucherNo.Text = dr("PITVoucherNo").ToString
            c1dateVoucherDate.Value = SQLDateShow(dr("VoucherDate"))
            txtDescription.Text = dr("Description").ToString
            tdbcPeriodFrom.SelectedValue = Strings.Right(dr("PeriodFrom").ToString, 2) & "/" & Strings.Left(dr("PeriodFrom").ToString, 4)
            tdbcPeriodTo.SelectedValue = Strings.Right(dr("PeriodTo").ToString, 2) & "/" & Strings.Left(dr("PeriodTo").ToString, 4)

            LoadTdbg()

          
        End If

        ReadOnlyControl(tdbcVoucherTypeID)
        ReadOnlyControl(txtVoucherNo)
        btnSetNewKey.Enabled = False

        If _IsCalculated Then
            'chỉ cho sửa Description
            ReadOnlyControl(c1dateVoucherDate)
            ReadOnlyControl(tdbcPeriodFrom)
            ReadOnlyControl(tdbcPeriodTo)
            

            tdbg.AllowUpdate = False
            tdbg.AllowDelete = False
            tdbg.AllowAddNew = False

            btnSetNewKey.Enabled = False
        End If

        btnCalculate.Enabled = ReturnPermission("D13F2070") > 1
    End Sub

    Private Sub SaveLastChoose(ByRef dt As DataTable, ByVal dtTemp As DataTable, ByVal sField As String)
        If dt Is Nothing Then Exit Sub

        Dim dt_copy As DataTable = ReturnTableFilter(dt, "IsUsed = True")

        For Each drTemp As DataRow In dtTemp.Rows
            Dim bDup As Boolean = False

            Dim dr() As DataRow
            dr = dt_copy.Select(sField & " = " & SQLString(drTemp(sField)))
            If dr.Length > 0 Then
                bDup = True
            End If

            If bDup = False Then
                dt_copy.ImportRow(drTemp)
            End If
        Next

        dt = dt_copy
    End Sub


    Private Sub LoadTdbc()
        Dim sSQL As String = ""
        'sSQL &= " Select 	VoucherTypeID , VoucherTypeName, " & vbCrLf
        'sSQL &= " 	Auto, S1Type, S1, S2Type, S2, S3Type, S3, OutputOrder, OutputLength, Separator" & vbCrLf
        'sSQL &= " 	From 	D91T0001" & vbCrLf
        'sSQL &= " 	Where 	Disabled = 0 and UseD13 = 1 " & vbCrLf
        'sSQL &= " 	Order by 	VoucherTypeID" & vbCrLf
        'LoadDataSource(tdbcVoucherTypeID, sSQL)
        LoadVoucherTypeID(tdbcVoucherTypeID, D13, sEditVoucherTypeID, gbUnicode)
        LoadCboPeriodReport(tdbcPeriodFrom, tdbcPeriodTo, "D09")
       
    End Sub

#Region "Events tdbcVoucherTypeID with txtVoucherNo"

    Private Sub tdbcVoucherTypeID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.Close
        If tdbcVoucherTypeID.FindStringExact(tdbcVoucherTypeID.Text) = -1 Then
            tdbcVoucherTypeID.Text = ""
            txtVoucherNo.Text = ""
            btnSetNewKey.Enabled = False
        End If
    End Sub

    Private Sub tdbcVoucherTypeID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcVoucherTypeID.SelectedValueChanged
        txtVoucherTypeName.Text = tdbcVoucherTypeID.Columns("VoucherTypeName").Text
        If _FormState = EnumFormState.FormAdd Then
            If Not (tdbcVoucherTypeID.Tag Is Nothing OrElse tdbcVoucherTypeID.Tag.ToString = "") Then
                tdbcVoucherTypeID.Tag = ""
                Exit Sub
            End If
            If tdbcVoucherTypeID.Text <> "" Then
                If tdbcVoucherTypeID.Columns("Auto").Text = "0" Then 'không tạo mã tự động
                    txtVoucherNo.ReadOnly = False
                    txtVoucherNo.TabStop = True
                    btnSetNewKey.Enabled = False
                    txtVoucherNo.Text = ""
                Else
                    gnNewLastKey = 0
                    txtVoucherNo.ReadOnly = True
                    txtVoucherNo.TabStop = False
                    btnSetNewKey.TabStop = False
                    btnSetNewKey.Enabled = True
                    txtVoucherNo.Text = CreateIGEVoucherNo(tdbcVoucherTypeID, False)
                End If
            End If
        End If

    End Sub

#End Region

#Region "Events tdbcPeriodFrom"

    Private Sub tdbcPeriodFrom_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.LostFocus
        If tdbcPeriodFrom.FindStringExact(tdbcPeriodFrom.Text) = -1 Then tdbcPeriodFrom.Text = ""
    End Sub
    Private Sub tdbcPeriodFrom_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodFrom.SelectedValueChanged
        If CheckExistForm(Me.Name) Then LoadTdbg()
    End Sub
#End Region

#Region "Events tdbcPeriodTo"

    Private Sub tdbcPeriodTo_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.LostFocus
        If tdbcPeriodTo.FindStringExact(tdbcPeriodTo.Text) = -1 Then tdbcPeriodTo.Text = ""
        'LoadTdbg()
    End Sub
    Private Sub tdbcPeriodTo_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPeriodTo.SelectedValueChanged
        If CheckExistForm(Me.Name) Then LoadTdbg()
    End Sub
#End Region

    Private Sub tdbc_BeforeOpen(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If CType(sender, C1.Win.C1List.C1Combo).Focused = False Then
            e.Cancel = True
        End If
    End Sub

    Private Sub tdbc_Close(ByVal sender As Object, ByVal e As System.EventArgs)
        tdbc_Validated(sender, Nothing)
    End Sub

    Private Sub tdbc_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.LimitToList = False
    End Sub

    Private Sub tdbc_Validated(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcVoucherTypeID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Loai_phieu"))
            tdbcVoucherTypeID.Focus()
            Return False
        End If

        If txtVoucherNo.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("So_phieu"))
            txtVoucherNo.Focus()
            Return False
        End If

        If c1dateVoucherDate.Value.ToString = "" Then
            D99C0008.MsgNotYetEnter(rl3("Ngay_phieu"))
            c1dateVoucherDate.Focus()
            Return False
        End If

        If txtDescription.Text.Trim = "" Then
            D99C0008.MsgNotYetEnter(rl3("Dien_giai"))
            txtDescription.Focus()
            Return False
        End If

        If tdbcPeriodFrom.Text <> "" And tdbcPeriodTo.Text <> "" Then
            Dim PFrom As Integer = L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
            Dim PTo As Integer = L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text)

            If PFrom > PTo Then
                D99C0008.MsgL3(rl3("Ky_tu_khong_duoc_lon_hon_ky_den"))
                tdbcPeriodFrom.Focus()
                Return False
            End If
        End If


        'Dim bChecked As Boolean = False
        Dim b As Integer
        For b = 0 To tdbg.RowCount - 1
            If CBool(tdbg(b, COL_IsUsed)) Then
                Exit For
            End If
        Next

        If b = tdbg.RowCount Then
            D99C0008.MsgNoDataInGrid()
            tdbg.Col = COL_IsUsed
            tdbg.Row = 0
            tdbg.Focus()
            Return False
        End If

        Dim sSQL As String = ""
        sSQL = SQLDeleteD09T6666()

        sSQL &= SQLInsertD09T6666s().ToString()

        Dim bRun As Boolean = False
        bRun = ExecuteSQL(sSQL)

        If bRun Then
            If Not CheckStore(SQLStoreD13P5555()) Then Return False
            sSQL = SQLDeleteD09T6666()
            ExecuteSQL(sSQL)
        End If
        'If tdbcGeneralIncomeCode.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Tong_thu_nhap_chiu_thue"))
        '    tdbcGeneralIncomeCode.Focus()
        '    Return False
        'End If

        'If tdbcTaxableIncomeCode.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Thu_nhap_tinh_thue"))
        '    tdbcTaxableIncomeCode.Focus()
        '    Return False
        'End If

        'If tdbcTempPITCode.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Thu_nhap_tam_khau_tru"))
        '    tdbcTempPITCode.Focus()
        '    Return False
        'End If

        'If tdbcNumPersonCode.Text.Trim = "" Then
        '    D99C0008.MsgNotYetChoose(rl3("Tong_so_nguoi_phu_thuoc_duoc_giam_tru"))
        '    tdbcNumPersonCode.Focus()
        '    Return False
        'End If


        'If tdbcGeneralIncomeCode.Text <> "" And (tdbcGeneralIncomeCode.Text = tdbcTaxableIncomeCode.Text Or tdbcGeneralIncomeCode.Text = tdbcTempPITCode.Text Or tdbcGeneralIncomeCode.Text = tdbcNumPersonCode.Text) Then
        '    D99C0008.MsgL3(rl3("Ban_phai_chon_gia_tri_khac"))
        '    tdbcGeneralIncomeCode.Focus()
        '    Return False
        'End If

        'If tdbcTaxableIncomeCode.Text <> "" And (tdbcTaxableIncomeCode.Text = tdbcTempPITCode.Text Or tdbcTaxableIncomeCode.Text = tdbcNumPersonCode.Text) Then
        '    D99C0008.MsgL3(rl3("Ban_phai_chon_gia_tri_khac"))
        '    tdbcTaxableIncomeCode.Focus()
        '    Return False
        'End If

        'If tdbcTempPITCode.Text <> "" And tdbcTempPITCode.Text = tdbcNumPersonCode.Text Then
        '    D99C0008.MsgL3(rl3("Ban_phai_chon_gia_tri_khac"))
        '    tdbcTempPITCode.Focus()
        '    Return False
        'End If

        Return True
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P5555
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/03/2015 10:46:04
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P5555() As String
        Dim sSQL As String = ""
        sSQL &= ("-- -Thuc thi kiem tra cac thiet lap he thong" & vbCrlf)
        sSQL &= "Exec D13P5555 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, tinyint, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, smallint, NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLNumber(0) & COMMA 'Mode, int, NOT NULL
        sSQL &= SQLString(Me.Name) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key01ID, varchar[50], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key02ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key03ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key04ID, varchar[20], NOT NULL
        sSQL &= SQLString("") & COMMA 'Key05ID, varchar[20], NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateFrom, datetime, NOT NULL
        sSQL &= SQLDateSave("") & COMMA 'DateTo, datetime, NOT NULL
        sSQL &= SQLNumber(0) 'Num01ID, int, NOT NULL
        Return sSQL
    End Function


    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD09T6666
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/03/2015 10:32:39
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD09T6666() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Delete D09T6666 " & vbCrlf)
        sSQL &= "Delete From D09T6666"
        sSQL &= " Where "
        sSQL &= "UserID = " & SQLString(gsUserID) & " And "
        sSQL &= "HostID = " & SQLString(My.Computer.Name) & " And "
        sSQL &= "FormID = " & SQLString(Me.Name)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD09T6666s
    '# Created User: Lê Anh Vũ
    '# Created Date: 09/03/2015 10:36:49
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD09T6666s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        Dim arrRow() As DataRow
        arrRow = dtM.Select("IsUsed = 1")

        For i As Integer = 0 To arrRow.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Insert vao bang tam D09T6666" & vbCrLf)
            sSQL.Append("Insert Into D09T6666(")
            sSQL.Append("UserID, HostID, Key01ID, FormID")
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(gsUserID) & COMMA) 'UserID, varchar[20], NOT NULL
            sSQL.Append(SQLString(My.Computer.Name) & COMMA) 'HostID, varchar[20], NOT NULL
            sSQL.Append(SQLStringUnicode(arrRow(i)("SalaryVoucherID"), gbUnicode, False) & COMMA) 'Key01ID, varchar[250], NOT NULL
            sSQL.Append(SQLString(Me.Name)) 'FormID, varchar[20], NOT NULL
            sSQL.Append(")")
            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function





    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T2074
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 20/08/2009 01:26:17
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T2074() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T2074"
        sSQL &= " Where "
        sSQL &= "PITVoucherID = " & SQLString(_pITVoucherID) & vbCrLf

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2074s
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 20/08/2009 01:27:12
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2074s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            If CBool(tdbg(i, COL_IsUsed)) Then
                sSQL.Append("Insert Into D13T2074(")
                sSQL.Append("PITVoucherID, SalaryVoucherID")
                sSQL.Append(") Values(")
                sSQL.Append(SQLString(_pITVoucherID) & COMMA) 'PITVoucherID [KEY], varchar[20], NOT NULL
                sSQL.Append(SQLString(tdbg(i, COL_SalaryVoucherID))) 'SalaryVoucherID [KEY], varchar[20], NOT NULL
                sSQL.Append(")")
                sRet.Append(sSQL.ToString & vbCrLf)
                sSQL.Remove(0, sSQL.Length)
            End If
        Next
        Return sRet
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T2070
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 20/08/2009 01:31:24
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T2070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Insert Into D13T2070(")
        sSQL.Append("VoucherTypeID, PITVoucherNo, VoucherDate, Description, DescriptionU, PITVoucherID, ")
        sSQL.Append("DivisionID, TranMonth, TranYear, ")
        sSQL.Append("PeriodFrom, PeriodTo, Calculated, ")
        sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
        sSQL.Append(") Values(")
        sSQL.Append(SQLString(tdbcVoucherTypeID.Text) & COMMA) 'VoucherTypeID, varchar[20], NOT NULL
        sSQL.Append(SQLString(txtVoucherNo.Text) & COMMA) 'PITVoucherNo, varchar[20], NOT NULL
        sSQL.Append(SQLDateSave(c1dateVoucherDate.Text) & COMMA) 'VoucherDate, datetime, NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'Description, varchar[250], NOT NULL
        sSQL.Append(SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'Description, varchar[250], NOT NULL

        sSQL.Append(SQLString(_pITVoucherID) & COMMA) 'PITVoucherID [KEY], varchar[20], NOT NULL
        sSQL.Append(SQLString(gsDivisionID) & COMMA) 'DivisionID, varchar[20], NOT NULL
        sSQL.Append(SQLNumber(giTranMonth) & COMMA) 'TranMonth, int, NOT NULL
        sSQL.Append(SQLNumber(giTranYear) & COMMA) 'TranYear, int, NOT NULL

        'Lê Anh Vũ: 09/03/2015 ID: 72542  bỏ lưu 4 field
        'sSQL.Append(SQLString(ComboValue(tdbcGeneralIncomeCode)) & COMMA) 'GeneralIncomeCode, varchar[20], NOT NULL
        'sSQL.Append(SQLString(ComboValue(tdbcTaxableIncomeCode)) & COMMA) 'TaxableIncomeCode, varchar[20], NOT NULL
        'sSQL.Append(SQLString(ComboValue(tdbcTempPITCode)) & COMMA) 'TempPITCode, varchar[20], NOT NULL
        'sSQL.Append(SQLString(ComboValue(tdbcNumPersonCode)) & COMMA) 'NumPersonCode, varchar[20], NOT NULL

        Dim iPeriodFrom As Integer = L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
        Dim iPeriodTo As Integer = L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text)

        sSQL.Append(SQLNumber(iPeriodFrom) & COMMA) 'PeriodFrom, int, NOT NULL
        sSQL.Append(SQLNumber(iPeriodTo) & COMMA) 'PeriodTo, int, NOT NULL
        sSQL.Append(SQLNumber(0) & COMMA) 'Calculated, tinyint, NOT NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
        sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[20], NOT NULL
        sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
        sSQL.Append(")" & vbCrLf)

        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLUpdateD13T2070
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 20/08/2009 01:31:40
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLUpdateD13T2070() As StringBuilder
        Dim sSQL As New StringBuilder
        sSQL.Append("Update D13T2070 Set ")

        'sSQL.Append("VoucherDate = " & SQLDateSave(?????) & COMMA) 'datetime, NULL
        sSQL.Append("Description = " & SQLStringUnicode(txtDescription.Text, gbUnicode, False) & COMMA) 'varchar[250], NOT NULL
        sSQL.Append("DescriptionU = " & SQLStringUnicode(txtDescription.Text, gbUnicode, True) & COMMA) 'varchar[250], NOT NULL

        'Lê Anh Vũ: 09/03/2015 ID: 72542  bỏ lưu 4 field
        'sSQL.Append("GeneralIncomeCode = " & SQLString(ComboValue(tdbcGeneralIncomeCode)) & COMMA) 'varchar[20], NOT NULL
        'sSQL.Append("TaxableIncomeCode = " & SQLString(ComboValue(tdbcTaxableIncomeCode)) & COMMA) 'varchar[20], NOT NULL
        'sSQL.Append("TempPITCode = " & SQLString(ComboValue(tdbcTempPITCode)) & COMMA) 'varchar[20], NOT NULL
        'sSQL.Append("NumPersonCode = " & SQLString(ComboValue(tdbcNumPersonCode)) & COMMA) 'varchar[20], NOT NULL

        Dim iPeriodFrom As Integer = L3Int(tdbcPeriodFrom.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodFrom.Columns("TranMonth").Text)
        Dim iPeriodTo As Integer = L3Int(tdbcPeriodTo.Columns("TranYear").Text) * 100 + L3Int(tdbcPeriodTo.Columns("TranMonth").Text)

        sSQL.Append("PeriodFrom = " & SQLNumber(iPeriodFrom) & COMMA) 'int, NOT NULL
        sSQL.Append("PeriodTo = " & SQLNumber(iPeriodTo) & COMMA) 'int, NOT NULL
        'sSQL.Append("Calculated = " & SQLNumber(?????) & COMMA) 'tinyint, NOT NULL
        sSQL.Append("LastModifyUserID = " & SQLString(gsUserID) & COMMA) 'varchar[20], NOT NULL
        sSQL.Append("LastModifyDate = GetDate()") 'datetime, NULL
        sSQL.Append(" Where ")
        sSQL.Append("PITVoucherID = " & SQLString(_pITVoucherID))

        Return sSQL
    End Function


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub

        'Kiểm tra Ngày phiếu có phù hợp với kỳ kế toán hiện tại không (gọi hàm CheckVoucherDateInPeriod)
        If Not CheckVoucherDateInPeriod(c1dateVoucherDate.Value.ToString) Then Exit Sub
        btnSave.Enabled = False
        btnClose.Enabled = False
        _bSaved = False
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder
        Select Case _FormState
            Case EnumFormState.FormAdd
                _pITVoucherID = CreateIGE("D13T2070", "PITVoucherID", "13", "PT", gsStringKey)
                sSQL.Append(SQLInsertD13T2070)
                sSQL.Append(SQLInsertD13T2074s)

                If CInt(tdbcVoucherTypeID.Columns("Auto").Text) <> 0 Then ' Tạo mã tự động
                    CreateIGEVoucherNo(tdbcVoucherTypeID, True)
                End If
                'Kiểm tra trùng phiếu 
                If CheckDuplicateVoucherNo(D13, "D13T2070", _pITVoucherID, txtVoucherNo.Text) Then
                    Me.Cursor = Cursors.Default
                    btnSave.Enabled = True
                    btnClose.Enabled = True
                    btnSetNewKey.Focus()
                    Exit Sub
                End If

            Case EnumFormState.FormEdit
                sSQL.Append(SQLUpdateD13T2070)
                sSQL.Append(SQLDeleteD13T2074)
                sSQL.Append(SQLInsertD13T2074s)

        End Select

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default

        If bRunSQL Then
            _bSaved = True
            SaveOK()
            btnClose.Enabled = True
            Select Case _FormState
                Case EnumFormState.FormAdd
                    btnCalculate.Enabled = True
                    btnClose.Focus()
                Case EnumFormState.FormEdit
                    RunAuditLog(AuditCodePITVoucher, "02", c1dateVoucherDate.Text, txtVoucherNo.Text, txtDescription.Text)
                    btnSave.Enabled = True
                    btnClose.Focus()
            End Select
        Else
            SaveNotOK()
            btnClose.Enabled = True
            btnSave.Enabled = True
        End If
    End Sub

    Dim bHeadClick As Boolean = False

    Private Sub tdbg_AfterColUpdate(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        Select Case e.ColIndex
            Case COL_IsUsed
                UpdateChooseColumn(dtM, "SalaryVoucherID", tdbg.Columns(COL_SalaryVoucherID).Text, CBool(tdbg.Columns(COL_IsUsed).Text))
        End Select
    End Sub

    Private Sub UpdateChooseColumn(ByRef dtX As DataTable, ByVal sFieldName As String, ByVal sKey As String, ByVal bChoose As Boolean)
        For Each dr As DataRow In dtX.Rows
            If dr(sFieldName).ToString = sKey Then
                dr.BeginEdit()
                dr("IsUsed") = bChoose
                dr.EndEdit()
                Exit For
            End If
        Next
    End Sub

    Private Sub tdbg_HeadClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.HeadClick
        Select Case e.ColIndex
            Case COL_IsUsed
                tdbg.AllowSort = False
                bHeadClick = Not bHeadClick
                For Each dr As DataRow In dtM.Rows
                    dr("IsUsed") = bHeadClick
                Next
                LoadDataSource(tdbg, dtM, gbUnicode)

            Case Else
                tdbg.AllowSort = True
        End Select
    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Dim sSQL As String = ""
        sSQL &= " Select 	1 " & vbCrLf
        sSQL &= " From 	D13T2070  WITH (NOLOCK) " & vbCrLf
        sSQL &= " Where 	PITVoucherID = " & SQLString(_pITVoucherID) & vbCrLf
        sSQL &= " And 	Calculated = 1 " & vbCrLf

        If ExistRecord(sSQL) Then
            'If D99C0008.MsgAsk(rl3("Phieu_nay_da_duoc_tinh_Ban_co_muon_tinh_lai_khong_")) = Windows.Forms.DialogResult.Yes Then
            If ExistRecord("Select Top 1 1 From D13T2084  WITH (NOLOCK) Where PITVoucherID = " & SQLString(_pITVoucherID)) Then
                D99C0008.MsgL3(rl3("Phieu_nay_da_duoc_su_dung_Ban_khong_the_tinh_lai"))
                Exit Sub
            End If
            sSQL = SQLStoreD13P2072()
            sSQL &= SQLStoreD13P2071()
            'Else
            '    Exit Sub
            'End If
        Else
            sSQL = SQLStoreD13P2071()
        End If

        If ExecuteSQL(sSQL) Then
            RunAuditLog(AuditCodePITVoucher, "02", c1dateVoucherDate.Text, txtVoucherNo.Text, txtDescription.Text)
            _bSaved = True
            D99C0008.MsgL3(rl3("Du_lieu_da_duoc_tinh_thanh_cong"))

            Dim f As New D13F2072
            f.PITVoucherID = _pITVoucherID
            f.ShowDialog()
            f.Dispose()

        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2071
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/08/2009 10:28:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2071() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2071 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_pITVoucherID) 'PITVoucherID, varchar[20], NOT NULL
        Return sSQL & vbCrLf
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P2072
    '# Created User: Đỗ Minh Dũng
    '# Created Date: 19/08/2009 10:28:28
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P2072() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P2072 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLNumber(giTranMonth) & COMMA 'TranMonth, int, NOT NULL
        sSQL &= SQLNumber(giTranYear) & COMMA 'TranYear, int, NOT NULL
        sSQL &= SQLString(_pITVoucherID) 'PITVoucherID, varchar[20], NOT NULL
        Return sSQL & vbCrLf
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSetNewKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetNewKey.Click
        GetNewVoucherNo(tdbcVoucherTypeID, txtVoucherNo)
    End Sub
End Class