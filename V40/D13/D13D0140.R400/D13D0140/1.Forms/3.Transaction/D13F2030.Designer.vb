<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2030
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2030))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.mnuAdd = New C1.Win.C1Command.C1Command
        Me.mnuView = New C1.Win.C1Command.C1Command
        Me.mnuEdit = New C1.Win.C1Command.C1Command
        Me.mnuDelete = New C1.Win.C1Command.C1Command
        Me.mnuFind = New C1.Win.C1Command.C1Command
        Me.mnuListAll = New C1.Win.C1Command.C1Command
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command
        Me.tdbcAbsentVoucherNo = New C1.Win.C1List.C1Combo
        Me.lblAbsentVoucherNo = New System.Windows.Forms.Label
        Me.txtAbsentVoucherNoName = New System.Windows.Forms.TextBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnAction = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.txtAbsentVoucherID = New System.Windows.Forms.TextBox
        mnuAddLink = New C1.Win.C1Command.C1CommandLink
        mnuViewLink = New C1.Win.C1Command.C1CommandLink
        mnuEditLink = New C1.Win.C1Command.C1CommandLink
        mnuDeleteLink = New C1.Win.C1Command.C1CommandLink
        mnuFindLink = New C1.Win.C1Command.C1CommandLink
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink
        mnuSysInfoLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbcAbsentVoucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.mnuView.Visible = False
        '
        'mnuEditLink
        '
        mnuEditLink.Command = Me.mnuEdit
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Text = "&Sửa"
        Me.mnuEdit.Visible = False
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
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        mnuFindLink.Delimiter = True
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
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
        '
        'mnuSysInfo
        '
        Me.mnuSysInfo.Name = "mnuSysInfo"
        Me.mnuSysInfo.Text = "Thông tin &hệ thống"
        '
        'tdbcAbsentVoucherNo
        '
        Me.tdbcAbsentVoucherNo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcAbsentVoucherNo.AllowColMove = False
        Me.tdbcAbsentVoucherNo.AllowSort = False
        Me.tdbcAbsentVoucherNo.AlternatingRows = True
        Me.tdbcAbsentVoucherNo.AutoCompletion = True
        Me.tdbcAbsentVoucherNo.AutoDropDown = True
        Me.tdbcAbsentVoucherNo.Caption = ""
        Me.tdbcAbsentVoucherNo.CaptionHeight = 17
        Me.tdbcAbsentVoucherNo.CaptionStyle = Style1
        Me.tdbcAbsentVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcAbsentVoucherNo.ColumnCaptionHeight = 17
        Me.tdbcAbsentVoucherNo.ColumnFooterHeight = 17
        Me.tdbcAbsentVoucherNo.ColumnWidth = 100
        Me.tdbcAbsentVoucherNo.ContentHeight = 17
        Me.tdbcAbsentVoucherNo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcAbsentVoucherNo.DisplayMember = "AbsentVoucherNo"
        Me.tdbcAbsentVoucherNo.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcAbsentVoucherNo.DropDownWidth = 300
        Me.tdbcAbsentVoucherNo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcAbsentVoucherNo.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcAbsentVoucherNo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcAbsentVoucherNo.EditorHeight = 17
        Me.tdbcAbsentVoucherNo.EmptyRows = True
        Me.tdbcAbsentVoucherNo.EvenRowStyle = Style2
        Me.tdbcAbsentVoucherNo.ExtendRightColumn = True
        Me.tdbcAbsentVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcAbsentVoucherNo.FooterStyle = Style3
        Me.tdbcAbsentVoucherNo.HeadingStyle = Style4
        Me.tdbcAbsentVoucherNo.HighLightRowStyle = Style5
        Me.tdbcAbsentVoucherNo.Images.Add(CType(resources.GetObject("tdbcAbsentVoucherNo.Images"), System.Drawing.Image))
        Me.tdbcAbsentVoucherNo.ItemHeight = 15
        Me.tdbcAbsentVoucherNo.Location = New System.Drawing.Point(154, 621)
        Me.tdbcAbsentVoucherNo.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcAbsentVoucherNo.MaxDropDownItems = CType(8, Short)
        Me.tdbcAbsentVoucherNo.MaxLength = 32767
        Me.tdbcAbsentVoucherNo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcAbsentVoucherNo.Name = "tdbcAbsentVoucherNo"
        Me.tdbcAbsentVoucherNo.OddRowStyle = Style6
        Me.tdbcAbsentVoucherNo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcAbsentVoucherNo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcAbsentVoucherNo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcAbsentVoucherNo.SelectedStyle = Style7
        Me.tdbcAbsentVoucherNo.Size = New System.Drawing.Size(172, 23)
        Me.tdbcAbsentVoucherNo.Style = Style8
        Me.tdbcAbsentVoucherNo.TabIndex = 0
        Me.tdbcAbsentVoucherNo.ValueMember = "AbsentVoucherNo"
        Me.tdbcAbsentVoucherNo.Visible = False
        Me.tdbcAbsentVoucherNo.PropBag = resources.GetString("tdbcAbsentVoucherNo.PropBag")
        '
        'lblAbsentVoucherNo
        '
        Me.lblAbsentVoucherNo.AutoSize = True
        Me.lblAbsentVoucherNo.Location = New System.Drawing.Point(12, 16)
        Me.lblAbsentVoucherNo.Name = "lblAbsentVoucherNo"
        Me.lblAbsentVoucherNo.Size = New System.Drawing.Size(85, 13)
        Me.lblAbsentVoucherNo.TabIndex = 1
        Me.lblAbsentVoucherNo.Text = "Chấm công nhật"
        Me.lblAbsentVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbsentVoucherNoName
        '
        Me.txtAbsentVoucherNoName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtAbsentVoucherNoName.Location = New System.Drawing.Point(320, 12)
        Me.txtAbsentVoucherNoName.Name = "txtAbsentVoucherNoName"
        Me.txtAbsentVoucherNoName.ReadOnly = True
        Me.txtAbsentVoucherNoName.Size = New System.Drawing.Size(686, 22)
        Me.txtAbsentVoucherNoName.TabIndex = 2
        Me.txtAbsentVoucherNoName.TabStop = False
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(15, 41)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(994, 575)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(850, 621)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 4
        Me.btnAction.Text = "&Thực hiện..."
        Me.btnAction.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(933, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuAddLink, mnuViewLink, mnuEditLink, mnuDeleteLink, mnuFindLink, mnuListAllLink, mnuSysInfoLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuAdd)
        Me.C1CommandHolder.Commands.Add(Me.mnuView)
        Me.C1CommandHolder.Commands.Add(Me.mnuEdit)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder.Owner = Me
        '
        'txtAbsentVoucherID
        '
        Me.txtAbsentVoucherID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentVoucherID.Location = New System.Drawing.Point(132, 12)
        Me.txtAbsentVoucherID.Name = "txtAbsentVoucherID"
        Me.txtAbsentVoucherID.ReadOnly = True
        Me.txtAbsentVoucherID.Size = New System.Drawing.Size(182, 22)
        Me.txtAbsentVoucherID.TabIndex = 6
        '
        'D13F2030
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.txtAbsentVoucherID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.tdbcAbsentVoucherNo)
        Me.Controls.Add(Me.lblAbsentVoucherNo)
        Me.Controls.Add(Me.txtAbsentVoucherNoName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2030"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn chuyÓn c¤ng sang phÏp - D13F2030"
        CType(Me.tdbcAbsentVoucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcAbsentVoucherNo As C1.Win.C1List.C1Combo
    Private WithEvents lblAbsentVoucherNo As System.Windows.Forms.Label
    Private WithEvents txtAbsentVoucherNoName As System.Windows.Forms.TextBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnAction As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    Private WithEvents mnuView As C1.Win.C1Command.C1Command
    Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Private WithEvents txtAbsentVoucherID As System.Windows.Forms.TextBox
End Class
