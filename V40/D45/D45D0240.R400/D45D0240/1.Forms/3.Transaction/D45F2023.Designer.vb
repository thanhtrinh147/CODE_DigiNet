<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2023
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
        Dim mnuFindLink As C1.Win.C1Command.C1CommandLink
        Dim mnuListAllLink As C1.Win.C1Command.C1CommandLink
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2023))
        Me.mnuFind = New C1.Win.C1Command.C1Command()
        Me.mnuListAll = New C1.Win.C1Command.C1Command()
        Me.grpInfo = New System.Windows.Forms.GroupBox()
        Me.chkIsProStatistic = New System.Windows.Forms.CheckBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.chkIsTransfer = New System.Windows.Forms.CheckBox()
        Me.chkIsDelivery = New System.Windows.Forms.CheckBox()
        Me.chkIsReceipt = New System.Windows.Forms.CheckBox()
        Me.txtVoucherNo = New System.Windows.Forms.TextBox()
        Me.lblVoucherNo = New System.Windows.Forms.Label()
        Me.lblteDateTo = New System.Windows.Forms.Label()
        Me.c1dateDateTo = New C1.Win.C1Input.C1DateEdit()
        Me.lblteDateFrom = New System.Windows.Forms.Label()
        Me.c1dateDateFrom = New C1.Win.C1Input.C1DateEdit()
        Me.chkIsCreatePieceWork = New System.Windows.Forms.CheckBox()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnInherit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnF12 = New System.Windows.Forms.Button()
        Me.chkIsUsed = New System.Windows.Forms.CheckBox()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.chkIsInherit = New System.Windows.Forms.CheckBox()
        mnuFindLink = New C1.Win.C1Command.C1CommandLink()
        mnuListAllLink = New C1.Win.C1Command.C1CommandLink()
        Me.grpInfo.SuspendLayout()
        CType(Me.c1dateDateTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateDateFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuFindLink
        '
        mnuFindLink.Command = Me.mnuFind
        '
        'mnuFind
        '
        Me.mnuFind.Name = "mnuFind"
        Me.mnuFind.Text = "Tìm &kiếm"
        '
        'mnuListAllLink
        '
        mnuListAllLink.Command = Me.mnuListAll
        '
        'mnuListAll
        '
        Me.mnuListAll.Name = "mnuListAll"
        Me.mnuListAll.Text = "&Liệt kê tất cả"
        '
        'grpInfo
        '
        Me.grpInfo.Controls.Add(Me.chkIsProStatistic)
        Me.grpInfo.Controls.Add(Me.btnFilter)
        Me.grpInfo.Controls.Add(Me.chkIsTransfer)
        Me.grpInfo.Controls.Add(Me.chkIsDelivery)
        Me.grpInfo.Controls.Add(Me.chkIsReceipt)
        Me.grpInfo.Controls.Add(Me.txtVoucherNo)
        Me.grpInfo.Controls.Add(Me.lblVoucherNo)
        Me.grpInfo.Controls.Add(Me.lblteDateTo)
        Me.grpInfo.Controls.Add(Me.c1dateDateTo)
        Me.grpInfo.Controls.Add(Me.lblteDateFrom)
        Me.grpInfo.Controls.Add(Me.c1dateDateFrom)
        Me.grpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfo.Location = New System.Drawing.Point(8, 2)
        Me.grpInfo.Name = "grpInfo"
        Me.grpInfo.Size = New System.Drawing.Size(1002, 71)
        Me.grpInfo.TabIndex = 0
        Me.grpInfo.TabStop = False
        Me.grpInfo.Text = "Thông tin kế thừa"
        '
        'chkIsProStatistic
        '
        Me.chkIsProStatistic.AutoSize = True
        Me.chkIsProStatistic.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsProStatistic.Location = New System.Drawing.Point(242, 48)
        Me.chkIsProStatistic.Name = "chkIsProStatistic"
        Me.chkIsProStatistic.Size = New System.Drawing.Size(115, 17)
        Me.chkIsProStatistic.TabIndex = 3
        Me.chkIsProStatistic.Text = "Thống kê sản xuất"
        Me.chkIsProStatistic.UseVisualStyleBackColor = True
        '
        'btnFilter
        '
        Me.btnFilter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFilter.Location = New System.Drawing.Point(907, 45)
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.Size = New System.Drawing.Size(86, 22)
        Me.btnFilter.TabIndex = 7
        Me.btnFilter.Text = "Lọc"
        Me.btnFilter.UseVisualStyleBackColor = True
        '
        'chkIsTransfer
        '
        Me.chkIsTransfer.AutoSize = True
        Me.chkIsTransfer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsTransfer.Location = New System.Drawing.Point(242, 21)
        Me.chkIsTransfer.Name = "chkIsTransfer"
        Me.chkIsTransfer.Size = New System.Drawing.Size(115, 17)
        Me.chkIsTransfer.TabIndex = 2
        Me.chkIsTransfer.Text = "Vận chuyển nội bộ"
        Me.chkIsTransfer.UseVisualStyleBackColor = True
        '
        'chkIsDelivery
        '
        Me.chkIsDelivery.AutoSize = True
        Me.chkIsDelivery.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsDelivery.Location = New System.Drawing.Point(25, 48)
        Me.chkIsDelivery.Name = "chkIsDelivery"
        Me.chkIsDelivery.Size = New System.Drawing.Size(69, 17)
        Me.chkIsDelivery.TabIndex = 1
        Me.chkIsDelivery.Text = "Xuất kho"
        Me.chkIsDelivery.UseVisualStyleBackColor = True
        '
        'chkIsReceipt
        '
        Me.chkIsReceipt.AutoSize = True
        Me.chkIsReceipt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkIsReceipt.Location = New System.Drawing.Point(26, 21)
        Me.chkIsReceipt.Name = "chkIsReceipt"
        Me.chkIsReceipt.Size = New System.Drawing.Size(73, 17)
        Me.chkIsReceipt.TabIndex = 0
        Me.chkIsReceipt.Text = "Nhập kho"
        Me.chkIsReceipt.UseVisualStyleBackColor = True
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoucherNo.Location = New System.Drawing.Point(590, 46)
        Me.txtVoucherNo.MaxLength = 20
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(301, 20)
        Me.txtVoucherNo.TabIndex = 6
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoucherNo.Location = New System.Drawing.Point(504, 50)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVoucherNo.TabIndex = 11
        Me.lblVoucherNo.Text = "Số phiếu"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblteDateTo
        '
        Me.lblteDateTo.AutoSize = True
        Me.lblteDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblteDateTo.Location = New System.Drawing.Point(734, 23)
        Me.lblteDateTo.Name = "lblteDateTo"
        Me.lblteDateTo.Size = New System.Drawing.Size(13, 13)
        Me.lblteDateTo.TabIndex = 10
        Me.lblteDateTo.Text = "--"
        Me.lblteDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateDateTo
        '
        Me.c1dateDateTo.AutoSize = False
        Me.c1dateDateTo.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateTo.EmptyAsNull = True
        Me.c1dateDateTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1dateDateTo.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateTo.Location = New System.Drawing.Point(762, 18)
        Me.c1dateDateTo.Name = "c1dateDateTo"
        Me.c1dateDateTo.Size = New System.Drawing.Size(130, 22)
        Me.c1dateDateTo.TabIndex = 5
        Me.c1dateDateTo.Tag = Nothing
        Me.c1dateDateTo.TrimStart = True
        Me.c1dateDateTo.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteDateFrom
        '
        Me.lblteDateFrom.AutoSize = True
        Me.lblteDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblteDateFrom.Location = New System.Drawing.Point(504, 23)
        Me.lblteDateFrom.Name = "lblteDateFrom"
        Me.lblteDateFrom.Size = New System.Drawing.Size(32, 13)
        Me.lblteDateFrom.TabIndex = 8
        Me.lblteDateFrom.Text = "Ngày"
        Me.lblteDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateDateFrom
        '
        Me.c1dateDateFrom.AutoSize = False
        Me.c1dateDateFrom.CustomFormat = "dd/MM/yyyy"
        Me.c1dateDateFrom.EmptyAsNull = True
        Me.c1dateDateFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1dateDateFrom.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateDateFrom.Location = New System.Drawing.Point(591, 18)
        Me.c1dateDateFrom.Name = "c1dateDateFrom"
        Me.c1dateDateFrom.Size = New System.Drawing.Size(130, 22)
        Me.c1dateDateFrom.TabIndex = 4
        Me.c1dateDateFrom.Tag = Nothing
        Me.c1dateDateFrom.TrimStart = True
        Me.c1dateDateFrom.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'chkIsCreatePieceWork
        '
        Me.chkIsCreatePieceWork.AutoSize = True
        Me.chkIsCreatePieceWork.Checked = True
        Me.chkIsCreatePieceWork.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkIsCreatePieceWork.Location = New System.Drawing.Point(8, 80)
        Me.chkIsCreatePieceWork.Name = "chkIsCreatePieceWork"
        Me.chkIsCreatePieceWork.Size = New System.Drawing.Size(219, 17)
        Me.chkIsCreatePieceWork.TabIndex = 1
        Me.chkIsCreatePieceWork.Text = "Tạo phiếu thống kê sản phẩm tính lương"
        Me.chkIsCreatePieceWork.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AlternatingRows = True
        Me.C1CommandHolder.SetC1Command(Me.tdbg, Me.C1ContextMenu)
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbg, Me.C1ContextMenu)
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(8, 105)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1002, 518)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnInherit
        '
        Me.btnInherit.Location = New System.Drawing.Point(852, 629)
        Me.btnInherit.Name = "btnInherit"
        Me.btnInherit.Size = New System.Drawing.Size(76, 22)
        Me.btnInherit.TabIndex = 3
        Me.btnInherit.Text = "&Kế thừa"
        Me.btnInherit.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(934, 629)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(7, 629)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(95, 22)
        Me.btnF12.TabIndex = 5
        Me.btnF12.Text = "Hiển thị"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'chkIsUsed
        '
        Me.chkIsUsed.AutoSize = True
        Me.chkIsUsed.Location = New System.Drawing.Point(108, 632)
        Me.chkIsUsed.Name = "chkIsUsed"
        Me.chkIsUsed.Size = New System.Drawing.Size(181, 17)
        Me.chkIsUsed.TabIndex = 6
        Me.chkIsUsed.Text = "Chỉ hiển thị những dòng đã chọn"
        Me.chkIsUsed.UseVisualStyleBackColor = True
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {mnuFindLink, mnuListAllLink})
        Me.C1ContextMenu.Name = "C1ContextMenu"
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuFind)
        Me.C1CommandHolder.Commands.Add(Me.mnuListAll)
        Me.C1CommandHolder.Owner = Me
        '
        'chkIsInherit
        '
        Me.chkIsInherit.AutoSize = True
        Me.chkIsInherit.Location = New System.Drawing.Point(326, 632)
        Me.chkIsInherit.Name = "chkIsInherit"
        Me.chkIsInherit.Size = New System.Drawing.Size(151, 17)
        Me.chkIsInherit.TabIndex = 7
        Me.chkIsInherit.Text = "Hiển thị dữ liệu đã kế thừa"
        Me.chkIsInherit.UseVisualStyleBackColor = True
        '
        'D45F2023
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.chkIsInherit)
        Me.Controls.Add(Me.chkIsUsed)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnInherit)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.chkIsCreatePieceWork)
        Me.Controls.Add(Me.grpInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2023"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa dö liÖu - D45F2023"
        Me.grpInfo.ResumeLayout(False)
        Me.grpInfo.PerformLayout()
        CType(Me.c1dateDateTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateDateFrom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents grpInfo As System.Windows.Forms.GroupBox
    Private WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents lblteDateTo As System.Windows.Forms.Label
    Private WithEvents c1dateDateTo As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteDateFrom As System.Windows.Forms.Label
    Private WithEvents c1dateDateFrom As C1.Win.C1Input.C1DateEdit
    Private WithEvents chkIsTransfer As System.Windows.Forms.CheckBox
    Private WithEvents chkIsDelivery As System.Windows.Forms.CheckBox
    Private WithEvents chkIsReceipt As System.Windows.Forms.CheckBox
    Private WithEvents btnFilter As System.Windows.Forms.Button
    Private WithEvents chkIsCreatePieceWork As System.Windows.Forms.CheckBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnInherit As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents chkIsUsed As System.Windows.Forms.CheckBox
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Private WithEvents mnuFind As C1.Win.C1Command.C1Command
    Private WithEvents mnuListAll As C1.Win.C1Command.C1Command
    Friend WithEvents chkIsProStatistic As System.Windows.Forms.CheckBox
    Private WithEvents chkIsInherit As System.Windows.Forms.CheckBox
End Class
