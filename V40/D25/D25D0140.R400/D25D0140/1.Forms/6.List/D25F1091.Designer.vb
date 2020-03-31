<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1091
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
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1091))
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.txtIntGroupID = New System.Windows.Forms.TextBox
        Me.lblIntGroupID = New System.Windows.Forms.Label
        Me.txtIntGroupName = New System.Windows.Forms.TextBox
        Me.lblIntGroupName = New System.Windows.Forms.Label
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.lblDescription = New System.Windows.Forms.Label
        Me.grpMain = New System.Windows.Forms.GroupBox
        Me.tdbdInterviewerID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.lblLine = New System.Windows.Forms.Label
        Me.grpLine = New System.Windows.Forms.GroupBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.grpMain.SuspendLayout()
        CType(Me.tdbdInterviewerID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtIntGroupID
        '
        Me.txtIntGroupID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtIntGroupID.Location = New System.Drawing.Point(72, 19)
        Me.txtIntGroupID.MaxLength = 50
        Me.txtIntGroupID.Name = "txtIntGroupID"
        Me.txtIntGroupID.Size = New System.Drawing.Size(229, 22)
        Me.txtIntGroupID.TabIndex = 1
        '
        'lblIntGroupID
        '
        Me.lblIntGroupID.AutoSize = True
        Me.lblIntGroupID.Location = New System.Drawing.Point(16, 24)
        Me.lblIntGroupID.Name = "lblIntGroupID"
        Me.lblIntGroupID.Size = New System.Drawing.Size(22, 13)
        Me.lblIntGroupID.TabIndex = 0
        Me.lblIntGroupID.Text = "Mã"
        Me.lblIntGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtIntGroupName
        '
        Me.txtIntGroupName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtIntGroupName.Location = New System.Drawing.Point(72, 47)
        Me.txtIntGroupName.MaxLength = 250
        Me.txtIntGroupName.Name = "txtIntGroupName"
        Me.txtIntGroupName.Size = New System.Drawing.Size(701, 22)
        Me.txtIntGroupName.TabIndex = 4
        '
        'lblIntGroupName
        '
        Me.lblIntGroupName.AutoSize = True
        Me.lblIntGroupName.Location = New System.Drawing.Point(16, 52)
        Me.lblIntGroupName.Name = "lblIntGroupName"
        Me.lblIntGroupName.Size = New System.Drawing.Size(26, 13)
        Me.lblIntGroupName.TabIndex = 3
        Me.lblIntGroupName.Text = "Tên"
        Me.lblIntGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(72, 74)
        Me.txtDescription.MaxLength = 500
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(701, 22)
        Me.txtDescription.TabIndex = 6
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(16, 79)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription.TabIndex = 5
        Me.lblDescription.Text = "Diễn giải"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.tdbdInterviewerID)
        Me.grpMain.Controls.Add(Me.lblLine)
        Me.grpMain.Controls.Add(Me.grpLine)
        Me.grpMain.Controls.Add(Me.chkDisabled)
        Me.grpMain.Controls.Add(Me.tdbg)
        Me.grpMain.Controls.Add(Me.txtIntGroupID)
        Me.grpMain.Controls.Add(Me.txtDescription)
        Me.grpMain.Controls.Add(Me.lblIntGroupID)
        Me.grpMain.Controls.Add(Me.txtIntGroupName)
        Me.grpMain.Controls.Add(Me.lblIntGroupName)
        Me.grpMain.Controls.Add(Me.lblDescription)
        Me.grpMain.Location = New System.Drawing.Point(5, -2)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(782, 489)
        Me.grpMain.TabIndex = 0
        Me.grpMain.TabStop = False
        '
        'tdbdInterviewerID
        '
        Me.tdbdInterviewerID.AllowColMove = False
        Me.tdbdInterviewerID.AllowColSelect = False
        Me.tdbdInterviewerID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdInterviewerID.AllowSort = False
        Me.tdbdInterviewerID.AlternatingRows = True
        Me.tdbdInterviewerID.CaptionHeight = 17
        Me.tdbdInterviewerID.CaptionStyle = Style1
        Me.tdbdInterviewerID.ColumnCaptionHeight = 17
        Me.tdbdInterviewerID.ColumnFooterHeight = 17
        Me.tdbdInterviewerID.DisplayMember = "InterviewerID"
        Me.tdbdInterviewerID.EmptyRows = True
        Me.tdbdInterviewerID.EvenRowStyle = Style2
        Me.tdbdInterviewerID.ExtendRightColumn = True
        Me.tdbdInterviewerID.FetchRowStyles = False
        Me.tdbdInterviewerID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdInterviewerID.FooterStyle = Style3
        Me.tdbdInterviewerID.HeadingStyle = Style4
        Me.tdbdInterviewerID.HighLightRowStyle = Style5
        Me.tdbdInterviewerID.Images.Add(CType(resources.GetObject("tdbdInterviewerID.Images"), System.Drawing.Image))
        Me.tdbdInterviewerID.Location = New System.Drawing.Point(92, 218)
        Me.tdbdInterviewerID.Name = "tdbdInterviewerID"
        Me.tdbdInterviewerID.OddRowStyle = Style6
        Me.tdbdInterviewerID.RecordSelectorStyle = Style7
        Me.tdbdInterviewerID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdInterviewerID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdInterviewerID.RowHeight = 15
        Me.tdbdInterviewerID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdInterviewerID.ScrollTips = False
        Me.tdbdInterviewerID.Size = New System.Drawing.Size(350, 147)
        Me.tdbdInterviewerID.Style = Style8
        Me.tdbdInterviewerID.TabIndex = 10
        Me.tdbdInterviewerID.TabStop = False
        Me.tdbdInterviewerID.ValueMember = "InterviewerID"
        Me.tdbdInterviewerID.Visible = False
        Me.tdbdInterviewerID.PropBag = resources.GetString("tdbdInterviewerID.PropBag")
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.Location = New System.Drawing.Point(7, 108)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(167, 13)
        Me.lblLine.TabIndex = 7
        Me.lblLine.Text = "Danh sách người phỏng vấn"
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpLine
        '
        Me.grpLine.Location = New System.Drawing.Point(184, 113)
        Me.grpLine.Name = "grpLine"
        Me.grpLine.Size = New System.Drawing.Size(589, 3)
        Me.grpLine.TabIndex = 8
        Me.grpLine.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(558, 22)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 134)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(774, 348)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 9
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(711, 495)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(553, 495)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(632, 495)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        '
        'D25F1091
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(791, 521)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grpMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1091"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt nhâm phàng vÊn - D25F1091"
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        CType(Me.tdbdInterviewerID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtIntGroupID As System.Windows.Forms.TextBox
    Private WithEvents lblIntGroupID As System.Windows.Forms.Label
    Private WithEvents txtIntGroupName As System.Windows.Forms.TextBox
    Private WithEvents lblIntGroupName As System.Windows.Forms.Label
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents grpMain As System.Windows.Forms.GroupBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Friend WithEvents grpLine As System.Windows.Forms.GroupBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents lblLine As System.Windows.Forms.Label
    Private WithEvents tdbdInterviewerID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class
