<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F3020
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
        Dim mnuAddLink As C1.Win.C1Command.C1CommandLink
        Dim mnuViewLink As C1.Win.C1Command.C1CommandLink
        Dim mnuEditLink As C1.Win.C1Command.C1CommandLink
        Dim mnuDeleteLink As C1.Win.C1Command.C1CommandLink
        Dim mnuFindLink As C1.Win.C1Command.C1CommandLink
        Dim mnuListAllLink As C1.Win.C1Command.C1CommandLink
        Dim mnuSysInfoLink As C1.Win.C1Command.C1CommandLink
        Dim mnuPrintLink As C1.Win.C1Command.C1CommandLink
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F3020))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.mnuAdd = New C1.Win.C1Command.C1Command()
        Me.mnuView = New C1.Win.C1Command.C1Command()
        Me.mnuEdit = New C1.Win.C1Command.C1Command()
        Me.mnuDelete = New C1.Win.C1Command.C1Command()
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command()
        Me.mnuPrint = New C1.Win.C1Command.C1Command()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.chkIsDisplayDetail = New System.Windows.Forms.CheckBox()
        Me.txtCandidateName = New System.Windows.Forms.TextBox()
        Me.txtCandidateID = New System.Windows.Forms.TextBox()
        Me.chkIsComplete = New System.Windows.Forms.CheckBox()
        Me.chkIsPedding = New System.Windows.Forms.CheckBox()
        Me.c1dateVoucherDateTo = New C1.Win.C1Input.C1DateEdit()
        Me.c1dateVoucherFromDate = New C1.Win.C1Input.C1DateEdit()
        Me.lblteVoucherFromDate = New System.Windows.Forms.Label()
        Me.lblteVoucherDateTo = New System.Windows.Forms.Label()
        Me.lblCandidateID = New System.Windows.Forms.Label()
        Me.lblCandidateName = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnShowColumns = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAction = New System.Windows.Forms.Button()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuCreate = New C1.Win.C1Command.C1Command()
        Me.mnuPeddingLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuPedding = New C1.Win.C1Command.C1Command()
        Me.mnuCompleteLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuComplete = New C1.Win.C1Command.C1Command()
        Me.mnuHold = New C1.Win.C1Command.C1Command()
        Me.mnuCancel = New C1.Win.C1Command.C1Command()
        Me.mnuUpdateInterviewResult = New C1.Win.C1Command.C1Command()
        Me.mnuCancelInterviewResult = New C1.Win.C1Command.C1Command()
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder()
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo()
        Me.lblDivisionID = New System.Windows.Forms.Label()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuExportToExcel = New C1.Win.C1Command.C1Command()
        mnuAddLink = New C1.Win.C1Command.C1CommandLink()
        mnuViewLink = New C1.Win.C1Command.C1CommandLink()
        mnuEditLink = New C1.Win.C1Command.C1CommandLink()
        mnuDeleteLink = New C1.Win.C1Command.C1CommandLink()
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        mnuSysInfoLink = New C1.Win.C1Command.C1CommandLink()
        mnuPrintLink = New C1.Win.C1Command.C1CommandLink()
        CType(Me.c1dateVoucherDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateVoucherFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuAddLink
        '
        mnuAddLink.Command = Me.mnuAdd
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Text = "&Thêm"
        '
        'mnuViewLink
        '
        mnuViewLink.Command = Me.mnuView
        mnuViewLink.SortOrder = 1
        '
        'mnuView
        '
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Text = "Xe&m"
        '
        'mnuEditLink
        '
        mnuEditLink.Command = Me.mnuEdit
        mnuEditLink.SortOrder = 2
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Text = "&Sửa"
        '
        'mnuDeleteLink
        '
        mnuDeleteLink.Command = Me.mnuDelete
        mnuDeleteLink.SortOrder = 3
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "&Xóa"
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        mnuFindLink.Delimiter = True
        mnuFindLink.SortOrder = 7
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        mnuListAllLink.SortOrder = 8
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'mnuSysInfoLink
        '
        mnuSysInfoLink.Command = Me.mnuSysInfo
        mnuSysInfoLink.Delimiter = True
        mnuSysInfoLink.SortOrder = 10
        '
        'mnuSysInfo
        '
        Me.mnuSysInfo.Name = "mnuSysInfo"
        Me.mnuSysInfo.Text = "Thông tin &hệ thống"
        '
        'mnuPrintLink
        '
        mnuPrintLink.Command = Me.mnuPrint
        mnuPrintLink.Delimiter = True
        mnuPrintLink.SortOrder = 11
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Text = "&In"
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(930, 65)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 9
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'chkIsDisplayDetail
        '
        Me.chkIsDisplayDetail.AutoSize = True
        Me.chkIsDisplayDetail.Location = New System.Drawing.Point(12, 69)
        Me.chkIsDisplayDetail.Name = "chkIsDisplayDetail"
        Me.chkIsDisplayDetail.Size = New System.Drawing.Size(96, 17)
        Me.chkIsDisplayDetail.TabIndex = 10
        Me.chkIsDisplayDetail.Text = "Hiển thị chi tiết"
        Me.chkIsDisplayDetail.UseVisualStyleBackColor = True
        '
        'txtCandidateName
        '
        Me.txtCandidateName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtCandidateName.Location = New System.Drawing.Point(441, 34)
        Me.txtCandidateName.MaxLength = 100
        Me.txtCandidateName.Name = "txtCandidateName"
        Me.txtCandidateName.Size = New System.Drawing.Size(273, 22)
        Me.txtCandidateName.TabIndex = 7
        '
        'txtCandidateID
        '
        Me.txtCandidateID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtCandidateID.Location = New System.Drawing.Point(441, 6)
        Me.txtCandidateID.MaxLength = 20
        Me.txtCandidateID.Name = "txtCandidateID"
        Me.txtCandidateID.Size = New System.Drawing.Size(273, 22)
        Me.txtCandidateID.TabIndex = 6
        '
        'chkIsComplete
        '
        Me.chkIsComplete.AutoSize = True
        Me.chkIsComplete.Location = New System.Drawing.Point(158, 37)
        Me.chkIsComplete.Name = "chkIsComplete"
        Me.chkIsComplete.Size = New System.Drawing.Size(52, 17)
        Me.chkIsComplete.TabIndex = 5
        Me.chkIsComplete.Text = "Đóng"
        Me.chkIsComplete.UseVisualStyleBackColor = True
        '
        'chkIsPedding
        '
        Me.chkIsPedding.AutoSize = True
        Me.chkIsPedding.Checked = True
        Me.chkIsPedding.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsPedding.Location = New System.Drawing.Point(15, 37)
        Me.chkIsPedding.Name = "chkIsPedding"
        Me.chkIsPedding.Size = New System.Drawing.Size(99, 17)
        Me.chkIsPedding.TabIndex = 4
        Me.chkIsPedding.Text = "Đang thực hiện"
        Me.chkIsPedding.UseVisualStyleBackColor = True
        '
        'c1dateVoucherDateTo
        '
        Me.c1dateVoucherDateTo.AutoSize = False
        Me.c1dateVoucherDateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateVoucherDateTo.EmptyAsNull = True
        Me.c1dateVoucherDateTo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateVoucherDateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateVoucherDateTo.Location = New System.Drawing.Point(214, 6)
        Me.c1dateVoucherDateTo.Name = "c1dateVoucherDateTo"
        Me.c1dateVoucherDateTo.Size = New System.Drawing.Size(106, 22)
        Me.c1dateVoucherDateTo.TabIndex = 3
        Me.c1dateVoucherDateTo.Tag = Nothing
        Me.c1dateVoucherDateTo.TrimStart = True
        Me.c1dateVoucherDateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'c1dateVoucherFromDate
        '
        Me.c1dateVoucherFromDate.AutoSize = False
        Me.c1dateVoucherFromDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateVoucherFromDate.EmptyAsNull = True
        Me.c1dateVoucherFromDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateVoucherFromDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateVoucherFromDate.Location = New System.Drawing.Point(89, 6)
        Me.c1dateVoucherFromDate.Name = "c1dateVoucherFromDate"
        Me.c1dateVoucherFromDate.Size = New System.Drawing.Size(106, 22)
        Me.c1dateVoucherFromDate.TabIndex = 1
        Me.c1dateVoucherFromDate.Tag = Nothing
        Me.c1dateVoucherFromDate.TrimStart = True
        Me.c1dateVoucherFromDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteVoucherFromDate
        '
        Me.lblteVoucherFromDate.AutoSize = True
        Me.lblteVoucherFromDate.Location = New System.Drawing.Point(12, 11)
        Me.lblteVoucherFromDate.Name = "lblteVoucherFromDate"
        Me.lblteVoucherFromDate.Size = New System.Drawing.Size(49, 13)
        Me.lblteVoucherFromDate.TabIndex = 0
        Me.lblteVoucherFromDate.Text = "Ngày lập"
        Me.lblteVoucherFromDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteVoucherDateTo
        '
        Me.lblteVoucherDateTo.AutoSize = True
        Me.lblteVoucherDateTo.Location = New System.Drawing.Point(198, 10)
        Me.lblteVoucherDateTo.Name = "lblteVoucherDateTo"
        Me.lblteVoucherDateTo.Size = New System.Drawing.Size(13, 13)
        Me.lblteVoucherDateTo.TabIndex = 2
        Me.lblteVoucherDateTo.Text = "_"
        Me.lblteVoucherDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCandidateID
        '
        Me.lblCandidateID.AutoSize = True
        Me.lblCandidateID.Location = New System.Drawing.Point(343, 11)
        Me.lblCandidateID.Name = "lblCandidateID"
        Me.lblCandidateID.Size = New System.Drawing.Size(66, 13)
        Me.lblCandidateID.TabIndex = 5
        Me.lblCandidateID.Text = "Mã ứng viên"
        Me.lblCandidateID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCandidateName
        '
        Me.lblCandidateName.AutoSize = True
        Me.lblCandidateName.Location = New System.Drawing.Point(343, 39)
        Me.lblCandidateName.Name = "lblCandidateName"
        Me.lblCandidateName.Size = New System.Drawing.Size(70, 13)
        Me.lblCandidateName.TabIndex = 7
        Me.lblCandidateName.Text = "Tên ứng viên"
        Me.lblCandidateName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder1.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder1.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(12, 92)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RecordSelectors = False
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(994, 517)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 11
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnShowColumns
        '
        Me.btnShowColumns.Location = New System.Drawing.Point(12, 621)
        Me.btnShowColumns.Name = "btnShowColumns"
        Me.btnShowColumns.Size = New System.Drawing.Size(100, 22)
        Me.btnShowColumns.TabIndex = 14
        Me.btnShowColumns.Text = "Hiển thị"
        Me.btnShowColumns.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(930, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(848, 621)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 12
        Me.btnAction.Text = "&Thực hiện..."
        Me.btnAction.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuAddLink, mnuViewLink, mnuEditLink, mnuDeleteLink, Me.C1CommandLink2, Me.mnuPeddingLink, Me.mnuCompleteLink, mnuFindLink, mnuListAllLink, Me.C1CommandLink1, mnuSysInfoLink, mnuPrintLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuCreate
        Me.C1CommandLink2.Delimiter = True
        Me.C1CommandLink2.SortOrder = 4
        '
        'mnuCreate
        '
        Me.mnuCreate.Name = "mnuCreate"
        Me.mnuCreate.Text = "Lập lịch phỏng vấn tiếp theo"
        '
        'mnuPeddingLink
        '
        Me.mnuPeddingLink.Command = Me.mnuPedding
        Me.mnuPeddingLink.Delimiter = True
        Me.mnuPeddingLink.SortOrder = 5
        Me.mnuPeddingLink.Text = "Đ&ang thực hiện"
        '
        'mnuPedding
        '
        Me.mnuPedding.Name = "mnuPedding"
        Me.mnuPedding.Text = "Đang thực hiện"
        '
        'mnuCompleteLink
        '
        Me.mnuCompleteLink.Command = Me.mnuComplete
        Me.mnuCompleteLink.SortOrder = 6
        Me.mnuCompleteLink.Text = "Đó&ng"
        '
        'mnuComplete
        '
        Me.mnuComplete.Name = "mnuComplete"
        Me.mnuComplete.Text = "Hoàn tất"
        '
        'mnuHold
        '
        Me.mnuHold.Name = "mnuHold"
        Me.mnuHold.Text = "Treo"
        Me.mnuHold.Visible = False
        '
        'mnuCancel
        '
        Me.mnuCancel.Name = "mnuCancel"
        Me.mnuCancel.Text = "Hủy"
        Me.mnuCancel.Visible = False
        '
        'mnuUpdateInterviewResult
        '
        Me.mnuUpdateInterviewResult.Name = "mnuUpdateInterviewResult"
        Me.mnuUpdateInterviewResult.Text = "Cập nhật kết quả PV"
        '
        'mnuCancelInterviewResult
        '
        Me.mnuCancelInterviewResult.Name = "mnuCancelInterviewResult"
        Me.mnuCancelInterviewResult.Text = "Hủy kết quả PV"
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder1.Commands.Add(Me.mnuAdd)
        Me.C1CommandHolder1.Commands.Add(Me.mnuView)
        Me.C1CommandHolder1.Commands.Add(Me.mnuEdit)
        Me.C1CommandHolder1.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder1.Commands.Add(Me.mnuHold)
        Me.C1CommandHolder1.Commands.Add(Me.mnuPedding)
        Me.C1CommandHolder1.Commands.Add(Me.mnuComplete)
        Me.C1CommandHolder1.Commands.Add(Me.mnuCancel)
        Me.C1CommandHolder1.Commands.Add(Me.mnuUpdateInterviewResult)
        Me.C1CommandHolder1.Commands.Add(Me.mnuCancelInterviewResult)
        Me.C1CommandHolder1.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder1.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder1.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder1.Commands.Add(Me.mnuPrint)
        Me.C1CommandHolder1.Commands.Add(Me.mnuCreate)
        Me.C1CommandHolder1.Commands.Add(Me.mnuExportToExcel)
        Me.C1CommandHolder1.Owner = Me
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
        Me.tdbcDivisionID.CaptionStyle = Style1
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDivisionID.ColumnCaptionHeight = 17
        Me.tdbcDivisionID.ColumnFooterHeight = 17
        Me.tdbcDivisionID.ColumnWidth = 100
        Me.tdbcDivisionID.ContentHeight = 17
        Me.tdbcDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDivisionID.DisplayMember = "DivisionName"
        Me.tdbcDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.RightDown
        Me.tdbcDivisionID.DropDownWidth = 350
        Me.tdbcDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EditorHeight = 17
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.EvenRowStyle = Style2
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.FooterStyle = Style3
        Me.tdbcDivisionID.HeadingStyle = Style4
        Me.tdbcDivisionID.HighLightRowStyle = Style5
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.ItemHeight = 15
        Me.tdbcDivisionID.Location = New System.Drawing.Point(816, 6)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.OddRowStyle = Style6
        Me.tdbcDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.SelectedStyle = Style7
        Me.tdbcDivisionID.Size = New System.Drawing.Size(190, 23)
        Me.tdbcDivisionID.Style = Style8
        Me.tdbcDivisionID.TabIndex = 8
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(731, 11)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(38, 13)
        Me.lblDivisionID.TabIndex = 16
        Me.lblDivisionID.Text = "Đơn vị"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuExportToExcel
        Me.C1CommandLink1.Delimiter = True
        Me.C1CommandLink1.SortOrder = 9
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Text = "Xuất &Excel"
        '
        'D25F3020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbcDivisionID)
        Me.Controls.Add(Me.chkIsComplete)
        Me.Controls.Add(Me.btnShowColumns)
        Me.Controls.Add(Me.chkIsPedding)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.chkIsDisplayDetail)
        Me.Controls.Add(Me.txtCandidateName)
        Me.Controls.Add(Me.txtCandidateID)
        Me.Controls.Add(Me.c1dateVoucherDateTo)
        Me.Controls.Add(Me.c1dateVoucherFromDate)
        Me.Controls.Add(Me.lblteVoucherFromDate)
        Me.Controls.Add(Me.lblteVoucherDateTo)
        Me.Controls.Add(Me.lblCandidateID)
        Me.Controls.Add(Me.lblCandidateName)
        Me.Controls.Add(Me.lblDivisionID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F3020"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn lÜch phàng vÊn - D25F3020"
        CType(Me.c1dateVoucherDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateVoucherFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents chkIsDisplayDetail As System.Windows.Forms.CheckBox
    Private WithEvents txtCandidateName As System.Windows.Forms.TextBox
    Private WithEvents txtCandidateID As System.Windows.Forms.TextBox
    Private WithEvents chkIsComplete As System.Windows.Forms.CheckBox
    Private WithEvents chkIsPedding As System.Windows.Forms.CheckBox
    Private WithEvents c1dateVoucherDateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1dateVoucherFromDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteVoucherFromDate As System.Windows.Forms.Label
    Private WithEvents lblteVoucherDateTo As System.Windows.Forms.Label
    Private WithEvents lblCandidateID As System.Windows.Forms.Label
    Private WithEvents lblCandidateName As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnShowColumns As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnAction As System.Windows.Forms.Button
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    Private WithEvents mnuView As C1.Win.C1Command.C1Command
    Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Friend WithEvents mnuPeddingLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuCompleteLink As C1.Win.C1Command.C1CommandLink
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Private WithEvents mnuPrint As C1.Win.C1Command.C1Command
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Private WithEvents mnuHold As C1.Win.C1Command.C1Command
    Private WithEvents mnuPedding As C1.Win.C1Command.C1Command
    Private WithEvents mnuComplete As C1.Win.C1Command.C1Command
    Private WithEvents mnuCancel As C1.Win.C1Command.C1Command
    Private WithEvents mnuUpdateInterviewResult As C1.Win.C1Command.C1Command
    Private WithEvents mnuCancelInterviewResult As C1.Win.C1Command.C1Command
    Private WithEvents mnuCreate As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuExportToExcel As C1.Win.C1Command.C1Command
End Class
