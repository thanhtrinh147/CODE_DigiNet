<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F2021
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
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F2021))
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnShow = New System.Windows.Forms.Button
        Me.tdbdEmployeeID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.chkIsUsed = New System.Windows.Forms.CheckBox
        CType(Me.tdbdEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnSave.Location = New System.Drawing.Point(855, 625)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Default
        Me.btnClose.Location = New System.Drawing.Point(937, 625)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(5, 625)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(100, 22)
        Me.btnShow.TabIndex = 6
        Me.btnShow.Text = "Hiển thị"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'tdbdEmployeeID
        '
        Me.tdbdEmployeeID.AllowColMove = False
        Me.tdbdEmployeeID.AllowColSelect = False
        Me.tdbdEmployeeID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdEmployeeID.AllowSort = False
        Me.tdbdEmployeeID.AlternatingRows = True
        Me.tdbdEmployeeID.CaptionHeight = 17
        Me.tdbdEmployeeID.CaptionStyle = Style9
        Me.tdbdEmployeeID.ColumnCaptionHeight = 17
        Me.tdbdEmployeeID.ColumnFooterHeight = 17
        Me.tdbdEmployeeID.DisplayMember = "EmployeeName"
        Me.tdbdEmployeeID.EmptyRows = True
        Me.tdbdEmployeeID.EvenRowStyle = Style10
        Me.tdbdEmployeeID.ExtendRightColumn = True
        Me.tdbdEmployeeID.FetchRowStyles = False
        Me.tdbdEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdEmployeeID.FooterStyle = Style11
        Me.tdbdEmployeeID.HeadingStyle = Style12
        Me.tdbdEmployeeID.HighLightRowStyle = Style13
        Me.tdbdEmployeeID.Images.Add(CType(resources.GetObject("tdbdEmployeeID.Images"), System.Drawing.Image))
        Me.tdbdEmployeeID.Location = New System.Drawing.Point(424, 101)
        Me.tdbdEmployeeID.Name = "tdbdEmployeeID"
        Me.tdbdEmployeeID.OddRowStyle = Style14
        Me.tdbdEmployeeID.RecordSelectorStyle = Style15
        Me.tdbdEmployeeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdEmployeeID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdEmployeeID.RowHeight = 15
        Me.tdbdEmployeeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdEmployeeID.ScrollTips = False
        Me.tdbdEmployeeID.Size = New System.Drawing.Size(350, 147)
        Me.tdbdEmployeeID.Style = Style16
        Me.tdbdEmployeeID.TabIndex = 19
        Me.tdbdEmployeeID.TabStop = False
        Me.tdbdEmployeeID.ValueMember = "EmployeeID"
        Me.tdbdEmployeeID.ValueTranslate = True
        Me.tdbdEmployeeID.Visible = False
        Me.tdbdEmployeeID.PropBag = resources.GetString("tdbdEmployeeID.PropBag")
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
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
        Me.tdbg.Location = New System.Drawing.Point(5, 6)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1008, 613)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(143, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(142, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(142, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(111, 629)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(155, 17)
        Me.chkIsUsed.TabIndex = 32
        Me.chkIsUsed.Text = "Chỉ hiển thị dữ liệu đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'D25F2021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.tdbdEmployeeID)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F2021"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DuyÖt ¢Ò xuÊt tuyÓn dóng - D25F2021"
        CType(Me.tdbdEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnShow As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdEmployeeID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox
End Class
