<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25U2224
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25U2224))
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.picClose = New System.Windows.Forms.PictureBox()
        Me.pnlGrid = New System.Windows.Forms.Panel()
        Me.tdbgM = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.tdbgD = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.pnlDetail = New System.Windows.Forms.Panel()
        Me.btnCollapse = New System.Windows.Forms.Button()
        Me.imgDownUp = New System.Windows.Forms.ImageList(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.C1CommandHolder = New C1.Win.C1Command.C1CommandHolder()
        Me.C1ContextMenu = New C1.Win.C1Command.C1ContextMenu()
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuLaborContract = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuUpdateInfo = New C1.Win.C1Command.C1Command()
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink()
        Me.mnuApprove = New C1.Win.C1Command.C1Command()
        Me.mnuTransactionLeaveAssignmentLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuTransactionLeaveAssignment = New C1.Win.C1Command.C1Command()
        Me.mnuRefeshLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuRefesh = New C1.Win.C1Command.C1Command()
        Me.mnuPrintLink = New C1.Win.C1Command.C1CommandLink()
        Me.mnuPrint = New C1.Win.C1Command.C1Command()
        Me.Panel1.SuspendLayout()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDetail.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblMessage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblMessage.Location = New System.Drawing.Point(0, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(842, 20)
        Me.lblMessage.TabIndex = 0
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
        Me.Panel1.Size = New System.Drawing.Size(842, 20)
        Me.Panel1.TabIndex = 0
        '
        'picClose
        '
        Me.picClose.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.picClose.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.picClose.Image = CType(resources.GetObject("picClose.Image"), System.Drawing.Image)
        Me.picClose.Location = New System.Drawing.Point(826, 3)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(14, 14)
        Me.picClose.TabIndex = 2
        Me.picClose.TabStop = False
        '
        'pnlGrid
        '
        Me.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGrid.Location = New System.Drawing.Point(0, 20)
        Me.pnlGrid.Name = "pnlGrid"
        Me.pnlGrid.Size = New System.Drawing.Size(842, 602)
        Me.pnlGrid.TabIndex = 2
        '
        'tdbgM
        '
        Me.tdbgM.AllowColMove = False
        Me.tdbgM.AllowColSelect = False
        Me.tdbgM.AllowFilter = False
        Me.tdbgM.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgM.AllowUpdate = False
        Me.tdbgM.AlternatingRows = True
        Me.tdbgM.CaptionHeight = 17
        Me.tdbgM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tdbgM.EmptyRows = True
        Me.tdbgM.ExtendRightColumn = True
        Me.tdbgM.FilterBar = True
        Me.tdbgM.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgM.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgM.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgM.Images.Add(CType(resources.GetObject("tdbgM.Images"), System.Drawing.Image))
        Me.tdbgM.Location = New System.Drawing.Point(3, 3)
        Me.tdbgM.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRowRaiseCell
        Me.tdbgM.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgM.Name = "tdbgM"
        Me.tdbgM.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgM.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgM.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgM.PrintInfo.PageSettings = CType(resources.GetObject("tdbgM.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgM.RowHeight = 15
        Me.tdbgM.Size = New System.Drawing.Size(836, 180)
        Me.tdbgM.TabAcrossSplits = True
        Me.tdbgM.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgM.TabIndex = 0
        Me.tdbgM.Tag = "COL"
        Me.tdbgM.WrapCellPointer = True
        Me.tdbgM.PropBag = resources.GetString("tdbgM.PropBag")
        '
        'tdbgD
        '
        Me.tdbgD.AllowColMove = False
        Me.tdbgD.AllowColSelect = False
        Me.tdbgD.AllowFilter = False
        Me.tdbgD.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgD.AlternatingRows = True
        Me.C1CommandHolder.SetC1ContextMenu(Me.tdbgD, Me.C1ContextMenu)
        Me.tdbgD.CaptionHeight = 17
        Me.tdbgD.ColumnFooters = True
        Me.tdbgD.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tdbgD.EmptyRows = True
        Me.tdbgD.ExtendRightColumn = True
        Me.tdbgD.FilterBar = True
        Me.tdbgD.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgD.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgD.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgD.Images.Add(CType(resources.GetObject("tdbgD.Images"), System.Drawing.Image))
        Me.tdbgD.Location = New System.Drawing.Point(3, 219)
        Me.tdbgD.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgD.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgD.Name = "tdbgD"
        Me.tdbgD.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgD.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgD.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbgD.PrintInfo.PageSettings = CType(resources.GetObject("tdbgD.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgD.RowHeight = 15
        Me.tdbgD.Size = New System.Drawing.Size(836, 380)
        Me.tdbgD.TabAcrossSplits = True
        Me.tdbgD.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgD.TabIndex = 2
        Me.tdbgD.PropBag = resources.GetString("tdbgD.PropBag")
        '
        'pnlDetail
        '
        Me.pnlDetail.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.pnlDetail.Controls.Add(Me.btnCollapse)
        Me.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDetail.Location = New System.Drawing.Point(3, 189)
        Me.pnlDetail.Name = "pnlDetail"
        Me.pnlDetail.Size = New System.Drawing.Size(836, 24)
        Me.pnlDetail.TabIndex = 1
        '
        'btnCollapse
        '
        Me.btnCollapse.FlatAppearance.BorderSize = 0
        Me.btnCollapse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCollapse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollapse.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnCollapse.Location = New System.Drawing.Point(6, 1)
        Me.btnCollapse.Name = "btnCollapse"
        Me.btnCollapse.Size = New System.Drawing.Size(94, 24)
        Me.btnCollapse.TabIndex = 0
        Me.btnCollapse.Text = "Chi tiết"
        Me.btnCollapse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCollapse.UseVisualStyleBackColor = True
        '
        'imgDownUp
        '
        Me.imgDownUp.ImageStream = CType(resources.GetObject("imgDownUp.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDownUp.TransparentColor = System.Drawing.Color.Transparent
        Me.imgDownUp.Images.SetKeyName(0, "down.png")
        Me.imgDownUp.Images.SetKeyName(1, "up.png")
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tdbgM, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tdbgD, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.pnlDetail, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.68826!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.31174!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(842, 602)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'C1CommandHolder
        '
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuLaborContract)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdateInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuApprove)
        Me.C1CommandHolder.Commands.Add(Me.mnuTransactionLeaveAssignment)
        Me.C1CommandHolder.Commands.Add(Me.mnuRefesh)
        Me.C1CommandHolder.Commands.Add(Me.mnuPrint)
        Me.C1CommandHolder.Commands.Add(Me.C1ContextMenu)
        Me.C1CommandHolder.Commands.Add(Me.mnuLaborContract)
        Me.C1CommandHolder.Commands.Add(Me.mnuUpdateInfo)
        Me.C1CommandHolder.Commands.Add(Me.mnuApprove)
        Me.C1CommandHolder.Commands.Add(Me.mnuTransactionLeaveAssignment)
        Me.C1CommandHolder.Commands.Add(Me.mnuRefesh)
        Me.C1CommandHolder.Commands.Add(Me.mnuPrint)
        Me.C1CommandHolder.Owner = Me
        '
        'C1ContextMenu
        '
        Me.C1ContextMenu.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink2, Me.C1CommandLink1, Me.C1CommandLink3, Me.mnuTransactionLeaveAssignmentLink, Me.mnuRefeshLink, Me.mnuPrintLink})
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
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuApprove
        Me.C1CommandLink3.SortOrder = 2
        '
        'mnuApprove
        '
        Me.mnuApprove.Name = "mnuApprove"
        Me.mnuApprove.Text = "Duyệt"
        Me.mnuApprove.Visible = False
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
        '
        'mnuRefeshLink
        '
        Me.mnuRefeshLink.Command = Me.mnuRefesh
        Me.mnuRefeshLink.Delimiter = True
        Me.mnuRefeshLink.SortOrder = 4
        '
        'mnuRefesh
        '
        Me.mnuRefesh.Name = "mnuRefesh"
        Me.mnuRefesh.Text = "Refesh"
        '
        'mnuPrintLink
        '
        Me.mnuPrintLink.Command = Me.mnuPrint
        Me.mnuPrintLink.Delimiter = True
        Me.mnuPrintLink.SortOrder = 5
        '
        'mnuPrint
        '
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.Text = "&In"
        '
        'D25U2224
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlGrid)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "D25U2224"
        Me.Size = New System.Drawing.Size(842, 622)
        Me.Panel1.ResumeLayout(False)
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbgD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDetail.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.C1CommandHolder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents pnlGrid As System.Windows.Forms.Panel
    Private WithEvents picClose As System.Windows.Forms.PictureBox
    Private WithEvents pnlDetail As System.Windows.Forms.Panel
    Private WithEvents btnCollapse As System.Windows.Forms.Button
    Private WithEvents tdbgD As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbgM As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel

    Private WithEvents imgDownUp As System.Windows.Forms.ImageList
    Private WithEvents C1CommandHolder As C1.Win.C1Command.C1CommandHolder
    Private WithEvents C1ContextMenu As C1.Win.C1Command.C1ContextMenu
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuLaborContract As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuUpdateInfo As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuApprove As C1.Win.C1Command.C1Command
    Friend WithEvents mnuTransactionLeaveAssignmentLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuTransactionLeaveAssignment As C1.Win.C1Command.C1Command
    Friend WithEvents mnuRefeshLink As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuRefesh As C1.Win.C1Command.C1Command
    Friend WithEvents mnuPrintLink As C1.Win.C1Command.C1CommandLink
    Private WithEvents mnuPrint As C1.Win.C1Command.C1Command

End Class
