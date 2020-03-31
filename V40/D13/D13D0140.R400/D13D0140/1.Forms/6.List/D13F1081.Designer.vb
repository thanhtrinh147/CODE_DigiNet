<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1081
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1081))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.optFullProgressive = New System.Windows.Forms.RadioButton
        Me.optPartProgressive = New System.Windows.Forms.RadioButton
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.optMonthReward = New System.Windows.Forms.RadioButton
        Me.optDateReward = New System.Windows.Forms.RadioButton
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtRewardName = New System.Windows.Forms.TextBox
        Me.txtRewardID = New System.Windows.Forms.TextBox
        Me.lblRewardID = New System.Windows.Forms.Label
        Me.lblRewardName = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.grp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tdbg)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.grp2)
        Me.GroupBox1.Controls.Add(Me.chkDisabled)
        Me.GroupBox1.Controls.Add(Me.txtRewardName)
        Me.GroupBox1.Controls.Add(Me.txtRewardID)
        Me.GroupBox1.Controls.Add(Me.lblRewardID)
        Me.GroupBox1.Controls.Add(Me.lblRewardName)
        Me.GroupBox1.Location = New System.Drawing.Point(4, -1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(552, 365)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(10, 150)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(532, 206)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 5
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.optFullProgressive)
        Me.GroupBox3.Controls.Add(Me.optPartProgressive)
        Me.GroupBox3.Location = New System.Drawing.Point(277, 73)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(265, 71)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Phương pháp"
        '
        'optFullProgressive
        '
        Me.optFullProgressive.AutoSize = True
        Me.optFullProgressive.Location = New System.Drawing.Point(45, 42)
        Me.optFullProgressive.Name = "optFullProgressive"
        Me.optFullProgressive.Size = New System.Drawing.Size(113, 17)
        Me.optFullProgressive.TabIndex = 1
        Me.optFullProgressive.Text = "Lũy tiến toàn phần"
        Me.optFullProgressive.UseVisualStyleBackColor = True
        '
        'optPartProgressive
        '
        Me.optPartProgressive.AutoSize = True
        Me.optPartProgressive.Checked = True
        Me.optPartProgressive.Location = New System.Drawing.Point(45, 19)
        Me.optPartProgressive.Name = "optPartProgressive"
        Me.optPartProgressive.Size = New System.Drawing.Size(113, 17)
        Me.optPartProgressive.TabIndex = 0
        Me.optPartProgressive.TabStop = True
        Me.optPartProgressive.Text = "Lũy tiến từng phần"
        Me.optPartProgressive.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.optMonthReward)
        Me.grp2.Controls.Add(Me.optDateReward)
        Me.grp2.Location = New System.Drawing.Point(10, 73)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(265, 71)
        Me.grp2.TabIndex = 3
        Me.grp2.TabStop = False
        Me.grp2.Text = "Thời gian làm việc"
        '
        'optMonthReward
        '
        Me.optMonthReward.AutoSize = True
        Me.optMonthReward.Checked = True
        Me.optMonthReward.Location = New System.Drawing.Point(41, 42)
        Me.optMonthReward.Name = "optMonthReward"
        Me.optMonthReward.Size = New System.Drawing.Size(56, 17)
        Me.optMonthReward.TabIndex = 1
        Me.optMonthReward.TabStop = True
        Me.optMonthReward.Text = "Tháng"
        Me.optMonthReward.UseVisualStyleBackColor = True
        '
        'optDateReward
        '
        Me.optDateReward.AutoSize = True
        Me.optDateReward.Location = New System.Drawing.Point(41, 19)
        Me.optDateReward.Name = "optDateReward"
        Me.optDateReward.Size = New System.Drawing.Size(50, 17)
        Me.optDateReward.TabIndex = 0
        Me.optDateReward.Text = "Ngày"
        Me.optDateReward.UseVisualStyleBackColor = True
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(444, 18)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtRewardName
        '
        Me.txtRewardName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRewardName.Location = New System.Drawing.Point(81, 45)
        Me.txtRewardName.MaxLength = 50
        Me.txtRewardName.Name = "txtRewardName"
        Me.txtRewardName.Size = New System.Drawing.Size(461, 22)
        Me.txtRewardName.TabIndex = 2
        '
        'txtRewardID
        '
        Me.txtRewardID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRewardID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRewardID.Location = New System.Drawing.Point(81, 15)
        Me.txtRewardID.MaxLength = 20
        Me.txtRewardID.Name = "txtRewardID"
        Me.txtRewardID.Size = New System.Drawing.Size(158, 22)
        Me.txtRewardID.TabIndex = 0
        '
        'lblRewardID
        '
        Me.lblRewardID.AutoSize = True
        Me.lblRewardID.Location = New System.Drawing.Point(10, 20)
        Me.lblRewardID.Name = "lblRewardID"
        Me.lblRewardID.Size = New System.Drawing.Size(22, 13)
        Me.lblRewardID.TabIndex = 1
        Me.lblRewardID.Text = "Mã"
        Me.lblRewardID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRewardName
        '
        Me.lblRewardName.AutoSize = True
        Me.lblRewardName.Location = New System.Drawing.Point(10, 50)
        Me.lblRewardName.Name = "lblRewardName"
        Me.lblRewardName.Size = New System.Drawing.Size(48, 13)
        Me.lblRewardName.TabIndex = 3
        Me.lblRewardName.Text = "Diễn giải"
        Me.lblRewardName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(320, 370)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(480, 370)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(400, 370)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'D13F1081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 400)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1081"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt tiÒn th§êng theo th¡m ni£n -  D13F1081"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents txtRewardID As System.Windows.Forms.TextBox
    Private WithEvents lblRewardID As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grp2 As System.Windows.Forms.GroupBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtRewardName As System.Windows.Forms.TextBox
    Private WithEvents lblRewardName As System.Windows.Forms.Label
    Private WithEvents optFullProgressive As System.Windows.Forms.RadioButton
    Private WithEvents optPartProgressive As System.Windows.Forms.RadioButton
    Private WithEvents optMonthReward As System.Windows.Forms.RadioButton
    Private WithEvents optDateReward As System.Windows.Forms.RadioButton
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
End Class
