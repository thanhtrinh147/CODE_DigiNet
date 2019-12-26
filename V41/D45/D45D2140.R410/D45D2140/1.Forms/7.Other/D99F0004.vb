Imports System.Reflection
Imports System.IO

Friend Class D99F0004
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button

    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblImage As System.Windows.Forms.Label
    Friend WithEvents imgList As System.Windows.Forms.ImageList

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D99F0004))
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnNo = New System.Windows.Forms.Button
        Me.imgList = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCancel = New System.Windows.Forms.Button
        Me.lblMessage = New System.Windows.Forms.Label
        Me.lblImage = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(31, 70)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 22)
        Me.btnOK.TabIndex = 0
        Me.btnOK.Text = "OK"
        Me.btnOK.Visible = False
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(116, 70)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(75, 22)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Yes"
        Me.btnYes.Visible = False
        '
        'btnNo
        '
        Me.btnNo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNo.ImageList = Me.imgList
        Me.btnNo.Location = New System.Drawing.Point(201, 70)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(75, 22)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "No"
        Me.btnNo.Visible = False
        '
        'imgList
        '
        Me.imgList.ImageStream = CType(resources.GetObject("imgList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgList.TransparentColor = System.Drawing.Color.Transparent
        Me.imgList.Images.SetKeyName(0, "Error.bmp")
        Me.imgList.Images.SetKeyName(1, "Exclamation.bmp")
        Me.imgList.Images.SetKeyName(2, "Information.bmp")
        Me.imgList.Images.SetKeyName(3, "Question.bmp")
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(286, 70)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.Control
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(56, 22)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(321, 31)
        Me.lblMessage.TabIndex = 4
        '
        'lblImage
        '
        Me.lblImage.ImageIndex = 0
        Me.lblImage.ImageList = Me.imgList
        Me.lblImage.Location = New System.Drawing.Point(10, 9)
        Me.lblImage.Name = "lblImage"
        Me.lblImage.Size = New System.Drawing.Size(31, 33)
        Me.lblImage.TabIndex = 5
        '
        'D99F0004
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(397, 105)
        Me.Controls.Add(Me.lblImage)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D99F0004"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private eLanguage As EnumLanguage
    Private strMessage As String
    Private strCaption As String
    Private nSelectedIcon As L3MessageBoxIcon
    Private eButton As L3MessageBoxButtons
    Private nDefaultButton As MessageBoxDefaultButton
    Private nDialogResult As DialogResult

    ' For positioning
    Dim nMessageLeft As Int16
    Dim nIconLeft As Int16
    Dim nButtonLeft As Int16
    Dim nButtonTop As Int16
    Dim bCallButton As Boolean = False
    Dim clsMessage As New D99C0008

    Public Property Language() As Int16
        Get
            Return CType(eLanguage, Short)
        End Get
        Set(ByVal Value As Int16)
            eLanguage = CType(Value, EnumLanguage)
        End Set
    End Property

    Public Property Message() As String
        Get
            Return strMessage
        End Get
        Set(ByVal Value As String)
            strMessage = Value

            lblMessage.Text = Value
        End Set
    End Property

    Public Property Caption() As String
        Get
            Return strCaption
        End Get
        Set(ByVal Value As String)
            strCaption = Value

            Me.Text = Value
        End Set
    End Property

    Public WriteOnly Property SelectedIcon() As Short
        Set(ByVal Value As Short)
            nSelectedIcon = CType(Value, L3MessageBoxIcon)
        End Set
    End Property

    Public Property MessageBoxButtons() As L3MessageBoxButtons
        Get
            Return eButton
        End Get

        Set(ByVal Value As L3MessageBoxButtons)
            eButton = Value
        End Set
    End Property

    Public WriteOnly Property DefaultButton() As MessageBoxDefaultButton
        Set(ByVal Value As MessageBoxDefaultButton)
            nDefaultButton = Value
        End Set
    End Property

    Public ReadOnly Property L3DialogResult() As DialogResult
        Get
            Return nDialogResult
        End Get
    End Property

    Public Sub MyShow()
        SetIcon()
        SetLanguage()
        Reposition()
        Me.ShowDialog()
    End Sub

    Private Sub SetIcon()

        Try
            Select Case nSelectedIcon
                Case L3MessageBoxIcon.None
                    lblImage.Visible = False
                Case L3MessageBoxIcon.Err
                    lblImage.ImageIndex = 0
                Case L3MessageBoxIcon.Exclamation
                    lblImage.ImageIndex = 1
                Case L3MessageBoxIcon.Information
                    lblImage.ImageIndex = 2
                Case L3MessageBoxIcon.Question
                    lblImage.ImageIndex = 3
            End Select
        Catch ex As Exception
            MessageBox.Show("Kh¤ng câ icons. BÁn hºy xem lÁi ¢§éng dÉn cÀc icons.", "Thông báo", Windows.Forms.MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub SetLanguage()
        'btnOK.Text = "OK"
        'btnCancel.Text = "Cancel"
        'btnYes.Text = "Yes"
        'btnNo.Text = "No"
    End Sub

    Private Function SeperateStr(ByVal str As String, ByVal maxCharPerRow As Integer, ByRef nSpace As Integer) As String
        'Rã chuỗi theo chiều dài maxCharPerRow + thêm vbcrlf vào
        Dim i, j, length As Int16
        Dim sTemp As String = ""
        Dim sItem As String = ""

        i = 0 : length = CType(str.Length, Short)
        nSpace = 0

        While i < length - 1
            If str.Length > maxCharPerRow Then
                If str.Substring(maxCharPerRow - 1, 1) <> " " Then
                    For j = CType(maxCharPerRow - 1, Short) To 1 Step -1
                        If str.Substring(j - 1, 1) = " " Then Exit For
                    Next j
                    sItem = str.Substring(0, j)
                    sTemp = sTemp & sItem & vbCrLf
                    str = str.Substring(j, str.Length - j)
                    i = i + j
                Else
                    sItem = str.Substring(0, maxCharPerRow)
                    sTemp = sTemp & sItem & vbCrLf
                    str = str.Substring(maxCharPerRow, str.Length - maxCharPerRow)
                    i = CType(i + maxCharPerRow - 1, Short)
                End If
                nSpace += 1
            Else

                nSpace += 1
                sTemp = sTemp & str
                Return sTemp

            End If
        End While
        Return sTemp
    End Function

    Private Sub Reposition()
        If Trim(strMessage) = "" Then Exit Sub
        ' Canh khoảng cách  Form<-> control ở 2 biên trái phải là 10; 2 bên trên là 40
        Dim nFormWidth As Int16 ' Chiều dài form
        Dim nSpace As Integer = 13 ' khoảng cách 2 dòng trên Label
        Dim nMaxMsgWidth As Integer = 450 ' Max Width của label 400
        Dim nMaxCharPerRow As Integer = 75 ' Số ký tự tối đa trên 1 dòng của label 66
        ' Với chiều dài label tối đa là 400 thì chứa tối đa là 66 ký tự
        '---------------------------------------------------------------
        'Canh  message
        If nSelectedIcon <> L3MessageBoxIcon.None Then
            nMessageLeft = 56 ' Vị trí icon 
        Else
            nMessageLeft = 10 ' vị trí LblMessage
        End If
        lblMessage.Left = nMessageLeft

        ' Tính lại độ rộng của Label trong TH Message có chứa ký tự VbCrlf
        Dim aChar(), strMsg As String
        Dim i, nMsgHeight, nMsgWidth, nSpaceCount As Integer

        'Dùng Regex cắt Message thành nhiều dòng dựa trên các ký tự VbCrlf,mỗi dòng là 1 chuỗi được lưu trong aChar
        strMsg = "" : nMsgHeight = 0 : nSpaceCount = 0
        Dim rg As New System.Text.RegularExpressions.Regex(vbCrLf)
        aChar = rg.Split(strMessage)
        rg = Nothing

        '-------------------------------------------------------------------------------
        'Duyệt qua tùng dòng kiểm tra xem độ dài ký tự của mỗi dòng có lớn hơn nnMaxCharPerRow ko?
        'Nếu lớn hơn thì tách dòng đó thành nhiều dòng con.
        For i = 0 To aChar.Length - 1
            If aChar(i).Length > nMaxCharPerRow Then
                strMsg = strMsg & SeperateStr(aChar(i), nMaxCharPerRow, nSpaceCount) & vbCrLf
                nMsgHeight += nSpaceCount * nSpace
            Else
                strMsg = strMsg & aChar(i) & vbCrLf
                nMsgHeight += nSpace
            End If
        Next
        strMsg = strMsg.Substring(0, strMsg.Length - 2)

        strMessage = strMsg & Space(1)
        lblMessage.Text = strMessage
        '-----------------------------------------------------------------

        lblMessage.AutoSize = True
        nMsgWidth = lblMessage.Width

        If nMsgHeight <> nSpace Then
            lblMessage.AutoSize = False
            lblMessage.Top = lblImage.Top
            lblMessage.Width = nMsgWidth
            lblMessage.Height = nMsgHeight
        End If
        '---------------------------------------------------------------

        'Lấy và kiểm tra chiều ngang form
        nFormWidth = CType(lblMessage.Left + lblMessage.Width + 20, Short)
        Select Case eButton
            Case L3MessageBoxButtons.OK
                If nFormWidth < 120 Then
                    Me.Width = 120
                Else
                    Me.Width = nFormWidth
                End If
            Case L3MessageBoxButtons.OKCancel, L3MessageBoxButtons.YesNo
                If nFormWidth < 200 Then
                    Me.Width = 200
                Else
                    Me.Width = nFormWidth
                End If
            Case L3MessageBoxButtons.YesNoCancel
                If nFormWidth < 280 Then
                    Me.Width = 280
                Else
                    Me.Width = nFormWidth
                End If
            Case Else
                Me.Width = nFormWidth
        End Select
        '---------------------------------------------------------------
        'Tính lại Top của button và canh giữa các button trong form
        nButtonTop = CType(lblMessage.Top + lblMessage.Height + 15, Short)

        Select Case eButton
            Case L3MessageBoxButtons.OK
                btnOK.Left = CType(Me.Width / 2 - btnOK.Width / 2 - 3, Integer)
            Case L3MessageBoxButtons.YesNo
                btnYes.Left = CType(Me.Width / 2 - btnYes.Width - 3, Integer)
                btnNo.Left = CType(Me.Width / 2 + 2, Integer)
            Case L3MessageBoxButtons.OKCancel
                btnOK.Left = CType(Me.Width / 2 - btnOK.Width - 3, Integer)
                btnCancel.Left = CType(Me.Width / 2 + 2, Integer)
            Case L3MessageBoxButtons.YesNoCancel
                btnNo.Left = CType(Me.Width / 2 - btnNo.Width / 2 - 3, Integer)
                btnYes.Left = btnNo.Left - btnYes.Width - 5
                btnCancel.Left = btnNo.Left + btnCancel.Width + 5
        End Select

        btnYes.Top = nButtonTop
        btnNo.Top = nButtonTop
        btnOK.Top = nButtonTop
        btnCancel.Top = nButtonTop
        '---------------------------------------------------------------
        'Chiều cao của form tính từ button + 40
        Me.Height = btnYes.Top + btnYes.Height + 40
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        nDialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        nDialogResult = System.Windows.Forms.DialogResult.Yes
        bCallButton = True
        Me.Close()
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        nDialogResult = System.Windows.Forms.DialogResult.No
        bCallButton = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        nDialogResult = System.Windows.Forms.DialogResult.Cancel
        bCallButton = True
        Me.Close()
    End Sub

    Private Sub D99F0004_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If btnYes.Visible And Not bCallButton Then
            If e.CloseReason = CloseReason.UserClosing Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub MessageForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Me.btnOK.Visible = False
        Me.btnYes.Visible = False
        Me.btnNo.Visible = False
        Me.btnCancel.Visible = False

        Select Case eButton
            Case L3MessageBoxButtons.OK
                Me.btnOK.Visible = True
            Case L3MessageBoxButtons.OKCancel
                Me.btnOK.Visible = True
                Me.btnCancel.Visible = True
            Case L3MessageBoxButtons.YesNo
                Me.btnYes.Visible = True
                Me.btnNo.Visible = True
            Case L3MessageBoxButtons.YesNoCancel
                Me.btnYes.Visible = True
                Me.btnNo.Visible = True
                Me.btnCancel.Visible = True
        End Select
    End Sub

    Private Sub MessageForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        strMessage = ""
        strCaption = ""
        SetResolutionForm(Me)
    End Sub

    Private Sub MessageForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        ' Default Button
        Select Case nDefaultButton
            Case MessageBoxDefaultButton.Button1
                Select Case eButton
                    Case L3MessageBoxButtons.OKCancel
                        btnOK.Focus()
                    Case L3MessageBoxButtons.YesNo, L3MessageBoxButtons.YesNoCancel
                        btnYes.Focus()
                End Select
            Case MessageBoxDefaultButton.Button2
                Select Case eButton
                    Case L3MessageBoxButtons.OKCancel
                        btnCancel.Focus()
                    Case L3MessageBoxButtons.YesNo, L3MessageBoxButtons.YesNoCancel
                        btnNo.Focus()
                End Select
            Case MessageBoxDefaultButton.Button3
                Select Case eButton
                    Case L3MessageBoxButtons.YesNoCancel
                        btnCancel.Focus()
                End Select
        End Select
    End Sub

End Class
