<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1101
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1101))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.txtResultReferenceID = New System.Windows.Forms.TextBox
        Me.lblResultReferenceID = New System.Windows.Forms.Label
        Me.txtResultReferenceName = New System.Windows.Forms.TextBox
        Me.lblResultReferenceName = New System.Windows.Forms.Label
        Me.txtNotice = New System.Windows.Forms.TextBox
        Me.lblNotice = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbdMethod = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.optModeValue = New System.Windows.Forms.RadioButton
        Me.optModeDate = New System.Windows.Forms.RadioButton
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtResultReferenceID
        '
        Me.txtResultReferenceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtResultReferenceID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtResultReferenceID.Location = New System.Drawing.Point(87, 9)
        Me.txtResultReferenceID.Name = "txtResultReferenceID"
        Me.txtResultReferenceID.Size = New System.Drawing.Size(215, 22)
        Me.txtResultReferenceID.TabIndex = 1
        '
        'lblResultReferenceID
        '
        Me.lblResultReferenceID.AutoSize = True
        Me.lblResultReferenceID.Location = New System.Drawing.Point(6, 14)
        Me.lblResultReferenceID.Name = "lblResultReferenceID"
        Me.lblResultReferenceID.Size = New System.Drawing.Size(22, 13)
        Me.lblResultReferenceID.TabIndex = 0
        Me.lblResultReferenceID.Text = "Mã"
        Me.lblResultReferenceID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtResultReferenceName
        '
        Me.txtResultReferenceName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtResultReferenceName.Location = New System.Drawing.Point(87, 37)
        Me.txtResultReferenceName.MaxLength = 250
        Me.txtResultReferenceName.Name = "txtResultReferenceName"
        Me.txtResultReferenceName.Size = New System.Drawing.Size(499, 22)
        Me.txtResultReferenceName.TabIndex = 4
        '
        'lblResultReferenceName
        '
        Me.lblResultReferenceName.AutoSize = True
        Me.lblResultReferenceName.Location = New System.Drawing.Point(6, 42)
        Me.lblResultReferenceName.Name = "lblResultReferenceName"
        Me.lblResultReferenceName.Size = New System.Drawing.Size(48, 13)
        Me.lblResultReferenceName.TabIndex = 3
        Me.lblResultReferenceName.Text = "Diễn giải"
        Me.lblResultReferenceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNotice
        '
        Me.txtNotice.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNotice.Location = New System.Drawing.Point(87, 65)
        Me.txtNotice.MaxLength = 250
        Me.txtNotice.Name = "txtNotice"
        Me.txtNotice.Size = New System.Drawing.Size(499, 22)
        Me.txtNotice.TabIndex = 6
        '
        'lblNotice
        '
        Me.lblNotice.AutoSize = True
        Me.lblNotice.Location = New System.Drawing.Point(6, 70)
        Me.lblNotice.Name = "lblNotice"
        Me.lblNotice.Size = New System.Drawing.Size(44, 13)
        Me.lblNotice.TabIndex = 5
        Me.lblNotice.Text = "Ghi chú"
        Me.lblNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(469, 12)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 124)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(577, 238)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 8
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(344, 369)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 22)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(427, 369)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(77, 22)
        Me.btnNext.TabIndex = 10
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(510, 369)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 11
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbdMethod
        '
        Me.tdbdMethod.AllowColMove = False
        Me.tdbdMethod.AllowColSelect = False
        Me.tdbdMethod.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdMethod.AllowSort = False
        Me.tdbdMethod.AlternatingRows = True
        Me.tdbdMethod.CaptionHeight = 17
        Me.tdbdMethod.CaptionStyle = Style1
        Me.tdbdMethod.ColumnCaptionHeight = 17
        Me.tdbdMethod.ColumnFooterHeight = 17
        Me.tdbdMethod.DisplayMember = "MethodName"
        Me.tdbdMethod.EmptyRows = True
        Me.tdbdMethod.EvenRowStyle = Style2
        Me.tdbdMethod.ExtendRightColumn = True
        Me.tdbdMethod.FetchRowStyles = False
        Me.tdbdMethod.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tdbdMethod.FooterStyle = Style3
        Me.tdbdMethod.HeadingStyle = Style4
        Me.tdbdMethod.HighLightRowStyle = Style5
        Me.tdbdMethod.Images.Add(CType(resources.GetObject("tdbdMethod.Images"), System.Drawing.Image))
        Me.tdbdMethod.Location = New System.Drawing.Point(125, 174)
        Me.tdbdMethod.Name = "tdbdMethod"
        Me.tdbdMethod.OddRowStyle = Style6
        Me.tdbdMethod.RecordSelectorStyle = Style7
        Me.tdbdMethod.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdMethod.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdMethod.RowHeight = 15
        Me.tdbdMethod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdMethod.ScrollTips = False
        Me.tdbdMethod.Size = New System.Drawing.Size(239, 147)
        Me.tdbdMethod.Style = Style8
        Me.tdbdMethod.TabIndex = 11
        Me.tdbdMethod.TabStop = False
        Me.tdbdMethod.ValueMember = "MethodName"
        Me.tdbdMethod.Visible = False
        Me.tdbdMethod.PropBag = resources.GetString("tdbdMethod.PropBag")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optModeValue)
        Me.Panel1.Controls.Add(Me.optModeDate)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(71, 93)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(200, 27)
        Me.Panel1.TabIndex = 7
        '
        'optModeValue
        '
        Me.optModeValue.AutoSize = True
        Me.optModeValue.Checked = True
        Me.optModeValue.Location = New System.Drawing.Point(16, 6)
        Me.optModeValue.Name = "optModeValue"
        Me.optModeValue.Size = New System.Drawing.Size(52, 17)
        Me.optModeValue.TabIndex = 0
        Me.optModeValue.TabStop = True
        Me.optModeValue.Text = "Giá trị"
        Me.optModeValue.UseVisualStyleBackColor = True
        '
        'optModeDate
        '
        Me.optModeDate.AutoSize = True
        Me.optModeDate.Location = New System.Drawing.Point(133, 6)
        Me.optModeDate.Name = "optModeDate"
        Me.optModeDate.Size = New System.Drawing.Size(50, 17)
        Me.optModeDate.TabIndex = 1
        Me.optModeDate.Text = "Ngày"
        Me.optModeDate.UseVisualStyleBackColor = True
        '
        'D13F1101
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 399)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tdbdMethod)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtNotice)
        Me.Controls.Add(Me.txtResultReferenceName)
        Me.Controls.Add(Me.txtResultReferenceID)
        Me.Controls.Add(Me.lblResultReferenceID)
        Me.Controls.Add(Me.lblResultReferenceName)
        Me.Controls.Add(Me.lblNotice)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1101"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt b¶ng tham chiÕu kÕt qu¶ - D13F1101"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtResultReferenceID As System.Windows.Forms.TextBox
    Private WithEvents lblResultReferenceID As System.Windows.Forms.Label
    Private WithEvents txtResultReferenceName As System.Windows.Forms.TextBox
    Private WithEvents lblResultReferenceName As System.Windows.Forms.Label
    Private WithEvents txtNotice As System.Windows.Forms.TextBox
    Private WithEvents lblNotice As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbdMethod As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents optModeValue As System.Windows.Forms.RadioButton
    Private WithEvents optModeDate As System.Windows.Forms.RadioButton
End Class
