<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1002))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblMinute = New System.Windows.Forms.Label
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblDetail = New System.Windows.Forms.Label
        Me.txtConvertionHours = New System.Windows.Forms.TextBox
        Me.txtCycle = New System.Windows.Forms.TextBox
        Me.tdbcMethodID = New C1.Win.C1List.C1Combo
        Me.lblMethodID = New System.Windows.Forms.Label
        Me.lblCycle = New System.Windows.Forms.Label
        Me.lblConvertionHours = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cboDecimals = New System.Windows.Forms.ComboBox
        Me.tdbdMethod = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblDecimal1 = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcMethodID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tdbdMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblMinute)
        Me.GroupBox1.Controls.Add(Me.tdbg1)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblDetail)
        Me.GroupBox1.Controls.Add(Me.txtConvertionHours)
        Me.GroupBox1.Controls.Add(Me.txtCycle)
        Me.GroupBox1.Controls.Add(Me.tdbcMethodID)
        Me.GroupBox1.Controls.Add(Me.lblMethodID)
        Me.GroupBox1.Controls.Add(Me.lblCycle)
        Me.GroupBox1.Controls.Add(Me.lblConvertionHours)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(622, 217)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Quy đổi từ giờ sang công"
        '
        'lblMinute
        '
        Me.lblMinute.AutoSize = True
        Me.lblMinute.Location = New System.Drawing.Point(382, 27)
        Me.lblMinute.Name = "lblMinute"
        Me.lblMinute.Size = New System.Drawing.Size(28, 13)
        Me.lblMinute.TabIndex = 9
        Me.lblMinute.Text = "phút"
        Me.lblMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg1
        '
        Me.tdbg1.AllowAddNew = True
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowDelete = True
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowSort = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.CaptionHeight = 17
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FetchRowStyles = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(6, 85)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.RowHeight = 15
        Me.tdbg1.Size = New System.Drawing.Size(610, 126)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 8
        Me.tdbg1.Tag = "COL1"
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(62, 61)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(554, 5)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'lblDetail
        '
        Me.lblDetail.AutoSize = True
        Me.lblDetail.Location = New System.Drawing.Point(14, 57)
        Me.lblDetail.Name = "lblDetail"
        Me.lblDetail.Size = New System.Drawing.Size(39, 13)
        Me.lblDetail.TabIndex = 6
        Me.lblDetail.Text = "Chi tiết"
        Me.lblDetail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtConvertionHours
        '
        Me.txtConvertionHours.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtConvertionHours.Location = New System.Drawing.Point(516, 22)
        Me.txtConvertionHours.Name = "txtConvertionHours"
        Me.txtConvertionHours.Size = New System.Drawing.Size(100, 22)
        Me.txtConvertionHours.TabIndex = 4
        Me.txtConvertionHours.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCycle
        '
        Me.txtCycle.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtCycle.Location = New System.Drawing.Point(308, 23)
        Me.txtCycle.Name = "txtCycle"
        Me.txtCycle.Size = New System.Drawing.Size(68, 22)
        Me.txtCycle.TabIndex = 2
        Me.txtCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tdbcMethodID
        '
        Me.tdbcMethodID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcMethodID.AllowColMove = False
        Me.tdbcMethodID.AllowSort = False
        Me.tdbcMethodID.AlternatingRows = True
        Me.tdbcMethodID.AutoCompletion = True
        Me.tdbcMethodID.AutoDropDown = True
        Me.tdbcMethodID.Caption = ""
        Me.tdbcMethodID.CaptionHeight = 17
        Me.tdbcMethodID.CaptionStyle = Style1
        Me.tdbcMethodID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcMethodID.ColumnCaptionHeight = 17
        Me.tdbcMethodID.ColumnFooterHeight = 17
        Me.tdbcMethodID.ColumnWidth = 100
        Me.tdbcMethodID.ContentHeight = 17
        Me.tdbcMethodID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcMethodID.DisplayMember = "MethodName"
        Me.tdbcMethodID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcMethodID.DropDownWidth = 300
        Me.tdbcMethodID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcMethodID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcMethodID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcMethodID.EditorHeight = 17
        Me.tdbcMethodID.EmptyRows = True
        Me.tdbcMethodID.EvenRowStyle = Style2
        Me.tdbcMethodID.ExtendRightColumn = True
        Me.tdbcMethodID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcMethodID.FooterStyle = Style3
        Me.tdbcMethodID.HeadingStyle = Style4
        Me.tdbcMethodID.HighLightRowStyle = Style5
        Me.tdbcMethodID.Images.Add(CType(resources.GetObject("tdbcMethodID.Images"), System.Drawing.Image))
        Me.tdbcMethodID.ItemHeight = 15
        Me.tdbcMethodID.Location = New System.Drawing.Point(133, 21)
        Me.tdbcMethodID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcMethodID.MaxDropDownItems = CType(8, Short)
        Me.tdbcMethodID.MaxLength = 32767
        Me.tdbcMethodID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcMethodID.Name = "tdbcMethodID"
        Me.tdbcMethodID.OddRowStyle = Style6
        Me.tdbcMethodID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcMethodID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcMethodID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcMethodID.SelectedStyle = Style7
        Me.tdbcMethodID.Size = New System.Drawing.Size(100, 23)
        Me.tdbcMethodID.Style = Style8
        Me.tdbcMethodID.TabIndex = 0
        Me.tdbcMethodID.ValueMember = "MethodID"
        Me.tdbcMethodID.PropBag = resources.GetString("tdbcMethodID.PropBag")
        '
        'lblMethodID
        '
        Me.lblMethodID.AutoSize = True
        Me.lblMethodID.Location = New System.Drawing.Point(14, 26)
        Me.lblMethodID.Name = "lblMethodID"
        Me.lblMethodID.Size = New System.Drawing.Size(109, 13)
        Me.lblMethodID.TabIndex = 1
        Me.lblMethodID.Text = "Phương pháp quy đổi"
        Me.lblMethodID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCycle
        '
        Me.lblCycle.AutoSize = True
        Me.lblCycle.Location = New System.Drawing.Point(262, 27)
        Me.lblCycle.Name = "lblCycle"
        Me.lblCycle.Size = New System.Drawing.Size(40, 13)
        Me.lblCycle.TabIndex = 3
        Me.lblCycle.Text = "Chu kỳ"
        Me.lblCycle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConvertionHours
        '
        Me.lblConvertionHours.AutoSize = True
        Me.lblConvertionHours.Location = New System.Drawing.Point(431, 27)
        Me.lblConvertionHours.Name = "lblConvertionHours"
        Me.lblConvertionHours.Size = New System.Drawing.Size(75, 13)
        Me.lblConvertionHours.TabIndex = 5
        Me.lblConvertionHours.Text = "Số giờ quy đổi"
        Me.lblConvertionHours.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboDecimals)
        Me.GroupBox3.Controls.Add(Me.tdbdMethod)
        Me.GroupBox3.Controls.Add(Me.tdbg2)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.lblDecimal1)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 230)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(622, 215)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Quy đổi công"
        '
        'cboDecimals
        '
        Me.cboDecimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDecimals.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboDecimals.FormattingEnabled = True
        Me.cboDecimals.Items.AddRange(New Object() {"-3", "-2", "-1", "0", "1", "2", "3"})
        Me.cboDecimals.Location = New System.Drawing.Point(133, 21)
        Me.cboDecimals.Name = "cboDecimals"
        Me.cboDecimals.Size = New System.Drawing.Size(100, 22)
        Me.cboDecimals.TabIndex = 0
        '
        'tdbdMethod
        '
        Me.tdbdMethod.AllowColMove = False
        Me.tdbdMethod.AllowColSelect = False
        Me.tdbdMethod.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdMethod.AllowSort = False
        Me.tdbdMethod.AlternatingRows = True
        Me.tdbdMethod.CaptionHeight = 17
        Me.tdbdMethod.CaptionStyle = Style9
        Me.tdbdMethod.ColumnCaptionHeight = 17
        Me.tdbdMethod.ColumnFooterHeight = 17
        Me.tdbdMethod.DisplayMember = "MethodName"
        Me.tdbdMethod.EmptyRows = True
        Me.tdbdMethod.EvenRowStyle = Style10
        Me.tdbdMethod.ExtendRightColumn = True
        Me.tdbdMethod.FetchRowStyles = False
        Me.tdbdMethod.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdMethod.FooterStyle = Style11
        Me.tdbdMethod.HeadingStyle = Style12
        Me.tdbdMethod.HighLightRowStyle = Style13
        Me.tdbdMethod.Images.Add(CType(resources.GetObject("tdbdMethod.Images"), System.Drawing.Image))
        Me.tdbdMethod.Location = New System.Drawing.Point(406, 133)
        Me.tdbdMethod.Name = "tdbdMethod"
        Me.tdbdMethod.OddRowStyle = Style14
        Me.tdbdMethod.RecordSelectorStyle = Style15
        Me.tdbdMethod.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdMethod.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdMethod.RowHeight = 15
        Me.tdbdMethod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdMethod.ScrollTips = False
        Me.tdbdMethod.Size = New System.Drawing.Size(300, 147)
        Me.tdbdMethod.Style = Style16
        Me.tdbdMethod.TabIndex = 10
        Me.tdbdMethod.TabStop = False
        Me.tdbdMethod.ValueMember = "MethodName"
        Me.tdbdMethod.Visible = False
        Me.tdbdMethod.PropBag = resources.GetString("tdbdMethod.PropBag")
        '
        'tdbg2
        '
        Me.tdbg2.AllowAddNew = True
        Me.tdbg2.AllowColMove = False
        Me.tdbg2.AllowColSelect = False
        Me.tdbg2.AllowDelete = True
        Me.tdbg2.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg2.AllowSort = False
        Me.tdbg2.AlternatingRows = True
        Me.tdbg2.CaptionHeight = 17
        Me.tdbg2.EmptyRows = True
        Me.tdbg2.ExtendRightColumn = True
        Me.tdbg2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg2.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg2.Images.Add(CType(resources.GetObject("tdbg2.Images"), System.Drawing.Image))
        Me.tdbg2.Location = New System.Drawing.Point(6, 84)
        Me.tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg2.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg2.Name = "tdbg2"
        Me.tdbg2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg2.PreviewInfo.ZoomFactor = 75
        Me.tdbg2.PrintInfo.PageSettings = CType(resources.GetObject("tdbg2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg2.RowHeight = 15
        Me.tdbg2.Size = New System.Drawing.Size(610, 125)
        Me.tdbg2.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg2.TabAcrossSplits = True
        Me.tdbg2.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg2.TabIndex = 9
        Me.tdbg2.Tag = "COL2"
        Me.tdbg2.PropBag = resources.GetString("tdbg2.PropBag")
        '
        'GroupBox4
        '
        Me.GroupBox4.Location = New System.Drawing.Point(62, 61)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(554, 5)
        Me.GroupBox4.TabIndex = 8
        Me.GroupBox4.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Chi tiết"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDecimal1
        '
        Me.lblDecimal1.AutoSize = True
        Me.lblDecimal1.Location = New System.Drawing.Point(14, 25)
        Me.lblDecimal1.Name = "lblDecimal1"
        Me.lblDecimal1.Size = New System.Drawing.Size(48, 13)
        Me.lblDecimal1.TabIndex = 1
        Me.lblDecimal1.Text = "Làm tròn"
        Me.lblDecimal1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(478, 451)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(560, 451)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D13F1002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(648, 486)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1002"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Quy ¢åi c¤ng tô mÀy chÊm c¤ng - D13F1002"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcMethodID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tdbdMethod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcMethodID As C1.Win.C1List.C1Combo
    Private WithEvents lblMethodID As System.Windows.Forms.Label
    Private WithEvents txtConvertionHours As System.Windows.Forms.TextBox
    Private WithEvents txtCycle As System.Windows.Forms.TextBox
    Private WithEvents lblCycle As System.Windows.Forms.Label
    Private WithEvents lblConvertionHours As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lblDetail As System.Windows.Forms.Label
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents tdbg2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents lblDecimal1 As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbdMethod As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents cboDecimals As System.Windows.Forms.ComboBox
    Private WithEvents lblMinute As System.Windows.Forms.Label
End Class
