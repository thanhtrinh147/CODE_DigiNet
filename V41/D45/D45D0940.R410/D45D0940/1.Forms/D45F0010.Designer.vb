<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F0010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F0010))
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
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.TabUnitPrice = New System.Windows.Forms.TabPage()
        Me.grpHAUnitPrice = New System.Windows.Forms.GroupBox()
        Me.tdbg4 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grpUnitPrice = New System.Windows.Forms.GroupBox()
        Me.tdbg3 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.TabFormular = New System.Windows.Forms.TabPage()
        Me.txtFormular = New System.Windows.Forms.TextBox()
        Me.tdbg2 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblFormular = New System.Windows.Forms.Label()
        Me.tdbdDecimals = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        Me.tabMain.SuspendLayout()
        Me.TabUnitPrice.SuspendLayout()
        Me.grpHAUnitPrice.SuspendLayout()
        CType(Me.tdbg4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpUnitPrice.SuspendLayout()
        CType(Me.tdbg3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabFormular.SuspendLayout()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdDecimals, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(714, 384)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(632, 384)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.TabUnitPrice)
        Me.tabMain.Controls.Add(Me.TabFormular)
        Me.tabMain.Location = New System.Drawing.Point(3, 3)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(787, 373)
        Me.tabMain.TabIndex = 0
        '
        'TabUnitPrice
        '
        Me.TabUnitPrice.Controls.Add(Me.grpHAUnitPrice)
        Me.TabUnitPrice.Controls.Add(Me.grpUnitPrice)
        Me.TabUnitPrice.Location = New System.Drawing.Point(4, 22)
        Me.TabUnitPrice.Name = "TabUnitPrice"
        Me.TabUnitPrice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabUnitPrice.Size = New System.Drawing.Size(779, 347)
        Me.TabUnitPrice.TabIndex = 0
        Me.TabUnitPrice.Text = "1. Định nghĩa các loại đơn giá"
        Me.TabUnitPrice.UseVisualStyleBackColor = True
        '
        'grpHAUnitPrice
        '
        Me.grpHAUnitPrice.Controls.Add(Me.tdbg4)
        Me.grpHAUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpHAUnitPrice.Location = New System.Drawing.Point(6, 181)
        Me.grpHAUnitPrice.Name = "grpHAUnitPrice"
        Me.grpHAUnitPrice.Size = New System.Drawing.Size(762, 156)
        Me.grpHAUnitPrice.TabIndex = 1
        Me.grpHAUnitPrice.TabStop = False
        Me.grpHAUnitPrice.Text = "Đơn giá thường"
        '
        'tdbg4
        '
        Me.tdbg4.AllowColMove = False
        Me.tdbg4.AllowColSelect = False
        Me.tdbg4.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg4.AllowSort = False
        Me.tdbg4.AlternatingRows = True
        Me.tdbg4.CaptionHeight = 17
        Me.tdbg4.EmptyRows = True
        Me.tdbg4.ExtendRightColumn = True
        Me.tdbg4.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg4.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg4.Images.Add(CType(resources.GetObject("tdbg4.Images"), System.Drawing.Image))
        Me.tdbg4.Location = New System.Drawing.Point(7, 22)
        Me.tdbg4.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg4.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg4.Name = "tdbg4"
        Me.tdbg4.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg4.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg4.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg4.PrintInfo.PageSettings = CType(resources.GetObject("tdbg4.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg4.RowHeight = 15
        Me.tdbg4.Size = New System.Drawing.Size(747, 127)
        Me.tdbg4.TabAcrossSplits = True
        Me.tdbg4.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg4.TabIndex = 0
        Me.tdbg4.Tag = "COL4"
        Me.tdbg4.PropBag = resources.GetString("tdbg4.PropBag")
        '
        'grpUnitPrice
        '
        Me.grpUnitPrice.Controls.Add(Me.tdbdDecimals)
        Me.grpUnitPrice.Controls.Add(Me.tdbg3)
        Me.grpUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpUnitPrice.Location = New System.Drawing.Point(10, 8)
        Me.grpUnitPrice.Name = "grpUnitPrice"
        Me.grpUnitPrice.Size = New System.Drawing.Size(762, 157)
        Me.grpUnitPrice.TabIndex = 0
        Me.grpUnitPrice.TabStop = False
        Me.grpUnitPrice.Text = "Đơn giá thường"
        '
        'tdbg3
        '
        Me.tdbg3.AllowColMove = False
        Me.tdbg3.AllowColSelect = False
        Me.tdbg3.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg3.AllowSort = False
        Me.tdbg3.AlternatingRows = True
        Me.tdbg3.CaptionHeight = 17
        Me.tdbg3.EmptyRows = True
        Me.tdbg3.ExtendRightColumn = True
        Me.tdbg3.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg3.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg3.Images.Add(CType(resources.GetObject("tdbg3.Images"), System.Drawing.Image))
        Me.tdbg3.Location = New System.Drawing.Point(7, 22)
        Me.tdbg3.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg3.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg3.Name = "tdbg3"
        Me.tdbg3.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg3.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg3.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg3.PrintInfo.PageSettings = CType(resources.GetObject("tdbg3.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg3.RowHeight = 15
        Me.tdbg3.Size = New System.Drawing.Size(747, 127)
        Me.tdbg3.TabAcrossSplits = True
        Me.tdbg3.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg3.TabIndex = 0
        Me.tdbg3.Tag = "COL3"
        Me.tdbg3.PropBag = resources.GetString("tdbg3.PropBag")
        '
        'TabFormular
        '
        Me.TabFormular.Controls.Add(Me.txtFormular)
        Me.TabFormular.Controls.Add(Me.tdbg2)
        Me.TabFormular.Controls.Add(Me.tdbg)
        Me.TabFormular.Controls.Add(Me.lblFormular)
        Me.TabFormular.Location = New System.Drawing.Point(4, 22)
        Me.TabFormular.Name = "TabFormular"
        Me.TabFormular.Padding = New System.Windows.Forms.Padding(3)
        Me.TabFormular.Size = New System.Drawing.Size(779, 347)
        Me.TabFormular.TabIndex = 1
        Me.TabFormular.Text = "2. Định nghĩa công thức cho tham số"
        Me.TabFormular.UseVisualStyleBackColor = True
        '
        'txtFormular
        '
        Me.txtFormular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtFormular.Location = New System.Drawing.Point(481, 24)
        Me.txtFormular.MaxLength = 8000
        Me.txtFormular.Multiline = True
        Me.txtFormular.Name = "txtFormular"
        Me.txtFormular.Size = New System.Drawing.Size(290, 124)
        Me.txtFormular.TabIndex = 2
        '
        'tdbg2
        '
        Me.tdbg2.AllowColMove = False
        Me.tdbg2.AllowColSelect = False
        Me.tdbg2.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg2.AllowSort = False
        Me.tdbg2.AllowUpdate = False
        Me.tdbg2.AlternatingRows = True
        Me.tdbg2.CaptionHeight = 17
        Me.tdbg2.EmptyRows = True
        Me.tdbg2.ExtendRightColumn = True
        Me.tdbg2.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg2.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg2.Images.Add(CType(resources.GetObject("tdbg2.Images"), System.Drawing.Image))
        Me.tdbg2.Location = New System.Drawing.Point(481, 154)
        Me.tdbg2.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg2.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg2.Name = "tdbg2"
        Me.tdbg2.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg2.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg2.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg2.PrintInfo.PageSettings = CType(resources.GetObject("tdbg2.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg2.RowHeight = 15
        Me.tdbg2.Size = New System.Drawing.Size(290, 188)
        Me.tdbg2.TabAcrossSplits = True
        Me.tdbg2.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg2.TabIndex = 3
        Me.tdbg2.Tag = "COL2"
        Me.tdbg2.PropBag = resources.GetString("tdbg2.PropBag")
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 6)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(469, 336)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'lblFormular
        '
        Me.lblFormular.AutoSize = True
        Me.lblFormular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFormular.Location = New System.Drawing.Point(481, 6)
        Me.lblFormular.Name = "lblFormular"
        Me.lblFormular.Size = New System.Drawing.Size(65, 13)
        Me.lblFormular.TabIndex = 1
        Me.lblFormular.Text = "Công thức"
        Me.lblFormular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbdDecimals
        '
        Me.tdbdDecimals.AllowColMove = False
        Me.tdbdDecimals.AllowColSelect = False
        Me.tdbdDecimals.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdDecimals.AllowSort = False
        Me.tdbdDecimals.AlternatingRows = True
        Me.tdbdDecimals.CaptionStyle = Style1
        Me.tdbdDecimals.ColumnCaptionHeight = 17
        Me.tdbdDecimals.ColumnFooterHeight = 17
        Me.tdbdDecimals.DisplayMember = "ID"
        Me.tdbdDecimals.EmptyRows = True
        Me.tdbdDecimals.EvenRowStyle = Style2
        Me.tdbdDecimals.ExtendRightColumn = True
        Me.tdbdDecimals.FetchRowStyles = False
        Me.tdbdDecimals.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbdDecimals.FooterStyle = Style3
        Me.tdbdDecimals.HeadingStyle = Style4
        Me.tdbdDecimals.HighLightRowStyle = Style5
        Me.tdbdDecimals.Images.Add(CType(resources.GetObject("tdbdDecimals.Images"), System.Drawing.Image))
        Me.tdbdDecimals.Location = New System.Drawing.Point(577, -21)
        Me.tdbdDecimals.Name = "tdbdDecimals"
        Me.tdbdDecimals.OddRowStyle = Style6
        Me.tdbdDecimals.RecordSelectorStyle = Style7
        Me.tdbdDecimals.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdDecimals.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdDecimals.RowHeight = 15
        Me.tdbdDecimals.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdDecimals.ScrollTips = False
        Me.tdbdDecimals.Size = New System.Drawing.Size(98, 100)
        Me.tdbdDecimals.Style = Style8
        Me.tdbdDecimals.TabIndex = 1
        Me.tdbdDecimals.TabStop = False
        Me.tdbdDecimals.ValueMember = "ID"
        Me.tdbdDecimals.Visible = False
        Me.tdbdDecimals.PropBag = resources.GetString("tdbdDecimals.PropBag")
        '
        'D45F0010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(793, 412)
        Me.Controls.Add(Me.tabMain)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F0010"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "˜Ünh nghÚa cÀc loÁi ˜¥n giÀ/ Sç l§íng - D45F0010"
        Me.tabMain.ResumeLayout(False)
        Me.TabUnitPrice.ResumeLayout(False)
        Me.grpHAUnitPrice.ResumeLayout(False)
        CType(Me.tdbg4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpUnitPrice.ResumeLayout(False)
        CType(Me.tdbg3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabFormular.ResumeLayout(False)
        Me.TabFormular.PerformLayout()
        CType(Me.tdbg2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdDecimals, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents TabUnitPrice As System.Windows.Forms.TabPage
    Friend WithEvents TabFormular As System.Windows.Forms.TabPage
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents txtFormular As System.Windows.Forms.TextBox
    Private WithEvents tdbg2 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents lblFormular As System.Windows.Forms.Label
    Private WithEvents grpUnitPrice As System.Windows.Forms.GroupBox
    Private WithEvents tdbg3 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents grpHAUnitPrice As System.Windows.Forms.GroupBox
    Private WithEvents tdbg4 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdDecimals As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class