<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2005
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
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2005))
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnAction = New System.Windows.Forms.Button
        Me.chkCheckAll = New System.Windows.Forms.CheckBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tdbdPayrollVoucherNo = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.C1ContextMenu1 = New C1.Win.C1Command.C1ContextMenu
        Me.mnuFindLink = New C1.Win.C1Command.C1CommandLink
        Me.mnuFind = New C1.Win.C1Command.C1Command
        Me.mnuListLink = New C1.Win.C1Command.C1CommandLink
        Me.mnuListAll = New C1.Win.C1Command.C1Command
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdPayrollVoucherNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(650, 400)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(568, 400)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 2
        Me.btnAction.Text = "&Thực hiện..."
        Me.btnAction.UseVisualStyleBackColor = True
        '
        'chkCheckAll
        '
        Me.chkCheckAll.AutoSize = True
        Me.chkCheckAll.Location = New System.Drawing.Point(41, 8)
        Me.chkCheckAll.Name = "chkCheckAll"
        Me.chkCheckAll.Size = New System.Drawing.Size(81, 17)
        Me.chkCheckAll.TabIndex = 0
        Me.chkCheckAll.Text = "Chọn tất cả"
        Me.chkCheckAll.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu1)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 28)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(720, 366)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'tdbdPayrollVoucherNo
        '
        Me.tdbdPayrollVoucherNo.AllowColMove = False
        Me.tdbdPayrollVoucherNo.AllowColSelect = False
        Me.tdbdPayrollVoucherNo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdPayrollVoucherNo.AllowSort = False
        Me.tdbdPayrollVoucherNo.AlternatingRows = True
        Me.tdbdPayrollVoucherNo.CaptionHeight = 17
        Me.tdbdPayrollVoucherNo.CaptionStyle = Style9
        Me.tdbdPayrollVoucherNo.ColumnCaptionHeight = 17
        Me.tdbdPayrollVoucherNo.ColumnFooterHeight = 17
        Me.tdbdPayrollVoucherNo.DisplayMember = "PayrollVoucherNo"
        Me.tdbdPayrollVoucherNo.EmptyRows = True
        Me.tdbdPayrollVoucherNo.EvenRowStyle = Style10
        Me.tdbdPayrollVoucherNo.ExtendRightColumn = True
        Me.tdbdPayrollVoucherNo.FetchRowStyles = False
        Me.tdbdPayrollVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdPayrollVoucherNo.FooterStyle = Style11
        Me.tdbdPayrollVoucherNo.HeadingStyle = Style12
        Me.tdbdPayrollVoucherNo.HighLightRowStyle = Style13
        Me.tdbdPayrollVoucherNo.Images.Add(CType(resources.GetObject("tdbdPayrollVoucherNo.Images"), System.Drawing.Image))
        Me.tdbdPayrollVoucherNo.Location = New System.Drawing.Point(174, 104)
        Me.tdbdPayrollVoucherNo.Name = "tdbdPayrollVoucherNo"
        Me.tdbdPayrollVoucherNo.OddRowStyle = Style14
        Me.tdbdPayrollVoucherNo.RecordSelectorStyle = Style15
        Me.tdbdPayrollVoucherNo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdPayrollVoucherNo.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdPayrollVoucherNo.RowHeight = 15
        Me.tdbdPayrollVoucherNo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdPayrollVoucherNo.ScrollTips = False
        Me.tdbdPayrollVoucherNo.Size = New System.Drawing.Size(300, 147)
        Me.tdbdPayrollVoucherNo.Style = Style16
        Me.tdbdPayrollVoucherNo.TabIndex = 5
        Me.tdbdPayrollVoucherNo.TabStop = False
        Me.tdbdPayrollVoucherNo.ValueMember = "PayrollVoucherNo"
        Me.tdbdPayrollVoucherNo.Visible = False
        Me.tdbdPayrollVoucherNo.PropBag = resources.GetString("tdbdPayrollVoucherNo.PropBag")
        '
        'C1ContextMenu1
        '
        Me.C1ContextMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.mnuFindLink, Me.mnuListLink})
        Me.C1ContextMenu1.Name = "C1ContextMenu1"
        '
        'mnuFindLink
        '
        Me.mnuFindLink.Command = Me.mnuFind
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListLink
        '
        Me.mnuListLink.Command = Me.mnuListAll
        Me.mnuListLink.SortOrder = 1
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu1)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'D45F2005
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 428)
        Me.Controls.Add(Me.tdbdPayrollVoucherNo)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.chkCheckAll)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2005"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa kÕt qu¶ thÍ giao viÖc - D45F2005"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdPayrollVoucherNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnAction As System.Windows.Forms.Button
    Private WithEvents chkCheckAll As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdPayrollVoucherNo As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents C1ContextMenu1 As C1.Win.C1Command.C1ContextMenu
    Friend WithEvents mnuFindLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents mnuFind As C1.Win.C1Command.C1Command
    Friend WithEvents mnuListLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuListAll As C1.Win.C1Command.C1Command

End Class
