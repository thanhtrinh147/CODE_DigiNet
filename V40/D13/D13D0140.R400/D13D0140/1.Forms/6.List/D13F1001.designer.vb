<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1001))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpAbsentType = New System.Windows.Forms.GroupBox
        Me.lblDecimals = New System.Windows.Forms.Label
        Me.cboDecimals = New System.Windows.Forms.ComboBox
        Me.grpClassification = New System.Windows.Forms.GroupBox
        Me.chkIsValue = New System.Windows.Forms.CheckBox
        Me.tdbcClassification = New C1.Win.C1List.C1Combo
        Me.chkIsClassification = New System.Windows.Forms.CheckBox
        Me.lblClassification = New System.Windows.Forms.Label
        Me.txtClassificationName = New System.Windows.Forms.TextBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtUnitID = New System.Windows.Forms.TextBox
        Me.txtOrders = New System.Windows.Forms.TextBox
        Me.txtLookup = New System.Windows.Forms.TextBox
        Me.txtAbsentTypeDateName = New System.Windows.Forms.TextBox
        Me.txtAbsentTypeDateID = New System.Windows.Forms.TextBox
        Me.lblAbsentTypeID = New System.Windows.Forms.Label
        Me.lblAbsentTypeName = New System.Windows.Forms.Label
        Me.lblLookup = New System.Windows.Forms.Label
        Me.lblOrders = New System.Windows.Forms.Label
        Me.lblUnitID = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnCofficientInfo = New System.Windows.Forms.Button
        Me.btnAbsentConversion = New System.Windows.Forms.Button
        Me.grpAbsentType.SuspendLayout()
        Me.grpClassification.SuspendLayout()
        CType(Me.tdbcClassification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpAbsentType
        '
        Me.grpAbsentType.Controls.Add(Me.lblDecimals)
        Me.grpAbsentType.Controls.Add(Me.cboDecimals)
        Me.grpAbsentType.Controls.Add(Me.grpClassification)
        Me.grpAbsentType.Controls.Add(Me.chkDisabled)
        Me.grpAbsentType.Controls.Add(Me.txtUnitID)
        Me.grpAbsentType.Controls.Add(Me.txtOrders)
        Me.grpAbsentType.Controls.Add(Me.txtLookup)
        Me.grpAbsentType.Controls.Add(Me.txtAbsentTypeDateName)
        Me.grpAbsentType.Controls.Add(Me.txtAbsentTypeDateID)
        Me.grpAbsentType.Controls.Add(Me.lblAbsentTypeID)
        Me.grpAbsentType.Controls.Add(Me.lblAbsentTypeName)
        Me.grpAbsentType.Controls.Add(Me.lblLookup)
        Me.grpAbsentType.Controls.Add(Me.lblOrders)
        Me.grpAbsentType.Controls.Add(Me.lblUnitID)
        Me.grpAbsentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpAbsentType.Location = New System.Drawing.Point(10, 9)
        Me.grpAbsentType.Name = "grpAbsentType"
        Me.grpAbsentType.Size = New System.Drawing.Size(478, 258)
        Me.grpAbsentType.TabIndex = 0
        Me.grpAbsentType.TabStop = False
        '
        'lblDecimals
        '
        Me.lblDecimals.AutoSize = True
        Me.lblDecimals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecimals.Location = New System.Drawing.Point(300, 139)
        Me.lblDecimals.Name = "lblDecimals"
        Me.lblDecimals.Size = New System.Drawing.Size(48, 13)
        Me.lblDecimals.TabIndex = 13
        Me.lblDecimals.Text = "Làm tròn"
        Me.lblDecimals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDecimals
        '
        Me.cboDecimals.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDecimals.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboDecimals.FormattingEnabled = True
        Me.cboDecimals.Items.AddRange(New Object() {"-5", "-4", "-3", "-2", "-1", "0", "1", "2", "3", "4", "5"})
        Me.cboDecimals.Location = New System.Drawing.Point(366, 135)
        Me.cboDecimals.Name = "cboDecimals"
        Me.cboDecimals.Size = New System.Drawing.Size(97, 22)
        Me.cboDecimals.TabIndex = 6
        '
        'grpClassification
        '
        Me.grpClassification.Controls.Add(Me.chkIsValue)
        Me.grpClassification.Controls.Add(Me.tdbcClassification)
        Me.grpClassification.Controls.Add(Me.chkIsClassification)
        Me.grpClassification.Controls.Add(Me.lblClassification)
        Me.grpClassification.Controls.Add(Me.txtClassificationName)
        Me.grpClassification.Location = New System.Drawing.Point(12, 172)
        Me.grpClassification.Name = "grpClassification"
        Me.grpClassification.Size = New System.Drawing.Size(460, 80)
        Me.grpClassification.TabIndex = 7
        Me.grpClassification.TabStop = False
        '
        'chkIsValue
        '
        Me.chkIsValue.AutoSize = True
        Me.chkIsValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsValue.Location = New System.Drawing.Point(8, 53)
        Me.chkIsValue.Name = "chkIsValue"
        Me.chkIsValue.Size = New System.Drawing.Size(149, 17)
        Me.chkIsValue.TabIndex = 3
        Me.chkIsValue.Text = "Hiển thị giá trị của mỗi loại"
        Me.chkIsValue.UseVisualStyleBackColor = True
        '
        'tdbcClassification
        '
        Me.tdbcClassification.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcClassification.AllowColMove = False
        Me.tdbcClassification.AllowSort = False
        Me.tdbcClassification.AlternatingRows = True
        Me.tdbcClassification.AutoCompletion = True
        Me.tdbcClassification.AutoDropDown = True
        Me.tdbcClassification.AutoSelect = True
        Me.tdbcClassification.Caption = ""
        Me.tdbcClassification.CaptionHeight = 17
        Me.tdbcClassification.CaptionStyle = Style1
        Me.tdbcClassification.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcClassification.ColumnCaptionHeight = 17
        Me.tdbcClassification.ColumnFooterHeight = 17
        Me.tdbcClassification.ColumnWidth = 100
        Me.tdbcClassification.ContentHeight = 17
        Me.tdbcClassification.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcClassification.DisplayMember = "ClassificationID"
        Me.tdbcClassification.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcClassification.DropDownWidth = 300
        Me.tdbcClassification.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcClassification.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcClassification.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcClassification.EditorHeight = 17
        Me.tdbcClassification.EmptyRows = True
        Me.tdbcClassification.EvenRowStyle = Style2
        Me.tdbcClassification.ExtendRightColumn = True
        Me.tdbcClassification.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcClassification.FooterStyle = Style3
        Me.tdbcClassification.HeadingStyle = Style4
        Me.tdbcClassification.HighLightRowStyle = Style5
        Me.tdbcClassification.Images.Add(CType(resources.GetObject("tdbcClassification.Images"), System.Drawing.Image))
        Me.tdbcClassification.ItemHeight = 15
        Me.tdbcClassification.Location = New System.Drawing.Point(127, 23)
        Me.tdbcClassification.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcClassification.MaxDropDownItems = CType(8, Short)
        Me.tdbcClassification.MaxLength = 32767
        Me.tdbcClassification.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcClassification.Name = "tdbcClassification"
        Me.tdbcClassification.OddRowStyle = Style6
        Me.tdbcClassification.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcClassification.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcClassification.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcClassification.SelectedStyle = Style7
        Me.tdbcClassification.Size = New System.Drawing.Size(121, 23)
        Me.tdbcClassification.Style = Style8
        Me.tdbcClassification.TabIndex = 1
        Me.tdbcClassification.ValueMember = "ClassificationID"
        Me.tdbcClassification.PropBag = resources.GetString("tdbcClassification.PropBag")
        '
        'chkIsClassification
        '
        Me.chkIsClassification.AutoSize = True
        Me.chkIsClassification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsClassification.Location = New System.Drawing.Point(6, 0)
        Me.chkIsClassification.Name = "chkIsClassification"
        Me.chkIsClassification.Size = New System.Drawing.Size(108, 17)
        Me.chkIsClassification.TabIndex = 0
        Me.chkIsClassification.Text = "Đánh giá xếp loại"
        Me.chkIsClassification.UseVisualStyleBackColor = True
        '
        'lblClassification
        '
        Me.lblClassification.AutoSize = True
        Me.lblClassification.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClassification.Location = New System.Drawing.Point(17, 27)
        Me.lblClassification.Name = "lblClassification"
        Me.lblClassification.Size = New System.Drawing.Size(72, 13)
        Me.lblClassification.TabIndex = 0
        Me.lblClassification.Text = "Loại đánh giá"
        Me.lblClassification.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClassificationName
        '
        Me.txtClassificationName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtClassificationName.Location = New System.Drawing.Point(254, 23)
        Me.txtClassificationName.Name = "txtClassificationName"
        Me.txtClassificationName.ReadOnly = True
        Me.txtClassificationName.Size = New System.Drawing.Size(197, 22)
        Me.txtClassificationName.TabIndex = 2
        Me.txtClassificationName.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(369, 25)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtUnitID
        '
        Me.txtUnitID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtUnitID.Location = New System.Drawing.Point(139, 135)
        Me.txtUnitID.MaxLength = 20
        Me.txtUnitID.Name = "txtUnitID"
        Me.txtUnitID.Size = New System.Drawing.Size(121, 22)
        Me.txtUnitID.TabIndex = 5
        '
        'txtOrders
        '
        Me.txtOrders.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtOrders.Location = New System.Drawing.Point(139, 107)
        Me.txtOrders.MaxLength = 3
        Me.txtOrders.Name = "txtOrders"
        Me.txtOrders.Size = New System.Drawing.Size(121, 22)
        Me.txtOrders.TabIndex = 4
        '
        'txtLookup
        '
        Me.txtLookup.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtLookup.Location = New System.Drawing.Point(139, 78)
        Me.txtLookup.MaxLength = 20
        Me.txtLookup.Name = "txtLookup"
        Me.txtLookup.Size = New System.Drawing.Size(121, 22)
        Me.txtLookup.TabIndex = 3
        '
        'txtAbsentTypeDateName
        '
        Me.txtAbsentTypeDateName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentTypeDateName.Location = New System.Drawing.Point(139, 50)
        Me.txtAbsentTypeDateName.MaxLength = 50
        Me.txtAbsentTypeDateName.Name = "txtAbsentTypeDateName"
        Me.txtAbsentTypeDateName.Size = New System.Drawing.Size(324, 22)
        Me.txtAbsentTypeDateName.TabIndex = 2
        '
        'txtAbsentTypeDateID
        '
        Me.txtAbsentTypeDateID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAbsentTypeDateID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtAbsentTypeDateID.Location = New System.Drawing.Point(139, 22)
        Me.txtAbsentTypeDateID.MaxLength = 20
        Me.txtAbsentTypeDateID.Name = "txtAbsentTypeDateID"
        Me.txtAbsentTypeDateID.Size = New System.Drawing.Size(121, 22)
        Me.txtAbsentTypeDateID.TabIndex = 0
        '
        'lblAbsentTypeID
        '
        Me.lblAbsentTypeID.AutoSize = True
        Me.lblAbsentTypeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbsentTypeID.Location = New System.Drawing.Point(17, 26)
        Me.lblAbsentTypeID.Name = "lblAbsentTypeID"
        Me.lblAbsentTypeID.Size = New System.Drawing.Size(22, 13)
        Me.lblAbsentTypeID.TabIndex = 7
        Me.lblAbsentTypeID.Text = "Mã"
        Me.lblAbsentTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAbsentTypeName
        '
        Me.lblAbsentTypeName.AutoSize = True
        Me.lblAbsentTypeName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAbsentTypeName.Location = New System.Drawing.Point(17, 55)
        Me.lblAbsentTypeName.Name = "lblAbsentTypeName"
        Me.lblAbsentTypeName.Size = New System.Drawing.Size(48, 13)
        Me.lblAbsentTypeName.TabIndex = 8
        Me.lblAbsentTypeName.Text = "Diễn giải"
        Me.lblAbsentTypeName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLookup
        '
        Me.lblLookup.AutoSize = True
        Me.lblLookup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLookup.Location = New System.Drawing.Point(17, 83)
        Me.lblLookup.Name = "lblLookup"
        Me.lblLookup.Size = New System.Drawing.Size(41, 13)
        Me.lblLookup.TabIndex = 9
        Me.lblLookup.Text = "Tên tắt"
        Me.lblLookup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOrders
        '
        Me.lblOrders.AutoSize = True
        Me.lblOrders.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOrders.Location = New System.Drawing.Point(17, 112)
        Me.lblOrders.Name = "lblOrders"
        Me.lblOrders.Size = New System.Drawing.Size(75, 13)
        Me.lblOrders.TabIndex = 10
        Me.lblOrders.Text = "Thứ tự hiển thị"
        Me.lblOrders.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUnitID
        '
        Me.lblUnitID.AutoSize = True
        Me.lblUnitID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnitID.Location = New System.Drawing.Point(17, 139)
        Me.lblUnitID.Name = "lblUnitID"
        Me.lblUnitID.Size = New System.Drawing.Size(60, 13)
        Me.lblUnitID.TabIndex = 11
        Me.lblUnitID.Text = "Đơn vị tính"
        Me.lblUnitID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(252, 273)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(412, 273)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(332, 273)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnCofficientInfo
        '
        Me.btnCofficientInfo.Location = New System.Drawing.Point(10, 273)
        Me.btnCofficientInfo.Name = "btnCofficientInfo"
        Me.btnCofficientInfo.Size = New System.Drawing.Size(107, 22)
        Me.btnCofficientInfo.TabIndex = 4
        Me.btnCofficientInfo.Text = "Thông tin &hệ số"
        Me.btnCofficientInfo.UseVisualStyleBackColor = True
        '
        'btnAbsentConversion
        '
        Me.btnAbsentConversion.Location = New System.Drawing.Point(124, 274)
        Me.btnAbsentConversion.Name = "btnAbsentConversion"
        Me.btnAbsentConversion.Size = New System.Drawing.Size(100, 22)
        Me.btnAbsentConversion.TabIndex = 5
        Me.btnAbsentConversion.Text = "&Quy đổi công"
        Me.btnAbsentConversion.UseVisualStyleBackColor = True
        Me.btnAbsentConversion.Visible = False
        '
        'D13F1001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 300)
        Me.Controls.Add(Me.btnAbsentConversion)
        Me.Controls.Add(Me.btnCofficientInfo)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpAbsentType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1001"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt Kho¶n ¢iÒu chÙnh thu nhËp - D13F1001"
        Me.grpAbsentType.ResumeLayout(False)
        Me.grpAbsentType.PerformLayout()
        Me.grpClassification.ResumeLayout(False)
        Me.grpClassification.PerformLayout()
        CType(Me.tdbcClassification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grpAbsentType As System.Windows.Forms.GroupBox
    Private WithEvents txtLookup As System.Windows.Forms.TextBox
    Private WithEvents txtAbsentTypeDateName As System.Windows.Forms.TextBox
    Private WithEvents txtAbsentTypeDateID As System.Windows.Forms.TextBox
    Private WithEvents lblAbsentTypeID As System.Windows.Forms.Label
    Private WithEvents lblAbsentTypeName As System.Windows.Forms.Label
    Private WithEvents lblLookup As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtUnitID As System.Windows.Forms.TextBox
    Private WithEvents txtOrders As System.Windows.Forms.TextBox
    Private WithEvents lblOrders As System.Windows.Forms.Label
    Private WithEvents lblUnitID As System.Windows.Forms.Label
    Private WithEvents grpClassification As System.Windows.Forms.GroupBox
    Private WithEvents chkIsClassification As System.Windows.Forms.CheckBox
    Private WithEvents tdbcClassification As C1.Win.C1List.C1Combo
    Private WithEvents chkIsValue As System.Windows.Forms.CheckBox
    Private WithEvents lblClassification As System.Windows.Forms.Label
    Private WithEvents txtClassificationName As System.Windows.Forms.TextBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents lblDecimals As System.Windows.Forms.Label
    Private WithEvents cboDecimals As System.Windows.Forms.ComboBox
    Private WithEvents btnCofficientInfo As System.Windows.Forms.Button
    Private WithEvents btnAbsentConversion As System.Windows.Forms.Button
End Class
