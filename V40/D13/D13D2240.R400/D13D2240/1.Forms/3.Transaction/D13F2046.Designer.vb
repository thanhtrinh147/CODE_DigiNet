<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2046
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
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2046))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.flex = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnsExportToExcel = New System.Windows.Forms.ToolStripMenuItem
        Me.btnF12 = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.chkShowALL = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnFillter = New System.Windows.Forms.Button
        Me.tdbcPreSalaryVoucherID = New C1.Win.C1List.C1Combo
        Me.lblPreSalaryVoucherID = New System.Windows.Forms.Label
        Me.optMode1 = New System.Windows.Forms.RadioButton
        Me.optMode2 = New System.Windows.Forms.RadioButton
        CType(Me.flex, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.tdbcPreSalaryVoucherID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flex
        '
        Me.flex.ColumnInfo = "10,1,0,0,0,85,Columns:0{Width:21;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.flex.ContextMenuStrip = Me.ContextMenuStrip1
        Me.flex.Cursor = System.Windows.Forms.Cursors.Default
        Me.flex.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.flex.ExtendLastCol = True
        Me.flex.Location = New System.Drawing.Point(3, 33)
        Me.flex.Name = "flex"
        Me.flex.Rows.DefaultSize = 17
        Me.flex.Size = New System.Drawing.Size(1003, 581)
        Me.flex.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnsExportToExcel})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 26)
        '
        'mnsExportToExcel
        '
        Me.mnsExportToExcel.Name = "mnsExportToExcel"
        Me.mnsExportToExcel.Size = New System.Drawing.Size(125, 22)
        Me.mnsExportToExcel.Text = "Xuất &Excel"
        '
        'btnF12
        '
        Me.btnF12.Location = New System.Drawing.Point(3, 621)
        Me.btnF12.Name = "btnF12"
        Me.btnF12.Size = New System.Drawing.Size(102, 22)
        Me.btnF12.TabIndex = 21
        Me.btnF12.Text = "Hiển thị"
        Me.btnF12.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(930, 621)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 22
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'chkShowALL
        '
        Me.chkShowALL.AutoSize = True
        Me.chkShowALL.Location = New System.Drawing.Point(111, 623)
        Me.chkShowALL.Name = "chkShowALL"
        Me.chkShowALL.Size = New System.Drawing.Size(92, 17)
        Me.chkShowALL.TabIndex = 23
        Me.chkShowALL.Text = "Hiển thị tất cả"
        Me.chkShowALL.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optMode2)
        Me.Panel1.Controls.Add(Me.optMode1)
        Me.Panel1.Controls.Add(Me.btnFillter)
        Me.Panel1.Controls.Add(Me.tdbcPreSalaryVoucherID)
        Me.Panel1.Controls.Add(Me.lblPreSalaryVoucherID)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1003, 28)
        Me.Panel1.TabIndex = 24
        '
        'btnFillter
        '
        Me.btnFillter.Location = New System.Drawing.Point(630, 3)
        Me.btnFillter.Name = "btnFillter"
        Me.btnFillter.Size = New System.Drawing.Size(73, 22)
        Me.btnFillter.TabIndex = 4
        Me.btnFillter.Text = "Lọc (F5)"
        Me.btnFillter.UseVisualStyleBackColor = True
        '
        'tdbcPreSalaryVoucherID
        '
        Me.tdbcPreSalaryVoucherID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPreSalaryVoucherID.AllowColMove = False
        Me.tdbcPreSalaryVoucherID.AllowSort = False
        Me.tdbcPreSalaryVoucherID.AlternatingRows = True
        Me.tdbcPreSalaryVoucherID.AutoCompletion = True
        Me.tdbcPreSalaryVoucherID.AutoDropDown = True
        Me.tdbcPreSalaryVoucherID.Caption = ""
        Me.tdbcPreSalaryVoucherID.CaptionHeight = 17
        Me.tdbcPreSalaryVoucherID.CaptionStyle = Style9
        Me.tdbcPreSalaryVoucherID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPreSalaryVoucherID.ColumnCaptionHeight = 17
        Me.tdbcPreSalaryVoucherID.ColumnFooterHeight = 17
        Me.tdbcPreSalaryVoucherID.ColumnHeaders = False
        Me.tdbcPreSalaryVoucherID.ContentHeight = 17
        Me.tdbcPreSalaryVoucherID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPreSalaryVoucherID.DisplayMember = "Description"
        Me.tdbcPreSalaryVoucherID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPreSalaryVoucherID.DropDownWidth = 229
        Me.tdbcPreSalaryVoucherID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPreSalaryVoucherID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPreSalaryVoucherID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPreSalaryVoucherID.EditorHeight = 17
        Me.tdbcPreSalaryVoucherID.EmptyRows = True
        Me.tdbcPreSalaryVoucherID.EvenRowStyle = Style10
        Me.tdbcPreSalaryVoucherID.ExtendRightColumn = True
        Me.tdbcPreSalaryVoucherID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPreSalaryVoucherID.FooterStyle = Style11
        Me.tdbcPreSalaryVoucherID.HeadingStyle = Style12
        Me.tdbcPreSalaryVoucherID.HighLightRowStyle = Style13
        Me.tdbcPreSalaryVoucherID.Images.Add(CType(resources.GetObject("tdbcPreSalaryVoucherID.Images"), System.Drawing.Image))
        Me.tdbcPreSalaryVoucherID.ItemHeight = 15
        Me.tdbcPreSalaryVoucherID.Location = New System.Drawing.Point(150, 3)
        Me.tdbcPreSalaryVoucherID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPreSalaryVoucherID.MaxDropDownItems = CType(8, Short)
        Me.tdbcPreSalaryVoucherID.MaxLength = 32767
        Me.tdbcPreSalaryVoucherID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPreSalaryVoucherID.Name = "tdbcPreSalaryVoucherID"
        Me.tdbcPreSalaryVoucherID.OddRowStyle = Style14
        Me.tdbcPreSalaryVoucherID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPreSalaryVoucherID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPreSalaryVoucherID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPreSalaryVoucherID.SelectedStyle = Style15
        Me.tdbcPreSalaryVoucherID.Size = New System.Drawing.Size(229, 23)
        Me.tdbcPreSalaryVoucherID.Style = Style16
        Me.tdbcPreSalaryVoucherID.TabIndex = 0
        Me.tdbcPreSalaryVoucherID.ValueMember = "PreSalaryVoucherID"
        Me.tdbcPreSalaryVoucherID.PropBag = resources.GetString("tdbcPreSalaryVoucherID.PropBag")
        '
        'lblPreSalaryVoucherID
        '
        Me.lblPreSalaryVoucherID.AutoSize = True
        Me.lblPreSalaryVoucherID.Location = New System.Drawing.Point(3, 7)
        Me.lblPreSalaryVoucherID.Name = "lblPreSalaryVoucherID"
        Me.lblPreSalaryVoucherID.Size = New System.Drawing.Size(131, 13)
        Me.lblPreSalaryVoucherID.TabIndex = 1
        Me.lblPreSalaryVoucherID.Text = "Phiếu lương cần đối chiếu"
        Me.lblPreSalaryVoucherID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'optMode1
        '
        Me.optMode1.AutoSize = True
        Me.optMode1.Checked = True
        Me.optMode1.Location = New System.Drawing.Point(412, 5)
        Me.optMode1.Name = "optMode1"
        Me.optMode1.Size = New System.Drawing.Size(85, 17)
        Me.optMode1.TabIndex = 5
        Me.optMode1.TabStop = True
        Me.optMode1.Text = "Chiều ngang"
        Me.optMode1.UseVisualStyleBackColor = True
        '
        'optMode2
        '
        Me.optMode2.AutoSize = True
        Me.optMode2.Location = New System.Drawing.Point(524, 5)
        Me.optMode2.Name = "optMode2"
        Me.optMode2.Size = New System.Drawing.Size(73, 17)
        Me.optMode2.TabIndex = 6
        Me.optMode2.Text = "Chiều dọc"
        Me.optMode2.UseVisualStyleBackColor = True
        '
        'D13F2046
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 645)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkShowALL)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnF12)
        Me.Controls.Add(Me.flex)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2046"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " - D13F2046"
        CType(Me.flex, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.tdbcPreSalaryVoucherID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents flex As C1.Win.C1FlexGrid.C1FlexGrid
    Private WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Private WithEvents mnsExportToExcel As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents btnF12 As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents chkShowALL As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents tdbcPreSalaryVoucherID As C1.Win.C1List.C1Combo
    Private WithEvents lblPreSalaryVoucherID As System.Windows.Forms.Label
    Private WithEvents btnFillter As System.Windows.Forms.Button
    Private WithEvents optMode1 As System.Windows.Forms.RadioButton
    Private WithEvents optMode2 As System.Windows.Forms.RadioButton
End Class
