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
        Me.tdbgPropose = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.tab1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.tdbgResult = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.tdbgPropose, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.tdbgResult, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.tdbgPropose.Location = New System.Drawing.Point(2, 4)
        Me.tdbgPropose.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgPropose.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgPropose.Name = "tdbgPropose"
        Me.tdbgPropose.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgPropose.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgPropose.PreviewInfo.ZoomFactor = 75
        Me.tdbgPropose.PrintInfo.PageSettings = CType(resources.GetObject("tdbgPropose.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgPropose.RowHeight = 15
        Me.tdbgPropose.Size = New System.Drawing.Size(499, 287)
        Me.tdbgPropose.TabAcrossSplits = True
        Me.tdbgPropose.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgPropose.TabIndex = 0
        Me.tdbgPropose.Tag = "COLP"
        Me.tdbgPropose.PropBag = resources.GetString("tdbgPropose.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(360, 330)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(442, 330)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tab1
        '
        Me.tab1.Controls.Add(Me.TabPage1)
        Me.tab1.Controls.Add(Me.TabPage2)
        Me.tab1.Location = New System.Drawing.Point(5, 5)
        Me.tab1.Name = "tab1"
        Me.tab1.SelectedIndex = 0
        Me.tab1.Size = New System.Drawing.Size(513, 321)
        Me.tab1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.tdbgPropose)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(505, 295)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Đề xuất tuyển dụng"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.tdbgResult)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(505, 295)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Kết quả phỏng vấn"
        Me.TabPage2.UseVisualStyleBackColor = True
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
        Me.tdbgResult.Location = New System.Drawing.Point(3, 5)
        Me.tdbgResult.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgResult.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgResult.Name = "tdbgResult"
        Me.tdbgResult.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgResult.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgResult.PreviewInfo.ZoomFactor = 75
        Me.tdbgResult.PrintInfo.PageSettings = CType(resources.GetObject("tdbgResult.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgResult.RowHeight = 15
        Me.tdbgResult.Size = New System.Drawing.Size(495, 286)
        Me.tdbgResult.TabAcrossSplits = True
        Me.tdbgResult.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgResult.TabIndex = 1
        Me.tdbgResult.Tag = "COLR"
        Me.tdbgResult.PropBag = resources.GetString("tdbgResult.PropBag")
        '
        'D25F0050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(522, 360)
        Me.Controls.Add(Me.tab1)
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
        Me.tab1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.tdbgResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbgPropose As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tab1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents tdbgResult As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
