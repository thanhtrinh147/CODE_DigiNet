<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2061
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2061))
        Me.txtTransferMethodID = New System.Windows.Forms.TextBox
        Me.lblTransferMethodID = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtTransferMethodName = New System.Windows.Forms.TextBox
        Me.lblTransferMethodName = New System.Windows.Forms.Label
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.lblNote = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCollectDetail = New System.Windows.Forms.Button
        Me.optCollect = New System.Windows.Forms.RadioButton
        Me.optDetail = New System.Windows.Forms.RadioButton
        Me.btnDetail = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grp2 = New System.Windows.Forms.GroupBox
        Me.lblTransfer = New System.Windows.Forms.Label
        Me.btnNext = New System.Windows.Forms.Button
        Me.grp2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTransferMethodID
        '
        Me.txtTransferMethodID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTransferMethodID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransferMethodID.Location = New System.Drawing.Point(124, 11)
        Me.txtTransferMethodID.MaxLength = 20
        Me.txtTransferMethodID.Name = "txtTransferMethodID"
        Me.txtTransferMethodID.Size = New System.Drawing.Size(151, 22)
        Me.txtTransferMethodID.TabIndex = 0
        '
        'lblTransferMethodID
        '
        Me.lblTransferMethodID.AutoSize = True
        Me.lblTransferMethodID.Location = New System.Drawing.Point(5, 16)
        Me.lblTransferMethodID.Name = "lblTransferMethodID"
        Me.lblTransferMethodID.Size = New System.Drawing.Size(22, 13)
        Me.lblTransferMethodID.TabIndex = 1
        Me.lblTransferMethodID.Text = "Mã"
        Me.lblTransferMethodID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(411, 14)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtTransferMethodName
        '
        Me.txtTransferMethodName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTransferMethodName.Location = New System.Drawing.Point(124, 38)
        Me.txtTransferMethodName.MaxLength = 250
        Me.txtTransferMethodName.Name = "txtTransferMethodName"
        Me.txtTransferMethodName.Size = New System.Drawing.Size(381, 22)
        Me.txtTransferMethodName.TabIndex = 2
        '
        'lblTransferMethodName
        '
        Me.lblTransferMethodName.AutoSize = True
        Me.lblTransferMethodName.Location = New System.Drawing.Point(5, 43)
        Me.lblTransferMethodName.Name = "lblTransferMethodName"
        Me.lblTransferMethodName.Size = New System.Drawing.Size(48, 13)
        Me.lblTransferMethodName.TabIndex = 4
        Me.lblTransferMethodName.Text = "Diễn giải"
        Me.lblTransferMethodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(124, 66)
        Me.txtNote.MaxLength = 250
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNote.Size = New System.Drawing.Size(381, 91)
        Me.txtNote.TabIndex = 3
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(5, 66)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 6
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(152, 173)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(353, 2)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'btnCollectDetail
        '
        Me.btnCollectDetail.Enabled = False
        Me.btnCollectDetail.Location = New System.Drawing.Point(362, 183)
        Me.btnCollectDetail.Name = "btnCollectDetail"
        Me.btnCollectDetail.Size = New System.Drawing.Size(145, 22)
        Me.btnCollectDetail.TabIndex = 7
        Me.btnCollectDetail.Text = "&Chi tiết chuyển tổng hợp"
        Me.btnCollectDetail.UseVisualStyleBackColor = True
        '
        'optCollect
        '
        Me.optCollect.AutoSize = True
        Me.optCollect.Location = New System.Drawing.Point(245, 186)
        Me.optCollect.Name = "optCollect"
        Me.optCollect.Size = New System.Drawing.Size(71, 17)
        Me.optCollect.TabIndex = 6
        Me.optCollect.Text = "Tổng hợp"
        Me.optCollect.UseVisualStyleBackColor = True
        '
        'optDetail
        '
        Me.optDetail.AutoSize = True
        Me.optDetail.Checked = True
        Me.optDetail.Location = New System.Drawing.Point(124, 186)
        Me.optDetail.Name = "optDetail"
        Me.optDetail.Size = New System.Drawing.Size(57, 17)
        Me.optDetail.TabIndex = 5
        Me.optDetail.TabStop = True
        Me.optDetail.Text = "Chi tiết"
        Me.optDetail.UseVisualStyleBackColor = True
        '
        'btnDetail
        '
        Me.btnDetail.Location = New System.Drawing.Point(207, 218)
        Me.btnDetail.Name = "btnDetail"
        Me.btnDetail.Size = New System.Drawing.Size(76, 22)
        Me.btnDetail.TabIndex = 1
        Me.btnDetail.Text = "&Chi tiết"
        Me.btnDetail.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(286, 218)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(444, 218)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grp2
        '
        Me.grp2.Controls.Add(Me.lblTransfer)
        Me.grp2.Controls.Add(Me.btnCollectDetail)
        Me.grp2.Controls.Add(Me.lblTransferMethodID)
        Me.grp2.Controls.Add(Me.optCollect)
        Me.grp2.Controls.Add(Me.optDetail)
        Me.grp2.Controls.Add(Me.lblNote)
        Me.grp2.Controls.Add(Me.lblTransferMethodName)
        Me.grp2.Controls.Add(Me.txtTransferMethodID)
        Me.grp2.Controls.Add(Me.chkDisabled)
        Me.grp2.Controls.Add(Me.txtTransferMethodName)
        Me.grp2.Controls.Add(Me.GroupBox1)
        Me.grp2.Controls.Add(Me.txtNote)
        Me.grp2.Location = New System.Drawing.Point(6, 1)
        Me.grp2.Name = "grp2"
        Me.grp2.Size = New System.Drawing.Size(514, 211)
        Me.grp2.TabIndex = 0
        Me.grp2.TabStop = False
        '
        'lblTransfer
        '
        Me.lblTransfer.AutoSize = True
        Me.lblTransfer.Location = New System.Drawing.Point(5, 168)
        Me.lblTransfer.Name = "lblTransfer"
        Me.lblTransfer.Size = New System.Drawing.Size(133, 13)
        Me.lblTransfer.TabIndex = 4
        Me.lblTransfer.Text = "Hình thức chuyển bút toán"
        Me.lblTransfer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(365, 218)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'D13F2061
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 245)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grp2)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDetail)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2061"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt ph§¥ng phÀp chuyÓn bòt toÀn - D13F2061"
        Me.grp2.ResumeLayout(False)
        Me.grp2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtTransferMethodID As System.Windows.Forms.TextBox
    Private WithEvents lblTransferMethodID As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtTransferMethodName As System.Windows.Forms.TextBox
    Private WithEvents lblTransferMethodName As System.Windows.Forms.Label
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents optDetail As System.Windows.Forms.RadioButton
    Private WithEvents btnCollectDetail As System.Windows.Forms.Button
    Private WithEvents optCollect As System.Windows.Forms.RadioButton
    Private WithEvents btnDetail As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents grp2 As System.Windows.Forms.GroupBox
    Private WithEvents lblTransfer As System.Windows.Forms.Label
    Private WithEvents btnNext As System.Windows.Forms.Button
End Class
