<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1033
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1033))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.txtDateBeginBaseOn = New System.Windows.Forms.TextBox
        Me.txtDutyName = New System.Windows.Forms.TextBox
        Me.txtDutyID = New System.Windows.Forms.TextBox
        Me.tdbcTemplateID = New C1.Win.C1List.C1Combo
        Me.lblTemplateID = New System.Windows.Forms.Label
        Me.txtTemplateName = New System.Windows.Forms.TextBox
        Me.lblDutyID = New System.Windows.Forms.Label
        Me.lblDateBeginBaseOn = New System.Windows.Forms.Label
        Me.btnTemplate = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grp1.SuspendLayout()
        CType(Me.tdbcTemplateID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.txtDateBeginBaseOn)
        Me.grp1.Controls.Add(Me.txtDutyName)
        Me.grp1.Controls.Add(Me.txtDutyID)
        Me.grp1.Controls.Add(Me.tdbcTemplateID)
        Me.grp1.Controls.Add(Me.lblTemplateID)
        Me.grp1.Controls.Add(Me.txtTemplateName)
        Me.grp1.Controls.Add(Me.lblDutyID)
        Me.grp1.Controls.Add(Me.lblDateBeginBaseOn)
        Me.grp1.Location = New System.Drawing.Point(4, -1)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(486, 103)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'txtDateBeginBaseOn
        '
        Me.txtDateBeginBaseOn.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDateBeginBaseOn.Location = New System.Drawing.Point(113, 74)
        Me.txtDateBeginBaseOn.Name = "txtDateBeginBaseOn"
        Me.txtDateBeginBaseOn.ReadOnly = True
        Me.txtDateBeginBaseOn.Size = New System.Drawing.Size(128, 20)
        Me.txtDateBeginBaseOn.TabIndex = 4
        '
        'txtDutyName
        '
        Me.txtDutyName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDutyName.Location = New System.Drawing.Point(247, 44)
        Me.txtDutyName.Name = "txtDutyName"
        Me.txtDutyName.ReadOnly = True
        Me.txtDutyName.Size = New System.Drawing.Size(219, 22)
        Me.txtDutyName.TabIndex = 3
        '
        'txtDutyID
        '
        Me.txtDutyID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDutyID.Location = New System.Drawing.Point(113, 45)
        Me.txtDutyID.Name = "txtDutyID"
        Me.txtDutyID.ReadOnly = True
        Me.txtDutyID.Size = New System.Drawing.Size(128, 22)
        Me.txtDutyID.TabIndex = 2
        '
        'tdbcTemplateID
        '
        Me.tdbcTemplateID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTemplateID.AllowColMove = False
        Me.tdbcTemplateID.AllowSort = False
        Me.tdbcTemplateID.AlternatingRows = True
        Me.tdbcTemplateID.AutoCompletion = True
        Me.tdbcTemplateID.AutoDropDown = True
        Me.tdbcTemplateID.Caption = ""
        Me.tdbcTemplateID.CaptionHeight = 17
        Me.tdbcTemplateID.CaptionStyle = Style1
        Me.tdbcTemplateID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTemplateID.ColumnCaptionHeight = 17
        Me.tdbcTemplateID.ColumnFooterHeight = 17
        Me.tdbcTemplateID.ColumnWidth = 100
        Me.tdbcTemplateID.ContentHeight = 17
        Me.tdbcTemplateID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTemplateID.DisplayMember = "TemplateID"
        Me.tdbcTemplateID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTemplateID.DropDownWidth = 300
        Me.tdbcTemplateID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTemplateID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTemplateID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTemplateID.EditorHeight = 17
        Me.tdbcTemplateID.EmptyRows = True
        Me.tdbcTemplateID.EvenRowStyle = Style2
        Me.tdbcTemplateID.ExtendRightColumn = True
        Me.tdbcTemplateID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTemplateID.FooterStyle = Style3
        Me.tdbcTemplateID.HeadingStyle = Style4
        Me.tdbcTemplateID.HighLightRowStyle = Style5
        Me.tdbcTemplateID.Images.Add(CType(resources.GetObject("tdbcTemplateID.Images"), System.Drawing.Image))
        Me.tdbcTemplateID.ItemHeight = 15
        Me.tdbcTemplateID.Location = New System.Drawing.Point(113, 15)
        Me.tdbcTemplateID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTemplateID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTemplateID.MaxLength = 32767
        Me.tdbcTemplateID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTemplateID.Name = "tdbcTemplateID"
        Me.tdbcTemplateID.OddRowStyle = Style6
        Me.tdbcTemplateID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTemplateID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTemplateID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTemplateID.SelectedStyle = Style7
        Me.tdbcTemplateID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcTemplateID.Style = Style8
        Me.tdbcTemplateID.TabIndex = 0
        Me.tdbcTemplateID.ValueMember = "TemplateID"
        Me.tdbcTemplateID.PropBag = resources.GetString("tdbcTemplateID.PropBag")
        '
        'lblTemplateID
        '
        Me.lblTemplateID.AutoSize = True
        Me.lblTemplateID.Location = New System.Drawing.Point(13, 20)
        Me.lblTemplateID.Name = "lblTemplateID"
        Me.lblTemplateID.Size = New System.Drawing.Size(51, 13)
        Me.lblTemplateID.TabIndex = 1
        Me.lblTemplateID.Text = "Template"
        Me.lblTemplateID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemplateName
        '
        Me.txtTemplateName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtTemplateName.Location = New System.Drawing.Point(247, 15)
        Me.txtTemplateName.Name = "txtTemplateName"
        Me.txtTemplateName.ReadOnly = True
        Me.txtTemplateName.Size = New System.Drawing.Size(219, 22)
        Me.txtTemplateName.TabIndex = 1
        Me.txtTemplateName.TabStop = False
        '
        'lblDutyID
        '
        Me.lblDutyID.AutoSize = True
        Me.lblDutyID.Location = New System.Drawing.Point(13, 49)
        Me.lblDutyID.Name = "lblDutyID"
        Me.lblDutyID.Size = New System.Drawing.Size(47, 13)
        Me.lblDutyID.TabIndex = 4
        Me.lblDutyID.Text = "Chức vụ"
        Me.lblDutyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDateBeginBaseOn
        '
        Me.lblDateBeginBaseOn.AutoSize = True
        Me.lblDateBeginBaseOn.Location = New System.Drawing.Point(13, 79)
        Me.lblDateBeginBaseOn.Name = "lblDateBeginBaseOn"
        Me.lblDateBeginBaseOn.Size = New System.Drawing.Size(94, 13)
        Me.lblDateBeginBaseOn.TabIndex = 7
        Me.lblDateBeginBaseOn.Text = "Ngày bắt đầu tính"
        Me.lblDateBeginBaseOn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnTemplate
        '
        Me.btnTemplate.Location = New System.Drawing.Point(310, 108)
        Me.btnTemplate.Name = "btnTemplate"
        Me.btnTemplate.Size = New System.Drawing.Size(100, 22)
        Me.btnTemplate.TabIndex = 1
        Me.btnTemplate.Text = "&Gán template"
        Me.btnTemplate.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(414, 108)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D13F1033
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 136)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnTemplate)
        Me.Controls.Add(Me.grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1033"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GÀn template tŸng th¤ng sç l§¥ng - D13F1033"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcTemplateID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcTemplateID As C1.Win.C1List.C1Combo
    Private WithEvents lblTemplateID As System.Windows.Forms.Label
    Private WithEvents txtTemplateName As System.Windows.Forms.TextBox
    Private WithEvents txtDutyID As System.Windows.Forms.TextBox
    Private WithEvents txtDutyName As System.Windows.Forms.TextBox
    Private WithEvents lblDutyID As System.Windows.Forms.Label
    Private WithEvents btnTemplate As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents txtDateBeginBaseOn As System.Windows.Forms.TextBox
    Private WithEvents lblDateBeginBaseOn As System.Windows.Forms.Label
End Class
