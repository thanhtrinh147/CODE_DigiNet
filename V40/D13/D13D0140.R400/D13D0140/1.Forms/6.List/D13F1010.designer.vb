<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1010))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator_Find = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.txtTaxObjectName = New System.Windows.Forms.TextBox()
        Me.txtTaxObjectID = New System.Windows.Forms.TextBox()
        Me.lblTaxObjectID = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblTaxObjectName = New System.Windows.Forms.Label()
        Me.grpDetail = New System.Windows.Forms.GroupBox()
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.chkIsDefault = New System.Windows.Forms.CheckBox()
        Me.imgButton = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlB = New System.Windows.Forms.Panel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnNotSave = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetail.SuspendLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlB.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator_Find, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator3, Me.mnsSysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(165, 148)
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
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(164, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'chkShowDisabled
        '
        Me.chkShowDisabled.AutoSize = True
        Me.chkShowDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowDisabled.Location = New System.Drawing.Point(3, 457)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 4
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbEdit, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator9, Me.tsbSysInfo})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
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
        'tsbSysInfo
        '
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(101, 22)
        Me.tsbSysInfo.Text = "Thông tin &hệ thống"
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(323, 22)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtTaxObjectName
        '
        Me.txtTaxObjectName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTaxObjectName.Location = New System.Drawing.Point(78, 47)
        Me.txtTaxObjectName.MaxLength = 250
        Me.txtTaxObjectName.Name = "txtTaxObjectName"
        Me.txtTaxObjectName.Size = New System.Drawing.Size(343, 22)
        Me.txtTaxObjectName.TabIndex = 3
        '
        'txtTaxObjectID
        '
        Me.txtTaxObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxObjectID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTaxObjectID.Location = New System.Drawing.Point(78, 19)
        Me.txtTaxObjectID.MaxLength = 20
        Me.txtTaxObjectID.Name = "txtTaxObjectID"
        Me.txtTaxObjectID.Size = New System.Drawing.Size(144, 22)
        Me.txtTaxObjectID.TabIndex = 0
        '
        'lblTaxObjectID
        '
        Me.lblTaxObjectID.AutoSize = True
        Me.lblTaxObjectID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxObjectID.Location = New System.Drawing.Point(10, 24)
        Me.lblTaxObjectID.Name = "lblTaxObjectID"
        Me.lblTaxObjectID.Size = New System.Drawing.Size(22, 13)
        Me.lblTaxObjectID.TabIndex = 0
        Me.lblTaxObjectID.Text = "Mã"
        Me.lblTaxObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
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
        Me.tdbg.Location = New System.Drawing.Point(3, 32)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(342, 419)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'lblTaxObjectName
        '
        Me.lblTaxObjectName.AutoSize = True
        Me.lblTaxObjectName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaxObjectName.Location = New System.Drawing.Point(10, 52)
        Me.lblTaxObjectName.Name = "lblTaxObjectName"
        Me.lblTaxObjectName.Size = New System.Drawing.Size(48, 13)
        Me.lblTaxObjectName.TabIndex = 3
        Me.lblTaxObjectName.Text = "Diễn giải"
        Me.lblTaxObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpDetail
        '
        Me.grpDetail.Controls.Add(Me.tdbg1)
        Me.grpDetail.Controls.Add(Me.chkIsDefault)
        Me.grpDetail.Controls.Add(Me.chkDisabled)
        Me.grpDetail.Controls.Add(Me.txtTaxObjectName)
        Me.grpDetail.Controls.Add(Me.txtTaxObjectID)
        Me.grpDetail.Controls.Add(Me.lblTaxObjectID)
        Me.grpDetail.Controls.Add(Me.lblTaxObjectName)
        Me.grpDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetail.Location = New System.Drawing.Point(351, 28)
        Me.grpDetail.Name = "grpDetail"
        Me.grpDetail.Size = New System.Drawing.Size(426, 423)
        Me.grpDetail.TabIndex = 2
        Me.grpDetail.TabStop = False
        Me.grpDetail.Text = "Chi tiết"
        '
        'tdbg1
        '
        Me.tdbg1.AllowAddNew = True
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowDelete = True
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowSort = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.CaptionHeight = 17
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(8, 80)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.RowHeight = 15
        Me.tdbg1.Size = New System.Drawing.Size(413, 336)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 4
        Me.tdbg1.Tag = "COLD"
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        '
        'chkIsDefault
        '
        Me.chkIsDefault.AutoSize = True
        Me.chkIsDefault.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsDefault.Location = New System.Drawing.Point(230, 22)
        Me.chkIsDefault.Name = "chkIsDefault"
        Me.chkIsDefault.Size = New System.Drawing.Size(71, 17)
        Me.chkIsDefault.TabIndex = 1
        Me.chkIsDefault.Text = "Mặc định"
        Me.chkIsDefault.UseVisualStyleBackColor = True
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
        Me.pnlB.Location = New System.Drawing.Point(430, 453)
        Me.pnlB.Name = "pnlB"
        Me.pnlB.Size = New System.Drawing.Size(347, 32)
        Me.pnlB.TabIndex = 3
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
        'D13F1010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 486)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.pnlB)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.grpDetail)
        Me.Controls.Add(Me.chkShowDisabled)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1010"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc ¢çi t§íng nèp thuÕ thu nhËp -  D13F1010"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetail.ResumeLayout(False)
        Me.grpDetail.PerformLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Find As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkShowDisabled As System.Windows.Forms.CheckBox
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtTaxObjectName As System.Windows.Forms.TextBox
    Private WithEvents txtTaxObjectID As System.Windows.Forms.TextBox
    Private WithEvents lblTaxObjectID As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents lblTaxObjectName As System.Windows.Forms.Label
    Private WithEvents grpDetail As System.Windows.Forms.GroupBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents imgButton As System.Windows.Forms.ImageList
    Private WithEvents pnlB As System.Windows.Forms.Panel
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnNotSave As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents chkIsDefault As System.Windows.Forms.CheckBox
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
