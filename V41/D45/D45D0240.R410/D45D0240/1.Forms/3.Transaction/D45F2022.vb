Imports System
Public Class D45F2022
    Dim dtGrid As DataTable
    Dim sFilter As New System.Text.StringBuilder()
    Dim bRefreshFilter As Boolean = False 'Cờ bật set FilterText =""
    Private _createVoucherNo_D45F2020 As Boolean
    Public WriteOnly Property CreateVoucherNo_D45F2020() As Boolean
        Set(ByVal Value As Boolean)
            _createVoucherNo_D45F2020 = Value
        End Set
    End Property


#Region "Const of tdbg"
    Private Const COL_ProductID As Integer = 0   ' Mã sản phẩm
    Private Const COL_ProductName As Integer = 1 ' Tên sản phẩm
    Private Const COL_Quantity03 As Integer = 2  ' Số lượng kế hoạch
    Private Const COL_Quantity As Integer = 3    ' Quantity
    Private Const COL_Quantity02 As Integer = 4  ' Quantity02
    Private Const COL_ShiftID As Integer = 5     ' Ca làm việc
    Private Const COL_VoucherDate As Integer = 6 ' Ngày phiếu
    Private Const COL_VoucherNo As Integer = 7   ' Số phiếu
    Private Const COL_VoucherDesc As Integer = 8 ' Diễn giải
#End Region




    Private Sub D45F2022_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F2022_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetColorGrid(tdbg)
        tdbg_NumberFormat()
        LoadCaptionQuantity()
        tdbg_LockedColumns()
        SetResolutionForm(Me)
    End Sub

    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Phuong_thuc_tao_phieu_cham_cong") & " - " & Me.Name & UnicodeCaption(gbUnicode) 'Ph§¥ng th÷c tÁo phiÕu chÊm c¤ng
        '================================================================ 
        btnChoose.Text = rL3("_Chon_san_pham") '&Chọn sản phẩm
        btnCaculate.Text = rL3("Tin_h") 'Tín&h
        btnContinue.Text = rL3("_Tiep_tuc") '&Tiếp tục
        btnClose.Text = rL3("Do_ng") 'Đó&ng
        '================================================================ 
        optMode2.Text = rL3("Tong_hop_so_luong") 'Tổng hợp số lượng
        optMode1.Text = rL3("Tong_hop_theo_san_pham") 'Tổng hợp theo sản phẩm
        optMode0.Text = rL3("Chi_tiet") 'Chi tiết
        '================================================================ 
        grpData.Text = rL3("Chuyen_du_lieu") 'Chuyển dữ liệu
        '================================================================ 
        tdbg.Columns(COL_ProductID).Caption = rL3("Ma_san_pham") 'Mã sản phẩm
        tdbg.Columns(COL_ProductName).Caption = rL3("Ten_san_pham") 'Tên sản phẩm
        tdbg.Columns(COL_Quantity03).Caption = rL3("So_luong_ke_hoach") 'Số lượng kế hoạch
        tdbg.Columns(COL_ShiftID).Caption = rL3("Ca_lam_viec") 'Ca làm việc
        tdbg.Columns(COL_VoucherDate).Caption = rL3("Ngay_phieu") 'Ngày phiếu
        tdbg.Columns(COL_VoucherNo).Caption = rL3("So_phieu") 'Số phiếu
        tdbg.Columns(COL_VoucherDesc).Caption = rL3("Dien_giai") 'Diễn giải
    End Sub


    Private Sub tdbg_NumberFormat()
        tdbg.Columns(COL_Quantity).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity02).NumberFormat = DxxFormat.DefaultNumber2
        tdbg.Columns(COL_Quantity03).NumberFormat = DxxFormat.DefaultNumber2
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = SQLStoreD45P2022()
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_ProductID)
    End Sub

    Private Sub ReLoadTDBGrid()
        Dim strFind As String = ""
        If sFilter.ToString.Equals("") = False And strFind.Equals("") = False Then strFind &= " And "
        strFind &= sFilter.ToString

        dtGrid.DefaultView.RowFilter = strFind

        FooterTotalGrid(tdbg, COL_ProductID)
    End Sub

    Private Sub LoadCaptionQuantity()
        Dim sSQL As String = ""
        sSQL = "Select Code, ShortName" & UnicodeJoin(gbUnicode) & " As ShortName, Disabled From D45T0010  WITH(NOLOCK) Where Type = 'QTY' Order by Code"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        Dim j As Integer = 0 'dòng của table
        If dt.Rows.Count > 0 Then
            For i As Integer = COL_Quantity To COL_Quantity02
                tdbg.Splits(0).DisplayColumns(i).HeadingStyle.Font = FontUnicode(gbUnicode)
                tdbg.Columns(i).Caption = dt.Rows(j).Item("ShortName").ToString
                tdbg.Splits(0).DisplayColumns(i).Visible = L3Bool(IIf(dt.Rows(j).Item("Disabled").ToString = "1", 0, 1))
                j += 1
            Next
        End If
    End Sub

#Region "tdbg"

    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            If bRefreshFilter Then Exit Sub 'set FilterText ="" thì thoát
            'Filter the data 
            FilterChangeGrid(tdbg, sFilter)
            ReLoadTDBGrid()
        Catch ex As Exception
            'Update 11/05/2011: Tạm thời có lỗi thì bỏ qua không hiện message
            WriteLogFile(ex.Message) 'Ghi file log TH nhập số >MaxInt cột Byte
        End Try
    End Sub

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.Col = COL_VoucherNo Then HotKeyEnterGrid(tdbg, COL_ProductID, e)
        End If

        HotKeyCtrlVOnGrid(tdbg, e) 'Đã bổ sung D99X0000
    End Sub

    'không cho nhấn giá trị trên cột Filter bar đối với cột STT
    Private Sub tdbg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tdbg.KeyPress
        Select Case tdbg.Col
            Case COL_Quantity
                e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End Select
    End Sub
#End Region

    Private Function AllowSave() As Boolean
        If tdbg.RowCount <= 0 Then
            D99C0008.MsgL3(rl3("Khong_co_du_lieu_de_tao_phieu_CCSP"))
            tdbg.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        _CreateVoucherNo_D45F2020 = False
        Me.Close()
    End Sub

    Private Sub btnContinue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContinue.Click
        tdbg.UpdateData()
        If AllowSave() = False Then Exit Sub

        Dim f As New D45F2001
        With f
            .IsAuto = 1
            .FormState = EnumFormState.FormAdd
            .ShowDialog()
            .Dispose()
        End With
        Me.Close()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        Dim f As New D45F2021
        With f
            .ShowDialog()
            .Dispose()
        End With

    End Sub

    Private Sub btnCaculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaculate.Click
        LoadTDBGrid()
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P2022
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 06/07/2011 04:17:25
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P2022() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P2022 "
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        If optMode0.Checked Then
            sSQL &= SQLNumber(0) 'Mode, int, NOT NULL
        ElseIf optMode1.Checked Then
            sSQL &= SQLNumber(1) 'Mode, int, NOT NULL
        Else
            sSQL &= SQLNumber(2) 'Mode, int, NOT NULL
        End If

        Return sSQL
    End Function


    Private Sub tdbg_LockedColumns()
        tdbg.Splits(0).DisplayColumns(COL_ShiftID).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(0).DisplayColumns(COL_ShiftID).Locked = True
        tdbg.Splits(0).DisplayColumns(COL_ShiftID).AllowFocus = False
        tdbg.Splits(0).DisplayColumns(COL_VoucherDate).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(0).DisplayColumns(COL_VoucherDate).Locked = True
        tdbg.Splits(0).DisplayColumns(COL_VoucherDate).AllowFocus = False
        tdbg.Splits(0).DisplayColumns(COL_VoucherDesc).Style.BackColor = Color.FromArgb(COLOR_BACKCOLOR)
        tdbg.Splits(0).DisplayColumns(COL_VoucherDesc).Locked = True
        tdbg.Splits(0).DisplayColumns(COL_VoucherDesc).AllowFocus = False
    End Sub



End Class