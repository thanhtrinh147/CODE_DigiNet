<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2100
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
        Dim mnuAddLink As C1.Win.C1Command.C1CommandLink
        Dim mnuViewLink As C1.Win.C1Command.C1CommandLink
        Dim mnuEditLink As C1.Win.C1Command.C1CommandLink
        Dim mnuDeleteLink As C1.Win.C1Command.C1CommandLink
        Dim mnuSysInfoLink As C1.Win.C1Command.C1CommandLink
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2100))
        Me.mnuAdd = New C1.Win.C1Command.C1Command
        Me.mnuView = New C1.Win.C1Command.C1Command
        Me.mnuEdit = New C1.Win.C1Command.C1Command
        Me.mnuDelete = New C1.Win.C1Command.C1Command
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnAction = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink
        Me.mnuCalculate = New C1.Win.C1Command.C1Command
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink
        Me.mnuCancelCalculate = New C1.Win.C1Command.C1Command
        Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink
        Me.mnuTransfred = New C1.Win.C1Command.C1Command
        Me.C1CommandLink5 = New C1.Win.C1Command.C1CommandLink
        Me.mnuDeleteTransfered = New C1.Win.C1Command.C1Command
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink
        Me.mnuShowDetail = New C1.Win.C1Command.C1Command
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder
        mnuAddLink = New C1.Win.C1Command.C1CommandLink
        mnuViewLink = New C1.Win.C1Command.C1CommandLink
        mnuEditLink = New C1.Win.C1Command.C1CommandLink
        mnuDeleteLink = New C1.Win.C1Command.C1CommandLink
        mnuSysInfoLink = New C1.Win.C1Command.C1CommandLink
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuAddLink
        '
        mnuAddLink.Command = Me.mnuAdd
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Text = "&Thêm"
        '
        'mnuViewLink
        '
        mnuViewLink.Command = Me.mnuView
        mnuViewLink.SortOrder = 1
        '
        'mnuView
        '
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Text = "Xe&m"
        '
        'mnuEditLink
        '
        mnuEditLink.Command = Me.mnuEdit
        mnuEditLink.SortOrder = 2
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Text = "&Sửa"
        '
        'mnuDeleteLink
        '
        mnuDeleteLink.Command = Me.mnuDelete
        mnuDeleteLink.SortOrder = 3
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "&Xóa"
        '
        'mnuSysInfoLink
        '
        mnuSysInfoLink.Command = Me.mnuSysInfo
        mnuSysInfoLink.Delimiter = True
        mnuSysInfoLink.SortOrder = 9
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
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(3, 4)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1012, 613)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(853, 625)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(76, 22)
        Me.btnAction.TabIndex = 1
        Me.btnAction.Text = "&Thực hiện..."
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(935, 625)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuAddLink, mnuViewLink, mnuEditLink, mnuDeleteLink, Me.C1CommandLink1, Me.C1CommandLink2, Me.C1CommandLink4, Me.C1CommandLink5, Me.C1CommandLink3, mnuSysInfoLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuCalculate
        Me.C1CommandLink1.Delimiter = True
        Me.C1CommandLink1.SortOrder = 4
        '
        'mnuCalculate
        '
        Me.mnuCalculate.Name = "mnuCalculate"
        Me.mnuCalculate.Text = "T&ính"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuCancelCalculate
        Me.C1CommandLink2.SortOrder = 5
        '
        'mnuCancelCalculate
        '
        Me.mnuCancelCalculate.Name = "mnuCancelCalculate"
        Me.mnuCancelCalculate.Text = "&Bỏ tính"
        '
        'C1CommandLink4
        '
        Me.C1CommandLink4.Command = Me.mnuTransfred
        Me.C1CommandLink4.Delimiter = True
        Me.C1CommandLink4.SortOrder = 6
        Me.C1CommandLink4.Text = "Chuyể&n bút toán "
        '
        'mnuTransfred
        '
        Me.mnuTransfred.Name = "mnuTransfred"
        Me.mnuTransfred.Text = "Chuyể&n bút toán "
        '
        'C1CommandLink5
        '
        Me.C1CommandLink5.Command = Me.mnuDeleteTransfered
        Me.C1CommandLink5.SortOrder = 7
        Me.C1CommandLink5.Text = "Xó&a chuyển bút toán "
        '
        'mnuDeleteTransfered
        '
        Me.mnuDeleteTransfered.Name = "mnuDeleteTransfered"
        Me.mnuDeleteTransfered.Text = "Xó&a chuyển bút toán "
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuShowDetail
        Me.C1CommandLink3.Delimiter = True
        Me.C1CommandLink3.SortOrder = 8
        '
        'mnuShowDetail
        '
        Me.mnuShowDetail.Name = "mnuShowDetail"
        Me.mnuShowDetail.Text = "&Chi tiết"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuAdd)
        Me.C1CommandHolder.Commands.Add(Me.mnuView)
        Me.C1CommandHolder.Commands.Add(Me.mnuEdit)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuCalculate)
        Me.C1CommandHolder.Commands.Add(Me.mnuCancelCalculate)
        Me.C1CommandHolder.Commands.Add(Me.mnuShowDetail)
        Me.C1CommandHolder.Commands.Add(Me.mnuTransfred)
        Me.C1CommandHolder.Commands.Add(Me.mnuDeleteTransfered)
        Me.C1CommandHolder.Owner = Me
        '
        'D13F2100
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAction)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2100"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Truy vÊn phiÕu tÛnh kÕt qu¶ chuyÓn bòt toÀn - D13F2100"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnAction As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    Private WithEvents mnuView As C1.Win.C1Command.C1Command
    Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuCalculate As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuCancelCalculate As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuShowDetail As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuTransfred As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink5 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuDeleteTransfered As C1.Win.C1Command.C1Command
End Class
