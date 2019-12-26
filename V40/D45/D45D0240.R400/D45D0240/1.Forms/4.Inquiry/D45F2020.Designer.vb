<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2020
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
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2020))
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style41 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style42 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style43 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style44 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style45 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style46 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style47 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style48 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.c1dateDateFrom = New C1.Win.C1Input.C1DateEdit()
        Me.lblteDateFrom = New System.Windows.Forms.Label()
        Me.c1dateDateTo = New C1.Win.C1Input.C1DateEdit()
        Me.lblteDateTo = New System.Windows.Forms.Label()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.chkShowCCSP = New System.Windows.Forms.CheckBox()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.tdbcTeamID = New C1.Win.C1List.C1Combo()
        Me.tdbcDepartmentID = New C1.Win.C1List.C1Combo()
        Me.lblTeamID = New System.Windows.Forms.Label()
        Me.lblDepartmentID = New System.Windows.Forms.Label()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCreateVoucherNo = New System.Windows.Forms.Button()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuDelete = New C1.Win.C1Command.C1Command()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnInherit = New System.Windows.Forms.Button()
        Me.tdbg2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        CType(Me.c1dateDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        mnuFindLink.Delimiter = True
        mnuFindLink.SortOrder = 1
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        mnuListAllLink.SortOrder = 2
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'c1dateDateFrom
        '
        Me.c1dateDateFrom.AutoSize = False
        Me.c1dateDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateFrom.EmptyAsNull = True
        Me.c1dateDateFrom.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateDateFrom.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateFrom.Location = New System.Drawing.Point(89, 16)
        Me.c1dateDateFrom.Name = "c1dateDateFrom"
        Me.c1dateDateFrom.Size = New System.Drawing.Size(155, 22)
        Me.c1dateDateFrom.TabIndex = 0
        Me.c1dateDateFrom.Tag = Nothing
        Me.c1dateDateFrom.TrimStart = True
        Me.c1dateDateFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteDateFrom
        '
        Me.lblteDateFrom.AutoSize = True
        Me.lblteDateFrom.Location = New System.Drawing.Point(13, 21)
        Me.lblteDateFrom.Name = "lblteDateFrom"
        Me.lblteDateFrom.Size = New System.Drawing.Size(32, 13)
        Me.lblteDateFrom.TabIndex = 1
        Me.lblteDateFrom.Text = "Ngày"
        Me.lblteDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateDateTo
        '
        Me.c1dateDateTo.AutoSize = False
        Me.c1dateDateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateTo.EmptyAsNull = True
        Me.c1dateDateTo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateDateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateTo.Location = New System.Drawing.Point(317, 16)
        Me.c1dateDateTo.Name = "c1dateDateTo"
        Me.c1dateDateTo.Size = New System.Drawing.Size(155, 22)
        Me.c1dateDateTo.TabIndex = 1
        Me.c1dateDateTo.Tag = Nothing
        Me.c1dateDateTo.TrimStart = True
        Me.c1dateDateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteDateTo
        '
        Me.lblteDateTo.AutoSize = True
        Me.lblteDateTo.Location = New System.Drawing.Point(277, 21)
        Me.lblteDateTo.Name = "lblteDateTo"
        Me.lblteDateTo.Size = New System.Drawing.Size(13, 13)
        Me.lblteDateTo.TabIndex = 3
        Me.lblteDateTo.Text = "--"
        Me.lblteDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtVoucherNo.Location = New System.Drawing.Point(680, 16)
        Me.txtVoucherNo.MaxLength = 20
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(309, 22)
        Me.txtVoucherNo.TabIndex = 2
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(589, 22)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVoucherNo.TabIndex = 5
        Me.lblVoucherNo.Text = "Số phiếu"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkShowCCSP
        '
        Me.chkShowCCSP.AutoSize = True
        Me.chkShowCCSP.Location = New System.Drawing.Point(689, 86)
        Me.chkShowCCSP.Name = "chkShowCCSP"
        Me.chkShowCCSP.Size = New System.Drawing.Size(156, 17)
        Me.chkShowCCSP.TabIndex = 2
        Me.chkShowCCSP.Text = "Hiển thị các phiếu TKSPTL"
        Me.chkShowCCSP.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbcTeamID)
        Me.grp1.Controls.Add(Me.tdbcDepartmentID)
        Me.grp1.Controls.Add(Me.lblTeamID)
        Me.grp1.Controls.Add(Me.lblDepartmentID)
        Me.grp1.Controls.Add(Me.txtVoucherNo)
        Me.grp1.Controls.Add(Me.lblVoucherNo)
        Me.grp1.Controls.Add(Me.lblteDateTo)
        Me.grp1.Controls.Add(Me.c1dateDateTo)
        Me.grp1.Controls.Add(Me.lblteDateFrom)
        Me.grp1.Controls.Add(Me.c1dateDateFrom)
        Me.grp1.Location = New System.Drawing.Point(9, 1)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(1000, 79)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
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
        Me.tdbcTeamID.CaptionStyle = Style33
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
        Me.tdbcTeamID.EvenRowStyle = Style34
        Me.tdbcTeamID.ExtendRightColumn = True
        Me.tdbcTeamID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTeamID.FooterStyle = Style35
        Me.tdbcTeamID.HeadingStyle = Style36
        Me.tdbcTeamID.HighLightRowStyle = Style37
        Me.tdbcTeamID.Images.Add(CType(resources.GetObject("tdbcTeamID.Images"), System.Drawing.Image))
        Me.tdbcTeamID.ItemHeight = 15
        Me.tdbcTeamID.Location = New System.Drawing.Point(317, 47)
        Me.tdbcTeamID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTeamID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTeamID.MaxLength = 32767
        Me.tdbcTeamID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTeamID.Name = "tdbcTeamID"
        Me.tdbcTeamID.OddRowStyle = Style38
        Me.tdbcTeamID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTeamID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.SelectedStyle = Style39
        Me.tdbcTeamID.Size = New System.Drawing.Size(155, 23)
        Me.tdbcTeamID.Style = Style40
        Me.tdbcTeamID.TabIndex = 4
        Me.tdbcTeamID.ValueMember = "TeamID"
        Me.tdbcTeamID.PropBag = resources.GetString("tdbcTeamID.PropBag")
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
        Me.tdbcDepartmentID.CaptionStyle = Style41
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
        Me.tdbcDepartmentID.EvenRowStyle = Style42
        Me.tdbcDepartmentID.ExtendRightColumn = True
        Me.tdbcDepartmentID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDepartmentID.FooterStyle = Style43
        Me.tdbcDepartmentID.HeadingStyle = Style44
        Me.tdbcDepartmentID.HighLightRowStyle = Style45
        Me.tdbcDepartmentID.Images.Add(CType(resources.GetObject("tdbcDepartmentID.Images"), System.Drawing.Image))
        Me.tdbcDepartmentID.ItemHeight = 15
        Me.tdbcDepartmentID.Location = New System.Drawing.Point(89, 47)
        Me.tdbcDepartmentID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDepartmentID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDepartmentID.MaxLength = 32767
        Me.tdbcDepartmentID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDepartmentID.Name = "tdbcDepartmentID"
        Me.tdbcDepartmentID.OddRowStyle = Style46
        Me.tdbcDepartmentID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDepartmentID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.SelectedStyle = Style47
        Me.tdbcDepartmentID.Size = New System.Drawing.Size(155, 23)
        Me.tdbcDepartmentID.Style = Style48
        Me.tdbcDepartmentID.TabIndex = 3
        Me.tdbcDepartmentID.ValueMember = "DepartmentID"
        Me.tdbcDepartmentID.PropBag = resources.GetString("tdbcDepartmentID.PropBag")
        '
        'lblTeamID
        '
        Me.lblTeamID.AutoSize = True
        Me.lblTeamID.Location = New System.Drawing.Point(253, 52)
        Me.lblTeamID.Name = "lblTeamID"
        Me.lblTeamID.Size = New System.Drawing.Size(49, 13)
        Me.lblTeamID.TabIndex = 16
        Me.lblTeamID.Text = "Tổ nhóm"
        Me.lblTeamID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDepartmentID
        '
        Me.lblDepartmentID.AutoSize = True
        Me.lblDepartmentID.Location = New System.Drawing.Point(13, 52)
        Me.lblDepartmentID.Name = "lblDepartmentID"
        Me.lblDepartmentID.Size = New System.Drawing.Size(59, 13)
        Me.lblDepartmentID.TabIndex = 14
        Me.lblDepartmentID.Text = "Phòng ban"
        Me.lblDepartmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(931, 83)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(78, 22)
        Me.btnFilter.TabIndex = 1
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(933, 628)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCreateVoucherNo
        '
        Me.btnCreateVoucherNo.Location = New System.Drawing.Point(9, 628)
        Me.btnCreateVoucherNo.Name = "btnCreateVoucherNo"
        Me.btnCreateVoucherNo.Size = New System.Drawing.Size(143, 22)
        Me.btnCreateVoucherNo.TabIndex = 7
        Me.btnCreateVoucherNo.Text = "&Tạo phiếu chấm công"
        Me.btnCreateVoucherNo.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, mnuFindLink, mnuListAllLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuDelete
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "Xóa"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Owner = Me
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
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
        Me.tdbg.Location = New System.Drawing.Point(9, 109)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RecordSelectors = False
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1000, 513)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 4
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnInherit
        '
        Me.btnInherit.Location = New System.Drawing.Point(9, 83)
        Me.btnInherit.Name = "btnInherit"
        Me.btnInherit.Size = New System.Drawing.Size(100, 22)
        Me.btnInherit.TabIndex = 3
        Me.btnInherit.Text = "&Kế thừa dữ liệu"
        Me.btnInherit.UseVisualStyleBackColor = True
        '
        'tdbg2
        '
        Me.tdbg2.AllowColMove = False
        Me.tdbg2.AllowColSelect = False
        Me.tdbg2.AllowFilter = False
        Me.tdbg2.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg2.AllowUpdate = False
        Me.tdbg2.AlternatingRows = True
        Me.tdbg2.CaptionHeight = 17
        Me.tdbg2.ColumnFooters = True
        Me.tdbg2.EmptyRows = True
        Me.tdbg2.ExtendRightColumn = True
        Me.tdbg2.FilterBar = True
        Me.tdbg2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg2.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg2.Images.Add(CType(resources.GetObject("tdbg2.Images"), System.Drawing.Image))
        Me.tdbg2.Location = New System.Drawing.Point(9, 410)
        Me.tdbg2.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg2.Name = "tdbg2"
        Me.tdbg2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg2.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg2.PrintInfo.PageSettings = CType(resources.GetObject("tdbg2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg2.RowHeight = 15
        Me.tdbg2.Size = New System.Drawing.Size(1000, 212)
        Me.tdbg2.TabAcrossSplits = True
        Me.tdbg2.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg2.TabIndex = 5
        Me.tdbg2.Tag = "COL2"
        Me.tdbg2.PropBag = resources.GetString("tdbg2.PropBag")
        '
        'D45F2020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnInherit)
        Me.Controls.Add(Me.btnCreateVoucherNo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.chkShowCCSP)
        Me.Controls.Add(Me.tdbg2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2020"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PhiÕu TKSPTL ch§a xõ lü"
        CType(Me.c1dateDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents c1dateDateFrom As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteDateFrom As System.Windows.Forms.Label
    Private WithEvents c1dateDateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteDateTo As System.Windows.Forms.Label
    Private WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents chkShowCCSP As System.Windows.Forms.CheckBox
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbg2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnCreateVoucherNo As System.Windows.Forms.Button
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Private WithEvents btnInherit As System.Windows.Forms.Button
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Private WithEvents tdbcTeamID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcDepartmentID As C1.Win.C1List.C1Combo
    Private WithEvents lblTeamID As System.Windows.Forms.Label
    Private WithEvents lblDepartmentID As System.Windows.Forms.Label
End Class
