<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1061
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1061))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.txtTransactionID = New System.Windows.Forms.TextBox
        Me.lblTransactionID = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtTransactionName = New System.Windows.Forms.TextBox
        Me.lblTransactionName = New System.Windows.Forms.Label
        Me.optProposalRecruitment = New System.Windows.Forms.RadioButton
        Me.optPlanningRecruitment = New System.Windows.Forms.RadioButton
        Me.tdbcCreatorID = New C1.Win.C1List.C1Combo
        Me.lblCreatorID = New System.Windows.Forms.Label
        Me.tdbcApproverID = New C1.Win.C1List.C1Combo
        Me.lblApproverID = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo
        Me.lblVoucherTypeID = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.grp1 = New System.Windows.Forms.GroupBox
        CType(Me.tdbcCreatorID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcApproverID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTransactionID
        '
        Me.txtTransactionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransactionID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransactionID.Location = New System.Drawing.Point(95, 14)
        Me.txtTransactionID.MaxLength = 20
        Me.txtTransactionID.Name = "txtTransactionID"
        Me.txtTransactionID.Size = New System.Drawing.Size(147, 22)
        Me.txtTransactionID.TabIndex = 0
        '
        'lblTransactionID
        '
        Me.lblTransactionID.AutoSize = True
        Me.lblTransactionID.Location = New System.Drawing.Point(12, 19)
        Me.lblTransactionID.Name = "lblTransactionID"
        Me.lblTransactionID.Size = New System.Drawing.Size(22, 13)
        Me.lblTransactionID.TabIndex = 1
        Me.lblTransactionID.Text = "Mã"
        Me.lblTransactionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(440, 18)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtTransactionName
        '
        Me.txtTransactionName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransactionName.Location = New System.Drawing.Point(95, 42)
        Me.txtTransactionName.MaxLength = 250
        Me.txtTransactionName.Name = "txtTransactionName"
        Me.txtTransactionName.Size = New System.Drawing.Size(448, 22)
        Me.txtTransactionName.TabIndex = 2
        '
        'lblTransactionName
        '
        Me.lblTransactionName.AutoSize = True
        Me.lblTransactionName.Location = New System.Drawing.Point(12, 46)
        Me.lblTransactionName.Name = "lblTransactionName"
        Me.lblTransactionName.Size = New System.Drawing.Size(26, 13)
        Me.lblTransactionName.TabIndex = 4
        Me.lblTransactionName.Text = "Tên"
        Me.lblTransactionName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'optProposalRecruitment
        '
        Me.optProposalRecruitment.AutoSize = True
        Me.optProposalRecruitment.Location = New System.Drawing.Point(95, 74)
        Me.optProposalRecruitment.Name = "optProposalRecruitment"
        Me.optProposalRecruitment.Size = New System.Drawing.Size(138, 17)
        Me.optProposalRecruitment.TabIndex = 3
        Me.optProposalRecruitment.TabStop = True
        Me.optProposalRecruitment.Text = "Lập đề xuất tuyển dụng"
        Me.optProposalRecruitment.UseVisualStyleBackColor = True
        '
        'optPlanningRecruitment
        '
        Me.optPlanningRecruitment.AutoSize = True
        Me.optPlanningRecruitment.Location = New System.Drawing.Point(396, 74)
        Me.optPlanningRecruitment.Name = "optPlanningRecruitment"
        Me.optPlanningRecruitment.Size = New System.Drawing.Size(147, 17)
        Me.optPlanningRecruitment.TabIndex = 4
        Me.optPlanningRecruitment.TabStop = True
        Me.optPlanningRecruitment.Text = "Lập kế hoạch tuyển dụng"
        Me.optPlanningRecruitment.UseVisualStyleBackColor = True
        '
        'tdbcCreatorID
        '
        Me.tdbcCreatorID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcCreatorID.AllowColMove = False
        Me.tdbcCreatorID.AllowSort = False
        Me.tdbcCreatorID.AlternatingRows = True
        Me.tdbcCreatorID.AutoDropDown = True
        Me.tdbcCreatorID.Caption = ""
        Me.tdbcCreatorID.CaptionHeight = 17
        Me.tdbcCreatorID.CaptionStyle = Style1
        Me.tdbcCreatorID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcCreatorID.ColumnCaptionHeight = 17
        Me.tdbcCreatorID.ColumnFooterHeight = 17
        Me.tdbcCreatorID.ColumnWidth = 100
        Me.tdbcCreatorID.ContentHeight = 17
        Me.tdbcCreatorID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcCreatorID.DisplayMember = "EmployeeName"
        Me.tdbcCreatorID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcCreatorID.DropDownWidth = 300
        Me.tdbcCreatorID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcCreatorID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcCreatorID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcCreatorID.EditorHeight = 17
        Me.tdbcCreatorID.EmptyRows = True
        Me.tdbcCreatorID.EvenRowStyle = Style2
        Me.tdbcCreatorID.ExtendRightColumn = True
        Me.tdbcCreatorID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcCreatorID.FooterStyle = Style3
        Me.tdbcCreatorID.HeadingStyle = Style4
        Me.tdbcCreatorID.HighLightRowStyle = Style5
        Me.tdbcCreatorID.Images.Add(CType(resources.GetObject("tdbcCreatorID.Images"), System.Drawing.Image))
        Me.tdbcCreatorID.ItemHeight = 15
        Me.tdbcCreatorID.Location = New System.Drawing.Point(95, 159)
        Me.tdbcCreatorID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcCreatorID.MaxDropDownItems = CType(8, Short)
        Me.tdbcCreatorID.MaxLength = 20
        Me.tdbcCreatorID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcCreatorID.Name = "tdbcCreatorID"
        Me.tdbcCreatorID.OddRowStyle = Style6
        Me.tdbcCreatorID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcCreatorID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcCreatorID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcCreatorID.SelectedStyle = Style7
        Me.tdbcCreatorID.Size = New System.Drawing.Size(234, 23)
        Me.tdbcCreatorID.Style = Style8
        Me.tdbcCreatorID.TabIndex = 7
        Me.tdbcCreatorID.ValueMember = "EmployeeID"
        Me.tdbcCreatorID.PropBag = resources.GetString("tdbcCreatorID.PropBag")
        '
        'lblCreatorID
        '
        Me.lblCreatorID.AutoSize = True
        Me.lblCreatorID.Location = New System.Drawing.Point(12, 163)
        Me.lblCreatorID.Name = "lblCreatorID"
        Me.lblCreatorID.Size = New System.Drawing.Size(52, 13)
        Me.lblCreatorID.TabIndex = 8
        Me.lblCreatorID.Text = "Người lập"
        Me.lblCreatorID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcApproverID
        '
        Me.tdbcApproverID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcApproverID.AllowColMove = False
        Me.tdbcApproverID.AllowSort = False
        Me.tdbcApproverID.AlternatingRows = True
        Me.tdbcApproverID.AutoDropDown = True
        Me.tdbcApproverID.Caption = ""
        Me.tdbcApproverID.CaptionHeight = 17
        Me.tdbcApproverID.CaptionStyle = Style9
        Me.tdbcApproverID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcApproverID.ColumnCaptionHeight = 17
        Me.tdbcApproverID.ColumnFooterHeight = 17
        Me.tdbcApproverID.ColumnWidth = 100
        Me.tdbcApproverID.ContentHeight = 17
        Me.tdbcApproverID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcApproverID.DisplayMember = "EmployeeName"
        Me.tdbcApproverID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcApproverID.DropDownWidth = 300
        Me.tdbcApproverID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcApproverID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcApproverID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcApproverID.EditorHeight = 17
        Me.tdbcApproverID.EmptyRows = True
        Me.tdbcApproverID.EvenRowStyle = Style10
        Me.tdbcApproverID.ExtendRightColumn = True
        Me.tdbcApproverID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcApproverID.FooterStyle = Style11
        Me.tdbcApproverID.HeadingStyle = Style12
        Me.tdbcApproverID.HighLightRowStyle = Style13
        Me.tdbcApproverID.Images.Add(CType(resources.GetObject("tdbcApproverID.Images"), System.Drawing.Image))
        Me.tdbcApproverID.ItemHeight = 15
        Me.tdbcApproverID.Location = New System.Drawing.Point(95, 188)
        Me.tdbcApproverID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcApproverID.MaxDropDownItems = CType(8, Short)
        Me.tdbcApproverID.MaxLength = 20
        Me.tdbcApproverID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcApproverID.Name = "tdbcApproverID"
        Me.tdbcApproverID.OddRowStyle = Style14
        Me.tdbcApproverID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcApproverID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcApproverID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcApproverID.SelectedStyle = Style15
        Me.tdbcApproverID.Size = New System.Drawing.Size(234, 23)
        Me.tdbcApproverID.Style = Style16
        Me.tdbcApproverID.TabIndex = 8
        Me.tdbcApproverID.ValueMember = "EmployeeID"
        Me.tdbcApproverID.PropBag = resources.GetString("tdbcApproverID.PropBag")
        '
        'lblApproverID
        '
        Me.lblApproverID.AutoSize = True
        Me.lblApproverID.Location = New System.Drawing.Point(12, 192)
        Me.lblApproverID.Name = "lblApproverID"
        Me.lblApproverID.Size = New System.Drawing.Size(64, 13)
        Me.lblApproverID.TabIndex = 11
        Me.lblApproverID.Text = "Người duyệt"
        Me.lblApproverID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(319, 227)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(401, 227)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(483, 228)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbcVoucherTypeID
        '
        Me.tdbcVoucherTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcVoucherTypeID.AllowColMove = False
        Me.tdbcVoucherTypeID.AllowSort = False
        Me.tdbcVoucherTypeID.AlternatingRows = True
        Me.tdbcVoucherTypeID.AutoCompletion = True
        Me.tdbcVoucherTypeID.AutoDropDown = True
        Me.tdbcVoucherTypeID.Caption = ""
        Me.tdbcVoucherTypeID.CaptionHeight = 17
        Me.tdbcVoucherTypeID.CaptionStyle = Style17
        Me.tdbcVoucherTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcVoucherTypeID.ColumnCaptionHeight = 17
        Me.tdbcVoucherTypeID.ColumnFooterHeight = 17
        Me.tdbcVoucherTypeID.ColumnWidth = 100
        Me.tdbcVoucherTypeID.ContentHeight = 17
        Me.tdbcVoucherTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcVoucherTypeID.DisplayMember = "Description"
        Me.tdbcVoucherTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcVoucherTypeID.DropDownWidth = 350
        Me.tdbcVoucherTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcVoucherTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcVoucherTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcVoucherTypeID.EditorHeight = 17
        Me.tdbcVoucherTypeID.EmptyRows = True
        Me.tdbcVoucherTypeID.EvenRowStyle = Style18
        Me.tdbcVoucherTypeID.ExtendRightColumn = True
        Me.tdbcVoucherTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcVoucherTypeID.FooterStyle = Style19
        Me.tdbcVoucherTypeID.HeadingStyle = Style20
        Me.tdbcVoucherTypeID.HighLightRowStyle = Style21
        Me.tdbcVoucherTypeID.Images.Add(CType(resources.GetObject("tdbcVoucherTypeID.Images"), System.Drawing.Image))
        Me.tdbcVoucherTypeID.ItemHeight = 15
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(95, 102)
        Me.tdbcVoucherTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcVoucherTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcVoucherTypeID.MaxLength = 32767
        Me.tdbcVoucherTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcVoucherTypeID.Name = "tdbcVoucherTypeID"
        Me.tdbcVoucherTypeID.OddRowStyle = Style22
        Me.tdbcVoucherTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcVoucherTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.SelectedStyle = Style23
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(234, 23)
        Me.tdbcVoucherTypeID.Style = Style24
        Me.tdbcVoucherTypeID.TabIndex = 5
        Me.tdbcVoucherTypeID.ValueMember = "Code"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = True
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(12, 106)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 17
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(95, 131)
        Me.txtDescription.MaxLength = 250
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(448, 22)
        Me.txtDescription.TabIndex = 6
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(12, 135)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription.TabIndex = 20
        Me.lblDescription.Text = "Diễn giải"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.txtTransactionName)
        Me.grp1.Controls.Add(Me.txtDescription)
        Me.grp1.Controls.Add(Me.lblDescription)
        Me.grp1.Controls.Add(Me.lblVoucherTypeID)
        Me.grp1.Controls.Add(Me.lblApproverID)
        Me.grp1.Controls.Add(Me.tdbcVoucherTypeID)
        Me.grp1.Controls.Add(Me.lblCreatorID)
        Me.grp1.Controls.Add(Me.lblTransactionName)
        Me.grp1.Controls.Add(Me.lblTransactionID)
        Me.grp1.Controls.Add(Me.txtTransactionID)
        Me.grp1.Controls.Add(Me.tdbcApproverID)
        Me.grp1.Controls.Add(Me.chkDisabled)
        Me.grp1.Controls.Add(Me.tdbcCreatorID)
        Me.grp1.Controls.Add(Me.optProposalRecruitment)
        Me.grp1.Controls.Add(Me.optPlanningRecruitment)
        Me.grp1.Location = New System.Drawing.Point(7, 1)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(552, 219)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'D25F1061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(566, 256)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1061"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt loÁi nghiÖp vó - D25F1061"
        CType(Me.tdbcCreatorID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcApproverID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtTransactionID As System.Windows.Forms.TextBox
    Private WithEvents lblTransactionID As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtTransactionName As System.Windows.Forms.TextBox
    Private WithEvents lblTransactionName As System.Windows.Forms.Label
    Private WithEvents optProposalRecruitment As System.Windows.Forms.RadioButton
    Private WithEvents optPlanningRecruitment As System.Windows.Forms.RadioButton
    Private WithEvents tdbcCreatorID As C1.Win.C1List.C1Combo
    Private WithEvents lblCreatorID As System.Windows.Forms.Label
    Private WithEvents tdbcApproverID As C1.Win.C1List.C1Combo
    Private WithEvents lblApproverID As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
End Class
