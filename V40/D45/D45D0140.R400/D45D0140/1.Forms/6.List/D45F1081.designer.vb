<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1081
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
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1081))
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style33 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style34 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style35 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style36 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style37 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style38 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style39 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style40 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style41 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style42 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style43 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style44 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style45 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style46 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style47 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style48 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink
        Me.tdbcProductID = New C1.Win.C1List.C1Combo
        Me.lblProductID = New System.Windows.Forms.Label
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.txtRoutingNum = New System.Windows.Forms.TextBox
        Me.lblRoutingNum = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtRoutingDesc = New System.Windows.Forms.TextBox
        Me.lblRoutingDesc = New System.Windows.Forms.Label
        Me.tdbcSRoutingID = New C1.Win.C1List.C1Combo
        Me.lblSRoutingID = New System.Windows.Forms.Label
        Me.txtSRoutingName = New System.Windows.Forms.TextBox
        Me.btnReSetGrid = New System.Windows.Forms.Button
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.tdbdStageID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        CType(Me.tdbcProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcSRoutingID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdStageID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Delimiter = True
        Me.C1CommandLink2.SortOrder = 6
        '
        'tdbcProductID
        '
        Me.tdbcProductID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcProductID.AllowColMove = False
        Me.tdbcProductID.AllowSort = False
        Me.tdbcProductID.AlternatingRows = True
        Me.tdbcProductID.AutoCompletion = True
        Me.tdbcProductID.AutoDropDown = True
        Me.tdbcProductID.Caption = ""
        Me.tdbcProductID.CaptionHeight = 17
        Me.tdbcProductID.CaptionStyle = Style25
        Me.tdbcProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcProductID.ColumnCaptionHeight = 17
        Me.tdbcProductID.ColumnFooterHeight = 17
        Me.tdbcProductID.ColumnWidth = 100
        Me.tdbcProductID.ContentHeight = 17
        Me.tdbcProductID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcProductID.DisplayMember = "ProductID"
        Me.tdbcProductID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcProductID.DropDownWidth = 350
        Me.tdbcProductID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcProductID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcProductID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcProductID.EditorHeight = 17
        Me.tdbcProductID.EmptyRows = True
        Me.tdbcProductID.EvenRowStyle = Style26
        Me.tdbcProductID.ExtendRightColumn = True
        Me.tdbcProductID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcProductID.FooterStyle = Style27
        Me.tdbcProductID.HeadingStyle = Style28
        Me.tdbcProductID.HighLightRowStyle = Style29
        Me.tdbcProductID.Images.Add(CType(resources.GetObject("tdbcProductID.Images"), System.Drawing.Image))
        Me.tdbcProductID.ItemHeight = 15
        Me.tdbcProductID.Location = New System.Drawing.Point(96, 10)
        Me.tdbcProductID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcProductID.MaxDropDownItems = CType(8, Short)
        Me.tdbcProductID.MaxLength = 32767
        Me.tdbcProductID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcProductID.Name = "tdbcProductID"
        Me.tdbcProductID.OddRowStyle = Style30
        Me.tdbcProductID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcProductID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcProductID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcProductID.SelectedStyle = Style31
        Me.tdbcProductID.Size = New System.Drawing.Size(140, 23)
        Me.tdbcProductID.Style = Style32
        Me.tdbcProductID.TabIndex = 0
        Me.tdbcProductID.ValueMember = "ProductID"
        Me.tdbcProductID.PropBag = resources.GetString("tdbcProductID.PropBag")
        '
        'lblProductID
        '
        Me.lblProductID.AutoSize = True
        Me.lblProductID.Location = New System.Drawing.Point(8, 17)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(55, 13)
        Me.lblProductID.TabIndex = 1
        Me.lblProductID.Text = "Sản phẩm"
        Me.lblProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductName
        '
        Me.txtProductName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtProductName.Location = New System.Drawing.Point(242, 11)
        Me.txtProductName.MaxLength = 250
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(355, 22)
        Me.txtProductName.TabIndex = 2
        '
        'txtRoutingNum
        '
        Me.txtRoutingNum.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRoutingNum.Location = New System.Drawing.Point(96, 40)
        Me.txtRoutingNum.MaxLength = 20
        Me.txtRoutingNum.Name = "txtRoutingNum"
        Me.txtRoutingNum.Size = New System.Drawing.Size(140, 22)
        Me.txtRoutingNum.TabIndex = 3
        '
        'lblRoutingNum
        '
        Me.lblRoutingNum.AutoSize = True
        Me.lblRoutingNum.Location = New System.Drawing.Point(8, 45)
        Me.lblRoutingNum.Name = "lblRoutingNum"
        Me.lblRoutingNum.Size = New System.Drawing.Size(65, 13)
        Me.lblRoutingNum.TabIndex = 4
        Me.lblRoutingNum.Text = "Mã quy trình"
        Me.lblRoutingNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(242, 44)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 5
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtRoutingDesc
        '
        Me.txtRoutingDesc.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRoutingDesc.Location = New System.Drawing.Point(96, 69)
        Me.txtRoutingDesc.MaxLength = 250
        Me.txtRoutingDesc.Name = "txtRoutingDesc"
        Me.txtRoutingDesc.Size = New System.Drawing.Size(501, 22)
        Me.txtRoutingDesc.TabIndex = 6
        '
        'lblRoutingDesc
        '
        Me.lblRoutingDesc.AutoSize = True
        Me.lblRoutingDesc.Location = New System.Drawing.Point(8, 74)
        Me.lblRoutingDesc.Name = "lblRoutingDesc"
        Me.lblRoutingDesc.Size = New System.Drawing.Size(69, 13)
        Me.lblRoutingDesc.TabIndex = 7
        Me.lblRoutingDesc.Text = "Tên quy trình"
        Me.lblRoutingDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcSRoutingID
        '
        Me.tdbcSRoutingID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcSRoutingID.AllowColMove = False
        Me.tdbcSRoutingID.AllowSort = False
        Me.tdbcSRoutingID.AlternatingRows = True
        Me.tdbcSRoutingID.AutoCompletion = True
        Me.tdbcSRoutingID.AutoDropDown = True
        Me.tdbcSRoutingID.Caption = ""
        Me.tdbcSRoutingID.CaptionHeight = 17
        Me.tdbcSRoutingID.CaptionStyle = Style33
        Me.tdbcSRoutingID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcSRoutingID.ColumnCaptionHeight = 17
        Me.tdbcSRoutingID.ColumnFooterHeight = 17
        Me.tdbcSRoutingID.ColumnWidth = 100
        Me.tdbcSRoutingID.ContentHeight = 17
        Me.tdbcSRoutingID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcSRoutingID.DisplayMember = "SRoutingID"
        Me.tdbcSRoutingID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcSRoutingID.DropDownWidth = 350
        Me.tdbcSRoutingID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcSRoutingID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcSRoutingID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcSRoutingID.EditorHeight = 17
        Me.tdbcSRoutingID.EmptyRows = True
        Me.tdbcSRoutingID.EvenRowStyle = Style34
        Me.tdbcSRoutingID.ExtendRightColumn = True
        Me.tdbcSRoutingID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcSRoutingID.FooterStyle = Style35
        Me.tdbcSRoutingID.HeadingStyle = Style36
        Me.tdbcSRoutingID.HighLightRowStyle = Style37
        Me.tdbcSRoutingID.Images.Add(CType(resources.GetObject("tdbcSRoutingID.Images"), System.Drawing.Image))
        Me.tdbcSRoutingID.ItemHeight = 15
        Me.tdbcSRoutingID.Location = New System.Drawing.Point(96, 98)
        Me.tdbcSRoutingID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcSRoutingID.MaxDropDownItems = CType(8, Short)
        Me.tdbcSRoutingID.MaxLength = 32767
        Me.tdbcSRoutingID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcSRoutingID.Name = "tdbcSRoutingID"
        Me.tdbcSRoutingID.OddRowStyle = Style38
        Me.tdbcSRoutingID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcSRoutingID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcSRoutingID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcSRoutingID.SelectedStyle = Style39
        Me.tdbcSRoutingID.Size = New System.Drawing.Size(140, 23)
        Me.tdbcSRoutingID.Style = Style40
        Me.tdbcSRoutingID.TabIndex = 8
        Me.tdbcSRoutingID.ValueMember = "SRoutingID"
        Me.tdbcSRoutingID.PropBag = resources.GetString("tdbcSRoutingID.PropBag")
        '
        'lblSRoutingID
        '
        Me.lblSRoutingID.AutoSize = True
        Me.lblSRoutingID.Location = New System.Drawing.Point(8, 103)
        Me.lblSRoutingID.Name = "lblSRoutingID"
        Me.lblSRoutingID.Size = New System.Drawing.Size(82, 13)
        Me.lblSRoutingID.TabIndex = 9
        Me.lblSRoutingID.Text = "Quy trình chuẩn"
        Me.lblSRoutingID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSRoutingName
        '
        Me.txtSRoutingName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSRoutingName.Location = New System.Drawing.Point(242, 100)
        Me.txtSRoutingName.MaxLength = 250
        Me.txtSRoutingName.Name = "txtSRoutingName"
        Me.txtSRoutingName.Size = New System.Drawing.Size(318, 22)
        Me.txtSRoutingName.TabIndex = 10
        '
        'btnReSetGrid
        '
        Me.btnReSetGrid.Location = New System.Drawing.Point(566, 100)
        Me.btnReSetGrid.Name = "btnReSetGrid"
        Me.btnReSetGrid.Size = New System.Drawing.Size(31, 22)
        Me.btnReSetGrid.TabIndex = 11
        Me.btnReSetGrid.Text = "..."
        Me.btnReSetGrid.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(11, 136)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RecordSelectors = False
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(586, 290)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 12
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(521, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(357, 432)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Text = "&Lưu"
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(439, 432)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 15
        Me.btnNext.Text = "Nhập &tiếp"
        '
        'tdbdStageID
        '
        Me.tdbdStageID.AllowColMove = False
        Me.tdbdStageID.AllowColSelect = False
        Me.tdbdStageID.AllowDrop = True
        Me.tdbdStageID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdStageID.AllowSort = False
        Me.tdbdStageID.AlternatingRows = True
        Me.tdbdStageID.CaptionHeight = 17
        Me.tdbdStageID.CaptionStyle = Style41
        Me.tdbdStageID.ColumnCaptionHeight = 17
        Me.tdbdStageID.ColumnFooterHeight = 17
        Me.tdbdStageID.DisplayMember = "StageID"
        Me.tdbdStageID.EmptyRows = True
        Me.tdbdStageID.EvenRowStyle = Style42
        Me.tdbdStageID.ExtendRightColumn = True
        Me.tdbdStageID.FetchRowStyles = False
        Me.tdbdStageID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdStageID.FooterStyle = Style43
        Me.tdbdStageID.HeadingStyle = Style44
        Me.tdbdStageID.HighLightRowStyle = Style45
        Me.tdbdStageID.Images.Add(CType(resources.GetObject("tdbdStageID.Images"), System.Drawing.Image))
        Me.tdbdStageID.Location = New System.Drawing.Point(96, 176)
        Me.tdbdStageID.Name = "tdbdStageID"
        Me.tdbdStageID.OddRowStyle = Style46
        Me.tdbdStageID.RecordSelectorStyle = Style47
        Me.tdbdStageID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdStageID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdStageID.RowHeight = 15
        Me.tdbdStageID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdStageID.ScrollTips = False
        Me.tdbdStageID.Size = New System.Drawing.Size(350, 147)
        Me.tdbdStageID.Style = Style48
        Me.tdbdStageID.TabIndex = 16
        Me.tdbdStageID.TabStop = False
        Me.tdbdStageID.ValueMember = "StageID"
        Me.tdbdStageID.Visible = False
        Me.tdbdStageID.PropBag = resources.GetString("tdbdStageID.PropBag")
        '
        'D45F1081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(609, 460)
        Me.Controls.Add(Me.tdbdStageID)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnReSetGrid)
        Me.Controls.Add(Me.txtSRoutingName)
        Me.Controls.Add(Me.tdbcSRoutingID)
        Me.Controls.Add(Me.txtRoutingDesc)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtRoutingNum)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.tdbcProductID)
        Me.Controls.Add(Me.lblProductID)
        Me.Controls.Add(Me.lblRoutingNum)
        Me.Controls.Add(Me.lblRoutingDesc)
        Me.Controls.Add(Me.lblSRoutingID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1081"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt quy trØnh s¶n xuÊt s¶n phÈm - D45F1081"
        CType(Me.tdbcProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcSRoutingID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdStageID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Private WithEvents tdbcProductID As C1.Win.C1List.C1Combo
    Private WithEvents lblProductID As System.Windows.Forms.Label
    Private WithEvents txtProductName As System.Windows.Forms.TextBox
    Private WithEvents txtRoutingNum As System.Windows.Forms.TextBox
    Private WithEvents lblRoutingNum As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtRoutingDesc As System.Windows.Forms.TextBox
    Private WithEvents lblRoutingDesc As System.Windows.Forms.Label
    Private WithEvents tdbcSRoutingID As C1.Win.C1List.C1Combo
    Private WithEvents lblSRoutingID As System.Windows.Forms.Label
    Private WithEvents txtSRoutingName As System.Windows.Forms.TextBox
    Private WithEvents btnReSetGrid As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents tdbdStageID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class
