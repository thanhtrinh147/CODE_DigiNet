<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F0002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F0002))
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tabOption = New System.Windows.Forms.TabControl()
        Me.TabPageDefault = New System.Windows.Forms.TabPage()
        Me.chkSaveLastRecent = New System.Windows.Forms.CheckBox()
        Me.chkUseEnterAsTab = New System.Windows.Forms.CheckBox()
        Me.chkViewFormPeriodWhenAppRun = New System.Windows.Forms.CheckBox()
        Me.chkMessageWhenSaveOK = New System.Windows.Forms.CheckBox()
        Me.chkMessageAskBeforeSave = New System.Windows.Forms.CheckBox()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.tdbcTransTypeID = New C1.Win.C1List.C1Combo()
        Me.lblTransTypeID = New System.Windows.Forms.Label()
        Me.txtTransTypeName = New System.Windows.Forms.TextBox()
        Me.lblDefaultDivisionID = New System.Windows.Forms.Label()
        Me.tdbcDefaultDivisionID = New C1.Win.C1List.C1Combo()
        Me.txtDefaultDivisionName = New System.Windows.Forms.TextBox()
        Me.tabOption.SuspendLayout()
        Me.TabPageDefault.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDefaultDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(442, 272)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(359, 272)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabOption
        '
        Me.tabOption.Controls.Add(Me.TabPageDefault)
        Me.tabOption.Location = New System.Drawing.Point(3, 3)
        Me.tabOption.Name = "tabOption"
        Me.tabOption.SelectedIndex = 0
        Me.tabOption.Size = New System.Drawing.Size(515, 263)
        Me.tabOption.TabIndex = 0
        '
        'TabPageDefault
        '
        Me.TabPageDefault.Controls.Add(Me.chkSaveLastRecent)
        Me.TabPageDefault.Controls.Add(Me.chkUseEnterAsTab)
        Me.TabPageDefault.Controls.Add(Me.chkViewFormPeriodWhenAppRun)
        Me.TabPageDefault.Controls.Add(Me.chkMessageWhenSaveOK)
        Me.TabPageDefault.Controls.Add(Me.chkMessageAskBeforeSave)
        Me.TabPageDefault.Controls.Add(Me.grp1)
        Me.TabPageDefault.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDefault.Name = "TabPageDefault"
        Me.TabPageDefault.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDefault.Size = New System.Drawing.Size(507, 237)
        Me.TabPageDefault.TabIndex = 0
        Me.TabPageDefault.Text = "1. Mặc định"
        Me.TabPageDefault.UseVisualStyleBackColor = True
        '
        'chkSaveLastRecent
        '
        Me.chkSaveLastRecent.AutoSize = True
        Me.chkSaveLastRecent.Location = New System.Drawing.Point(6, 209)
        Me.chkSaveLastRecent.Name = "chkSaveLastRecent"
        Me.chkSaveLastRecent.Size = New System.Drawing.Size(202, 17)
        Me.chkSaveLastRecent.TabIndex = 5
        Me.chkSaveLastRecent.Text = "Lưu các giá trị gần nhất khi nhập tiếp"
        Me.chkSaveLastRecent.UseVisualStyleBackColor = True
        '
        'chkUseEnterAsTab
        '
        Me.chkUseEnterAsTab.AutoSize = True
        Me.chkUseEnterAsTab.Location = New System.Drawing.Point(6, 155)
        Me.chkUseEnterAsTab.Name = "chkUseEnterAsTab"
        Me.chkUseEnterAsTab.Size = New System.Drawing.Size(245, 17)
        Me.chkUseEnterAsTab.TabIndex = 3
        Me.chkUseEnterAsTab.Text = "Sử dụng chức năng phím Enter như phím Tab"
        Me.chkUseEnterAsTab.UseVisualStyleBackColor = True
        '
        'chkViewFormPeriodWhenAppRun
        '
        Me.chkViewFormPeriodWhenAppRun.AutoSize = True
        Me.chkViewFormPeriodWhenAppRun.Location = New System.Drawing.Point(6, 184)
        Me.chkViewFormPeriodWhenAppRun.Name = "chkViewFormPeriodWhenAppRun"
        Me.chkViewFormPeriodWhenAppRun.Size = New System.Drawing.Size(293, 17)
        Me.chkViewFormPeriodWhenAppRun.TabIndex = 4
        Me.chkViewFormPeriodWhenAppRun.Text = "Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình"
        Me.chkViewFormPeriodWhenAppRun.UseVisualStyleBackColor = True
        '
        'chkMessageWhenSaveOK
        '
        Me.chkMessageWhenSaveOK.AutoSize = True
        Me.chkMessageWhenSaveOK.Location = New System.Drawing.Point(6, 126)
        Me.chkMessageWhenSaveOK.Name = "chkMessageWhenSaveOK"
        Me.chkMessageWhenSaveOK.Size = New System.Drawing.Size(169, 17)
        Me.chkMessageWhenSaveOK.TabIndex = 2
        Me.chkMessageWhenSaveOK.Text = "Thông báo khi lưu thành công"
        Me.chkMessageWhenSaveOK.UseVisualStyleBackColor = True
        '
        'chkMessageAskBeforeSave
        '
        Me.chkMessageAskBeforeSave.AutoSize = True
        Me.chkMessageAskBeforeSave.Location = New System.Drawing.Point(6, 97)
        Me.chkMessageAskBeforeSave.Name = "chkMessageAskBeforeSave"
        Me.chkMessageAskBeforeSave.Size = New System.Drawing.Size(103, 17)
        Me.chkMessageAskBeforeSave.TabIndex = 1
        Me.chkMessageAskBeforeSave.Text = "Hỏi trước khi lưu"
        Me.chkMessageAskBeforeSave.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbcTransTypeID)
        Me.grp1.Controls.Add(Me.lblTransTypeID)
        Me.grp1.Controls.Add(Me.txtTransTypeName)
        Me.grp1.Controls.Add(Me.lblDefaultDivisionID)
        Me.grp1.Controls.Add(Me.tdbcDefaultDivisionID)
        Me.grp1.Controls.Add(Me.txtDefaultDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(495, 82)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'tdbcTransTypeID
        '
        Me.tdbcTransTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransTypeID.AllowColMove = False
        Me.tdbcTransTypeID.AllowSort = False
        Me.tdbcTransTypeID.AlternatingRows = True
        Me.tdbcTransTypeID.AutoCompletion = True
        Me.tdbcTransTypeID.AutoDropDown = True
        Me.tdbcTransTypeID.Caption = ""
        Me.tdbcTransTypeID.CaptionHeight = 17
        Me.tdbcTransTypeID.CaptionStyle = Style1
        Me.tdbcTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransTypeID.ColumnCaptionHeight = 17
        Me.tdbcTransTypeID.ColumnFooterHeight = 17
        Me.tdbcTransTypeID.ColumnWidth = 100
        Me.tdbcTransTypeID.ContentHeight = 17
        Me.tdbcTransTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransTypeID.DisplayMember = "TransTypeID"
        Me.tdbcTransTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTransTypeID.DropDownWidth = 300
        Me.tdbcTransTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransTypeID.EditorHeight = 17
        Me.tdbcTransTypeID.EmptyRows = True
        Me.tdbcTransTypeID.EvenRowStyle = Style2
        Me.tdbcTransTypeID.ExtendRightColumn = True
        Me.tdbcTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.FooterStyle = Style3
        Me.tdbcTransTypeID.HeadingStyle = Style4
        Me.tdbcTransTypeID.HighLightRowStyle = Style5
        Me.tdbcTransTypeID.Images.Add(CType(resources.GetObject("tdbcTransTypeID.Images"), System.Drawing.Image))
        Me.tdbcTransTypeID.ItemHeight = 15
        Me.tdbcTransTypeID.Location = New System.Drawing.Point(117, 48)
        Me.tdbcTransTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransTypeID.MaxLength = 32767
        Me.tdbcTransTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransTypeID.Name = "tdbcTransTypeID"
        Me.tdbcTransTypeID.OddRowStyle = Style6
        Me.tdbcTransTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.SelectedStyle = Style7
        Me.tdbcTransTypeID.Size = New System.Drawing.Size(125, 23)
        Me.tdbcTransTypeID.Style = Style8
        Me.tdbcTransTypeID.TabIndex = 7
        Me.tdbcTransTypeID.ValueMember = "TransTypeID"
        Me.tdbcTransTypeID.PropBag = resources.GetString("tdbcTransTypeID.PropBag")
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(5, 52)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 6
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtTransTypeName.Location = New System.Drawing.Point(246, 48)
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.ReadOnly = True
        Me.txtTransTypeName.Size = New System.Drawing.Size(240, 22)
        Me.txtTransTypeName.TabIndex = 8
        Me.txtTransTypeName.TabStop = False
        '
        'lblDefaultDivisionID
        '
        Me.lblDefaultDivisionID.AutoSize = True
        Me.lblDefaultDivisionID.Location = New System.Drawing.Point(6, 23)
        Me.lblDefaultDivisionID.Name = "lblDefaultDivisionID"
        Me.lblDefaultDivisionID.Size = New System.Drawing.Size(85, 13)
        Me.lblDefaultDivisionID.TabIndex = 0
        Me.lblDefaultDivisionID.Text = "Đơn vị mặc định"
        Me.lblDefaultDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbcDefaultDivisionID
        '
        Me.tdbcDefaultDivisionID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDefaultDivisionID.AllowColMove = False
        Me.tdbcDefaultDivisionID.AllowSort = False
        Me.tdbcDefaultDivisionID.AlternatingRows = True
        Me.tdbcDefaultDivisionID.AutoCompletion = True
        Me.tdbcDefaultDivisionID.AutoDropDown = True
        Me.tdbcDefaultDivisionID.Caption = ""
        Me.tdbcDefaultDivisionID.CaptionHeight = 17
        Me.tdbcDefaultDivisionID.CaptionStyle = Style9
        Me.tdbcDefaultDivisionID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDefaultDivisionID.ColumnCaptionHeight = 17
        Me.tdbcDefaultDivisionID.ColumnFooterHeight = 17
        Me.tdbcDefaultDivisionID.ColumnWidth = 100
        Me.tdbcDefaultDivisionID.ContentHeight = 17
        Me.tdbcDefaultDivisionID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDefaultDivisionID.DisplayMember = "DivisionID"
        Me.tdbcDefaultDivisionID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDefaultDivisionID.DropDownWidth = 400
        Me.tdbcDefaultDivisionID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDefaultDivisionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDefaultDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDefaultDivisionID.EditorHeight = 17
        Me.tdbcDefaultDivisionID.EmptyRows = True
        Me.tdbcDefaultDivisionID.EvenRowStyle = Style10
        Me.tdbcDefaultDivisionID.ExtendRightColumn = True
        Me.tdbcDefaultDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDefaultDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDefaultDivisionID.FooterStyle = Style11
        Me.tdbcDefaultDivisionID.HeadingStyle = Style12
        Me.tdbcDefaultDivisionID.HighLightRowStyle = Style13
        Me.tdbcDefaultDivisionID.Images.Add(CType(resources.GetObject("tdbcDefaultDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDefaultDivisionID.ItemHeight = 15
        Me.tdbcDefaultDivisionID.Location = New System.Drawing.Point(117, 19)
        Me.tdbcDefaultDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDefaultDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDefaultDivisionID.MaxLength = 32767
        Me.tdbcDefaultDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDefaultDivisionID.Name = "tdbcDefaultDivisionID"
        Me.tdbcDefaultDivisionID.OddRowStyle = Style14
        Me.tdbcDefaultDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDefaultDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDefaultDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDefaultDivisionID.SelectedStyle = Style15
        Me.tdbcDefaultDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDefaultDivisionID.Style = Style16
        Me.tdbcDefaultDivisionID.TabIndex = 1
        Me.tdbcDefaultDivisionID.ValueMember = "DivisionID"
        Me.tdbcDefaultDivisionID.PropBag = resources.GetString("tdbcDefaultDivisionID.PropBag")
        '
        'txtDefaultDivisionName
        '
        Me.txtDefaultDivisionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDefaultDivisionName.Location = New System.Drawing.Point(247, 19)
        Me.txtDefaultDivisionName.Name = "txtDefaultDivisionName"
        Me.txtDefaultDivisionName.ReadOnly = True
        Me.txtDefaultDivisionName.Size = New System.Drawing.Size(240, 22)
        Me.txtDefaultDivisionName.TabIndex = 2
        Me.txtDefaultDivisionName.TabStop = False
        '
        'D25F0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 303)
        Me.Controls.Add(Me.tabOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F0002"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tîy chãn - D25F0002"
        Me.tabOption.ResumeLayout(False)
        Me.TabPageDefault.ResumeLayout(False)
        Me.TabPageDefault.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDefaultDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tabOption As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDefault As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDefaultDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDefaultDivisionName As System.Windows.Forms.TextBox
    Private WithEvents chkViewFormPeriodWhenAppRun As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageWhenSaveOK As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageAskBeforeSave As System.Windows.Forms.CheckBox
    Private WithEvents chkUseEnterAsTab As System.Windows.Forms.CheckBox
    Private WithEvents lblDefaultDivisionID As System.Windows.Forms.Label
    Private WithEvents chkSaveLastRecent As System.Windows.Forms.CheckBox
    Private WithEvents tdbcTransTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
End Class
