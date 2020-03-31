﻿''' <summary>
''' Định nghĩa các biến truyền qua lại giữa các exe với nhau
''' </summary>
Module D13X0003

    Public Const EXEMODULE As String = "D13"
    Public Const EXED00 As String = "D00E0030"
    Public Const EXEPARENT As String = "D13E0040"
    Public Const EXECHILD As String = "D13E2140"
    '---------------------------------------
    ''' <summary>
    ''' Server truyền vào
    ''' </summary>
    Public PARA_Server As String
    ''' <summary>
    ''' Database truyền vào
    ''' </summary>
    Public PARA_Database As String
    ''' <summary>
    ''' User login vào Lemon3 truyền vào
    ''' </summary>
    Public PARA_ConnectionUser As String
    ''' <summary>
    ''' User login vào Database truyền vào
    ''' </summary>
    Public PARA_UserID As String
    ''' <summary>
    ''' Password user login vào Database truyền vào
    ''' </summary>
    Public PARA_Password As String
    ''' <summary>
    ''' Đơn vị truyền vào
    ''' </summary>
    Public PARA_DivisionID As String
    ''' <summary>
    ''' Tháng kế toán truyền vào
    ''' </summary>
    Public PARA_TranMonth As String
    ''' <summary>
    ''' Năm kế toán truyền vào
    ''' </summary>
    Public PARA_TranYear As String
    ''' <summary>
    ''' Ngôn ngữ truyền vào
    ''' </summary>
    ''' <remarks></remarks>
    Public PARA_Language As EnumLanguage
    ''' <summary>
    ''' Form ID dùng để hiện thị. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormID As String
    ''' <summary>
    ''' Form ID dùng để phân quyền. Ví dụ: DxxFxxxx
    ''' </summary>
    Public PARA_FormIDPermission As String
    ''' <summary>
    ''' FormState
    ''' </summary>
    Public PARA_FormState As EnumFormState
    '---------------------------------------
    'Ngoài ra khi cần thêm bất cứ thông số nào lập trình viên phải định nghĩa bắt
    'đầu bằng refix PARA_
    Public PARA_ID01 As String = ""
    Public PARA_ID02 As String = ""
    Public PARA_ID03 As String = ""
    Public PARA_ID04 As String = ""
    Public PARA_ID05 As String = ""
    Public PARA_ID06 As String = ""
    Public PARA_ID07 As String = ""
    Public PARA_ID08 As String = ""
    Public PARA_ID09 As String = ""
    Public PARA_ID10 As String = ""
    Public PARA_ID11 As String = ""
    Public PARA_ID12 As String = ""
    Public PARA_ModuleID As String = ""
    Public PARA_ParentExe As String = ""
End Module
