''' <summary>
''' LEANHVU: Lớp đang xây dụng kiểm tra dữ liệu hợp lệ
''' </summary>
''' <remarks></remarks>
Public Class GUIValidation

    Private Shared _listRequiredControl As List(Of Object)
    Public Shared ShowErrorProvider As Boolean = False ' Mặc định không dùng ErrorProvider.
    Public Shared ShowMsg As Boolean = True ' Mặc định thông báo theo Msg.
    Private Shared ShowedError As Boolean = False

    Public Shared Sub RequiredControl(ByVal ParamArray oParamArray() As Object)
        _listRequiredControl = New List(Of Object)
        _listRequiredControl.AddRange(oParamArray)
    End Sub

    'Private Shared ErrPr As System.Windows.Forms.ErrorProvider
    Public Shared Function CheckError() As Boolean
        Dim bError As Boolean = True
        'Dim ErrPr As System.Windows.Forms.ErrorProvider
        'If ShowErrorProvider Then
        '    ErrPr = New System.Windows.Forms.ErrorProvider()
        'End If
        If ErrPr IsNot Nothing AndAlso ShowErrorProvider Then
            ErrPr.Clear()
        End If
        Try
            If _listRequiredControl.Count = 0 Then
                Return True
            Else
                Dim iLen As Integer = _listRequiredControl.Count
                For index As Integer = 0 To iLen - 2 Step 2
                    Dim ctrl As Control
                    ctrl = CType(_listRequiredControl.Item(index), Control)
                    If ctrl.Text = "" Then
                        Dim stringErr As String = _listRequiredControl(index + 1).ToString()
                        If ShowMsg AndAlso bError Then 'Lê Anh Vũ: Chỉ hiển thị 1 lần duy nhất, nhưng set lỗi cho control thì phải chạy hết.
                            If TypeOf (ctrl) Is C1.Win.C1List.C1Combo Then
                                D99C0008.MsgNotYetChoose(stringErr) ' C1Combo thì thông báo chọn
                            Else
                                D99C0008.MsgNotYetEnter(stringErr) ' Thông báo nhập
                            End If
                            ctrl.Focus()
                            bError = False
                        End If
                        If ErrPr IsNot Nothing AndAlso ShowErrorProvider Then
                            ErrPr.SetError(ctrl, stringErr) ' Set lỗi cho tất cả control.
                        End If
                    End If
                Next
                Return bError
            End If
        Catch ex As Exception
            D99C0008.MsgL3("Lỗi truyền tham số: " & ex.Message)
        End Try
    End Function
End Class
