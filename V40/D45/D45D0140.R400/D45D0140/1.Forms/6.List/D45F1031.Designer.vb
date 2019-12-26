<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1031
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1031))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.txtSRoutingID = New System.Windows.Forms.TextBox
        Me.lblSRoutingID = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtSRoutingName = New System.Windows.Forms.TextBox
        Me.lblSRoutingName = New System.Windows.Forms.Label
        Me.c1datePreparedDate = New C1.Win.C1Input.C1DateEdit
        Me.lbltePreparedDate = New System.Windows.Forms.Label
        Me.tdbcPreparerID = New C1.Win.C1List.C1Combo
        Me.lblPreparerID = New System.Windows.Forms.Label
        Me.txtPreparerName = New System.Windows.Forms.TextBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.lblStage = New System.Windows.Forms.Label
        Me.grpStage = New System.Windows.Forms.GroupBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tdbdStageID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.c1datePreparedDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPreparerID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdStageID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtSRoutingID
        '
        Me.txtSRoutingID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtSRoutingID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSRoutingID.Location = New System.Drawing.Point(135, 12)
        Me.txtSRoutingID.MaxLength = 20
        Me.txtSRoutingID.Name = "txtSRoutingID"
        Me.txtSRoutingID.Size = New System.Drawing.Size(128, 22)
        Me.txtSRoutingID.TabIndex = 0
        '
        'lblSRoutingID
        '
        Me.lblSRoutingID.AutoSize = True
        Me.lblSRoutingID.Location = New System.Drawing.Point(47, 17)
        Me.lblSRoutingID.Name = "lblSRoutingID"
        Me.lblSRoutingID.Size = New System.Drawing.Size(22, 13)
        Me.lblSRoutingID.TabIndex = 1
        Me.lblSRoutingID.Text = "Mã"
        Me.lblSRoutingID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(429, 15)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtSRoutingName
        '
        Me.txtSRoutingName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSRoutingName.Location = New System.Drawing.Point(135, 42)
        Me.txtSRoutingName.MaxLength = 150
        Me.txtSRoutingName.Name = "txtSRoutingName"
        Me.txtSRoutingName.Size = New System.Drawing.Size(392, 22)
        Me.txtSRoutingName.TabIndex = 3
        '
        'lblSRoutingName
        '
        Me.lblSRoutingName.AutoSize = True
        Me.lblSRoutingName.Location = New System.Drawing.Point(47, 46)
        Me.lblSRoutingName.Name = "lblSRoutingName"
        Me.lblSRoutingName.Size = New System.Drawing.Size(48, 13)
        Me.lblSRoutingName.TabIndex = 4
        Me.lblSRoutingName.Text = "Diễn giải"
        Me.lblSRoutingName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1datePreparedDate
        '
        Me.c1datePreparedDate.AutoSize = False
        Me.c1datePreparedDate.CustomFormat = "dd/MM/yyyy"
        Me.c1datePreparedDate.EmptyAsNull = True
        Me.c1datePreparedDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1datePreparedDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1datePreparedDate.Location = New System.Drawing.Point(135, 72)
        Me.c1datePreparedDate.Name = "c1datePreparedDate"
        Me.c1datePreparedDate.Size = New System.Drawing.Size(128, 22)
        Me.c1datePreparedDate.TabIndex = 5
        Me.c1datePreparedDate.Tag = Nothing
        Me.c1datePreparedDate.TrimStart = True
        Me.c1datePreparedDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lbltePreparedDate
        '
        Me.lbltePreparedDate.AutoSize = True
        Me.lbltePreparedDate.Location = New System.Drawing.Point(47, 77)
        Me.lbltePreparedDate.Name = "lbltePreparedDate"
        Me.lbltePreparedDate.Size = New System.Drawing.Size(49, 13)
        Me.lbltePreparedDate.TabIndex = 6
        Me.lbltePreparedDate.Text = "Ngày lập"
        Me.lbltePreparedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcPreparerID
        '
        Me.tdbcPreparerID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPreparerID.AllowColMove = False
        Me.tdbcPreparerID.AllowSort = False
        Me.tdbcPreparerID.AlternatingRows = True
        Me.tdbcPreparerID.AutoCompletion = True
        Me.tdbcPreparerID.AutoDropDown = True
        Me.tdbcPreparerID.Caption = ""
        Me.tdbcPreparerID.CaptionHeight = 17
        Me.tdbcPreparerID.CaptionStyle = Style1
        Me.tdbcPreparerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPreparerID.ColumnCaptionHeight = 17
        Me.tdbcPreparerID.ColumnFooterHeight = 17
        Me.tdbcPreparerID.ColumnWidth = 100
        Me.tdbcPreparerID.ContentHeight = 17
        Me.tdbcPreparerID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPreparerID.DisplayMember = "EmployeeID"
        Me.tdbcPreparerID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPreparerID.DropDownWidth = 300
        Me.tdbcPreparerID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPreparerID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPreparerID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPreparerID.EditorHeight = 17
        Me.tdbcPreparerID.EmptyRows = True
        Me.tdbcPreparerID.EvenRowStyle = Style2
        Me.tdbcPreparerID.ExtendRightColumn = True
        Me.tdbcPreparerID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPreparerID.FooterStyle = Style3
        Me.tdbcPreparerID.HeadingStyle = Style4
        Me.tdbcPreparerID.HighLightRowStyle = Style5
        Me.tdbcPreparerID.Images.Add(CType(resources.GetObject("tdbcPreparerID.Images"), System.Drawing.Image))
        Me.tdbcPreparerID.ItemHeight = 15
        Me.tdbcPreparerID.Location = New System.Drawing.Point(135, 103)
        Me.tdbcPreparerID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPreparerID.MaxDropDownItems = CType(8, Short)
        Me.tdbcPreparerID.MaxLength = 32767
        Me.tdbcPreparerID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPreparerID.Name = "tdbcPreparerID"
        Me.tdbcPreparerID.OddRowStyle = Style6
        Me.tdbcPreparerID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPreparerID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPreparerID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPreparerID.SelectedStyle = Style7
        Me.tdbcPreparerID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcPreparerID.Style = Style8
        Me.tdbcPreparerID.TabIndex = 7
        Me.tdbcPreparerID.ValueMember = "EmployeeID"
        Me.tdbcPreparerID.PropBag = resources.GetString("tdbcPreparerID.PropBag")
        '
        'lblPreparerID
        '
        Me.lblPreparerID.AutoSize = True
        Me.lblPreparerID.Location = New System.Drawing.Point(47, 108)
        Me.lblPreparerID.Name = "lblPreparerID"
        Me.lblPreparerID.Size = New System.Drawing.Size(52, 13)
        Me.lblPreparerID.TabIndex = 8
        Me.lblPreparerID.Text = "Người lập"
        Me.lblPreparerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPreparerName
        '
        Me.txtPreparerName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtPreparerName.Location = New System.Drawing.Point(269, 103)
        Me.txtPreparerName.Name = "txtPreparerName"
        Me.txtPreparerName.ReadOnly = True
        Me.txtPreparerName.Size = New System.Drawing.Size(258, 22)
        Me.txtPreparerName.TabIndex = 9
        Me.txtPreparerName.TabStop = False
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(135, 133)
        Me.txtNote.MaxLength = 150
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(392, 22)
        Me.txtNote.TabIndex = 10
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(47, 137)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 11
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStage
        '
        Me.lblStage.AutoSize = True
        Me.lblStage.Location = New System.Drawing.Point(19, 168)
        Me.lblStage.Name = "lblStage"
        Me.lblStage.Size = New System.Drawing.Size(60, 13)
        Me.lblStage.TabIndex = 12
        Me.lblStage.Text = "Công đoạn"
        Me.lblStage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpStage
        '
        Me.grpStage.Location = New System.Drawing.Point(99, 174)
        Me.grpStage.Name = "grpStage"
        Me.grpStage.Size = New System.Drawing.Size(451, 3)
        Me.grpStage.TabIndex = 13
        Me.grpStage.TabStop = False
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
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(22, 195)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(505, 163)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 14
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'tdbdStageID
        '
        Me.tdbdStageID.AllowColMove = False
        Me.tdbdStageID.AllowColSelect = False
        Me.tdbdStageID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdStageID.AllowSort = False
        Me.tdbdStageID.AlternatingRows = True
        Me.tdbdStageID.CaptionHeight = 17
        Me.tdbdStageID.CaptionStyle = Style9
        Me.tdbdStageID.ColumnCaptionHeight = 17
        Me.tdbdStageID.ColumnFooterHeight = 17
        Me.tdbdStageID.DisplayMember = "StageID"
        Me.tdbdStageID.EmptyRows = True
        Me.tdbdStageID.EvenRowStyle = Style10
        Me.tdbdStageID.ExtendRightColumn = True
        Me.tdbdStageID.FetchRowStyles = False
        Me.tdbdStageID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdStageID.FooterStyle = Style11
        Me.tdbdStageID.HeadingStyle = Style12
        Me.tdbdStageID.HighLightRowStyle = Style13
        Me.tdbdStageID.Images.Add(CType(resources.GetObject("tdbdStageID.Images"), System.Drawing.Image))
        Me.tdbdStageID.Location = New System.Drawing.Point(181, 222)
        Me.tdbdStageID.Name = "tdbdStageID"
        Me.tdbdStageID.OddRowStyle = Style14
        Me.tdbdStageID.RecordSelectorStyle = Style15
        Me.tdbdStageID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdStageID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdStageID.RowHeight = 15
        Me.tdbdStageID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdStageID.ScrollTips = False
        Me.tdbdStageID.Size = New System.Drawing.Size(300, 147)
        Me.tdbdStageID.Style = Style16
        Me.tdbdStageID.TabIndex = 15
        Me.tdbdStageID.TabStop = False
        Me.tdbdStageID.ValueMember = "StageID"
        Me.tdbdStageID.Visible = False
        Me.tdbdStageID.PropBag = resources.GetString("tdbdStageID.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(287, 371)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(369, 371)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 17
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(451, 371)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D45F1031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 404)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbdStageID)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.grpStage)
        Me.Controls.Add(Me.lblStage)
        Me.Controls.Add(Me.txtNote)
        Me.Controls.Add(Me.tdbcPreparerID)
        Me.Controls.Add(Me.c1datePreparedDate)
        Me.Controls.Add(Me.txtSRoutingName)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtSRoutingID)
        Me.Controls.Add(Me.lblSRoutingID)
        Me.Controls.Add(Me.lblSRoutingName)
        Me.Controls.Add(Me.lbltePreparedDate)
        Me.Controls.Add(Me.lblPreparerID)
        Me.Controls.Add(Me.txtPreparerName)
        Me.Controls.Add(Me.lblNote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1031"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt quy trØnh s¶n xuÊt chuÈn - D45F1031"
        CType(Me.c1datePreparedDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPreparerID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdStageID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtSRoutingID As System.Windows.Forms.TextBox
    Private WithEvents lblSRoutingID As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtSRoutingName As System.Windows.Forms.TextBox
    Private WithEvents lblSRoutingName As System.Windows.Forms.Label
    Private WithEvents c1datePreparedDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lbltePreparedDate As System.Windows.Forms.Label
    Private WithEvents tdbcPreparerID As C1.Win.C1List.C1Combo
    Private WithEvents lblPreparerID As System.Windows.Forms.Label
    Private WithEvents txtPreparerName As System.Windows.Forms.TextBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents lblStage As System.Windows.Forms.Label
    Private WithEvents grpStage As System.Windows.Forms.GroupBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdStageID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
