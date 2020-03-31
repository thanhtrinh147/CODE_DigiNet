<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F3010
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
        Dim mnuDeleteLink As C1.Win.C1Command.C1CommandLink
        Dim mnuSysInfoLink As C1.Win.C1Command.C1CommandLink
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F3010))
        Me.mnuDelete = New C1.Win.C1Command.C1Command
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnClose = New System.Windows.Forms.Button
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink
        Me.mnuDetail = New C1.Win.C1Command.C1Command
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.btnAction = New System.Windows.Forms.Button
        mnuDeleteLink = New C1.Win.C1Command.C1CommandLink
        mnuSysInfoLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grp1.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuDeleteLink
        '
        mnuDeleteLink.Command = Me.mnuDelete
        mnuDeleteLink.Delimiter = True
        mnuDeleteLink.SortOrder = 1
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "&Xóa kết quả "
        '
        'mnuSysInfoLink
        '
        mnuSysInfoLink.Command = Me.mnuSysInfo
        mnuSysInfoLink.Delimiter = True
        mnuSysInfoLink.SortOrder = 2
        '
        'mnuSysInfo
        '
        Me.mnuSysInfo.Name = "mnuSysInfo"
        Me.mnuSysInfo.Text = "Thông tin &hệ thống"
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 12)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(772, 446)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(712, 469)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, mnuDeleteLink, mnuSysInfoLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuDetail
        '
        'mnuDetail
        '
        Me.mnuDetail.Name = "mnuDetail"
        Me.mnuDetail.Text = "Chi tiết"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuDetail)
        Me.C1CommandHolder.Owner = Me
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbg)
        Me.grp1.Location = New System.Drawing.Point(4, -1)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(784, 464)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(632, 469)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 1
        Me.btnAction.Text = "&Thực hiện..."
        Me.btnAction.UseVisualStyleBackColor = True
        '
        'D13F3010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(794, 501)
        Me.Controls.Add(Me.btnAction)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F3010"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChuyÓn bòt toÀn - D13F3010"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grp1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuDetail As C1.Win.C1Command.C1Command
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents btnAction As System.Windows.Forms.Button
End Class