<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F5557
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
        Me.components = New System.ComponentModel.Container
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F5557))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.chkLockedVouchers = New System.Windows.Forms.CheckBox
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbcTransactionTypeID = New C1.Win.C1List.C1Combo
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.lblTransactionTypeID = New System.Windows.Forms.Label
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.tdbcTransactionTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkLockedVouchers
        '
        Me.chkLockedVouchers.AutoSize = True
        Me.chkLockedVouchers.Location = New System.Drawing.Point(302, 12)
        Me.chkLockedVouchers.Name = "chkLockedVouchers"
        Me.chkLockedVouchers.Size = New System.Drawing.Size(96, 17)
        Me.chkLockedVouchers.TabIndex = 2
        Me.chkLockedVouchers.Text = "Phiếu đã khóa"
        Me.chkLockedVouchers.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(148, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(147, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(147, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(861, 627)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(941, 627)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbcTransactionTypeID
        '
        Me.tdbcTransactionTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransactionTypeID.AllowColMove = False
        Me.tdbcTransactionTypeID.AllowSort = False
        Me.tdbcTransactionTypeID.AlternatingRows = True
        Me.tdbcTransactionTypeID.AutoDropDown = True
        Me.tdbcTransactionTypeID.Caption = ""
        Me.tdbcTransactionTypeID.CaptionHeight = 17
        Me.tdbcTransactionTypeID.CaptionStyle = Style1
        Me.tdbcTransactionTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransactionTypeID.ColumnCaptionHeight = 17
        Me.tdbcTransactionTypeID.ColumnFooterHeight = 17
        Me.tdbcTransactionTypeID.ColumnWidth = 100
        Me.tdbcTransactionTypeID.ContentHeight = 17
        Me.tdbcTransactionTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransactionTypeID.DisplayMember = "TransactionTypeName"
        Me.tdbcTransactionTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTransactionTypeID.DropDownWidth = 200
        Me.tdbcTransactionTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransactionTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransactionTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransactionTypeID.EditorHeight = 17
        Me.tdbcTransactionTypeID.EmptyRows = True
        Me.tdbcTransactionTypeID.EvenRowStyle = Style2
        Me.tdbcTransactionTypeID.ExtendRightColumn = True
        Me.tdbcTransactionTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransactionTypeID.FooterStyle = Style3
        Me.tdbcTransactionTypeID.HeadingStyle = Style4
        Me.tdbcTransactionTypeID.HighLightRowStyle = Style5
        Me.tdbcTransactionTypeID.Images.Add(CType(resources.GetObject("tdbcTransactionTypeID.Images"), System.Drawing.Image))
        Me.tdbcTransactionTypeID.ItemHeight = 15
        Me.tdbcTransactionTypeID.Location = New System.Drawing.Point(96, 9)
        Me.tdbcTransactionTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransactionTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransactionTypeID.MaxLength = 32767
        Me.tdbcTransactionTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransactionTypeID.Name = "tdbcTransactionTypeID"
        Me.tdbcTransactionTypeID.OddRowStyle = Style6
        Me.tdbcTransactionTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransactionTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransactionTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransactionTypeID.SelectedStyle = Style7
        Me.tdbcTransactionTypeID.Size = New System.Drawing.Size(200, 23)
        Me.tdbcTransactionTypeID.Style = Style8
        Me.tdbcTransactionTypeID.TabIndex = 1
        Me.tdbcTransactionTypeID.ValueMember = "TransactionTypeID"
        Me.tdbcTransactionTypeID.PropBag = resources.GetString("tdbcTransactionTypeID.PropBag")
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 40)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 581)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'lblTransactionTypeID
        '
        Me.lblTransactionTypeID.AutoSize = True
        Me.lblTransactionTypeID.Location = New System.Drawing.Point(12, 13)
        Me.lblTransactionTypeID.Name = "lblTransactionTypeID"
        Me.lblTransactionTypeID.Size = New System.Drawing.Size(56, 13)
        Me.lblTransactionTypeID.TabIndex = 0
        Me.lblTransactionTypeID.Text = "Nghiệp vụ"
        Me.lblTransactionTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D13F5557
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.tdbcTransactionTypeID)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lblTransactionTypeID)
        Me.Controls.Add(Me.chkLockedVouchers)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F5557"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Khâa phiÕu - D13F5557"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.tdbcTransactionTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkLockedVouchers As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcTransactionTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransactionTypeID As System.Windows.Forms.Label
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
End Class
