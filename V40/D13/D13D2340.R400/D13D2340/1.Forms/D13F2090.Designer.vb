<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2090
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2090))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbcPeriod = New C1.Win.C1List.C1Combo
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.txtStrEmployeeID = New System.Windows.Forms.TextBox
        Me.lblStrEmployeeID = New System.Windows.Forms.Label
        Me.txtStrEmployeeName = New System.Windows.Forms.TextBox
        Me.lblStrEmployeeName = New System.Windows.Forms.Label
        Me.btnFilter = New System.Windows.Forms.Button
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsBackPay = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsViewResult = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsCancelResult = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.chkIsUsed = New System.Windows.Forms.CheckBox
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbFind = New System.Windows.Forms.ToolStripButton
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmBackPay = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmViewResult = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmCancelResult = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.tdbcPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tdbcPeriod
        '
        Me.tdbcPeriod.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriod.AllowColMove = False
        Me.tdbcPeriod.AllowSort = False
        Me.tdbcPeriod.AlternatingRows = True
        Me.tdbcPeriod.AutoCompletion = True
        Me.tdbcPeriod.AutoDropDown = True
        Me.tdbcPeriod.Caption = ""
        Me.tdbcPeriod.CaptionHeight = 17
        Me.tdbcPeriod.CaptionStyle = Style9
        Me.tdbcPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriod.ColumnCaptionHeight = 17
        Me.tdbcPeriod.ColumnFooterHeight = 17
        Me.tdbcPeriod.ColumnHeaders = False
        Me.tdbcPeriod.ColumnWidth = 100
        Me.tdbcPeriod.ContentHeight = 17
        Me.tdbcPeriod.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriod.DisplayMember = "Period"
        Me.tdbcPeriod.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriod.DropDownWidth = 128
        Me.tdbcPeriod.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriod.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPeriod.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriod.EditorHeight = 17
        Me.tdbcPeriod.EmptyRows = True
        Me.tdbcPeriod.EvenRowStyle = Style10
        Me.tdbcPeriod.ExtendRightColumn = True
        Me.tdbcPeriod.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPeriod.FooterStyle = Style11
        Me.tdbcPeriod.HeadingStyle = Style12
        Me.tdbcPeriod.HighLightRowStyle = Style13
        Me.tdbcPeriod.Images.Add(CType(resources.GetObject("tdbcPeriod.Images"), System.Drawing.Image))
        Me.tdbcPeriod.ItemHeight = 15
        Me.tdbcPeriod.Location = New System.Drawing.Point(66, 33)
        Me.tdbcPeriod.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriod.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriod.MaxLength = 32767
        Me.tdbcPeriod.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriod.Name = "tdbcPeriod"
        Me.tdbcPeriod.OddRowStyle = Style14
        Me.tdbcPeriod.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPeriod.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriod.SelectedStyle = Style15
        Me.tdbcPeriod.Size = New System.Drawing.Size(128, 23)
        Me.tdbcPeriod.Style = Style16
        Me.tdbcPeriod.TabIndex = 0
        Me.tdbcPeriod.ValueMember = "Period"
        Me.tdbcPeriod.PropBag = resources.GetString("tdbcPeriod.PropBag")
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(14, 38)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(19, 13)
        Me.lblPeriod.TabIndex = 1
        Me.lblPeriod.Text = "Kỳ"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStrEmployeeID
        '
        Me.txtStrEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtStrEmployeeID.Location = New System.Drawing.Point(322, 34)
        Me.txtStrEmployeeID.Name = "txtStrEmployeeID"
        Me.txtStrEmployeeID.Size = New System.Drawing.Size(128, 22)
        Me.txtStrEmployeeID.TabIndex = 2
        '
        'lblStrEmployeeID
        '
        Me.lblStrEmployeeID.AutoSize = True
        Me.lblStrEmployeeID.Location = New System.Drawing.Point(211, 39)
        Me.lblStrEmployeeID.Name = "lblStrEmployeeID"
        Me.lblStrEmployeeID.Size = New System.Drawing.Size(72, 13)
        Me.lblStrEmployeeID.TabIndex = 3
        Me.lblStrEmployeeID.Text = "Mã nhân viên"
        Me.lblStrEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStrEmployeeName
        '
        Me.txtStrEmployeeName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtStrEmployeeName.Location = New System.Drawing.Point(599, 33)
        Me.txtStrEmployeeName.Name = "txtStrEmployeeName"
        Me.txtStrEmployeeName.Size = New System.Drawing.Size(252, 22)
        Me.txtStrEmployeeName.TabIndex = 4
        '
        'lblStrEmployeeName
        '
        Me.lblStrEmployeeName.AutoSize = True
        Me.lblStrEmployeeName.Location = New System.Drawing.Point(477, 38)
        Me.lblStrEmployeeName.Name = "lblStrEmployeeName"
        Me.lblStrEmployeeName.Size = New System.Drawing.Size(76, 13)
        Me.lblStrEmployeeName.TabIndex = 5
        Me.lblStrEmployeeName.Text = "Tên nhân viên"
        Me.lblStrEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnFilter
        '
        Me.btnFilter.Location = New System.Drawing.Point(863, 34)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 6
        Me.btnFilter.Text = "Lọc (F5)"
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
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
        Me.tdbg.Location = New System.Drawing.Point(3, 61)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RecordSelectors = False
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 565)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 7
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsBackPay, Me.mnsViewResult, Me.mnsCancelResult, Me.ToolStripSeparator2, Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 120)
        '
        'mnsBackPay
        '
        Me.mnsBackPay.Name = "mnsBackPay"
        Me.mnsBackPay.Size = New System.Drawing.Size(136, 22)
        Me.mnsBackPay.Text = "&Hồi tố lương"
        '
        'mnsViewResult
        '
        Me.mnsViewResult.Name = "mnsViewResult"
        Me.mnsViewResult.Size = New System.Drawing.Size(136, 22)
        Me.mnsViewResult.Text = "&Xem kết quả"
        '
        'mnsCancelResult
        '
        Me.mnsCancelResult.Name = "mnsCancelResult"
        Me.mnsCancelResult.Size = New System.Drawing.Size(136, 22)
        Me.mnsCancelResult.Text = "Hủy kết q&uả"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(133, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(136, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(136, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(3, 635)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(188, 17)
        Me.chkIsUsed.TabIndex = 8
        Me.chkIsUsed.Text = "Chỉ hiển thị những dữ liệu đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator9, Me.tsbClose, Me.ToolStripSeparator10, Me.tsdActive})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1018, 25)
        Me.ToolStrip1.TabIndex = 9
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
        'tsbClose
        '
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(37, 22)
        Me.tsbClose.Text = "Đón&g"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmBackPay, Me.tsmViewResult, Me.tsmCancelResult, Me.ToolStripSeparator1, Me.tsmFind, Me.tsmListAll})
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(68, 22)
        Me.tsdActive.Text = "&Thực hiện"
        '
        'tsmBackPay
        '
        Me.tsmBackPay.Name = "tsmBackPay"
        Me.tsmBackPay.Size = New System.Drawing.Size(136, 22)
        Me.tsmBackPay.Text = "&Hồi tố lương"
        '
        'tsmViewResult
        '
        Me.tsmViewResult.Name = "tsmViewResult"
        Me.tsmViewResult.Size = New System.Drawing.Size(136, 22)
        Me.tsmViewResult.Text = "&Xem kết quả"
        '
        'tsmCancelResult
        '
        Me.tsmCancelResult.Name = "tsmCancelResult"
        Me.tsmCancelResult.Size = New System.Drawing.Size(136, 22)
        Me.tsmCancelResult.Text = "Hủy kết q&uả"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(133, 6)
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(136, 22)
        Me.tsmFind.Text = "Tìm &kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(136, 22)
        Me.tsmListAll.Text = "&Liệt kê tất cả"
        '
        'D13F2090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.txtStrEmployeeName)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.txtStrEmployeeID)
        Me.Controls.Add(Me.tdbcPeriod)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblStrEmployeeID)
        Me.Controls.Add(Me.lblStrEmployeeName)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2090"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh sÀch nh¡n vi£n häi tç l§¥ng - D13F2090"
        CType(Me.tdbcPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcPeriod As C1.Win.C1List.C1Combo
    Private WithEvents lblPeriod As System.Windows.Forms.Label
    Private WithEvents txtStrEmployeeID As System.Windows.Forms.TextBox
    Private WithEvents lblStrEmployeeID As System.Windows.Forms.Label
    Private WithEvents txtStrEmployeeName As System.Windows.Forms.TextBox
    Private WithEvents lblStrEmployeeName As System.Windows.Forms.Label
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Private WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Private WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Private WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsBackPay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsViewResult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsCancelResult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmBackPay As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmViewResult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmCancelResult As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
End Class
