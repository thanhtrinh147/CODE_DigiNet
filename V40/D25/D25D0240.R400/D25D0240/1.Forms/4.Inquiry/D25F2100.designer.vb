<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F2100
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F2100))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnShowOption = New System.Windows.Forms.Button()
        Me.tdbdApproverID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.chkIsUsed = New System.Windows.Forms.CheckBox()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.tdbdApproverID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(935, 629)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(853, 629)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 18
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
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
        Me.tdbg.Cursor = System.Windows.Forms.Cursors.Default
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 11)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1002, 614)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 17
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(136, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(136, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'btnShowOption
        '
        Me.btnShowOption.Location = New System.Drawing.Point(9, 629)
        Me.btnShowOption.Name = "btnShowOption"
        Me.btnShowOption.Size = New System.Drawing.Size(81, 22)
        Me.btnShowOption.TabIndex = 23
        Me.btnShowOption.Text = "Hiển thị"
        Me.btnShowOption.UseVisualStyleBackColor = True
        '
        'tdbdApproverID
        '
        Me.tdbdApproverID.AllowColMove = False
        Me.tdbdApproverID.AllowColSelect = False
        Me.tdbdApproverID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdApproverID.AllowSort = False
        Me.tdbdApproverID.AlternatingRows = True
        Me.tdbdApproverID.CaptionHeight = 17
        Me.tdbdApproverID.CaptionStyle = Style1
        Me.tdbdApproverID.ColumnCaptionHeight = 17
        Me.tdbdApproverID.ColumnFooterHeight = 17
        Me.tdbdApproverID.DisplayMember = "EmployeeName"
        Me.tdbdApproverID.EmptyRows = True
        Me.tdbdApproverID.EvenRowStyle = Style2
        Me.tdbdApproverID.ExtendRightColumn = True
        Me.tdbdApproverID.FetchRowStyles = False
        Me.tdbdApproverID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdApproverID.FooterStyle = Style3
        Me.tdbdApproverID.HeadingStyle = Style4
        Me.tdbdApproverID.HighLightRowStyle = Style5
        Me.tdbdApproverID.Images.Add(CType(resources.GetObject("tdbdApproverID.Images"), System.Drawing.Image))
        Me.tdbdApproverID.Location = New System.Drawing.Point(96, 140)
        Me.tdbdApproverID.Name = "tdbdApproverID"
        Me.tdbdApproverID.OddRowStyle = Style6
        Me.tdbdApproverID.RecordSelectorStyle = Style7
        Me.tdbdApproverID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdApproverID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdApproverID.RowHeight = 15
        Me.tdbdApproverID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdApproverID.ScrollTips = False
        Me.tdbdApproverID.Size = New System.Drawing.Size(350, 147)
        Me.tdbdApproverID.Style = Style8
        Me.tdbdApproverID.TabIndex = 27
        Me.tdbdApproverID.TabStop = False
        Me.tdbdApproverID.ValueMember = "EmployeeID"
        Me.tdbdApproverID.ValueTranslate = True
        Me.tdbdApproverID.Visible = False
        Me.tdbdApproverID.PropBag = resources.GetString("tdbdApproverID.PropBag")
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(96, 633)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(155, 17)
        Me.chkIsUsed.TabIndex = 31
        Me.chkIsUsed.Text = "Chỉ hiển thị dữ liệu đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'D25F2100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.tdbdApproverID)
        Me.Controls.Add(Me.btnShowOption)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F2100"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DuyÖt quyÕt ¢Ünh tuyÓn dóng - D25F2100"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.tdbdApproverID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnShowOption As System.Windows.Forms.Button
    Private WithEvents tdbdApproverID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox

End Class
