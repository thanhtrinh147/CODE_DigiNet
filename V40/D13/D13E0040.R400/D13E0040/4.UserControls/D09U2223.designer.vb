<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D09U2223
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D09U2223))
        Me.mnuPrintLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuPrint = New C1.Win.C1Command.C1Command()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuLaborContract = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdateInfo = New C1.Win.C1Command.C1Command()
        Me.mnuUpdateLeaveDayLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdateLeaveDay = New C1.Win.C1Command.C1Command()
        Me.mnuTransactionLeaveAssignmentLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuTransactionLeaveAssignment = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuSetTransaction = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink6 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdate = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink10 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdatePayrollFile = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink11 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdateFamilyDeductionValidationDate = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuPITBalance = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink5 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuSalaryProposal = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink7 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuSalaryAdjust = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink8 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink9 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink12 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuExportToExcel = New C1.Win.C1Command.C1Command()
        Me.mnuRefeshLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuRefesh = New C1.Win.C1Command.C1Command()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.c1date1 = New C1.Win.C1Input.C1DateEdit()
        Me.c1date2 = New C1.Win.C1Input.C1DateEdit()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.C1CommandLink13 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuFilterEmployee = New C1.Win.C1Command.C1Command()
        Me.Panel1.SuspendLayout()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1date1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1date2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGrid.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuPrintLink
        '
        Me.mnuPrintLink.Command = Me.mnuPrint
        Me.mnuPrintLink.Delimiter = True
        Me.mnuPrintLink.SortOrder = 16
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Text = "&In"
        Me.mnuPrint.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(357, 20)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "AlertMessage"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.picClose)
        Me.Panel1.Controls.Add(Me.lblMessage)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(357, 20)
        Me.Panel1.TabIndex = 2
        '
        'picClose
        '
        Me.picClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picClose.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.picClose.Image = CType(resources.GetObject("picClose.Image"), System.Drawing.Image)
        Me.picClose.Location = New System.Drawing.Point(342, 0)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(14, 14)
        Me.picClose.TabIndex = 2
        Me.picClose.TabStop = False
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink2, Me.C1CommandLink1, Me.mnuUpdateLeaveDayLink, Me.mnuTransactionLeaveAssignmentLink, Me.C1CommandLink3, Me.C1CommandLink6, Me.C1CommandLink10, Me.C1CommandLink11, Me.C1CommandLink4, Me.C1CommandLink13, Me.C1CommandLink5, Me.C1CommandLink7, Me.C1CommandLink8, Me.C1CommandLink9, Me.C1CommandLink12, Me.mnuRefeshLink, Me.mnuPrintLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuLaborContract
        '
        'mnuLaborContract
        '
        Me.mnuLaborContract.Name = "mnuLaborContract"
        Me.mnuLaborContract.Text = "Lập hợp đồng lao động"
        Me.mnuLaborContract.Visible = False
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuUpdateInfo
        Me.C1CommandLink1.SortOrder = 1
        '
        'mnuUpdateInfo
        '
        Me.mnuUpdateInfo.Name = "mnuUpdateInfo"
        Me.mnuUpdateInfo.Text = "Cập nhật thông tin"
        Me.mnuUpdateInfo.Visible = False
        '
        'mnuUpdateLeaveDayLink
        '
        Me.mnuUpdateLeaveDayLink.Command = Me.mnuUpdateLeaveDay
        Me.mnuUpdateLeaveDayLink.Delimiter = True
        Me.mnuUpdateLeaveDayLink.SortOrder = 2
        '
        'mnuUpdateLeaveDay
        '
        Me.mnuUpdateLeaveDay.Name = "mnuUpdateLeaveDay"
        Me.mnuUpdateLeaveDay.Text = "Cập nhật ngày tính phép"
        Me.mnuUpdateLeaveDay.Visible = False
        '
        'mnuTransactionLeaveAssignmentLink
        '
        Me.mnuTransactionLeaveAssignmentLink.Command = Me.mnuTransactionLeaveAssignment
        Me.mnuTransactionLeaveAssignmentLink.Delimiter = True
        Me.mnuTransactionLeaveAssignmentLink.SortOrder = 3
        '
        'mnuTransactionLeaveAssignment
        '
        Me.mnuTransactionLeaveAssignment.Name = "mnuTransactionLeaveAssignment"
        Me.mnuTransactionLeaveAssignment.Text = "Cấp phép năm"
        Me.mnuTransactionLeaveAssignment.Visible = False
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuSetTransaction
        Me.C1CommandLink3.Delimiter = True
        Me.C1CommandLink3.SortOrder = 4
        '
        'mnuSetTransaction
        '
        Me.mnuSetTransaction.Name = "mnuSetTransaction"
        Me.mnuSetTransaction.Text = "&Cập nhật HSL gốc"
        '
        'C1CommandLink6
        '
        Me.C1CommandLink6.Command = Me.mnuUpdate
        Me.C1CommandLink6.SortOrder = 5
        '
        'mnuUpdate
        '
        Me.mnuUpdate.Name = "mnuUpdate"
        Me.mnuUpdate.Text = "Cập nhật hồ sơ lương tháng"
        '
        'C1CommandLink10
        '
        Me.C1CommandLink10.Command = Me.mnuUpdatePayrollFile
        Me.C1CommandLink10.SortOrder = 6
        '
        'mnuUpdatePayrollFile
        '
        Me.mnuUpdatePayrollFile.Name = "mnuUpdatePayrollFile"
        Me.mnuUpdatePayrollFile.Text = "&Cập nhật HSL"
        '
        'C1CommandLink11
        '
        Me.C1CommandLink11.Command = Me.mnuUpdateFamilyDeductionValidationDate
        Me.C1CommandLink11.SortOrder = 7
        '
        'mnuUpdateFamilyDeductionValidationDate
        '
        Me.mnuUpdateFamilyDeductionValidationDate.Name = "mnuUpdateFamilyDeductionValidationDate"
        Me.mnuUpdateFamilyDeductionValidationDate.Text = "Cập nhật &hiệu lực giảm trừ gia cảnh"
        '
        'C1CommandLink4
        '
        Me.C1CommandLink4.Command = Me.mnuPITBalance
        Me.C1CommandLink4.Delimiter = True
        Me.C1CommandLink4.SortOrder = 8
        Me.C1CommandLink4.Text = "&Quyết toán thuế TNCN"
        '
        'mnuPITBalance
        '
        Me.mnuPITBalance.Name = "mnuPITBalance"
        Me.mnuPITBalance.Text = "Quyết toán thuế TNCN"
        '
        'C1CommandLink5
        '
        Me.C1CommandLink5.Command = Me.mnuSalaryProposal
        Me.C1CommandLink5.SortOrder = 10
        '
        'mnuSalaryProposal
        '
        Me.mnuSalaryProposal.Name = "mnuSalaryProposal"
        Me.mnuSalaryProposal.Text = "Đề xuất điều chỉnh lương"
        '
        'C1CommandLink7
        '
        Me.C1CommandLink7.Command = Me.mnuSalaryAdjust
        Me.C1CommandLink7.SortOrder = 11
        '
        'mnuSalaryAdjust
        '
        Me.mnuSalaryAdjust.Name = "mnuSalaryAdjust"
        Me.mnuSalaryAdjust.Text = "Điều chỉnh lương"
        '
        'C1CommandLink8
        '
        Me.C1CommandLink8.Command = Me.mnuFind
        Me.C1CommandLink8.Delimiter = True
        Me.C1CommandLink8.SortOrder = 12
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm kiếm"
        '
        'C1CommandLink9
        '
        Me.C1CommandLink9.Command = Me.mnuListAll
        Me.C1CommandLink9.SortOrder = 13
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "Liệt kê tất cả"
        '
        'C1CommandLink12
        '
        Me.C1CommandLink12.Command = Me.mnuExportToExcel
        Me.C1CommandLink12.Delimiter = True
        Me.C1CommandLink12.SortOrder = 14
        '
        'mnuExportToExcel
        '
        Me.mnuExportToExcel.Name = "mnuExportToExcel"
        Me.mnuExportToExcel.Text = "Xuất Excel"
        '
        'mnuRefeshLink
        '
        Me.mnuRefeshLink.Command = Me.mnuRefesh
        Me.mnuRefeshLink.Delimiter = True
        Me.mnuRefeshLink.SortOrder = 15
        '
        'mnuRefesh
        '
        Me.mnuRefesh.Name = "mnuRefesh"
        Me.mnuRefesh.Text = "Refesh"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuPrint)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdateInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuLaborContract)
        Me.C1CommandHolder.Commands.Add(Me.mnuTransactionLeaveAssignment)
        Me.C1CommandHolder.Commands.Add(Me.mnuRefesh)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdateLeaveDay)
        Me.C1CommandHolder.Commands.Add(Me.mnuSetTransaction)
        Me.C1CommandHolder.Commands.Add(Me.mnuPITBalance)
        Me.C1CommandHolder.Commands.Add(Me.mnuSalaryProposal)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdate)
        Me.C1CommandHolder.Commands.Add(Me.mnuSalaryAdjust)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdatePayrollFile)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdateFamilyDeductionValidationDate)
        Me.C1CommandHolder.Commands.Add(Me.mnuExportToExcel)
        Me.C1CommandHolder.Commands.Add(Me.mnuFilterEmployee)
        Me.C1CommandHolder.Owner = Me
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(357, 253)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'c1date1
        '
        Me.c1date1.AutoSize = False
        Me.c1date1.CustomFormat = "dd/MM/yyyy"
        Me.c1date1.EmptyAsNull = True
        Me.c1date1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1date1.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1date1.Location = New System.Drawing.Point(3, 251)
        Me.c1date1.Name = "c1date1"
        Me.c1date1.Size = New System.Drawing.Size(100, 22)
        Me.c1date1.TabIndex = 4
        Me.c1date1.Tag = Nothing
        Me.c1date1.TrimStart = True
        Me.c1date1.Visible = False
        Me.c1date1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'c1date2
        '
        Me.c1date2.AutoSize = False
        Me.c1date2.CustomFormat = "dd/MM/yyyy"
        Me.c1date2.EmptyAsNull = True
        Me.c1date2.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1date2.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1date2.Location = New System.Drawing.Point(136, 251)
        Me.c1date2.Name = "c1date2"
        Me.c1date2.Size = New System.Drawing.Size(100, 22)
        Me.c1date2.TabIndex = 5
        Me.c1date2.Tag = Nothing
        Me.c1date2.TrimStart = True
        Me.c1date2.Visible = False
        Me.c1date2.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'pnlGrid
        '
        Me.pnlGrid.Controls.Add(Me.tdbg)
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 20)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(357, 253)
        Me.pnlGrid.TabIndex = 8
        '
        'C1CommandLink13
        '
        Me.C1CommandLink13.Command = Me.mnuFilterEmployee
        Me.C1CommandLink13.SortOrder = 9
        '
        'mnuFilterEmployee
        '
        Me.mnuFilterEmployee.Name = "mnuFilterEmployee"
        Me.mnuFilterEmployee.Text = "Sàng lọc nhân viên"
        '
        'D09U2223
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.c1date2)
        Me.Controls.Add(Me.c1date1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "D09U2223"
        Me.Size = New System.Drawing.Size(357, 273)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1date1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1date2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGrid.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuPrint As C1.Win.C1Command.C1Command
    Private WithEvents c1date2 As C1.Win.C1Input.C1DateEdit
    Private WithEvents c1date1 As C1.Win.C1Input.C1DateEdit
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents pnlGrid As System.Windows.Forms.Panel
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuPrintLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuTransactionLeaveAssignmentLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuRefeshLink As C1.Win.C1Command.C1CommandLink
    Private WithEvents picClose As System.Windows.Forms.PictureBox
    Friend WithEvents mnuUpdateLeaveDayLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink5 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink6 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuUpdateSalaryMonth As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink7 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink8 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink9 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink10 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink11 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink12 As C1.Win.C1Command.C1CommandLink
    Private WithEvents mnuUpdateInfo As C1.Win.C1Command.C1Command
    Private WithEvents mnuLaborContract As C1.Win.C1Command.C1Command
    Private WithEvents mnuTransactionLeaveAssignment As C1.Win.C1Command.C1Command
    Private WithEvents mnuRefesh As C1.Win.C1Command.C1Command
    Private WithEvents mnuUpdateLeaveDay As C1.Win.C1Command.C1Command
    Private WithEvents mnuSetTransaction As C1.Win.C1Command.C1Command
    Private WithEvents mnuPITBalance As C1.Win.C1Command.C1Command
    Private WithEvents mnuSalaryProposal As C1.Win.C1Command.C1Command
    Private WithEvents mnuUpdate As C1.Win.C1Command.C1Command
    Private WithEvents mnuSalaryAdjust As C1.Win.C1Command.C1Command
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Private WithEvents mnuUpdatePayrollFile As C1.Win.C1Command.C1Command
    Private WithEvents mnuUpdateFamilyDeductionValidationDate As C1.Win.C1Command.C1Command
    Private WithEvents mnuExportToExcel As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink13 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuFilterEmployee As C1.Win.C1Command.C1Command

End Class
