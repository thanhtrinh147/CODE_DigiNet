<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F0050
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F0050))
        Me.tdbgPropose = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.Tab1 = New System.Windows.Forms.TabPage()
        Me.Tab2 = New System.Windows.Forms.TabPage()
        Me.tdbgResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Tab3 = New System.Windows.Forms.TabPage()
        Me.tdbgRef = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Tab4 = New System.Windows.Forms.TabPage()
        Me.tdbgU = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Tab5 = New System.Windows.Forms.TabPage()
        Me.tdbgIdentification = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.Tab6 = New System.Windows.Forms.TabPage()
        Me.tdbg6 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.tdbgPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabMain.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        CType(Me.tdbgResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab3.SuspendLayout()
        CType(Me.tdbgRef, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab4.SuspendLayout()
        CType(Me.tdbgU, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab5.SuspendLayout()
        CType(Me.tdbgIdentification, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tab6.SuspendLayout()
        CType(Me.tdbg6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbgPropose
        '
        Me.tdbgPropose.AllowColMove = False
        Me.tdbgPropose.AllowColSelect = False
        Me.tdbgPropose.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgPropose.AllowSort = False
        Me.tdbgPropose.AlternatingRows = True
        Me.tdbgPropose.CaptionHeight = 17
        Me.tdbgPropose.EmptyRows = True
        Me.tdbgPropose.ExtendRightColumn = True
        Me.tdbgPropose.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgPropose.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgPropose.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgPropose.Images.Add(CType(resources.GetObject("tdbgPropose.Images"), System.Drawing.Image))
        Me.tdbgPropose.Location = New System.Drawing.Point(6, 4)
        Me.tdbgPropose.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgPropose.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgPropose.Name = "tdbgPropose"
        Me.tdbgPropose.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgPropose.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgPropose.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgPropose.PrintInfo.PageSettings = CType(resources.GetObject("tdbgPropose.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgPropose.RowHeight = 15
        Me.tdbgPropose.Size = New System.Drawing.Size(558, 319)
        Me.tdbgPropose.TabAcrossSplits = True
        Me.tdbgPropose.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgPropose.TabIndex = 0
        Me.tdbgPropose.Tag = "COLP"
        Me.tdbgPropose.PropBag = resources.GetString("tdbgPropose.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(422, 363)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(504, 363)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.Tab1)
        Me.tabMain.Controls.Add(Me.Tab2)
        Me.tabMain.Controls.Add(Me.Tab3)
        Me.tabMain.Controls.Add(Me.Tab4)
        Me.tabMain.Controls.Add(Me.Tab5)
        Me.tabMain.Controls.Add(Me.Tab6)
        Me.tabMain.Location = New System.Drawing.Point(2, 6)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(578, 354)
        Me.tabMain.TabIndex = 4
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.tdbgPropose)
        Me.Tab1.Location = New System.Drawing.Point(4, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab1.Size = New System.Drawing.Size(570, 328)
        Me.Tab1.TabIndex = 0
        Me.Tab1.Text = "Đề xuất tuyển dụng"
        Me.Tab1.UseVisualStyleBackColor = True
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.tdbgResult)
        Me.Tab2.Location = New System.Drawing.Point(4, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab2.Size = New System.Drawing.Size(570, 328)
        Me.Tab2.TabIndex = 1
        Me.Tab2.Text = "Kết quả phỏng vấn"
        Me.Tab2.UseVisualStyleBackColor = True
        '
        'tdbgResult
        '
        Me.tdbgResult.AllowColMove = False
        Me.tdbgResult.AllowColSelect = False
        Me.tdbgResult.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgResult.AllowSort = False
        Me.tdbgResult.AlternatingRows = True
        Me.tdbgResult.CaptionHeight = 17
        Me.tdbgResult.EmptyRows = True
        Me.tdbgResult.ExtendRightColumn = True
        Me.tdbgResult.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgResult.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgResult.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgResult.Images.Add(CType(resources.GetObject("tdbgResult.Images"), System.Drawing.Image))
        Me.tdbgResult.Location = New System.Drawing.Point(6, 5)
        Me.tdbgResult.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgResult.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgResult.Name = "tdbgResult"
        Me.tdbgResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgResult.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgResult.PrintInfo.PageSettings = CType(resources.GetObject("tdbgResult.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgResult.RowHeight = 15
        Me.tdbgResult.Size = New System.Drawing.Size(558, 318)
        Me.tdbgResult.TabAcrossSplits = True
        Me.tdbgResult.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgResult.TabIndex = 1
        Me.tdbgResult.Tag = "COLR"
        Me.tdbgResult.PropBag = resources.GetString("tdbgResult.PropBag")
        '
        'Tab3
        '
        Me.Tab3.Controls.Add(Me.tdbgRef)
        Me.Tab3.Location = New System.Drawing.Point(4, 22)
        Me.Tab3.Name = "Tab3"
        Me.Tab3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab3.Size = New System.Drawing.Size(570, 328)
        Me.Tab3.TabIndex = 2
        Me.Tab3.Text = "Đề xuất/ Kế hoạch đào tạo"
        Me.Tab3.UseVisualStyleBackColor = True
        '
        'tdbgRef
        '
        Me.tdbgRef.AllowColMove = False
        Me.tdbgRef.AllowColSelect = False
        Me.tdbgRef.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgRef.AllowSort = False
        Me.tdbgRef.AlternatingRows = True
        Me.tdbgRef.CaptionHeight = 17
        Me.tdbgRef.EmptyRows = True
        Me.tdbgRef.ExtendRightColumn = True
        Me.tdbgRef.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgRef.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgRef.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgRef.Images.Add(CType(resources.GetObject("tdbgRef.Images"), System.Drawing.Image))
        Me.tdbgRef.Location = New System.Drawing.Point(6, 4)
        Me.tdbgRef.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgRef.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgRef.Name = "tdbgRef"
        Me.tdbgRef.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgRef.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgRef.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgRef.PrintInfo.PageSettings = CType(resources.GetObject("tdbgRef.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgRef.RowHeight = 15
        Me.tdbgRef.Size = New System.Drawing.Size(558, 319)
        Me.tdbgRef.TabAcrossSplits = True
        Me.tdbgRef.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgRef.TabIndex = 2
        Me.tdbgRef.Tag = "sCOLR"
        Me.tdbgRef.PropBag = resources.GetString("tdbgRef.PropBag")
        '
        'Tab4
        '
        Me.Tab4.Controls.Add(Me.tdbgU)
        Me.Tab4.Location = New System.Drawing.Point(4, 22)
        Me.Tab4.Name = "Tab4"
        Me.Tab4.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab4.Size = New System.Drawing.Size(570, 328)
        Me.Tab4.TabIndex = 3
        Me.Tab4.Text = "Cập nhật kết quả đào tạo"
        Me.Tab4.UseVisualStyleBackColor = True
        '
        'tdbgU
        '
        Me.tdbgU.AllowColMove = False
        Me.tdbgU.AllowColSelect = False
        Me.tdbgU.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgU.AllowSort = False
        Me.tdbgU.AlternatingRows = True
        Me.tdbgU.CaptionHeight = 17
        Me.tdbgU.EmptyRows = True
        Me.tdbgU.ExtendRightColumn = True
        Me.tdbgU.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgU.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgU.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgU.Images.Add(CType(resources.GetObject("tdbgU.Images"), System.Drawing.Image))
        Me.tdbgU.Location = New System.Drawing.Point(6, 4)
        Me.tdbgU.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgU.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgU.Name = "tdbgU"
        Me.tdbgU.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgU.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgU.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgU.PrintInfo.PageSettings = CType(resources.GetObject("tdbgU.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgU.RowHeight = 15
        Me.tdbgU.Size = New System.Drawing.Size(558, 320)
        Me.tdbgU.TabAcrossSplits = True
        Me.tdbgU.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgU.TabIndex = 3
        Me.tdbgU.Tag = "sCOL"
        Me.tdbgU.PropBag = resources.GetString("tdbgU.PropBag")
        '
        'Tab5
        '
        Me.Tab5.Controls.Add(Me.tdbgIdentification)
        Me.Tab5.Location = New System.Drawing.Point(4, 22)
        Me.Tab5.Name = "Tab5"
        Me.Tab5.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab5.Size = New System.Drawing.Size(570, 328)
        Me.Tab5.TabIndex = 4
        Me.Tab5.Text = "Giấy tờ tùy thân"
        Me.Tab5.UseVisualStyleBackColor = True
        '
        'tdbgIdentification
        '
        Me.tdbgIdentification.AllowColMove = False
        Me.tdbgIdentification.AllowColSelect = False
        Me.tdbgIdentification.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgIdentification.AllowSort = False
        Me.tdbgIdentification.AlternatingRows = True
        Me.tdbgIdentification.CaptionHeight = 17
        Me.tdbgIdentification.ColumnFooters = True
        Me.tdbgIdentification.EmptyRows = True
        Me.tdbgIdentification.ExtendRightColumn = True
        Me.tdbgIdentification.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgIdentification.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgIdentification.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgIdentification.Images.Add(CType(resources.GetObject("tdbgIdentification.Images"), System.Drawing.Image))
        Me.tdbgIdentification.Location = New System.Drawing.Point(6, 5)
        Me.tdbgIdentification.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgIdentification.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgIdentification.Name = "tdbgIdentification"
        Me.tdbgIdentification.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgIdentification.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgIdentification.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgIdentification.PrintInfo.PageSettings = CType(resources.GetObject("tdbgIdentification.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgIdentification.RowHeight = 15
        Me.tdbgIdentification.Size = New System.Drawing.Size(558, 319)
        Me.tdbgIdentification.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbgIdentification.TabAcrossSplits = True
        Me.tdbgIdentification.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgIdentification.TabIndex = 0
        Me.tdbgIdentification.Tag = "sCOLI"
        Me.tdbgIdentification.WrapCellPointer = True
        Me.tdbgIdentification.PropBag = resources.GetString("tdbgIdentification.PropBag")
        '
        'Tab6
        '
        Me.Tab6.Controls.Add(Me.tdbg6)
        Me.Tab6.Location = New System.Drawing.Point(4, 22)
        Me.Tab6.Name = "Tab6"
        Me.Tab6.Padding = New System.Windows.Forms.Padding(3)
        Me.Tab6.Size = New System.Drawing.Size(570, 328)
        Me.Tab6.TabIndex = 5
        Me.Tab6.Text = "Cổng thông tin ứng viên"
        Me.Tab6.UseVisualStyleBackColor = True
        '
        'tdbg6
        '
        Me.tdbg6.AllowColMove = False
        Me.tdbg6.AllowColSelect = False
        Me.tdbg6.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg6.AllowSort = False
        Me.tdbg6.AlternatingRows = True
        Me.tdbg6.CaptionHeight = 17
        Me.tdbg6.EmptyRows = True
        Me.tdbg6.ExtendRightColumn = True
        Me.tdbg6.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg6.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg6.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg6.Images.Add(CType(resources.GetObject("tdbg6.Images"), System.Drawing.Image))
        Me.tdbg6.Location = New System.Drawing.Point(6, 5)
        Me.tdbg6.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg6.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg6.Name = "tdbg6"
        Me.tdbg6.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg6.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg6.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg6.PrintInfo.PageSettings = CType(resources.GetObject("tdbg6.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg6.RowHeight = 15
        Me.tdbg6.Size = New System.Drawing.Size(558, 319)
        Me.tdbg6.TabAcrossSplits = True
        Me.tdbg6.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg6.TabIndex = 3
        Me.tdbg6.Tag = "sCOLR"
        Me.tdbg6.PropBag = resources.GetString("tdbg6.PropBag")
        '
        'D25F0050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 389)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F0050"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp th¤ng tin tham chiÕu - D25F0050"
        CType(Me.tdbgPropose, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabMain.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab2.ResumeLayout(False)
        CType(Me.tdbgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab3.ResumeLayout(False)
        CType(Me.tdbgRef, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab4.ResumeLayout(False)
        CType(Me.tdbgU, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab5.ResumeLayout(False)
        CType(Me.tdbgIdentification, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tab6.ResumeLayout(False)
        CType(Me.tdbg6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbgPropose As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents Tab1 As System.Windows.Forms.TabPage
    Friend WithEvents Tab2 As System.Windows.Forms.TabPage
    Private WithEvents tdbgResult As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Tab3 As System.Windows.Forms.TabPage
    Private WithEvents tdbgRef As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Tab4 As System.Windows.Forms.TabPage
    Private WithEvents tdbgU As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Tab5 As System.Windows.Forms.TabPage
    Private WithEvents tdbgIdentification As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Tab6 As System.Windows.Forms.TabPage
    Private WithEvents tdbg6 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
