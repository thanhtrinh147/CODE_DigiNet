<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2054
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2054))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbcTypeFormula = New C1.Win.C1List.C1Combo
        Me.lblTypeFormula = New System.Windows.Forms.Label
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbcTypeFormula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbcTypeFormula
        '
        Me.tdbcTypeFormula.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTypeFormula.AllowColMove = False
        Me.tdbcTypeFormula.AllowSort = False
        Me.tdbcTypeFormula.AlternatingRows = True
        Me.tdbcTypeFormula.AutoCompletion = True
        Me.tdbcTypeFormula.AutoDropDown = True
        Me.tdbcTypeFormula.AutoSelect = True
        Me.tdbcTypeFormula.Caption = ""
        Me.tdbcTypeFormula.CaptionHeight = 17
        Me.tdbcTypeFormula.CaptionStyle = Style1
        Me.tdbcTypeFormula.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTypeFormula.ColumnCaptionHeight = 17
        Me.tdbcTypeFormula.ColumnFooterHeight = 17
        Me.tdbcTypeFormula.ColumnWidth = 100
        Me.tdbcTypeFormula.ContentHeight = 17
        Me.tdbcTypeFormula.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTypeFormula.DisplayMember = "FormulaTypeName"
        Me.tdbcTypeFormula.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTypeFormula.DropDownWidth = 193
        Me.tdbcTypeFormula.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTypeFormula.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTypeFormula.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTypeFormula.EditorHeight = 17
        Me.tdbcTypeFormula.EmptyRows = True
        Me.tdbcTypeFormula.EvenRowStyle = Style2
        Me.tdbcTypeFormula.ExtendRightColumn = True
        Me.tdbcTypeFormula.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTypeFormula.FooterStyle = Style3
        Me.tdbcTypeFormula.HeadingStyle = Style4
        Me.tdbcTypeFormula.HighLightRowStyle = Style5
        Me.tdbcTypeFormula.Images.Add(CType(resources.GetObject("tdbcTypeFormula.Images"), System.Drawing.Image))
        Me.tdbcTypeFormula.ItemHeight = 15
        Me.tdbcTypeFormula.Location = New System.Drawing.Point(86, 12)
        Me.tdbcTypeFormula.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTypeFormula.MaxDropDownItems = CType(8, Short)
        Me.tdbcTypeFormula.MaxLength = 32767
        Me.tdbcTypeFormula.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTypeFormula.Name = "tdbcTypeFormula"
        Me.tdbcTypeFormula.OddRowStyle = Style6
        Me.tdbcTypeFormula.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTypeFormula.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTypeFormula.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTypeFormula.SelectedStyle = Style7
        Me.tdbcTypeFormula.Size = New System.Drawing.Size(193, 23)
        Me.tdbcTypeFormula.Style = Style8
        Me.tdbcTypeFormula.TabIndex = 0
        Me.tdbcTypeFormula.ValueMember = "FormulaTypeID"
        Me.tdbcTypeFormula.PropBag = resources.GetString("tdbcTypeFormula.PropBag")
        '
        'lblTypeFormula
        '
        Me.lblTypeFormula.AutoSize = True
        Me.lblTypeFormula.Location = New System.Drawing.Point(12, 17)
        Me.lblTypeFormula.Name = "lblTypeFormula"
        Me.lblTypeFormula.Size = New System.Drawing.Size(27, 13)
        Me.lblTypeFormula.TabIndex = 1
        Me.lblTypeFormula.Text = "Loại"
        Me.lblTypeFormula.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(12, 52)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(593, 387)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(529, 446)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        '
        'D13F2054
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(617, 478)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.tdbcTypeFormula)
        Me.Controls.Add(Me.lblTypeFormula)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(10, 78)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2054"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc hªm tÛnh l§¥ng - D13F2054"
        CType(Me.tdbcTypeFormula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcTypeFormula As C1.Win.C1List.C1Combo
    Private WithEvents lblTypeFormula As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
