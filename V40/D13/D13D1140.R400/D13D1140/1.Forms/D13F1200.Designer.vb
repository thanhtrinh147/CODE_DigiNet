<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1200
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1200))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpDetail = New System.Windows.Forms.GroupBox()
        Me.lblExchangeRateText = New System.Windows.Forms.Label()
        Me.cneExchangeRate = New C1.Win.C1Input.C1NumericEdit()
        Me.tdbcCurrencyID = New C1.Win.C1List.C1Combo()
        Me.c1dateValidDate = New C1.Win.C1Input.C1DateEdit()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblValidDate = New System.Windows.Forms.Label()
        Me.lblCurrencyID = New System.Windows.Forms.Label()
        Me.txtCurrencyName = New System.Windows.Forms.TextBox()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.chkShowDisabled = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Find = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton()
        Me.tsbFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton()
        Me.imgButton = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlB = New System.Windows.Forms.Panel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNotSave = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpMaster = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.c1dateValidDateTo = New C1.Win.C1Input.C1DateEdit()
        Me.c1dateValidDateFrom = New C1.Win.C1Input.C1DateEdit()
        Me.lblValidDateFrom = New System.Windows.Forms.Label()
        Me.lblValidDateTo = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grpDetail.SuspendLayout()
        CType(Me.cneExchangeRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcCurrencyID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateValidDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnlB.SuspendLayout()
        Me.grpMaster.SuspendLayout()
        CType(Me.c1dateValidDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateValidDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(164, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(161, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(164, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(164, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.lblExchangeRateText)
        Me.grpDetail.Controls.Add(Me.cneExchangeRate)
        Me.grpDetail.Controls.Add(Me.tdbcCurrencyID)
        Me.grpDetail.Controls.Add(Me.c1dateValidDate)
        Me.grpDetail.Controls.Add(Me.txtDescription)
        Me.grpDetail.Controls.Add(Me.chkDisabled)
        Me.grpDetail.Controls.Add(Me.lblDescription)
        Me.grpDetail.Controls.Add(Me.lblValidDate)
        Me.grpDetail.Controls.Add(Me.lblCurrencyID)
        Me.grpDetail.Controls.Add(Me.txtCurrencyName)
        Me.grpDetail.Controls.Add(Me.lblExchangeRate)
        Me.grpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetail.Location = New System.Drawing.Point(464, 27)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(545, 132)
        Me.grpDetail.TabIndex = 3
        Me.grpDetail.TabStop = False
        Me.grpDetail.Text = "Chi tiết"
        '
        'lblExchangeRateText
        '
        Me.lblExchangeRateText.AutoSize = True
        Me.lblExchangeRateText.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchangeRateText.Location = New System.Drawing.Point(222, 76)
        Me.lblExchangeRateText.Name = "lblExchangeRateText"
        Me.lblExchangeRateText.Size = New System.Drawing.Size(110, 13)
        Me.lblExchangeRateText.TabIndex = 8
        Me.lblExchangeRateText.Text = "1 USD = 21,000 VND"
        Me.lblExchangeRateText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cneExchangeRate
        '
        Me.cneExchangeRate.AutoSize = False
        Me.cneExchangeRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cneExchangeRate.Location = New System.Drawing.Point(106, 71)
        Me.cneExchangeRate.Name = "cneExchangeRate"
        Me.cneExchangeRate.Size = New System.Drawing.Size(113, 22)
        Me.cneExchangeRate.TabIndex = 7
        Me.cneExchangeRate.Tag = Nothing
        Me.cneExchangeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneExchangeRate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'tdbcCurrencyID
        '
        Me.tdbcCurrencyID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcCurrencyID.AllowColMove = False
        Me.tdbcCurrencyID.AllowSort = False
        Me.tdbcCurrencyID.AlternatingRows = True
        Me.tdbcCurrencyID.AutoCompletion = True
        Me.tdbcCurrencyID.AutoDropDown = True
        Me.tdbcCurrencyID.Caption = ""
        Me.tdbcCurrencyID.CaptionHeight = 17
        Me.tdbcCurrencyID.CaptionStyle = Style1
        Me.tdbcCurrencyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcCurrencyID.ColumnCaptionHeight = 17
        Me.tdbcCurrencyID.ColumnFooterHeight = 17
        Me.tdbcCurrencyID.ColumnWidth = 100
        Me.tdbcCurrencyID.ContentHeight = 17
        Me.tdbcCurrencyID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcCurrencyID.DisplayMember = "CurrencyID"
        Me.tdbcCurrencyID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcCurrencyID.DropDownWidth = 350
        Me.tdbcCurrencyID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcCurrencyID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcCurrencyID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcCurrencyID.EditorHeight = 17
        Me.tdbcCurrencyID.EmptyRows = True
        Me.tdbcCurrencyID.EvenRowStyle = Style2
        Me.tdbcCurrencyID.ExtendRightColumn = True
        Me.tdbcCurrencyID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcCurrencyID.FooterStyle = Style3
        Me.tdbcCurrencyID.HeadingStyle = Style4
        Me.tdbcCurrencyID.HighLightRowStyle = Style5
        Me.tdbcCurrencyID.Images.Add(CType(resources.GetObject("tdbcCurrencyID.Images"), System.Drawing.Image))
        Me.tdbcCurrencyID.ItemHeight = 15
        Me.tdbcCurrencyID.Location = New System.Drawing.Point(106, 41)
        Me.tdbcCurrencyID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcCurrencyID.MaxDropDownItems = CType(8, Short)
        Me.tdbcCurrencyID.MaxLength = 32767
        Me.tdbcCurrencyID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcCurrencyID.Name = "tdbcCurrencyID"
        Me.tdbcCurrencyID.OddRowStyle = Style6
        Me.tdbcCurrencyID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcCurrencyID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcCurrencyID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcCurrencyID.SelectedStyle = Style7
        Me.tdbcCurrencyID.Size = New System.Drawing.Size(113, 23)
        Me.tdbcCurrencyID.Style = Style8
        Me.tdbcCurrencyID.TabIndex = 4
        Me.tdbcCurrencyID.ValueMember = "CurrencyID"
        Me.tdbcCurrencyID.PropBag = resources.GetString("tdbcCurrencyID.PropBag")
        '
        'c1dateValidDate
        '
        Me.c1dateValidDate.AutoSize = False
        Me.c1dateValidDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateValidDate.EmptyAsNull = True
        Me.c1dateValidDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateValidDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateValidDate.Location = New System.Drawing.Point(106, 13)
        Me.c1dateValidDate.Name = "c1dateValidDate"
        Me.c1dateValidDate.Size = New System.Drawing.Size(113, 22)
        Me.c1dateValidDate.TabIndex = 1
        Me.c1dateValidDate.Tag = Nothing
        Me.c1dateValidDate.TrimStart = True
        Me.c1dateValidDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(106, 99)
        Me.txtDescription.MaxLength = 250
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(433, 22)
        Me.txtDescription.TabIndex = 10
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(225, 16)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(15, 104)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription.TabIndex = 9
        Me.lblDescription.Text = "Diễn giải"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidDate
        '
        Me.lblValidDate.AutoSize = True
        Me.lblValidDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblValidDate.Location = New System.Drawing.Point(15, 19)
        Me.lblValidDate.Name = "lblValidDate"
        Me.lblValidDate.Size = New System.Drawing.Size(58, 13)
        Me.lblValidDate.TabIndex = 0
        Me.lblValidDate.Text = "Hiệu lực từ"
        Me.lblValidDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrencyID
        '
        Me.lblCurrencyID.AutoSize = True
        Me.lblCurrencyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrencyID.Location = New System.Drawing.Point(15, 45)
        Me.lblCurrencyID.Name = "lblCurrencyID"
        Me.lblCurrencyID.Size = New System.Drawing.Size(47, 13)
        Me.lblCurrencyID.TabIndex = 3
        Me.lblCurrencyID.Text = "Loại tiền"
        Me.lblCurrencyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCurrencyName
        '
        Me.txtCurrencyName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtCurrencyName.Location = New System.Drawing.Point(225, 41)
        Me.txtCurrencyName.Name = "txtCurrencyName"
        Me.txtCurrencyName.ReadOnly = True
        Me.txtCurrencyName.Size = New System.Drawing.Size(314, 22)
        Me.txtCurrencyName.TabIndex = 5
        Me.txtCurrencyName.TabStop = False
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.AutoSize = True
        Me.lblExchangeRate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExchangeRate.Location = New System.Drawing.Point(15, 76)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(36, 13)
        Me.lblExchangeRate.TabIndex = 6
        Me.lblExchangeRate.Text = "Tỷ giá"
        Me.lblExchangeRate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkShowDisabled
        '
        Me.chkShowDisabled.AutoSize = True
        Me.chkShowDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowDisabled.Location = New System.Drawing.Point(4, 634)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 4
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator_Find, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator3, Me.mnsExportToExcel, Me.ToolStripSeparator_SysInfo, Me.mnsSysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 176)
        '
        'mnsAdd
        '
        Me.mnsAdd.Name = "mnsAdd"
        Me.mnsAdd.Size = New System.Drawing.Size(164, 22)
        Me.mnsAdd.Text = "&Thêm"
        '
        'mnsEdit
        '
        Me.mnsEdit.Name = "mnsEdit"
        Me.mnsEdit.Size = New System.Drawing.Size(164, 22)
        Me.mnsEdit.Text = "&Sửa"
        '
        'mnsDelete
        '
        Me.mnsDelete.Name = "mnsDelete"
        Me.mnsDelete.Size = New System.Drawing.Size(164, 22)
        Me.mnsDelete.Text = "&Xóa"
        '
        'ToolStripSeparator_Find
        '
        Me.ToolStripSeparator_Find.Name = "ToolStripSeparator_Find"
        Me.ToolStripSeparator_Find.Size = New System.Drawing.Size(161, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(164, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(161, 6)
        '
        'tsbDelete
        '
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(30, 22)
        Me.tsbDelete.Text = "&Xóa"
        '
        'tsbEdit
        '
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(30, 22)
        Me.tsbEdit.Text = "&Sửa"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(73, 22)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'tsbFind
        '
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(53, 22)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbAdd
        '
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(38, 22)
        Me.tsbAdd.Text = "&Thêm"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator2, Me.tsbExportToExcel, Me.ToolStripSeparator4, Me.tsbSysInfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(62, 22)
        Me.tsbExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(101, 22)
        Me.tsbSysInfo.Text = "Thông tin &hệ thống"
        '
        'imgButton
        '
        Me.imgButton.ImageStream = CType(resources.GetObject("imgButton.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgButton.TransparentColor = System.Drawing.Color.Transparent
        Me.imgButton.Images.SetKeyName(0, "Save.png")
        Me.imgButton.Images.SetKeyName(1, "SaveNext.png")
        Me.imgButton.Images.SetKeyName(2, "NoSave.png")
        Me.imgButton.Images.SetKeyName(3, "CloseForm.ico")
        '
        'pnlB
        '
        Me.pnlB.Controls.Add(Me.btnNext)
        Me.pnlB.Controls.Add(Me.btnNotSave)
        Me.pnlB.Controls.Add(Me.btnSave)
        Me.pnlB.Location = New System.Drawing.Point(663, 165)
        Me.pnlB.Name = "pnlB"
        Me.pnlB.Size = New System.Drawing.Size(346, 32)
        Me.pnlB.TabIndex = 5
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(108, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(130, 27)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Lưu và Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnNotSave
        '
        Me.btnNotSave.Location = New System.Drawing.Point(244, 3)
        Me.btnNotSave.Name = "btnNotSave"
        Me.btnNotSave.Size = New System.Drawing.Size(100, 27)
        Me.btnNotSave.TabIndex = 2
        Me.btnNotSave.Text = "&Không Lưu"
        Me.btnNotSave.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 0
        Me.btnSave.Location = New System.Drawing.Point(26, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 27)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grpMaster
        '
        Me.grpMaster.Controls.Add(Me.btnFilter)
        Me.grpMaster.Controls.Add(Me.c1dateValidDateTo)
        Me.grpMaster.Controls.Add(Me.c1dateValidDateFrom)
        Me.grpMaster.Controls.Add(Me.lblValidDateFrom)
        Me.grpMaster.Controls.Add(Me.lblValidDateTo)
        Me.grpMaster.Location = New System.Drawing.Point(4, 27)
        Me.grpMaster.Name = "grpMaster"
        Me.grpMaster.Size = New System.Drawing.Size(454, 45)
        Me.grpMaster.TabIndex = 1
        Me.grpMaster.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(372, 14)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Lọc (F5)"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'c1dateValidDateTo
        '
        Me.c1dateValidDateTo.AutoSize = False
        Me.c1dateValidDateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateValidDateTo.EmptyAsNull = True
        Me.c1dateValidDateTo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateValidDateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateValidDateTo.Location = New System.Drawing.Point(196, 14)
        Me.c1dateValidDateTo.Name = "c1dateValidDateTo"
        Me.c1dateValidDateTo.Size = New System.Drawing.Size(100, 22)
        Me.c1dateValidDateTo.TabIndex = 3
        Me.c1dateValidDateTo.Tag = Nothing
        Me.c1dateValidDateTo.TrimStart = True
        Me.c1dateValidDateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'c1dateValidDateFrom
        '
        Me.c1dateValidDateFrom.AutoSize = False
        Me.c1dateValidDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.c1dateValidDateFrom.EmptyAsNull = True
        Me.c1dateValidDateFrom.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateValidDateFrom.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateValidDateFrom.Location = New System.Drawing.Point(65, 13)
        Me.c1dateValidDateFrom.Name = "c1dateValidDateFrom"
        Me.c1dateValidDateFrom.Size = New System.Drawing.Size(100, 22)
        Me.c1dateValidDateFrom.TabIndex = 1
        Me.c1dateValidDateFrom.Tag = Nothing
        Me.c1dateValidDateFrom.TrimStart = True
        Me.c1dateValidDateFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblValidDateFrom
        '
        Me.lblValidDateFrom.AutoSize = True
        Me.lblValidDateFrom.Location = New System.Drawing.Point(6, 18)
        Me.lblValidDateFrom.Name = "lblValidDateFrom"
        Me.lblValidDateFrom.Size = New System.Drawing.Size(46, 13)
        Me.lblValidDateFrom.TabIndex = 0
        Me.lblValidDateFrom.Text = "Hiệu lực"
        Me.lblValidDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblValidDateTo
        '
        Me.lblValidDateTo.AutoSize = True
        Me.lblValidDateTo.Location = New System.Drawing.Point(170, 19)
        Me.lblValidDateTo.Name = "lblValidDateTo"
        Me.lblValidDateTo.Size = New System.Drawing.Size(16, 13)
        Me.lblValidDateTo.TabIndex = 2
        Me.lblValidDateTo.Text = "---"
        Me.lblValidDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(4, 78)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(454, 549)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'D13F1200
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.pnlB)
        Me.Controls.Add(Me.grpMaster)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpDetail)
        Me.Controls.Add(Me.chkShowDisabled)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1200"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc tú giÀ - D13F1200"
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        CType(Me.cneExchangeRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcCurrencyID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateValidDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnlB.ResumeLayout(False)
        Me.grpMaster.ResumeLayout(False)
        Me.grpMaster.PerformLayout()
        CType(Me.c1dateValidDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateValidDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents grpDetail As System.Windows.Forms.GroupBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents chkShowDisabled As System.Windows.Forms.CheckBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Find As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbExportToExcel As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents imgButton As System.Windows.Forms.ImageList
    Private WithEvents pnlB As System.Windows.Forms.Panel
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnNotSave As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents grpMaster As System.Windows.Forms.GroupBox
    Private WithEvents c1dateValidDateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1dateValidDateFrom As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblValidDateFrom As System.Windows.Forms.Label
    Private WithEvents lblValidDateTo As System.Windows.Forms.Label
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents lblExchangeRateText As System.Windows.Forms.Label
    Private WithEvents cneExchangeRate As C1.Win.C1Input.C1NumericEdit
    Private WithEvents tdbcCurrencyID As C1.Win.C1List.C1Combo
    Private WithEvents c1dateValidDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblValidDate As System.Windows.Forms.Label
    Private WithEvents lblCurrencyID As System.Windows.Forms.Label
    Private WithEvents txtCurrencyName As System.Windows.Forms.TextBox
    Private WithEvents lblExchangeRate As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
