<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1181
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1181))
        Me.txtSalEmpGroupID = New System.Windows.Forms.TextBox
        Me.lblSalEmpGroupID = New System.Windows.Forms.Label
        Me.grpMain = New System.Windows.Forms.GroupBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.txtSalEmpGroupName = New System.Windows.Forms.TextBox
        Me.lblSalEmpGroupName = New System.Windows.Forms.Label
        Me.lblNote = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnPermission = New System.Windows.Forms.Button
        Me.grpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtSalEmpGroupID
        '
        Me.txtSalEmpGroupID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSalEmpGroupID.Location = New System.Drawing.Point(75, 22)
        Me.txtSalEmpGroupID.MaxLength = 20
        Me.txtSalEmpGroupID.Name = "txtSalEmpGroupID"
        Me.txtSalEmpGroupID.Size = New System.Drawing.Size(180, 22)
        Me.txtSalEmpGroupID.TabIndex = 0
        '
        'lblSalEmpGroupID
        '
        Me.lblSalEmpGroupID.AutoSize = True
        Me.lblSalEmpGroupID.Location = New System.Drawing.Point(12, 27)
        Me.lblSalEmpGroupID.Name = "lblSalEmpGroupID"
        Me.lblSalEmpGroupID.Size = New System.Drawing.Size(22, 13)
        Me.lblSalEmpGroupID.TabIndex = 1
        Me.lblSalEmpGroupID.Text = "Mã"
        Me.lblSalEmpGroupID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpMain
        '
        Me.grpMain.Controls.Add(Me.chkDisabled)
        Me.grpMain.Controls.Add(Me.txtNote)
        Me.grpMain.Controls.Add(Me.txtSalEmpGroupName)
        Me.grpMain.Controls.Add(Me.lblSalEmpGroupID)
        Me.grpMain.Controls.Add(Me.txtSalEmpGroupID)
        Me.grpMain.Controls.Add(Me.lblSalEmpGroupName)
        Me.grpMain.Controls.Add(Me.lblNote)
        Me.grpMain.Location = New System.Drawing.Point(7, 1)
        Me.grpMain.Name = "grpMain"
        Me.grpMain.Size = New System.Drawing.Size(479, 128)
        Me.grpMain.TabIndex = 2
        Me.grpMain.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(373, 24)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 3
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(75, 89)
        Me.txtNote.MaxLength = 250
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(396, 22)
        Me.txtNote.TabIndex = 2
        '
        'txtSalEmpGroupName
        '
        Me.txtSalEmpGroupName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSalEmpGroupName.Location = New System.Drawing.Point(75, 55)
        Me.txtSalEmpGroupName.MaxLength = 250
        Me.txtSalEmpGroupName.Name = "txtSalEmpGroupName"
        Me.txtSalEmpGroupName.Size = New System.Drawing.Size(396, 22)
        Me.txtSalEmpGroupName.TabIndex = 1
        '
        'lblSalEmpGroupName
        '
        Me.lblSalEmpGroupName.AutoSize = True
        Me.lblSalEmpGroupName.Location = New System.Drawing.Point(12, 60)
        Me.lblSalEmpGroupName.Name = "lblSalEmpGroupName"
        Me.lblSalEmpGroupName.Size = New System.Drawing.Size(26, 13)
        Me.lblSalEmpGroupName.TabIndex = 3
        Me.lblSalEmpGroupName.Text = "Tên"
        Me.lblSalEmpGroupName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(12, 94)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 5
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(411, 134)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(329, 134)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "Nhập &tiếp"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(247, 134)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Lưu"
        '
        'btnPermission
        '
        Me.btnPermission.Location = New System.Drawing.Point(8, 135)
        Me.btnPermission.Name = "btnPermission"
        Me.btnPermission.Size = New System.Drawing.Size(135, 22)
        Me.btnPermission.TabIndex = 5
        Me.btnPermission.Text = "&Phân quyền dữ liệu"
        Me.btnPermission.UseVisualStyleBackColor = True
        '
        'D13F1181
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 162)
        Me.Controls.Add(Me.btnPermission)
        Me.Controls.Add(Me.grpMain)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1181"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt nhâm l§¥ng - D13F1181"
        Me.grpMain.ResumeLayout(False)
        Me.grpMain.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtSalEmpGroupID As System.Windows.Forms.TextBox
    Private WithEvents lblSalEmpGroupID As System.Windows.Forms.Label
    Private WithEvents grpMain As System.Windows.Forms.GroupBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents txtSalEmpGroupName As System.Windows.Forms.TextBox
    Private WithEvents lblSalEmpGroupName As System.Windows.Forms.Label
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnPermission As System.Windows.Forms.Button
End Class
