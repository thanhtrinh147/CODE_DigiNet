<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F0002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F0002))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tabOption = New System.Windows.Forms.TabControl()
        Me.TabPageDefault = New System.Windows.Forms.TabPage()
        Me.chkShowFormular = New System.Windows.Forms.CheckBox()
        Me.chkShowZeroNumber = New System.Windows.Forms.CheckBox()
        Me.chkShowReportPath = New System.Windows.Forms.CheckBox()
        Me.chkViewFormPeriodWhenAppRun = New System.Windows.Forms.CheckBox()
        Me.chkMessageWhenSaveOK = New System.Windows.Forms.CheckBox()
        Me.chkMessageAskBeforeSave = New System.Windows.Forms.CheckBox()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.lblDivisionID = New System.Windows.Forms.Label()
        Me.tdbcDefaultDivisionID = New C1.Win.C1List.C1Combo()
        Me.txtDivisionName = New System.Windows.Forms.TextBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.grpReportLanguage = New System.Windows.Forms.GroupBox()
        Me.optReportLanguage2 = New System.Windows.Forms.RadioButton()
        Me.optReportLanguage1 = New System.Windows.Forms.RadioButton()
        Me.optReportLanguage0 = New System.Windows.Forms.RadioButton()
        Me.chkShowDiagram = New System.Windows.Forms.CheckBox()
        Me.tabOption.SuspendLayout()
        Me.TabPageDefault.SuspendLayout()
        Me.grp1.SuspendLayout()
        CType(Me.tdbcDefaultDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.grpReportLanguage.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(453, 281)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(373, 281)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabOption
        '
        Me.tabOption.Controls.Add(Me.TabPageDefault)
        Me.tabOption.Controls.Add(Me.TabPage1)
        Me.tabOption.Location = New System.Drawing.Point(3, 3)
        Me.tabOption.Name = "tabOption"
        Me.tabOption.SelectedIndex = 0
        Me.tabOption.Size = New System.Drawing.Size(526, 272)
        Me.tabOption.TabIndex = 7
        '
        'TabPageDefault
        '
        Me.TabPageDefault.Controls.Add(Me.chkShowFormular)
        Me.TabPageDefault.Controls.Add(Me.chkShowZeroNumber)
        Me.TabPageDefault.Controls.Add(Me.chkShowReportPath)
        Me.TabPageDefault.Controls.Add(Me.chkViewFormPeriodWhenAppRun)
        Me.TabPageDefault.Controls.Add(Me.chkMessageWhenSaveOK)
        Me.TabPageDefault.Controls.Add(Me.chkMessageAskBeforeSave)
        Me.TabPageDefault.Controls.Add(Me.grp1)
        Me.TabPageDefault.Location = New System.Drawing.Point(4, 22)
        Me.TabPageDefault.Name = "TabPageDefault"
        Me.TabPageDefault.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageDefault.Size = New System.Drawing.Size(518, 246)
        Me.TabPageDefault.TabIndex = 0
        Me.TabPageDefault.Text = "Mặc định"
        Me.TabPageDefault.UseVisualStyleBackColor = True
        '
        'chkShowFormular
        '
        Me.chkShowFormular.AutoSize = True
        Me.chkShowFormular.Location = New System.Drawing.Point(6, 164)
        Me.chkShowFormular.Name = "chkShowFormular"
        Me.chkShowFormular.Size = New System.Drawing.Size(318, 17)
        Me.chkShowFormular.TabIndex = 8
        Me.chkShowFormular.Text = "Hiển thị công thức tính lương tại màn hình bảng lương công ty"
        Me.chkShowFormular.UseVisualStyleBackColor = True
        '
        'chkShowZeroNumber
        '
        Me.chkShowZeroNumber.AutoSize = True
        Me.chkShowZeroNumber.Location = New System.Drawing.Point(6, 187)
        Me.chkShowZeroNumber.Name = "chkShowZeroNumber"
        Me.chkShowZeroNumber.Size = New System.Drawing.Size(239, 17)
        Me.chkShowZeroNumber.TabIndex = 7
        Me.chkShowZeroNumber.Text = "Hiển thị số 0 tại màn hình bảng lương công ty"
        Me.chkShowZeroNumber.UseVisualStyleBackColor = True
        '
        'chkShowReportPath
        '
        Me.chkShowReportPath.AutoSize = True
        Me.chkShowReportPath.Location = New System.Drawing.Point(6, 141)
        Me.chkShowReportPath.Name = "chkShowReportPath"
        Me.chkShowReportPath.Size = New System.Drawing.Size(263, 17)
        Me.chkShowReportPath.TabIndex = 6
        Me.chkShowReportPath.Text = "Hiển thị màn hình đường dẫn báo cáo cho lần sau"
        Me.chkShowReportPath.UseVisualStyleBackColor = True
        '
        'chkViewFormPeriodWhenAppRun
        '
        Me.chkViewFormPeriodWhenAppRun.AutoSize = True
        Me.chkViewFormPeriodWhenAppRun.Location = New System.Drawing.Point(6, 118)
        Me.chkViewFormPeriodWhenAppRun.Name = "chkViewFormPeriodWhenAppRun"
        Me.chkViewFormPeriodWhenAppRun.Size = New System.Drawing.Size(293, 17)
        Me.chkViewFormPeriodWhenAppRun.TabIndex = 4
        Me.chkViewFormPeriodWhenAppRun.Text = "Hiển thị màn hình chọn kỳ kế toán khi chạy chương trình"
        Me.chkViewFormPeriodWhenAppRun.UseVisualStyleBackColor = True
        '
        'chkMessageWhenSaveOK
        '
        Me.chkMessageWhenSaveOK.AutoSize = True
        Me.chkMessageWhenSaveOK.Location = New System.Drawing.Point(6, 95)
        Me.chkMessageWhenSaveOK.Name = "chkMessageWhenSaveOK"
        Me.chkMessageWhenSaveOK.Size = New System.Drawing.Size(169, 17)
        Me.chkMessageWhenSaveOK.TabIndex = 3
        Me.chkMessageWhenSaveOK.Text = "Thông báo khi lưu thành công"
        Me.chkMessageWhenSaveOK.UseVisualStyleBackColor = True
        '
        'chkMessageAskBeforeSave
        '
        Me.chkMessageAskBeforeSave.AutoSize = True
        Me.chkMessageAskBeforeSave.Location = New System.Drawing.Point(6, 72)
        Me.chkMessageAskBeforeSave.Name = "chkMessageAskBeforeSave"
        Me.chkMessageAskBeforeSave.Size = New System.Drawing.Size(103, 17)
        Me.chkMessageAskBeforeSave.TabIndex = 2
        Me.chkMessageAskBeforeSave.Text = "Hỏi trước khi lưu"
        Me.chkMessageAskBeforeSave.UseVisualStyleBackColor = True
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.lblDivisionID)
        Me.grp1.Controls.Add(Me.tdbcDefaultDivisionID)
        Me.grp1.Controls.Add(Me.txtDivisionName)
        Me.grp1.Location = New System.Drawing.Point(6, 6)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(507, 51)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(6, 23)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(85, 13)
        Me.lblDivisionID.TabIndex = 8
        Me.lblDivisionID.Text = "Đơn vị mặc định"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tdbcDefaultDivisionID.CaptionStyle = Style1
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
        Me.tdbcDefaultDivisionID.EvenRowStyle = Style2
        Me.tdbcDefaultDivisionID.ExtendRightColumn = True
        Me.tdbcDefaultDivisionID.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcDefaultDivisionID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDefaultDivisionID.FooterStyle = Style3
        Me.tdbcDefaultDivisionID.HeadingStyle = Style4
        Me.tdbcDefaultDivisionID.HighLightRowStyle = Style5
        Me.tdbcDefaultDivisionID.Images.Add(CType(resources.GetObject("tdbcDefaultDivisionID.Images"), System.Drawing.Image))
        Me.tdbcDefaultDivisionID.ItemHeight = 15
        Me.tdbcDefaultDivisionID.Location = New System.Drawing.Point(120, 19)
        Me.tdbcDefaultDivisionID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDefaultDivisionID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDefaultDivisionID.MaxLength = 32767
        Me.tdbcDefaultDivisionID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDefaultDivisionID.Name = "tdbcDefaultDivisionID"
        Me.tdbcDefaultDivisionID.OddRowStyle = Style6
        Me.tdbcDefaultDivisionID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDefaultDivisionID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDefaultDivisionID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDefaultDivisionID.SelectedStyle = Style7
        Me.tdbcDefaultDivisionID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcDefaultDivisionID.Style = Style8
        Me.tdbcDefaultDivisionID.TabIndex = 1
        Me.tdbcDefaultDivisionID.ValueMember = "DivisionID"
        Me.tdbcDefaultDivisionID.PropBag = resources.GetString("tdbcDefaultDivisionID.PropBag")
        '
        'txtDivisionName
        '
        Me.txtDivisionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDivisionName.Location = New System.Drawing.Point(249, 19)
        Me.txtDivisionName.Name = "txtDivisionName"
        Me.txtDivisionName.ReadOnly = True
        Me.txtDivisionName.Size = New System.Drawing.Size(252, 22)
        Me.txtDivisionName.TabIndex = 2
        Me.txtDivisionName.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.grpReportLanguage)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(518, 246)
        Me.TabPage1.TabIndex = 1
        Me.TabPage1.Text = "Báo cáo"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'grpReportLanguage
        '
        Me.grpReportLanguage.Controls.Add(Me.optReportLanguage2)
        Me.grpReportLanguage.Controls.Add(Me.optReportLanguage1)
        Me.grpReportLanguage.Controls.Add(Me.optReportLanguage0)
        Me.grpReportLanguage.Location = New System.Drawing.Point(17, 16)
        Me.grpReportLanguage.Name = "grpReportLanguage"
        Me.grpReportLanguage.Size = New System.Drawing.Size(483, 79)
        Me.grpReportLanguage.TabIndex = 0
        Me.grpReportLanguage.TabStop = False
        Me.grpReportLanguage.Text = "Ngôn ngữ báo cáo"
        '
        'optReportLanguage2
        '
        Me.optReportLanguage2.AutoSize = True
        Me.optReportLanguage2.Location = New System.Drawing.Point(362, 31)
        Me.optReportLanguage2.Name = "optReportLanguage2"
        Me.optReportLanguage2.Size = New System.Drawing.Size(74, 17)
        Me.optReportLanguage2.TabIndex = 2
        Me.optReportLanguage2.TabStop = True
        Me.optReportLanguage2.Text = "Tiếng Anh"
        Me.optReportLanguage2.UseVisualStyleBackColor = True
        '
        'optReportLanguage1
        '
        Me.optReportLanguage1.AutoSize = True
        Me.optReportLanguage1.Location = New System.Drawing.Point(178, 31)
        Me.optReportLanguage1.Name = "optReportLanguage1"
        Me.optReportLanguage1.Size = New System.Drawing.Size(120, 17)
        Me.optReportLanguage1.TabIndex = 1
        Me.optReportLanguage1.TabStop = True
        Me.optReportLanguage1.Text = "Song ngữ Việt - Anh"
        Me.optReportLanguage1.UseVisualStyleBackColor = True
        '
        'optReportLanguage0
        '
        Me.optReportLanguage0.AutoSize = True
        Me.optReportLanguage0.Location = New System.Drawing.Point(32, 31)
        Me.optReportLanguage0.Name = "optReportLanguage0"
        Me.optReportLanguage0.Size = New System.Drawing.Size(73, 17)
        Me.optReportLanguage0.TabIndex = 0
        Me.optReportLanguage0.TabStop = True
        Me.optReportLanguage0.Text = "Tiếng Việt"
        Me.optReportLanguage0.UseVisualStyleBackColor = True
        '
        'chkShowDiagram
        '
        Me.chkShowDiagram.AutoSize = True
        Me.chkShowDiagram.Location = New System.Drawing.Point(3, 281)
        Me.chkShowDiagram.Name = "chkShowDiagram"
        Me.chkShowDiagram.Size = New System.Drawing.Size(135, 17)
        Me.chkShowDiagram.TabIndex = 5
        Me.chkShowDiagram.Text = "Hiển thị sơ đồ quy trình"
        Me.chkShowDiagram.UseVisualStyleBackColor = True
        Me.chkShowDiagram.Visible = False
        '
        'D13F0002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 315)
        Me.Controls.Add(Me.tabOption)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkShowDiagram)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F0002"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tîy chãn - D13F0002"
        Me.tabOption.ResumeLayout(False)
        Me.TabPageDefault.ResumeLayout(False)
        Me.TabPageDefault.PerformLayout()
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcDefaultDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.grpReportLanguage.ResumeLayout(False)
        Me.grpReportLanguage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tabOption As System.Windows.Forms.TabControl
    Friend WithEvents TabPageDefault As System.Windows.Forms.TabPage
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcDefaultDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents txtDivisionName As System.Windows.Forms.TextBox
    Private WithEvents chkViewFormPeriodWhenAppRun As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageWhenSaveOK As System.Windows.Forms.CheckBox
    Private WithEvents chkMessageAskBeforeSave As System.Windows.Forms.CheckBox
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
    Private WithEvents chkShowDiagram As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents grpReportLanguage As System.Windows.Forms.GroupBox
    Private WithEvents optReportLanguage2 As System.Windows.Forms.RadioButton
    Private WithEvents optReportLanguage1 As System.Windows.Forms.RadioButton
    Private WithEvents optReportLanguage0 As System.Windows.Forms.RadioButton
    Private WithEvents chkShowReportPath As System.Windows.Forms.CheckBox
    Private WithEvents chkShowZeroNumber As System.Windows.Forms.CheckBox
    Private WithEvents chkShowFormular As System.Windows.Forms.CheckBox
End Class
