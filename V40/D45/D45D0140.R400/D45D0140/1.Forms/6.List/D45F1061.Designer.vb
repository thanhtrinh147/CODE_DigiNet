<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1061
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1061))
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtPieceworkCalMethodID = New System.Windows.Forms.TextBox
        Me.lblPieceworkCalMethodID = New System.Windows.Forms.Label
        Me.lbDescription = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.grp3 = New System.Windows.Forms.GroupBox
        Me.lblFunctionID = New System.Windows.Forms.Label
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.txtTempFormulaDesc = New System.Windows.Forms.TextBox
        Me.tdbcDecimals = New C1.Win.C1List.C1Combo
        Me.txtTempFormula = New System.Windows.Forms.TextBox
        Me.lblTempFormulaDesc = New System.Windows.Forms.Label
        Me.lblTempFormula = New System.Windows.Forms.Label
        Me.lblDecimals = New System.Windows.Forms.Label
        Me.chkViewAll = New System.Windows.Forms.CheckBox
        Me.chkIsHACoefUP = New System.Windows.Forms.CheckBox
        Me.grp1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp2.SuspendLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDecimals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.chkIsHACoefUP)
        Me.grp1.Controls.Add(Me.chkDisabled)
        Me.grp1.Controls.Add(Me.txtDescription)
        Me.grp1.Controls.Add(Me.txtPieceworkCalMethodID)
        Me.grp1.Controls.Add(Me.lblPieceworkCalMethodID)
        Me.grp1.Controls.Add(Me.lbDescription)
        Me.grp1.Location = New System.Drawing.Point(8, 3)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(1001, 74)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(876, 19)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(137, 44)
        Me.txtDescription.MaxLength = 250
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(856, 22)
        Me.txtDescription.TabIndex = 3
        '
        'txtPieceworkCalMethodID
        '
        Me.txtPieceworkCalMethodID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPieceworkCalMethodID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPieceworkCalMethodID.Location = New System.Drawing.Point(137, 16)
        Me.txtPieceworkCalMethodID.MaxLength = 20
        Me.txtPieceworkCalMethodID.Name = "txtPieceworkCalMethodID"
        Me.txtPieceworkCalMethodID.Size = New System.Drawing.Size(309, 22)
        Me.txtPieceworkCalMethodID.TabIndex = 0
        '
        'lblPieceworkCalMethodID
        '
        Me.lblPieceworkCalMethodID.AutoSize = True
        Me.lblPieceworkCalMethodID.Location = New System.Drawing.Point(27, 21)
        Me.lblPieceworkCalMethodID.Name = "lblPieceworkCalMethodID"
        Me.lblPieceworkCalMethodID.Size = New System.Drawing.Size(25, 13)
        Me.lblPieceworkCalMethodID.TabIndex = 1
        Me.lblPieceworkCalMethodID.Text = "Mã "
        Me.lblPieceworkCalMethodID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbDescription
        '
        Me.lbDescription.AutoSize = True
        Me.lbDescription.Location = New System.Drawing.Point(27, 49)
        Me.lbDescription.Name = "lbDescription"
        Me.lbDescription.Size = New System.Drawing.Size(48, 13)
        Me.lbDescription.TabIndex = 3
        Me.lbDescription.Text = "Diễn giải"
        Me.lbDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tdbg)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 534)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
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
        Me.tdbg.Location = New System.Drawing.Point(6, 14)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(543, 512)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(933, 624)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(851, 624)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(769, 624)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.GroupBox3)
        Me.grp2.Controls.Add(Me.GroupBox2)
        Me.grp2.Controls.Add(Me.grp3)
        Me.grp2.Controls.Add(Me.lblFunctionID)
        Me.grp2.Controls.Add(Me.tdbg1)
        Me.grp2.Controls.Add(Me.txtTempFormulaDesc)
        Me.grp2.Controls.Add(Me.tdbcDecimals)
        Me.grp2.Controls.Add(Me.txtTempFormula)
        Me.grp2.Controls.Add(Me.lblTempFormulaDesc)
        Me.grp2.Controls.Add(Me.lblTempFormula)
        Me.grp2.Controls.Add(Me.lblDecimals)
        Me.grp2.Location = New System.Drawing.Point(573, 84)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(436, 534)
        Me.grp2.TabIndex = 2
        Me.grp2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Location = New System.Drawing.Point(131, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(301, 4)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(138, 157)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(294, 3)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        '
        'grp3
        '
        Me.grp3.Location = New System.Drawing.Point(93, 19)
        Me.grp3.Name = "grp3"
        Me.grp3.Size = New System.Drawing.Size(339, 3)
        Me.grp3.TabIndex = 6
        Me.grp3.TabStop = False
        '
        'lblFunctionID
        '
        Me.lblFunctionID.AutoSize = True
        Me.lblFunctionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFunctionID.Location = New System.Drawing.Point(6, 266)
        Me.lblFunctionID.Name = "lblFunctionID"
        Me.lblFunctionID.Size = New System.Drawing.Size(118, 13)
        Me.lblFunctionID.TabIndex = 5
        Me.lblFunctionID.Text = "Các hàm tính lương"
        Me.lblFunctionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg1
        '
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowUpdate = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.CaptionHeight = 17
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(6, 288)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.RowHeight = 15
        Me.tdbg1.Size = New System.Drawing.Size(424, 239)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 3
        Me.tdbg1.Tag = "COL1"
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        '
        'txtTempFormulaDesc
        '
        Me.txtTempFormulaDesc.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTempFormulaDesc.Location = New System.Drawing.Point(6, 171)
        Me.txtTempFormulaDesc.MaxLength = 2000
        Me.txtTempFormulaDesc.Multiline = True
        Me.txtTempFormulaDesc.Name = "txtTempFormulaDesc"
        Me.txtTempFormulaDesc.Size = New System.Drawing.Size(424, 80)
        Me.txtTempFormulaDesc.TabIndex = 2
        '
        'tdbcDecimals
        '
        Me.tdbcDecimals.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDecimals.AllowColMove = False
        Me.tdbcDecimals.AllowSort = False
        Me.tdbcDecimals.AlternatingRows = True
        Me.tdbcDecimals.AutoCompletion = True
        Me.tdbcDecimals.AutoDropDown = True
        Me.tdbcDecimals.Caption = ""
        Me.tdbcDecimals.CaptionHeight = 17
        Me.tdbcDecimals.CaptionStyle = Style9
        Me.tdbcDecimals.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDecimals.ColumnCaptionHeight = 17
        Me.tdbcDecimals.ColumnFooterHeight = 17
        Me.tdbcDecimals.ColumnHeaders = False
        Me.tdbcDecimals.ColumnWidth = 100
        Me.tdbcDecimals.ContentHeight = 17
        Me.tdbcDecimals.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDecimals.DisplayMember = "Decimals"
        Me.tdbcDecimals.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDecimals.DropDownWidth = 128
        Me.tdbcDecimals.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDecimals.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDecimals.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDecimals.EditorHeight = 17
        Me.tdbcDecimals.EmptyRows = True
        Me.tdbcDecimals.EvenRowStyle = Style10
        Me.tdbcDecimals.ExtendRightColumn = True
        Me.tdbcDecimals.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDecimals.FooterStyle = Style11
        Me.tdbcDecimals.HeadingStyle = Style12
        Me.tdbcDecimals.HighLightRowStyle = Style13
        Me.tdbcDecimals.Images.Add(CType(resources.GetObject("tdbcDecimals.Images"), System.Drawing.Image))
        Me.tdbcDecimals.ItemHeight = 15
        Me.tdbcDecimals.Location = New System.Drawing.Point(302, 122)
        Me.tdbcDecimals.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDecimals.MaxDropDownItems = CType(8, Short)
        Me.tdbcDecimals.MaxLength = 32767
        Me.tdbcDecimals.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDecimals.Name = "tdbcDecimals"
        Me.tdbcDecimals.OddRowStyle = Style14
        Me.tdbcDecimals.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDecimals.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDecimals.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDecimals.SelectedStyle = Style15
        Me.tdbcDecimals.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDecimals.Style = Style16
        Me.tdbcDecimals.TabIndex = 1
        Me.tdbcDecimals.ValueMember = "Decimals"
        Me.tdbcDecimals.PropBag = resources.GetString("tdbcDecimals.PropBag")
        '
        'txtTempFormula
        '
        Me.txtTempFormula.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTempFormula.Location = New System.Drawing.Point(6, 32)
        Me.txtTempFormula.MaxLength = 2000
        Me.txtTempFormula.Multiline = True
        Me.txtTempFormula.Name = "txtTempFormula"
        Me.txtTempFormula.Size = New System.Drawing.Size(424, 80)
        Me.txtTempFormula.TabIndex = 0
        '
        'lblTempFormulaDesc
        '
        Me.lblTempFormulaDesc.AutoSize = True
        Me.lblTempFormulaDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempFormulaDesc.Location = New System.Drawing.Point(6, 151)
        Me.lblTempFormulaDesc.Name = "lblTempFormulaDesc"
        Me.lblTempFormulaDesc.Size = New System.Drawing.Size(118, 13)
        Me.lblTempFormulaDesc.TabIndex = 2
        Me.lblTempFormulaDesc.Text = "Diễn giải công thức"
        Me.lblTempFormulaDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTempFormula
        '
        Me.lblTempFormula.AutoSize = True
        Me.lblTempFormula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTempFormula.Location = New System.Drawing.Point(6, 13)
        Me.lblTempFormula.Name = "lblTempFormula"
        Me.lblTempFormula.Size = New System.Drawing.Size(65, 13)
        Me.lblTempFormula.TabIndex = 1
        Me.lblTempFormula.Text = "Công thức"
        Me.lblTempFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDecimals
        '
        Me.lblDecimals.AutoSize = True
        Me.lblDecimals.Location = New System.Drawing.Point(244, 127)
        Me.lblDecimals.Name = "lblDecimals"
        Me.lblDecimals.Size = New System.Drawing.Size(48, 13)
        Me.lblDecimals.TabIndex = 3
        Me.lblDecimals.Text = "Làm tròn"
        Me.lblDecimals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkViewAll
        '
        Me.chkViewAll.AutoSize = True
        Me.chkViewAll.Location = New System.Drawing.Point(8, 628)
        Me.chkViewAll.Name = "chkViewAll"
        Me.chkViewAll.Size = New System.Drawing.Size(92, 17)
        Me.chkViewAll.TabIndex = 6
        Me.chkViewAll.Text = "Hiển thị tất cả"
        Me.chkViewAll.UseVisualStyleBackColor = True
        '
        'chkIsHACoefUP
        '
        Me.chkIsHACoefUP.AutoSize = True
        Me.chkIsHACoefUP.Location = New System.Drawing.Point(499, 19)
        Me.chkIsHACoefUP.Name = "chkIsHACoefUP"
        Me.chkIsHACoefUP.Size = New System.Drawing.Size(123, 17)
        Me.chkIsHACoefUP.TabIndex = 1
        Me.chkIsHACoefUP.Text = "Theo đơn giá GCHS"
        Me.chkIsHACoefUP.UseVisualStyleBackColor = True
        '
        'D45F1061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.chkViewAll)
        Me.Controls.Add(Me.grp2)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1061"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiÕt ph§¥ng phÀp tÛnh l§¥ng s¶n phÈm - D45F1061"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDecimals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents txtPieceworkCalMethodID As System.Windows.Forms.TextBox
    Private WithEvents lblPieceworkCalMethodID As System.Windows.Forms.Label
    Private WithEvents lbDescription As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grp2 As System.Windows.Forms.GroupBox
    Private WithEvents txtTempFormula As System.Windows.Forms.TextBox
    Private WithEvents lblTempFormula As System.Windows.Forms.Label
    Private WithEvents tdbcDecimals As C1.Win.C1List.C1Combo
    Private WithEvents lblDecimals As System.Windows.Forms.Label
    Private WithEvents txtTempFormulaDesc As System.Windows.Forms.TextBox
    Private WithEvents lblTempFormulaDesc As System.Windows.Forms.Label
    Private WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents grp3 As System.Windows.Forms.GroupBox
    Private WithEvents lblFunctionID As System.Windows.Forms.Label
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents chkViewAll As System.Windows.Forms.CheckBox
    Private WithEvents chkIsHACoefUP As System.Windows.Forms.CheckBox
End Class
