<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2055
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
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2055))
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tdbdSalSystemID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.txtSalaryMethodName = New System.Windows.Forms.TextBox
        Me.lblSalaryMethodName = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.chkIsBackPay = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbdSalSystemID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tdbdSalSystemID)
        Me.GroupBox1.Controls.Add(Me.tdbg)
        Me.GroupBox1.Controls.Add(Me.txtSalaryMethodName)
        Me.GroupBox1.Controls.Add(Me.lblSalaryMethodName)
        Me.GroupBox1.Location = New System.Drawing.Point(6, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(581, 368)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tdbdSalSystemID
        '
        Me.tdbdSalSystemID.AllowColMove = False
        Me.tdbdSalSystemID.AllowColSelect = False
        Me.tdbdSalSystemID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdSalSystemID.AllowSort = False
        Me.tdbdSalSystemID.AlternatingRows = True
        Me.tdbdSalSystemID.CaptionHeight = 17
        Me.tdbdSalSystemID.CaptionStyle = Style1
        Me.tdbdSalSystemID.ColumnCaptionHeight = 17
        Me.tdbdSalSystemID.ColumnFooterHeight = 17
        Me.tdbdSalSystemID.ColumnHeaders = False
        Me.tdbdSalSystemID.DisplayMember = "SalSysShortName"
        Me.tdbdSalSystemID.EmptyRows = True
        Me.tdbdSalSystemID.EvenRowStyle = Style2
        Me.tdbdSalSystemID.ExtendRightColumn = True
        Me.tdbdSalSystemID.FetchRowStyles = False
        Me.tdbdSalSystemID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdSalSystemID.FooterStyle = Style3
        Me.tdbdSalSystemID.HeadingStyle = Style4
        Me.tdbdSalSystemID.HighLightRowStyle = Style5
        Me.tdbdSalSystemID.Images.Add(CType(resources.GetObject("tdbdSalSystemID.Images"), System.Drawing.Image))
        Me.tdbdSalSystemID.Location = New System.Drawing.Point(286, 108)
        Me.tdbdSalSystemID.Name = "tdbdSalSystemID"
        Me.tdbdSalSystemID.OddRowStyle = Style6
        Me.tdbdSalSystemID.RecordSelectorStyle = Style7
        Me.tdbdSalSystemID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdSalSystemID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdSalSystemID.RowHeight = 15
        Me.tdbdSalSystemID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdSalSystemID.ScrollTips = False
        Me.tdbdSalSystemID.Size = New System.Drawing.Size(140, 147)
        Me.tdbdSalSystemID.Style = Style8
        Me.tdbdSalSystemID.TabIndex = 3
        Me.tdbdSalSystemID.TabStop = False
        Me.tdbdSalSystemID.ValueMember = "SalSystemID"
        Me.tdbdSalSystemID.ValueTranslate = True
        Me.tdbdSalSystemID.Visible = False
        Me.tdbdSalSystemID.PropBag = resources.GetString("tdbdSalSystemID.PropBag")
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 44)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(564, 316)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 2
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'txtSalaryMethodName
        '
        Me.txtSalaryMethodName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSalaryMethodName.Location = New System.Drawing.Point(134, 16)
        Me.txtSalaryMethodName.Name = "txtSalaryMethodName"
        Me.txtSalaryMethodName.ReadOnly = True
        Me.txtSalaryMethodName.Size = New System.Drawing.Size(439, 22)
        Me.txtSalaryMethodName.TabIndex = 1
        Me.txtSalaryMethodName.TabStop = False
        '
        'lblSalaryMethodName
        '
        Me.lblSalaryMethodName.AutoSize = True
        Me.lblSalaryMethodName.Location = New System.Drawing.Point(6, 20)
        Me.lblSalaryMethodName.Name = "lblSalaryMethodName"
        Me.lblSalaryMethodName.Size = New System.Drawing.Size(72, 13)
        Me.lblSalaryMethodName.TabIndex = 0
        Me.lblSalaryMethodName.Text = "PP tính lương"
        Me.lblSalaryMethodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(511, 374)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(429, 374)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        '
        'chkIsBackPay
        '
        Me.chkIsBackPay.AutoSize = True
        Me.chkIsBackPay.Location = New System.Drawing.Point(6, 376)
        Me.chkIsBackPay.Name = "chkIsBackPay"
        Me.chkIsBackPay.Size = New System.Drawing.Size(217, 17)
        Me.chkIsBackPay.TabIndex = 3
        Me.chkIsBackPay.Text = "Chỉ hiển thị những khoản có hồi tố lương"
        Me.chkIsBackPay.UseVisualStyleBackColor = True
        '
        'D13F2055
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(594, 399)
        Me.Controls.Add(Me.chkIsBackPay)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2055"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp häi tç l§¥ng - D13F2055"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tdbdSalSystemID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtSalaryMethodName As System.Windows.Forms.TextBox
    Private WithEvents lblSalaryMethodName As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents chkIsBackPay As System.Windows.Forms.CheckBox
    Private WithEvents tdbdSalSystemID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class
