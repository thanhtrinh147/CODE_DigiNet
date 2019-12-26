<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F4031
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F4031))
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
        Dim Style17 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style18 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style19 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style20 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style21 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style22 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style23 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style24 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.tabMain = New System.Windows.Forms.TabControl
        Me.tabMainInfo = New System.Windows.Forms.TabPage
        Me.grpu = New System.Windows.Forms.GroupBox
        Me.lblCustom = New System.Windows.Forms.Label
        Me.tdbcCustomReportID = New C1.Win.C1List.C1Combo
        Me.txtReportTitle = New System.Windows.Forms.TextBox
        Me.txtCustomReportName = New System.Windows.Forms.TextBox
        Me.txtReportName = New System.Windows.Forms.TextBox
        Me.lblReportTitle = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtReportCategoryName = New System.Windows.Forms.TextBox
        Me.lblReportName = New System.Windows.Forms.Label
        Me.tdbcReportID = New C1.Win.C1List.C1Combo
        Me.lblReportCatelogy = New System.Windows.Forms.Label
        Me.txtReportCode = New System.Windows.Forms.TextBox
        Me.lblReportCode = New System.Windows.Forms.Label
        Me.tabDefineColumn = New System.Windows.Forms.TabPage
        Me.tdbdCode = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.tabMain.SuspendLayout()
        Me.tabMainInfo.SuspendLayout()
        Me.grpu.SuspendLayout()
        CType(Me.tdbcCustomReportID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcReportID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDefineColumn.SuspendLayout()
        CType(Me.tdbdCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabMainInfo)
        Me.tabMain.Controls.Add(Me.tabDefineColumn)
        Me.tabMain.Location = New System.Drawing.Point(6, 6)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(554, 341)
        Me.tabMain.TabIndex = 0
        Me.tabMain.TabStop = False
        '
        'tabMainInfo
        '
        Me.tabMainInfo.Controls.Add(Me.grpu)
        Me.tabMainInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabMainInfo.Name = "tabMainInfo"
        Me.tabMainInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabMainInfo.Size = New System.Drawing.Size(546, 315)
        Me.tabMainInfo.TabIndex = 0
        Me.tabMainInfo.Text = "1. Thông tin chính"
        Me.tabMainInfo.UseVisualStyleBackColor = True
        '
        'grpu
        '
        Me.grpu.Controls.Add(Me.lblCustom)
        Me.grpu.Controls.Add(Me.tdbcCustomReportID)
        Me.grpu.Controls.Add(Me.txtReportTitle)
        Me.grpu.Controls.Add(Me.txtCustomReportName)
        Me.grpu.Controls.Add(Me.txtReportName)
        Me.grpu.Controls.Add(Me.lblReportTitle)
        Me.grpu.Controls.Add(Me.chkDisabled)
        Me.grpu.Controls.Add(Me.txtReportCategoryName)
        Me.grpu.Controls.Add(Me.lblReportName)
        Me.grpu.Controls.Add(Me.tdbcReportID)
        Me.grpu.Controls.Add(Me.lblReportCatelogy)
        Me.grpu.Controls.Add(Me.txtReportCode)
        Me.grpu.Controls.Add(Me.lblReportCode)
        Me.grpu.Location = New System.Drawing.Point(6, 3)
        Me.grpu.Name = "grpu"
        Me.grpu.Size = New System.Drawing.Size(531, 308)
        Me.grpu.TabIndex = 0
        Me.grpu.TabStop = False
        '
        'lblCustom
        '
        Me.lblCustom.AutoSize = True
        Me.lblCustom.Location = New System.Drawing.Point(8, 138)
        Me.lblCustom.Name = "lblCustom"
        Me.lblCustom.Size = New System.Drawing.Size(45, 13)
        Me.lblCustom.TabIndex = 5
        Me.lblCustom.Text = "Đặc thù"
        Me.lblCustom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcCustomReportID
        '
        Me.tdbcCustomReportID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcCustomReportID.AllowColMove = False
        Me.tdbcCustomReportID.AllowSort = False
        Me.tdbcCustomReportID.AlternatingRows = True
        Me.tdbcCustomReportID.AutoCompletion = True
        Me.tdbcCustomReportID.AutoDropDown = True
        Me.tdbcCustomReportID.Caption = ""
        Me.tdbcCustomReportID.CaptionHeight = 17
        Me.tdbcCustomReportID.CaptionStyle = Style1
        Me.tdbcCustomReportID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcCustomReportID.ColumnCaptionHeight = 17
        Me.tdbcCustomReportID.ColumnFooterHeight = 17
        Me.tdbcCustomReportID.ContentHeight = 17
        Me.tdbcCustomReportID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcCustomReportID.DisplayMember = "ReportID"
        Me.tdbcCustomReportID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcCustomReportID.DropDownWidth = 400
        Me.tdbcCustomReportID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcCustomReportID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCustomReportID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcCustomReportID.EditorHeight = 17
        Me.tdbcCustomReportID.EmptyRows = True
        Me.tdbcCustomReportID.EvenRowStyle = Style2
        Me.tdbcCustomReportID.ExtendRightColumn = True
        Me.tdbcCustomReportID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcCustomReportID.FooterStyle = Style3
        Me.tdbcCustomReportID.HeadingStyle = Style4
        Me.tdbcCustomReportID.HighLightRowStyle = Style5
        Me.tdbcCustomReportID.Images.Add(CType(resources.GetObject("tdbcCustomReportID.Images"), System.Drawing.Image))
        Me.tdbcCustomReportID.ItemHeight = 15
        Me.tdbcCustomReportID.Location = New System.Drawing.Point(111, 134)
        Me.tdbcCustomReportID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcCustomReportID.MaxDropDownItems = CType(8, Short)
        Me.tdbcCustomReportID.MaxLength = 32767
        Me.tdbcCustomReportID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcCustomReportID.Name = "tdbcCustomReportID"
        Me.tdbcCustomReportID.OddRowStyle = Style6
        Me.tdbcCustomReportID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcCustomReportID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcCustomReportID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcCustomReportID.SelectedStyle = Style7
        Me.tdbcCustomReportID.Size = New System.Drawing.Size(151, 23)
        Me.tdbcCustomReportID.Style = Style8
        Me.tdbcCustomReportID.TabIndex = 5
        Me.tdbcCustomReportID.ValueMember = "ReportID"
        Me.tdbcCustomReportID.PropBag = resources.GetString("tdbcCustomReportID.PropBag")
        '
        'txtReportTitle
        '
        Me.txtReportTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReportTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtReportTitle.Location = New System.Drawing.Point(111, 75)
        Me.txtReportTitle.MaxLength = 250
        Me.txtReportTitle.Name = "txtReportTitle"
        Me.txtReportTitle.Size = New System.Drawing.Size(414, 22)
        Me.txtReportTitle.TabIndex = 3
        '
        'txtCustomReportName
        '
        Me.txtCustomReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtCustomReportName.Location = New System.Drawing.Point(268, 134)
        Me.txtCustomReportName.Name = "txtCustomReportName"
        Me.txtCustomReportName.ReadOnly = True
        Me.txtCustomReportName.Size = New System.Drawing.Size(257, 22)
        Me.txtCustomReportName.TabIndex = 7
        Me.txtCustomReportName.TabStop = False
        '
        'txtReportName
        '
        Me.txtReportName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtReportName.Location = New System.Drawing.Point(111, 46)
        Me.txtReportName.MaxLength = 50
        Me.txtReportName.Name = "txtReportName"
        Me.txtReportName.Size = New System.Drawing.Size(414, 22)
        Me.txtReportName.TabIndex = 2
        '
        'lblReportTitle
        '
        Me.lblReportTitle.AutoSize = True
        Me.lblReportTitle.Location = New System.Drawing.Point(8, 79)
        Me.lblReportTitle.Name = "lblReportTitle"
        Me.lblReportTitle.Size = New System.Drawing.Size(44, 13)
        Me.lblReportTitle.TabIndex = 5
        Me.lblReportTitle.Text = "Tiêu đề"
        Me.lblReportTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(427, 23)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtReportCategoryName
        '
        Me.txtReportCategoryName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtReportCategoryName.Location = New System.Drawing.Point(268, 104)
        Me.txtReportCategoryName.Name = "txtReportCategoryName"
        Me.txtReportCategoryName.ReadOnly = True
        Me.txtReportCategoryName.Size = New System.Drawing.Size(257, 22)
        Me.txtReportCategoryName.TabIndex = 4
        Me.txtReportCategoryName.TabStop = False
        '
        'lblReportName
        '
        Me.lblReportName.AutoSize = True
        Me.lblReportName.Location = New System.Drawing.Point(8, 50)
        Me.lblReportName.Name = "lblReportName"
        Me.lblReportName.Size = New System.Drawing.Size(26, 13)
        Me.lblReportName.TabIndex = 3
        Me.lblReportName.Text = "Tên"
        Me.lblReportName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcReportID
        '
        Me.tdbcReportID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcReportID.AllowColMove = False
        Me.tdbcReportID.AllowSort = False
        Me.tdbcReportID.AlternatingRows = True
        Me.tdbcReportID.AutoCompletion = True
        Me.tdbcReportID.AutoDropDown = True
        Me.tdbcReportID.AutoSelect = True
        Me.tdbcReportID.Caption = ""
        Me.tdbcReportID.CaptionHeight = 17
        Me.tdbcReportID.CaptionStyle = Style9
        Me.tdbcReportID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcReportID.ColumnCaptionHeight = 17
        Me.tdbcReportID.ColumnFooterHeight = 17
        Me.tdbcReportID.ContentHeight = 17
        Me.tdbcReportID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcReportID.DisplayMember = "ReportID"
        Me.tdbcReportID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcReportID.DropDownWidth = 400
        Me.tdbcReportID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcReportID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcReportID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcReportID.EditorHeight = 17
        Me.tdbcReportID.EmptyRows = True
        Me.tdbcReportID.EvenRowStyle = Style10
        Me.tdbcReportID.ExtendRightColumn = True
        Me.tdbcReportID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcReportID.FooterStyle = Style11
        Me.tdbcReportID.HeadingStyle = Style12
        Me.tdbcReportID.HighLightRowStyle = Style13
        Me.tdbcReportID.Images.Add(CType(resources.GetObject("tdbcReportID.Images"), System.Drawing.Image))
        Me.tdbcReportID.ItemHeight = 15
        Me.tdbcReportID.Location = New System.Drawing.Point(111, 104)
        Me.tdbcReportID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcReportID.MaxDropDownItems = CType(8, Short)
        Me.tdbcReportID.MaxLength = 32767
        Me.tdbcReportID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcReportID.Name = "tdbcReportID"
        Me.tdbcReportID.OddRowStyle = Style14
        Me.tdbcReportID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcReportID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcReportID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcReportID.SelectedStyle = Style15
        Me.tdbcReportID.Size = New System.Drawing.Size(151, 23)
        Me.tdbcReportID.Style = Style16
        Me.tdbcReportID.TabIndex = 4
        Me.tdbcReportID.ValueMember = "ReportID"
        Me.tdbcReportID.PropBag = resources.GetString("tdbcReportID.PropBag")
        '
        'lblReportCatelogy
        '
        Me.lblReportCatelogy.AutoSize = True
        Me.lblReportCatelogy.Location = New System.Drawing.Point(8, 108)
        Me.lblReportCatelogy.Name = "lblReportCatelogy"
        Me.lblReportCatelogy.Size = New System.Drawing.Size(75, 13)
        Me.lblReportCatelogy.TabIndex = 2
        Me.lblReportCatelogy.Text = "Dạng báo cáo"
        Me.lblReportCatelogy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtReportCode
        '
        Me.txtReportCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtReportCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtReportCode.Location = New System.Drawing.Point(111, 17)
        Me.txtReportCode.MaxLength = 20
        Me.txtReportCode.Name = "txtReportCode"
        Me.txtReportCode.Size = New System.Drawing.Size(151, 22)
        Me.txtReportCode.TabIndex = 0
        '
        'lblReportCode
        '
        Me.lblReportCode.AutoSize = True
        Me.lblReportCode.Location = New System.Drawing.Point(8, 21)
        Me.lblReportCode.Name = "lblReportCode"
        Me.lblReportCode.Size = New System.Drawing.Size(22, 13)
        Me.lblReportCode.TabIndex = 0
        Me.lblReportCode.Text = "Mã"
        Me.lblReportCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDefineColumn
        '
        Me.tabDefineColumn.Controls.Add(Me.tdbdCode)
        Me.tabDefineColumn.Controls.Add(Me.tdbg)
        Me.tabDefineColumn.Location = New System.Drawing.Point(4, 22)
        Me.tabDefineColumn.Name = "tabDefineColumn"
        Me.tabDefineColumn.Padding = New System.Windows.Forms.Padding(3)
        Me.tabDefineColumn.Size = New System.Drawing.Size(546, 315)
        Me.tabDefineColumn.TabIndex = 1
        Me.tabDefineColumn.Text = "2. Định nghĩa cột"
        Me.tabDefineColumn.UseVisualStyleBackColor = True
        '
        'tdbdCode
        '
        Me.tdbdCode.AllowColMove = False
        Me.tdbdCode.AllowColSelect = False
        Me.tdbdCode.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdCode.AllowSort = False
        Me.tdbdCode.AlternatingRows = True
        Me.tdbdCode.CaptionHeight = 17
        Me.tdbdCode.CaptionStyle = Style17
        Me.tdbdCode.ColumnCaptionHeight = 17
        Me.tdbdCode.ColumnFooterHeight = 17
        Me.tdbdCode.DisplayMember = "Code"
        Me.tdbdCode.EmptyRows = True
        Me.tdbdCode.EvenRowStyle = Style18
        Me.tdbdCode.ExtendRightColumn = True
        Me.tdbdCode.FetchRowStyles = False
        Me.tdbdCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbdCode.FooterStyle = Style19
        Me.tdbdCode.HeadingStyle = Style20
        Me.tdbdCode.HighLightRowStyle = Style21
        Me.tdbdCode.Images.Add(CType(resources.GetObject("tdbdCode.Images"), System.Drawing.Image))
        Me.tdbdCode.Location = New System.Drawing.Point(44, 92)
        Me.tdbdCode.Name = "tdbdCode"
        Me.tdbdCode.OddRowStyle = Style22
        Me.tdbdCode.RecordSelectorStyle = Style23
        Me.tdbdCode.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdCode.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdCode.RowHeight = 15
        Me.tdbdCode.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdCode.ScrollTips = False
        Me.tdbdCode.Size = New System.Drawing.Size(480, 177)
        Me.tdbdCode.Style = Style24
        Me.tdbdCode.TabIndex = 1
        Me.tdbdCode.TabStop = False
        Me.tdbdCode.ValueMember = "Code"
        Me.tdbdCode.Visible = False
        Me.tdbdCode.PropBag = resources.GetString("tdbdCode.PropBag")
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
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 6)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(534, 303)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(324, 351)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(484, 351)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(404, 351)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'D45F4031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(565, 380)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tabMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F4031"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "˜Ünh nghÚa bÀo cÀo b¶ng l§¥ng s¶n phÈm - D45F4031"
        Me.tabMain.ResumeLayout(False)
        Me.tabMainInfo.ResumeLayout(False)
        Me.grpu.ResumeLayout(False)
        Me.grpu.PerformLayout()
        CType(Me.tdbcCustomReportID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcReportID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDefineColumn.ResumeLayout(False)
        CType(Me.tdbdCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabMainInfo As System.Windows.Forms.TabPage
    Friend WithEvents tabDefineColumn As System.Windows.Forms.TabPage
    Private WithEvents txtReportCode As System.Windows.Forms.TextBox
    Private WithEvents tdbcReportID As C1.Win.C1List.C1Combo
    Private WithEvents txtReportTitle As System.Windows.Forms.TextBox
    Private WithEvents txtReportName As System.Windows.Forms.TextBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents lblReportCode As System.Windows.Forms.Label
    Private WithEvents lblReportName As System.Windows.Forms.Label
    Private WithEvents lblReportTitle As System.Windows.Forms.Label
    Private WithEvents lblReportCatelogy As System.Windows.Forms.Label
    Private WithEvents txtReportCategoryName As System.Windows.Forms.TextBox
    Private WithEvents tdbdCode As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents grpu As System.Windows.Forms.GroupBox
    Private WithEvents tdbcCustomReportID As C1.Win.C1List.C1Combo
    Private WithEvents txtCustomReportName As System.Windows.Forms.TextBox
    Private WithEvents lblCustom As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class