<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2110
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2110))
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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkIsCalculate = New System.Windows.Forms.CheckBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.c1dateEntryDate = New C1.Win.C1Input.C1DateEdit
        Me.lblDescription = New System.Windows.Forms.Label
        Me.lblteEntryDate = New System.Windows.Forms.Label
        Me.tdbcEmployeeID = New C1.Win.C1List.C1Combo
        Me.lblEmployeeID = New System.Windows.Forms.Label
        Me.txtAbsentVoucherNo = New System.Windows.Forms.TextBox
        Me.lblAbsentVoucherNo = New System.Windows.Forms.Label
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo
        Me.lblVoucherTypeID = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.tdbcPolicyID = New C1.Win.C1List.C1Combo
        Me.lblPolicyID = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCalculate = New System.Windows.Forms.Button
        Me.pnl1 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.c1dateEntryDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.tdbcPolicyID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkIsCalculate)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.c1dateEntryDate)
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.lblteEntryDate)
        Me.GroupBox1.Controls.Add(Me.tdbcEmployeeID)
        Me.GroupBox1.Controls.Add(Me.lblEmployeeID)
        Me.GroupBox1.Controls.Add(Me.txtAbsentVoucherNo)
        Me.GroupBox1.Controls.Add(Me.lblAbsentVoucherNo)
        Me.GroupBox1.Controls.Add(Me.tdbcVoucherTypeID)
        Me.GroupBox1.Controls.Add(Me.lblVoucherTypeID)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(6, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1006, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Thông tin phiếu"
        '
        'chkIsCalculate
        '
        Me.chkIsCalculate.AutoSize = True
        Me.chkIsCalculate.Enabled = False
        Me.chkIsCalculate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsCalculate.Location = New System.Drawing.Point(883, 51)
        Me.chkIsCalculate.Name = "chkIsCalculate"
        Me.chkIsCalculate.Size = New System.Drawing.Size(62, 17)
        Me.chkIsCalculate.TabIndex = 10
        Me.chkIsCalculate.Text = "Đã tính"
        Me.chkIsCalculate.UseVisualStyleBackColor = True
        '
        'txtDescription
        '
        Me.txtDescription.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDescription.Location = New System.Drawing.Point(89, 48)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(774, 22)
        Me.txtDescription.TabIndex = 9
        '
        'c1dateEntryDate
        '
        Me.c1dateEntryDate.AutoSize = False
        Me.c1dateEntryDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateEntryDate.EmptyAsNull = True
        Me.c1dateEntryDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateEntryDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateEntryDate.Location = New System.Drawing.Point(883, 19)
        Me.c1dateEntryDate.Name = "c1dateEntryDate"
        Me.c1dateEntryDate.Size = New System.Drawing.Size(116, 22)
        Me.c1dateEntryDate.TabIndex = 7
        Me.c1dateEntryDate.Tag = Nothing
        Me.c1dateEntryDate.TrimStart = True
        Me.c1dateEntryDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(14, 52)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(44, 13)
        Me.lblDescription.TabIndex = 8
        Me.lblDescription.Text = "Ghi chú"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteEntryDate
        '
        Me.lblteEntryDate.AutoSize = True
        Me.lblteEntryDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblteEntryDate.Location = New System.Drawing.Point(802, 23)
        Me.lblteEntryDate.Name = "lblteEntryDate"
        Me.lblteEntryDate.Size = New System.Drawing.Size(61, 13)
        Me.lblteEntryDate.TabIndex = 6
        Me.lblteEntryDate.Text = "Ngày phiếu"
        Me.lblteEntryDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcEmployeeID
        '
        Me.tdbcEmployeeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcEmployeeID.AllowColMove = False
        Me.tdbcEmployeeID.AllowSort = False
        Me.tdbcEmployeeID.AlternatingRows = True
        Me.tdbcEmployeeID.AutoDropDown = True
        Me.tdbcEmployeeID.Caption = ""
        Me.tdbcEmployeeID.CaptionHeight = 17
        Me.tdbcEmployeeID.CaptionStyle = Style1
        Me.tdbcEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcEmployeeID.ColumnCaptionHeight = 17
        Me.tdbcEmployeeID.ColumnFooterHeight = 17
        Me.tdbcEmployeeID.ColumnWidth = 100
        Me.tdbcEmployeeID.ContentHeight = 17
        Me.tdbcEmployeeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcEmployeeID.DisplayMember = "EmployeeName"
        Me.tdbcEmployeeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcEmployeeID.DropDownWidth = 300
        Me.tdbcEmployeeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcEmployeeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcEmployeeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcEmployeeID.EditorHeight = 17
        Me.tdbcEmployeeID.EmptyRows = True
        Me.tdbcEmployeeID.EvenRowStyle = Style2
        Me.tdbcEmployeeID.ExtendRightColumn = True
        Me.tdbcEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcEmployeeID.FooterStyle = Style3
        Me.tdbcEmployeeID.HeadingStyle = Style4
        Me.tdbcEmployeeID.HighLightRowStyle = Style5
        Me.tdbcEmployeeID.Images.Add(CType(resources.GetObject("tdbcEmployeeID.Images"), System.Drawing.Image))
        Me.tdbcEmployeeID.ItemHeight = 15
        Me.tdbcEmployeeID.Location = New System.Drawing.Point(614, 19)
        Me.tdbcEmployeeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcEmployeeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcEmployeeID.MaxLength = 32767
        Me.tdbcEmployeeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcEmployeeID.Name = "tdbcEmployeeID"
        Me.tdbcEmployeeID.OddRowStyle = Style6
        Me.tdbcEmployeeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcEmployeeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcEmployeeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcEmployeeID.SelectedStyle = Style7
        Me.tdbcEmployeeID.Size = New System.Drawing.Size(169, 23)
        Me.tdbcEmployeeID.Style = Style8
        Me.tdbcEmployeeID.TabIndex = 5
        Me.tdbcEmployeeID.ValueMember = "EmployeeID"
        Me.tdbcEmployeeID.PropBag = resources.GetString("tdbcEmployeeID.PropBag")
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeID.Location = New System.Drawing.Point(542, 23)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(52, 13)
        Me.lblEmployeeID.TabIndex = 4
        Me.lblEmployeeID.Text = "Người lập"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAbsentVoucherNo
        '
        Me.txtAbsentVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentVoucherNo.Location = New System.Drawing.Point(350, 19)
        Me.txtAbsentVoucherNo.MaxLength = 20
        Me.txtAbsentVoucherNo.Name = "txtAbsentVoucherNo"
        Me.txtAbsentVoucherNo.Size = New System.Drawing.Size(165, 22)
        Me.txtAbsentVoucherNo.TabIndex = 3
        '
        'lblAbsentVoucherNo
        '
        Me.lblAbsentVoucherNo.AutoSize = True
        Me.lblAbsentVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbsentVoucherNo.Location = New System.Drawing.Point(283, 23)
        Me.lblAbsentVoucherNo.Name = "lblAbsentVoucherNo"
        Me.lblAbsentVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblAbsentVoucherNo.TabIndex = 2
        Me.lblAbsentVoucherNo.Text = "Số phiếu"
        Me.lblAbsentVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(89, 19)
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
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(167, 23)
        Me.tdbcVoucherTypeID.Style = Style16
        Me.tdbcVoucherTypeID.TabIndex = 1
        Me.tdbcVoucherTypeID.ValueMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = True
        Me.lblVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(14, 23)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 0
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tdbg)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1006, 457)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Phiếu lương"
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 19)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(993, 429)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tdbcPolicyID)
        Me.GroupBox3.Controls.Add(Me.lblPolicyID)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(6, 557)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1006, 52)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Cơ chế chuyển bút toán"
        '
        'tdbcPolicyID
        '
        Me.tdbcPolicyID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPolicyID.AllowColMove = False
        Me.tdbcPolicyID.AllowSort = False
        Me.tdbcPolicyID.AlternatingRows = True
        Me.tdbcPolicyID.AutoDropDown = True
        Me.tdbcPolicyID.Caption = ""
        Me.tdbcPolicyID.CaptionHeight = 17
        Me.tdbcPolicyID.CaptionStyle = Style17
        Me.tdbcPolicyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPolicyID.ColumnCaptionHeight = 17
        Me.tdbcPolicyID.ColumnFooterHeight = 17
        Me.tdbcPolicyID.ColumnWidth = 100
        Me.tdbcPolicyID.ContentHeight = 17
        Me.tdbcPolicyID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPolicyID.DisplayMember = "PolicyName"
        Me.tdbcPolicyID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPolicyID.DropDownWidth = 350
        Me.tdbcPolicyID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPolicyID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPolicyID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPolicyID.EditorHeight = 17
        Me.tdbcPolicyID.EmptyRows = True
        Me.tdbcPolicyID.EvenRowStyle = Style18
        Me.tdbcPolicyID.ExtendRightColumn = True
        Me.tdbcPolicyID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPolicyID.FooterStyle = Style19
        Me.tdbcPolicyID.HeadingStyle = Style20
        Me.tdbcPolicyID.HighLightRowStyle = Style21
        Me.tdbcPolicyID.Images.Add(CType(resources.GetObject("tdbcPolicyID.Images"), System.Drawing.Image))
        Me.tdbcPolicyID.ItemHeight = 15
        Me.tdbcPolicyID.Location = New System.Drawing.Point(159, 20)
        Me.tdbcPolicyID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPolicyID.MaxDropDownItems = CType(8, Short)
        Me.tdbcPolicyID.MaxLength = 32767
        Me.tdbcPolicyID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPolicyID.Name = "tdbcPolicyID"
        Me.tdbcPolicyID.OddRowStyle = Style22
        Me.tdbcPolicyID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPolicyID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPolicyID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPolicyID.SelectedStyle = Style23
        Me.tdbcPolicyID.Size = New System.Drawing.Size(382, 23)
        Me.tdbcPolicyID.Style = Style24
        Me.tdbcPolicyID.TabIndex = 1
        Me.tdbcPolicyID.ValueMember = "PolicyID"
        Me.tdbcPolicyID.PropBag = resources.GetString("tdbcPolicyID.PropBag")
        '
        'lblPolicyID
        '
        Me.lblPolicyID.AutoSize = True
        Me.lblPolicyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolicyID.Location = New System.Drawing.Point(14, 25)
        Me.lblPolicyID.Name = "lblPolicyID"
        Me.lblPolicyID.Size = New System.Drawing.Size(121, 13)
        Me.lblPolicyID.TabIndex = 0
        Me.lblPolicyID.Text = "Cơ chế chuyển bút toán"
        Me.lblPolicyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(195, 5)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(31, 5)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Lưu"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(113, 5)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Nhập &tiếp"
        '
        'btnCalculate
        '
        Me.btnCalculate.Location = New System.Drawing.Point(12, 621)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(79, 22)
        Me.btnCalculate.TabIndex = 6
        Me.btnCalculate.Text = "Tín&h"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.btnNext)
        Me.pnl1.Controls.Add(Me.btnSave)
        Me.pnl1.Controls.Add(Me.btnClose)
        Me.pnl1.Location = New System.Drawing.Point(732, 615)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(280, 38)
        Me.pnl1.TabIndex = 7
        '
        'D13F2110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.pnl1)
        Me.Controls.Add(Me.btnCalculate)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2110"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PhiÕu tÛnh kÕt qu¶ chuyÓn bòt toÀn - D13F2110"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.c1dateEntryDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcVoucherTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.tdbcPolicyID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnl1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtAbsentVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblAbsentVoucherNo As System.Windows.Forms.Label
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents tdbcEmployeeID As C1.Win.C1List.C1Combo
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Private WithEvents c1dateEntryDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteEntryDate As System.Windows.Forms.Label
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcPolicyID As C1.Win.C1List.C1Combo
    Private WithEvents lblPolicyID As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnCalculate As System.Windows.Forms.Button
    Private WithEvents chkIsCalculate As System.Windows.Forms.CheckBox
    Private WithEvents pnl1 As System.Windows.Forms.Panel
End Class
