<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F0001
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F0001))
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tabSystem = New System.Windows.Forms.TabControl
        Me.TabPageMainInfo = New System.Windows.Forms.TabPage
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.chkIsUseAppRecruitProposal = New System.Windows.Forms.CheckBox
        Me.lblDefaultDivision = New System.Windows.Forms.Label
        Me.tdbcInterviewerDefault = New C1.Win.C1List.C1Combo
        Me.txtIntPlaceDefault = New System.Windows.Forms.TextBox
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.txtDefaultPeriod = New System.Windows.Forms.TextBox
        Me.lblDefaultPeriod = New System.Windows.Forms.Label
        Me.txtPeriodNumber = New System.Windows.Forms.TextBox
        Me.lblNumberPeriod = New System.Windows.Forms.Label
        Me.txtDivisionName = New System.Windows.Forms.TextBox
        Me.lblIntPlaceDefault = New System.Windows.Forms.Label
        Me.lblInterviewerDefault = New System.Windows.Forms.Label
        Me.txtRecSourceName = New System.Windows.Forms.TextBox
        Me.tagPageAuto = New System.Windows.Forms.TabPage
        Me.chkAutoInterviewFileID = New System.Windows.Forms.CheckBox
        Me.chkAutoRecInformationID = New System.Windows.Forms.CheckBox
        Me.chkSeparator = New System.Windows.Forms.CheckBox
        Me.lblCandidateOutputLength = New System.Windows.Forms.Label
        Me.c1NumCandudateOutputLength = New System.Windows.Forms.NumericUpDown
        Me.cboCandidateOutputOrder = New System.Windows.Forms.ComboBox
        Me.cboCandidateSeparator = New System.Windows.Forms.ComboBox
        Me.chkCandidateS5Type = New System.Windows.Forms.CheckBox
        Me.chkCandidateS4Type = New System.Windows.Forms.CheckBox
        Me.chkSupply = New System.Windows.Forms.CheckBox
        Me.chkAuto = New System.Windows.Forms.CheckBox
        Me.chkCandidateS3Type = New System.Windows.Forms.CheckBox
        Me.chkCandidateS2Type = New System.Windows.Forms.CheckBox
        Me.chkCandidateS1Type = New System.Windows.Forms.CheckBox
        Me.chkAutoCandidateID = New System.Windows.Forms.CheckBox
        Me.lblCandidateOutputOrder = New System.Windows.Forms.Label
        Me.TabPageOther = New System.Windows.Forms.TabPage
        Me.optRecruimentActualQTYMode0 = New System.Windows.Forms.RadioButton
        Me.optRecruimentActualQTYMode1 = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.tabSystem.SuspendLayout()
        Me.TabPageMainInfo.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcInterviewerDefault, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tagPageAuto.SuspendLayout()
        CType(Me.c1NumCandudateOutputLength, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(384, 257)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(467, 257)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabSystem
        '
        Me.tabSystem.Controls.Add(Me.TabPageMainInfo)
        Me.tabSystem.Controls.Add(Me.tagPageAuto)
        Me.tabSystem.Controls.Add(Me.TabPageOther)
        Me.tabSystem.Location = New System.Drawing.Point(3, 3)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.SelectedIndex = 0
        Me.tabSystem.Size = New System.Drawing.Size(540, 252)
        Me.tabSystem.TabIndex = 0
        '
        'TabPageMainInfo
        '
        Me.TabPageMainInfo.Controls.Add(Me.grp1)
        Me.TabPageMainInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMainInfo.Name = "TabPageMainInfo"
        Me.TabPageMainInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMainInfo.Size = New System.Drawing.Size(532, 226)
        Me.TabPageMainInfo.TabIndex = 0
        Me.TabPageMainInfo.Text = "1. Thông tin chính"
        Me.TabPageMainInfo.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.chkIsUseAppRecruitProposal)
        Me.grp1.Controls.Add(Me.lblDefaultDivision)
        Me.grp1.Controls.Add(Me.tdbcInterviewerDefault)
        Me.grp1.Controls.Add(Me.txtIntPlaceDefault)
        Me.grp1.Controls.Add(Me.tdbcDivisionID)
        Me.grp1.Controls.Add(Me.txtDefaultPeriod)
        Me.grp1.Controls.Add(Me.lblDefaultPeriod)
        Me.grp1.Controls.Add(Me.txtPeriodNumber)
        Me.grp1.Controls.Add(Me.lblNumberPeriod)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Controls.Add(Me.lblIntPlaceDefault)
        Me.grp1.Controls.Add(Me.lblInterviewerDefault)
        Me.grp1.Controls.Add(Me.txtRecSourceName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(521, 211)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'chkIsUseAppRecruitProposal
        '
        Me.chkIsUseAppRecruitProposal.AutoSize = True
        Me.chkIsUseAppRecruitProposal.Checked = True
        Me.chkIsUseAppRecruitProposal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsUseAppRecruitProposal.Location = New System.Drawing.Point(15, 170)
        Me.chkIsUseAppRecruitProposal.Name = "chkIsUseAppRecruitProposal"
        Me.chkIsUseAppRecruitProposal.Size = New System.Drawing.Size(199, 17)
        Me.chkIsUseAppRecruitProposal.TabIndex = 13
        Me.chkIsUseAppRecruitProposal.Text = "Duyệt nhiều cấp đề xuất tuyển dụng"
        Me.chkIsUseAppRecruitProposal.UseVisualStyleBackColor = True
        '
        'lblDefaultDivision
        '
        Me.lblDefaultDivision.AutoSize = True
        Me.lblDefaultDivision.Location = New System.Drawing.Point(13, 23)
        Me.lblDefaultDivision.Name = "lblDefaultDivision"
        Me.lblDefaultDivision.Size = New System.Drawing.Size(85, 13)
        Me.lblDefaultDivision.TabIndex = 12
        Me.lblDefaultDivision.Text = "Đơn vị mặc định"
        Me.lblDefaultDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcInterviewerDefault
        '
        Me.tdbcInterviewerDefault.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcInterviewerDefault.AllowColMove = False
        Me.tdbcInterviewerDefault.AllowSort = False
        Me.tdbcInterviewerDefault.AlternatingRows = True
        Me.tdbcInterviewerDefault.AutoCompletion = True
        Me.tdbcInterviewerDefault.AutoDropDown = True
        Me.tdbcInterviewerDefault.Caption = ""
        Me.tdbcInterviewerDefault.CaptionHeight = 17
        Me.tdbcInterviewerDefault.CaptionStyle = Style17
        Me.tdbcInterviewerDefault.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcInterviewerDefault.ColumnCaptionHeight = 17
        Me.tdbcInterviewerDefault.ColumnFooterHeight = 17
        Me.tdbcInterviewerDefault.ColumnWidth = 100
        Me.tdbcInterviewerDefault.ContentHeight = 17
        Me.tdbcInterviewerDefault.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcInterviewerDefault.DisplayMember = "InterviewerDefault"
        Me.tdbcInterviewerDefault.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcInterviewerDefault.DropDownWidth = 300
        Me.tdbcInterviewerDefault.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcInterviewerDefault.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcInterviewerDefault.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcInterviewerDefault.EditorHeight = 17
        Me.tdbcInterviewerDefault.EmptyRows = True
        Me.tdbcInterviewerDefault.EvenRowStyle = Style18
        Me.tdbcInterviewerDefault.ExtendRightColumn = True
        Me.tdbcInterviewerDefault.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcInterviewerDefault.FooterStyle = Style19
        Me.tdbcInterviewerDefault.HeadingStyle = Style20
        Me.tdbcInterviewerDefault.HighLightRowStyle = Style21
        Me.tdbcInterviewerDefault.Images.Add(CType(resources.GetObject("tdbcInterviewerDefault.Images"), System.Drawing.Image))
        Me.tdbcInterviewerDefault.ItemHeight = 15
        Me.tdbcInterviewerDefault.Location = New System.Drawing.Point(129, 100)
        Me.tdbcInterviewerDefault.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcInterviewerDefault.MaxDropDownItems = CType(8, Short)
        Me.tdbcInterviewerDefault.MaxLength = 32767
        Me.tdbcInterviewerDefault.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcInterviewerDefault.Name = "tdbcInterviewerDefault"
        Me.tdbcInterviewerDefault.OddRowStyle = Style22
        Me.tdbcInterviewerDefault.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcInterviewerDefault.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcInterviewerDefault.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcInterviewerDefault.SelectedStyle = Style23
        Me.tdbcInterviewerDefault.Size = New System.Drawing.Size(128, 23)
        Me.tdbcInterviewerDefault.Style = Style24
        Me.tdbcInterviewerDefault.TabIndex = 4
        Me.tdbcInterviewerDefault.ValueMember = "InterviewerDefault"
        Me.tdbcInterviewerDefault.PropBag = resources.GetString("tdbcInterviewerDefault.PropBag")
        '
        'txtIntPlaceDefault
        '
        Me.txtIntPlaceDefault.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtIntPlaceDefault.Location = New System.Drawing.Point(129, 131)
        Me.txtIntPlaceDefault.MaxLength = 250
        Me.txtIntPlaceDefault.Name = "txtIntPlaceDefault"
        Me.txtIntPlaceDefault.Size = New System.Drawing.Size(383, 22)
        Me.txtIntPlaceDefault.TabIndex = 6
        '
        'tdbcDivisionID
        '
        Me.tdbcDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDivisionID.AllowColMove = False
        Me.tdbcDivisionID.AllowSort = False
        Me.tdbcDivisionID.AlternatingRows = True
        Me.tdbcDivisionID.AutoCompletion = True
        Me.tdbcDivisionID.AutoDropDown = True
        Me.tdbcDivisionID.Caption = ""
        Me.tdbcDivisionID.CaptionHeight = 17
        Me.tdbcDivisionID.CaptionStyle = Style25
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDivisionID.ColumnCaptionHeight = 17
        Me.tdbcDivisionID.ColumnFooterHeight = 17
        Me.tdbcDivisionID.ColumnWidth = 100
        Me.tdbcDivisionID.ContentHeight = 17
        Me.tdbcDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDivisionID.DisplayMember = "DivisionID"
        Me.tdbcDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDivisionID.DropDownWidth = 400
        Me.tdbcDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EditorHeight = 17
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.EvenRowStyle = Style26
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.FooterStyle = Style27
        Me.tdbcDivisionID.HeadingStyle = Style28
        Me.tdbcDivisionID.HighLightRowStyle = Style29
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.ItemHeight = 15
        Me.tdbcDivisionID.Location = New System.Drawing.Point(129, 19)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.OddRowStyle = Style30
        Me.tdbcDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.SelectedStyle = Style31
        Me.tdbcDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDivisionID.Style = Style32
        Me.tdbcDivisionID.TabIndex = 0
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'txtDefaultPeriod
        '
        Me.txtDefaultPeriod.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDefaultPeriod.Location = New System.Drawing.Point(129, 48)
        Me.txtDefaultPeriod.Name = "txtDefaultPeriod"
        Me.txtDefaultPeriod.ReadOnly = True
        Me.txtDefaultPeriod.Size = New System.Drawing.Size(128, 22)
        Me.txtDefaultPeriod.TabIndex = 2
        '
        'lblDefaultPeriod
        '
        Me.lblDefaultPeriod.AutoSize = True
        Me.lblDefaultPeriod.Location = New System.Drawing.Point(12, 52)
        Me.lblDefaultPeriod.Name = "lblDefaultPeriod"
        Me.lblDefaultPeriod.Size = New System.Drawing.Size(105, 13)
        Me.lblDefaultPeriod.TabIndex = 8
        Me.lblDefaultPeriod.Text = "Kỳ kế toán mặc định"
        Me.lblDefaultPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPeriodNumber
        '
        Me.txtPeriodNumber.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPeriodNumber.Location = New System.Drawing.Point(384, 47)
        Me.txtPeriodNumber.Name = "txtPeriodNumber"
        Me.txtPeriodNumber.ReadOnly = True
        Me.txtPeriodNumber.Size = New System.Drawing.Size(128, 22)
        Me.txtPeriodNumber.TabIndex = 3
        Me.txtPeriodNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNumberPeriod
        '
        Me.lblNumberPeriod.AutoSize = True
        Me.lblNumberPeriod.Location = New System.Drawing.Point(285, 52)
        Me.lblNumberPeriod.Name = "lblNumberPeriod"
        Me.lblNumberPeriod.Size = New System.Drawing.Size(73, 13)
        Me.lblNumberPeriod.TabIndex = 10
        Me.lblNumberPeriod.Text = "Số kỳ kế toán"
        Me.lblNumberPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(259, 19)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(253, 22)
        Me.txtDivisionName.TabIndex = 1
        Me.txtDivisionName.TabStop = False
        '
        'lblIntPlaceDefault
        '
        Me.lblIntPlaceDefault.AutoSize = True
        Me.lblIntPlaceDefault.Location = New System.Drawing.Point(13, 136)
        Me.lblIntPlaceDefault.Name = "lblIntPlaceDefault"
        Me.lblIntPlaceDefault.Size = New System.Drawing.Size(77, 13)
        Me.lblIntPlaceDefault.TabIndex = 6
        Me.lblIntPlaceDefault.Text = "Nơi phỏng vấn"
        Me.lblIntPlaceDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInterviewerDefault
        '
        Me.lblInterviewerDefault.AutoSize = True
        Me.lblInterviewerDefault.Location = New System.Drawing.Point(13, 105)
        Me.lblInterviewerDefault.Name = "lblInterviewerDefault"
        Me.lblInterviewerDefault.Size = New System.Drawing.Size(89, 13)
        Me.lblInterviewerDefault.TabIndex = 3
        Me.lblInterviewerDefault.Text = "Người phỏng vấn"
        Me.lblInterviewerDefault.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecSourceName
        '
        Me.txtRecSourceName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtRecSourceName.Location = New System.Drawing.Point(259, 100)
        Me.txtRecSourceName.Name = "txtRecSourceName"
        Me.txtRecSourceName.ReadOnly = True
        Me.txtRecSourceName.Size = New System.Drawing.Size(253, 22)
        Me.txtRecSourceName.TabIndex = 5
        Me.txtRecSourceName.TabStop = False
        '
        'tagPageAuto
        '
        Me.tagPageAuto.Controls.Add(Me.chkAutoInterviewFileID)
        Me.tagPageAuto.Controls.Add(Me.chkAutoRecInformationID)
        Me.tagPageAuto.Controls.Add(Me.chkSeparator)
        Me.tagPageAuto.Controls.Add(Me.lblCandidateOutputLength)
        Me.tagPageAuto.Controls.Add(Me.c1NumCandudateOutputLength)
        Me.tagPageAuto.Controls.Add(Me.cboCandidateOutputOrder)
        Me.tagPageAuto.Controls.Add(Me.cboCandidateSeparator)
        Me.tagPageAuto.Controls.Add(Me.chkCandidateS5Type)
        Me.tagPageAuto.Controls.Add(Me.chkCandidateS4Type)
        Me.tagPageAuto.Controls.Add(Me.chkSupply)
        Me.tagPageAuto.Controls.Add(Me.chkAuto)
        Me.tagPageAuto.Controls.Add(Me.chkCandidateS3Type)
        Me.tagPageAuto.Controls.Add(Me.chkCandidateS2Type)
        Me.tagPageAuto.Controls.Add(Me.chkCandidateS1Type)
        Me.tagPageAuto.Controls.Add(Me.chkAutoCandidateID)
        Me.tagPageAuto.Controls.Add(Me.lblCandidateOutputOrder)
        Me.tagPageAuto.Location = New System.Drawing.Point(4, 22)
        Me.tagPageAuto.Name = "tagPageAuto"
        Me.tagPageAuto.Padding = New System.Windows.Forms.Padding(3)
        Me.tagPageAuto.Size = New System.Drawing.Size(532, 226)
        Me.tagPageAuto.TabIndex = 1
        Me.tagPageAuto.Text = "2. Thiết lập mã tự động"
        Me.tagPageAuto.UseVisualStyleBackColor = True
        '
        'chkAutoInterviewFileID
        '
        Me.chkAutoInterviewFileID.AutoSize = True
        Me.chkAutoInterviewFileID.Location = New System.Drawing.Point(21, 57)
        Me.chkAutoInterviewFileID.Name = "chkAutoInterviewFileID"
        Me.chkAutoInterviewFileID.Size = New System.Drawing.Size(114, 17)
        Me.chkAutoInterviewFileID.TabIndex = 16
        Me.chkAutoInterviewFileID.Text = "Mã lịch phỏng vấn"
        Me.chkAutoInterviewFileID.UseVisualStyleBackColor = True
        Me.chkAutoInterviewFileID.Visible = False
        '
        'chkAutoRecInformationID
        '
        Me.chkAutoRecInformationID.AutoSize = True
        Me.chkAutoRecInformationID.Location = New System.Drawing.Point(21, 34)
        Me.chkAutoRecInformationID.Name = "chkAutoRecInformationID"
        Me.chkAutoRecInformationID.Size = New System.Drawing.Size(151, 17)
        Me.chkAutoRecInformationID.TabIndex = 15
        Me.chkAutoRecInformationID.Text = "Mã thông báo tuyển dụng "
        Me.chkAutoRecInformationID.UseVisualStyleBackColor = True
        Me.chkAutoRecInformationID.Visible = False
        '
        'chkSeparator
        '
        Me.chkSeparator.AutoSize = True
        Me.chkSeparator.Location = New System.Drawing.Point(311, 78)
        Me.chkSeparator.Name = "chkSeparator"
        Me.chkSeparator.Size = New System.Drawing.Size(100, 17)
        Me.chkSeparator.TabIndex = 14
        Me.chkSeparator.Text = "Dấu phân cách"
        Me.chkSeparator.UseVisualStyleBackColor = True
        Me.chkSeparator.Visible = False
        '
        'lblCandidateOutputLength
        '
        Me.lblCandidateOutputLength.AutoSize = True
        Me.lblCandidateOutputLength.Location = New System.Drawing.Point(308, 129)
        Me.lblCandidateOutputLength.Name = "lblCandidateOutputLength"
        Me.lblCandidateOutputLength.Size = New System.Drawing.Size(55, 13)
        Me.lblCandidateOutputLength.TabIndex = 9
        Me.lblCandidateOutputLength.Text = "Độ dài mã"
        Me.lblCandidateOutputLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCandidateOutputLength.Visible = False
        '
        'c1NumCandudateOutputLength
        '
        Me.c1NumCandudateOutputLength.Enabled = False
        Me.c1NumCandudateOutputLength.Location = New System.Drawing.Point(420, 125)
        Me.c1NumCandudateOutputLength.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.c1NumCandudateOutputLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.c1NumCandudateOutputLength.Name = "c1NumCandudateOutputLength"
        Me.c1NumCandudateOutputLength.Size = New System.Drawing.Size(95, 20)
        Me.c1NumCandudateOutputLength.TabIndex = 10
        Me.c1NumCandudateOutputLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.c1NumCandudateOutputLength.Value = New Decimal(New Integer() {5, 0, 0, 0})
        Me.c1NumCandudateOutputLength.Visible = False
        '
        'cboCandidateOutputOrder
        '
        Me.cboCandidateOutputOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCandidateOutputOrder.Enabled = False
        Me.cboCandidateOutputOrder.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboCandidateOutputOrder.FormattingEnabled = True
        Me.cboCandidateOutputOrder.Items.AddRange(New Object() {"SSSN", "SSNS", "SNSS", "NSSS"})
        Me.cboCandidateOutputOrder.Location = New System.Drawing.Point(420, 99)
        Me.cboCandidateOutputOrder.Name = "cboCandidateOutputOrder"
        Me.cboCandidateOutputOrder.Size = New System.Drawing.Size(95, 22)
        Me.cboCandidateOutputOrder.TabIndex = 7
        Me.cboCandidateOutputOrder.Visible = False
        '
        'cboCandidateSeparator
        '
        Me.cboCandidateSeparator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCandidateSeparator.Enabled = False
        Me.cboCandidateSeparator.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboCandidateSeparator.FormattingEnabled = True
        Me.cboCandidateSeparator.Items.AddRange(New Object() {"-", "+", "*", "/", ".", ",", ";"})
        Me.cboCandidateSeparator.Location = New System.Drawing.Point(420, 75)
        Me.cboCandidateSeparator.Name = "cboCandidateSeparator"
        Me.cboCandidateSeparator.Size = New System.Drawing.Size(95, 22)
        Me.cboCandidateSeparator.TabIndex = 4
        Me.cboCandidateSeparator.Visible = False
        '
        'chkCandidateS5Type
        '
        Me.chkCandidateS5Type.AutoSize = True
        Me.chkCandidateS5Type.Enabled = False
        Me.chkCandidateS5Type.Location = New System.Drawing.Point(137, 203)
        Me.chkCandidateS5Type.Name = "chkCandidateS5Type"
        Me.chkCandidateS5Type.Size = New System.Drawing.Size(112, 17)
        Me.chkCandidateS5Type.TabIndex = 13
        Me.chkCandidateS5Type.Text = "Sau phần tự động"
        Me.chkCandidateS5Type.UseVisualStyleBackColor = True
        Me.chkCandidateS5Type.Visible = False
        '
        'chkCandidateS4Type
        '
        Me.chkCandidateS4Type.AutoSize = True
        Me.chkCandidateS4Type.Enabled = False
        Me.chkCandidateS4Type.Location = New System.Drawing.Point(137, 178)
        Me.chkCandidateS4Type.Name = "chkCandidateS4Type"
        Me.chkCandidateS4Type.Size = New System.Drawing.Size(121, 17)
        Me.chkCandidateS4Type.TabIndex = 12
        Me.chkCandidateS4Type.Text = "Trước phần tự động"
        Me.chkCandidateS4Type.UseVisualStyleBackColor = True
        Me.chkCandidateS4Type.Visible = False
        '
        'chkSupply
        '
        Me.chkSupply.AutoSize = True
        Me.chkSupply.Enabled = False
        Me.chkSupply.Location = New System.Drawing.Point(88, 153)
        Me.chkSupply.Name = "chkSupply"
        Me.chkSupply.Size = New System.Drawing.Size(92, 17)
        Me.chkSupply.TabIndex = 11
        Me.chkSupply.Text = "Phần bổ sung"
        Me.chkSupply.UseVisualStyleBackColor = True
        Me.chkSupply.Visible = False
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.Location = New System.Drawing.Point(88, 53)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(91, 17)
        Me.chkAuto.TabIndex = 1
        Me.chkAuto.Text = "Phần tự động"
        Me.chkAuto.UseVisualStyleBackColor = True
        Me.chkAuto.Visible = False
        '
        'chkCandidateS3Type
        '
        Me.chkCandidateS3Type.AutoSize = True
        Me.chkCandidateS3Type.Enabled = False
        Me.chkCandidateS3Type.Location = New System.Drawing.Point(137, 128)
        Me.chkCandidateS3Type.Name = "chkCandidateS3Type"
        Me.chkCandidateS3Type.Size = New System.Drawing.Size(97, 17)
        Me.chkCandidateS3Type.TabIndex = 8
        Me.chkCandidateS3Type.Text = "Phân loại khác"
        Me.chkCandidateS3Type.UseVisualStyleBackColor = True
        Me.chkCandidateS3Type.Visible = False
        '
        'chkCandidateS2Type
        '
        Me.chkCandidateS2Type.AutoSize = True
        Me.chkCandidateS2Type.Enabled = False
        Me.chkCandidateS2Type.Location = New System.Drawing.Point(137, 103)
        Me.chkCandidateS2Type.Name = "chkCandidateS2Type"
        Me.chkCandidateS2Type.Size = New System.Drawing.Size(69, 17)
        Me.chkCandidateS2Type.TabIndex = 5
        Me.chkCandidateS2Type.Text = "Theo tên"
        Me.chkCandidateS2Type.UseVisualStyleBackColor = True
        Me.chkCandidateS2Type.Visible = False
        '
        'chkCandidateS1Type
        '
        Me.chkCandidateS1Type.AutoSize = True
        Me.chkCandidateS1Type.Enabled = False
        Me.chkCandidateS1Type.Location = New System.Drawing.Point(137, 78)
        Me.chkCandidateS1Type.Name = "chkCandidateS1Type"
        Me.chkCandidateS1Type.Size = New System.Drawing.Size(66, 17)
        Me.chkCandidateS1Type.TabIndex = 2
        Me.chkCandidateS1Type.Text = "Theo họ"
        Me.chkCandidateS1Type.UseVisualStyleBackColor = True
        Me.chkCandidateS1Type.Visible = False
        '
        'chkAutoCandidateID
        '
        Me.chkAutoCandidateID.AutoSize = True
        Me.chkAutoCandidateID.Location = New System.Drawing.Point(21, 11)
        Me.chkAutoCandidateID.Name = "chkAutoCandidateID"
        Me.chkAutoCandidateID.Size = New System.Drawing.Size(85, 17)
        Me.chkAutoCandidateID.TabIndex = 0
        Me.chkAutoCandidateID.Text = "Mã ứng viên"
        Me.chkAutoCandidateID.UseVisualStyleBackColor = True
        '
        'lblCandidateOutputOrder
        '
        Me.lblCandidateOutputOrder.AutoSize = True
        Me.lblCandidateOutputOrder.Location = New System.Drawing.Point(308, 104)
        Me.lblCandidateOutputOrder.Name = "lblCandidateOutputOrder"
        Me.lblCandidateOutputOrder.Size = New System.Drawing.Size(70, 13)
        Me.lblCandidateOutputOrder.TabIndex = 6
        Me.lblCandidateOutputOrder.Text = "Dạng hiển thị"
        Me.lblCandidateOutputOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCandidateOutputOrder.Visible = False
        '
        'TabPageOther
        '
        Me.TabPageOther.Controls.Add(Me.optRecruimentActualQTYMode0)
        Me.TabPageOther.Controls.Add(Me.optRecruimentActualQTYMode1)
        Me.TabPageOther.Controls.Add(Me.GroupBox1)
        Me.TabPageOther.Controls.Add(Me.lbl1)
        Me.TabPageOther.Location = New System.Drawing.Point(4, 22)
        Me.TabPageOther.Name = "TabPageOther"
        Me.TabPageOther.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageOther.Size = New System.Drawing.Size(532, 226)
        Me.TabPageOther.TabIndex = 2
        Me.TabPageOther.Text = "3. Khác"
        Me.TabPageOther.UseVisualStyleBackColor = True
        '
        'optRecruimentActualQTYMode0
        '
        Me.optRecruimentActualQTYMode0.AutoSize = True
        Me.optRecruimentActualQTYMode0.Location = New System.Drawing.Point(15, 71)
        Me.optRecruimentActualQTYMode0.Name = "optRecruimentActualQTYMode0"
        Me.optRecruimentActualQTYMode0.Size = New System.Drawing.Size(291, 17)
        Me.optRecruimentActualQTYMode0.TabIndex = 3
        Me.optRecruimentActualQTYMode0.TabStop = True
        Me.optRecruimentActualQTYMode0.Text = "NV đã lập quyết định tuyển dụng có trạng thái nhận tiệc"
        Me.optRecruimentActualQTYMode0.UseVisualStyleBackColor = True
        '
        'optRecruimentActualQTYMode1
        '
        Me.optRecruimentActualQTYMode1.AutoSize = True
        Me.optRecruimentActualQTYMode1.Checked = True
        Me.optRecruimentActualQTYMode1.Location = New System.Drawing.Point(15, 40)
        Me.optRecruimentActualQTYMode1.Name = "optRecruimentActualQTYMode1"
        Me.optRecruimentActualQTYMode1.Size = New System.Drawing.Size(172, 17)
        Me.optRecruimentActualQTYMode1.TabIndex = 2
        Me.optRecruimentActualQTYMode1.TabStop = True
        Me.optRecruimentActualQTYMode1.Text = "NV đã thực hiện tăng lao động"
        Me.optRecruimentActualQTYMode1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(123, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 5)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.ForeColor = System.Drawing.Color.Blue
        Me.lbl1.Location = New System.Drawing.Point(15, 14)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(102, 13)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "Số lượng thực tuyển"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D25F0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(546, 287)
        Me.Controls.Add(Me.tabSystem)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F0001"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp hÖ thçng - D25F0001"
        Me.tabSystem.ResumeLayout(False)
        Me.TabPageMainInfo.ResumeLayout(False)
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcInterviewerDefault, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tagPageAuto.ResumeLayout(False)
        Me.tagPageAuto.PerformLayout()
        CType(Me.c1NumCandudateOutputLength, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageOther.ResumeLayout(False)
        Me.TabPageOther.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tabSystem As System.Windows.Forms.TabControl
    Friend WithEvents TabPageMainInfo As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDefaultPeriod As System.Windows.Forms.TextBox
    Private WithEvents lblDefaultPeriod As System.Windows.Forms.Label
    Private WithEvents txtPeriodNumber As System.Windows.Forms.TextBox
    Private WithEvents lblNumberPeriod As System.Windows.Forms.Label
    Private WithEvents txtDivisionName As System.Windows.Forms.TextBox
    Private WithEvents txtIntPlaceDefault As System.Windows.Forms.TextBox
    Private WithEvents lblIntPlaceDefault As System.Windows.Forms.Label
    Private WithEvents tdbcInterviewerDefault As C1.Win.C1List.C1Combo
    Private WithEvents lblInterviewerDefault As System.Windows.Forms.Label
    Private WithEvents txtRecSourceName As System.Windows.Forms.TextBox
    Friend WithEvents tagPageAuto As System.Windows.Forms.TabPage
    Private WithEvents chkAutoCandidateID As System.Windows.Forms.CheckBox
    Private WithEvents chkSupply As System.Windows.Forms.CheckBox
    Private WithEvents chkAuto As System.Windows.Forms.CheckBox
    Private WithEvents chkCandidateS3Type As System.Windows.Forms.CheckBox
    Private WithEvents chkCandidateS2Type As System.Windows.Forms.CheckBox
    Private WithEvents chkCandidateS1Type As System.Windows.Forms.CheckBox
    Private WithEvents cboCandidateOutputOrder As System.Windows.Forms.ComboBox
    Private WithEvents cboCandidateSeparator As System.Windows.Forms.ComboBox
    Private WithEvents chkCandidateS5Type As System.Windows.Forms.CheckBox
    Private WithEvents chkCandidateS4Type As System.Windows.Forms.CheckBox
    Private WithEvents lblCandidateOutputOrder As System.Windows.Forms.Label
    Private WithEvents lblCandidateOutputLength As System.Windows.Forms.Label
    Friend WithEvents c1NumCandudateOutputLength As System.Windows.Forms.NumericUpDown
    Private WithEvents chkSeparator As System.Windows.Forms.CheckBox
    Private WithEvents lblDefaultDivision As System.Windows.Forms.Label
    Private WithEvents chkAutoRecInformationID As System.Windows.Forms.CheckBox
    Private WithEvents chkAutoInterviewFileID As System.Windows.Forms.CheckBox
    Private WithEvents chkIsUseAppRecruitProposal As System.Windows.Forms.CheckBox
    Friend WithEvents TabPageOther As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents optRecruimentActualQTYMode1 As System.Windows.Forms.RadioButton
    Private WithEvents optRecruimentActualQTYMode0 As System.Windows.Forms.RadioButton
End Class
