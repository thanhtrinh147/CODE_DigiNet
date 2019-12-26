<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1002))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tdbdSRoutingID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.TableToolStrip = New System.Windows.Forms.ToolStrip
        Me.tsbInherit = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFind = New System.Windows.Forms.ToolStripButton
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmInherit = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator
        Me.mnsInherit = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdSRoutingID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableToolStrip.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 28)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(588, 366)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'tdbdSRoutingID
        '
        Me.tdbdSRoutingID.AllowColMove = False
        Me.tdbdSRoutingID.AllowColSelect = False
        Me.tdbdSRoutingID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdSRoutingID.AllowSort = False
        Me.tdbdSRoutingID.AlternatingRows = True
        Me.tdbdSRoutingID.CaptionHeight = 17
        Me.tdbdSRoutingID.CaptionStyle = Style1
        Me.tdbdSRoutingID.ColumnCaptionHeight = 17
        Me.tdbdSRoutingID.ColumnFooterHeight = 17
        Me.tdbdSRoutingID.DisplayMember = "SRoutingID"
        Me.tdbdSRoutingID.EmptyRows = True
        Me.tdbdSRoutingID.EvenRowStyle = Style2
        Me.tdbdSRoutingID.ExtendRightColumn = True
        Me.tdbdSRoutingID.FetchRowStyles = False
        Me.tdbdSRoutingID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbdSRoutingID.FooterStyle = Style3
        Me.tdbdSRoutingID.HeadingStyle = Style4
        Me.tdbdSRoutingID.HighLightRowStyle = Style5
        Me.tdbdSRoutingID.Images.Add(CType(resources.GetObject("tdbdSRoutingID.Images"), System.Drawing.Image))
        Me.tdbdSRoutingID.Location = New System.Drawing.Point(85, 84)
        Me.tdbdSRoutingID.Name = "tdbdSRoutingID"
        Me.tdbdSRoutingID.OddRowStyle = Style6
        Me.tdbdSRoutingID.RecordSelectorStyle = Style7
        Me.tdbdSRoutingID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdSRoutingID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdSRoutingID.RowHeight = 15
        Me.tdbdSRoutingID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdSRoutingID.ScrollTips = False
        Me.tdbdSRoutingID.Size = New System.Drawing.Size(300, 147)
        Me.tdbdSRoutingID.Style = Style8
        Me.tdbdSRoutingID.TabIndex = 5
        Me.tdbdSRoutingID.TabStop = False
        Me.tdbdSRoutingID.ValueMember = "SRoutingID"
        Me.tdbdSRoutingID.Visible = False
        Me.tdbdSRoutingID.PropBag = resources.GetString("tdbdSRoutingID.PropBag")
        '
        'TableToolStrip
        '
        Me.TableToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbInherit, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator2, Me.tsbClose, Me.ToolStripSeparator6, Me.tsdActive})
        Me.TableToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TableToolStrip.Name = "TableToolStrip"
        Me.TableToolStrip.Size = New System.Drawing.Size(594, 25)
        Me.TableToolStrip.TabIndex = 13
        Me.TableToolStrip.Text = "tbrTest"
        '
        'tsbInherit
        '
        Me.tsbInherit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInherit.Name = "tsbInherit"
        Me.tsbInherit.Size = New System.Drawing.Size(48, 22)
        Me.tsbInherit.Text = "Kế thừa"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbFind
        '
        Me.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(53, 22)
        Me.tsbFind.Text = "Tìm kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(73, 22)
        Me.tsbListAll.Text = "Liệt kê tất cả"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClose
        '
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(37, 22)
        Me.tsbClose.Text = "Đóng"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmInherit, Me.ToolStripSeparator5, Me.tsmFind, Me.tsmListAll})
        Me.tsdActive.Image = CType(resources.GetObject("tsdActive.Image"), System.Drawing.Image)
        Me.tsdActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(68, 22)
        Me.tsdActive.Text = "Thực hiện"
        '
        'tsmInherit
        '
        Me.tsmInherit.Name = "tsmInherit"
        Me.tsmInherit.Size = New System.Drawing.Size(152, 22)
        Me.tsmInherit.Text = "Kế thừ&a"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(149, 6)
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(152, 22)
        Me.tsmFind.Text = "Tìm kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(152, 22)
        Me.tsmListAll.Text = "Liệt kê tất cả"
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsInherit, Me.ToolStripSeparator_SysInfo, Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 76)
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
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(133, 6)
        '
        'mnsInherit
        '
        Me.mnsInherit.Name = "mnsInherit"
        Me.mnsInherit.Size = New System.Drawing.Size(136, 22)
        Me.mnsInherit.Text = "Kế thừ&a"
        '
        'D45F1002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 399)
        Me.Controls.Add(Me.TableToolStrip)
        Me.Controls.Add(Me.tdbdSRoutingID)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1002"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa s¶n phÈm - D45F1002"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdSRoutingID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableToolStrip.ResumeLayout(False)
        Me.TableToolStrip.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdSRoutingID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Friend WithEvents TableToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbInherit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmInherit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsInherit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem

End Class