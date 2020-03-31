<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2040
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2040))
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnAction = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuAdd = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuView = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuEdit = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuDelete = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink10 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuLockVoucher = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink11 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuOpenVoucher = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink5 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuSalCalculate = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink9 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuCalSalAll = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink6 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuViewResultSalCalculation = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink7 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuDeleteResultSalCalculation = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink12 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink13 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink8 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuSysInfo = New C1.Win.C1Command.C1Command()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.tmr1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlPic = New System.Windows.Forms.Panel()
        Me.picRunning = New System.Windows.Forms.PictureBox()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlPic.SuspendLayout()
        CType(Me.picRunning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(6, 8)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1006, 607)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnAction
        '
        Me.btnAction.Location = New System.Drawing.Point(793, 624)
        Me.btnAction.Name = "btnAction"
        Me.btnAction.Size = New System.Drawing.Size(137, 22)
        Me.btnAction.TabIndex = 1
        Me.btnAction.Text = "&Thực hiện..."
        Me.btnAction.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(936, 624)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, Me.C1CommandLink2, Me.C1CommandLink3, Me.C1CommandLink4, Me.C1CommandLink10, Me.C1CommandLink11, Me.C1CommandLink5, Me.C1CommandLink9, Me.C1CommandLink6, Me.C1CommandLink7, Me.C1CommandLink12, Me.C1CommandLink13, Me.C1CommandLink8})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuAdd
        '
        'mnuAdd
        '
        Me.mnuAdd.Name = "mnuAdd"
        Me.mnuAdd.Text = "&Thêm"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuView
        Me.C1CommandLink2.SortOrder = 1
        '
        'mnuView
        '
        Me.mnuView.Name = "mnuView"
        Me.mnuView.Text = "Xe&m"
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuEdit
        Me.C1CommandLink3.SortOrder = 2
        Me.C1CommandLink3.Text = "&Sửa"
        '
        'mnuEdit
        '
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Text = "Sửa"
        '
        'C1CommandLink4
        '
        Me.C1CommandLink4.Command = Me.mnuDelete
        Me.C1CommandLink4.SortOrder = 3
        '
        'mnuDelete
        '
        Me.mnuDelete.Name = "mnuDelete"
        Me.mnuDelete.Text = "&Xóa"
        '
        'C1CommandLink10
        '
        Me.C1CommandLink10.Command = Me.mnuLockVoucher
        Me.C1CommandLink10.Delimiter = True
        Me.C1CommandLink10.SortOrder = 4
        '
        'mnuLockVoucher
        '
        Me.mnuLockVoucher.Name = "mnuLockVoucher"
        Me.mnuLockVoucher.Text = "Khóa &phiếu"
        '
        'C1CommandLink11
        '
        Me.C1CommandLink11.Command = Me.mnuOpenVoucher
        Me.C1CommandLink11.SortOrder = 5
        Me.C1CommandLink11.Text = "Mở phiế&u"
        '
        'mnuOpenVoucher
        '
        Me.mnuOpenVoucher.Name = "mnuOpenVoucher"
        Me.mnuOpenVoucher.Text = "&Mở phiếu"
        '
        'C1CommandLink5
        '
        Me.C1CommandLink5.Command = Me.mnuSalCalculate
        Me.C1CommandLink5.Delimiter = True
        Me.C1CommandLink5.SortOrder = 6
        Me.C1CommandLink5.Text = "Tính &lương"
        '
        'mnuSalCalculate
        '
        Me.mnuSalCalculate.Name = "mnuSalCalculate"
        Me.mnuSalCalculate.Text = "Tính lương"
        '
        'C1CommandLink9
        '
        Me.C1CommandLink9.Command = Me.mnuCalSalAll
        Me.C1CommandLink9.SortOrder = 7
        Me.C1CommandLink9.Text = "Tính lương hàng l&oạt"
        '
        'mnuCalSalAll
        '
        Me.mnuCalSalAll.Name = "mnuCalSalAll"
        Me.mnuCalSalAll.Text = "Tính lương hàng loạt"
        '
        'C1CommandLink6
        '
        Me.C1CommandLink6.Command = Me.mnuViewResultSalCalculation
        Me.C1CommandLink6.SortOrder = 8
        Me.C1CommandLink6.Text = "&Kết quả tính lương"
        '
        'mnuViewResultSalCalculation
        '
        Me.mnuViewResultSalCalculation.Name = "mnuViewResultSalCalculation"
        Me.mnuViewResultSalCalculation.Text = "Kết quả tính lương"
        '
        'C1CommandLink7
        '
        Me.C1CommandLink7.Command = Me.mnuDeleteResultSalCalculation
        Me.C1CommandLink7.SortOrder = 9
        Me.C1CommandLink7.Text = "Xóa kết &quả tính lương"
        '
        'mnuDeleteResultSalCalculation
        '
        Me.mnuDeleteResultSalCalculation.Name = "mnuDeleteResultSalCalculation"
        Me.mnuDeleteResultSalCalculation.Text = "Xóa kết quả tính lương"
        '
        'C1CommandLink12
        '
        Me.C1CommandLink12.Command = Me.mnuFind
        Me.C1CommandLink12.Delimiter = True
        Me.C1CommandLink12.SortOrder = 10
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'C1CommandLink13
        '
        Me.C1CommandLink13.Command = Me.mnuListAll
        Me.C1CommandLink13.SortOrder = 11
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'C1CommandLink8
        '
        Me.C1CommandLink8.Command = Me.mnuSysInfo
        Me.C1CommandLink8.Delimiter = True
        Me.C1CommandLink8.SortOrder = 12
        '
        'mnuSysInfo
        '
        Me.mnuSysInfo.Name = "mnuSysInfo"
        Me.mnuSysInfo.Text = "Thông tin &hệ thống"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuAdd)
        Me.C1CommandHolder.Commands.Add(Me.mnuView)
        Me.C1CommandHolder.Commands.Add(Me.mnuEdit)
        Me.C1CommandHolder.Commands.Add(Me.mnuDelete)
        Me.C1CommandHolder.Commands.Add(Me.mnuSalCalculate)
        Me.C1CommandHolder.Commands.Add(Me.mnuViewResultSalCalculation)
        Me.C1CommandHolder.Commands.Add(Me.mnuDeleteResultSalCalculation)
        Me.C1CommandHolder.Commands.Add(Me.mnuSysInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuCalSalAll)
        Me.C1CommandHolder.Commands.Add(Me.mnuLockVoucher)
        Me.C1CommandHolder.Commands.Add(Me.mnuOpenVoucher)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'tmr1
        '
        '
        'pnlPic
        '
        Me.pnlPic.Controls.Add(Me.picRunning)
        Me.pnlPic.Location = New System.Drawing.Point(480, 265)
        Me.pnlPic.Name = "pnlPic"
        Me.pnlPic.Size = New System.Drawing.Size(80, 69)
        Me.pnlPic.TabIndex = 26
        Me.pnlPic.Visible = False
        '
        'picRunning
        '
        Me.picRunning.Image = Global.D13D2240.My.Resources.Resources.Running_vi
        Me.picRunning.Location = New System.Drawing.Point(3, 5)
        Me.picRunning.Name = "picRunning"
        Me.picRunning.Size = New System.Drawing.Size(74, 61)
        Me.picRunning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRunning.TabIndex = 0
        Me.picRunning.TabStop = False
        '
        'D13F2040
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.pnlPic)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAction)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2040"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc phiÕu tÛnh l§¥ng -  D13F2040"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlPic.ResumeLayout(False)
        CType(Me.picRunning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnAction As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink5 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink6 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink7 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink8 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents tmr1 As System.Windows.Forms.Timer
    Friend WithEvents C1CommandLink9 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink10 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink11 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink12 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink13 As C1.Win.C1Command.C1CommandLink
    Private WithEvents mnuAdd As C1.Win.C1Command.C1Command
    Private WithEvents mnuView As C1.Win.C1Command.C1Command
    Private WithEvents mnuEdit As C1.Win.C1Command.C1Command
    Private WithEvents mnuDelete As C1.Win.C1Command.C1Command
    Private WithEvents mnuViewResultSalCalculation As C1.Win.C1Command.C1Command
    Private WithEvents mnuDeleteResultSalCalculation As C1.Win.C1Command.C1Command
    Private WithEvents mnuSysInfo As C1.Win.C1Command.C1Command
    Private WithEvents mnuCalSalAll As C1.Win.C1Command.C1Command
    Private WithEvents mnuLockVoucher As C1.Win.C1Command.C1Command
    Private WithEvents mnuOpenVoucher As C1.Win.C1Command.C1Command
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuSalCalculate As C1.Win.C1Command.C1Command
    Friend WithEvents pnlPic As System.Windows.Forms.Panel
    Private WithEvents picRunning As System.Windows.Forms.PictureBox
End Class
