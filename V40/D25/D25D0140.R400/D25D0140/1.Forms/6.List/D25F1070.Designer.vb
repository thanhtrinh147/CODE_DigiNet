<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1070
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
        Me.components = New System.ComponentModel.Container
        Dim mnuAddLink As C1.Win.C1Command.C1CommandLink
        Dim mnuViewLink As C1.Win.C1Command.C1CommandLink
        Dim mnuEditLink As C1.Win.C1Command.C1CommandLink
        Dim mnuDeleteLink As C1.Win.C1Command.C1CommandLink
        Dim mnuSysInfoLink As C1.Win.C1Command.C1CommandLink
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1070))
        Me.mnuAdd = New C1.Win.C1Command.C1Command
        Me.mnuView = New C1.Win.C1Command.C1Command
        Me.mnuEdit = New C1.Win.C1Command.C1Command
        Me.mnuDelete = New C1.Win.C1Command.C1Command
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.TableToolStrip = New System.Windows.Forms.ToolStrip
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton
        Me.tsbView = New System.Windows.Forms.ToolStripButton
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmView = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmSysInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.chkShowDisabled = New System.Windows.Forms.CheckBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsView = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem
        mnuAddLink = New C1.Win.C1Command.C1CommandLink
        mnuViewLink = New C1.Win.C1Command.C1CommandLink
        mnuEditLink = New C1.Win.C1Command.C1CommandLink
        mnuDeleteLink = New C1.Win.C1Command.C1CommandLink
        mnuSysInfoLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableToolStrip.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
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
        '
        'mnuView
        '
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Text = "Xe&m"
        '
        'mnuEditLink
        '
        mnuEditLink.Command = Me.mnuEdit
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Text = "&Sửa"
        '
        'mnuDeleteLink
        '
        mnuDeleteLink.Command = Me.mnuDelete
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "&Xóa"
        '
        'mnuSysInfoLink
        '
        mnuSysInfoLink.Command = Me.mnuSysInfo
        mnuSysInfoLink.Delimiter = True
        '
        'mnuSysInfo
        '
        Me.mnuSysInfo.Name = "mnuSysInfo"
        Me.mnuSysInfo.Text = "Thông tin &hệ thống"
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
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 28)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(588, 338)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuAddLink, mnuViewLink, mnuEditLink, mnuDeleteLink, mnuSysInfoLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuAdd)
        Me.C1CommandHolder.Commands.Add(Me.mnuView)
        Me.C1CommandHolder.Commands.Add(Me.mnuEdit)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder.Owner = Me
        '
        'TableToolStrip
        '
        Me.TableToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbView, Me.tsbEdit, Me.tsbDelete, Me.ToolStripButton3, Me.tsbSysInfo, Me.ToolStripSeparator2, Me.tsbClose, Me.ToolStripSeparator4, Me.tsdActive})
        Me.TableToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TableToolStrip.Name = "TableToolStrip"
        Me.TableToolStrip.Size = New System.Drawing.Size(594, 25)
        Me.TableToolStrip.TabIndex = 0
        Me.TableToolStrip.Text = "tbrTest"
        '
        'tsbAdd
        '
        Me.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(38, 22)
        Me.tsbAdd.Text = "Thêm"
        '
        'tsbView
        '
        Me.tsbView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbView.Name = "tsbView"
        Me.tsbView.Size = New System.Drawing.Size(32, 22)
        Me.tsbView.Text = "Xem"
        '
        'tsbEdit
        '
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(30, 22)
        Me.tsbEdit.Text = "Sửa"
        '
        'tsbDelete
        '
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(30, 22)
        Me.tsbDelete.Text = "Xóa"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(56, 22)
        Me.tsbSysInfo.Text = "Thông tin"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClose
        '
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(37, 22)
        Me.tsbClose.Text = "Đóng"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAdd, Me.tsmView, Me.tsmEdit, Me.tsmDelete, Me.ToolStripSeparator8, Me.tsmSysInfo})
        Me.tsdActive.Image = CType(resources.GetObject("tsdActive.Image"), System.Drawing.Image)
        Me.tsdActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(68, 22)
        Me.tsdActive.Text = "Thực hiện"
        '
        'tsmAdd
        '
        Me.tsmAdd.Name = "tsmAdd"
        Me.tsmAdd.Size = New System.Drawing.Size(167, 22)
        Me.tsmAdd.Text = "Thêm"
        '
        'tsmView
        '
        Me.tsmView.Name = "tsmView"
        Me.tsmView.Size = New System.Drawing.Size(167, 22)
        Me.tsmView.Text = "Xem"
        '
        'tsmEdit
        '
        Me.tsmEdit.Name = "tsmEdit"
        Me.tsmEdit.Size = New System.Drawing.Size(167, 22)
        Me.tsmEdit.Text = "Sửa"
        '
        'tsmDelete
        '
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.Size = New System.Drawing.Size(167, 22)
        Me.tsmDelete.Text = "Xóa"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(164, 6)
        '
        'tsmSysInfo
        '
        Me.tsmSysInfo.Name = "tsmSysInfo"
        Me.tsmSysInfo.Size = New System.Drawing.Size(167, 22)
        Me.tsmSysInfo.Text = "Thông tin hệ thống"
        '
        'chkShowDisabled
        '
        Me.chkShowDisabled.AutoSize = True
        Me.chkShowDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.chkShowDisabled.Location = New System.Drawing.Point(3, 374)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 3
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsView, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator_SysInfo, Me.mnsSysInfo})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(105, 98)
        '
        'mnsAdd
        '
        Me.mnsAdd.Name = "mnsAdd"
        Me.mnsAdd.Size = New System.Drawing.Size(104, 22)
        Me.mnsAdd.Text = "&Thêm"
        '
        'mnsView
        '
        Me.mnsView.Name = "mnsView"
        Me.mnsView.Size = New System.Drawing.Size(104, 22)
        Me.mnsView.Text = "Xe&m"
        '
        'mnsEdit
        '
        Me.mnsEdit.Name = "mnsEdit"
        Me.mnsEdit.Size = New System.Drawing.Size(104, 22)
        Me.mnsEdit.Text = "&Sửa"
        '
        'mnsDelete
        '
        Me.mnsDelete.Name = "mnsDelete"
        Me.mnsDelete.Size = New System.Drawing.Size(104, 22)
        Me.mnsDelete.Text = "&Xóa"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(101, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(32, 19)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'D25F1070
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 399)
        Me.Controls.Add(Me.chkShowDisabled)
        Me.Controls.Add(Me.TableToolStrip)
        Me.Controls.Add(Me.tdbg)
        Me.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1070"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc ng§éi phàng vÊn - D25F1070"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableToolStrip.ResumeLayout(False)
        Me.TableToolStrip.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    Private WithEvents mnuView As C1.Win.C1Command.C1Command
    Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Friend WithEvents TableToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbView As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSysInfo As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkShowDisabled As System.Windows.Forms.CheckBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsView As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
End Class
