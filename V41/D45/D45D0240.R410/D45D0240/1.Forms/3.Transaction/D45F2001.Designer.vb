<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2001))
        Me.grpVoucher = New System.Windows.Forms.GroupBox()
        Me.tdbcPreparerID = New C1.Win.C1List.C1Combo()
        Me.txtVoucherTypeName = New System.Windows.Forms.TextBox()
        Me.btnSetNewKey = New System.Windows.Forms.Button()
        Me.c1dateVoucherDate = New C1.Win.C1Input.C1DateEdit()
        Me.tdbcVoucherTypeID = New C1.Win.C1List.C1Combo()
        Me.txtNote = New System.Windows.Forms.TextBox()
        Me.txtProductVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.lblVoucherDate = New System.Windows.Forms.Label()
        Me.lblVoucherDesc = New System.Windows.Forms.Label()
        Me.lblVoucherTypeID = New System.Windows.Forms.Label()
        Me.lblPreparerID = New System.Windows.Forms.Label()
        Me.txtPreparerName = New System.Windows.Forms.TextBox()
        Me.grpAttendance = New System.Windows.Forms.GroupBox()
        Me.c1dateDateTo = New C1.Win.C1Input.C1DateEdit()
        Me.c1dateDateFrom = New C1.Win.C1Input.C1DateEdit()
        Me.lblteDateFrom = New System.Windows.Forms.Label()
        Me.lblteDateTo = New System.Windows.Forms.Label()
        Me.grpCriate = New System.Windows.Forms.GroupBox()
        Me.tdbcBlockID = New C1.Win.C1List.C1Combo()
        Me.tdbcTeamID = New C1.Win.C1List.C1Combo()
        Me.tdbcDepartmentID = New C1.Win.C1List.C1Combo()
        Me.lblDepartmentID = New System.Windows.Forms.Label()
        Me.lblTeamID = New System.Windows.Forms.Label()
        Me.lblBlockID = New System.Windows.Forms.Label()
        Me.btnAttendance = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.tdbcTransTypeID = New C1.Win.C1List.C1Combo()
        Me.lblTransTypeID = New System.Windows.Forms.Label()
        Me.txtTransTypeName = New System.Windows.Forms.TextBox()
        Me.tdbcDAGroupID = New C1.Win.C1List.C1Combo()
        Me.lblDAGroupID = New System.Windows.Forms.Label()
        Me.txtDAGroupName = New System.Windows.Forms.TextBox()
        Me.grpMethod = New System.Windows.Forms.GroupBox()
        Me.optMethod3 = New System.Windows.Forms.RadioButton()
        Me.chkIsSpec = New System.Windows.Forms.CheckBox()
        Me.optMethod2 = New System.Windows.Forms.RadioButton()
        Me.optMethod1 = New System.Windows.Forms.RadioButton()
        Me.optMethod0 = New System.Windows.Forms.RadioButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.grpVoucher.SuspendLayout
        CType(Me.tdbcPreparerID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.c1dateVoucherDate,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcVoucherTypeID,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpAttendance.SuspendLayout
        CType(Me.c1dateDateTo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.c1dateDateFrom,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpCriate.SuspendLayout
        CType(Me.tdbcBlockID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcTeamID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcDepartmentID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcTransTypeID,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.tdbcDAGroupID,System.ComponentModel.ISupportInitialize).BeginInit
        Me.grpMethod.SuspendLayout
        Me.SuspendLayout
        '
        'grpVoucher
        '
        Me.grpVoucher.Controls.Add(Me.tdbcPreparerID)
        Me.grpVoucher.Controls.Add(Me.txtVoucherTypeName)
        Me.grpVoucher.Controls.Add(Me.btnSetNewKey)
        Me.grpVoucher.Controls.Add(Me.c1dateVoucherDate)
        Me.grpVoucher.Controls.Add(Me.tdbcVoucherTypeID)
        Me.grpVoucher.Controls.Add(Me.txtNote)
        Me.grpVoucher.Controls.Add(Me.txtProductVoucherNo)
        Me.grpVoucher.Controls.Add(Me.lblVoucherNo)
        Me.grpVoucher.Controls.Add(Me.lblVoucherDate)
        Me.grpVoucher.Controls.Add(Me.lblVoucherDesc)
        Me.grpVoucher.Controls.Add(Me.lblVoucherTypeID)
        Me.grpVoucher.Controls.Add(Me.lblPreparerID)
        Me.grpVoucher.Controls.Add(Me.txtPreparerName)
        Me.grpVoucher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpVoucher.Location = New System.Drawing.Point(8, 67)
        Me.grpVoucher.Name = "grpVoucher"
        Me.grpVoucher.Size = New System.Drawing.Size(614, 128)
        Me.grpVoucher.TabIndex = 2
        Me.grpVoucher.TabStop = false
        Me.grpVoucher.Text = "Chứng từ"
        '
        'tdbcPreparerID
        '
        Me.tdbcPreparerID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPreparerID.AllowColMove = false
        Me.tdbcPreparerID.AllowSort = false
        Me.tdbcPreparerID.AlternatingRows = true
        Me.tdbcPreparerID.AutoCompletion = true
        Me.tdbcPreparerID.AutoDropDown = true
        Me.tdbcPreparerID.Caption = ""
        Me.tdbcPreparerID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPreparerID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPreparerID.DisplayMember = "EmployeeID"
        Me.tdbcPreparerID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPreparerID.DropDownWidth = 400
        Me.tdbcPreparerID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPreparerID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPreparerID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPreparerID.EmptyRows = true
        Me.tdbcPreparerID.ExtendRightColumn = true
        Me.tdbcPreparerID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tdbcPreparerID.Images.Add(CType(resources.GetObject("tdbcPreparerID.Images"),System.Drawing.Image))
        Me.tdbcPreparerID.Location = New System.Drawing.Point(132, 98)
        Me.tdbcPreparerID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcPreparerID.MaxDropDownItems = CType(8,Short)
        Me.tdbcPreparerID.MaxLength = 32767
        Me.tdbcPreparerID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPreparerID.Name = "tdbcPreparerID"
        Me.tdbcPreparerID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPreparerID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPreparerID.Size = New System.Drawing.Size(141, 21)
        Me.tdbcPreparerID.TabIndex = 5
        Me.tdbcPreparerID.ValueMember = "EmployeeID"
        Me.tdbcPreparerID.PropBag = resources.GetString("tdbcPreparerID.PropBag")
        '
        'txtVoucherTypeName
        '
        Me.txtVoucherTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtVoucherTypeName.Location = New System.Drawing.Point(279, 17)
        Me.txtVoucherTypeName.Name = "txtVoucherTypeName"
        Me.txtVoucherTypeName.ReadOnly = true
        Me.txtVoucherTypeName.Size = New System.Drawing.Size(321, 20)
        Me.txtVoucherTypeName.TabIndex = 2
        Me.txtVoucherTypeName.TabStop = false
        '
        'btnSetNewKey
        '
        Me.btnSetNewKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnSetNewKey.Image = Global.D45D0240.My.Resources.Resources.KEY
        Me.btnSetNewKey.Location = New System.Drawing.Point(279, 45)
        Me.btnSetNewKey.Name = "btnSetNewKey"
        Me.btnSetNewKey.Size = New System.Drawing.Size(24, 22)
        Me.btnSetNewKey.TabIndex = 2
        Me.btnSetNewKey.TabStop = false
        Me.btnSetNewKey.UseVisualStyleBackColor = true
        '
        'c1dateVoucherDate
        '
        Me.c1dateVoucherDate.AutoSize = false
        Me.c1dateVoucherDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateVoucherDate.EmptyAsNull = true
        Me.c1dateVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.c1dateVoucherDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateVoucherDate.Location = New System.Drawing.Point(460, 45)
        Me.c1dateVoucherDate.Name = "c1dateVoucherDate"
        Me.c1dateVoucherDate.Size = New System.Drawing.Size(140, 22)
        Me.c1dateVoucherDate.TabIndex = 3
        Me.c1dateVoucherDate.Tag = Nothing
        Me.c1dateVoucherDate.TrimStart = true
        Me.c1dateVoucherDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'tdbcVoucherTypeID
        '
        Me.tdbcVoucherTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcVoucherTypeID.AllowColMove = false
        Me.tdbcVoucherTypeID.AllowSort = false
        Me.tdbcVoucherTypeID.AlternatingRows = true
        Me.tdbcVoucherTypeID.AutoCompletion = true
        Me.tdbcVoucherTypeID.AutoDropDown = true
        Me.tdbcVoucherTypeID.Caption = ""
        Me.tdbcVoucherTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcVoucherTypeID.ColumnWidth = 100
        Me.tdbcVoucherTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcVoucherTypeID.DisplayMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcVoucherTypeID.DropDownWidth = 300
        Me.tdbcVoucherTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcVoucherTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcVoucherTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcVoucherTypeID.EmptyRows = true
        Me.tdbcVoucherTypeID.ExtendRightColumn = true
        Me.tdbcVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tdbcVoucherTypeID.Images.Add(CType(resources.GetObject("tdbcVoucherTypeID.Images"),System.Drawing.Image))
        Me.tdbcVoucherTypeID.Location = New System.Drawing.Point(133, 16)
        Me.tdbcVoucherTypeID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcVoucherTypeID.MaxDropDownItems = CType(8,Short)
        Me.tdbcVoucherTypeID.MaxLength = 32767
        Me.tdbcVoucherTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcVoucherTypeID.Name = "tdbcVoucherTypeID"
        Me.tdbcVoucherTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcVoucherTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcVoucherTypeID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcVoucherTypeID.TabIndex = 0
        Me.tdbcVoucherTypeID.ValueMember = "VoucherTypeID"
        Me.tdbcVoucherTypeID.PropBag = resources.GetString("tdbcVoucherTypeID.PropBag")
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtNote.Location = New System.Drawing.Point(133, 72)
        Me.txtNote.MaxLength = 150
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(467, 20)
        Me.txtNote.TabIndex = 4
        '
        'txtProductVoucherNo
        '
        Me.txtProductVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtProductVoucherNo.Location = New System.Drawing.Point(133, 46)
        Me.txtProductVoucherNo.MaxLength = 20
        Me.txtProductVoucherNo.Name = "txtProductVoucherNo"
        Me.txtProductVoucherNo.Size = New System.Drawing.Size(140, 20)
        Me.txtProductVoucherNo.TabIndex = 1
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = true
        Me.lblVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVoucherNo.Location = New System.Drawing.Point(25, 50)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVoucherNo.TabIndex = 3
        Me.lblVoucherNo.Text = "Số phiếu"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoucherDate
        '
        Me.lblVoucherDate.AutoSize = true
        Me.lblVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVoucherDate.Location = New System.Drawing.Point(343, 50)
        Me.lblVoucherDate.Name = "lblVoucherDate"
        Me.lblVoucherDate.Size = New System.Drawing.Size(61, 13)
        Me.lblVoucherDate.TabIndex = 6
        Me.lblVoucherDate.Text = "Ngày phiếu"
        Me.lblVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoucherDesc
        '
        Me.lblVoucherDesc.AutoSize = true
        Me.lblVoucherDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVoucherDesc.Location = New System.Drawing.Point(25, 76)
        Me.lblVoucherDesc.Name = "lblVoucherDesc"
        Me.lblVoucherDesc.Size = New System.Drawing.Size(48, 13)
        Me.lblVoucherDesc.TabIndex = 8
        Me.lblVoucherDesc.Text = "Diễn giải"
        Me.lblVoucherDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVoucherTypeID
        '
        Me.lblVoucherTypeID.AutoSize = true
        Me.lblVoucherTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblVoucherTypeID.Location = New System.Drawing.Point(25, 21)
        Me.lblVoucherTypeID.Name = "lblVoucherTypeID"
        Me.lblVoucherTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblVoucherTypeID.TabIndex = 0
        Me.lblVoucherTypeID.Text = "Loại phiếu"
        Me.lblVoucherTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPreparerID
        '
        Me.lblPreparerID.AutoSize = true
        Me.lblPreparerID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblPreparerID.Location = New System.Drawing.Point(25, 103)
        Me.lblPreparerID.Name = "lblPreparerID"
        Me.lblPreparerID.Size = New System.Drawing.Size(52, 13)
        Me.lblPreparerID.TabIndex = 10
        Me.lblPreparerID.Text = "Người lập"
        Me.lblPreparerID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPreparerName
        '
        Me.txtPreparerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtPreparerName.Location = New System.Drawing.Point(279, 99)
        Me.txtPreparerName.Name = "txtPreparerName"
        Me.txtPreparerName.ReadOnly = true
        Me.txtPreparerName.Size = New System.Drawing.Size(321, 20)
        Me.txtPreparerName.TabIndex = 12
        Me.txtPreparerName.TabStop = false
        '
        'grpAttendance
        '
        Me.grpAttendance.Controls.Add(Me.c1dateDateTo)
        Me.grpAttendance.Controls.Add(Me.c1dateDateFrom)
        Me.grpAttendance.Controls.Add(Me.lblteDateFrom)
        Me.grpAttendance.Controls.Add(Me.lblteDateTo)
        Me.grpAttendance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpAttendance.Location = New System.Drawing.Point(8, 273)
        Me.grpAttendance.Name = "grpAttendance"
        Me.grpAttendance.Size = New System.Drawing.Size(611, 49)
        Me.grpAttendance.TabIndex = 4
        Me.grpAttendance.TabStop = false
        Me.grpAttendance.Text = "Thống kê cho khoảng thời gian"
        '
        'c1dateDateTo
        '
        Me.c1dateDateTo.AutoSize = false
        Me.c1dateDateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateTo.EmptyAsNull = true
        Me.c1dateDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.c1dateDateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateTo.Location = New System.Drawing.Point(437, 20)
        Me.c1dateDateTo.Name = "c1dateDateTo"
        Me.c1dateDateTo.Size = New System.Drawing.Size(140, 22)
        Me.c1dateDateTo.TabIndex = 1
        Me.c1dateDateTo.Tag = Nothing
        Me.c1dateDateTo.TrimStart = true
        Me.c1dateDateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'c1dateDateFrom
        '
        Me.c1dateDateFrom.AutoSize = false
        Me.c1dateDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateFrom.EmptyAsNull = true
        Me.c1dateDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.c1dateDateFrom.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateFrom.Location = New System.Drawing.Point(132, 20)
        Me.c1dateDateFrom.Name = "c1dateDateFrom"
        Me.c1dateDateFrom.Size = New System.Drawing.Size(140, 22)
        Me.c1dateDateFrom.TabIndex = 0
        Me.c1dateDateFrom.Tag = Nothing
        Me.c1dateDateFrom.TrimStart = true
        Me.c1dateDateFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteDateFrom
        '
        Me.lblteDateFrom.AutoSize = true
        Me.lblteDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblteDateFrom.Location = New System.Drawing.Point(25, 25)
        Me.lblteDateFrom.Name = "lblteDateFrom"
        Me.lblteDateFrom.Size = New System.Drawing.Size(46, 13)
        Me.lblteDateFrom.TabIndex = 0
        Me.lblteDateFrom.Text = "Từ ngày"
        Me.lblteDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteDateTo
        '
        Me.lblteDateTo.AutoSize = true
        Me.lblteDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblteDateTo.Location = New System.Drawing.Point(343, 25)
        Me.lblteDateTo.Name = "lblteDateTo"
        Me.lblteDateTo.Size = New System.Drawing.Size(53, 13)
        Me.lblteDateTo.TabIndex = 2
        Me.lblteDateTo.Text = "Đến ngày"
        Me.lblteDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpCriate
        '
        Me.grpCriate.Controls.Add(Me.tdbcBlockID)
        Me.grpCriate.Controls.Add(Me.tdbcTeamID)
        Me.grpCriate.Controls.Add(Me.tdbcDepartmentID)
        Me.grpCriate.Controls.Add(Me.lblDepartmentID)
        Me.grpCriate.Controls.Add(Me.lblTeamID)
        Me.grpCriate.Controls.Add(Me.lblBlockID)
        Me.grpCriate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpCriate.Location = New System.Drawing.Point(8, 328)
        Me.grpCriate.Name = "grpCriate"
        Me.grpCriate.Size = New System.Drawing.Size(611, 79)
        Me.grpCriate.TabIndex = 5
        Me.grpCriate.TabStop = false
        Me.grpCriate.Text = "Điều kiện"
        '
        'tdbcBlockID
        '
        Me.tdbcBlockID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcBlockID.AllowColMove = false
        Me.tdbcBlockID.AllowSort = false
        Me.tdbcBlockID.AlternatingRows = true
        Me.tdbcBlockID.AutoCompletion = true
        Me.tdbcBlockID.AutoDropDown = true
        Me.tdbcBlockID.Caption = ""
        Me.tdbcBlockID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcBlockID.ColumnWidth = 100
        Me.tdbcBlockID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcBlockID.DisplayMember = "BlockName"
        Me.tdbcBlockID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcBlockID.DropDownWidth = 350
        Me.tdbcBlockID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcBlockID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcBlockID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcBlockID.EmptyRows = true
        Me.tdbcBlockID.ExtendRightColumn = true
        Me.tdbcBlockID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcBlockID.Images.Add(CType(resources.GetObject("tdbcBlockID.Images"),System.Drawing.Image))
        Me.tdbcBlockID.Location = New System.Drawing.Point(132, 15)
        Me.tdbcBlockID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcBlockID.MaxDropDownItems = CType(8,Short)
        Me.tdbcBlockID.MaxLength = 32767
        Me.tdbcBlockID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcBlockID.Name = "tdbcBlockID"
        Me.tdbcBlockID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcBlockID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcBlockID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcBlockID.TabIndex = 0
        Me.tdbcBlockID.ValueMember = "BlockID"
        Me.tdbcBlockID.PropBag = resources.GetString("tdbcBlockID.PropBag")
        '
        'tdbcTeamID
        '
        Me.tdbcTeamID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTeamID.AllowColMove = false
        Me.tdbcTeamID.AllowSort = false
        Me.tdbcTeamID.AlternatingRows = true
        Me.tdbcTeamID.AutoCompletion = true
        Me.tdbcTeamID.AutoDropDown = true
        Me.tdbcTeamID.AutoSelect = true
        Me.tdbcTeamID.Caption = ""
        Me.tdbcTeamID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTeamID.ColumnWidth = 100
        Me.tdbcTeamID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTeamID.DisplayMember = "TeamName"
        Me.tdbcTeamID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTeamID.DropDownWidth = 400
        Me.tdbcTeamID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTeamID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTeamID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTeamID.EmptyRows = true
        Me.tdbcTeamID.ExtendRightColumn = true
        Me.tdbcTeamID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tdbcTeamID.Images.Add(CType(resources.GetObject("tdbcTeamID.Images"),System.Drawing.Image))
        Me.tdbcTeamID.Location = New System.Drawing.Point(132, 44)
        Me.tdbcTeamID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcTeamID.MaxDropDownItems = CType(8,Short)
        Me.tdbcTeamID.MaxLength = 32767
        Me.tdbcTeamID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTeamID.Name = "tdbcTeamID"
        Me.tdbcTeamID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTeamID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTeamID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcTeamID.TabIndex = 2
        Me.tdbcTeamID.ValueMember = "TeamID"
        Me.tdbcTeamID.PropBag = resources.GetString("tdbcTeamID.PropBag")
        '
        'tdbcDepartmentID
        '
        Me.tdbcDepartmentID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDepartmentID.AllowColMove = false
        Me.tdbcDepartmentID.AllowSort = false
        Me.tdbcDepartmentID.AlternatingRows = true
        Me.tdbcDepartmentID.AutoCompletion = true
        Me.tdbcDepartmentID.AutoDropDown = true
        Me.tdbcDepartmentID.AutoSelect = true
        Me.tdbcDepartmentID.Caption = ""
        Me.tdbcDepartmentID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDepartmentID.ColumnWidth = 100
        Me.tdbcDepartmentID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDepartmentID.DisplayMember = "DepartmentName"
        Me.tdbcDepartmentID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDepartmentID.DropDownWidth = 400
        Me.tdbcDepartmentID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDepartmentID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDepartmentID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDepartmentID.EmptyRows = true
        Me.tdbcDepartmentID.ExtendRightColumn = true
        Me.tdbcDepartmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.tdbcDepartmentID.Images.Add(CType(resources.GetObject("tdbcDepartmentID.Images"),System.Drawing.Image))
        Me.tdbcDepartmentID.Location = New System.Drawing.Point(437, 15)
        Me.tdbcDepartmentID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcDepartmentID.MaxDropDownItems = CType(8,Short)
        Me.tdbcDepartmentID.MaxLength = 32767
        Me.tdbcDepartmentID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDepartmentID.Name = "tdbcDepartmentID"
        Me.tdbcDepartmentID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDepartmentID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDepartmentID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcDepartmentID.TabIndex = 1
        Me.tdbcDepartmentID.ValueMember = "DepartmentID"
        Me.tdbcDepartmentID.PropBag = resources.GetString("tdbcDepartmentID.PropBag")
        '
        'lblDepartmentID
        '
        Me.lblDepartmentID.AutoSize = true
        Me.lblDepartmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblDepartmentID.Location = New System.Drawing.Point(343, 20)
        Me.lblDepartmentID.Name = "lblDepartmentID"
        Me.lblDepartmentID.Size = New System.Drawing.Size(59, 13)
        Me.lblDepartmentID.TabIndex = 3
        Me.lblDepartmentID.Text = "Phòng ban"
        Me.lblDepartmentID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTeamID
        '
        Me.lblTeamID.AutoSize = true
        Me.lblTeamID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTeamID.Location = New System.Drawing.Point(24, 49)
        Me.lblTeamID.Name = "lblTeamID"
        Me.lblTeamID.Size = New System.Drawing.Size(49, 13)
        Me.lblTeamID.TabIndex = 6
        Me.lblTeamID.Text = "Tổ nhóm"
        Me.lblTeamID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblBlockID
        '
        Me.lblBlockID.AutoSize = true
        Me.lblBlockID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblBlockID.Location = New System.Drawing.Point(25, 23)
        Me.lblBlockID.Name = "lblBlockID"
        Me.lblBlockID.Size = New System.Drawing.Size(28, 13)
        Me.lblBlockID.TabIndex = 8
        Me.lblBlockID.Text = "Khối"
        Me.lblBlockID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAttendance
        '
        Me.btnAttendance.Location = New System.Drawing.Point(8, 413)
        Me.btnAttendance.Name = "btnAttendance"
        Me.btnAttendance.Size = New System.Drawing.Size(128, 22)
        Me.btnAttendance.TabIndex = 9
        Me.btnAttendance.Text = "Thống kê sản phẩm"
        Me.btnAttendance.UseVisualStyleBackColor = true
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(543, 413)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = true
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(461, 413)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = true
        '
        'tdbcTransTypeID
        '
        Me.tdbcTransTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransTypeID.AllowColMove = false
        Me.tdbcTransTypeID.AllowSort = false
        Me.tdbcTransTypeID.AlternatingRows = true
        Me.tdbcTransTypeID.AutoCompletion = true
        Me.tdbcTransTypeID.AutoDropDown = true
        Me.tdbcTransTypeID.Caption = ""
        Me.tdbcTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransTypeID.ColumnWidth = 100
        Me.tdbcTransTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransTypeID.DisplayMember = "TransTypeID"
        Me.tdbcTransTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTransTypeID.DropDownWidth = 300
        Me.tdbcTransTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransTypeID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTransTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransTypeID.EmptyRows = true
        Me.tdbcTransTypeID.ExtendRightColumn = true
        Me.tdbcTransTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcTransTypeID.Images.Add(CType(resources.GetObject("tdbcTransTypeID.Images"),System.Drawing.Image))
        Me.tdbcTransTypeID.Location = New System.Drawing.Point(141, 7)
        Me.tdbcTransTypeID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcTransTypeID.MaxDropDownItems = CType(8,Short)
        Me.tdbcTransTypeID.MaxLength = 32767
        Me.tdbcTransTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransTypeID.Name = "tdbcTransTypeID"
        Me.tdbcTransTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcTransTypeID.TabIndex = 0
        Me.tdbcTransTypeID.ValueMember = "TransTypeID"
        Me.tdbcTransTypeID.PropBag = resources.GetString("tdbcTransTypeID.PropBag")
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = true
        Me.lblTransTypeID.Location = New System.Drawing.Point(16, 12)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 0
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTransTypeName.Location = New System.Drawing.Point(287, 7)
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.ReadOnly = true
        Me.txtTransTypeName.Size = New System.Drawing.Size(332, 20)
        Me.txtTransTypeName.TabIndex = 2
        Me.txtTransTypeName.TabStop = false
        '
        'tdbcDAGroupID
        '
        Me.tdbcDAGroupID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDAGroupID.AllowColMove = false
        Me.tdbcDAGroupID.AllowSort = false
        Me.tdbcDAGroupID.AlternatingRows = true
        Me.tdbcDAGroupID.AutoCompletion = true
        Me.tdbcDAGroupID.AutoDropDown = true
        Me.tdbcDAGroupID.Caption = ""
        Me.tdbcDAGroupID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDAGroupID.ColumnWidth = 100
        Me.tdbcDAGroupID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDAGroupID.DisplayMember = "DAGroupID"
        Me.tdbcDAGroupID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDAGroupID.DropDownWidth = 300
        Me.tdbcDAGroupID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDAGroupID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDAGroupID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDAGroupID.Enabled = false
        Me.tdbcDAGroupID.ExtendRightColumn = true
        Me.tdbcDAGroupID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDAGroupID.Images.Add(CType(resources.GetObject("tdbcDAGroupID.Images"),System.Drawing.Image))
        Me.tdbcDAGroupID.Location = New System.Drawing.Point(141, 35)
        Me.tdbcDAGroupID.MatchEntryTimeout = CType(2000,Long)
        Me.tdbcDAGroupID.MaxDropDownItems = CType(8,Short)
        Me.tdbcDAGroupID.MaxLength = 32767
        Me.tdbcDAGroupID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDAGroupID.Name = "tdbcDAGroupID"
        Me.tdbcDAGroupID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDAGroupID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDAGroupID.Size = New System.Drawing.Size(140, 21)
        Me.tdbcDAGroupID.TabIndex = 1
        Me.tdbcDAGroupID.ValueMember = "DAGroupID"
        Me.tdbcDAGroupID.PropBag = resources.GetString("tdbcDAGroupID.PropBag")
        '
        'lblDAGroupID
        '
        Me.lblDAGroupID.AllowDrop = true
        Me.lblDAGroupID.Location = New System.Drawing.Point(16, 40)
        Me.lblDAGroupID.Name = "lblDAGroupID"
        Me.lblDAGroupID.Size = New System.Drawing.Size(116, 13)
        Me.lblDAGroupID.TabIndex = 3
        Me.lblDAGroupID.Text = "Nhóm truy cập dữ liệu"
        Me.lblDAGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDAGroupName
        '
        Me.txtDAGroupName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtDAGroupName.Location = New System.Drawing.Point(287, 35)
        Me.txtDAGroupName.Name = "txtDAGroupName"
        Me.txtDAGroupName.ReadOnly = true
        Me.txtDAGroupName.Size = New System.Drawing.Size(332, 20)
        Me.txtDAGroupName.TabIndex = 5
        Me.txtDAGroupName.TabStop = false
        '
        'grpMethod
        '
        Me.grpMethod.Controls.Add(Me.optMethod3)
        Me.grpMethod.Controls.Add(Me.chkIsSpec)
        Me.grpMethod.Controls.Add(Me.optMethod2)
        Me.grpMethod.Controls.Add(Me.optMethod1)
        Me.grpMethod.Controls.Add(Me.optMethod0)
        Me.grpMethod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.grpMethod.Location = New System.Drawing.Point(8, 201)
        Me.grpMethod.Name = "grpMethod"
        Me.grpMethod.Size = New System.Drawing.Size(611, 66)
        Me.grpMethod.TabIndex = 3
        Me.grpMethod.TabStop = false
        Me.grpMethod.Text = "Phương pháp thống kê sản phẩm"
        '
        'optMethod3
        '
        Me.optMethod3.AutoSize = true
        Me.optMethod3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.optMethod3.Location = New System.Drawing.Point(28, 42)
        Me.optMethod3.Name = "optMethod3"
        Me.optMethod3.Size = New System.Drawing.Size(129, 17)
        Me.optMethod3.TabIndex = 3
        Me.optMethod3.TabStop = true
        Me.optMethod3.Text = "Theo nhóm nhân viên"
        Me.optMethod3.UseVisualStyleBackColor = true
        '
        'chkIsSpec
        '
        Me.chkIsSpec.AutoSize = true
        Me.chkIsSpec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkIsSpec.Location = New System.Drawing.Point(226, 43)
        Me.chkIsSpec.Name = "chkIsSpec"
        Me.chkIsSpec.Size = New System.Drawing.Size(192, 17)
        Me.chkIsSpec.TabIndex = 4
        Me.chkIsSpec.Text = "Thống kê sản phẩm theo quy cách"
        Me.chkIsSpec.UseVisualStyleBackColor = true
        '
        'optMethod2
        '
        Me.optMethod2.AutoSize = true
        Me.optMethod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.optMethod2.Location = New System.Drawing.Point(437, 19)
        Me.optMethod2.Name = "optMethod2"
        Me.optMethod2.Size = New System.Drawing.Size(110, 17)
        Me.optMethod2.TabIndex = 2
        Me.optMethod2.Text = "Theo nhóm CCSP"
        Me.optMethod2.UseVisualStyleBackColor = true
        '
        'optMethod1
        '
        Me.optMethod1.AutoSize = true
        Me.optMethod1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.optMethod1.Location = New System.Drawing.Point(226, 20)
        Me.optMethod1.Name = "optMethod1"
        Me.optMethod1.Size = New System.Drawing.Size(147, 17)
        Me.optMethod1.TabIndex = 1
        Me.optMethod1.Text = "Theo phòng ban/tổ nhóm"
        Me.optMethod1.UseVisualStyleBackColor = true
        '
        'optMethod0
        '
        Me.optMethod0.AutoSize = true
        Me.optMethod0.Checked = true
        Me.optMethod0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.optMethod0.Location = New System.Drawing.Point(28, 20)
        Me.optMethod0.Name = "optMethod0"
        Me.optMethod0.Size = New System.Drawing.Size(100, 17)
        Me.optMethod0.TabIndex = 0
        Me.optMethod0.TabStop = true
        Me.optMethod0.Text = "Theo nhân viên"
        Me.optMethod0.UseVisualStyleBackColor = true
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(379, 413)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = true
        '
        'D45F2001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(631, 443)
        Me.Controls.Add(Me.grpMethod)
        Me.Controls.Add(Me.tdbcDAGroupID)
        Me.Controls.Add(Me.tdbcTransTypeID)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAttendance)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpCriate)
        Me.Controls.Add(Me.grpAttendance)
        Me.Controls.Add(Me.grpVoucher)
        Me.Controls.Add(Me.lblTransTypeID)
        Me.Controls.Add(Me.txtTransTypeName)
        Me.Controls.Add(Me.lblDAGroupID)
        Me.Controls.Add(Me.txtDAGroupName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "D45F2001"
        Me.ShowInTaskbar = false
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp phiÕu thçng k£ s¶n phÈm tÛnh l§¥ng"
        Me.grpVoucher.ResumeLayout(false)
        Me.grpVoucher.PerformLayout
        CType(Me.tdbcPreparerID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.c1dateVoucherDate,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcVoucherTypeID,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpAttendance.ResumeLayout(false)
        Me.grpAttendance.PerformLayout
        CType(Me.c1dateDateTo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.c1dateDateFrom,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpCriate.ResumeLayout(false)
        Me.grpCriate.PerformLayout
        CType(Me.tdbcBlockID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcTeamID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcDepartmentID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcTransTypeID,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.tdbcDAGroupID,System.ComponentModel.ISupportInitialize).EndInit
        Me.grpMethod.ResumeLayout(false)
        Me.grpMethod.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Private WithEvents grpVoucher As System.Windows.Forms.GroupBox
    Private WithEvents btnSetNewKey As System.Windows.Forms.Button
    Private WithEvents c1dateVoucherDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents tdbcVoucherTypeID As C1.Win.C1List.C1Combo
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents txtProductVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents lblVoucherDate As System.Windows.Forms.Label
    Private WithEvents lblVoucherDesc As System.Windows.Forms.Label
    Private WithEvents lblVoucherTypeID As System.Windows.Forms.Label
    Private WithEvents txtVoucherTypeName As System.Windows.Forms.TextBox
    Private WithEvents grpAttendance As System.Windows.Forms.GroupBox
    Private WithEvents c1dateDateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1dateDateFrom As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteDateFrom As System.Windows.Forms.Label
    Private WithEvents lblteDateTo As System.Windows.Forms.Label
    Private WithEvents grpCriate As System.Windows.Forms.GroupBox
    Private WithEvents tdbcTeamID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcDepartmentID As C1.Win.C1List.C1Combo
    Private WithEvents lblDepartmentID As System.Windows.Forms.Label
    Private WithEvents lblTeamID As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnAttendance As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    'Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    'Private WithEvents mnuView As C1.Win.C1Command.C1Command
    'Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    'Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    'Friend WithEvents mnuAttendance As C1.Win.C1Command.C1CommandMenu
    'Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    'Friend WithEvents mnuAttendanceEmployee As C1.Win.C1Command.C1Command
    'Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    'Friend WithEvents mnuAttendanceProduct As C1.Win.C1Command.C1Command
    'Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
    'Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Friend WithEvents mnuAttendanceStage As C1.Win.C1Command.C1Command
    Private WithEvents tdbcPreparerID As C1.Win.C1List.C1Combo
    Private WithEvents lblPreparerID As System.Windows.Forms.Label
    Private WithEvents txtPreparerName As System.Windows.Forms.TextBox
    Private WithEvents tdbcTransTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
    Private WithEvents tdbcDAGroupID As C1.Win.C1List.C1Combo
    Private WithEvents lblDAGroupID As System.Windows.Forms.Label
    Private WithEvents txtDAGroupName As System.Windows.Forms.TextBox
    Friend WithEvents grpMethod As System.Windows.Forms.GroupBox
    Private WithEvents optMethod2 As System.Windows.Forms.RadioButton
    Private WithEvents optMethod1 As System.Windows.Forms.RadioButton
    Private WithEvents optMethod0 As System.Windows.Forms.RadioButton
    Private WithEvents chkIsSpec As System.Windows.Forms.CheckBox
    Private WithEvents optMethod3 As System.Windows.Forms.RadioButton
    Private WithEvents tdbcBlockID As C1.Win.C1List.C1Combo
    Private WithEvents lblBlockID As System.Windows.Forms.Label
End Class