<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2027
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
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2027))
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.mnuFind = New C1.Win.C1Command.C1Command
        Me.mnuListAll = New C1.Win.C1Command.C1Command
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnFilter = New System.Windows.Forms.Button
        Me.txtAbsentVoucherNo = New System.Windows.Forms.TextBox
        Me.txtRemark = New System.Windows.Forms.TextBox
        Me.c1dateEntryDate = New C1.Win.C1Input.C1DateEdit
        Me.txtAbsentVoucherID = New System.Windows.Forms.TextBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbdType = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.btnShow = New System.Windows.Forms.Button
        mnuFindLink = New C1.Win.C1Command.C1CommandLink
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink
        Me.GroupBox1.SuspendLayout()
        CType(Me.c1dateEntryDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
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
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.txtAbsentVoucherNo)
        Me.GroupBox1.Controls.Add(Me.txtRemark)
        Me.GroupBox1.Controls.Add(Me.c1dateEntryDate)
        Me.GroupBox1.Controls.Add(Me.txtAbsentVoucherID)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(994, 49)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Chứng từ"
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(913, 19)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(75, 22)
        Me.btnFilter.TabIndex = 3
        Me.btnFilter.Text = "Lọ&c"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'txtAbsentVoucherNo
        '
        Me.txtAbsentVoucherNo.Enabled = False
        Me.txtAbsentVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentVoucherNo.Location = New System.Drawing.Point(6, 19)
        Me.txtAbsentVoucherNo.Name = "txtAbsentVoucherNo"
        Me.txtAbsentVoucherNo.Size = New System.Drawing.Size(245, 22)
        Me.txtAbsentVoucherNo.TabIndex = 0
        '
        'txtRemark
        '
        Me.txtRemark.Enabled = False
        Me.txtRemark.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRemark.Location = New System.Drawing.Point(398, 19)
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(509, 22)
        Me.txtRemark.TabIndex = 2
        '
        'c1dateEntryDate
        '
        Me.c1dateEntryDate.AutoSize = False
        Me.c1dateEntryDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateEntryDate.EmptyAsNull = True
        Me.c1dateEntryDate.Enabled = False
        Me.c1dateEntryDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateEntryDate.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.c1dateEntryDate.Location = New System.Drawing.Point(254, 19)
        Me.c1dateEntryDate.Name = "c1dateEntryDate"
        Me.c1dateEntryDate.Size = New System.Drawing.Size(141, 22)
        Me.c1dateEntryDate.TabIndex = 1
        Me.c1dateEntryDate.Tag = Nothing
        Me.c1dateEntryDate.TrimStart = True
        Me.c1dateEntryDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtAbsentVoucherID
        '
        Me.txtAbsentVoucherID.Enabled = False
        Me.txtAbsentVoucherID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentVoucherID.Location = New System.Drawing.Point(6, 19)
        Me.txtAbsentVoucherID.Name = "txtAbsentVoucherID"
        Me.txtAbsentVoucherID.Size = New System.Drawing.Size(177, 22)
        Me.txtAbsentVoucherID.TabIndex = 0
        Me.txtAbsentVoucherID.Visible = False
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Floating
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(12, 66)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(994, 550)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(2, 2)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(850, 624)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(930, 624)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbdType
        '
        Me.tdbdType.AllowColMove = False
        Me.tdbdType.AllowColSelect = False
        Me.tdbdType.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdType.AllowSort = False
        Me.tdbdType.AlternatingRows = True
        Me.tdbdType.CaptionHeight = 17
        Me.tdbdType.CaptionStyle = Style1
        Me.tdbdType.ColumnCaptionHeight = 17
        Me.tdbdType.ColumnFooterHeight = 17
        Me.tdbdType.DisplayMember = "Type"
        Me.tdbdType.EmptyRows = True
        Me.tdbdType.EvenRowStyle = Style2
        Me.tdbdType.ExtendRightColumn = True
        Me.tdbdType.FetchRowStyles = False
        Me.tdbdType.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdType.FooterStyle = Style3
        Me.tdbdType.HeadingStyle = Style4
        Me.tdbdType.HighLightRowStyle = Style5
        Me.tdbdType.Images.Add(CType(resources.GetObject("tdbdType.Images"), System.Drawing.Image))
        Me.tdbdType.Location = New System.Drawing.Point(210, 164)
        Me.tdbdType.Name = "tdbdType"
        Me.tdbdType.OddRowStyle = Style6
        Me.tdbdType.RecordSelectorStyle = Style7
        Me.tdbdType.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdType.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdType.RowHeight = 15
        Me.tdbdType.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdType.ScrollTips = False
        Me.tdbdType.Size = New System.Drawing.Size(357, 147)
        Me.tdbdType.Style = Style8
        Me.tdbdType.TabIndex = 2
        Me.tdbdType.TabStop = False
        Me.tdbdType.ValueMember = "Type"
        Me.tdbdType.Visible = False
        Me.tdbdType.PropBag = resources.GetString("tdbdType.PropBag")
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuFindLink, mnuListAllLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(12, 624)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(116, 22)
        Me.btnShow.TabIndex = 4
        Me.btnShow.Text = "Hiển &thị"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'D13F2027
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.tdbdType)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2027"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "NhËp phiÕu ¢iÒu chÙnh thu nhËp - D13F2027"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.c1dateEntryDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtAbsentVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents txtRemark As System.Windows.Forms.TextBox
    Private WithEvents c1dateEntryDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents txtAbsentVoucherID As System.Windows.Forms.TextBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tdbdType As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents btnShow As System.Windows.Forms.Button
End Class
