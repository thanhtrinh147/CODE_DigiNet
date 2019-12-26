<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1041
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1041))
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
        Me.txtTransTypeID = New System.Windows.Forms.TextBox()
        Me.lblTransTypeID = New System.Windows.Forms.Label()
        Me.txtTransTypeName = New System.Windows.Forms.TextBox()
        Me.lblTransTypeName = New System.Windows.Forms.Label()
        Me.tdbcDAGroupID = New C1.Win.C1List.C1Combo()
        Me.lblDAGroupID = New System.Windows.Forms.Label()
        Me.txtDAGroupName = New System.Windows.Forms.TextBox()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.grpLine = New System.Windows.Forms.GroupBox()
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo()
        Me.lblVoucherTypeID = New System.Windows.Forms.Label()
        Me.txtVoucherTypeName = New System.Windows.Forms.TextBox()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.lblNote = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.lblVoucher = New System.Windows.Forms.Label()
        Me.lblMethod = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optMethod3 = New System.Windows.Forms.RadioButton()
        Me.chkIsSpec = New System.Windows.Forms.CheckBox()
        Me.optMethod2 = New System.Windows.Forms.RadioButton()
        Me.optMethod1 = New System.Windows.Forms.RadioButton()
        Me.optMethod0 = New System.Windows.Forms.RadioButton()
        CType(Me.tdbcDAGroupID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTransTypeID
        '
        Me.txtTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransTypeID.Location = New System.Drawing.Point(140, 15)
        Me.txtTransTypeID.MaxLength = 20
        Me.txtTransTypeID.Name = "txtTransTypeID"
        Me.txtTransTypeID.Size = New System.Drawing.Size(140, 22)
        Me.txtTransTypeID.TabIndex = 0
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(11, 19)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(22, 13)
        Me.lblTransTypeID.TabIndex = 0
        Me.lblTransTypeID.Text = "Mã"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransTypeName.Location = New System.Drawing.Point(140, 43)
        Me.txtTransTypeName.MaxLength = 150
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.Size = New System.Drawing.Size(490, 22)
        Me.txtTransTypeName.TabIndex = 2
        '
        'lblTransTypeName
        '
        Me.lblTransTypeName.AutoSize = True
        Me.lblTransTypeName.Location = New System.Drawing.Point(11, 48)
        Me.lblTransTypeName.Name = "lblTransTypeName"
        Me.lblTransTypeName.Size = New System.Drawing.Size(48, 13)
        Me.lblTransTypeName.TabIndex = 3
        Me.lblTransTypeName.Text = "Diễn giải"
        Me.lblTransTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDAGroupID
        '
        Me.tdbcDAGroupID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDAGroupID.AllowColMove = False
        Me.tdbcDAGroupID.AllowSort = False
        Me.tdbcDAGroupID.AlternatingRows = True
        Me.tdbcDAGroupID.AutoCompletion = True
        Me.tdbcDAGroupID.AutoDropDown = True
        Me.tdbcDAGroupID.Caption = ""
        Me.tdbcDAGroupID.CaptionHeight = 17
        Me.tdbcDAGroupID.CaptionStyle = Style1
        Me.tdbcDAGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDAGroupID.ColumnCaptionHeight = 17
        Me.tdbcDAGroupID.ColumnFooterHeight = 17
        Me.tdbcDAGroupID.ColumnWidth = 100
        Me.tdbcDAGroupID.ContentHeight = 17
        Me.tdbcDAGroupID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDAGroupID.DisplayMember = "DAGroupID"
        Me.tdbcDAGroupID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDAGroupID.DropDownWidth = 300
        Me.tdbcDAGroupID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDAGroupID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDAGroupID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDAGroupID.EditorHeight = 17
        Me.tdbcDAGroupID.EmptyRows = True
        Me.tdbcDAGroupID.EvenRowStyle = Style2
        Me.tdbcDAGroupID.ExtendRightColumn = True
        Me.tdbcDAGroupID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDAGroupID.FooterStyle = Style3
        Me.tdbcDAGroupID.HeadingStyle = Style4
        Me.tdbcDAGroupID.HighLightRowStyle = Style5
        Me.tdbcDAGroupID.Images.Add(CType(resources.GetObject("tdbcDAGroupID.Images"), System.Drawing.Image))
        Me.tdbcDAGroupID.ItemHeight = 15
        Me.tdbcDAGroupID.Location = New System.Drawing.Point(140, 71)
        Me.tdbcDAGroupID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDAGroupID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDAGroupID.MaxLength = 32767
        Me.tdbcDAGroupID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDAGroupID.Name = "tdbcDAGroupID"
        Me.tdbcDAGroupID.OddRowStyle = Style6
        Me.tdbcDAGroupID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDAGroupID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDAGroupID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDAGroupID.SelectedStyle = Style7
        Me.tdbcDAGroupID.Size = New System.Drawing.Size(140, 23)
        Me.tdbcDAGroupID.Style = Style8
        Me.tdbcDAGroupID.TabIndex = 3
        Me.tdbcDAGroupID.ValueMember = "DAGroupID"
        Me.tdbcDAGroupID.PropBag = resources.GetString("tdbcDAGroupID.PropBag")
        '
        'lblDAGroupID
        '
        Me.lblDAGroupID.AllowDrop = True
        Me.lblDAGroupID.Location = New System.Drawing.Point(11, 76)
        Me.lblDAGroupID.Name = "lblDAGroupID"
        Me.lblDAGroupID.Size = New System.Drawing.Size(117, 13)
        Me.lblDAGroupID.TabIndex = 5
        Me.lblDAGroupID.Text = "Nhóm truy cập dữ liệu"
        Me.lblDAGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDAGroupName
        '
        Me.txtDAGroupName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDAGroupName.Location = New System.Drawing.Point(286, 72)
        Me.txtDAGroupName.Name = "txtDAGroupName"
        Me.txtDAGroupName.ReadOnly = True
        Me.txtDAGroupName.Size = New System.Drawing.Size(344, 22)
        Me.txtDAGroupName.TabIndex = 4
        Me.txtDAGroupName.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(524, 18)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'grpLine
        '
        Me.grpLine.Location = New System.Drawing.Point(6, 105)
        Me.grpLine.Name = "grpLine"
        Me.grpLine.Size = New System.Drawing.Size(626, 3)
        Me.grpLine.TabIndex = 8
        Me.grpLine.TabStop = False
        '
        'tdbcVoucherTypeID
        '
        Me.tdbcVoucherTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcVoucherTypeID.AllowColMove = False
        Me.tdbcVoucherTypeID.AllowSort = False
        Me.tdbcVoucherTypeID.AlternatingRows = True
        Me.tdbcVoucherTypeID.AutoCompletion = True
        Me.tdbcVoucherTypeID.AutoDropDown = True
        Me.tdbcVoucherTypeID.Caption = ""
        Me.tdbcVoucherTypeID.CaptionHeight = 17
        Me.tdbcVoucherTypeID.CaptionStyle = Style9
        Me.tdbcVoucherTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcVoucherTypeID.ColumnCaptionHeight = 17
        Me.tdbcVoucherTypeID.ColumnFooterHeight = 17
        Me.tdbcVoucherTypeID.ColumnWidth = 100
        Me.tdbcVoucherTypeID.ContentHeight = 17
        Me.tdbcVoucherTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcVoucherTypeID.DisplayMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcVoucherTypeID.DropDownWidth = 300
        Me.tdbcVoucherTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcVoucherTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcVoucherTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcVoucherTypeID.EditorHeight = 17
        Me.tdbcVoucherTypeID.EmptyRows = True
        Me.tdbcVoucherTypeID.EvenRowStyle = Style10
        Me.tdbcVoucherTypeID.ExtendRightColumn = True
        Me.tdbcVoucherTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcVoucherTypeID.FooterStyle = Style11
        Me.tdbcVoucherTypeID.HeadingStyle = Style12
        Me.tdbcVoucherTypeID.HighLightRowStyle = Style13
        Me.tdbcVoucherTypeID.Images.Add(CType(resources.GetObject("tdbcVoucherTypeID.Images"), System.Drawing.Image))
        Me.tdbcVoucherTypeID.ItemHeight = 15
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(140, 119)
        Me.tdbcVoucherTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcVoucherTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcVoucherTypeID.MaxLength = 32767
        Me.tdbcVoucherTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcVoucherTypeID.Name = "tdbcVoucherTypeID"
        Me.tdbcVoucherTypeID.OddRowStyle = Style14
        Me.tdbcVoucherTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcVoucherTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.SelectedStyle = Style15
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(140, 23)
        Me.tdbcVoucherTypeID.Style = Style16
        Me.tdbcVoucherTypeID.TabIndex = 5
        Me.tdbcVoucherTypeID.ValueMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = True
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(11, 124)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 9
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVoucherTypeName
        '
        Me.txtVoucherTypeName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtVoucherTypeName.Location = New System.Drawing.Point(286, 119)
        Me.txtVoucherTypeName.Name = "txtVoucherTypeName"
        Me.txtVoucherTypeName.ReadOnly = True
        Me.txtVoucherTypeName.Size = New System.Drawing.Size(344, 22)
        Me.txtVoucherTypeName.TabIndex = 6
        Me.txtVoucherTypeName.TabStop = False
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(140, 148)
        Me.txtNote.MaxLength = 150
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(490, 22)
        Me.txtNote.TabIndex = 7
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(11, 153)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(48, 13)
        Me.lblNote.TabIndex = 12
        Me.lblNote.Text = "Diễn giải"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(403, 272)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(485, 272)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(567, 272)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.optMethod3)
        Me.grp1.Controls.Add(Me.chkIsSpec)
        Me.grp1.Controls.Add(Me.optMethod2)
        Me.grp1.Controls.Add(Me.optMethod1)
        Me.grp1.Controls.Add(Me.optMethod0)
        Me.grp1.Controls.Add(Me.lblMethod)
        Me.grp1.Controls.Add(Me.GroupBox1)
        Me.grp1.Controls.Add(Me.lblVoucher)
        Me.grp1.Controls.Add(Me.txtTransTypeID)
        Me.grp1.Controls.Add(Me.lblNote)
        Me.grp1.Controls.Add(Me.txtVoucherTypeName)
        Me.grp1.Controls.Add(Me.txtNote)
        Me.grp1.Controls.Add(Me.lblVoucherTypeID)
        Me.grp1.Controls.Add(Me.tdbcVoucherTypeID)
        Me.grp1.Controls.Add(Me.txtDAGroupName)
        Me.grp1.Controls.Add(Me.grpLine)
        Me.grp1.Controls.Add(Me.lblDAGroupID)
        Me.grp1.Controls.Add(Me.chkDisabled)
        Me.grp1.Controls.Add(Me.lblTransTypeName)
        Me.grp1.Controls.Add(Me.tdbcDAGroupID)
        Me.grp1.Controls.Add(Me.lblTransTypeID)
        Me.grp1.Controls.Add(Me.txtTransTypeName)
        Me.grp1.Location = New System.Drawing.Point(7, 4)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(636, 262)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'lblVoucher
        '
        Me.lblVoucher.AutoSize = True
        Me.lblVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucher.Location = New System.Drawing.Point(5, 99)
        Me.lblVoucher.Name = "lblVoucher"
        Me.lblVoucher.Size = New System.Drawing.Size(58, 13)
        Me.lblVoucher.TabIndex = 4
        Me.lblVoucher.Text = "Chứng từ"
        Me.lblVoucher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMethod
        '
        Me.lblMethod.AutoSize = True
        Me.lblMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMethod.Location = New System.Drawing.Point(5, 180)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(148, 13)
        Me.lblMethod.TabIndex = 13
        Me.lblMethod.Text = "Phương pháp chấm công"
        Me.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(6, 186)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 3)
        Me.GroupBox1.TabIndex = 14
        Me.GroupBox1.TabStop = False
        '
        'optMethod3
        '
        Me.optMethod3.AutoSize = True
        Me.optMethod3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMethod3.Location = New System.Drawing.Point(16, 234)
        Me.optMethod3.Name = "optMethod3"
        Me.optMethod3.Size = New System.Drawing.Size(129, 17)
        Me.optMethod3.TabIndex = 11
        Me.optMethod3.TabStop = True
        Me.optMethod3.Text = "Theo nhóm nhân viên"
        Me.optMethod3.UseVisualStyleBackColor = True
        '
        'chkIsSpec
        '
        Me.chkIsSpec.AutoSize = True
        Me.chkIsSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsSpec.Location = New System.Drawing.Point(214, 235)
        Me.chkIsSpec.Name = "chkIsSpec"
        Me.chkIsSpec.Size = New System.Drawing.Size(151, 17)
        Me.chkIsSpec.TabIndex = 12
        Me.chkIsSpec.Text = "Chấm công theo quy cách"
        Me.chkIsSpec.UseVisualStyleBackColor = True
        '
        'optMethod2
        '
        Me.optMethod2.AutoSize = True
        Me.optMethod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMethod2.Location = New System.Drawing.Point(437, 204)
        Me.optMethod2.Name = "optMethod2"
        Me.optMethod2.Size = New System.Drawing.Size(110, 17)
        Me.optMethod2.TabIndex = 10
        Me.optMethod2.Text = "Theo nhóm CCSP"
        Me.optMethod2.UseVisualStyleBackColor = True
        '
        'optMethod1
        '
        Me.optMethod1.AutoSize = True
        Me.optMethod1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMethod1.Location = New System.Drawing.Point(214, 205)
        Me.optMethod1.Name = "optMethod1"
        Me.optMethod1.Size = New System.Drawing.Size(147, 17)
        Me.optMethod1.TabIndex = 9
        Me.optMethod1.Text = "Theo phòng ban/tổ nhóm"
        Me.optMethod1.UseVisualStyleBackColor = True
        '
        'optMethod0
        '
        Me.optMethod0.AutoSize = True
        Me.optMethod0.Checked = True
        Me.optMethod0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMethod0.Location = New System.Drawing.Point(16, 205)
        Me.optMethod0.Name = "optMethod0"
        Me.optMethod0.Size = New System.Drawing.Size(100, 17)
        Me.optMethod0.TabIndex = 8
        Me.optMethod0.TabStop = True
        Me.optMethod0.Text = "Theo nhân viên"
        Me.optMethod0.UseVisualStyleBackColor = True
        '
        'D45F1041
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 298)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1041"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt loÁi nghiÖp vó - D45F1041"
        CType(Me.tdbcDAGroupID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtTransTypeID As System.Windows.Forms.TextBox
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
    Private WithEvents lblTransTypeName As System.Windows.Forms.Label
    Private WithEvents tdbcDAGroupID As C1.Win.C1List.C1Combo
    Private WithEvents lblDAGroupID As System.Windows.Forms.Label
    Private WithEvents txtDAGroupName As System.Windows.Forms.TextBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents grpLine As System.Windows.Forms.GroupBox
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents txtVoucherTypeName As System.Windows.Forms.TextBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents optMethod3 As System.Windows.Forms.RadioButton
    Private WithEvents chkIsSpec As System.Windows.Forms.CheckBox
    Private WithEvents optMethod2 As System.Windows.Forms.RadioButton
    Private WithEvents optMethod1 As System.Windows.Forms.RadioButton
    Private WithEvents optMethod0 As System.Windows.Forms.RadioButton
    Private WithEvents lblMethod As System.Windows.Forms.Label
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents lblVoucher As System.Windows.Forms.Label
End Class
