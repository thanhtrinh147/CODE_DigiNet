<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2021
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2021))
        Me.chkIsUsed = New System.Windows.Forms.CheckBox
        Me.btnChoose = New System.Windows.Forms.Button
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.btnF12 = New System.Windows.Forms.Button
        Me.TableToolStrip = New System.Windows.Forms.ToolStrip
        Me.tsbFind = New System.Windows.Forms.ToolStripButton
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableToolStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(109, 632)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(188, 17)
        Me.chkIsUsed.TabIndex = 6
        Me.chkIsUsed.Text = "Chỉ hiển thị những dữ liệu đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(938, 629)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(76, 22)
        Me.btnChoose.TabIndex = 7
        Me.btnChoose.Text = "&Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
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
        Me.tdbg.Size = New System.Drawing.Size(1011, 598)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(0, 0)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsFind, Me.mnsListAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(141, 48)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(140, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(140, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(3, 629)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(100, 22)
        Me.btnF12.TabIndex = 10
        Me.btnF12.Text = "Hiển thị"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'TableToolStrip
        '
        Me.TableToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator1, Me.tsbClose, Me.ToolStripSeparator5, Me.tsdActive})
        Me.TableToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TableToolStrip.Name = "TableToolStrip"
        Me.TableToolStrip.Size = New System.Drawing.Size(1018, 25)
        Me.TableToolStrip.TabIndex = 11
        Me.TableToolStrip.Text = "tbrTest"
        '
        'tsbFind
        '
        Me.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbFind.Name = "tsbFind"
        Me.tsbFind.Size = New System.Drawing.Size(61, 22)
        Me.tsbFind.Text = "Tìm kiếm"
        Me.tsbFind.ToolTipText = "Tìm kiếm"
        '
        'tsbListAll
        '
        Me.tsbListAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbListAll.Name = "tsbListAll"
        Me.tsbListAll.Size = New System.Drawing.Size(77, 22)
        Me.tsbListAll.Text = "Liệt kê tất cả"
        Me.tsbListAll.ToolTipText = "Liệt kê tất cả"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbClose
        '
        Me.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClose.Name = "tsbClose"
        Me.tsbClose.Size = New System.Drawing.Size(40, 22)
        Me.tsbClose.Text = "Đóng"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsdActive
        '
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmFind, Me.tsmListAll})
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(73, 22)
        Me.tsdActive.Text = "&Thực hiện"
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(140, 22)
        Me.tsmFind.Text = "Tìm &kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(140, 22)
        Me.tsmListAll.Text = "&Liệt kê tất cả"
        '
        'D45F2021
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.TableToolStrip)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.btnChoose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2021"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn s¶n phÈm - D45F2021"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableToolStrip.ResumeLayout(False)
        Me.TableToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Friend WithEvents TableToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Private WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
End Class