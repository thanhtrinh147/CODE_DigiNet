Public Class D45F1131
    Private _bSaved As Boolean = False
    Public ReadOnly Property bSaved() As Boolean
        Get
            Return _bSaved
        End Get
    End Property

    Private _isPrice As Boolean = False
    Public ReadOnly Property IsPrice As Boolean
        Get
            Return _isPrice
        End Get
    End Property

    Private _isNorm As Boolean = False
    Public ReadOnly Property IsNorm As Boolean
        Get
            Return _isNorm
        End Get
    End Property

    Private _priceValue As Double = 0
    Public ReadOnly Property PriceValue As Double
        Get
            Return _priceValue
        End Get
    End Property

    Private _priceMethod As String = "0"
    Public ReadOnly Property PriceMethod As String
        Get
            Return _priceMethod
        End Get
    End Property

    Private _normMethod As String = "0"
    Public ReadOnly Property NormMethod As String
        Get
            Return _normMethod
        End Get
    End Property

    Private _normValue As Double = 0
    Public ReadOnly Property NormValue As Double
        Get
            Return _normValue
        End Get
    End Property

    Private Sub D45F1131_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Cursor = Cursors.WaitCursor
        LoadInfoGeneral() 'Load System/ Option /... in DxxD9940
        LoadLanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        InputbyUnicode(Me, gbUnicode)
        InputNumber(cnePriceValue, SqlDbType.Decimal, "N2", False, 18, 4)
        InputNumber(cneNormValue, SqlDbType.Decimal, "N2", False, 18, 4)
        InputPercent(cnePricePercent)
        InputPercent(cneNormPercent)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub D45F1131_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter
                UseEnterAsTab(Me, True)
        End Select
    End Sub
    Private Sub LoadLanguage()
        '================================================================ 
        Me.Text = rL3("Dieu_chinh_hang_loat") & " - " & Me.Name & UnicodeCaption(gbUnicode) '˜iÒu chÙnh hªng loÁt
        '================================================================ 
        btnAdjust.Text = rL3("Dieu__chinh") 'Điều &chỉnh
        '================================================================ 
        chkIsPrice.Text = rL3("Don_gia") 'Đơn giá
        chkIsNorm.Text = rL3("Dinh_muc") 'Định mức
        '================================================================ 
        tdbcPriceType.Columns("PriceType").Caption = rL3("Ma") 'Mã
        tdbcPriceType.Columns("PriceTypeName").Caption = rL3("Ten") 'Tên
        tdbcPriceMethod.Columns("PriceMethod").Caption = rL3("Ma") 'Mã
        tdbcPriceMethod.Columns("PriceMethodName").Caption = rL3("Ten") 'Tên
        tdbcNormType.Columns("NormType").Caption = rL3("Ma") 'Mã
        tdbcNormType.Columns("NormTypeName").Caption = rL3("Ten") 'Tên
        tdbcNormMethod.Columns("NormMethod").Caption = rL3("Ma") 'Mã
        tdbcNormMethod.Columns("NormMethodName").Caption = rL3("Ten") 'Tên
    End Sub
    Private Sub SetBackColorObligatory()
        tdbcPriceType.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcPriceMethod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        cnePriceValue.BackColor = COLOR_BACKCOLOROBLIGATORY
        cnePricePercent.BackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcNormType.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcNormMethod.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        cneNormValue.BackColor = COLOR_BACKCOLOROBLIGATORY
        cneNormPercent.BackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub
    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcPriceType
        sSQL = "--	Do nguon cho Combo Loai dieu chinh DG" & vbCrLf
        sSQL &= "SELECT		 '+' AS PriceType, N'" & rL3("Tang_U") & "' AS PriceTypeName" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		'-' AS PriceType, N'" & rL3("Giam") & "' AS PriceTypeName" & vbCrLf
        LoadDataSource(tdbcPriceType, sSQL, gbUnicode)

        'Load tdbcPriceMethod
        sSQL = "--	Do nguon cho Combo Phuong thuc đieu chinh DG" & vbCrLf
        sSQL &= "SELECT		 0 AS PriceMethod, N'" & rL3("Ti_le") & "' AS PriceMethodName" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		1 AS PriceMethod, N'" & rL3("Gia_triU") & "' AS PriceMethodName" & vbCrLf
        LoadDataSource(tdbcPriceMethod, sSQL, gbUnicode)

        'Load tdbcNormType
        sSQL = "--	Do nguon cho Combo Loai dieu chinh DM" & vbCrLf
        sSQL &= "SELECT		 '+' AS NormType, N'" & rL3("Tang_U") & "' AS NormTypeName" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		'-' AS NormType, N'" & rL3("Giam") & "' AS NormTypeName" & vbCrLf
        LoadDataSource(tdbcNormType, sSQL, gbUnicode)

        'Load tdbcNormMethod
        sSQL = "--	Do nguon cho Combo Phuong thuc đieu chinh DM" & vbCrLf
        sSQL &= "SELECT		 0 AS NormMethod, N'" & rL3("Ti_le") & "' AS NormMethodName" & vbCrLf
        sSQL &= "UNION ALL" & vbCrLf
        sSQL &= "SELECT 		1 AS NormMethod, N'" & rL3("Gia_triU") & "' AS NormMethodName" & vbCrLf
        LoadDataSource(tdbcNormMethod, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcPriceType"
    Private Sub tdbcPriceType_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceType.LostFocus
        If tdbcPriceType.FindStringExact(tdbcPriceType.Text) = -1 Then tdbcPriceType.Text = ""
    End Sub
#End Region

#Region "Events tdbcPriceMethod"
    Private Sub tdbcPriceMethod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceMethod.LostFocus
        If tdbcPriceMethod.FindStringExact(tdbcPriceMethod.Text) = -1 Then tdbcPriceMethod.Text = ""
    End Sub
    Private Sub tdbcPriceMethod_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcPriceMethod.SelectedValueChanged
        VisibledLable(lblPricePercent, cnePricePercent, cnePriceValue, ReturnValueC1Combo(tdbcPriceMethod))
    End Sub

#End Region

#Region "Events tdbcNormType"
    Private Sub tdbcNormType_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNormType.LostFocus
        If tdbcNormType.FindStringExact(tdbcNormType.Text) = -1 Then tdbcNormType.Text = ""
    End Sub
#End Region

#Region "Events tdbcNormMethod"
    Private Sub tdbcNormMethod_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcNormMethod.LostFocus
        If tdbcNormMethod.FindStringExact(tdbcNormMethod.Text) = -1 Then tdbcNormMethod.Text = ""
    End Sub
    Private Sub tdbcNormMethod_SelectedValueChanged(sender As Object, e As EventArgs) Handles tdbcNormMethod.SelectedValueChanged
        VisibledLable(lblNormPercent, cneNormPercent, cneNormValue, ReturnValueC1Combo(tdbcNormMethod))
    End Sub
#End Region
    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPriceType.Close, tdbcPriceMethod.Close, tdbcNormMethod.Close, tdbcNormType.Close
        tdbcName_Validated(sender, Nothing)
    End Sub
    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcPriceType.Validated, tdbcPriceMethod.Validated, tdbcNormMethod.Validated, tdbcNormType.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
    Private Sub VisibledLable(lblPercent As System.Windows.Forms.Label, cnePercent As C1.Win.C1Input.C1NumericEdit, cneValue As C1.Win.C1Input.C1NumericEdit, sValue As String)
        '0: Tỷ lệ'1: Giá trị
        Dim bResult As Boolean = L3Bool(sValue)
        lblPercent.Visible = Not bResult
        cnePercent.Visible = Not bResult
        cneValue.Visible = bResult
    End Sub

    Private Sub chkIsPrice_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsPrice.CheckedChanged
        If chkIsPrice.Checked Then
            UnReadOnlyControl(True, tdbcPriceType, tdbcPriceMethod, cnePriceValue)
        Else
            ReadOnlyControl(tdbcPriceType, tdbcPriceMethod, cnePriceValue)
        End If
    End Sub

    Private Sub chkIsNorm_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsNorm.CheckedChanged
        If chkIsNorm.Checked Then
            UnReadOnlyControl(True, tdbcNormType, tdbcNormMethod, cneNormValue)
        Else
            ReadOnlyControl(tdbcNormType, tdbcNormMethod, cneNormValue)
        End If
    End Sub
    Private Function AllowSave() As Boolean
        If chkIsPrice.Checked Then
            If tdbcPriceType.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose("")
                tdbcPriceType.Focus()
                Return False
            End If
            If tdbcPriceMethod.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose("")
                tdbcPriceMethod.Focus()
                Return False
            End If
            If cnePriceValue.Visible AndAlso Number(cnePriceValue.Value) = 0 Then
                D99C0008.MsgNotYetEnter(rL3("Gia_triU"))
                cnePriceValue.Focus()
                Return False
            End If
            If cnePricePercent.Visible AndAlso Number(cnePricePercent.Value) = 0 Then
                D99C0008.MsgNotYetEnter(lblPricePercent.Text)
                cnePricePercent.Focus()
                Return False
            End If
        End If
        If chkIsNorm.Checked Then
            If tdbcNormType.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose("")
                tdbcNormType.Focus()
                Return False
            End If
            If tdbcNormMethod.Text.Trim = "" Then
                D99C0008.MsgNotYetChoose("")
                tdbcNormMethod.Focus()
                Return False
            End If
            If cneNormValue.Visible AndAlso Number(cneNormValue.Value) = 0 Then
                D99C0008.MsgNotYetEnter(rL3("Gia_triU"))
                cneNormValue.Focus()
                Return False
            End If
            If cneNormPercent.Visible AndAlso Number(cneNormPercent.Value) = 0 Then
                D99C0008.MsgNotYetEnter(lblNormPercent.Text)
                cneNormPercent.Focus()
                Return False
            End If
        End If

        Return True
    End Function
    Private Sub btnAdjust_Click(sender As Object, e As EventArgs) Handles btnAdjust.Click
        'Chặn lỗi khi đang vi phạm trên lưới mà nhấn Alt + L
        btnAdjust.Focus()
        If btnAdjust.Focused = False Then Exit Sub
        '************************************
        If AllowSave() = False Then Exit Sub
        '************************************
        _bSaved = True
        If chkIsPrice.Checked Then
            _isPrice = True
            _priceValue = GetPriceValue(tdbcPriceMethod, tdbcPriceType, cnePricePercent, cnePriceValue, _priceMethod)
        End If
        If chkIsNorm.Checked Then
            _isNorm = True
            _normValue = GetPriceValue(tdbcNormMethod, tdbcNormType, cneNormPercent, cneNormValue, _normMethod)
        End If
        Me.Close()
    End Sub

    Private Function GetPriceValue(tdbcMethod As C1.Win.C1List.C1Combo, tdbcType As C1.Win.C1List.C1Combo, cnePercent As C1.Win.C1Input.C1NumericEdit, cneValue As C1.Win.C1Input.C1NumericEdit, ByRef sMethod As String) As Double
        Dim dPriceValue As Double = 0
        If ReturnValueC1Combo(tdbcMethod).ToString = "0" Then 'Tỷ lệ
            sMethod = "0"
            If ReturnValueC1Combo(tdbcType).ToString = "+" Then 'Tăng
                dPriceValue = 1 + Number(cnePercent.Value)
            Else 'Giảm
                dPriceValue = 1 - Number(cnePercent.Value)
            End If
        Else 'Giá trị
            sMethod = "1"
            If ReturnValueC1Combo(tdbcType).ToString = "+" Then 'Tăng
                dPriceValue = Number(cneValue.Value)
            Else 'Giảm
                dPriceValue = -Number(cneValue.Value)
            End If
        End If

        Return dPriceValue
    End Function

End Class