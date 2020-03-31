Imports System

Module D13X0007

    Public Class TextOnPaste
        Inherits NativeWindow

        Private tb As TextBox
        Private TypeCheck As EnumKey
        Private CheckString As String


        Private Sub New()
        End Sub

        Public Sub New(ByVal tb As TextBox, ByVal TypeCheck As EnumKey, Optional ByVal CheckString As String = "")
            Me.TypeCheck = TypeCheck
            Me.CheckString = CheckString
            Me.tb = tb
            Me.AssignHandle(tb.Handle)
        End Sub

        Private Const WM_PASTE As Integer = &H302

        Protected Overrides Sub WndProc(ByRef m As Message)
            'With every key press, click, key-combination press, etc a Message is sent to the
            ' window. You need to read about Win32 programming if you don't understand it.
            Select Case m.Msg
                Case WM_PASTE
                    'User has tried a way to paste something, like SHIFT+INSERT or
                    ' right-click context menu...
                    If Clipboard.GetDataObject.GetDataPresent(DataFormats.Text) Then
                        'What user has tried to paste is a piece of text...
                        Dim str As String = Clipboard.GetDataObject.GetData(DataFormats.Text).ToString
                        'Remove all appearances of coma
                        str = Replace(str, ",", "")
                        Dim NewVal As String
                        NewVal = Mid(tb.Text, 1, tb.SelectionStart) & str & Mid(tb.Text, tb.SelectionStart + tb.SelectionLength + 1, Len(tb.Text))
                        'NewVal will contain the future value of the textbox, if we would let
                        ' what user wanted to paste to actually paste there...
                        If CheckValidNumber(NewVal) Then
                            ' The result will be a numeric value. So go ahead and paste it!
                            tb.SelectedText = str
                        End If
                        ' We're done, so we exit the sub (not letting the default WndProc() to
                        ' paste the original string user tried to paste.
                        Exit Sub
                    End If
            End Select
            'In situations other than what we handled, the default WndProc() needs to be run
            MyBase.WndProc(m)

        End Sub

        '
        ''' <summary>
        ''' Kiểm tra số không hợp lệ
        ''' </summary>
        ''' <param name="NewVal">Giá trị cần paste vào</param>
        ''' <returns>True: hợp lệ </returns>
        ''' <remarks></remarks>
        Private Function CheckValidNumber(ByVal NewVal As String) As Boolean
            Select Case TypeCheck
                Case EnumKey.Number
                    If NewVal.Contains(".") Or NewVal.Contains("-") Then Return False
                Case EnumKey.NumberDot
                    If NewVal.Contains("-") Then Return False
                Case EnumKey.NumberSign
                    If NewVal.Contains(".") Then Return False
                Case EnumKey.Custom
                    For Each c As Char In NewVal
                        If Not CheckString.Contains(c) Then Return False
                    Next
                    Return True
            End Select
            If Not IsNumeric(NewVal) Then Return False
            Return True
        End Function
    End Class

    Public Const StringNumber As String = "0123456789"
    Public Const StringNumberDot As String = "0123456789."
    Public Const StringNumberSign As String = "0123456789-"
    Public Const StringNumberDotSign As String = "0123456789.-"

    Public Const StringTelephone As String = "0123456789()-"

#Region "Nhập số trên textbox và lưới"
    ''' <summary>
    ''' Checked number when the user presses and releases a key on the keyboard
    ''' </summary>
    ''' <param name="sender">Required. The control to be pressed</param>
    ''' <param name="KeyChar">Required. Char presses</param>
    ''' <param name="TypeCheck">Required. Chars are allow press </param>
    ''' <param name="CheckString">Optional. Chars are allow press when TypeCheck is Custom</param>
    ''' <returns>returns a value indicating whether the specified keychar occurs whithin this TypeCheck</returns>
    ''' <remarks></remarks>
    Private Function CheckKeyPress_Number(ByVal sender As Object, ByVal KeyChar As Char, ByVal TypeCheck As EnumKey, Optional ByVal CheckString As String = "") As Boolean
        Select Case TypeCheck
            Case EnumKey.Number
                If KeyChar = "." Or KeyChar = "-" Then Return True
            Case EnumKey.NumberDot
                If KeyChar = "-" Then Return True
            Case EnumKey.NumberSign
                If KeyChar = "." Then Return True
            Case EnumKey.Custom
                Return Not CheckString.Contains(KeyChar)
        End Select
        If sender Is Nothing Then Return False
        Dim tb As TextBox = CType(sender, TextBox)

        If tb.Text.StartsWith(",") Then ' update 22/7/2013 id 57344 - Textbox lương cơ bản = 7.000.000 vào sửa lương muốn thay đổi là 8.000.000 nhưng chỉ muốn nhập số 8 thay cho số 7 thì không được.
            tb.Text = tb.Text.Substring(1)
        End If

        If IsNumeric(KeyChar) And Not KeyChar = "-" Then
            Return Not IsNumeric(tb.Text & KeyChar)
        ElseIf KeyChar = "." Then
            If Not (tb.SelectedText = "." Or IsNumeric(tb.Text & KeyChar)) Then Return True
        ElseIf KeyChar = "-" Then
            If tb.SelectionStart <> 0 Or Microsoft.VisualBasic.Left(tb.Text, 1) = "-" Then Return True
        ElseIf Not Char.IsControl(KeyChar) Then
            Return True
        End If
    End Function

#Region "The DataType of TextBox is String"
    ''' <summary>
    ''' Entering number in textbox with DataType is String
    ''' </summary>
    ''' <param name="txtNumber">textbox name</param>
    ''' <param name="CheckString">The string is checked when TypeCheck = Custom</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckStringTextBox(ByVal txtNumber As TextBox, Optional ByVal CheckString As String = StringNumber)
        '  If txtNumber.ReadOnly OrElse txtNumber.Enabled = False Then Exit Sub
        Dim onPaste As New TextOnPaste(txtNumber, EnumKey.Custom, CheckString)

        txtNumber.Tag = "0;;" & EnumKey.Custom & ";" & CheckString
        AddHandler txtNumber.KeyPress, AddressOf txtNumber_KeyPress
        AddHandler txtNumber.Validating, AddressOf txtNumber_Validating
    End Sub

    ''' <summary>
    '''  Entering number in textboxs with DataType is String
    ''' </summary>
    ''' <param name="ar">textboxs name array have construct the same</param>
    ''' <param name="CheckString">The string is checked when TypeCheck = Custom</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckStringTextBox(ByVal ar() As TextBox, Optional ByVal CheckString As String = StringNumber)
        For i As Integer = 0 To ar.Length - 1
            CheckStringTextBox(ar(i), CheckString)
        Next
    End Sub
#End Region

#Region "The DataType of TextBox is Number"
    ''' <summary>
    ''' Entering number in textboxs with DataType is Number
    ''' </summary>
    ''' <param name="txtNumber">textbox name</param>
    ''' <param name="_EnumDataType">DataType input (string or number) to check overflow</param>
    ''' <param name="TypeCheck">char is checked whitout TypeCheck = Custom</param>
    ''' <param name="sNumberFormat">string format when LostFocus textbox</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckNumberTextBox(ByVal txtNumber As TextBox, ByVal sNumberFormat As String, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        If TypeCheck = EnumKey.Custom Then Exit Sub
        Dim num_digits As Integer = sNumberFormat.Substring(sNumberFormat.IndexOf("."c) + 1).Length
        CheckNumberTextBox(txtNumber, num_digits, _EnumDataType, TypeCheck)
    End Sub

    ''' <summary>
    ''' Entering number in textbox with DataType is Number
    ''' </summary>
    ''' <param name="txtNumber">textbox name</param>
    ''' <param name="_EnumDataType">DataType input (string or number) to check overflow</param>
    ''' <param name="TypeCheck">char is checked whithout TypeCheck = Custom</param>
    ''' <param name="num_digits">number digits to format value</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckNumberTextBox(ByVal txtNumber As TextBox, ByVal num_digits As Integer, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        ' If txtNumber.ReadOnly OrElse txtNumber.Enabled = False Then Exit Sub
        If TypeCheck = EnumKey.Custom Then Exit Sub
        Dim onPaste As New TextOnPaste(txtNumber, TypeCheck)

        txtNumber.Tag = _EnumDataType & ";" & num_digits & ";" & TypeCheck & ";"
        AddHandler txtNumber.KeyPress, AddressOf txtNumber_KeyPress

        AddHandler txtNumber.Validating, AddressOf txtNumber_Validating
    End Sub

    ''' <summary>
    '''  Entering number in textboxs with DataType is Number
    ''' </summary>
    ''' <param name="ar">Textbox array</param>
    ''' <param name="_EnumDataType">the same dataType</param>
    ''' <param name="sNumberFormat">the same number format string</param>
    ''' <param name="TypeCheck">char is checked when the user keypress whithout TypeCheck = Custom</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckNumberTextBox(ByVal ar() As TextBox, ByVal sNumberFormat As String, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        If TypeCheck = EnumKey.Custom Then Exit Sub
        For i As Integer = 0 To ar.Length - 1
            CheckNumberTextBox(ar(i), sNumberFormat, _EnumDataType, TypeCheck)
        Next
    End Sub

    ''' <summary>
    '''  Entering number in textboxs with DataType is Number
    ''' </summary>
    ''' <param name="ar">Textbox array</param>
    ''' <param name="_EnumDataType">the same dataType</param>
    ''' <param name="sNumberFormat">string format array when textbox is lostfocus</param>
    ''' <param name="TypeCheck">char is checked when the user keypress  whithout TypeCheck = Custom</param>
    ''' <remarks>Don't use TypeCheck = Custom</remarks>
    Public Sub CheckNumberTextBox(ByVal ar() As TextBox, ByVal sNumberFormat() As String, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        If TypeCheck = EnumKey.Custom Then Exit Sub
        For i As Integer = 0 To ar.Length - 1
            CheckNumberTextBox(ar(i), sNumberFormat(i), _EnumDataType, TypeCheck)
        Next
    End Sub

    Public Sub CheckNumberTextBox(ByVal ar() As TextBox, ByVal num_digits() As Integer, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        For i As Integer = 0 To ar.Length - 1
            CheckNumberTextBox(ar(i), num_digits(i), _EnumDataType, TypeCheck)
        Next
    End Sub

    Public Sub CheckNumberTextBox(ByVal ar() As TextBox, ByVal num_digits As Integer, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        For i As Integer = 0 To ar.Length - 1
            CheckNumberTextBox(ar(i), num_digits, _EnumDataType, TypeCheck)
        Next
    End Sub
#End Region

#Region "The DataType of TrueDBGrid is String"
    ''' <summary>
    ''' DataType of column is String
    ''' </summary>
    ''' <param name="tdbg">truedbgrid name</param>
    ''' <param name="iCol">column name</param>
    ''' <param name="CheckString">The string is checked when TypeCheck = Custom</param>
    ''' <remarks>This function is set in Form_Load event</remarks>
    Public Sub CheckStringTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As String, Optional ByVal CheckString As String = StringNumber)
        Dim txtNumber As New TextBox
        txtNumber.BorderStyle = BorderStyle.None

        CheckStringTextBox(txtNumber, CheckString)

        tdbg.Columns(iCol).Editor = txtNumber

        AddHandler txtNumber.LostFocus, AddressOf txtNumber_LostFocus

        AddHandler tdbg.RowColChange, AddressOf tdbg_RowColChange
    End Sub

    Public Sub CheckStringTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, Optional ByVal CheckString As String = StringNumber)
        CheckStringTDBGrid(tdbg, tdbg.Columns(iCol).DataField, CheckString)
    End Sub

    Public Sub CheckStringTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol() As Integer, Optional ByVal CheckString As String = StringNumber)
        For i As Integer = 0 To iCol.Length - 1
            CheckStringTDBGrid(tdbg, iCol(i), CheckString)
        Next
    End Sub

    Public Sub CheckStringTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol() As String, Optional ByVal CheckString As String = StringNumber)
        For i As Integer = 0 To iCol.Length - 1
            CheckStringTDBGrid(tdbg, iCol(i), CheckString)
        Next
    End Sub
#End Region

#Region "The DataType of TrueDBGrid is Number"

    ''' <summary>
    ''' Check number input grid
    ''' </summary>
    ''' <param name="tdbg">truedbgrid name</param>
    ''' <param name="iCol">column name</param>
    ''' <param name="_EnumDataType">DataType input (string or number) to check overflow</param>
    ''' <param name="TypeCheck">char is checked whithout TypeCheck = Custom</param>
    ''' <remarks>This function is set in Form_Load event, after tdbg_NumberFormat() function</remarks>
    Public Sub CheckNumberTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As String, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        Dim txtNumber As New TextBox
        txtNumber.BorderStyle = BorderStyle.None
        txtNumber.TextAlign = HorizontalAlignment.Right
        txtNumber.MaxLength = tdbg.Columns(iCol).DataWidth

        Dim sNumberFormat As Object = IIf(tdbg.Columns(iCol).NumberFormat.Contains("Event"), tdbg.Columns(iCol).Tag, tdbg.Columns(iCol).NumberFormat)

        Dim iNumDigits As Integer = ReturnNumDigits(sNumberFormat)
        CheckNumberTextBox(txtNumber, iNumDigits, _EnumDataType, TypeCheck)

        tdbg.Columns(iCol).Editor = txtNumber

        AddHandler txtNumber.GotFocus, AddressOf txtNumber_GotFocus
        AddHandler txtNumber.LostFocus, AddressOf txtNumber_LostFocus

        AddHandler tdbg.RowColChange, AddressOf tdbg_RowColChange
    End Sub


    Public Sub CheckNumberTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol As Integer, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        CheckNumberTDBGrid(tdbg, tdbg.Columns(iCol).DataField, _EnumDataType, TypeCheck)
    End Sub

    Public Sub CheckNumberTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol() As Integer, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        For i As Integer = 0 To iCol.Length - 1
            CheckNumberTDBGrid(tdbg, iCol(i), _EnumDataType, TypeCheck)
        Next
    End Sub

    Public Sub CheckNumberTDBGrid(ByRef tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid, ByVal iCol() As String, Optional ByVal _EnumDataType As EnumDataType = EnumDataType.Number, Optional ByVal TypeCheck As EnumKey = EnumKey.NumberDot)
        For i As Integer = 0 To iCol.Length - 1
            CheckNumberTDBGrid(tdbg, iCol(i), _EnumDataType, TypeCheck)
        Next
    End Sub
#End Region


#Region "Events of TextBox"

    Private Sub txtNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) ', ByVal TypeCheck As EnumKey, Optional ByVal CheckString As String = "")
        Select Case e.KeyChar
            Case Chr(8), Chr(9), Chr(13) 'BackSpace, Tab, Enter
                e.Handled = False : Exit Sub
        End Select
        Dim txtNumber As TextBox = CType(sender, TextBox)
        Dim TypeCheck As EnumKey = 0
        Dim CheckString As String = ""
        If txtNumber.Tag IsNot Nothing Then
            Dim arr() As String = txtNumber.Tag.ToString.Split(";"c)
            If arr.Length > 2 Then TypeCheck = CType(arr(2), EnumKey)
            If arr.Length > 3 Then CheckString = arr(3)
        End If
        e.Handled = CheckKeyPress_Number(sender, e.KeyChar, TypeCheck, CheckString)
    End Sub

    Private Sub txtNumber_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Dim txtNumber As TextBox = CType(sender, TextBox)
        If txtNumber.ReadOnly OrElse txtNumber.Enabled = False Then Exit Sub
        Dim DataType As EnumDataType = EnumDataType.Number
        Dim num_digits As Integer = 0
        If txtNumber.Tag IsNot Nothing Then
            Dim arr() As String = txtNumber.Tag.ToString.Split(";"c)
            If arr.Length = 0 OrElse arr(0).ToString.Equals("0") Then Exit Sub 'TH Chuỗi không cần format
            DataType = CType(arr(0), EnumDataType)
            If arr.Length > 1 Then num_digits = L3Int(arr(1))
        End If
        If txtNumber.Text <> "" And Not L3IsNumeric(txtNumber.Text, DataType) Then e.Cancel = True : Exit Sub
        txtNumber.Text = FormatRoundNumber(txtNumber.Text, num_digits) ' Format(Number(txtNumber.Text), sNumberFormat)
    End Sub

    Private Sub txtNumber_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtNumber As TextBox = CType(sender, TextBox)
        ' If txtNumber.Parent.Name.Contains("tdbg") = False Then Exit Sub
        If txtNumber.Text = "" OrElse IsNumeric(txtNumber.Text) = False Then Exit Sub
        Dim num_digits As Integer = 0
        If txtNumber.Tag IsNot Nothing Then
            Dim arr() As String = txtNumber.Tag.ToString.Split(";"c)
            If arr.Length = 0 OrElse arr(0).ToString.Equals("0") Then Exit Sub 'TH Chuỗi không cần format
            If arr.Length > 1 Then num_digits = L3Int(arr(1))
        End If
        txtNumber.Text = FormatRoundNumber(txtNumber.Text, num_digits) ' txtNumber.Text = Format(Number(txtNumber.Text), sNumberFormat)
    End Sub

    Private Sub txtNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim txtNumber As TextBox = CType(sender, TextBox)
        'If txtNumber.Parent.Name.Contains("tdbg") = False Then Exit Sub
        'Nếu không phải trên lưới thì không cần sự kiện này
        ' If Not TypeOf (txtNumber.Parent) Is C1.Win.C1TrueDBGrid.C1TrueDBGrid Then Exit Sub
        Dim tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(txtNumber.Parent, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        tdbg.Focus()
        tdbg.UpdateData()
    End Sub

#End Region

#Region "Events of TrueDBGrid"

    Private Sub tdbg_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs)
        Dim tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid = CType(sender, C1.Win.C1TrueDBGrid.C1TrueDBGrid)
        Dim txtID As TextBox = CType(tdbg.Columns(tdbg.Col).Editor, TextBox)
        If txtID Is Nothing OrElse txtID.Tag Is Nothing Then Exit Sub
        If tdbg.Row Mod 2 = 0 Then 'Dòng chẵn
            txtID.BackColor = tdbg.EvenRowStyle.BackColor
        Else
            txtID.BackColor = tdbg.OddRowStyle.BackColor
        End If

    End Sub

#End Region
#End Region
End Module

