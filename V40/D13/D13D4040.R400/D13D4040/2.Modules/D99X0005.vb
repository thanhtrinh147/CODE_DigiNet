'#######################################################################################
'#                                     CHÚ Ý
'#--------------------------------------------------------------------------------------
'# Không được thay đổi bất cứ dòng code này trong module này, nếu muốn thay đổi bạn phải
'# liên lạc với Trưởng nhóm để được giải quyết.
'# Ngày cập nhật cuối cùng: 26/05/2009
'# Người cập nhật cuối cùng: Nguyễn Thị Minh Hòa
'#######################################################################################

''' <summary>
''' Module quản lý các vấn đề về Shortcut và Image của Popupmenu
''' </summary>
''' <remarks>Chỉ gắn vào exe nào có sử dụng popupmenu</remarks>
Module D99X0005

#Region "Set Image và Shortcut của Popupmenu"
    ''' <summary>
    ''' Set Image và Shortcut của Popupmenu
    ''' </summary>
    ''' <param name="C1CmdHolder">C1CommandHolder của popupmenu</param>
    ''' <remarks>Gọi hàm SetShortcutPopupMenu(C1CommandHolder)tại form_load</remarks>
    <DebuggerStepThrough()> _
    Public Sub SetShortcutPopupMenu(ByVal C1CmdHolder As C1.Win.C1Command.C1CommandHolder)
        On Error Resume Next

        With C1CmdHolder
            .SmoothImages = False
            '************************************************
            'Image và Shortcut chuẩn
            'Thêm
            .Commands("mnuAdd").Image = My.Resources.add
            .Commands("mnuAdd").Shortcut = Shortcut.CtrlN
            'Kế thừa
            .Commands("mnuInherit").Image = My.Resources.copy
            .Commands("mnuInherit").Shortcut = Shortcut.CtrlY
            'Xem
            .Commands("mnuView").Image = My.Resources.view
            .Commands("mnuView").Shortcut = Shortcut.CtrlW
            'Sửa
            .Commands("mnuEdit").Image = My.Resources.edit
            .Commands("mnuEdit").Shortcut = Shortcut.CtrlE
            'Xóa
            .Commands("mnuDelete").Image = My.Resources.delete
            .Commands("mnuDelete").Shortcut = Shortcut.CtrlD
            'Tìm kiếm
            .Commands("mnuFind").Image = My.Resources.find
            .Commands("mnuFind").Shortcut = Shortcut.CtrlF
            'Liệt kê tất cả
            .Commands("mnuListAll").Image = My.Resources.ListAll
            .Commands("mnuListAll").Shortcut = Shortcut.CtrlA
            'Thông tin hệ thống
            .Commands("mnuSysInfo").Image = My.Resources.SysInfo
            .Commands("mnuSysInfo").Shortcut = Shortcut.CtrlI
            'In
            .Commands("mnuPrint").Image = My.Resources.PrintReport
            .Commands("mnuPrint").Shortcut = Shortcut.CtrlP
            
            'Xuất Excel
            .Commands("mnuExportToExcel").Image = My.Resources.ExportToExcel
            .Commands("mnuExportToExcel").Shortcut = Shortcut.CtrlX
            'Sửa khác
            .Commands("mnuEditOther").Image = My.Resources.EditOther
            .Commands("mnuEditOther").Shortcut = Shortcut.CtrlO
            'Sửa số phiếu
            .Commands("mnuEditVoucher").Image = My.Resources.EditVoucher
            .Commands("mnuEditVoucher").Shortcut = Shortcut.CtrlU
            'Xuất kho
            .Commands("mnuIssueStock").Image = My.Resources.IssueStock
            .Commands("mnuIssueStock").Shortcut = Shortcut.CtrlK
            'Khóa phiếu
            .Commands("mnuLockVoucher").Image = My.Resources.LockVoucher
            .Commands("mnuLockVoucher").Shortcut = Shortcut.CtrlL
            'Hiển thị chi tiết
            .Commands("mnuShowDetail").Image = My.Resources.ShowDetail
            .Commands("mnuShowDetail").Shortcut = Shortcut.CtrlS
            'Duyệt
            .Commands("mnuApprove").Image = My.Resources.approve
            .Commands("mnuApprove").Shortcut = Shortcut.CtrlR
            '************************************************
            'Image và Shortcut đặt thù của mỗi module
            .Commands("C1CommandMenu1").Image = My.Resources.PrintReport
            '************************************************
        End With
    End Sub
#End Region

#Region "Chỉ cho gõ phím tắt trên lưới"
    ''' <summary>
    ''' Chặn phím tắt của popup menu
    ''' </summary>
    ''' <param name="tdbg"></param>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks>Tại sự kiện của các menu kiểm tra: If CallMenuFromGrid(tdbg, e) = False Then Exit Sub</remarks>
    <DebuggerStepThrough()> _
    Public Function CallMenuFromGrid(ByVal tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal e As C1.Win.C1Command.ClickEventArgs) As Boolean
        If e Is Nothing Then
            Return True
        End If

        Select Case e.ClickSource
            Case C1.Win.C1Command.ClickSourceEnum.External
                Return False
            Case C1.Win.C1Command.ClickSourceEnum.Shortcut
                If tdbg.Focused = False Then
                    Return False
                End If
            Case C1.Win.C1Command.ClickSourceEnum.None
                Return False
        End Select
        Return True
    End Function

#End Region

End Module
