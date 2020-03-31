<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2011))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.c1dateVoucherDate = New C1.Win.C1Input.C1DateEdit
        Me.btnSetNewKey = New System.Windows.Forms.Button
        Me.txtPayrollVoucherNo = New System.Windows.Forms.TextBox
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo
        Me.lblVoucherTypeID = New System.Windows.Forms.Label
        Me.txtVoucherTypeName = New System.Windows.Forms.TextBox
        Me.lblPayrollVoucherNo = New System.Windows.Forms.Label
        Me.lblteVoucherDate = New System.Windows.Forms.Label
        Me.lblDescription = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbcTransTypeID = New C1.Win.C1List.C1Combo
        Me.lblTransTypeID = New System.Windows.Forms.Label
        Me.btnDetail = New System.Windows.Forms.Button
        Me.chkIsAutoAddEmps = New System.Windows.Forms.CheckBox
        Me.chkIsExcludeMaterity = New System.Windows.Forms.CheckBox
        Me.grp1.SuspendLayout()
        CType(Me.c1dateVoucherDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.txtDescription)
        Me.grp1.Controls.Add(Me.c1dateVoucherDate)
        Me.grp1.Controls.Add(Me.btnSetNewKey)
        Me.grp1.Controls.Add(Me.txtPayrollVoucherNo)
        Me.grp1.Controls.Add(Me.tdbcVoucherTypeID)
        Me.grp1.Controls.Add(Me.lblVoucherTypeID)
        Me.grp1.Controls.Add(Me.txtVoucherTypeName)
        Me.grp1.Controls.Add(Me.lblPayrollVoucherNo)
        Me.grp1.Controls.Add(Me.lblteVoucherDate)
        Me.grp1.Controls.Add(Me.lblDescription)
        Me.grp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grp1.Location = New System.Drawing.Point(12, 41)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(520, 112)
        Me.grp1.TabIndex = 2
        Me.grp1.TabStop = False
        Me.grp1.Text = "Chứng từ"
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(133, 77)
        Me.txtDescription.MaxLength = 250
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(374, 22)
        Me.txtDescription.TabIndex = 9
        '
        'c1dateVoucherDate
        '
        Me.c1dateVoucherDate.AutoSize = False
        Me.c1dateVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateVoucherDate.EmptyAsNull = True
        Me.c1dateVoucherDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateVoucherDate.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.c1dateVoucherDate.Location = New System.Drawing.Point(405, 49)
        Me.c1dateVoucherDate.Name = "c1dateVoucherDate"
        Me.c1dateVoucherDate.Size = New System.Drawing.Size(102, 23)
        Me.c1dateVoucherDate.TabIndex = 7
        Me.c1dateVoucherDate.Tag = Nothing
        Me.c1dateVoucherDate.TrimStart = True
        Me.c1dateVoucherDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'btnSetNewKey
        '
        Me.btnSetNewKey.Image = CType(resources.GetObject("btnSetNewKey.Image"), System.Drawing.Image)
        Me.btnSetNewKey.Location = New System.Drawing.Point(266, 49)
        Me.btnSetNewKey.Name = "btnSetNewKey"
        Me.btnSetNewKey.Size = New System.Drawing.Size(24, 22)
        Me.btnSetNewKey.TabIndex = 5
        Me.btnSetNewKey.UseVisualStyleBackColor = True
        '
        'txtPayrollVoucherNo
        '
        Me.txtPayrollVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPayrollVoucherNo.Location = New System.Drawing.Point(133, 49)
        Me.txtPayrollVoucherNo.MaxLength = 20
        Me.txtPayrollVoucherNo.Name = "txtPayrollVoucherNo"
        Me.txtPayrollVoucherNo.Size = New System.Drawing.Size(129, 22)
        Me.txtPayrollVoucherNo.TabIndex = 4
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
        Me.tdbcVoucherTypeID.CaptionStyle = Style1
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
        Me.tdbcVoucherTypeID.EvenRowStyle = Style2
        Me.tdbcVoucherTypeID.ExtendRightColumn = True
        Me.tdbcVoucherTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcVoucherTypeID.FooterStyle = Style3
        Me.tdbcVoucherTypeID.HeadingStyle = Style4
        Me.tdbcVoucherTypeID.HighLightRowStyle = Style5
        Me.tdbcVoucherTypeID.Images.Add(CType(resources.GetObject("tdbcVoucherTypeID.Images"), System.Drawing.Image))
        Me.tdbcVoucherTypeID.ItemHeight = 15
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(133, 20)
        Me.tdbcVoucherTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcVoucherTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcVoucherTypeID.MaxLength = 32767
        Me.tdbcVoucherTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcVoucherTypeID.Name = "tdbcVoucherTypeID"
        Me.tdbcVoucherTypeID.OddRowStyle = Style6
        Me.tdbcVoucherTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcVoucherTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.SelectedStyle = Style7
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(129, 23)
        Me.tdbcVoucherTypeID.Style = Style8
        Me.tdbcVoucherTypeID.TabIndex = 0
        Me.tdbcVoucherTypeID.ValueMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = True
        Me.lblVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(11, 24)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 1
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVoucherTypeName
        '
        Me.txtVoucherTypeName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtVoucherTypeName.Location = New System.Drawing.Point(266, 20)
        Me.txtVoucherTypeName.Name = "txtVoucherTypeName"
        Me.txtVoucherTypeName.ReadOnly = True
        Me.txtVoucherTypeName.Size = New System.Drawing.Size(241, 22)
        Me.txtVoucherTypeName.TabIndex = 2
        Me.txtVoucherTypeName.TabStop = False
        '
        'lblPayrollVoucherNo
        '
        Me.lblPayrollVoucherNo.AutoSize = True
        Me.lblPayrollVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPayrollVoucherNo.Location = New System.Drawing.Point(11, 53)
        Me.lblPayrollVoucherNo.Name = "lblPayrollVoucherNo"
        Me.lblPayrollVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblPayrollVoucherNo.TabIndex = 3
        Me.lblPayrollVoucherNo.Text = "Số phiếu"
        Me.lblPayrollVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteVoucherDate
        '
        Me.lblteVoucherDate.AutoSize = True
        Me.lblteVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblteVoucherDate.Location = New System.Drawing.Point(315, 54)
        Me.lblteVoucherDate.Name = "lblteVoucherDate"
        Me.lblteVoucherDate.Size = New System.Drawing.Size(61, 13)
        Me.lblteVoucherDate.TabIndex = 6
        Me.lblteVoucherDate.Text = "Ngày phiếu"
        Me.lblteVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(11, 80)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(48, 13)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Diễn giải"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(294, 182)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(456, 182)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbcTransTypeID
        '
        Me.tdbcTransTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransTypeID.AllowColMove = False
        Me.tdbcTransTypeID.AllowSort = False
        Me.tdbcTransTypeID.AlternatingRows = True
        Me.tdbcTransTypeID.AutoDropDown = True
        Me.tdbcTransTypeID.Caption = ""
        Me.tdbcTransTypeID.CaptionHeight = 17
        Me.tdbcTransTypeID.CaptionStyle = Style9
        Me.tdbcTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransTypeID.ColumnCaptionHeight = 17
        Me.tdbcTransTypeID.ColumnFooterHeight = 17
        Me.tdbcTransTypeID.ColumnWidth = 100
        Me.tdbcTransTypeID.ContentHeight = 17
        Me.tdbcTransTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransTypeID.DisplayMember = "TransTypeName"
        Me.tdbcTransTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTransTypeID.DropDownWidth = 300
        Me.tdbcTransTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransTypeID.EditorHeight = 17
        Me.tdbcTransTypeID.EmptyRows = True
        Me.tdbcTransTypeID.EvenRowStyle = Style10
        Me.tdbcTransTypeID.ExtendRightColumn = True
        Me.tdbcTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.FooterStyle = Style11
        Me.tdbcTransTypeID.HeadingStyle = Style12
        Me.tdbcTransTypeID.HighLightRowStyle = Style13
        Me.tdbcTransTypeID.Images.Add(CType(resources.GetObject("tdbcTransTypeID.Images"), System.Drawing.Image))
        Me.tdbcTransTypeID.ItemHeight = 15
        Me.tdbcTransTypeID.Location = New System.Drawing.Point(145, 12)
        Me.tdbcTransTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransTypeID.MaxLength = 32767
        Me.tdbcTransTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransTypeID.Name = "tdbcTransTypeID"
        Me.tdbcTransTypeID.OddRowStyle = Style14
        Me.tdbcTransTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.SelectedStyle = Style15
        Me.tdbcTransTypeID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcTransTypeID.Style = Style16
        Me.tdbcTransTypeID.TabIndex = 1
        Me.tdbcTransTypeID.ValueMember = "TransTypeID"
        Me.tdbcTransTypeID.PropBag = resources.GetString("tdbcTransTypeID.PropBag")
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(23, 17)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 0
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(376, 182)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(74, 22)
        Me.btnDetail.TabIndex = 6
        Me.btnDetail.Text = "&Chi tiết"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'chkIsAutoAddEmps
        '
        Me.chkIsAutoAddEmps.AutoSize = True
        Me.chkIsAutoAddEmps.Location = New System.Drawing.Point(26, 159)
        Me.chkIsAutoAddEmps.Name = "chkIsAutoAddEmps"
        Me.chkIsAutoAddEmps.Size = New System.Drawing.Size(186, 17)
        Me.chkIsAutoAddEmps.TabIndex = 3
        Me.chkIsAutoAddEmps.Text = "Tự động thêm NV vào HSL tháng"
        Me.chkIsAutoAddEmps.UseVisualStyleBackColor = True
        '
        'chkIsExcludeMaterity
        '
        Me.chkIsExcludeMaterity.AutoSize = True
        Me.chkIsExcludeMaterity.Location = New System.Drawing.Point(294, 159)
        Me.chkIsExcludeMaterity.Name = "chkIsExcludeMaterity"
        Me.chkIsExcludeMaterity.Size = New System.Drawing.Size(174, 17)
        Me.chkIsExcludeMaterity.TabIndex = 4
        Me.chkIsExcludeMaterity.Text = "Loại bỏ nhân viên nghỉ thai sản"
        Me.chkIsExcludeMaterity.UseVisualStyleBackColor = True
        '
        'D13F2011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 209)
        Me.Controls.Add(Me.chkIsExcludeMaterity)
        Me.Controls.Add(Me.chkIsAutoAddEmps)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.tdbcTransTypeID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.lblTransTypeID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(40, 40)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2011"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mê hä s¥ l§¥ng thÀng - D13F2011"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.c1dateVoucherDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents c1dateVoucherDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents btnSetNewKey As System.Windows.Forms.Button
    Private WithEvents txtPayrollVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents txtVoucherTypeName As System.Windows.Forms.TextBox
    Private WithEvents lblPayrollVoucherNo As System.Windows.Forms.Label
    Private WithEvents lblteVoucherDate As System.Windows.Forms.Label
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcTransTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents btnDetail As System.Windows.Forms.Button
    Private WithEvents chkIsAutoAddEmps As System.Windows.Forms.CheckBox
    Private WithEvents chkIsExcludeMaterity As System.Windows.Forms.CheckBox
End Class
