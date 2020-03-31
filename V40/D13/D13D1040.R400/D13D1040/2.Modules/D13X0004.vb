Module D13X0004

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho xóa
    ''' </summary>
    Public Function MsgNotDeleteData() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_xoa")
        Return sMsg
    End Function
End Module
