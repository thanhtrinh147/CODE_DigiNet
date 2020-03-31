﻿#Region "Khai báo Structure"

''' <summary>
''' Khai báo Structure cho phần Tùy chọn của Module
''' </summary>
Public Structure StructureOption
    ''' <summary>
    ''' Hỏi trước khi lưu
    ''' </summary>
    Public MessageAskBeforeSave As Boolean
    ''' <summary>
    ''' Hỏi trước khi xóa
    ''' </summary>
    Public MessageAskBeforeDelete As Boolean
    ''' <summary>
    ''' Hỏi trước khi sửa
    ''' </summary>
    Public MessageAskBeforeEdit As Boolean
    ''' <summary>
    ''' Thông báo khi lưu thành công
    ''' </summary>
    Public MessageWhenSaveOK As Boolean
    ''' <summary>
    ''' Thông báo khi nhập xuất dữ liệu thành công
    ''' </summary>
    Public MessageWhenImportExportDataOK As Boolean
    ''' <summary>
    ''' Thông báo khi kế thừa thành công
    ''' </summary>
    Public MessageWhenInheritOK As Boolean
    ''' <summary>
    ''' Hiển thị form chọn kỳ kế toán khi chạy chương trình
    ''' </summary>
    Public ViewFormPeriodWhenAppRun As Boolean
    ''' <summary>
    ''' Hiển thị đơn vị tính
    ''' </summary>
    Public ViewUnitID As Boolean
    ''' <summary>
    ''' Hiển thị đơn vị tính gốc
    ''' </summary>
    Public ViewBaseUnitID As Boolean
    ''' <summary>
    ''' Hiển thị số lương quy đổi
    ''' </summary>
    Public ViewConvertedQuantity As Boolean
    ''' <summary>
    ''' Hiển thị thành tiền quy đổi
    ''' </summary>
    Public ViewConvertedAmount As Boolean
    ''' <summary>
    ''' Hiển thị số phiếu của riêng tôi
    ''' </summary>
    Public ViewMyInvoice As Boolean
    ''' <summary>
    ''' Cho phép sửa số tiền quy đổi
    ''' </summary>
    Public AllowEditConvertedAmount As Boolean
    ''' <summary>
    ''' Cho phép sửa số lượng quy đổi
    ''' </summary>
    Public AllowEditConvertedQuantity As Boolean
    ''' <summary>
    ''' Cho phép nhập số âm
    ''' </summary>
    Public AllowEnterNumberNegative As Boolean
    ''' <summary>
    ''' Lưu giá trị gần nhất
    ''' </summary>
    Public SaveLastRecent As Boolean
    ''' <summary>
    ''' Lưu loại đối tượng gần nhất
    ''' </summary>
    Public SaveLastRecentObjectTypeID As Boolean
    ''' <summary>
    ''' Lưu đối tượng gần nhất
    ''' </summary>
    Public SaveLastRecentObjectID As Boolean
    ''' <summary>
    ''' Lưu diễn giải gần nhất
    ''' </summary>
    Public SaveLastRecentDescription As Boolean
    ''' <summary>
    ''' Lưu mã kho gần nhất
    ''' </summary>
    Public SaveLastRecentWareHouseID As Boolean
    ''' <summary>
    ''' Lưu đơn vị tính mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Mã kho mặc định
    ''' </summary>
    Public DefaultWareHouseID As String
    ''' <summary>
    ''' Tài khoản mặc định
    ''' </summary>
    Public DefaultAccountID As String
    ''' <summary>
    ''' Tài khoản nợ mặc định
    ''' </summary>
    Public DefaultCreditAccountID As String
    ''' <summary>
    ''' Tài khoản có mặc định
    ''' </summary>
    Public DefaultDebitAccountID As String
    ''' <summary>
    ''' Nhóm thuế mặc định
    ''' </summary>
    Public DefaultVATGroupID As String
    '''' <summary>
    '''' Khóa đơn vị
    '''' </summary>
    'Public LockDivisionID As Boolean
    ''' <summary>
    ''' Khóa thành tiền quy đổi
    ''' </summary>
    Public LockConvertedAmount As Boolean
    ''' <summary>
    ''' Làm tròn thành tiền quy đổi
    ''' </summary>
    Public RoundConvertedAmount As Boolean
    ''' <summary>
    ''' Hiển thị tên đơn vị tính
    ''' </summary>
    Public ViewUnitName As Boolean
    ''' <summary>
    ''' Hiển thị sơ đồ quy trình
    ''' </summary>
    Public ShowDiagram As Boolean
    ''' <summary>
    ''' Hiển thị màn hình đường dẫn báo cáo
    ''' </summary>
    Public ShowReportPath As Boolean
    ''' <summary>
    ''' Ngôn ngữ báo cáo
    ''' </summary>
    Public ReportLanguage As Byte
    '------------------------------------------------------------------------
    '  D13 Options here
    Public ShowZeroNumber As Boolean
    Public ShowFormular As Boolean
    'Public CodeTable As Boolean
    '------------------------------------------------------------------------
End Structure

''' <summary>
''' Khai báo structure cho phần Thiết lập hệ thống
''' </summary>
Public Structure StructureSystem
    ''' <summary>
    ''' Đơn vị mặc định
    ''' </summary>
    Public DefaultDivisionID As String
    ''' <summary>
    ''' Nguyên tệ mặc định
    ''' </summary>
    Public DefaultCurrencyID As String
    ''' <summary>
    ''' Tài khoản mặc định
    ''' </summary>
    Public DefaultAccountID As String
    ''' <summary>
    ''' Loại chứng từ mặc định
    ''' </summary>
    Public DefaultVoucherTypeID As String
    ''' <summary>
    ''' Tài khoản nợ mặc định
    ''' </summary>
    Public DefaultCreditAccountID As String
    ''' <summary>
    ''' Tài khoản có mặc định
    ''' </summary>
    Public DefaultDebitAccountID As String
    ''' <summary>
    ''' Dùng cho Sử dụng mã phân tích tiền lương
    ''' </summary>
    Public IsUsedPAna As Boolean

    '------------------------------------------------------------------------
    '  D13 Systems here
    Public IsUseBlock As Boolean
    Public IsUseDecisionNum As Boolean
    Public IsNewTransferPolicyMode As Boolean
    Public LoadSystem As Boolean
    Public FormatDateType As String
    '------------------------------------------------------------------------
    Public IsPayrollProject As Boolean
    Public IsSalOtherDiv As Boolean

End Structure

''' <summary>
''' Khai báo structure cho phần định dạng format
''' </summary>
Public Structure StructureFormat
    Public DefaultNumber4 As String
    Public DefaultNumber3 As String
    Public DefaultNumber2 As String
    Public DefaultNumber0 As String
    Public DefaultNumber1 As String
    Public D90_Converted As String
End Structure


''' <summary>
''' Định nghĩa các giá trị boolean của các mức lương dùng để cột mức lương tương ứng hiển thị 
''' khi mức lương đó hiện tại có sử dụng hay ẩn đi khi mức lương đó hiện tại không sử dụng
''' </summary>
Public Structure SALBA
    Public BASE01 As Boolean
    Public BASE02 As Boolean
    Public BASE03 As Boolean
    Public BASE04 As Boolean

    Public BASE01_DATE As Boolean
    Public BASE02_DATE As Boolean
    Public BASE03_DATE As Boolean
    Public BASE04_DATE As Boolean
End Structure

''' <summary>
''' Định nghĩa các giá trị boolean của các hệ số lương dùng để cột hệ số lương tương ứng hiển thị 
''' khi hệ số lương đó hiện tại có sử dụng hay ẩn đi khi hệ số lương đó hiện tại không sử dụng
''' </summary>
Public Structure SALCE
    Public CE01 As Boolean
    Public CE02 As Boolean
    Public CE03 As Boolean
    Public CE04 As Boolean
    Public CE05 As Boolean
    Public CE06 As Boolean
    Public CE07 As Boolean
    Public CE08 As Boolean
    Public CE09 As Boolean
    Public CE10 As Boolean
    Public CE11 As Boolean
    Public CE12 As Boolean
    Public CE13 As Boolean
    Public CE14 As Boolean
    Public CE15 As Boolean
    Public CE16 As Boolean
    Public CE17 As Boolean
    Public CE18 As Boolean
    Public CE19 As Boolean
    Public CE20 As Boolean

    Public CE01_DATE As Boolean
    Public CE02_DATE As Boolean
    Public CE03_DATE As Boolean
    Public CE04_DATE As Boolean
    Public CE05_DATE As Boolean
    Public CE06_DATE As Boolean
    Public CE07_DATE As Boolean
    Public CE08_DATE As Boolean
    Public CE09_DATE As Boolean
    Public CE10_DATE As Boolean
    Public CE11_DATE As Boolean
    Public CE12_DATE As Boolean
    Public CE13_DATE As Boolean
    Public CE14_DATE As Boolean
    Public CE15_DATE As Boolean
    Public CE16_DATE As Boolean
    Public CE17_DATE As Boolean
    Public CE18_DATE As Boolean
    Public CE19_DATE As Boolean
    Public CE20_DATE As Boolean
End Structure

Public Structure OLSC
    Public OLSC1 As Boolean
    Public OLSC10 As Boolean
    Public OLSC11 As Boolean
    Public OLSC12 As Boolean
    Public OLSC13 As Boolean
    Public OLSC14 As Boolean
    Public OLSC15 As Boolean
    Public OLSC2 As Boolean
    Public OLSC20 As Boolean
    Public OLSC21 As Boolean
    Public OLSC22 As Boolean
    Public OLSC23 As Boolean
    Public OLSC24 As Boolean
    Public OLSC25 As Boolean

    Public OfficialTitleID As Boolean
    Public SalaryLevelID As Boolean
    Public SaCoefficient As Boolean
    Public SaCoefficient12 As Boolean
    Public SaCoefficient13 As Boolean
    Public SaCoefficient14 As Boolean
    Public SaCoefficient15 As Boolean

    Public OfficialTitleID2 As Boolean
    Public SalaryLevelID2 As Boolean
    Public SaCoefficient2 As Boolean
    Public SaCoefficient22 As Boolean
    Public SaCoefficient23 As Boolean
    Public SaCoefficient24 As Boolean
    Public SaCoefficient25 As Boolean

    Public OLSC10_DATE As Boolean
    Public OLSC20_DATE As Boolean
End Structure

''' <summary>
''' Định nghĩa các định dạng Format cho mức lương, hệ số lương tương ứng 
''' </summary>
Public Structure StructureFormatSalary
    Public BASE01 As String
    Public BASE02 As String
    Public BASE03 As String
    Public BASE04 As String

    Public CE01 As String
    Public CE02 As String
    Public CE03 As String
    Public CE04 As String
    Public CE05 As String
    Public CE06 As String
    Public CE07 As String
    Public CE08 As String
    Public CE09 As String
    Public CE10 As String
    Public CE11 As String
    Public CE12 As String
    Public CE13 As String
    Public CE14 As String
    Public CE15 As String
    Public CE16 As String
    Public CE17 As String
    Public CE18 As String
    Public CE19 As String
    Public CE20 As String

    Public OLSC11 As String
    Public OLSC12 As String
    Public OLSC13 As String
    Public OLSC14 As String
    Public OLSC15 As String
    Public OLSC21 As String
    Public OLSC22 As String
    Public OLSC23 As String
    Public OLSC24 As String
    Public OLSC25 As String
End Structure

''' <summary>
''' Định nghĩa các giá trị boolean của các mã phân tích dùng để cột mã phân tích tiền lương tương ứng hiển thị 
''' khi mã phân tích tiền lương đó hiện tại có sử dụng hay ẩn đi khi mã phân tích tiền lương đó hiện tại không sử dụng
''' </summary>
Public Structure ANASALARY
    Public P01 As Boolean
    Public P02 As Boolean
    Public P03 As Boolean
    Public P04 As Boolean
    Public P05 As Boolean
    Public P06 As Boolean
    Public P07 As Boolean
    Public P08 As Boolean
    Public P09 As Boolean
    Public P10 As Boolean
    Public P11 As Boolean
    Public P12 As Boolean
    Public P13 As Boolean
    Public P14 As Boolean
    Public P15 As Boolean
    Public P16 As Boolean
    Public P17 As Boolean
    Public P18 As Boolean
    Public P19 As Boolean
    Public P20 As Boolean
End Structure
#End Region


Public Module D13X9940
    ''' <summary>
    '''  HSL tháng
    ''' </summary>
    ''' <remarks></remarks>
    Public gsPayRollVoucherID As String = ""
    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    Public D13Options As StructureOption
    ''' <summary>
    ''' Lưu trữ các thiết lập Thông tin hệ thống
    ''' </summary>
    Public D13Systems As StructureSystem
    ''' <summary>
    ''' Lưu trữ các thiết lập format
    ''' </summary>
    Public D13Format As StructureFormat
    ''' <summary>
    ''' Lưu trữ các thiết lập format lương
    ''' </summary>
    Public D13FormatSalary As StructureFormatSalary

    Public Const D13 As String = "D13"
    Public Const MODULED13 As String = "D13E0040"

    Public Sub LoadOptions(Optional ByVal sModuleID As String = "13")
        Try
            Dim clsOptions As New Lemon3.clsOptions(D13)
            With D13Options
                ' Gọi hàm GetValue với 2 tham số: để lấy giá trị có field name trong table và registry GIỐNG nhau và ở nhánh Options 
                .DefaultDivisionID = L3String(clsOptions.GetValue("DefaultDivisionID", ""))
                .MessageAskBeforeSave = L3Bool(clsOptions.GetValue("MessageAskBeforeSave", "AskBeforeSave", True))
                .MessageWhenSaveOK = L3Bool(clsOptions.GetValue("MessageWhenSaveOK", True))
                ' Gọi hàm GetValue với 3 tham số: để lấy giá trị có field name trong table và registry KHÁC nhau và ở nhánh Options 
                .ViewFormPeriodWhenAppRun = L3Bool(clsOptions.GetValue("ViewFormPeriodWhenAppRun", "NotShowPeriod", False))
                .ShowDiagram = L3Bool(clsOptions.GetValue("ShowDiagram", "SelectPeriod", False))
                .ShowReportPath = L3Bool(clsOptions.GetValue("ShowReportPath", True))
                .ReportLanguage = CByte((clsOptions.GetValue("ReportLanguage", 0)))
                .ShowZeroNumber = L3Bool(clsOptions.GetValue("ShowZeroNumber", False))
                .ShowFormular = L3Bool(clsOptions.GetValue("ShowFormular", False))
            End With


            'Dim D13LocalOptions As String = "Lemon3_D13"
            'Dim Options As String = "Options"

            'With D13Options
            '    If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID") = "" Then ' Lấy đường dẫn VB6
            '        .DefaultDivisionID = GetSetting(D13LocalOptions, Options, "DefaultDivisionID", "")
            '    Else 'Lấy đường dẫn VBNET
            '        .DefaultDivisionID = D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "DefaultDivisionID", "")
            '    End If

            '    If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave") = "" Then ' Lấy đường dẫn VB6
            '        .MessageAskBeforeSave = CType(GetSetting(D13LocalOptions, Options, "AskBeforeSave", "True"), Boolean)
            '    Else 'Lấy đường dẫn VBNET
            '        .MessageAskBeforeSave = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageAskBeforeSave", "True"))
            '    End If

            '    If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK") = "" Then ' Lấy đường dẫn VB6
            '        .MessageWhenSaveOK = CType(GetSetting(D13LocalOptions, Options, "MessageWhenSaveOK", "True"), Boolean)
            '    Else 'Lấy đường dẫn VBNET
            '        .MessageWhenSaveOK = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "MessageWhenSaveOK", "True"))
            '    End If

            '    If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun") = "" Then ' Lấy đường dẫn VB6
            '        .ViewFormPeriodWhenAppRun = CType(GetSetting(D13LocalOptions, Options, "NotShowPeriod", "False"), Boolean)
            '    Else 'Lấy đường dẫn VBNET
            '        .ViewFormPeriodWhenAppRun = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ViewFormPeriodWhenAppRun", "False"))
            '    End If

            '    If D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowDiagram") = "" Then ' Lấy đường dẫn VB6
            '        .ShowDiagram = CType(GetSetting(D13LocalOptions, Options, "ShowDiagram", "False"), Boolean)
            '    Else 'Lấy đường dẫn VBNET
            '        .ShowDiagram = Convert.ToBoolean(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowDiagram", "False"))
            '    End If

            '    'Các tùy chọn mới thêm vào sau khi chuyển lên .NET
            '    Dim Dxx As String = "D" & sModuleID 'PARA_ModuleID: lấy giá trị tại hàm GetAllParameter() : PARA_ModuleID = D99C0007.GetOthersSetting(EXEMODULE, EXECHILD, "ModuleID", xx)
            '    .ShowReportPath = CType(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowReportPath", "True"), Boolean)
            '    .ReportLanguage = CType(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ReportLanguage", "0"), Byte)
            '    .ShowZeroNumber = CType(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowZeroNumber", "False"), Boolean)
            '    .ShowFormular = CType(D99C0007.GetModulesSetting(D13, ModuleOption.lmOptions, "ShowFormular", "False"), Boolean)
            'End With

        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Load toàn bộ các thống số thiết lập hệ thống vào biến D13Systems
    ''' </summary>
    Public Sub LoadSystems()
        Try
            gsFormatDateType = GetFormatDateType()
            Dim sSQL As String = "Select * From D13T0000 WITH (NOLOCK) "
            Dim dt As DataTable = ReturnDataTable(sSQL)
            If dt.Rows.Count > 0 Then
                ' update 21/8/2012 incident 50602
                With D13Systems
                    .DefaultDivisionID = dt.Rows(0).Item("DivisionID").ToString
                    .IsNewTransferPolicyMode = L3Bool(dt.Rows(0).Item("IsNewTransferMode").ToString)
                    .IsUsedPAna = L3Bool(dt.Rows(0).Item("IsUsedPAna").ToString)
                    .IsPayrollProject = L3Bool(dt.Rows(0).Item("IsPayrollProject"))
                    .IsSalOtherDiv = L3Bool(dt.Rows(0).Item("IsSalOtherDiv"))
                End With
            Else
                With D13Systems
                    .DefaultDivisionID = ""
                    .IsNewTransferPolicyMode = False
                    .IsUsedPAna = False
                    .IsPayrollProject = False
                    .IsSalOtherDiv = False
                End With
            End If
            Dim dtD09 As DataTable = ReturnDataTable("Select IsUseBlock From D09T0000 WITH (NOLOCK) ")
            If dtD09.Rows.Count > 0 Then
                D13Systems.IsUseBlock = CBool(dtD09.Rows(0).Item(0))
            End If
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Load toàn bộ các thông số format cho biến D13Format
    ''' </summary>
    Public Sub LoadFormats()
        Try
            Dim sSQL As String = ""
            sSQL &= "Select Code, Short, Disabled, Type, Decimals From D13T9000  WITH (NOLOCK) Order By Code"
            Dim dt As DataTable = ReturnDataTable(sSQL)

            If dt.Rows.Count > 0 Then
                Dim dtSALBA As DataTable = ReturnTableFilter(dt, " Type = 'SALBA'")
                Dim dtSALCE As DataTable = ReturnTableFilter(dt, " Type = 'SALCE'")
                Dim dtOLSC As DataTable = ReturnTableFilter(dt, " Type = 'OLSC'")

                D13FormatSalary.BASE01 = InsertFormat(dtSALBA.Rows(0).Item("Decimals").ToString)
                D13FormatSalary.BASE02 = InsertFormat(dtSALBA.Rows(1).Item("Decimals").ToString)
                D13FormatSalary.BASE03 = InsertFormat(dtSALBA.Rows(2).Item("Decimals").ToString)
                D13FormatSalary.BASE04 = InsertFormat(dtSALBA.Rows(3).Item("Decimals").ToString)

                D13FormatSalary.CE01 = InsertFormat(dtSALCE.Rows(0).Item("Decimals").ToString)
                D13FormatSalary.CE02 = InsertFormat(dtSALCE.Rows(1).Item("Decimals").ToString)
                D13FormatSalary.CE03 = InsertFormat(dtSALCE.Rows(2).Item("Decimals").ToString)
                D13FormatSalary.CE04 = InsertFormat(dtSALCE.Rows(3).Item("Decimals").ToString)
                D13FormatSalary.CE05 = InsertFormat(dtSALCE.Rows(4).Item("Decimals").ToString)
                D13FormatSalary.CE06 = InsertFormat(dtSALCE.Rows(5).Item("Decimals").ToString)
                D13FormatSalary.CE07 = InsertFormat(dtSALCE.Rows(6).Item("Decimals").ToString)
                D13FormatSalary.CE08 = InsertFormat(dtSALCE.Rows(7).Item("Decimals").ToString)
                D13FormatSalary.CE09 = InsertFormat(dtSALCE.Rows(8).Item("Decimals").ToString)
                D13FormatSalary.CE10 = InsertFormat(dtSALCE.Rows(9).Item("Decimals").ToString)
                D13FormatSalary.CE11 = InsertFormat(dtSALCE.Rows(10).Item("Decimals").ToString)
                D13FormatSalary.CE12 = InsertFormat(dtSALCE.Rows(11).Item("Decimals").ToString)
                D13FormatSalary.CE13 = InsertFormat(dtSALCE.Rows(12).Item("Decimals").ToString)
                D13FormatSalary.CE14 = InsertFormat(dtSALCE.Rows(13).Item("Decimals").ToString)
                D13FormatSalary.CE15 = InsertFormat(dtSALCE.Rows(14).Item("Decimals").ToString)
                D13FormatSalary.CE16 = InsertFormat(dtSALCE.Rows(15).Item("Decimals").ToString)
                D13FormatSalary.CE17 = InsertFormat(dtSALCE.Rows(16).Item("Decimals").ToString)
                D13FormatSalary.CE18 = InsertFormat(dtSALCE.Rows(17).Item("Decimals").ToString)
                D13FormatSalary.CE19 = InsertFormat(dtSALCE.Rows(18).Item("Decimals").ToString)
                D13FormatSalary.CE20 = InsertFormat(dtSALCE.Rows(19).Item("Decimals").ToString)


                D13FormatSalary.OLSC11 = InsertFormat(dtOLSC.Rows(2).Item("Decimals").ToString)
                D13FormatSalary.OLSC12 = InsertFormat(dtOLSC.Rows(3).Item("Decimals").ToString)
                D13FormatSalary.OLSC13 = InsertFormat(dtOLSC.Rows(4).Item("Decimals").ToString)
                D13FormatSalary.OLSC14 = InsertFormat(dtOLSC.Rows(5).Item("Decimals").ToString)
                D13FormatSalary.OLSC15 = InsertFormat(dtOLSC.Rows(6).Item("Decimals").ToString)
                D13FormatSalary.OLSC21 = InsertFormat(dtOLSC.Rows(9).Item("Decimals").ToString)
                D13FormatSalary.OLSC22 = InsertFormat(dtOLSC.Rows(10).Item("Decimals").ToString)
                D13FormatSalary.OLSC23 = InsertFormat(dtOLSC.Rows(11).Item("Decimals").ToString)
                D13FormatSalary.OLSC24 = InsertFormat(dtOLSC.Rows(12).Item("Decimals").ToString)
                D13FormatSalary.OLSC25 = InsertFormat(dtOLSC.Rows(13).Item("Decimals").ToString)
            End If
            D13Format.DefaultNumber4 = "#,##0.0000"
            D13Format.DefaultNumber3 = "#,##0.000"
            D13Format.DefaultNumber2 = "#,##0.00"
            D13Format.DefaultNumber1 = "#,##0.0"
            D13Format.DefaultNumber0 = "#,##0"
        Catch ex As Exception
            D99C0008.MsgL3(ex.Message)
        End Try

    End Sub

    Public Function InsertFormat(ByVal sStrFormat As String) As String
        If IsNumeric(sStrFormat) Then
            Return ("#,##0" & InsertZero(Convert.ToInt16(sStrFormat)))
        Else
            Return ("#,##0" & InsertZero(0))
        End If
    End Function

    ''' <summary>
    ''' Hỏi trước khi lưu tùy thuộc vào thiết lập ở phần Tùy chọn
    ''' </summary>
    Public Function AskSave() As DialogResult
        If D13Options.MessageAskBeforeSave Then
            Return D99C0008.MsgAskSave()
        Else
            Return DialogResult.Yes
        End If
    End Function

    '    ''' <summary>
    '    ''' Thông báo trước khi khóa phiếu
    '    ''' </summary>    
    '    Public Function AskLocked() As DialogResult
    '        If D13Options.MessageAskBeforeSave Then
    '            Return D99C0008.MsgAsk(rL3("MSG000002"), MessageBoxDefaultButton.Button2)
    '        Else
    '            Return DialogResult.Yes
    '        End If
    '    End Function

    ''' <summary>
    ''' Thông báo khi lưu thành công tùy theo phần thiết lập ở tùy chọn
    ''' </summary>
    Public Sub SaveOK()
        If D13Options.MessageWhenSaveOK Then D99C0008.MsgSaveOK()
    End Sub

    ''' <summary>
    ''' Thông báo không khóa được phiếu
    ''' </summary>
    Public Sub LockedNotOK()
        D99C0008.MsgL3(rL3("MSG000003"))
    End Sub

    Public Sub LoadInfoGeneral()
        If gsDivisionID.Trim <> "" Then gsPayRollVoucherID = GetPayRollVoucherID() '89860 08/08/2016: Fix lỗi trên Desktop chọn lại kỳ phải Load lại PayRoll
        If D13Systems.LoadSystem Then Exit Sub
        LoadOptions()
        LoadSystems()
        LoadFormats()
        LoadCustomFormat()
        D13Systems.LoadSystem = True
    End Sub

End Module