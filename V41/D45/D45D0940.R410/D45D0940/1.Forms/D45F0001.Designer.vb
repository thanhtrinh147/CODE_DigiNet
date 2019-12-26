<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F0001
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F0001))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tabSystem = New System.Windows.Forms.TabControl
        Me.TabPageMainInfo = New System.Windows.Forms.TabPage
        Me.chkIsWorkingHour = New System.Windows.Forms.CheckBox
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.lblDefaultDivision = New System.Windows.Forms.Label
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.txtDefaultPeriod = New System.Windows.Forms.TextBox
        Me.lblDefaultPeriod = New System.Windows.Forms.Label
        Me.txtPeriodNumber = New System.Windows.Forms.TextBox
        Me.lblNumberPeriod = New System.Windows.Forms.Label
        Me.txtDivisionName = New System.Windows.Forms.TextBox
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.grpInherite = New System.Windows.Forms.GroupBox
        Me.chkIsQC = New System.Windows.Forms.CheckBox
        Me.chkIsOQuantity = New System.Windows.Forms.CheckBox
        Me.tabSystem.SuspendLayout()
        Me.TabPageMainInfo.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.grpInherite.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(377, 234)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(460, 234)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabSystem
        '
        Me.tabSystem.Controls.Add(Me.TabPageMainInfo)
        Me.tabSystem.Controls.Add(Me.TabPage1)
        Me.tabSystem.Location = New System.Drawing.Point(4, 4)
        Me.tabSystem.Name = "tabSystem"
        Me.tabSystem.SelectedIndex = 0
        Me.tabSystem.Size = New System.Drawing.Size(536, 226)
        Me.tabSystem.TabIndex = 0
        '
        'TabPageMainInfo
        '
        Me.TabPageMainInfo.Controls.Add(Me.chkIsWorkingHour)
        Me.TabPageMainInfo.Controls.Add(Me.grp1)
        Me.TabPageMainInfo.Location = New System.Drawing.Point(4, 22)
        Me.TabPageMainInfo.Name = "TabPageMainInfo"
        Me.TabPageMainInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageMainInfo.Size = New System.Drawing.Size(528, 200)
        Me.TabPageMainInfo.TabIndex = 0
        Me.TabPageMainInfo.Text = "1. Thông tin chính"
        Me.TabPageMainInfo.UseVisualStyleBackColor = True
        '
        'chkIsWorkingHour
        '
        Me.chkIsWorkingHour.AutoSize = True
        Me.chkIsWorkingHour.Location = New System.Drawing.Point(6, 95)
        Me.chkIsWorkingHour.Name = "chkIsWorkingHour"
        Me.chkIsWorkingHour.Size = New System.Drawing.Size(226, 17)
        Me.chkIsWorkingHour.TabIndex = 1
        Me.chkIsWorkingHour.Text = "Chấm công sản phẩm theo số giờ làm việc"
        Me.chkIsWorkingHour.UseVisualStyleBackColor = True
        Me.chkIsWorkingHour.Visible = False
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lblDefaultDivision)
        Me.grp1.Controls.Add(Me.tdbcDivisionID)
        Me.grp1.Controls.Add(Me.txtDefaultPeriod)
        Me.grp1.Controls.Add(Me.lblDefaultPeriod)
        Me.grp1.Controls.Add(Me.txtPeriodNumber)
        Me.grp1.Controls.Add(Me.lblNumberPeriod)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(516, 83)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'lblDefaultDivision
        '
        Me.lblDefaultDivision.AutoSize = True
        Me.lblDefaultDivision.Location = New System.Drawing.Point(6, 23)
        Me.lblDefaultDivision.Name = "lblDefaultDivision"
        Me.lblDefaultDivision.Size = New System.Drawing.Size(85, 13)
        Me.lblDefaultDivision.TabIndex = 7
        Me.lblDefaultDivision.Text = "Đơn vị mặc định"
        Me.lblDefaultDivision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDivisionID
        '
        Me.tdbcDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDivisionID.AllowColMove = False
        Me.tdbcDivisionID.AllowSort = False
        Me.tdbcDivisionID.AlternatingRows = True
        Me.tdbcDivisionID.AutoCompletion = True
        Me.tdbcDivisionID.AutoDropDown = True
        Me.tdbcDivisionID.Caption = ""
        Me.tdbcDivisionID.CaptionHeight = 17
        Me.tdbcDivisionID.CaptionStyle = Style9
        Me.tdbcDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDivisionID.ColumnCaptionHeight = 17
        Me.tdbcDivisionID.ColumnFooterHeight = 17
        Me.tdbcDivisionID.ColumnWidth = 100
        Me.tdbcDivisionID.ContentHeight = 17
        Me.tdbcDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDivisionID.DisplayMember = "DivisionID"
        Me.tdbcDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDivisionID.DropDownWidth = 400
        Me.tdbcDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EditorHeight = 17
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.EvenRowStyle = Style10
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcDivisionID.FooterStyle = Style11
        Me.tdbcDivisionID.HeadingStyle = Style12
        Me.tdbcDivisionID.HighLightRowStyle = Style13
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.ItemHeight = 15
        Me.tdbcDivisionID.Location = New System.Drawing.Point(134, 19)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.OddRowStyle = Style14
        Me.tdbcDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.SelectedStyle = Style15
        Me.tdbcDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDivisionID.Style = Style16
        Me.tdbcDivisionID.TabIndex = 1
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'txtDefaultPeriod
        '
        Me.txtDefaultPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtDefaultPeriod.Location = New System.Drawing.Point(134, 47)
        Me.txtDefaultPeriod.Name = "txtDefaultPeriod"
        Me.txtDefaultPeriod.ReadOnly = True
        Me.txtDefaultPeriod.Size = New System.Drawing.Size(128, 22)
        Me.txtDefaultPeriod.TabIndex = 6
        '
        'lblDefaultPeriod
        '
        Me.lblDefaultPeriod.AutoSize = True
        Me.lblDefaultPeriod.Location = New System.Drawing.Point(6, 51)
        Me.lblDefaultPeriod.Name = "lblDefaultPeriod"
        Me.lblDefaultPeriod.Size = New System.Drawing.Size(105, 13)
        Me.lblDefaultPeriod.TabIndex = 5
        Me.lblDefaultPeriod.Text = "Kỳ kế toán mặc định"
        Me.lblDefaultPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPeriodNumber
        '
        Me.txtPeriodNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtPeriodNumber.Location = New System.Drawing.Point(387, 47)
        Me.txtPeriodNumber.Name = "txtPeriodNumber"
        Me.txtPeriodNumber.ReadOnly = True
        Me.txtPeriodNumber.Size = New System.Drawing.Size(121, 22)
        Me.txtPeriodNumber.TabIndex = 4
        Me.txtPeriodNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNumberPeriod
        '
        Me.lblNumberPeriod.AutoSize = True
        Me.lblNumberPeriod.Location = New System.Drawing.Point(279, 51)
        Me.lblNumberPeriod.Name = "lblNumberPeriod"
        Me.lblNumberPeriod.Size = New System.Drawing.Size(73, 13)
        Me.lblNumberPeriod.TabIndex = 3
        Me.lblNumberPeriod.Text = "Số kỳ kế toán"
        Me.lblNumberPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(265, 19)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(243, 22)
        Me.txtDivisionName.TabIndex = 2
        Me.txtDivisionName.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpInherite)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(528, 200)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "2. Mặc định"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpInherite
        '
        Me.grpInherite.Controls.Add(Me.chkIsQC)
        Me.grpInherite.Controls.Add(Me.chkIsOQuantity)
        Me.grpInherite.Location = New System.Drawing.Point(8, 12)
        Me.grpInherite.Name = "grpInherite"
        Me.grpInherite.Size = New System.Drawing.Size(511, 85)
        Me.grpInherite.TabIndex = 3
        Me.grpInherite.TabStop = False
        Me.grpInherite.Text = "Kế thừa"
        '
        'chkIsQC
        '
        Me.chkIsQC.AutoSize = True
        Me.chkIsQC.Location = New System.Drawing.Point(39, 25)
        Me.chkIsQC.Name = "chkIsQC"
        Me.chkIsQC.Size = New System.Drawing.Size(342, 17)
        Me.chkIsQC.TabIndex = 1
        Me.chkIsQC.Text = "Chỉ hiển thị những phiếu kết quả SX sau khi đã kiểm tra chất lượng"
        Me.chkIsQC.UseVisualStyleBackColor = True
        '
        'chkIsOQuantity
        '
        Me.chkIsOQuantity.AutoSize = True
        Me.chkIsOQuantity.Location = New System.Drawing.Point(39, 50)
        Me.chkIsOQuantity.Name = "chkIsOQuantity"
        Me.chkIsOQuantity.Size = New System.Drawing.Size(142, 17)
        Me.chkIsOQuantity.TabIndex = 2
        Me.chkIsOQuantity.Text = "Chỉ kế thừa số lượng đạt"
        Me.chkIsOQuantity.UseVisualStyleBackColor = True
        '
        'D45F0001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 261)
        Me.Controls.Add(Me.tabSystem)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F0001"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp hÖ thçng - D45F0001"
        Me.tabSystem.ResumeLayout(False)
        Me.TabPageMainInfo.ResumeLayout(False)
        Me.TabPageMainInfo.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.grpInherite.ResumeLayout(False)
        Me.grpInherite.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tabSystem As System.Windows.Forms.TabControl
    Friend WithEvents TabPageMainInfo As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDefaultPeriod As System.Windows.Forms.TextBox
    Private WithEvents lblDefaultPeriod As System.Windows.Forms.Label
    Private WithEvents txtPeriodNumber As System.Windows.Forms.TextBox
    Private WithEvents lblNumberPeriod As System.Windows.Forms.Label
    Private WithEvents txtDivisionName As System.Windows.Forms.TextBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents grpInherite As System.Windows.Forms.GroupBox
    Private WithEvents chkIsOQuantity As System.Windows.Forms.CheckBox
    Private WithEvents chkIsQC As System.Windows.Forms.CheckBox
    Private WithEvents lblDefaultDivision As System.Windows.Forms.Label
    Private WithEvents chkIsWorkingHour As System.Windows.Forms.CheckBox
End Class