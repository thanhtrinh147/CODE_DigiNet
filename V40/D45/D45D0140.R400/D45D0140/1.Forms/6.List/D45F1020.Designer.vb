﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1020
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1020))
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsInherit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsView = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator_Find = New System.Windows.Forms.ToolStripSeparator
        Me.mnsUpdateNewPrice = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator12 = New System.Windows.Forms.ToolStripSeparator
        Me.mnsFind = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator_Export = New System.Windows.Forms.ToolStripSeparator
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.mnsImportData = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator_SysInfo = New System.Windows.Forms.ToolStripSeparator
        Me.mnsSysInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator13 = New System.Windows.Forms.ToolStripSeparator
        Me.mnsPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.TableToolStrip = New System.Windows.Forms.ToolStrip
        Me.tsbAdd = New System.Windows.Forms.ToolStripButton
        Me.tsbInherit = New System.Windows.Forms.ToolStripButton
        Me.tsbView = New System.Windows.Forms.ToolStripButton
        Me.tsbEdit = New System.Windows.Forms.ToolStripButton
        Me.tsbDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbFind = New System.Windows.Forms.ToolStripButton
        Me.tsbListAll = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbExportToExcel = New System.Windows.Forms.ToolStripButton
        Me.tsbImportData = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator11 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbSysInfo = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClose = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.tsdActive = New System.Windows.Forms.ToolStripDropDownButton
        Me.tsmAdd = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmInherit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmView = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmDelete = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmUpdateNewPrice = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator10 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmFind = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmListAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmExportToExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.tsmImportData = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmSysInfo = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator
        Me.tsmPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.chkShowDisabled = New System.Windows.Forms.CheckBox
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableToolStrip.SuspendLayout()
        Me.SuspendLayout()
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
        Me.tdbg.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
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
        Me.tdbg.Size = New System.Drawing.Size(1012, 600)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsAdd, Me.mnsInherit, Me.mnsView, Me.mnsEdit, Me.mnsDelete, Me.ToolStripSeparator_Find, Me.mnsUpdateNewPrice, Me.ToolStripSeparator12, Me.mnsFind, Me.mnsListAll, Me.ToolStripSeparator_Export, Me.mnsExportToExcel, Me.mnsImportData, Me.ToolStripSeparator_SysInfo, Me.mnsSysInfo, Me.ToolStripSeparator13, Me.mnsPrint})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(168, 298)
        '
        'mnsAdd
        '
        Me.mnsAdd.Name = "mnsAdd"
        Me.mnsAdd.Size = New System.Drawing.Size(167, 22)
        Me.mnsAdd.Text = "&Thêm"
        '
        'mnsInherit
        '
        Me.mnsInherit.Name = "mnsInherit"
        Me.mnsInherit.Size = New System.Drawing.Size(167, 22)
        Me.mnsInherit.Text = "Kế thừa"
        '
        'mnsView
        '
        Me.mnsView.Name = "mnsView"
        Me.mnsView.Size = New System.Drawing.Size(167, 22)
        Me.mnsView.Text = "Xe&m"
        '
        'mnsEdit
        '
        Me.mnsEdit.Name = "mnsEdit"
        Me.mnsEdit.Size = New System.Drawing.Size(167, 22)
        Me.mnsEdit.Text = "&Sửa"
        '
        'mnsDelete
        '
        Me.mnsDelete.Name = "mnsDelete"
        Me.mnsDelete.Size = New System.Drawing.Size(167, 22)
        Me.mnsDelete.Text = "&Xóa"
        '
        'ToolStripSeparator_Find
        '
        Me.ToolStripSeparator_Find.Name = "ToolStripSeparator_Find"
        Me.ToolStripSeparator_Find.Size = New System.Drawing.Size(164, 6)
        '
        'mnsUpdateNewPrice
        '
        Me.mnsUpdateNewPrice.Name = "mnsUpdateNewPrice"
        Me.mnsUpdateNewPrice.Size = New System.Drawing.Size(167, 22)
        Me.mnsUpdateNewPrice.Text = "Cập nhật giá mới"
        '
        'ToolStripSeparator12
        '
        Me.ToolStripSeparator12.Name = "ToolStripSeparator12"
        Me.ToolStripSeparator12.Size = New System.Drawing.Size(164, 6)
        '
        'mnsFind
        '
        Me.mnsFind.Name = "mnsFind"
        Me.mnsFind.Size = New System.Drawing.Size(167, 22)
        Me.mnsFind.Text = "Tìm &kiếm"
        '
        'mnsListAll
        '
        Me.mnsListAll.Name = "mnsListAll"
        Me.mnsListAll.Size = New System.Drawing.Size(167, 22)
        Me.mnsListAll.Text = "&Liệt kê tất cả"
        '
        'ToolStripSeparator_Export
        '
        Me.ToolStripSeparator_Export.Name = "ToolStripSeparator_Export"
        Me.ToolStripSeparator_Export.Size = New System.Drawing.Size(164, 6)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(167, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'mnsImportData
        '
        Me.mnsImportData.Name = "mnsImportData"
        Me.mnsImportData.Size = New System.Drawing.Size(167, 22)
        Me.mnsImportData.Text = "Import &dữ liệu"
        '
        'ToolStripSeparator_SysInfo
        '
        Me.ToolStripSeparator_SysInfo.Name = "ToolStripSeparator_SysInfo"
        Me.ToolStripSeparator_SysInfo.Size = New System.Drawing.Size(164, 6)
        '
        'mnsSysInfo
        '
        Me.mnsSysInfo.Name = "mnsSysInfo"
        Me.mnsSysInfo.Size = New System.Drawing.Size(167, 22)
        Me.mnsSysInfo.Text = "Thông tin &hệ thống"
        '
        'ToolStripSeparator13
        '
        Me.ToolStripSeparator13.Name = "ToolStripSeparator13"
        Me.ToolStripSeparator13.Size = New System.Drawing.Size(164, 6)
        '
        'mnsPrint
        '
        Me.mnsPrint.Name = "mnsPrint"
        Me.mnsPrint.Size = New System.Drawing.Size(167, 22)
        Me.mnsPrint.Text = "In"
        '
        'TableToolStrip
        '
        Me.TableToolStrip.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.TableToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbAdd, Me.tsbInherit, Me.tsbView, Me.tsbEdit, Me.tsbDelete, Me.ToolStripSeparator1, Me.tsbFind, Me.tsbListAll, Me.ToolStripSeparator2, Me.tsbExportToExcel, Me.tsbImportData, Me.ToolStripSeparator11, Me.tsbSysInfo, Me.ToolStripSeparator3, Me.tsbPrint, Me.ToolStripSeparator4, Me.tsbClose, Me.ToolStripSeparator6, Me.tsdActive})
        Me.TableToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.TableToolStrip.Name = "TableToolStrip"
        Me.TableToolStrip.Size = New System.Drawing.Size(1018, 25)
        Me.TableToolStrip.TabIndex = 8
        Me.TableToolStrip.Text = "tbrTest"
        '
        'tsbAdd
        '
        Me.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbAdd.Image = CType(resources.GetObject("tsbAdd.Image"), System.Drawing.Image)
        Me.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAdd.Name = "tsbAdd"
        Me.tsbAdd.Size = New System.Drawing.Size(38, 22)
        Me.tsbAdd.Text = "Thêm"
        '
        'tsbInherit
        '
        Me.tsbInherit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbInherit.Name = "tsbInherit"
        Me.tsbInherit.Size = New System.Drawing.Size(48, 22)
        Me.tsbInherit.Text = "Kế thừ&a"
        '
        'tsbView
        '
        Me.tsbView.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbView.Name = "tsbView"
        Me.tsbView.Size = New System.Drawing.Size(32, 22)
        Me.tsbView.Text = "Xem"
        '
        'tsbEdit
        '
        Me.tsbEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbEdit.Name = "tsbEdit"
        Me.tsbEdit.Size = New System.Drawing.Size(30, 22)
        Me.tsbEdit.Text = "Sửa"
        '
        'tsbDelete
        '
        Me.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDelete.Name = "tsbDelete"
        Me.tsbDelete.Size = New System.Drawing.Size(30, 22)
        Me.tsbDelete.Text = "Xóa"
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
        'tsbExportToExcel
        '
        Me.tsbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExportToExcel.Name = "tsbExportToExcel"
        Me.tsbExportToExcel.Size = New System.Drawing.Size(56, 22)
        Me.tsbExportToExcel.Text = "Xuất Exel"
        '
        'tsbImportData
        '
        Me.tsbImportData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbImportData.Name = "tsbImportData"
        Me.tsbImportData.Size = New System.Drawing.Size(66, 22)
        Me.tsbImportData.Text = "Import Data"
        '
        'ToolStripSeparator11
        '
        Me.ToolStripSeparator11.Name = "ToolStripSeparator11"
        Me.ToolStripSeparator11.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSysInfo
        '
        Me.tsbSysInfo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSysInfo.Name = "tsbSysInfo"
        Me.tsbSysInfo.Size = New System.Drawing.Size(56, 22)
        Me.tsbSysInfo.Text = "Thông tin"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrint
        '
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrint.Text = "In"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
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
        Me.tsdActive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmAdd, Me.tsmInherit, Me.tsmView, Me.tsmEdit, Me.tsmDelete, Me.ToolStripSeparator5, Me.tsmUpdateNewPrice, Me.ToolStripSeparator10, Me.tsmFind, Me.tsmListAll, Me.ToolStripSeparator7, Me.tsmExportToExcel, Me.tsmImportData, Me.ToolStripSeparator9, Me.tsmSysInfo, Me.ToolStripSeparator8, Me.tsmPrint})
        Me.tsdActive.Image = CType(resources.GetObject("tsdActive.Image"), System.Drawing.Image)
        Me.tsdActive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsdActive.Name = "tsdActive"
        Me.tsdActive.Size = New System.Drawing.Size(68, 22)
        Me.tsdActive.Text = "Thực hiện"
        '
        'tsmAdd
        '
        Me.tsmAdd.Name = "tsmAdd"
        Me.tsmAdd.Size = New System.Drawing.Size(167, 22)
        Me.tsmAdd.Text = "Thêm"
        '
        'tsmInherit
        '
        Me.tsmInherit.Name = "tsmInherit"
        Me.tsmInherit.Size = New System.Drawing.Size(167, 22)
        Me.tsmInherit.Text = "Kế thừa"
        '
        'tsmView
        '
        Me.tsmView.Name = "tsmView"
        Me.tsmView.Size = New System.Drawing.Size(167, 22)
        Me.tsmView.Text = "Xem"
        '
        'tsmEdit
        '
        Me.tsmEdit.Name = "tsmEdit"
        Me.tsmEdit.Size = New System.Drawing.Size(167, 22)
        Me.tsmEdit.Text = "Sửa"
        '
        'tsmDelete
        '
        Me.tsmDelete.Name = "tsmDelete"
        Me.tsmDelete.Size = New System.Drawing.Size(167, 22)
        Me.tsmDelete.Text = "Xóa"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(164, 6)
        '
        'tsmUpdateNewPrice
        '
        Me.tsmUpdateNewPrice.Name = "tsmUpdateNewPrice"
        Me.tsmUpdateNewPrice.Size = New System.Drawing.Size(167, 22)
        Me.tsmUpdateNewPrice.Text = "Cập nhật giá mới"
        '
        'ToolStripSeparator10
        '
        Me.ToolStripSeparator10.Name = "ToolStripSeparator10"
        Me.ToolStripSeparator10.Size = New System.Drawing.Size(164, 6)
        '
        'tsmFind
        '
        Me.tsmFind.Name = "tsmFind"
        Me.tsmFind.Size = New System.Drawing.Size(167, 22)
        Me.tsmFind.Text = "Tìm kiếm"
        '
        'tsmListAll
        '
        Me.tsmListAll.Name = "tsmListAll"
        Me.tsmListAll.Size = New System.Drawing.Size(167, 22)
        Me.tsmListAll.Text = "Liệt kê tất cả"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(164, 6)
        '
        'tsmExportToExcel
        '
        Me.tsmExportToExcel.Name = "tsmExportToExcel"
        Me.tsmExportToExcel.Size = New System.Drawing.Size(167, 22)
        Me.tsmExportToExcel.Text = "Xuất Excel"
        '
        'tsmImportData
        '
        Me.tsmImportData.Name = "tsmImportData"
        Me.tsmImportData.Size = New System.Drawing.Size(167, 22)
        Me.tsmImportData.Text = "Import dữ liệu"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(164, 6)
        '
        'tsmSysInfo
        '
        Me.tsmSysInfo.Name = "tsmSysInfo"
        Me.tsmSysInfo.Size = New System.Drawing.Size(167, 22)
        Me.tsmSysInfo.Text = "Thông tin hệ thống"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(164, 6)
        '
        'tsmPrint
        '
        Me.tsmPrint.Name = "tsmPrint"
        Me.tsmPrint.Size = New System.Drawing.Size(167, 22)
        Me.tsmPrint.Text = "In"
        '
        'chkShowDisabled
        '
        Me.chkShowDisabled.AutoSize = True
        Me.chkShowDisabled.Location = New System.Drawing.Point(3, 634)
        Me.chkShowDisabled.Name = "chkShowDisabled"
        Me.chkShowDisabled.Size = New System.Drawing.Size(186, 17)
        Me.chkShowDisabled.TabIndex = 9
        Me.chkShowDisabled.Text = "Hiển thị danh mục không sử dụng"
        Me.chkShowDisabled.UseVisualStyleBackColor = True
        '
        'D45F1020
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.TableToolStrip)
        Me.Controls.Add(Me.chkShowDisabled)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1020"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc b¶ng giÀ - D45F1020"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableToolStrip.ResumeLayout(False)
        Me.TableToolStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents TableToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbInherit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbView As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbEdit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbFind As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbListAll As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSysInfo As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClose As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsdActive As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents tsmAdd As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmInherit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmView As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmEdit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmDelete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmFind As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmListAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmSysInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmPrint As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsbExportToExcel As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbImportData As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsmUpdateNewPrice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator10 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsmExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmImportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator11 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents chkShowDisabled As System.Windows.Forms.CheckBox
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsAdd As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsView As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsDelete As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Find As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsFind As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsListAll As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_Export As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnsImportData As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents ToolStripSeparator_SysInfo As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnsSysInfo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsInherit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnsUpdateNewPrice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator12 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator13 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnsPrint As System.Windows.Forms.ToolStripMenuItem
End Class
