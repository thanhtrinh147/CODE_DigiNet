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
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F0002))
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style25 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style26 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style27 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style28 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style29 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style30 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style31 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style32 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tabOption = New System.Windows.Forms.TabControl
        Me.TabPageDefault = New System.Windows.Forms.TabPage
        Me.chkSaveLastRecent = New System.Windows.Forms.CheckBox
        Me.chkUseEnterAsTab = New System.Windows.Forms.CheckBox
        Me.chkViewFormPeriodWhenAppRun = New System.Windows.Forms.CheckBox
        Me.chkMessageWhenSaveOK = New System.Windows.Forms.CheckBox
        Me.chkMessageAskBeforeSave = New System.Windows.Forms.CheckBox
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.lblTransTypeID2 = New System.Windows.Forms.Label
        Me.tdbcTransTypeID = New C1.Win.C1List.C1Combo
        Me.lblTransTypeID = New System.Windows.Forms.Label
        Me.txtTransTypeName = New System.Windows.Forms.TextBox
        Me.lblDefaultDivision = New System.Windows.Forms.Label
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.txtDivisionName = New System.Windows.Forms.TextBox
        Me.tabOption.SuspendLayout()
        Me.TabPageDefault.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(442, 307)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(359, 307)
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
        Me.tabOption.Size = New System.Drawing.Size(515, 302)
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
        Me.TabPageDefault.Size = New System.Drawing.Size(507, 276)
        Me.TabPageDefault.TabIndex = 0
        Me.TabPageDefault.Text = "1. Mặc định"
        Me.TabPageDefault.UseVisualStyleBackColor = True
        '
        'chkSaveLastRecent
        '
        Me.chkSaveLastRecent.AutoSize = True
        Me.chkSaveLastRecent.Location = New System.Drawing.Point(6, 243)
        Me.chkSaveLastRecent.Name = "chkSaveLastRecent"
        Me.chkSaveLastRecent.Size = New System.Drawing.Size(202, 17)
        Me.chkSaveLastRecent.TabIndex = 5
        Me.chkSaveLastRecent.Text = "Lưu các giá trị gần nhất khi nhập tiếp"
        Me.chkSaveLastRecent.UseVisualStyleBackColor = True
        '
        'chkUseEnterAsTab
        '
        Me.chkUseEnterAsTab.AutoSize = True
        Me.chkUseEnterAsTab.Location = New System.Drawing.Point(6, 189)
        Me.chkUseEnterAsTab.Name = "chkUseEnterAsTab"
        Me.chkUseEnterAsTab.Size = New System.Drawing.Size(245, 17)
        Me.chkUseEnterAsTab.TabIndex = 3
        Me.chkUseEnterAsTab.Text = "Sử dụng chức năng phím Enter như phím Tab"
        Me.chkUseEnterAsTab.UseVisualStyleBackColor = True
        '
        'chkViewFormPeriodWhenAppRun
        '
        Me.chkViewFormPeriodWhenAppRun.AutoSize = True
        Me.chkViewFormPeriodWhenAppRun.Location = New System.Drawing.Point(6, 218)
        Me.chkViewFormPeriodWhenAppRun.Name = "chkViewFormPeriodWhenAppRun"
        Me.chkViewFormPeriodWhenAppRun.Size = New System.Drawing.Size(293, 17)
        Me.chkViewFormPeriodWhenAppRun.TabIndex = 4
        Me.chkViewFormPeriodWhenAppRun.Text = "Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình"
        Me.chkViewFormPeriodWhenAppRun.UseVisualStyleBackColor = True
        '
        'chkMessageWhenSaveOK
        '
        Me.chkMessageWhenSaveOK.AutoSize = True
        Me.chkMessageWhenSaveOK.Location = New System.Drawing.Point(6, 160)
        Me.chkMessageWhenSaveOK.Name = "chkMessageWhenSaveOK"
        Me.chkMessageWhenSaveOK.Size = New System.Drawing.Size(169, 17)
        Me.chkMessageWhenSaveOK.TabIndex = 2
        Me.chkMessageWhenSaveOK.Text = "Thông báo khi lưu thành công"
        Me.chkMessageWhenSaveOK.UseVisualStyleBackColor = True
        '
        'chkMessageAskBeforeSave
        '
        Me.chkMessageAskBeforeSave.AutoSize = True
        Me.chkMessageAskBeforeSave.Location = New System.Drawing.Point(6, 131)
        Me.chkMessageAskBeforeSave.Name = "chkMessageAskBeforeSave"
        Me.chkMessageAskBeforeSave.Size = New System.Drawing.Size(103, 17)
        Me.chkMessageAskBeforeSave.TabIndex = 1
        Me.chkMessageAskBeforeSave.Text = "Hỏi trước khi lưu"
        Me.chkMessageAskBeforeSave.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lblTransTypeID2)
        Me.grp1.Controls.Add(Me.tdbcTransTypeID)
        Me.grp1.Controls.Add(Me.lblTransTypeID)
        Me.grp1.Controls.Add(Me.txtTransTypeName)
        Me.grp1.Controls.Add(Me.lblDefaultDivision)
        Me.grp1.Controls.Add(Me.tdbcDivisionID)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(495, 112)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'lblTransTypeID2
        '
        Me.lblTransTypeID2.AutoSize = True
        Me.lblTransTypeID2.Location = New System.Drawing.Point(10, 85)
        Me.lblTransTypeID2.Name = "lblTransTypeID2"
        Me.lblTransTypeID2.Size = New System.Drawing.Size(81, 13)
        Me.lblTransTypeID2.TabIndex = 9
        Me.lblTransTypeID2.Text = "HS ứng cử viên"
        Me.lblTransTypeID2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTransTypeID2.Visible = False
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
        Me.tdbcTransTypeID.CaptionStyle = Style17
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
        Me.tdbcTransTypeID.EvenRowStyle = Style18
        Me.tdbcTransTypeID.ExtendRightColumn = True
        Me.tdbcTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.FooterStyle = Style19
        Me.tdbcTransTypeID.HeadingStyle = Style20
        Me.tdbcTransTypeID.HighLightRowStyle = Style21
        Me.tdbcTransTypeID.Images.Add(CType(resources.GetObject("tdbcTransTypeID.Images"), System.Drawing.Image))
        Me.tdbcTransTypeID.ItemHeight = 15
        Me.tdbcTransTypeID.Location = New System.Drawing.Point(118, 58)
        Me.tdbcTransTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransTypeID.MaxLength = 32767
        Me.tdbcTransTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransTypeID.Name = "tdbcTransTypeID"
        Me.tdbcTransTypeID.OddRowStyle = Style22
        Me.tdbcTransTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.SelectedStyle = Style23
        Me.tdbcTransTypeID.Size = New System.Drawing.Size(125, 23)
        Me.tdbcTransTypeID.Style = Style24
        Me.tdbcTransTypeID.TabIndex = 7
        Me.tdbcTransTypeID.ValueMember = "TransTypeID"
        Me.tdbcTransTypeID.PropBag = resources.GetString("tdbcTransTypeID.PropBag")
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(6, 62)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 6
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtTransTypeName.Location = New System.Drawing.Point(247, 58)
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.ReadOnly = True
        Me.txtTransTypeName.Size = New System.Drawing.Size(240, 22)
        Me.txtTransTypeName.TabIndex = 8
        Me.txtTransTypeName.TabStop = False
        '
        'lblDefaultDivision
        '
        Me.lblDefaultDivision.AutoSize = True
        Me.lblDefaultDivision.Location = New System.Drawing.Point(6, 23)
        Me.lblDefaultDivision.Name = "lblDefaultDivision"
        Me.lblDefaultDivision.Size = New System.Drawing.Size(85, 13)
        Me.lblDefaultDivision.TabIndex = 0
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
        Me.tdbcDivisionID.CaptionStyle = Style25
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
        Me.tdbcDivisionID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDivisionID.EditorHeight = 17
        Me.tdbcDivisionID.EmptyRows = True
        Me.tdbcDivisionID.EvenRowStyle = Style26
        Me.tdbcDivisionID.ExtendRightColumn = True
        Me.tdbcDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDivisionID.FooterStyle = Style27
        Me.tdbcDivisionID.HeadingStyle = Style28
        Me.tdbcDivisionID.HighLightRowStyle = Style29
        Me.tdbcDivisionID.Images.Add(CType(resources.GetObject("tdbcDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDivisionID.ItemHeight = 15
        Me.tdbcDivisionID.Location = New System.Drawing.Point(117, 19)
        Me.tdbcDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDivisionID.MaxLength = 32767
        Me.tdbcDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDivisionID.Name = "tdbcDivisionID"
        Me.tdbcDivisionID.OddRowStyle = Style30
        Me.tdbcDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDivisionID.SelectedStyle = Style31
        Me.tdbcDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDivisionID.Style = Style32
        Me.tdbcDivisionID.TabIndex = 1
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(247, 19)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(240, 22)
        Me.txtDivisionName.TabIndex = 2
        Me.txtDivisionName.TabStop = False
        '
        'D25F0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 333)
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
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tabOption As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDefault As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDivisionName As System.Windows.Forms.TextBox
    Private WithEvents chkViewFormPeriodWhenAppRun As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageWhenSaveOK As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageAskBeforeSave As System.Windows.Forms.CheckBox
    Private WithEvents chkUseEnterAsTab As System.Windows.Forms.CheckBox
    Private WithEvents lblDefaultDivision As System.Windows.Forms.Label
    Private WithEvents chkSaveLastRecent As System.Windows.Forms.CheckBox
    Private WithEvents lblTransTypeID2 As System.Windows.Forms.Label
    Private WithEvents tdbcTransTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
End Class
