<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1180
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1180))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsInherit = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkShowDisabled = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton()
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbFind = New System.Windows.Forms.ToolStripButton()
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbInherit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.grpDetail = New System.Windows.Forms.GroupBox()
        Me.tdbgD = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtSalEmpGroupName = New System.Windows.Forms.TextBox()
        Me.lblSalEmpGroupID = New System.Windows.Forms.Label()
        Me.txtSalEmpGroupID = New System.Windows.Forms.TextBox()
        Me.lblSalEmpGroupName = New System.Windows.Forms.Label()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.imgButton = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlB = New System.Windows.Forms.Panel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNotSave = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnPermission = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlB.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator4, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator3, Me.mnsSysInfo, Me.ToolStripSeparator_SysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(178, 154)
        '
        'mnsAdd
        '
        Me.mnsAdd.Name = "mnsAdd"
        Me.mnsAdd.Size = New System.Drawing.Size(177, 22)
        Me.mnsAdd.Text = "&Thêm"
        '
        'mnsEdit
        '
        Me.mnsEdit.Name = "mnsEdit"
        Me.mnsEdit.Size = New System.Drawing.Size(177, 22)
        Me.mnsEdit.Text = "&Sửa"
        '
        'mnsDelete
        '
        Me.mnsDelete.Name = "mnsDelete"
        Me.mnsDelete.Size = New System.Drawing.Size(177, 22)
        Me.mnsDelete.Text = "&Xóa"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(174, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(177, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(177, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(174, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(177, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(174, 6)
        '
        'mnsInherit
        '
        Me.mnsInherit.Name = "mnsInherit"
        Me.mnsInherit.Size = New System.Drawing.Size(164, 22)
        Me.mnsInherit.Text = "Kế thừ&a"
        '
        'chkShowDisabled
        '
        Me.chkShowDisabled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowDisabled.AutoSize = True
        Me.chkShowDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowDisabled.Location = New System.Drawing.Point(4, 632)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 4
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator9, Me.tsbSysInfo, Me.ToolStripSeparator2, Me.ToolStripMenuItem1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsbAdd
        '
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(42, 22)
        Me.tsbAdd.Text = "&Thêm"
        '
        'tsbEdit
        '
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(30, 22)
        Me.tsbEdit.Text = "&Sửa"
        '
        'tsbDelete
        '
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(31, 22)
        Me.tsbDelete.Text = "&Xóa"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFind
        '
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(61, 22)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(77, 22)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(114, 22)
        Me.tsbSysInfo.Text = "Thông tin &hệ thống"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(12, 25)
        '
        'tsbInherit
        '
        Me.tsbInherit.Name = "tsbInherit"
        Me.tsbInherit.Size = New System.Drawing.Size(48, 22)
        Me.tsbInherit.Text = "Kế thừ&a"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        '
        'grpDetail
        '
        Me.grpDetail.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpDetail.Controls.Add(Me.tdbgD)
        Me.grpDetail.Controls.Add(Me.chkDisabled)
        Me.grpDetail.Controls.Add(Me.txtNote)
        Me.grpDetail.Controls.Add(Me.txtSalEmpGroupName)
        Me.grpDetail.Controls.Add(Me.lblSalEmpGroupID)
        Me.grpDetail.Controls.Add(Me.txtSalEmpGroupID)
        Me.grpDetail.Controls.Add(Me.lblSalEmpGroupName)
        Me.grpDetail.Controls.Add(Me.lblNote)
        Me.grpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetail.Location = New System.Drawing.Point(526, 27)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(487, 591)
        Me.grpDetail.TabIndex = 2
        Me.grpDetail.TabStop = False
        Me.grpDetail.Text = "Chi tiết"
        '
        'tdbgD
        '
        Me.tdbgD.AllowAddNew = True
        Me.tdbgD.AllowColMove = False
        Me.tdbgD.AllowColSelect = False
        Me.tdbgD.AllowDelete = True
        Me.tdbgD.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgD.AllowSort = False
        Me.tdbgD.AlternatingRows = True
        Me.tdbgD.CaptionHeight = 17
        Me.tdbgD.ColumnFooters = True
        Me.tdbgD.EmptyRows = True
        Me.tdbgD.ExtendRightColumn = True
        Me.tdbgD.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgD.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgD.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgD.Images.Add(CType(resources.GetObject("tdbgD.Images"), System.Drawing.Image))
        Me.tdbgD.Location = New System.Drawing.Point(7, 123)
        Me.tdbgD.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgD.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgD.Name = "tdbgD"
        Me.tdbgD.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgD.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgD.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgD.PrintInfo.PageSettings = CType(resources.GetObject("tdbgD.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgD.RowHeight = 15
        Me.tdbgD.Size = New System.Drawing.Size(473, 462)
        Me.tdbgD.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbgD.TabAcrossSplits = True
        Me.tdbgD.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgD.TabIndex = 13
        Me.tdbgD.Tag = "COLD"
        Me.tdbgD.WrapCellPointer = True
        Me.tdbgD.PropBag = resources.GetString("tdbgD.PropBag")
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(379, 21)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 10
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(67, 86)
        Me.txtNote.MaxLength = 250
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(413, 22)
        Me.txtNote.TabIndex = 9
        '
        'txtSalEmpGroupName
        '
        Me.txtSalEmpGroupName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSalEmpGroupName.Location = New System.Drawing.Point(67, 52)
        Me.txtSalEmpGroupName.MaxLength = 250
        Me.txtSalEmpGroupName.Name = "txtSalEmpGroupName"
        Me.txtSalEmpGroupName.Size = New System.Drawing.Size(413, 22)
        Me.txtSalEmpGroupName.TabIndex = 7
        '
        'lblSalEmpGroupID
        '
        Me.lblSalEmpGroupID.AutoSize = True
        Me.lblSalEmpGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalEmpGroupID.Location = New System.Drawing.Point(4, 24)
        Me.lblSalEmpGroupID.Name = "lblSalEmpGroupID"
        Me.lblSalEmpGroupID.Size = New System.Drawing.Size(22, 13)
        Me.lblSalEmpGroupID.TabIndex = 8
        Me.lblSalEmpGroupID.Text = "Mã"
        Me.lblSalEmpGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalEmpGroupID
        '
        Me.txtSalEmpGroupID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSalEmpGroupID.Location = New System.Drawing.Point(67, 19)
        Me.txtSalEmpGroupID.MaxLength = 20
        Me.txtSalEmpGroupID.Name = "txtSalEmpGroupID"
        Me.txtSalEmpGroupID.Size = New System.Drawing.Size(180, 22)
        Me.txtSalEmpGroupID.TabIndex = 6
        '
        'lblSalEmpGroupName
        '
        Me.lblSalEmpGroupName.AutoSize = True
        Me.lblSalEmpGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalEmpGroupName.Location = New System.Drawing.Point(4, 57)
        Me.lblSalEmpGroupName.Name = "lblSalEmpGroupName"
        Me.lblSalEmpGroupName.Size = New System.Drawing.Size(26, 13)
        Me.lblSalEmpGroupName.TabIndex = 11
        Me.lblSalEmpGroupName.Text = "Tên"
        Me.lblSalEmpGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.Location = New System.Drawing.Point(4, 91)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 12
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlB.Controls.Add(Me.btnNext)
        Me.pnlB.Controls.Add(Me.btnNotSave)
        Me.pnlB.Controls.Add(Me.btnSave)
        Me.pnlB.Location = New System.Drawing.Point(526, 623)
        Me.pnlB.Name = "pnlB"
        Me.pnlB.Size = New System.Drawing.Size(492, 28)
        Me.pnlB.TabIndex = 3
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(250, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(130, 22)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Lưu và Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnNotSave
        '
        Me.btnNotSave.Location = New System.Drawing.Point(386, 3)
        Me.btnNotSave.Name = "btnNotSave"
        Me.btnNotSave.Size = New System.Drawing.Size(100, 22)
        Me.btnNotSave.TabIndex = 2
        Me.btnNotSave.Text = "&Không Lưu"
        Me.btnNotSave.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 0
        Me.btnSave.Location = New System.Drawing.Point(168, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
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
        Me.tdbg.Location = New System.Drawing.Point(4, 31)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(516, 580)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 5
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnPermission
        '
        Me.btnPermission.Location = New System.Drawing.Point(208, 629)
        Me.btnPermission.Name = "btnPermission"
        Me.btnPermission.Size = New System.Drawing.Size(135, 22)
        Me.btnPermission.TabIndex = 6
        Me.btnPermission.Text = "&Phân quyền dữ liệu"
        Me.btnPermission.UseVisualStyleBackColor = True
        '
        'D13F1180
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnPermission)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.grpDetail)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.chkShowDisabled)
        Me.Controls.Add(Me.pnlB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1180"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc nhâm l§¥ng - D13F1180"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlB.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents chkShowDisabled As System.Windows.Forms.CheckBox
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents imgButton As System.Windows.Forms.ImageList
    Private WithEvents pnlB As System.Windows.Forms.Panel
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnNotSave As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents mnsInherit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsbInherit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents txtSalEmpGroupName As System.Windows.Forms.TextBox
    Private WithEvents lblSalEmpGroupID As System.Windows.Forms.Label
    Private WithEvents txtSalEmpGroupID As System.Windows.Forms.TextBox
    Private WithEvents lblSalEmpGroupName As System.Windows.Forms.Label
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents btnPermission As System.Windows.Forms.Button
    Private WithEvents tdbgD As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
