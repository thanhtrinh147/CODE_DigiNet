<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2072
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
        Dim mnuFindLink As C1.Win.C1Command.C1CommandLink
        Dim mnuListAllLink As C1.Win.C1Command.C1CommandLink
        Dim mnuPrintLink As C1.Win.C1Command.C1CommandLink
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2072))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.mnuFind = New C1.Win.C1Command.C1Command
        Me.mnuListAll = New C1.Win.C1Command.C1Command
        Me.mnuPrint = New C1.Win.C1Command.C1Command
        Me.lblBlockID = New System.Windows.Forms.Label
        Me.lblDepartmentID = New System.Windows.Forms.Label
        Me.lblTeamID = New System.Windows.Forms.Label
        Me.chkDeductionLabor = New System.Windows.Forms.CheckBox
        Me.chkNonDeductionLabor = New System.Windows.Forms.CheckBox
        Me.btnFilter = New System.Windows.Forms.Button
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnAction = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink
        Me.mnuExportToExcel = New C1.Win.C1Command.C1Command
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.tdbcBlockID = New C1.Win.C1List.C1Combo
        Me.tdbcDepartmentID = New C1.Win.C1List.C1Combo
        Me.tdbcTeamID = New C1.Win.C1List.C1Combo
        Me.btnShowColumns = New System.Windows.Forms.Button
        mnuFindLink = New C1.Win.C1Command.C1CommandLink
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink
        mnuPrintLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcBlockID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        mnuListAllLink.SortOrder = 1
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'mnuPrintLink
        '
        mnuPrintLink.Command = Me.mnuPrint
        mnuPrintLink.Delimiter = True
        mnuPrintLink.SortOrder = 3
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Text = "&In"
        '
        'lblBlockID
        '
        Me.lblBlockID.AutoSize = True
        Me.lblBlockID.Location = New System.Drawing.Point(293, 19)
        Me.lblBlockID.Name = "lblBlockID"
        Me.lblBlockID.Size = New System.Drawing.Size(28, 13)
        Me.lblBlockID.TabIndex = 2
        Me.lblBlockID.Text = "Khối"
        Me.lblBlockID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartmentID
        '
        Me.lblDepartmentID.AutoSize = True
        Me.lblDepartmentID.Location = New System.Drawing.Point(293, 46)
        Me.lblDepartmentID.Name = "lblDepartmentID"
        Me.lblDepartmentID.Size = New System.Drawing.Size(59, 13)
        Me.lblDepartmentID.TabIndex = 3
        Me.lblDepartmentID.Text = "Phòng ban"
        Me.lblDepartmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTeamID
        '
        Me.lblTeamID.AutoSize = True
        Me.lblTeamID.Location = New System.Drawing.Point(665, 17)
        Me.lblTeamID.Name = "lblTeamID"
        Me.lblTeamID.Size = New System.Drawing.Size(49, 13)
        Me.lblTeamID.TabIndex = 6
        Me.lblTeamID.Text = "Tổ nhóm"
        Me.lblTeamID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDeductionLabor
        '
        Me.chkDeductionLabor.AutoSize = True
        Me.chkDeductionLabor.Location = New System.Drawing.Point(9, 16)
        Me.chkDeductionLabor.Name = "chkDeductionLabor"
        Me.chkDeductionLabor.Size = New System.Drawing.Size(191, 17)
        Me.chkDeductionLabor.TabIndex = 0
        Me.chkDeductionLabor.Text = "Lao động thuộc diện khấu trừ thuế"
        Me.chkDeductionLabor.UseVisualStyleBackColor = True
        '
        'chkNonDeductionLabor
        '
        Me.chkNonDeductionLabor.AutoSize = True
        Me.chkNonDeductionLabor.Location = New System.Drawing.Point(9, 45)
        Me.chkNonDeductionLabor.Name = "chkNonDeductionLabor"
        Me.chkNonDeductionLabor.Size = New System.Drawing.Size(224, 17)
        Me.chkNonDeductionLabor.TabIndex = 1
        Me.chkNonDeductionLabor.Text = "Lao động không thuộc diện khấu trừ thuế"
        Me.chkNonDeductionLabor.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(934, 42)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(72, 22)
        Me.btnFilter.TabIndex = 8
        Me.btnFilter.Text = "&Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 75)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RecordSelectors = False
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1000, 543)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 9
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(854, 625)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 10
        Me.btnAction.Text = "&Thực hiện..."
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(936, 625)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Đó&ng"
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuFindLink, mnuListAllLink, Me.C1CommandLink1, mnuPrintLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuExportToExcel
        Me.C1CommandLink1.Delimiter = True
        Me.C1CommandLink1.SortOrder = 2
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Text = "Xuất Excel"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Commands.Add(Me.mnuPrint)
        Me.C1CommandHolder.Commands.Add(Me.mnuExportToExcel)
        Me.C1CommandHolder.Owner = Me
        '
        'tdbcBlockID
        '
        Me.tdbcBlockID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcBlockID.AllowColMove = False
        Me.tdbcBlockID.AllowSort = False
        Me.tdbcBlockID.AlternatingRows = True
        Me.tdbcBlockID.AutoDropDown = True
        Me.tdbcBlockID.Caption = ""
        Me.tdbcBlockID.CaptionHeight = 17
        Me.tdbcBlockID.CaptionStyle = Style17
        Me.tdbcBlockID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcBlockID.ColumnCaptionHeight = 17
        Me.tdbcBlockID.ColumnFooterHeight = 17
        Me.tdbcBlockID.ColumnWidth = 100
        Me.tdbcBlockID.ContentHeight = 17
        Me.tdbcBlockID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcBlockID.DisplayMember = "BlockName"
        Me.tdbcBlockID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcBlockID.DropDownWidth = 350
        Me.tdbcBlockID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcBlockID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcBlockID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcBlockID.EditorHeight = 17
        Me.tdbcBlockID.EmptyRows = True
        Me.tdbcBlockID.EvenRowStyle = Style18
        Me.tdbcBlockID.ExtendRightColumn = True
        Me.tdbcBlockID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcBlockID.FooterStyle = Style19
        Me.tdbcBlockID.HeadingStyle = Style20
        Me.tdbcBlockID.HighLightRowStyle = Style21
        Me.tdbcBlockID.Images.Add(CType(resources.GetObject("tdbcBlockID.Images"), System.Drawing.Image))
        Me.tdbcBlockID.ItemHeight = 15
        Me.tdbcBlockID.Location = New System.Drawing.Point(374, 12)
        Me.tdbcBlockID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcBlockID.MaxDropDownItems = CType(8, Short)
        Me.tdbcBlockID.MaxLength = 32767
        Me.tdbcBlockID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcBlockID.Name = "tdbcBlockID"
        Me.tdbcBlockID.OddRowStyle = Style22
        Me.tdbcBlockID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcBlockID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcBlockID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcBlockID.SelectedStyle = Style23
        Me.tdbcBlockID.Size = New System.Drawing.Size(259, 23)
        Me.tdbcBlockID.Style = Style24
        Me.tdbcBlockID.TabIndex = 4
        Me.tdbcBlockID.ValueMember = "BlockID"
        Me.tdbcBlockID.PropBag = resources.GetString("tdbcBlockID.PropBag")
        '
        'tdbcDepartmentID
        '
        Me.tdbcDepartmentID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDepartmentID.AllowColMove = False
        Me.tdbcDepartmentID.AllowSort = False
        Me.tdbcDepartmentID.AlternatingRows = True
        Me.tdbcDepartmentID.AutoDropDown = True
        Me.tdbcDepartmentID.Caption = ""
        Me.tdbcDepartmentID.CaptionHeight = 17
        Me.tdbcDepartmentID.CaptionStyle = Style9
        Me.tdbcDepartmentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDepartmentID.ColumnCaptionHeight = 17
        Me.tdbcDepartmentID.ColumnFooterHeight = 17
        Me.tdbcDepartmentID.ColumnWidth = 100
        Me.tdbcDepartmentID.ContentHeight = 17
        Me.tdbcDepartmentID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDepartmentID.DisplayMember = "DepartmentName"
        Me.tdbcDepartmentID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDepartmentID.DropDownWidth = 350
        Me.tdbcDepartmentID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDepartmentID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDepartmentID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDepartmentID.EditorHeight = 17
        Me.tdbcDepartmentID.EmptyRows = True
        Me.tdbcDepartmentID.EvenRowStyle = Style10
        Me.tdbcDepartmentID.ExtendRightColumn = True
        Me.tdbcDepartmentID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDepartmentID.FooterStyle = Style11
        Me.tdbcDepartmentID.HeadingStyle = Style12
        Me.tdbcDepartmentID.HighLightRowStyle = Style13
        Me.tdbcDepartmentID.Images.Add(CType(resources.GetObject("tdbcDepartmentID.Images"), System.Drawing.Image))
        Me.tdbcDepartmentID.ItemHeight = 15
        Me.tdbcDepartmentID.Location = New System.Drawing.Point(374, 41)
        Me.tdbcDepartmentID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDepartmentID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDepartmentID.MaxLength = 32767
        Me.tdbcDepartmentID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDepartmentID.Name = "tdbcDepartmentID"
        Me.tdbcDepartmentID.OddRowStyle = Style14
        Me.tdbcDepartmentID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDepartmentID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.SelectedStyle = Style15
        Me.tdbcDepartmentID.Size = New System.Drawing.Size(259, 23)
        Me.tdbcDepartmentID.Style = Style16
        Me.tdbcDepartmentID.TabIndex = 5
        Me.tdbcDepartmentID.ValueMember = "DepartmentID"
        Me.tdbcDepartmentID.PropBag = resources.GetString("tdbcDepartmentID.PropBag")
        '
        'tdbcTeamID
        '
        Me.tdbcTeamID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTeamID.AllowColMove = False
        Me.tdbcTeamID.AllowSort = False
        Me.tdbcTeamID.AlternatingRows = True
        Me.tdbcTeamID.AutoDropDown = True
        Me.tdbcTeamID.Caption = ""
        Me.tdbcTeamID.CaptionHeight = 17
        Me.tdbcTeamID.CaptionStyle = Style1
        Me.tdbcTeamID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTeamID.ColumnCaptionHeight = 17
        Me.tdbcTeamID.ColumnFooterHeight = 17
        Me.tdbcTeamID.ColumnWidth = 100
        Me.tdbcTeamID.ContentHeight = 17
        Me.tdbcTeamID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTeamID.DisplayMember = "TeamName"
        Me.tdbcTeamID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
        Me.tdbcTeamID.DropDownWidth = 350
        Me.tdbcTeamID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTeamID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTeamID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTeamID.EditorHeight = 17
        Me.tdbcTeamID.EmptyRows = True
        Me.tdbcTeamID.EvenRowStyle = Style2
        Me.tdbcTeamID.ExtendRightColumn = True
        Me.tdbcTeamID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTeamID.FooterStyle = Style3
        Me.tdbcTeamID.HeadingStyle = Style4
        Me.tdbcTeamID.HighLightRowStyle = Style5
        Me.tdbcTeamID.Images.Add(CType(resources.GetObject("tdbcTeamID.Images"), System.Drawing.Image))
        Me.tdbcTeamID.ItemHeight = 15
        Me.tdbcTeamID.Location = New System.Drawing.Point(745, 12)
        Me.tdbcTeamID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTeamID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTeamID.MaxLength = 32767
        Me.tdbcTeamID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTeamID.Name = "tdbcTeamID"
        Me.tdbcTeamID.OddRowStyle = Style6
        Me.tdbcTeamID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTeamID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.SelectedStyle = Style7
        Me.tdbcTeamID.Size = New System.Drawing.Size(261, 23)
        Me.tdbcTeamID.Style = Style8
        Me.tdbcTeamID.TabIndex = 7
        Me.tdbcTeamID.ValueMember = "TeamID"
        Me.tdbcTeamID.PropBag = resources.GetString("tdbcTeamID.PropBag")
        '
        'btnShowColumns
        '
        Me.btnShowColumns.Location = New System.Drawing.Point(9, 625)
        Me.btnShowColumns.Name = "btnShowColumns"
        Me.btnShowColumns.Size = New System.Drawing.Size(100, 22)
        Me.btnShowColumns.TabIndex = 17
        Me.btnShowColumns.Text = "Hiển thị (F12)"
        Me.btnShowColumns.UseVisualStyleBackColor = True
        '
        'D13F2072
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnShowColumns)
        Me.Controls.Add(Me.tdbcTeamID)
        Me.Controls.Add(Me.tdbcDepartmentID)
        Me.Controls.Add(Me.tdbcBlockID)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.chkNonDeductionLabor)
        Me.Controls.Add(Me.chkDeductionLabor)
        Me.Controls.Add(Me.lblBlockID)
        Me.Controls.Add(Me.lblDepartmentID)
        Me.Controls.Add(Me.lblTeamID)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2072"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiÕt khai thuÕ thu nhËp cÀ nh¡n - D13F2072"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcBlockID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblBlockID As System.Windows.Forms.Label
    Private WithEvents lblDepartmentID As System.Windows.Forms.Label
    Private WithEvents lblTeamID As System.Windows.Forms.Label
    Private WithEvents chkDeductionLabor As System.Windows.Forms.CheckBox
    Private WithEvents chkNonDeductionLabor As System.Windows.Forms.CheckBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents mnuPrint As C1.Win.C1Command.C1Command
    Private WithEvents btnAction As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcBlockID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcDepartmentID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcTeamID As C1.Win.C1List.C1Combo
    Private WithEvents btnShowColumns As System.Windows.Forms.Button
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuExportToExcel As C1.Win.C1Command.C1Command
End Class
