'####################################################################################### '#                                     CHÚ Ý '#-------------------------------------------------------------------------------------- '# Không được thay đổi bất cứ dòng code này trong class này, nếu muốn thay đổi bạn phải '# liên lạc với Trưởng nhóm để được giải quyết. '# Diễn giải: Hiển thị các messagebox (backup từ DLL D99D0041) '# Ngày cập nhật cuối cùng: 12/05/2009 '# Người cập nhật cuối cùng: Nguyễn Thị Minh Hòa '#######################################################################################

''' <summary>
''' Liên quan đến MessageBox
''' </summary>
Public Class D99C0008

    Private Shared eLanguage As EnumLanguage
    Private Shared sThongBao As String = "Th¤ng bÀo"
    Private Shared sAnnouncement As String = "Announcement"

    ''' <summary>
    ''' Ngôn ngữ sử dụng cho Messagebox
    ''' </summary>
    Public Shared Property Language() As Integer
        Get
            Return eLanguage
        End Get
        Set(ByVal Value As Integer)
            eLanguage = CType(Value, EnumLanguage)
        End Set
    End Property

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số truyền vào (mặc định button OK)
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    <DebuggerStepThrough()> _
    Public Shared Function Msg(ByVal sMessage As String) As DialogResult
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.MessageBoxButtons = L3MessageBoxButtons.OK
        mForm.MyShow()
        Msg = mForm.DialogResult
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số truyền vào (mặc định button OK)
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    ''' <param name="sCaption">Tiêu đề</param>
    <DebuggerStepThrough()> _
    Public Shared Function Msg(ByVal sMessage As String, ByVal sCaption As String) As DialogResult
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.Caption = sCaption
        mForm.MessageBoxButtons = L3MessageBoxButtons.OK
        mForm.MyShow()
        Return mForm.L3DialogResult
        mForm.Dispose()
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số truyền vào
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    ''' <param name="sCaption">Tiêu đề</param>
    ''' <param name="buttons">Các buttons</param>
    <DebuggerStepThrough()> _
    Public Shared Function Msg(ByVal sMessage As String, ByVal sCaption As String, ByVal buttons As L3MessageBoxButtons) As DialogResult
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.Caption = sCaption
        mForm.MessageBoxButtons = buttons
        mForm.MyShow()
        Return mForm.L3DialogResult
        mForm.Dispose()
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số truyền vào
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    ''' <param name="sCaption">Tiêu đề</param>
    ''' <param name="buttons">Các buttons</param>
    ''' <param name="icon">Icon</param>
    <DebuggerStepThrough()> _
    Public Shared Function Msg(ByVal sMessage As String, ByVal sCaption As String, ByVal buttons As L3MessageBoxButtons, ByVal icon As L3MessageBoxIcon) As DialogResult
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.Caption = sCaption
        mForm.MessageBoxButtons = buttons
        mForm.SelectedIcon = icon
        mForm.MyShow()
        Return mForm.L3DialogResult
        mForm.Dispose()
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số truyền vào
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    ''' <param name="sCaption">Tiêu đề</param>
    ''' <param name="buttons">Các buttons</param>
    ''' <param name="icon">Icon</param>
    ''' <param name="defaultButton">Button mặc định</param>
    <DebuggerStepThrough()> _
    Public Shared Function Msg(ByVal sMessage As String, ByVal sCaption As String, ByVal buttons As L3MessageBoxButtons, ByVal icon As L3MessageBoxIcon, ByVal defaultButton As MessageBoxDefaultButton) As DialogResult
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.Caption = sCaption
        mForm.MessageBoxButtons = buttons
        mForm.SelectedIcon = icon
        mForm.DefaultButton = defaultButton
        mForm.MyShow()
        Return mForm.L3DialogResult
        mForm.Dispose()
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số mặc định là: Title = "Thông báo", Button = OK, Icon = Information
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    <DebuggerStepThrough()> _
    Public Shared Sub MsgL3(ByVal sMessage As String)
        MsgL3(sMessage, L3MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Hiển thị Messagebox với các thông số mặc định là: Title = "Thông báo", Button = OK, Icon = Tuy chon
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    <DebuggerStepThrough()> _
    Public Shared Sub MsgL3(ByVal sMessage As String, ByVal icon As L3MessageBoxIcon)
        Dim mForm As New D99F0004
        mForm.Language() = CType(eLanguage, Short)
        mForm.Message = sMessage
        mForm.Caption = IIf(Language = EnumLanguage.Vietnamese, sThongBao, sAnnouncement).ToString
        mForm.MessageBoxButtons = L3MessageBoxButtons.OK
        mForm.SelectedIcon = icon
        mForm.MyShow()
        mForm.Dispose()
    End Sub

    ''' <summary>
    ''' Hiển thị Messagebox hỏi với các thông số mặc định là: Title = "Thông báo", Button = OKQuestion, Icon = Information
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgAsk(ByVal sMessage As String) As DialogResult
        Return MsgAsk(sMessage, MessageBoxDefaultButton.Button1)
    End Function

    ''' <summary>
    ''' Hiển thị Messagebox hỏi với các thông số truyền vào
    ''' </summary>
    ''' <param name="sMessage">Chuỗi cần thông báo</param>
    ''' <param name="defaultButton1">Button mặc định</param>
    <DebuggerStepThrough()> _
    Public Shared Function MsgAsk(ByVal sMessage As String, ByVal defaultButton1 As MessageBoxDefaultButton) As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                Return Msg(sMessage, sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, defaultButton1)
            Case EnumLanguage.English
                Return Msg(sMessage, sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, defaultButton1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn có muốn lưu giữ liệu này hay không?
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgAskSave() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgAskSave = Msg("Bạn có muốn lưu dữ liệu này hay không?", sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgAskSave = Msg("Do you want to save this data?", sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
        End Select
    End Function


    ''' <summary>
    ''' Dữ liệu đã được lưu thành công.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgSaveOK() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgSaveOK = Msg("Dữ liệu đã được lưu thành công.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgSaveOK = Msg("Successfully saved.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Không lưu được dữ liệu.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgSaveNotOK() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgSaveNotOK = Msg("Không lưu được dữ liệu.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Err, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgSaveNotOK = Msg("Failed to save the data.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Err, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn có muốn xóa dữ liệu này không?
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgAskDelete() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgAskDelete = Msg("Bạn có muốn xóa dữ liệu này không?", sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            Case EnumLanguage.English
                MsgAskDelete = Msg("Do you want to delete this data?", sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        End Select
    End Function

    ''' <summary>
    ''' Bạn có thật sự muốn xóa dòng dữ liệu này không?
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgAskDeleteRow() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgAskDeleteRow = Msg("Bạn có thật sự muốn xóa dòng dữ liệu này không?", sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
            Case EnumLanguage.English
                MsgAskDeleteRow = Msg("Are you sure to delete this record?", sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        End Select
    End Function

    ''' <summary>
    ''' Dữ liệu này đã được sử dụng. Bạn không thể sửa.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgCanNotEdit() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgCanNotEdit = Msg("Dữ liệu này đã được sử dụng. Bạn không thể sửa.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            Case EnumLanguage.English
                MsgCanNotEdit = Msg("This data has been used. You can not delete update it.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        End Select
    End Function

    ''' <summary>
    ''' Dữ liệu này đã được sử dụng. Bạn không thể xoá.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgCanNotDelete() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgCanNotDelete = Msg("Dữ liệu này đã được sử dụng. Bạn không thể xoá.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
            Case EnumLanguage.English
                MsgCanNotDelete = Msg("This data has been used. You can not delete it.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
        End Select
    End Function

    ''' <summary>
    ''' Bạn phải nhập dữ liệu trên lưới.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNoDataInGrid() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNoDataInGrid = Msg("Bạn phải nhập dữ liệu trên lưới.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNoDataInGrid = Msg("You have to enter data in grid.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn phải nhập ...
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNotYetEnter(ByVal sData As String) As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNotYetEnter = Msg("Bạn phải nhập " + sData, sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNotYetEnter = Msg("You have to enter " + sData, sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn phải chọn ...
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNotYetChoose(ByVal sData As String) As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNotYetChoose = Msg("Bạn phải chọn " + sData, sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNotYetChoose = Msg("You have to choose " + sData, sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn phải đăng ký đơn vị ở module Tổng hợp.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgRegisterDivision() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgRegisterDivision = Msg("Bạn phải đăng ký đơn vị ở module Tổng hợp.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgRegisterDivision = Msg("You have not yet enter division in General Ledger module.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Không tồn tại kỳ kế toán của đơn vị hiện tại.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNotExistPeriod() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNotExistPeriod = Msg("Không tồn tại kỳ kế toán của đơn vị hiện tại.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNotExistPeriod = Msg("Period of current division does not exist.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn không có quyền khóa sổ.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNoPermissionCloseBook() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNoPermissionCloseBook = Msg("Bạn không có quyền khóa sổ.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNoPermissionCloseBook = Msg("You have no permission to close the book.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn không có quyền mở sổ.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNoPermissionOpenBook() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNoPermissionOpenBook = Msg("Bạn không có quyền mở sổ.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNoPermissionOpenBook = Msg("You have no permission to open the book.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn không có quyền tạo kỳ mới
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgNoPermissionNewPeriod() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgNoPermissionNewPeriod = Msg("Bạn không có quyền tạo kỳ mới.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgNoPermissionNewPeriod = Msg("You have no permission make new period.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Khoá sổ thành công cho kỳ ...
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgCloseBook(ByVal sPeriod As String) As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgCloseBook = Msg("Khoá sổ thành công cho kỳ " & sPeriod & ".", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgCloseBook = Msg("The book is closed for the period " & sPeriod & ".", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Mở sổ thành công cho kỳ ...
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgOpenBook(ByVal sPeriod As String) As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgOpenBook = Msg("Mở sổ thành công cho kỳ " & sPeriod & ".", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgOpenBook = Msg("The book is opened for the period " & sPeriod & ".", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Copy dữ liệu diễn giải vào cho lưới: - Tất cả các dòng (nhấn Yes) - Những dòng còn trống (nhấn No)
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgCopyDesctiption() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgCopyDesctiption = Msg("Copy dữ liệu diễn giải vào cho lưới:" & vbCrLf & "- Tất cả các dòng (nhấn Yes)" & vbCrLf & "- Những dòng còn trống (nhấn No)", sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgCopyDesctiption = Msg("Copy Description in grid:" & vbCrLf & "- Overwrite (press Yes)" & vbCrLf & "- Copy only empty cells (press No)", sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Copy cột dữ liệu cho: - Tất cả các dòng (nhấn Yes) - Những dòng còn trống (nhấn No)
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgCopyColumn() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgCopyColumn = Msg("Copy cột dữ liệu cho:" & vbCrLf & "- Tất cả các dòng (nhấn Yes)" & vbCrLf & "- Những dòng còn trống (nhấn No)", sThongBao, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgCopyColumn = Msg("Copy data in grid:" & vbCrLf & "- Overwrite (press Yes)" & vbCrLf & "- Copy only empty cells (press No)", sAnnouncement, L3MessageBoxButtons.YesNo, L3MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Mã này đã tồn tại.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Function MsgDuplicatePKey() As DialogResult
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgDuplicatePKey = Msg("Mã này đã tồn tại.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Case EnumLanguage.English
                MsgDuplicatePKey = Msg("This ID was used.", sAnnouncement, L3MessageBoxButtons.OK, L3MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Select
    End Function

    ''' <summary>
    ''' Bạn phải khởi động lại module thì thiết lập đơn vị mới có tác dụng.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Sub MsgSetUpDivision()
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgL3("Bạn phải khởi động lại module thì thiết lập đơn vị mới có tác dụng.")
            Case EnumLanguage.English
                MsgL3("The new division setting will be applied on the next log-on.")
        End Select
    End Sub

    ''' <summary>
    ''' Bạn phải chọn dữ liệu có trong danh sách.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Sub MsgInList()
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                MsgL3("Bạn phải chọn dữ liệu có trong danh sách.")
            Case EnumLanguage.English
                MsgL3("You have to choose data in list.")
        End Select
    End Sub

    ''' <summary>
    ''' Kết nối không thành công.
    ''' </summary>
    <DebuggerStepThrough()> _
    Public Shared Sub MsgInvalidConnection()
        Select Case eLanguage
            Case EnumLanguage.Vietnamese
                Msg("Kết nối không thành công.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Err)
            Case EnumLanguage.English
                Msg("Connection string is invalid.", sThongBao, L3MessageBoxButtons.OK, L3MessageBoxIcon.Err)
        End Select
    End Sub

End Class
