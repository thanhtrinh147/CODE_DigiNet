<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1081
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
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1081))
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.txtTransTypeID = New System.Windows.Forms.TextBox
        Me.lblTransTypeID = New System.Windows.Forms.Label
        Me.txtTransTypeName = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.tdbdCaptionName = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.tdbdGroupDataID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnNext = New System.Windows.Forms.Button
        CType(Me.tdbdCaptionName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdGroupDataID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtTransTypeID
        '
        Me.txtTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransTypeID.Location = New System.Drawing.Point(118, 12)
        Me.txtTransTypeID.MaxLength = 20
        Me.txtTransTypeID.Name = "txtTransTypeID"
        Me.txtTransTypeID.Size = New System.Drawing.Size(158, 22)
        Me.txtTransTypeID.TabIndex = 1
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(6, 17)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 0
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransTypeName.Location = New System.Drawing.Point(279, 12)
        Me.txtTransTypeName.MaxLength = 250
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.Size = New System.Drawing.Size(429, 22)
        Me.txtTransTypeName.TabIndex = 2
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(633, 387)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(469, 387)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tdbdCaptionName
        '
        Me.tdbdCaptionName.AllowColMove = False
        Me.tdbdCaptionName.AllowColSelect = False
        Me.tdbdCaptionName.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdCaptionName.AllowSort = False
        Me.tdbdCaptionName.AlternatingRows = True
        Me.tdbdCaptionName.CaptionHeight = 17
        Me.tdbdCaptionName.CaptionStyle = Style1
        Me.tdbdCaptionName.ColumnCaptionHeight = 17
        Me.tdbdCaptionName.ColumnFooterHeight = 17
        Me.tdbdCaptionName.DisplayMember = "CaptionName"
        Me.tdbdCaptionName.EmptyRows = True
        Me.tdbdCaptionName.EvenRowStyle = Style2
        Me.tdbdCaptionName.ExtendRightColumn = True
        Me.tdbdCaptionName.FetchRowStyles = False
        Me.tdbdCaptionName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdCaptionName.FooterStyle = Style3
        Me.tdbdCaptionName.HeadingStyle = Style4
        Me.tdbdCaptionName.HighLightRowStyle = Style5
        Me.tdbdCaptionName.Images.Add(CType(resources.GetObject("tdbdCaptionName.Images"), System.Drawing.Image))
        Me.tdbdCaptionName.Location = New System.Drawing.Point(42, 95)
        Me.tdbdCaptionName.Name = "tdbdCaptionName"
        Me.tdbdCaptionName.OddRowStyle = Style6
        Me.tdbdCaptionName.RecordSelectorStyle = Style7
        Me.tdbdCaptionName.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdCaptionName.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdCaptionName.RowHeight = 15
        Me.tdbdCaptionName.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdCaptionName.ScrollTips = False
        Me.tdbdCaptionName.Size = New System.Drawing.Size(228, 147)
        Me.tdbdCaptionName.Style = Style8
        Me.tdbdCaptionName.TabIndex = 5
        Me.tdbdCaptionName.TabStop = False
        Me.tdbdCaptionName.ValueMember = "CaptionName"
        Me.tdbdCaptionName.Visible = False
        Me.tdbdCaptionName.PropBag = resources.GetString("tdbdCaptionName.PropBag")
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(3, 387)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 4
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'tdbdGroupDataID
        '
        Me.tdbdGroupDataID.AllowColMove = False
        Me.tdbdGroupDataID.AllowColSelect = False
        Me.tdbdGroupDataID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdGroupDataID.AllowSort = False
        Me.tdbdGroupDataID.AlternatingRows = True
        Me.tdbdGroupDataID.CaptionHeight = 17
        Me.tdbdGroupDataID.CaptionStyle = Style9
        Me.tdbdGroupDataID.ColumnCaptionHeight = 17
        Me.tdbdGroupDataID.ColumnFooterHeight = 17
        Me.tdbdGroupDataID.DisplayMember = "GroupDataName"
        Me.tdbdGroupDataID.EmptyRows = True
        Me.tdbdGroupDataID.EvenRowStyle = Style10
        Me.tdbdGroupDataID.ExtendRightColumn = True
        Me.tdbdGroupDataID.FetchRowStyles = False
        Me.tdbdGroupDataID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdGroupDataID.FooterStyle = Style11
        Me.tdbdGroupDataID.HeadingStyle = Style12
        Me.tdbdGroupDataID.HighLightRowStyle = Style13
        Me.tdbdGroupDataID.Images.Add(CType(resources.GetObject("tdbdGroupDataID.Images"), System.Drawing.Image))
        Me.tdbdGroupDataID.Location = New System.Drawing.Point(148, 114)
        Me.tdbdGroupDataID.Name = "tdbdGroupDataID"
        Me.tdbdGroupDataID.OddRowStyle = Style14
        Me.tdbdGroupDataID.RecordSelectorStyle = Style15
        Me.tdbdGroupDataID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdGroupDataID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdGroupDataID.RowHeight = 15
        Me.tdbdGroupDataID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdGroupDataID.ScrollTips = False
        Me.tdbdGroupDataID.Size = New System.Drawing.Size(300, 147)
        Me.tdbdGroupDataID.Style = Style16
        Me.tdbdGroupDataID.TabIndex = 4
        Me.tdbdGroupDataID.TabStop = False
        Me.tdbdGroupDataID.ValueMember = "GroupDataName"
        Me.tdbdGroupDataID.Visible = False
        Me.tdbdGroupDataID.PropBag = resources.GetString("tdbdGroupDataID.PropBag")
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
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 46)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(706, 334)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(551, 387)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'D25F1081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 415)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.tdbdGroupDataID)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.tdbdCaptionName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtTransTypeName)
        Me.Controls.Add(Me.txtTransTypeID)
        Me.Controls.Add(Me.lblTransTypeID)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1081"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "˜Ünh nghÚa hä s¥ ÷ng cõ vi£n - D25F1081"
        CType(Me.tdbdCaptionName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdGroupDataID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtTransTypeID As System.Windows.Forms.TextBox
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tdbdCaptionName As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents tdbdGroupDataID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnNext As System.Windows.Forms.Button
End Class
