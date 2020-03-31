<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F2013
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F2013))
        Me.mnuFind = New C1.Win.C1Command.C1Command
        Me.mnuListAll = New C1.Win.C1Command.C1Command
        Me.tdbgFrom = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnRow = New System.Windows.Forms.Button
        Me.btnSelectAll = New System.Windows.Forms.Button
        Me.btnCancelRow = New System.Windows.Forms.Button
        Me.btnCancelAll = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.tdbgTo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.chkCancelCandidateID = New System.Windows.Forms.CheckBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.c1dateIntTime = New C1.Win.C1Input.C1DateEdit
        Me.lblntTime = New System.Windows.Forms.Label
        Me.c1dateIntDate = New C1.Win.C1Input.C1DateEdit
        Me.lblteIntTime = New System.Windows.Forms.Label
        Me.lblInTime = New System.Windows.Forms.Label
        Me.lblteIntDate = New System.Windows.Forms.Label
        mnuFindLink = New C1.Win.C1Command.C1CommandLink
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbgFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateIntTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateIntDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.c1dateIntDate.SuspendLayout()
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
        'tdbgFrom
        '
        Me.tdbgFrom.AllowColMove = False
        Me.tdbgFrom.AllowColSelect = False
        Me.tdbgFrom.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgFrom.AllowSort = False
        Me.tdbgFrom.AllowUpdate = False
        Me.tdbgFrom.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbgFrom, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgFrom, Me.C1ContextMenu)
        Me.tdbgFrom.CaptionHeight = 17
        Me.tdbgFrom.EmptyRows = True
        Me.tdbgFrom.ExtendRightColumn = True
        Me.tdbgFrom.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgFrom.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgFrom.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgFrom.Images.Add(CType(resources.GetObject("tdbgFrom.Images"), System.Drawing.Image))
        Me.tdbgFrom.Location = New System.Drawing.Point(12, 50)
        Me.tdbgFrom.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.tdbgFrom.Name = "tdbgFrom"
        Me.tdbgFrom.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgFrom.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgFrom.PreviewInfo.ZoomFactor = 75
        Me.tdbgFrom.PrintInfo.PageSettings = CType(resources.GetObject("tdbgFrom.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgFrom.RowHeight = 15
        Me.tdbgFrom.Size = New System.Drawing.Size(284, 339)
        Me.tdbgFrom.TabAcrossSplits = True
        Me.tdbgFrom.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgFrom.TabIndex = 4
        Me.tdbgFrom.Tag = "COL"
        Me.tdbgFrom.PropBag = resources.GetString("tdbgFrom.PropBag")
        '
        'btnRow
        '
        Me.btnRow.Location = New System.Drawing.Point(306, 162)
        Me.btnRow.Name = "btnRow"
        Me.btnRow.Size = New System.Drawing.Size(45, 22)
        Me.btnRow.TabIndex = 6
        Me.btnRow.Text = ">"
        Me.btnRow.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(306, 134)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(45, 22)
        Me.btnSelectAll.TabIndex = 5
        Me.btnSelectAll.Text = ">>"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'btnCancelRow
        '
        Me.btnCancelRow.Location = New System.Drawing.Point(306, 190)
        Me.btnCancelRow.Name = "btnCancelRow"
        Me.btnCancelRow.Size = New System.Drawing.Size(45, 22)
        Me.btnCancelRow.TabIndex = 7
        Me.btnCancelRow.Text = "<"
        Me.btnCancelRow.UseVisualStyleBackColor = True
        '
        'btnCancelAll
        '
        Me.btnCancelAll.Location = New System.Drawing.Point(306, 218)
        Me.btnCancelAll.Name = "btnCancelAll"
        Me.btnCancelAll.Size = New System.Drawing.Size(45, 22)
        Me.btnCancelAll.TabIndex = 8
        Me.btnCancelAll.Text = "<<"
        Me.btnCancelAll.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(572, 400)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
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
        'tdbgTo
        '
        Me.tdbgTo.AllowColMove = False
        Me.tdbgTo.AllowColSelect = False
        Me.tdbgTo.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgTo.AllowSort = False
        Me.tdbgTo.AllowUpdate = False
        Me.tdbgTo.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbgTo, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgTo, Me.C1ContextMenu)
        Me.tdbgTo.CaptionHeight = 17
        Me.tdbgTo.EmptyRows = True
        Me.tdbgTo.ExtendRightColumn = True
        Me.tdbgTo.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgTo.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgTo.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgTo.Images.Add(CType(resources.GetObject("tdbgTo.Images"), System.Drawing.Image))
        Me.tdbgTo.Location = New System.Drawing.Point(364, 50)
        Me.tdbgTo.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.tdbgTo.Name = "tdbgTo"
        Me.tdbgTo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgTo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgTo.PreviewInfo.ZoomFactor = 75
        Me.tdbgTo.PrintInfo.PageSettings = CType(resources.GetObject("tdbgTo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgTo.RowHeight = 15
        Me.tdbgTo.Size = New System.Drawing.Size(284, 339)
        Me.tdbgTo.TabAcrossSplits = True
        Me.tdbgTo.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgTo.TabIndex = 9
        Me.tdbgTo.Tag = "COL"
        Me.tdbgTo.PropBag = resources.GetString("tdbgTo.PropBag")
        '
        'chkCancelCandidateID
        '
        Me.chkCancelCandidateID.AutoSize = True
        Me.chkCancelCandidateID.Location = New System.Drawing.Point(12, 400)
        Me.chkCancelCandidateID.Name = "chkCancelCandidateID"
        Me.chkCancelCandidateID.Size = New System.Drawing.Size(233, 17)
        Me.chkCancelCandidateID.TabIndex = 12
        Me.chkCancelCandidateID.Text = "Hiển thị các ứng viên đã dời lịch phỏng vấn"
        Me.chkCancelCandidateID.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(490, 400)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'c1dateIntTime
        '
        Me.c1dateIntTime.AutoSize = False
        Me.c1dateIntTime.CustomFormat = "HH:mm"
        Me.c1dateIntTime.EmptyAsNull = True
        Me.c1dateIntTime.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateIntTime.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateIntTime.Location = New System.Drawing.Point(380, 9)
        Me.c1dateIntTime.Name = "c1dateIntTime"
        Me.c1dateIntTime.Size = New System.Drawing.Size(100, 22)
        Me.c1dateIntTime.TabIndex = 3
        Me.c1dateIntTime.Tag = Nothing
        Me.c1dateIntTime.TrimStart = True
        Me.c1dateIntTime.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblntTime
        '
        Me.lblntTime.AutoSize = True
        Me.lblntTime.Location = New System.Drawing.Point(363, 308)
        Me.lblntTime.Name = "lblntTime"
        Me.lblntTime.Size = New System.Drawing.Size(40, 13)
        Me.lblntTime.TabIndex = 9
        Me.lblntTime.Text = "Giờ PV"
        Me.lblntTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateIntDate
        '
        Me.c1dateIntDate.AutoSize = False
        Me.c1dateIntDate.Controls.Add(Me.lblteIntTime)
        Me.c1dateIntDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateIntDate.EmptyAsNull = True
        Me.c1dateIntDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateIntDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateIntDate.Location = New System.Drawing.Point(106, 9)
        Me.c1dateIntDate.Name = "c1dateIntDate"
        Me.c1dateIntDate.Size = New System.Drawing.Size(104, 22)
        Me.c1dateIntDate.TabIndex = 1
        Me.c1dateIntDate.Tag = Nothing
        Me.c1dateIntDate.TrimStart = True
        Me.c1dateIntDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteIntTime
        '
        Me.lblteIntTime.AutoSize = True
        Me.lblteIntTime.Location = New System.Drawing.Point(74, 313)
        Me.lblteIntTime.Name = "lblteIntTime"
        Me.lblteIntTime.Size = New System.Drawing.Size(44, 14)
        Me.lblteIntTime.TabIndex = 0
        Me.lblteIntTime.Text = "Giờ PV"
        Me.lblteIntTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInTime
        '
        Me.lblInTime.AutoSize = True
        Me.lblInTime.Location = New System.Drawing.Point(283, 13)
        Me.lblInTime.Name = "lblInTime"
        Me.lblInTime.Size = New System.Drawing.Size(68, 13)
        Me.lblInTime.TabIndex = 2
        Me.lblInTime.Text = "Thời gian PV"
        Me.lblInTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteIntDate
        '
        Me.lblteIntDate.AutoSize = True
        Me.lblteIntDate.Location = New System.Drawing.Point(15, 13)
        Me.lblteIntDate.Name = "lblteIntDate"
        Me.lblteIntDate.Size = New System.Drawing.Size(49, 13)
        Me.lblteIntDate.TabIndex = 0
        Me.lblteIntDate.Text = "Ngày PV"
        Me.lblteIntDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D25F2013
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(660, 434)
        Me.Controls.Add(Me.c1dateIntTime)
        Me.Controls.Add(Me.c1dateIntDate)
        Me.Controls.Add(Me.lblInTime)
        Me.Controls.Add(Me.lblteIntDate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbgTo)
        Me.Controls.Add(Me.chkCancelCandidateID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnCancelAll)
        Me.Controls.Add(Me.btnCancelRow)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnRow)
        Me.Controls.Add(Me.tdbgFrom)
        Me.Controls.Add(Me.lblntTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F2013"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Th£m ÷ng vi£n - D25F2013"
        CType(Me.tdbgFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateIntTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateIntDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.c1dateIntDate.ResumeLayout(False)
        Me.c1dateIntDate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbgFrom As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnRow As System.Windows.Forms.Button
    Private WithEvents btnSelectAll As System.Windows.Forms.Button
    Private WithEvents btnCancelRow As System.Windows.Forms.Button
    Private WithEvents btnCancelAll As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents chkCancelCandidateID As System.Windows.Forms.CheckBox
    Private WithEvents tdbgTo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents c1dateIntTime As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1dateIntDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteIntTime As System.Windows.Forms.Label
    Private WithEvents lblInTime As System.Windows.Forms.Label
    Private WithEvents lblteIntDate As System.Windows.Forms.Label
    Private WithEvents lblntTime As System.Windows.Forms.Label
End Class
