<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F0003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F0003))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grpBox = New System.Windows.Forms.GroupBox
        Me.tdbcPeriod = New C1.Win.C1List.C1Combo
        Me.tdbcDivisionID = New C1.Win.C1List.C1Combo
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.btnSelected = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpBox.SuspendLayout()
        CType(Me.tdbcPeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpBox
        '
        Me.grpBox.Controls.Add(Me.tdbcPeriod)
        Me.grpBox.Controls.Add(Me.tdbcDivisionID)
        Me.grpBox.Controls.Add(Me.lblDivisionID)
        Me.grpBox.Controls.Add(Me.lblPeriod)
        Me.grpBox.Location = New System.Drawing.Point(12, 6)
        Me.grpBox.Name = "grpBox"
        Me.grpBox.Size = New System.Drawing.Size(270, 89)
        Me.grpBox.TabIndex = 0
        Me.grpBox.TabStop = False
        '
        'tdbcPeriod
        '
        Me.tdbcPeriod.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPeriod.AllowColMove = False
        Me.tdbcPeriod.AllowSort = False
        Me.tdbcPeriod.AlternatingRows = True
        Me.tdbcPeriod.AutoCompletion = True
        Me.tdbcPeriod.AutoDropDown = True
        Me.tdbcPeriod.Caption = ""
        Me.tdbcPeriod.CaptionHeight = 17
        Me.tdbcPeriod.CaptionStyle = Style1
        Me.tdbcPeriod.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPeriod.ColumnCaptionHeight = 17
        Me.tdbcPeriod.ColumnFooterHeight = 17
        Me.tdbcPeriod.ColumnHeaders = False
        Me.tdbcPeriod.ColumnWidth = 100
        Me.tdbcPeriod.ContentHeight = 17
        Me.tdbcPeriod.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPeriod.DisplayMember = "Period"
        Me.tdbcPeriod.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPeriod.DropDownWidth = 155
        Me.tdbcPeriod.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPeriod.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriod.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPeriod.EditorHeight = 17
        Me.tdbcPeriod.EmptyRows = True
        Me.tdbcPeriod.EvenRowStyle = Style2
        Me.tdbcPeriod.ExtendRightColumn = True
        Me.tdbcPeriod.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.tdbcPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPeriod.FooterStyle = Style3
        Me.tdbcPeriod.HeadingStyle = Style4
        Me.tdbcPeriod.HighLightRowStyle = Style5
        Me.tdbcPeriod.Images.Add(CType(resources.GetObject("tdbcPeriod.Images"), System.Drawing.Image))
        Me.tdbcPeriod.ItemHeight = 15
        Me.tdbcPeriod.LimitToList = True
        Me.tdbcPeriod.Location = New System.Drawing.Point(94, 53)
        Me.tdbcPeriod.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPeriod.MaxDropDownItems = CType(8, Short)
        Me.tdbcPeriod.MaxLength = 32767
        Me.tdbcPeriod.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPeriod.Name = "tdbcPeriod"
        Me.tdbcPeriod.OddRowStyle = Style6
        Me.tdbcPeriod.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPeriod.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPeriod.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPeriod.SelectedStyle = Style7
        Me.tdbcPeriod.Size = New System.Drawing.Size(155, 23)
        Me.tdbcPeriod.Style = Style8
        Me.tdbcPeriod.TabIndex = 2
        Me.tdbcPeriod.ValueMember = "Period"
        Me.tdbcPeriod.PropBag = resources.GetString("tdbcPeriod.PropBag")
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
        Me.tdbcDivisionID.LimitToList = True
        Me.tdbcDivisionID.Location = New System.Drawing.Point(94, 19)
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
        Me.tdbcDivisionID.Size = New System.Drawing.Size(155, 23)
        Me.tdbcDivisionID.Style = Style16
        Me.tdbcDivisionID.TabIndex = 0
        Me.tdbcDivisionID.ValueMember = "DivisionID"
        Me.tdbcDivisionID.PropBag = resources.GetString("tdbcDivisionID.PropBag")
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(17, 24)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(38, 13)
        Me.lblDivisionID.TabIndex = 1
        Me.lblDivisionID.Text = "Đơn vị"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(17, 58)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(58, 13)
        Me.lblPeriod.TabIndex = 3
        Me.lblPeriod.Text = "Kỳ kế toán"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSelected
        '
        Me.btnSelected.Location = New System.Drawing.Point(124, 101)
        Me.btnSelected.Name = "btnSelected"
        Me.btnSelected.Size = New System.Drawing.Size(76, 22)
        Me.btnSelected.TabIndex = 2
        Me.btnSelected.Text = "Chọn"
        Me.btnSelected.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(206, 101)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D45F0003
        '
        Me.AcceptButton = Me.btnSelected
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(294, 132)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSelected)
        Me.Controls.Add(Me.grpBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F0003"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn kù kÕ toÀn - D45F0003"
        Me.grpBox.ResumeLayout(False)
        Me.grpBox.PerformLayout()
        CType(Me.tdbcPeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDivisionID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grpBox As System.Windows.Forms.GroupBox
    Private WithEvents btnSelected As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcDivisionID As C1.Win.C1List.C1Combo
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
    Private WithEvents tdbcPeriod As C1.Win.C1List.C1Combo
    Private WithEvents lblPeriod As System.Windows.Forms.Label
End Class