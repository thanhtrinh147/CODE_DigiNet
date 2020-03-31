<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1041
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1041))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tdbcDutyID = New C1.Win.C1List.C1Combo
        Me.optUseOfficialAll = New System.Windows.Forms.RadioButton
        Me.optUseOfficial2 = New System.Windows.Forms.RadioButton
        Me.optUseOfficial1 = New System.Windows.Forms.RadioButton
        Me.txtNumSalaryLevel = New System.Windows.Forms.TextBox
        Me.txtOfficialTitleName = New System.Windows.Forms.TextBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtOfficialTitleID = New System.Windows.Forms.TextBox
        Me.lblOfficialTitleID = New System.Windows.Forms.Label
        Me.lblOfficialTitleName = New System.Windows.Forms.Label
        Me.lblNumSalaryLevel = New System.Windows.Forms.Label
        Me.lblDutyID = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbcDutyID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.tdbcDutyID)
        Me.GroupBox1.Controls.Add(Me.optUseOfficialAll)
        Me.GroupBox1.Controls.Add(Me.optUseOfficial2)
        Me.GroupBox1.Controls.Add(Me.optUseOfficial1)
        Me.GroupBox1.Controls.Add(Me.txtNumSalaryLevel)
        Me.GroupBox1.Controls.Add(Me.txtOfficialTitleName)
        Me.GroupBox1.Controls.Add(Me.chkDisabled)
        Me.GroupBox1.Controls.Add(Me.txtOfficialTitleID)
        Me.GroupBox1.Controls.Add(Me.lblOfficialTitleID)
        Me.GroupBox1.Controls.Add(Me.lblOfficialTitleName)
        Me.GroupBox1.Controls.Add(Me.lblNumSalaryLevel)
        Me.GroupBox1.Controls.Add(Me.lblDutyID)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 171)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(13, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(531, 7)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        '
        'tdbcDutyID
        '
        Me.tdbcDutyID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDutyID.AllowColMove = False
        Me.tdbcDutyID.AllowSort = False
        Me.tdbcDutyID.AlternatingRows = True
        Me.tdbcDutyID.AutoDropDown = True
        Me.tdbcDutyID.Caption = ""
        Me.tdbcDutyID.CaptionHeight = 17
        Me.tdbcDutyID.CaptionStyle = Style1
        Me.tdbcDutyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDutyID.ColumnCaptionHeight = 17
        Me.tdbcDutyID.ColumnFooterHeight = 17
        Me.tdbcDutyID.ColumnWidth = 100
        Me.tdbcDutyID.ContentHeight = 17
        Me.tdbcDutyID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDutyID.DisplayMember = "DutyName"
        Me.tdbcDutyID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDutyID.DropDownWidth = 350
        Me.tdbcDutyID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDutyID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDutyID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDutyID.EditorHeight = 17
        Me.tdbcDutyID.EmptyRows = True
        Me.tdbcDutyID.EvenRowStyle = Style2
        Me.tdbcDutyID.ExtendRightColumn = True
        Me.tdbcDutyID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDutyID.FooterStyle = Style3
        Me.tdbcDutyID.HeadingStyle = Style4
        Me.tdbcDutyID.HighLightRowStyle = Style5
        Me.tdbcDutyID.Images.Add(CType(resources.GetObject("tdbcDutyID.Images"), System.Drawing.Image))
        Me.tdbcDutyID.ItemHeight = 15
        Me.tdbcDutyID.Location = New System.Drawing.Point(117, 107)
        Me.tdbcDutyID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDutyID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDutyID.MaxLength = 32767
        Me.tdbcDutyID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDutyID.Name = "tdbcDutyID"
        Me.tdbcDutyID.OddRowStyle = Style6
        Me.tdbcDutyID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDutyID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDutyID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDutyID.SelectedStyle = Style7
        Me.tdbcDutyID.Size = New System.Drawing.Size(185, 23)
        Me.tdbcDutyID.Style = Style8
        Me.tdbcDutyID.TabIndex = 8
        Me.tdbcDutyID.ValueMember = "DutyID"
        Me.tdbcDutyID.PropBag = resources.GetString("tdbcDutyID.PropBag")
        '
        'optUseOfficialAll
        '
        Me.optUseOfficialAll.AutoSize = True
        Me.optUseOfficialAll.Location = New System.Drawing.Point(296, 148)
        Me.optUseOfficialAll.Name = "optUseOfficialAll"
        Me.optUseOfficialAll.Size = New System.Drawing.Size(56, 17)
        Me.optUseOfficialAll.TabIndex = 12
        Me.optUseOfficialAll.TabStop = True
        Me.optUseOfficialAll.Text = "Tất cả"
        Me.optUseOfficialAll.UseVisualStyleBackColor = True
        '
        'optUseOfficial2
        '
        Me.optUseOfficial2.AutoSize = True
        Me.optUseOfficial2.Location = New System.Drawing.Point(150, 148)
        Me.optUseOfficial2.Name = "optUseOfficial2"
        Me.optUseOfficial2.Size = New System.Drawing.Size(95, 17)
        Me.optUseOfficial2.TabIndex = 11
        Me.optUseOfficial2.TabStop = True
        Me.optUseOfficial2.Text = "Ngạch lương 2"
        Me.optUseOfficial2.UseVisualStyleBackColor = True
        '
        'optUseOfficial1
        '
        Me.optUseOfficial1.AutoSize = True
        Me.optUseOfficial1.Location = New System.Drawing.Point(13, 148)
        Me.optUseOfficial1.Name = "optUseOfficial1"
        Me.optUseOfficial1.Size = New System.Drawing.Size(95, 17)
        Me.optUseOfficial1.TabIndex = 10
        Me.optUseOfficial1.TabStop = True
        Me.optUseOfficial1.Text = "Ngạch lương 1"
        Me.optUseOfficial1.UseVisualStyleBackColor = True
        '
        'txtNumSalaryLevel
        '
        Me.txtNumSalaryLevel.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNumSalaryLevel.Location = New System.Drawing.Point(117, 75)
        Me.txtNumSalaryLevel.MaxLength = 3
        Me.txtNumSalaryLevel.Name = "txtNumSalaryLevel"
        Me.txtNumSalaryLevel.Size = New System.Drawing.Size(185, 22)
        Me.txtNumSalaryLevel.TabIndex = 6
        Me.txtNumSalaryLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtOfficialTitleName
        '
        Me.txtOfficialTitleName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtOfficialTitleName.Location = New System.Drawing.Point(117, 46)
        Me.txtOfficialTitleName.MaxLength = 500
        Me.txtOfficialTitleName.Name = "txtOfficialTitleName"
        Me.txtOfficialTitleName.Size = New System.Drawing.Size(426, 22)
        Me.txtOfficialTitleName.TabIndex = 4
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(445, 20)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtOfficialTitleID
        '
        Me.txtOfficialTitleID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOfficialTitleID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtOfficialTitleID.Location = New System.Drawing.Point(117, 17)
        Me.txtOfficialTitleID.MaxLength = 50
        Me.txtOfficialTitleID.Name = "txtOfficialTitleID"
        Me.txtOfficialTitleID.Size = New System.Drawing.Size(185, 22)
        Me.txtOfficialTitleID.TabIndex = 1
        '
        'lblOfficialTitleID
        '
        Me.lblOfficialTitleID.AutoSize = True
        Me.lblOfficialTitleID.Location = New System.Drawing.Point(10, 21)
        Me.lblOfficialTitleID.Name = "lblOfficialTitleID"
        Me.lblOfficialTitleID.Size = New System.Drawing.Size(22, 13)
        Me.lblOfficialTitleID.TabIndex = 0
        Me.lblOfficialTitleID.Text = "Mã"
        Me.lblOfficialTitleID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOfficialTitleName
        '
        Me.lblOfficialTitleName.AutoSize = True
        Me.lblOfficialTitleName.Location = New System.Drawing.Point(10, 51)
        Me.lblOfficialTitleName.Name = "lblOfficialTitleName"
        Me.lblOfficialTitleName.Size = New System.Drawing.Size(48, 13)
        Me.lblOfficialTitleName.TabIndex = 3
        Me.lblOfficialTitleName.Text = "Diễn giải"
        Me.lblOfficialTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumSalaryLevel
        '
        Me.lblNumSalaryLevel.AutoSize = True
        Me.lblNumSalaryLevel.Location = New System.Drawing.Point(10, 80)
        Me.lblNumSalaryLevel.Name = "lblNumSalaryLevel"
        Me.lblNumSalaryLevel.Size = New System.Drawing.Size(85, 13)
        Me.lblNumSalaryLevel.TabIndex = 5
        Me.lblNumSalaryLevel.Text = "Bậc lương tối đa"
        Me.lblNumSalaryLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDutyID
        '
        Me.lblDutyID.AutoSize = True
        Me.lblDutyID.Location = New System.Drawing.Point(10, 111)
        Me.lblDutyID.Name = "lblDutyID"
        Me.lblDutyID.Size = New System.Drawing.Size(47, 13)
        Me.lblDutyID.TabIndex = 7
        Me.lblDutyID.Text = "Chức vụ"
        Me.lblDutyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(319, 183)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(479, 183)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(399, 183)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'D13F1041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 212)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1041"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt ngÁch l§¥ng c¤ng ch÷c - D13F1041"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tdbcDutyID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtNumSalaryLevel As System.Windows.Forms.TextBox
    Private WithEvents txtOfficialTitleName As System.Windows.Forms.TextBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtOfficialTitleID As System.Windows.Forms.TextBox
    Private WithEvents lblOfficialTitleID As System.Windows.Forms.Label
    Private WithEvents lblOfficialTitleName As System.Windows.Forms.Label
    Private WithEvents lblNumSalaryLevel As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents optUseOfficial1 As System.Windows.Forms.RadioButton
    Private WithEvents optUseOfficial2 As System.Windows.Forms.RadioButton
    Private WithEvents optUseOfficialAll As System.Windows.Forms.RadioButton
    Private WithEvents tdbcDutyID As C1.Win.C1List.C1Combo
    Private WithEvents lblDutyID As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
