<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2052
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2052))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.lblEmployeeName = New System.Windows.Forms.Label()
        Me.tdbcDepartmentID = New C1.Win.C1List.C1Combo()
        Me.lblDepartmentID = New System.Windows.Forms.Label()
        Me.grpMaster = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.tdbcTeamID = New C1.Win.C1List.C1Combo()
        Me.lblTeamID = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMaster.SuspendLayout()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(66, 15)
        Me.txtEmployeeID.MaxLength = 20
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.Size = New System.Drawing.Size(295, 22)
        Me.txtEmployeeID.TabIndex = 0
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblEmployeeID.Location = New System.Drawing.Point(8, 20)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(40, 13)
        Me.lblEmployeeID.TabIndex = 1
        Me.lblEmployeeID.Text = "Mã NV"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtEmployeeName.Location = New System.Drawing.Point(66, 43)
        Me.txtEmployeeName.MaxLength = 500
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.Size = New System.Drawing.Size(295, 22)
        Me.txtEmployeeName.TabIndex = 1
        '
        'lblEmployeeName
        '
        Me.lblEmployeeName.AutoSize = True
        Me.lblEmployeeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblEmployeeName.Location = New System.Drawing.Point(8, 48)
        Me.lblEmployeeName.Name = "lblEmployeeName"
        Me.lblEmployeeName.Size = New System.Drawing.Size(44, 13)
        Me.lblEmployeeName.TabIndex = 3
        Me.lblEmployeeName.Text = "Tên NV"
        Me.lblEmployeeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDepartmentID
        '
        Me.tdbcDepartmentID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDepartmentID.AllowColMove = False
        Me.tdbcDepartmentID.AllowSort = False
        Me.tdbcDepartmentID.AlternatingRows = True
        Me.tdbcDepartmentID.AutoCompletion = True
        Me.tdbcDepartmentID.AutoDropDown = True
        Me.tdbcDepartmentID.Caption = ""
        Me.tdbcDepartmentID.CaptionHeight = 17
        Me.tdbcDepartmentID.CaptionStyle = Style1
        Me.tdbcDepartmentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDepartmentID.ColumnCaptionHeight = 17
        Me.tdbcDepartmentID.ColumnFooterHeight = 17
        Me.tdbcDepartmentID.ColumnWidth = 100
        Me.tdbcDepartmentID.ContentHeight = 17
        Me.tdbcDepartmentID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDepartmentID.DisplayMember = "DepartmentName"
        Me.tdbcDepartmentID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDepartmentID.DropDownWidth = 350
        Me.tdbcDepartmentID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDepartmentID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDepartmentID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDepartmentID.EditorHeight = 17
        Me.tdbcDepartmentID.EmptyRows = True
        Me.tdbcDepartmentID.EvenRowStyle = Style2
        Me.tdbcDepartmentID.ExtendRightColumn = True
        Me.tdbcDepartmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDepartmentID.FooterStyle = Style3
        Me.tdbcDepartmentID.HeadingStyle = Style4
        Me.tdbcDepartmentID.HighLightRowStyle = Style5
        Me.tdbcDepartmentID.Images.Add(CType(resources.GetObject("tdbcDepartmentID.Images"), System.Drawing.Image))
        Me.tdbcDepartmentID.ItemHeight = 15
        Me.tdbcDepartmentID.Location = New System.Drawing.Point(499, 15)
        Me.tdbcDepartmentID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDepartmentID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDepartmentID.MaxLength = 32767
        Me.tdbcDepartmentID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDepartmentID.Name = "tdbcDepartmentID"
        Me.tdbcDepartmentID.OddRowStyle = Style6
        Me.tdbcDepartmentID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDepartmentID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.SelectedStyle = Style7
        Me.tdbcDepartmentID.Size = New System.Drawing.Size(486, 23)
        Me.tdbcDepartmentID.Style = Style8
        Me.tdbcDepartmentID.TabIndex = 2
        Me.tdbcDepartmentID.ValueMember = "DepartmentID"
        Me.tdbcDepartmentID.PropBag = resources.GetString("tdbcDepartmentID.PropBag")
        '
        'lblDepartmentID
        '
        Me.lblDepartmentID.AutoSize = True
        Me.lblDepartmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblDepartmentID.Location = New System.Drawing.Point(416, 20)
        Me.lblDepartmentID.Name = "lblDepartmentID"
        Me.lblDepartmentID.Size = New System.Drawing.Size(59, 13)
        Me.lblDepartmentID.TabIndex = 5
        Me.lblDepartmentID.Text = "Phòng ban"
        Me.lblDepartmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpMaster
        '
        Me.grpMaster.Controls.Add(Me.btnFilter)
        Me.grpMaster.Controls.Add(Me.tdbcTeamID)
        Me.grpMaster.Controls.Add(Me.txtEmployeeID)
        Me.grpMaster.Controls.Add(Me.tdbcDepartmentID)
        Me.grpMaster.Controls.Add(Me.lblDepartmentID)
        Me.grpMaster.Controls.Add(Me.txtEmployeeName)
        Me.grpMaster.Controls.Add(Me.lblEmployeeName)
        Me.grpMaster.Controls.Add(Me.lblEmployeeID)
        Me.grpMaster.Controls.Add(Me.lblTeamID)
        Me.grpMaster.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpMaster.Location = New System.Drawing.Point(9, 2)
        Me.grpMaster.Name = "grpMaster"
        Me.grpMaster.Size = New System.Drawing.Size(991, 99)
        Me.grpMaster.TabIndex = 0
        Me.grpMaster.TabStop = False
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.btnFilter.Location = New System.Drawing.Point(909, 71)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 4
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'tdbcTeamID
        '
        Me.tdbcTeamID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTeamID.AllowColMove = False
        Me.tdbcTeamID.AllowSort = False
        Me.tdbcTeamID.AlternatingRows = True
        Me.tdbcTeamID.AutoCompletion = True
        Me.tdbcTeamID.AutoDropDown = True
        Me.tdbcTeamID.Caption = ""
        Me.tdbcTeamID.CaptionHeight = 17
        Me.tdbcTeamID.CaptionStyle = Style9
        Me.tdbcTeamID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTeamID.ColumnCaptionHeight = 17
        Me.tdbcTeamID.ColumnFooterHeight = 17
        Me.tdbcTeamID.ColumnWidth = 100
        Me.tdbcTeamID.ContentHeight = 17
        Me.tdbcTeamID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTeamID.DisplayMember = "TeamName"
        Me.tdbcTeamID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTeamID.DropDownWidth = 350
        Me.tdbcTeamID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTeamID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTeamID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTeamID.EditorHeight = 17
        Me.tdbcTeamID.EmptyRows = True
        Me.tdbcTeamID.EvenRowStyle = Style10
        Me.tdbcTeamID.ExtendRightColumn = True
        Me.tdbcTeamID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTeamID.FooterStyle = Style11
        Me.tdbcTeamID.HeadingStyle = Style12
        Me.tdbcTeamID.HighLightRowStyle = Style13
        Me.tdbcTeamID.Images.Add(CType(resources.GetObject("tdbcTeamID.Images"), System.Drawing.Image))
        Me.tdbcTeamID.ItemHeight = 15
        Me.tdbcTeamID.Location = New System.Drawing.Point(499, 43)
        Me.tdbcTeamID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTeamID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTeamID.MaxLength = 32767
        Me.tdbcTeamID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTeamID.Name = "tdbcTeamID"
        Me.tdbcTeamID.OddRowStyle = Style14
        Me.tdbcTeamID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTeamID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.SelectedStyle = Style15
        Me.tdbcTeamID.Size = New System.Drawing.Size(486, 23)
        Me.tdbcTeamID.Style = Style16
        Me.tdbcTeamID.TabIndex = 3
        Me.tdbcTeamID.ValueMember = "TeamID"
        Me.tdbcTeamID.PropBag = resources.GetString("tdbcTeamID.PropBag")
        '
        'lblTeamID
        '
        Me.lblTeamID.AutoSize = True
        Me.lblTeamID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblTeamID.Location = New System.Drawing.Point(416, 48)
        Me.lblTeamID.Name = "lblTeamID"
        Me.lblTeamID.Size = New System.Drawing.Size(49, 13)
        Me.lblTeamID.TabIndex = 7
        Me.lblTeamID.Text = "Tổ nhóm"
        Me.lblTeamID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 111)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(991, 502)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(842, 619)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(76, 22)
        Me.btnChoose.TabIndex = 2
        Me.btnChoose.Text = "Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(924, 619)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D45F2052
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 645)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.grpMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2052"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn nh¡n vi£n - D45F2052"
        CType(Me.tdbcDepartmentID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMaster.ResumeLayout(False)
        Me.grpMaster.PerformLayout()
        CType(Me.tdbcTeamID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Private WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Private WithEvents lblEmployeeName As System.Windows.Forms.Label
    Private WithEvents tdbcDepartmentID As C1.Win.C1List.C1Combo
    Private WithEvents lblDepartmentID As System.Windows.Forms.Label
    Private WithEvents grpMaster As System.Windows.Forms.GroupBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbcTeamID As C1.Win.C1List.C1Combo
    Private WithEvents lblTeamID As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class