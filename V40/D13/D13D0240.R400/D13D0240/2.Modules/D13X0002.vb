''' <summary>
''' Module này dùng để khai báo các Sub và Function toàn cục
''' </summary>
''' <remarks>Các khai báo Sub và Function ở đây không được trùng với các khai báo
''' ở các module D99Xxxxx
''' </remarks>
Module D13X0002

    ''' <summary>
    ''' Thông báo dữ liệu đang được sử dụng , không cho mở lại hồ sơ lương
    ''' </summary>
    Public Function MsgNotReOpenSalaryFile() As String
        Dim sMsg As String = ""
        sMsg = rl3("Du_lieu_nay_dang_duoc_su_dung_Ban_khong_the_mo_lai")
        Return sMsg
    End Function
    Public ErrPr As New System.Windows.Forms.ErrorProvider
    ''' <summary>
    ''' Thông báo cột đã bị khóa khi nhấn phím nóng trên cột này để copy, xóa
    ''' </summary>
    Public Function MsgLockedColumn() As String
        Dim sMsg As String = ""
        sMsg = rl3("Cot_nay_da_bi_khoa_khong_duoc_phep_thao_tac_tren_cot_nay")
        Return sMsg
    End Function


    Public Function ComboValue(ByVal c1Combo As C1.Win.C1List.C1Combo) As String
        If c1Combo.Text = "" Then Return ""
        If c1Combo.SelectedValue IsNot Nothing Then
            Return c1Combo.SelectedValue.ToString
        Else
            Return ""
        End If
    End Function

    Public Const MaskFormatPeriod As String = "__/____"
    Public Const MaskFormatPeriodShort As String = "  /"

    Public Function L3PeriodValue(ByVal sPeriod As String) As String
        If sPeriod = MaskFormatDate Then Return MaskFormatPeriod
        If sPeriod.IndexOf("/") = -1 Then Return MaskFormatPeriod

        Dim oPeriod As Object = ConvertPeriod(sPeriod).ToString
        If IsDate(oPeriod) Then
            Return oPeriod.ToString
        Else
            Return MaskFormatPeriod
        End If
    End Function

    Private Function ConvertPeriod(ByVal sPeriod As String) As Object
        Try
            Dim arr() As String
            Dim nMonth As Integer
            Dim byPos As Double
            Dim sResult As String
            Dim sSeparator As String = "/"

            arr = Microsoft.VisualBasic.Split(sPeriod, sSeparator)
            nMonth = Convert.ToInt32(arr(0))

            'Tháng
            If nMonth < 1 Or nMonth > 12 Then
                Return MaskFormatDate
            Else
                sResult = nMonth.ToString("00")
            End If

            'Năm
            byPos = arr(1).IndexOf("_")
            Select Case byPos
                Case -1
                    If CInt(arr(1)) < 1900 Or CInt(arr(1)) > 2079 Then
                        Return MaskFormatDate
                    Else
                        sResult &= sSeparator & arr(1).ToString
                    End If
                Case 2
                    sResult &= sSeparator & (Year(Today.Date)).ToString.Substring(0, 2) & arr(1).Trim.Substring(0, 2)
                Case Else
                    sResult &= sSeparator & Year(Today.Date)
            End Select
            Return sResult

        Catch ex As Exception
            Return MaskFormatPeriod
        End Try
    End Function

    Public Function SQLPeriodSave(ByVal [Period] As String) As String
        If [Period] = "" Then Return "NULL"
        If [Period] = MaskFormatPeriodShort Then Return "NULL"
        If [Period] = MaskFormatPeriod Then Return "NULL"

        Dim sPeriod As String = ""
        sPeriod = [Period].Substring(3, 4) & [Period].Substring(0, 2)

        Return SQLString(sPeriod)
    End Function

    
End Module
