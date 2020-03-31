Imports System
Public Class D13F1110
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

	Private _formIDPermission As String = "D13F1110"
	Public WriteOnly Property FormIDPermission() As String
		Set(ByVal Value As String)
			       _formIDPermission = Value
		   End Set
	End Property


    '#Region "Const of tdbg - Total of Columns: 58"
    '    Private Const COL_DivisionID As String = "DivisionID"             ' Mã đơn vị
    '    Private Const COL_TypeID As String = "TypeID"                     ' TypeID
    '    Private Const COL_TypeName As String = "TypeName"                 ' TypeName
    '    Private Const COL_CreateUserID As String = "CreateUserID"         ' Người tạo
    '    Private Const COL_CreateDate As String = "CreateDate"             ' Ngày tạo
    '    Private Const COL_LastModifyUserID As String = "LastModifyUserID" ' Người cập nhật cuối cùng
    '    Private Const COL_LastModifyDate As String = "LastModifyDate"     ' Ngày cập nhật cuối cùng
    '    Private Const COL_Coefficient01 As String = "Coefficient01"       ' Hệ số 01
    '    Private Const COL_Coefficient02 As String = "Coefficient02"       ' Hệ số 02
    '    Private Const COL_Coefficient03 As String = "Coefficient03"       ' Hệ số 03
    '    Private Const COL_Coefficient04 As String = "Coefficient04"       ' Hệ số 04
    '    Private Const COL_Coefficient05 As String = "Coefficient05"       ' Hệ số 05
    '    Private Const COL_Coefficient06 As String = "Coefficient06"       ' Hệ số 06
    '    Private Const COL_Coefficient07 As String = "Coefficient07"       ' Hệ số 07
    '    Private Const COL_Coefficient08 As String = "Coefficient08"       ' Hệ số 08
    '    Private Const COL_Coefficient09 As String = "Coefficient09"       ' Hệ số 09
    '    Private Const COL_Coefficient10 As String = "Coefficient10"       ' Hệ số 10
    '    Private Const COL_Coefficient11 As String = "Coefficient11"       ' Coefficient11
    '    Private Const COL_Coefficient12 As String = "Coefficient12"       ' Coefficient12
    '    Private Const COL_Coefficient13 As String = "Coefficient13"       ' Coefficient13
    '    Private Const COL_Coefficient14 As String = "Coefficient14"       ' Coefficient14
    '    Private Const COL_Coefficient15 As String = "Coefficient15"       ' Coefficient15
    '    Private Const COL_Coefficient16 As String = "Coefficient16"       ' Coefficient16
    '    Private Const COL_Coefficient17 As String = "Coefficient17"       ' Coefficient17
    '    Private Const COL_Coefficient18 As String = "Coefficient18"       ' Coefficient18
    '    Private Const COL_Coefficient19 As String = "Coefficient19"       ' Coefficient19
    '    Private Const COL_Coefficient20 As String = "Coefficient20"       ' Coefficient20
    '    Private Const COL_Coefficient21 As String = "Coefficient21"       ' Coefficient21
    '    Private Const COL_Coefficient22 As String = "Coefficient22"       ' Coefficient22
    '    Private Const COL_Coefficient23 As String = "Coefficient23"       ' Coefficient23
    '    Private Const COL_Coefficient24 As String = "Coefficient24"       ' Coefficient24
    '    Private Const COL_Coefficient25 As String = "Coefficient25"       ' Coefficient25
    '    Private Const COL_Coefficient26 As String = "Coefficient26"       ' Coefficient26
    '    Private Const COL_Coefficient27 As String = "Coefficient27"       ' Coefficient27
    '    Private Const COL_Coefficient28 As String = "Coefficient28"       ' Coefficient28
    '    Private Const COL_Coefficient29 As String = "Coefficient29"       ' Coefficient29
    '    Private Const COL_Coefficient30 As String = "Coefficient30"       ' Coefficient30
    '    Private Const COL_Coefficient31 As String = "Coefficient31"       ' Coefficient31
    '    Private Const COL_Coefficient32 As String = "Coefficient32"       ' Coefficient32
    '    Private Const COL_Coefficient33 As String = "Coefficient33"       ' Coefficient33
    '    Private Const COL_Coefficient34 As String = "Coefficient34"       ' Coefficient34
    '    Private Const COL_Coefficient35 As String = "Coefficient35"       ' Coefficient35
    '    Private Const COL_Coefficient36 As String = "Coefficient36"       ' Coefficient36
    '    Private Const COL_Coefficient37 As String = "Coefficient37"       ' Coefficient37
    '    Private Const COL_Coefficient38 As String = "Coefficient38"       ' Coefficient38
    '    Private Const COL_Coefficient39 As String = "Coefficient39"       ' Coefficient39
    '    Private Const COL_Coefficient40 As String = "Coefficient40"       ' Coefficient40
    '    Private Const COL_Coefficient41 As String = "Coefficient41"       ' Coefficient41
    '    Private Const COL_Coefficient42 As String = "Coefficient42"       ' Coefficient42
    '    Private Const COL_Coefficient43 As String = "Coefficient43"       ' Coefficient43
    '    Private Const COL_Coefficient44 As String = "Coefficient44"       ' Coefficient44
    '    Private Const COL_Coefficient45 As String = "Coefficient45"       ' Coefficient45
    '    Private Const COL_Coefficient46 As String = "Coefficient46"       ' Coefficient46
    '    Private Const COL_Coefficient47 As String = "Coefficient47"       ' Coefficient47
    '    Private Const COL_Coefficient48 As String = "Coefficient48"       ' Coefficient48
    '    Private Const COL_Coefficient49 As String = "Coefficient49"       ' Coefficient49
    '    Private Const COL_Coefficient50 As String = "Coefficient50"       ' Coefficient50
    '    Private Const COL_Type As String = "Type"                         ' Mã
    '#End Region


#Region "Const of tdbg - Total of Columns: 59"
    Private Const COL_DivisionID As String = "DivisionID"             ' Mã đơn vị
    Private Const COL_TypeID As String = "TypeID"                     ' TypeID
    Private Const COL_TypeName As String = "TypeName"                 ' TypeName
    Private Const COL_CreateUserID As String = "CreateUserID"         ' Người tạo
    Private Const COL_CreateDate As String = "CreateDate"             ' Ngày tạo
    Private Const COL_LastModifyUserID As String = "LastModifyUserID" ' Người cập nhật cuối cùng
    Private Const COL_LastModifyDate As String = "LastModifyDate"     ' Ngày cập nhật cuối cùng
    Private Const COL_Coefficient01 As String = "Coefficient01"       ' Hệ số 01
    Private Const COL_Coefficient02 As String = "Coefficient02"       ' Hệ số 02
    Private Const COL_Coefficient03 As String = "Coefficient03"       ' Hệ số 03
    Private Const COL_Coefficient04 As String = "Coefficient04"       ' Hệ số 04
    Private Const COL_Coefficient05 As String = "Coefficient05"       ' Hệ số 05
    Private Const COL_Coefficient06 As String = "Coefficient06"       ' Hệ số 06
    Private Const COL_Coefficient07 As String = "Coefficient07"       ' Hệ số 07
    Private Const COL_Coefficient08 As String = "Coefficient08"       ' Hệ số 08
    Private Const COL_Coefficient09 As String = "Coefficient09"       ' Hệ số 09
    Private Const COL_Coefficient10 As String = "Coefficient10"       ' Hệ số 10
    Private Const COL_Coefficient11 As String = "Coefficient11"       ' Coefficient11
    Private Const COL_Coefficient12 As String = "Coefficient12"       ' Coefficient12
    Private Const COL_Coefficient13 As String = "Coefficient13"       ' Coefficient13
    Private Const COL_Coefficient14 As String = "Coefficient14"       ' Coefficient14
    Private Const COL_Coefficient15 As String = "Coefficient15"       ' Coefficient15
    Private Const COL_Coefficient16 As String = "Coefficient16"       ' Coefficient16
    Private Const COL_Coefficient17 As String = "Coefficient17"       ' Coefficient17
    Private Const COL_Coefficient18 As String = "Coefficient18"       ' Coefficient18
    Private Const COL_Coefficient19 As String = "Coefficient19"       ' Coefficient19
    Private Const COL_Coefficient20 As String = "Coefficient20"       ' Coefficient20
    Private Const COL_Coefficient21 As String = "Coefficient21"       ' Coefficient21
    Private Const COL_Coefficient22 As String = "Coefficient22"       ' Coefficient22
    Private Const COL_Coefficient23 As String = "Coefficient23"       ' Coefficient23
    Private Const COL_Coefficient24 As String = "Coefficient24"       ' Coefficient24
    Private Const COL_Coefficient25 As String = "Coefficient25"       ' Coefficient25
    Private Const COL_Coefficient26 As String = "Coefficient26"       ' Coefficient26
    Private Const COL_Coefficient27 As String = "Coefficient27"       ' Coefficient27
    Private Const COL_Coefficient28 As String = "Coefficient28"       ' Coefficient28
    Private Const COL_Coefficient29 As String = "Coefficient29"       ' Coefficient29
    Private Const COL_Coefficient30 As String = "Coefficient30"       ' Coefficient30
    Private Const COL_Coefficient31 As String = "Coefficient31"       ' Coefficient31
    Private Const COL_Coefficient32 As String = "Coefficient32"       ' Coefficient32
    Private Const COL_Coefficient33 As String = "Coefficient33"       ' Coefficient33
    Private Const COL_Coefficient34 As String = "Coefficient34"       ' Coefficient34
    Private Const COL_Coefficient35 As String = "Coefficient35"       ' Coefficient35
    Private Const COL_Coefficient36 As String = "Coefficient36"       ' Coefficient36
    Private Const COL_Coefficient37 As String = "Coefficient37"       ' Coefficient37
    Private Const COL_Coefficient38 As String = "Coefficient38"       ' Coefficient38
    Private Const COL_Coefficient39 As String = "Coefficient39"       ' Coefficient39
    Private Const COL_Coefficient40 As String = "Coefficient40"       ' Coefficient40
    Private Const COL_Coefficient41 As String = "Coefficient41"       ' Coefficient41
    Private Const COL_Coefficient42 As String = "Coefficient42"       ' Coefficient42
    Private Const COL_Coefficient43 As String = "Coefficient43"       ' Coefficient43
    Private Const COL_Coefficient44 As String = "Coefficient44"       ' Coefficient44
    Private Const COL_Coefficient45 As String = "Coefficient45"       ' Coefficient45
    Private Const COL_Coefficient46 As String = "Coefficient46"       ' Coefficient46
    Private Const COL_Coefficient47 As String = "Coefficient47"       ' Coefficient47
    Private Const COL_Coefficient48 As String = "Coefficient48"       ' Coefficient48
    Private Const COL_Coefficient49 As String = "Coefficient49"       ' Coefficient49
    Private Const COL_Coefficient50 As String = "Coefficient50"       ' Coefficient50
    Private Const COL_Type As String = "Type"                         ' Mã
    Private Const COL_IsUpdate As String = "IsUpdate"                 ' IsUpdate
#End Region



    Private _type As String = ""
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Private _divisionID As String = ""
    Public Property DivisionID() As String
        Get
            Return _divisionID
        End Get
        Set(ByVal Value As String)
            _divisionID = Value
        End Set
    End Property

    Private _typeID As String = ""
    Public Property TypeID() As String 
        Get
            Return _typeID
        End Get
        Set(ByVal Value As String )
            _typeID = Value
        End Set
    End Property

    Private _formState As EnumFormState
    Public WriteOnly Property FormState() As EnumFormState
        Set(ByVal Value As EnumFormState)
            _formState = Value
        End Set
    End Property

    Dim iLastCol As Integer = 0
    Dim iFirstCol As Integer = 0
    Dim bUseCoefficient As Boolean = False
    Dim bUnicode As Boolean = L3Bool(gbUnicode)

    Private dtGrid As DataTable

    Private Sub D13F1110_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub

    Private Sub D13F1110_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        '        If _type.ToUpper = "D91T0012" Then _divisionID = gsDivisionID
        '        If _type.ToUpper = "D09T2224" Then tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Visible = False
        btnSave.Enabled = ReturnPermission(_formIDPermission) >= 2 And _FormState <> EnumFormState.FormView
        _bSaved = False
        ResetColorGrid(tdbg)
        tdbg_LockedColumns()

     

        gbEnabledUseFind = False
        Loadlanguage()
        UnicodeGridDataField(tdbg, COL_TypeName, bUnicode)
        If _type.ToUpper = "D09T0211" Then
            CallFromD09F0290()
            LoadTDBGrid("%", True)

        Else
            tdbcDutyID.Visible = False
            lblDutyID.Visible = False
            tdbg.Height = tdbg.Height + (tdbg.Top - tdbcDutyID.Top)
            tdbg.Top = tdbcDutyID.Top
            LoadTDBGrid(_typeID)
        End If

        LoadCationCoefficient() 'Load caption Hệ số
        InputDateInTrueDBGrid(tdbg, COL_CreateDate, COL_LastModifyDate)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CallFromD09F0290()
        LoadTDBCombo()
        tdbcDutyID.SelectedValue = _typeID
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        sSQL = "--Do nguon combo Chuc Vu" & vbCrLf & _
              "  SELECT  	'%' as DutyID," & AllCode & " as DutyName, 0 As DisplayOrder " & vbCrLf & _
                " UNION ALL " & vbCrLf & _
                " SELECT      DutyID, DutyNameU as DutyName, 1 As DisplayOrder " & vbCrLf & _
                " FROM        D09T0211 WITH(NOLOCK)  WHERE Disabled = 0 " & vbCrLf & _
                " ORDER BY    DisplayOrder, DutyName"
        LoadDataSource(tdbcDutyID, sSQL, gbUnicode)
    End Sub

    Private Sub tdbg_LockedColumns()
        For i As Integer = IndexOfColumn(tdbg, COL_DivisionID) To IndexOfColumn(tdbg, COL_LastModifyDate)
            tdbg.Splits(SPLIT0).DisplayColumns(i).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
            tdbg.Splits(SPLIT0).DisplayColumns.Item(i).Locked = True
        Next
    End Sub

    Private Sub VisibleColumn()
        Select Case _type.ToUpper
            Case "D91T0012"
                _divisionID = gsDivisionID
            Case "D91T0012"
                tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Visible = False
            Case "D09T1080" ' UPDATE 12/6/2013 ID 56277
                tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Visible = False
        End Select
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Select Case _type.ToUpper
            Case "D91T0012"
                Me.Text = rl3("Thiet_lap_he_so_phong_ban")
            Case "D09T0211"
                Me.Text = rl3("Thiet_lap_he_so_chuc_vu")
            Case "D13T0118"
                'Me.Text = rl3("Thiet_lap_he_so_loai_cham_cong")
                Me.Text = rl3("Thiet_lap_he_so_khoan_dieu_chinh_thu_nhapW")
            Case "D39T1000"
                Me.Text = rl3("Thiet_lap_he_so_chi_tieu_danh_gia")
            Case "D29T1070"
                Me.Text = rl3("Thiet_lap_he_so_cham_cong")

            Case "D45T1010"
                Me.Text = rl3("Thiet_lap_he_so_cong_doan")
            Case "D09T0224"
                Me.Text = rl3("Thiet_lap_he_so_cong_viec")
            Case "D09T1080" ' UPDATE 12/6/2013 ID 56277
                Me.Text = rL3("Thiet_lap_he_so_du_an") '  Thiết lập hệ số dự án
            Case "D91T0016" ' UPDATE 12/6/2013 ID 56277
                Me.Text = rL3("Thiet_lap_he_so_don_vi") 'Thiết lập hệ số đơn vị
            Case "D09T0227" ' 21.04.2017 ID 96045 
                Me.Text = rL3("Thiet_lap_he_so_to_nhom") 'Thiết lập hệ số tổ nhóm
        End Select

        Me.Text &= " - D13F1110" & UnicodeCaption(bUnicode)
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("DivisionID").Caption = rl3("Ma_don_vi") 'Mã đơn vị
        tdbg.Columns("CreateUserID").Caption = rl3("Nguoi_tao") 'Người tạo
        tdbg.Columns("CreateDate").Caption = rl3("Ngay_tao") 'Ngày tạo
        tdbg.Columns("LastModifyUserID").Caption = rl3("Nguoi_cap_nhat_cuoi_cung") 'Người cập nhật cuối cùng
        tdbg.Columns("LastModifyDate").Caption = rL3("Ngay_cap_nhat_cuoi_cung") 'Ngày cập nhật cuối cùng
        '================================================================ 
        lblDutyID.Text = rL3("Chuc_vu") 'Chức vụ
        '================================================================ 
        tdbcDutyID.Columns("DutyID").Caption = rL3("Ma") 'Mã
        tdbcDutyID.Columns("DutyName").Caption = rL3("Ten") 'Tên

    End Sub

    Private Sub LoadCationCoefficient(Optional ByVal iSplit As Integer = 1)
        'Gan caption cho split0
        Select Case _type.ToUpper
            Case "D91T0012"
                tdbg.Splits(SPLIT0).DisplayColumns(COL_DivisionID).Visible = _type.ToUpper = "D91T0012"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_phong_ban") 'Mã phòng ban
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_phong_ban") 'Tên phòng ban
            Case "D09T0211"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_chuc_vu") 'Mã chức vụ
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_chuc_vu") 'Tên chức vụ
            Case "D13T0118"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_khoan_dieu_chinh_thu_nhapU")
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_khoan_dieu_chinh_thu_nhap")
            Case "D39T1000"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_chi_tieu_danh_gia") 'Mã yếu tố đánh giá
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_chi_tieu_danh_gia") 'Tên yếu tố đánh giá
            Case "D29T1070"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_loai_cham_cong") 'Mã loại chấm công
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_loai_cham_cong") 'Tên loại chấm công
            Case "D45T1010"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_cong_doan")
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_cong_doan")
            Case "D09T0224"
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_cong_viec")
                tdbg.Columns(COL_TypeName).Caption = rl3("Ten_cong_viec")
            Case "D09T1080" ' UPDATE 12/6/2013 ID 56277
                tdbg.Columns(COL_TypeID).Caption = rl3("Ma_du_an")
                tdbg.Columns(COL_TypeName).Caption = rL3("Ten_du_an")
            Case "D91T0016" ' UPDATE 12/6/2013 ID 56277
                tdbg.Columns(COL_TypeID).Caption = rL3("Ma_don_vi") 'Mã đơn vị
                tdbg.Columns(COL_TypeName).Caption = rL3("Ten_don_vi") 'Tên đơn vị
            Case "D09T0227" ' 21.04.2017 ID 96045 
                tdbg.Columns(COL_TypeID).Caption = rL3("Ma_to_nhom")
                tdbg.Columns(COL_TypeName).Caption = rL3("Ten_to_nhom")
        End Select

        Try
            Dim nColCoeffVisible As Integer = 0 'Số cột hiển thị
            Dim sSQL As String = ""
            Dim dt As DataTable
            Dim j As Integer = IndexOfColumn(tdbg, COL_Coefficient01)
            Dim arr() As FormatColumn = Nothing


            sSQL = SQLStoreD13P1111()
            dt = ReturnDataTable(sSQL)
            Dim sNumberFormat As String
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    sNumberFormat = dt.Rows(i).Item("Decimals").ToString
                    If sNumberFormat.Trim = "" Then
                        sNumberFormat = "N0"
                    Else
                        sNumberFormat = "N" & sNumberFormat.Trim
                    End If
                    AddDecimalColumns(arr, tdbg.Columns(j).DataField, sNumberFormat, 28, 8)

                    If bUnicode Then
                        tdbg.Columns(j).Caption = dt.Rows(i).Item("ShortU").ToString
                    Else
                        tdbg.Columns(j).Caption = dt.Rows(i).Item("Short").ToString
                        tdbg.Splits(iSplit).DisplayColumns(j).HeadingStyle.Font = New System.Drawing.Font("Lemon3", 8.249999!)
                    End If

                    tdbg.Splits(iSplit).DisplayColumns(j).Visible = Not CType(dt.Rows(i).Item("Disabled"), Boolean)
                    If Not CType(dt.Rows(i).Item("Disabled"), Boolean) Then
                        iLastCol = j
                    End If

                    tdbg.Columns(j).Tag = tdbg.Splits(iSplit).DisplayColumns(j).Visible.ToString

                    If tdbg.Splits(iSplit).DisplayColumns(j).Visible Then
                        If Not bUseCoefficient Then bUseCoefficient = True
                        If iFirstCol <> 0 Then iFirstCol = j
                        nColCoeffVisible += 1
                    End If

                    j += 1
                Next
            End If

            If arr IsNot Nothing Then InputNumber(tdbg, arr)

            If bUseCoefficient = False Then
                tdbg.RemoveHorizontalSplit(1)
            Else
                tdbg.Splits(SPLIT1).SplitSizeMode = C1.Win.C1TrueDBGrid.SizeModeEnum.Exact
                tdbg.Splits(SPLIT1).SplitSize = 80 * CInt(IIf(nColCoeffVisible > 5, 5, nColCoeffVisible))
            End If

            dt.Dispose()

        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    Private Sub LoadTDBGrid(ByVal sTypeID As String, Optional bCallFromD09F0290 As Boolean = False)
        Dim sSQL As String = ""

        sSQL = SQLStoreD13P1110(sTypeID)
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, bUnicode)

        If bCallFromD09F0290 Then ReLoadTDBGrid()
    End Sub

    Private Sub ReLoadTDBGrid()
        If dtGrid Is Nothing Then Exit Sub
        Dim strFind As String = ""
        'dtGrid.DefaultView.
        If ReturnValueC1Combo(tdbcDutyID) <> "%" Then
            strFind &= "TypeID=" & SQLString(ReturnValueC1Combo(tdbcDutyID))
        End If
        'tdbg.

        dtGrid.DefaultView.RowFilter = strFind
        ResetGrid()
    End Sub

    Private Sub ResetGrid()

        FooterTotalGrid(tdbg, COL_TypeName)
    End Sub

    Public Sub FooterTotalGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal sColumnName As String)
        'tdbg.Columns(sColumnName).FooterText = rl3("Tong_cong") & Space(1) & "(" & tdbg.RowCount & ")"
        'tdbg.Columns(sColumnName).FooterText = "(" & tdbg.RowCount & ")" 'Sửa theo chuẩn mới 14/9/2016 Ánh
    End Sub
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_AfterColUpdate(sender As Object, e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles tdbg.AfterColUpdate
        tdbg.Columns(COL_IsUpdate).Value = 1
        tdbg.UpdateData()
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter And tdbg.Col = iLastCol Then
            If bUseCoefficient Then
                HotKeyEnterGrid(tdbg, iFirstCol, e, SPLIT1)
            Else
                HotKeyEnterGrid(tdbg, iFirstCol, e, SPLIT0)
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnSave.Focus()
        If btnSave.Focused = False Then Exit Sub
        '************************************
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        'If Not AllowSave() Then Exit Sub

        btnSave.Enabled = False
        btnClose.Enabled = False
        tdbg.UpdateData()
        Me.Cursor = Cursors.WaitCursor
        Dim sSQL As New StringBuilder

        If _type.ToUpper = "D09T0211" Then
            Dim dr() As DataRow = dtGrid.DefaultView.ToTable(True, "TypeID", "IsUpdate").Select("IsUpdate=1")
            If dr.Length = 0 Then
                Me.Cursor = Cursors.Default
                btnClose.Enabled = True
                btnSave.Enabled = True
                Exit Sub
            End If

            sSQL.Append(SQLDeleteD13T1111_D09F0290(dr) & vbCrLf)
            sSQL.Append(SQLInsertD13T1111s_D09F0290())
        Else
            sSQL.Append(SQLDeleteD13T1111() & vbCrLf)
            sSQL.Append(SQLInsertD13T1111s)
        End If

        Dim bRunSQL As Boolean = ExecuteSQL(sSQL.ToString)
        Me.Cursor = Cursors.Default
        btnClose.Enabled = True
        btnSave.Enabled = True
        If bRunSQL Then
            SaveOK()
            _bSaved = True
        Else
            SaveNotOK()
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1110
    '# Created User: Lê Anh Vũ
    '# Created Date: 27/12/2016 09:03:28
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1110(ByVal sTypeID As String) As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon cho luoi" & vbCrLf)
        sSQL &= "Exec D13P1110 "
        sSQL &= SQLString(_type) & COMMA 'Type, varchar[50], NOT NULL
        sSQL &= SQLString(_divisionID) & COMMA 'DivisionID, varchar[50], NOT NULL
        sSQL &= SQLString(sTypeID) & COMMA 'TypeID, varchar[50], NOT NULL
        sSQL &= SQLString(gsUserID) 'UserID, text, NOT NULL
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1111
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 22/05/2009 10:39:59
    '# Modified User: 
    '# Modified Date: 
    '# Description: Load Caption cho 10 hệ số
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1111() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D13P1111 "
        sSQL &= SQLString(_type) 'Type, varchar[50], NOT NULL
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1111
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 22/05/2009 10:41:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: Khi lưu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1111() As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1111"
        sSQL &= " Where Type = " & SQLString(_type)
        If _divisionID <> "" And _divisionID <> "%" Then sSQL &= " And DivisionID =" & SQLString(_divisionID)
        If _typeID <> "" And _typeID <> "%" Then sSQL &= " And TypeID =" & SQLString(_typeID)
        Return sSQL
    End Function



    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1111s
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 22/05/2009 10:42:20
    '# Modified User: 
    '# Modified Date: 
    '# Description: Lưu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1111s() As StringBuilder
        Dim sRet As New StringBuilder
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To tdbg.RowCount - 1
            sSQL.Append("Insert Into D13T1111(")
            sSQL.Append("Type, DivisionID, TypeID,  ")
            For j As Integer = 1 To 50
                sSQL.Append("Coefficient" & j.ToString("00") & ",")
            Next
            sSQL.Append("CreateUserID, CreateDate, LastModifyUserID, LastModifyDate")
            sSQL.Append(") Values(")
            sSQL.Append(SQLString(tdbg(i, COL_Type)) & COMMA) 'Type, varchar[50], NULL
            sSQL.Append(SQLString(tdbg(i, COL_DivisionID)) & COMMA) 'DivisionID, varchar[50], NULL
            sSQL.Append(SQLString(tdbg(i, COL_TypeID)) & COMMA) 'TypeID, varchar[50], NULL


            Dim sFieldName As String
            For j As Integer = 1 To 50
                sFieldName = "Coefficient" & j.ToString("00")
                sSQL.Append(SQLMoney(tdbg(i, sFieldName), tdbg.Columns(sFieldName).NumberFormat) & COMMA) 'Coefficient06, money, NULL
            Next

            If tdbg(i, COL_CreateUserID).ToString <> "" Then
                sSQL.Append(SQLString(tdbg(i, COL_CreateUserID)) & COMMA) 'CreateUserID, varchar[50], NULL
            Else
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NULL
            End If

            If tdbg(i, COL_CreateDate).ToString <> "" Then
                sSQL.Append(SQLDateTimeSave(tdbg(i, COL_CreateDate)) & COMMA) 'CreateDate, datetime, NULL
            Else
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            End If

            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NULL
            sSQL.Append("GetDate()") 'LastModifyDate, datetime, NULL
            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLDeleteD13T1111
    '# Created User: Nguyễn Thị Ánh
    '# Created Date: 22/05/2009 10:41:36
    '# Modified User: 
    '# Modified Date: 
    '# Description: Khi lưu
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLDeleteD13T1111_D09F0290(ByVal dr() As DataRow) As String
        Dim sSQL As String = ""
        sSQL &= "Delete From D13T1111"
        If dr.Length <= 1 Then
            sSQL &= " Where TypeID = " & SQLString(dr(0)("TypeID"))
        Else
            sSQL &= " Where TypeID IN ("
            For i As Integer = 0 To dr.Length - 1
                If i <> 0 Then sSQL &= COMMA
                sSQL &= SQLString(dr(i)("TypeID"))
            Next
            sSQL &= ")"
        End If
        If _divisionID <> "" And _divisionID <> "%" Then sSQL &= " And DivisionID =" & SQLString(_divisionID)
        Return sSQL
    End Function

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD13T1111s
    '# Created User: Kim Long
    '# Created Date: 26/01/2018 10:21:56
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD13T1111s_D09F0290() As StringBuilder
        Dim sRet As New StringBuilder
        Dim dtSourceGrid As DataTable = CType(tdbg.DataSource, DataTable)
        Dim dr() As DataRow = dtSourceGrid.Select("IsUpdate=1")
        Dim sSQL As New StringBuilder
        For i As Integer = 0 To dr.Length - 1
            If sSQL.ToString = "" And sRet.ToString = "" Then sSQL.Append("-- Luu D13T1111" & vbCrLf)
            sSQL.Append("Insert Into D13T1111(")
            sSQL.Append("Type, DivisionID, TypeID,  " & vbCrLf)
            For j As Integer = 1 To 50
                sSQL.Append("Coefficient" & j.ToString("00") & ",")
            Next
            sSQL.Append("CreateUserID, CreateDate, " & vbCrLf)
            sSQL.Append("LastModifyUserID, LastModifyDate" & vbCrLf)
            sSQL.Append(") Values(" & vbCrLf)
            sSQL.Append(SQLString(dr(i).Item(COL_Type)) & COMMA) 'Type, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_DivisionID)) & COMMA) 'DivisionID, varchar[50], NOT NULL
            sSQL.Append(SQLString(dr(i).Item(COL_TypeID)) & COMMA) 'TypeID, varchar[50], NOT NULL
            Dim sFieldName As String
            For j As Integer = 1 To 50
                sFieldName = "Coefficient" & j.ToString("00")
                sSQL.Append(SQLMoney(dr(i)(sFieldName), tdbg.Columns(sFieldName).NumberFormat) & COMMA) 'Coefficient06, money, NULL
            Next
            If dr(i)(COL_CreateUserID).ToString <> "" Then
                sSQL.Append(SQLString(dr(i)(COL_CreateUserID)) & COMMA) 'CreateUserID, varchar[50], NULL
            Else
                sSQL.Append(SQLString(gsUserID) & COMMA) 'CreateUserID, varchar[50], NULL
            End If

            If dr(i)(COL_CreateDate).ToString <> "" Then
                sSQL.Append(SQLDateTimeSave(dr(i)(COL_CreateDate)) & COMMA) 'CreateDate, datetime, NULL
            Else
                sSQL.Append("GetDate()" & COMMA) 'CreateDate, datetime, NULL
            End If
            sSQL.Append(SQLString(gsUserID) & COMMA) 'LastModifyUserID, varchar[50], NOT NULL
            sSQL.Append("GetDate()" & vbCrLf) 'LastModifyDate, datetime, NULL

            sSQL.Append(")")

            sRet.Append(sSQL.ToString & vbCrLf)
            sSQL.Remove(0, sSQL.Length)
        Next
        Return sRet
    End Function



#Region "Events tdbcDutyID"

    Private Sub tdbcDutyID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcDutyID.LostFocus
        If tdbcDutyID.FindStringExact(tdbcDutyID.Text) = -1 Then tdbcDutyID.Text = ""
    End Sub

#End Region

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcDutyID.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub

    Private Sub tdbcDutyID_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcDutyID.SelectedValueChanged
        If tdbcDutyID.Tag Is Nothing OrElse L3String(tdbcDutyID.Tag) <> ReturnValueC1Combo(tdbcDutyID) Then
            ReLoadTDBGrid()
            tdbcDutyID.Tag = ReturnValueC1Combo(tdbcDutyID)
        End If
    End Sub
End Class