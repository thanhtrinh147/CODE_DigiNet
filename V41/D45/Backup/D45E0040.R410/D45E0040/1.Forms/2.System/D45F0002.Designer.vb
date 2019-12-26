<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F0002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F0002))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.tabOption = New System.Windows.Forms.TabControl
        Me.TabPageDefault = New System.Windows.Forms.TabPage
        Me.grpPieceMethod = New System.Windows.Forms.GroupBox
        Me.optPieceWorkMethod3 = New System.Windows.Forms.RadioButton
        Me.optPieceWorkMethod2 = New System.Windows.Forms.RadioButton
        Me.optPieceWorkMethod1 = New System.Windows.Forms.RadioButton
        Me.chkShowReportPath = New System.Windows.Forms.CheckBox
        Me.chkViewFormPeriodWhenAppRun = New System.Windows.Forms.CheckBox
        Me.chkMessageWhenSaveOK = New System.Windows.Forms.CheckBox
        Me.chkMessageAskBeforeSave = New System.Windows.Forms.CheckBox
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.lblDefaultDivision = New System.Windows.Forms.Label
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.txtDivisionName = New System.Windows.Forms.TextBox
        Me.TabPageShow = New System.Windows.Forms.TabPage
        Me.chkSaveLastRecent = New System.Windows.Forms.CheckBox
        Me.chkUseEnterMoveDown = New System.Windows.Forms.CheckBox
        Me.chkCancelEmployeeID = New System.Windows.Forms.CheckBox
        Me.chkAutoCopy = New System.Windows.Forms.CheckBox
        Me.TabPageReport = New System.Windows.Forms.TabPage
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.optEnglish = New System.Windows.Forms.RadioButton
        Me.optVietnameseEnglish = New System.Windows.Forms.RadioButton
        Me.optVietnamese = New System.Windows.Forms.RadioButton
        Me.btnSave = New System.Windows.Forms.Button
        Me.chkFormula = New System.Windows.Forms.CheckBox
        Me.tabOption.SuspendLayout()
        Me.TabPageDefault.SuspendLayout()
        Me.grpPieceMethod.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageShow.SuspendLayout()
        Me.TabPageReport.SuspendLayout()
        Me.grp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(442, 244)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabOption
        '
        Me.tabOption.Controls.Add(Me.TabPageDefault)
        Me.tabOption.Controls.Add(Me.TabPageShow)
        Me.tabOption.Controls.Add(Me.TabPageReport)
        Me.tabOption.Location = New System.Drawing.Point(3, 3)
        Me.tabOption.Name = "tabOption"
        Me.tabOption.SelectedIndex = 0
        Me.tabOption.Size = New System.Drawing.Size(515, 235)
        Me.tabOption.TabIndex = 0
        '
        'TabPageDefault
        '
        Me.TabPageDefault.Controls.Add(Me.chkFormula)
        Me.TabPageDefault.Controls.Add(Me.grpPieceMethod)
        Me.TabPageDefault.Controls.Add(Me.chkShowReportPath)
        Me.TabPageDefault.Controls.Add(Me.chkViewFormPeriodWhenAppRun)
        Me.TabPageDefault.Controls.Add(Me.chkMessageWhenSaveOK)
        Me.TabPageDefault.Controls.Add(Me.chkMessageAskBeforeSave)
        Me.TabPageDefault.Controls.Add(Me.grp1)
        Me.TabPageDefault.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDefault.Name = "TabPageDefault"
        Me.TabPageDefault.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDefault.Size = New System.Drawing.Size(507, 209)
        Me.TabPageDefault.TabIndex = 0
        Me.TabPageDefault.Text = "1. Mặc định"
        Me.TabPageDefault.UseVisualStyleBackColor = True
        '
        'grpPieceMethod
        '
        Me.grpPieceMethod.Controls.Add(Me.optPieceWorkMethod3)
        Me.grpPieceMethod.Controls.Add(Me.optPieceWorkMethod2)
        Me.grpPieceMethod.Controls.Add(Me.optPieceWorkMethod1)
        Me.grpPieceMethod.Location = New System.Drawing.Point(5, 162)
        Me.grpPieceMethod.Name = "grpPieceMethod"
        Me.grpPieceMethod.Size = New System.Drawing.Size(496, 42)
        Me.grpPieceMethod.TabIndex = 5
        Me.grpPieceMethod.TabStop = False
        Me.grpPieceMethod.Text = "Phương thức chấm công"
        '
        'optPieceWorkMethod3
        '
        Me.optPieceWorkMethod3.AutoSize = True
        Me.optPieceWorkMethod3.Location = New System.Drawing.Point(9, 42)
        Me.optPieceWorkMethod3.Name = "optPieceWorkMethod3"
        Me.optPieceWorkMethod3.Size = New System.Drawing.Size(133, 17)
        Me.optPieceWorkMethod3.TabIndex = 2
        Me.optPieceWorkMethod3.TabStop = True
        Me.optPieceWorkMethod3.Text = "Nhân viên / Sản phẩm"
        Me.optPieceWorkMethod3.UseVisualStyleBackColor = True
        '
        'optPieceWorkMethod2
        '
        Me.optPieceWorkMethod2.AutoSize = True
        Me.optPieceWorkMethod2.Location = New System.Drawing.Point(293, 19)
        Me.optPieceWorkMethod2.Name = "optPieceWorkMethod2"
        Me.optPieceWorkMethod2.Size = New System.Drawing.Size(197, 17)
        Me.optPieceWorkMethod2.TabIndex = 1
        Me.optPieceWorkMethod2.TabStop = True
        Me.optPieceWorkMethod2.Text = "Sản phẩm / Công đoạn / Nhân viên"
        Me.optPieceWorkMethod2.UseVisualStyleBackColor = True
        '
        'optPieceWorkMethod1
        '
        Me.optPieceWorkMethod1.AutoSize = True
        Me.optPieceWorkMethod1.Checked = True
        Me.optPieceWorkMethod1.Location = New System.Drawing.Point(9, 19)
        Me.optPieceWorkMethod1.Name = "optPieceWorkMethod1"
        Me.optPieceWorkMethod1.Size = New System.Drawing.Size(197, 17)
        Me.optPieceWorkMethod1.TabIndex = 0
        Me.optPieceWorkMethod1.TabStop = True
        Me.optPieceWorkMethod1.Text = "Nhân viên / Sản phẩm / Công đoạn"
        Me.optPieceWorkMethod1.UseVisualStyleBackColor = True
        '
        'chkShowReportPath
        '
        Me.chkShowReportPath.AutoSize = True
        Me.chkShowReportPath.Location = New System.Drawing.Point(6, 118)
        Me.chkShowReportPath.Name = "chkShowReportPath"
        Me.chkShowReportPath.Size = New System.Drawing.Size(263, 17)
        Me.chkShowReportPath.TabIndex = 4
        Me.chkShowReportPath.Text = "Hiển thị màn hình đường dẫn báo cáo cho lần sau"
        Me.chkShowReportPath.UseVisualStyleBackColor = True
        '
        'chkViewFormPeriodWhenAppRun
        '
        Me.chkViewFormPeriodWhenAppRun.AutoSize = True
        Me.chkViewFormPeriodWhenAppRun.Location = New System.Drawing.Point(6, 95)
        Me.chkViewFormPeriodWhenAppRun.Name = "chkViewFormPeriodWhenAppRun"
        Me.chkViewFormPeriodWhenAppRun.Size = New System.Drawing.Size(293, 17)
        Me.chkViewFormPeriodWhenAppRun.TabIndex = 3
        Me.chkViewFormPeriodWhenAppRun.Text = "Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình"
        Me.chkViewFormPeriodWhenAppRun.UseVisualStyleBackColor = True
        '
        'chkMessageWhenSaveOK
        '
        Me.chkMessageWhenSaveOK.AutoSize = True
        Me.chkMessageWhenSaveOK.Location = New System.Drawing.Point(6, 72)
        Me.chkMessageWhenSaveOK.Name = "chkMessageWhenSaveOK"
        Me.chkMessageWhenSaveOK.Size = New System.Drawing.Size(169, 17)
        Me.chkMessageWhenSaveOK.TabIndex = 2
        Me.chkMessageWhenSaveOK.Text = "Thông báo khi lưu thành công"
        Me.chkMessageWhenSaveOK.UseVisualStyleBackColor = True
        '
        'chkMessageAskBeforeSave
        '
        Me.chkMessageAskBeforeSave.AutoSize = True
        Me.chkMessageAskBeforeSave.Location = New System.Drawing.Point(6, 49)
        Me.chkMessageAskBeforeSave.Name = "chkMessageAskBeforeSave"
        Me.chkMessageAskBeforeSave.Size = New System.Drawing.Size(103, 17)
        Me.chkMessageAskBeforeSave.TabIndex = 1
        Me.chkMessageAskBeforeSave.Text = "Hỏi trước khi lưu"
        Me.chkMessageAskBeforeSave.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lblDefaultDivision)
        Me.grp1.Controls.Add(Me.tdbcDivisionID)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 2)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(495, 41)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'lblDefaultDivision
        '
        Me.lblDefaultDivision.AutoSize = True
        Me.lblDefaultDivision.Location = New System.Drawing.Point(5, 16)
        Me.lblDefaultDivision.Name = "lblDefaultDivision"
        Me.lblDefaultDivision.Size = New System.Drawing.Size(85, 13)
        Me.lblDefaultDivision.TabIndex = 8
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
        Me.tdbcDivisionID.Location = New System.Drawing.Point(118, 12)
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
        Me.tdbcDivisionID.TabIndex = 0
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(252, 12)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(237, 22)
        Me.txtDivisionName.TabIndex = 2
        Me.txtDivisionName.TabStop = False
        '
        'TabPageShow
        '
        Me.TabPageShow.Controls.Add(Me.chkSaveLastRecent)
        Me.TabPageShow.Controls.Add(Me.chkUseEnterMoveDown)
        Me.TabPageShow.Controls.Add(Me.chkCancelEmployeeID)
        Me.TabPageShow.Controls.Add(Me.chkAutoCopy)
        Me.TabPageShow.Location = New System.Drawing.Point(4, 22)
        Me.TabPageShow.Name = "TabPageShow"
        Me.TabPageShow.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageShow.Size = New System.Drawing.Size(507, 209)
        Me.TabPageShow.TabIndex = 1
        Me.TabPageShow.Text = "2. Tiện ích"
        Me.TabPageShow.UseVisualStyleBackColor = True
        '
        'chkSaveLastRecent
        '
        Me.chkSaveLastRecent.AutoSize = True
        Me.chkSaveLastRecent.Location = New System.Drawing.Point(26, 119)
        Me.chkSaveLastRecent.Name = "chkSaveLastRecent"
        Me.chkSaveLastRecent.Size = New System.Drawing.Size(130, 17)
        Me.chkSaveLastRecent.TabIndex = 10
        Me.chkSaveLastRecent.Text = "Lưu lại giá trị gần nhất"
        Me.chkSaveLastRecent.UseVisualStyleBackColor = True
        '
        'chkUseEnterMoveDown
        '
        Me.chkUseEnterMoveDown.AutoSize = True
        Me.chkUseEnterMoveDown.Location = New System.Drawing.Point(26, 84)
        Me.chkUseEnterMoveDown.Name = "chkUseEnterMoveDown"
        Me.chkUseEnterMoveDown.Size = New System.Drawing.Size(299, 17)
        Me.chkUseEnterMoveDown.TabIndex = 9
        Me.chkUseEnterMoveDown.Text = "Sử dụng phím Enter để di chuyển đến ô dưới ô hiện hành"
        Me.chkUseEnterMoveDown.UseVisualStyleBackColor = True
        '
        'chkCancelEmployeeID
        '
        Me.chkCancelEmployeeID.AutoSize = True
        Me.chkCancelEmployeeID.Location = New System.Drawing.Point(26, 49)
        Me.chkCancelEmployeeID.Name = "chkCancelEmployeeID"
        Me.chkCancelEmployeeID.Size = New System.Drawing.Size(127, 17)
        Me.chkCancelEmployeeID.TabIndex = 8
        Me.chkCancelEmployeeID.Text = "Bỏ qua mã nhân viên"
        Me.chkCancelEmployeeID.UseVisualStyleBackColor = True
        '
        'chkAutoCopy
        '
        Me.chkAutoCopy.AutoSize = True
        Me.chkAutoCopy.Location = New System.Drawing.Point(26, 14)
        Me.chkAutoCopy.Name = "chkAutoCopy"
        Me.chkAutoCopy.Size = New System.Drawing.Size(251, 17)
        Me.chkAutoCopy.TabIndex = 7
        Me.chkAutoCopy.Text = "Tự động copy giá trị dòng trên xuống dòng dưới"
        Me.chkAutoCopy.UseVisualStyleBackColor = True
        '
        'TabPageReport
        '
        Me.TabPageReport.Controls.Add(Me.grp2)
        Me.TabPageReport.Location = New System.Drawing.Point(4, 22)
        Me.TabPageReport.Name = "TabPageReport"
        Me.TabPageReport.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageReport.Size = New System.Drawing.Size(507, 209)
        Me.TabPageReport.TabIndex = 2
        Me.TabPageReport.Text = "Báo cáo"
        Me.TabPageReport.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.optEnglish)
        Me.grp2.Controls.Add(Me.optVietnameseEnglish)
        Me.grp2.Controls.Add(Me.optVietnamese)
        Me.grp2.Location = New System.Drawing.Point(6, 5)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(495, 179)
        Me.grp2.TabIndex = 0
        Me.grp2.TabStop = False
        Me.grp2.Text = "Ngôn ngữ báo cáo"
        '
        'optEnglish
        '
        Me.optEnglish.AutoSize = True
        Me.optEnglish.Location = New System.Drawing.Point(406, 35)
        Me.optEnglish.Name = "optEnglish"
        Me.optEnglish.Size = New System.Drawing.Size(74, 17)
        Me.optEnglish.TabIndex = 2
        Me.optEnglish.TabStop = True
        Me.optEnglish.Text = "Tiếng Anh"
        Me.optEnglish.UseVisualStyleBackColor = True
        '
        'optVietnameseEnglish
        '
        Me.optVietnameseEnglish.AutoSize = True
        Me.optVietnameseEnglish.Location = New System.Drawing.Point(187, 35)
        Me.optVietnameseEnglish.Name = "optVietnameseEnglish"
        Me.optVietnameseEnglish.Size = New System.Drawing.Size(120, 17)
        Me.optVietnameseEnglish.TabIndex = 1
        Me.optVietnameseEnglish.TabStop = True
        Me.optVietnameseEnglish.Text = "Song ngữ Việt - Anh"
        Me.optVietnameseEnglish.UseVisualStyleBackColor = True
        '
        'optVietnamese
        '
        Me.optVietnamese.AutoSize = True
        Me.optVietnamese.Location = New System.Drawing.Point(15, 35)
        Me.optVietnamese.Name = "optVietnamese"
        Me.optVietnamese.Size = New System.Drawing.Size(73, 17)
        Me.optVietnamese.TabIndex = 0
        Me.optVietnamese.TabStop = True
        Me.optVietnamese.Text = "Tiếng Việt"
        Me.optVietnamese.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(359, 244)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkFormula
        '
        Me.chkFormula.AutoSize = True
        Me.chkFormula.Location = New System.Drawing.Point(6, 141)
        Me.chkFormula.Name = "chkFormula"
        Me.chkFormula.Size = New System.Drawing.Size(364, 17)
        Me.chkFormula.TabIndex = 6
        Me.chkFormula.Text = "Hiển thị diễn giải / công thức tính lương tại màn hình kết quả tính lương"
        Me.chkFormula.UseVisualStyleBackColor = True
        '
        'D45F0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 271)
        Me.Controls.Add(Me.tabOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F0002"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tîy chãn - D45F0002"
        Me.tabOption.ResumeLayout(False)
        Me.TabPageDefault.ResumeLayout(False)
        Me.TabPageDefault.PerformLayout()
        Me.grpPieceMethod.ResumeLayout(False)
        Me.grpPieceMethod.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageShow.ResumeLayout(False)
        Me.TabPageShow.PerformLayout()
        Me.TabPageReport.ResumeLayout(False)
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
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
    Friend WithEvents TabPageShow As System.Windows.Forms.TabPage
    Private WithEvents chkUseEnterMoveDown As System.Windows.Forms.CheckBox
    Private WithEvents chkCancelEmployeeID As System.Windows.Forms.CheckBox
    Private WithEvents chkAutoCopy As System.Windows.Forms.CheckBox
    Private WithEvents lblDefaultDivision As System.Windows.Forms.Label
    Private WithEvents chkSaveLastRecent As System.Windows.Forms.CheckBox
    Friend WithEvents TabPageReport As System.Windows.Forms.TabPage
    Private WithEvents grp2 As System.Windows.Forms.GroupBox
    Private WithEvents optEnglish As System.Windows.Forms.RadioButton
    Private WithEvents optVietnameseEnglish As System.Windows.Forms.RadioButton
    Private WithEvents optVietnamese As System.Windows.Forms.RadioButton
    Private WithEvents chkShowReportPath As System.Windows.Forms.CheckBox
    Private WithEvents grpPieceMethod As System.Windows.Forms.GroupBox
    Private WithEvents optPieceWorkMethod2 As System.Windows.Forms.RadioButton
    Private WithEvents optPieceWorkMethod1 As System.Windows.Forms.RadioButton
    Private WithEvents optPieceWorkMethod3 As System.Windows.Forms.RadioButton
    Private WithEvents chkFormula As System.Windows.Forms.CheckBox
End Class