<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1110
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1110))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tdbcDutyID = New C1.Win.C1List.C1Combo()
        Me.lblDutyID = New System.Windows.Forms.Label()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDutyID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(5, 38)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(870, 477)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "sCOL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(717, 521)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(799, 521)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbcDutyID
        '
        Me.tdbcDutyID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDutyID.AllowColMove = False
        Me.tdbcDutyID.AllowSort = False
        Me.tdbcDutyID.AlternatingRows = True
        Me.tdbcDutyID.AutoCompletion = True
        Me.tdbcDutyID.AutoDropDown = True
        Me.tdbcDutyID.Caption = ""
        Me.tdbcDutyID.CaptionHeight = 17
        Me.tdbcDutyID.CaptionStyle = Style1
        Me.tdbcDutyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDutyID.ColumnCaptionHeight = 17
        Me.tdbcDutyID.ColumnFooterHeight = 17
        Me.tdbcDutyID.ColumnWidth = 100
        Me.tdbcDutyID.ContentHeight = 17
        Me.tdbcDutyID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDutyID.DisplayMember = "DutyName"
        Me.tdbcDutyID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDutyID.DropDownWidth = 350
        Me.tdbcDutyID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDutyID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDutyID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDutyID.EditorHeight = 17
        Me.tdbcDutyID.EmptyRows = True
        Me.tdbcDutyID.EvenRowStyle = Style2
        Me.tdbcDutyID.ExtendRightColumn = True
        Me.tdbcDutyID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDutyID.FooterStyle = Style3
        Me.tdbcDutyID.HeadingStyle = Style4
        Me.tdbcDutyID.HighLightRowStyle = Style5
        Me.tdbcDutyID.Images.Add(CType(resources.GetObject("tdbcDutyID.Images"), System.Drawing.Image))
        Me.tdbcDutyID.ItemHeight = 15
        Me.tdbcDutyID.Location = New System.Drawing.Point(72, 9)
        Me.tdbcDutyID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDutyID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDutyID.MaxLength = 32767
        Me.tdbcDutyID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDutyID.Name = "tdbcDutyID"
        Me.tdbcDutyID.OddRowStyle = Style6
        Me.tdbcDutyID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDutyID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDutyID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDutyID.SelectedStyle = Style7
        Me.tdbcDutyID.Size = New System.Drawing.Size(197, 23)
        Me.tdbcDutyID.Style = Style8
        Me.tdbcDutyID.TabIndex = 3
        Me.tdbcDutyID.ValueMember = "DutyID"
        Me.tdbcDutyID.PropBag = resources.GetString("tdbcDutyID.PropBag")
        '
        'lblDutyID
        '
        Me.lblDutyID.AutoSize = True
        Me.lblDutyID.Location = New System.Drawing.Point(7, 14)
        Me.lblDutyID.Name = "lblDutyID"
        Me.lblDutyID.Size = New System.Drawing.Size(47, 13)
        Me.lblDutyID.TabIndex = 4
        Me.lblDutyID.Text = "Chức vụ"
        Me.lblDutyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D13F1110
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 546)
        Me.Controls.Add(Me.tdbcDutyID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lblDutyID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1110"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Th¤ng tin hÖ sç - D13F1110"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDutyID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcDutyID As C1.Win.C1List.C1Combo
    Private WithEvents lblDutyID As System.Windows.Forms.Label
End Class
