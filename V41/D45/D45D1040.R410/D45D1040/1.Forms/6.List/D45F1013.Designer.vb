<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1013))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
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
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsbInherit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.grpDetail = New System.Windows.Forms.GroupBox()
        Me.txtMachineName = New System.Windows.Forms.TextBox()
        Me.txtMachineID = New System.Windows.Forms.TextBox()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.lblMachineID = New System.Windows.Forms.Label()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.imgButton = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlB = New System.Windows.Forms.Panel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNotSave = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.grpDetail.SuspendLayout()
        Me.pnlB.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator4, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator3, Me.mnsExportToExcel, Me.ToolStripSeparator5, Me.mnsSysInfo, Me.ToolStripSeparator_SysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 182)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(161, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(164, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(164, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(161, 6)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(164, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(161, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(164, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(161, 6)
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
        Me.chkShowDisabled.Location = New System.Drawing.Point(6, 455)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 4
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator9, Me.tsbExportToExcel, Me.ToolStripSeparator6, Me.tsbSysInfo, Me.ToolStripMenuItem1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(625, 25)
        Me.ToolStrip1.TabIndex = 0
        '
        'tsbAdd
        '
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(38, 22)
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
        Me.tsbDelete.Size = New System.Drawing.Size(30, 22)
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
        Me.tsbFind.Size = New System.Drawing.Size(53, 22)
        Me.tsbFind.Text = "Tìm &kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(73, 22)
        Me.tsbListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 25)
        '
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(62, 22)
        Me.tsbExportToExcel.Text = "Xuất &Excel"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(101, 22)
        Me.tsbSysInfo.Text = "Thông tin &hệ thống"
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
        Me.grpDetail.Controls.Add(Me.txtMachineName)
        Me.grpDetail.Controls.Add(Me.txtMachineID)
        Me.grpDetail.Controls.Add(Me.chkDisabled)
        Me.grpDetail.Controls.Add(Me.lblMachineID)
        Me.grpDetail.Controls.Add(Me.lblMachineName)
        Me.grpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetail.Location = New System.Drawing.Point(6, 28)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(613, 80)
        Me.grpDetail.TabIndex = 2
        Me.grpDetail.TabStop = False
        Me.grpDetail.Text = "Chi tiết"
        '
        'txtMachineName
        '
        Me.txtMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtMachineName.Location = New System.Drawing.Point(125, 48)
        Me.txtMachineName.MaxLength = 500
        Me.txtMachineName.Name = "txtMachineName"
        Me.txtMachineName.Size = New System.Drawing.Size(486, 22)
        Me.txtMachineName.TabIndex = 7
        '
        'txtMachineID
        '
        Me.txtMachineID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtMachineID.Location = New System.Drawing.Point(125, 18)
        Me.txtMachineID.MaxLength = 50
        Me.txtMachineID.Name = "txtMachineID"
        Me.txtMachineID.Size = New System.Drawing.Size(202, 22)
        Me.txtMachineID.TabIndex = 5
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(333, 22)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 4
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'lblMachineID
        '
        Me.lblMachineID.AutoSize = True
        Me.lblMachineID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachineID.Location = New System.Drawing.Point(6, 25)
        Me.lblMachineID.Name = "lblMachineID"
        Me.lblMachineID.Size = New System.Drawing.Size(70, 13)
        Me.lblMachineID.TabIndex = 6
        Me.lblMachineID.Text = "Máy sản xuất"
        Me.lblMachineID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMachineName
        '
        Me.lblMachineName.AutoSize = True
        Me.lblMachineName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachineName.Location = New System.Drawing.Point(6, 54)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(91, 13)
        Me.lblMachineName.TabIndex = 8
        Me.lblMachineName.Text = "Tên máy sản xuất"
        Me.lblMachineName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.pnlB.Location = New System.Drawing.Point(275, 110)
        Me.pnlB.Name = "pnlB"
        Me.pnlB.Size = New System.Drawing.Size(347, 32)
        Me.pnlB.TabIndex = 3
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(110, 3)
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
        Me.btnSave.Location = New System.Drawing.Point(28, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 27)
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
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 146)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(613, 306)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 5
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'D45F1013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 476)
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
        Me.Name = "D45F1013"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc MÀy s¶n xuÊt - D45F1013"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
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
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents grpDetail As System.Windows.Forms.GroupBox
    Private WithEvents tsbExportToExcel As System.Windows.Forms.ToolStripButton
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
    Private WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents txtMachineName As System.Windows.Forms.TextBox
    Private WithEvents txtMachineID As System.Windows.Forms.TextBox
    Private WithEvents lblMachineID As System.Windows.Forms.Label
    Private WithEvents lblMachineName As System.Windows.Forms.Label
End Class