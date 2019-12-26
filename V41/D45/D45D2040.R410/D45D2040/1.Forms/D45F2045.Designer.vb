<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2045
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2045))
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.tdbcTaskID = New C1.Win.C1List.C1Combo()
        Me.tdbcComponentID = New C1.Win.C1List.C1Combo()
        Me.lblTaskID = New System.Windows.Forms.Label()
        Me.lblComponentID = New System.Windows.Forms.Label()
        Me.tdbcGroupProductID = New C1.Win.C1List.C1Combo()
        Me.lblGroupProductID = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.chkIsUsed = New System.Windows.Forms.CheckBox()
        CType(Me.tdbcTaskID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcComponentID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcGroupProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnFilter
        '
        Me.btnFilter.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnFilter.Location = New System.Drawing.Point(927, 11)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(76, 22)
        Me.btnFilter.TabIndex = 46
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'tdbcTaskID
        '
        Me.tdbcTaskID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTaskID.AllowColMove = False
        Me.tdbcTaskID.AllowSort = False
        Me.tdbcTaskID.AlternatingRows = True
        Me.tdbcTaskID.AutoDropDown = True
        Me.tdbcTaskID.Caption = ""
        Me.tdbcTaskID.CaptionHeight = 17
        Me.tdbcTaskID.CaptionStyle = Style1
        Me.tdbcTaskID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTaskID.ColumnCaptionHeight = 17
        Me.tdbcTaskID.ColumnFooterHeight = 17
        Me.tdbcTaskID.ColumnWidth = 100
        Me.tdbcTaskID.ContentHeight = 17
        Me.tdbcTaskID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTaskID.DisplayMember = "TaskName"
        Me.tdbcTaskID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTaskID.DropDownWidth = 350
        Me.tdbcTaskID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTaskID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTaskID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTaskID.EditorHeight = 17
        Me.tdbcTaskID.EmptyRows = True
        Me.tdbcTaskID.EvenRowStyle = Style2
        Me.tdbcTaskID.ExtendRightColumn = True
        Me.tdbcTaskID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTaskID.FooterStyle = Style3
        Me.tdbcTaskID.HeadingStyle = Style4
        Me.tdbcTaskID.HighLightRowStyle = Style5
        Me.tdbcTaskID.Images.Add(CType(resources.GetObject("tdbcTaskID.Images"), System.Drawing.Image))
        Me.tdbcTaskID.ItemHeight = 15
        Me.tdbcTaskID.Location = New System.Drawing.Point(728, 11)
        Me.tdbcTaskID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTaskID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTaskID.MaxLength = 32767
        Me.tdbcTaskID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTaskID.Name = "tdbcTaskID"
        Me.tdbcTaskID.OddRowStyle = Style6
        Me.tdbcTaskID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTaskID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTaskID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTaskID.SelectedStyle = Style7
        Me.tdbcTaskID.Size = New System.Drawing.Size(194, 23)
        Me.tdbcTaskID.Style = Style8
        Me.tdbcTaskID.TabIndex = 45
        Me.tdbcTaskID.ValueMember = "TaskID"
        Me.tdbcTaskID.PropBag = resources.GetString("tdbcTaskID.PropBag")
        '
        'tdbcComponentID
        '
        Me.tdbcComponentID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcComponentID.AllowColMove = False
        Me.tdbcComponentID.AllowSort = False
        Me.tdbcComponentID.AlternatingRows = True
        Me.tdbcComponentID.AutoDropDown = True
        Me.tdbcComponentID.Caption = ""
        Me.tdbcComponentID.CaptionHeight = 17
        Me.tdbcComponentID.CaptionStyle = Style9
        Me.tdbcComponentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcComponentID.ColumnCaptionHeight = 17
        Me.tdbcComponentID.ColumnFooterHeight = 17
        Me.tdbcComponentID.ColumnWidth = 100
        Me.tdbcComponentID.ContentHeight = 17
        Me.tdbcComponentID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcComponentID.DisplayMember = "ComponentName"
        Me.tdbcComponentID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcComponentID.DropDownWidth = 350
        Me.tdbcComponentID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcComponentID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcComponentID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcComponentID.EditorHeight = 17
        Me.tdbcComponentID.EmptyRows = True
        Me.tdbcComponentID.EvenRowStyle = Style10
        Me.tdbcComponentID.ExtendRightColumn = True
        Me.tdbcComponentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcComponentID.FooterStyle = Style11
        Me.tdbcComponentID.HeadingStyle = Style12
        Me.tdbcComponentID.HighLightRowStyle = Style13
        Me.tdbcComponentID.Images.Add(CType(resources.GetObject("tdbcComponentID.Images"), System.Drawing.Image))
        Me.tdbcComponentID.ItemHeight = 15
        Me.tdbcComponentID.Location = New System.Drawing.Point(420, 11)
        Me.tdbcComponentID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcComponentID.MaxDropDownItems = CType(8, Short)
        Me.tdbcComponentID.MaxLength = 32767
        Me.tdbcComponentID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcComponentID.Name = "tdbcComponentID"
        Me.tdbcComponentID.OddRowStyle = Style14
        Me.tdbcComponentID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcComponentID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcComponentID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcComponentID.SelectedStyle = Style15
        Me.tdbcComponentID.Size = New System.Drawing.Size(195, 23)
        Me.tdbcComponentID.Style = Style16
        Me.tdbcComponentID.TabIndex = 44
        Me.tdbcComponentID.ValueMember = "ComponentID"
        Me.tdbcComponentID.PropBag = resources.GetString("tdbcComponentID.PropBag")
        '
        'lblTaskID
        '
        Me.lblTaskID.AutoSize = True
        Me.lblTaskID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTaskID.Location = New System.Drawing.Point(637, 16)
        Me.lblTaskID.Name = "lblTaskID"
        Me.lblTaskID.Size = New System.Drawing.Size(66, 13)
        Me.lblTaskID.TabIndex = 49
        Me.lblTaskID.Text = "Cụm tiểu tác"
        Me.lblTaskID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblComponentID
        '
        Me.lblComponentID.AutoSize = True
        Me.lblComponentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComponentID.Location = New System.Drawing.Point(332, 16)
        Me.lblComponentID.Name = "lblComponentID"
        Me.lblComponentID.Size = New System.Drawing.Size(73, 13)
        Me.lblComponentID.TabIndex = 48
        Me.lblComponentID.Text = "Nhóm tiểu tác"
        Me.lblComponentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcGroupProductID
        '
        Me.tdbcGroupProductID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcGroupProductID.AllowColMove = False
        Me.tdbcGroupProductID.AllowSort = False
        Me.tdbcGroupProductID.AlternatingRows = True
        Me.tdbcGroupProductID.AutoDropDown = True
        Me.tdbcGroupProductID.Caption = ""
        Me.tdbcGroupProductID.CaptionHeight = 17
        Me.tdbcGroupProductID.CaptionStyle = Style17
        Me.tdbcGroupProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcGroupProductID.ColumnCaptionHeight = 17
        Me.tdbcGroupProductID.ColumnFooterHeight = 17
        Me.tdbcGroupProductID.ColumnWidth = 100
        Me.tdbcGroupProductID.ContentHeight = 17
        Me.tdbcGroupProductID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcGroupProductID.DisplayMember = "GroupProductName"
        Me.tdbcGroupProductID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcGroupProductID.DropDownWidth = 350
        Me.tdbcGroupProductID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcGroupProductID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcGroupProductID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcGroupProductID.EditorHeight = 17
        Me.tdbcGroupProductID.EmptyRows = True
        Me.tdbcGroupProductID.EvenRowStyle = Style18
        Me.tdbcGroupProductID.ExtendRightColumn = True
        Me.tdbcGroupProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcGroupProductID.FooterStyle = Style19
        Me.tdbcGroupProductID.HeadingStyle = Style20
        Me.tdbcGroupProductID.HighLightRowStyle = Style21
        Me.tdbcGroupProductID.Images.Add(CType(resources.GetObject("tdbcGroupProductID.Images"), System.Drawing.Image))
        Me.tdbcGroupProductID.ItemHeight = 15
        Me.tdbcGroupProductID.Location = New System.Drawing.Point(103, 11)
        Me.tdbcGroupProductID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcGroupProductID.MaxDropDownItems = CType(8, Short)
        Me.tdbcGroupProductID.MaxLength = 32767
        Me.tdbcGroupProductID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcGroupProductID.Name = "tdbcGroupProductID"
        Me.tdbcGroupProductID.OddRowStyle = Style22
        Me.tdbcGroupProductID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcGroupProductID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcGroupProductID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcGroupProductID.SelectedStyle = Style23
        Me.tdbcGroupProductID.Size = New System.Drawing.Size(200, 23)
        Me.tdbcGroupProductID.Style = Style24
        Me.tdbcGroupProductID.TabIndex = 43
        Me.tdbcGroupProductID.ValueMember = "GroupProductID"
        Me.tdbcGroupProductID.PropBag = resources.GetString("tdbcGroupProductID.PropBag")
        '
        'lblGroupProductID
        '
        Me.lblGroupProductID.AutoSize = True
        Me.lblGroupProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroupProductID.Location = New System.Drawing.Point(6, 16)
        Me.lblGroupProductID.Name = "lblGroupProductID"
        Me.lblGroupProductID.Size = New System.Drawing.Size(84, 13)
        Me.lblGroupProductID.TabIndex = 47
        Me.lblGroupProductID.Text = "Nhóm sản phẩm"
        Me.lblGroupProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tdbg.CellTips = C1.Win.C1TrueDBGrid.CellTipEnum.Floating
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 44)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(997, 567)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 50
        Me.tdbg.Tag = "sCOL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(846, 618)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(76, 22)
        Me.btnChoose.TabIndex = 51
        Me.btnChoose.Text = "Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(927, 618)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 52
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(6, 621)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(188, 17)
        Me.chkIsUsed.TabIndex = 53
        Me.chkIsUsed.Text = "Chỉ hiển thị những dữ liệu đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'D45F2045
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 645)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnFilter)
        Me.Controls.Add(Me.tdbcTaskID)
        Me.Controls.Add(Me.tdbcComponentID)
        Me.Controls.Add(Me.lblTaskID)
        Me.Controls.Add(Me.lblComponentID)
        Me.Controls.Add(Me.tdbcGroupProductID)
        Me.Controls.Add(Me.lblGroupProductID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2045"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn tiÓu tÀc - D45F2045"
        CType(Me.tdbcTaskID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcComponentID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcGroupProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents tdbcTaskID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcComponentID As C1.Win.C1List.C1Combo
    Private WithEvents lblTaskID As System.Windows.Forms.Label
    Private WithEvents lblComponentID As System.Windows.Forms.Label
    Private WithEvents tdbcGroupProductID As C1.Win.C1List.C1Combo
    Private WithEvents lblGroupProductID As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox
End Class