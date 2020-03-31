<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1011))
        Me.txtRecSourceID = New System.Windows.Forms.TextBox
        Me.lblRecSourceID = New System.Windows.Forms.Label
        Me.txtRecSourceName = New System.Windows.Forms.TextBox
        Me.lblRecSourceName = New System.Windows.Forms.Label
        Me.grpContact = New System.Windows.Forms.GroupBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.txtContactPhone = New System.Windows.Forms.TextBox
        Me.txtDuty = New System.Windows.Forms.TextBox
        Me.txtContactPerson = New System.Windows.Forms.TextBox
        Me.lblContactPerson = New System.Windows.Forms.Label
        Me.lblDuty = New System.Windows.Forms.Label
        Me.lblContactPhone = New System.Windows.Forms.Label
        Me.lblNote = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpContact.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRecSourceID
        '
        Me.txtRecSourceID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecSourceID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRecSourceID.Location = New System.Drawing.Point(91, 6)
        Me.txtRecSourceID.MaxLength = 20
        Me.txtRecSourceID.Name = "txtRecSourceID"
        Me.txtRecSourceID.Size = New System.Drawing.Size(178, 22)
        Me.txtRecSourceID.TabIndex = 1
        '
        'lblRecSourceID
        '
        Me.lblRecSourceID.AutoSize = True
        Me.lblRecSourceID.Location = New System.Drawing.Point(9, 6)
        Me.lblRecSourceID.Name = "lblRecSourceID"
        Me.lblRecSourceID.Size = New System.Drawing.Size(22, 13)
        Me.lblRecSourceID.TabIndex = 0
        Me.lblRecSourceID.Text = "Mã"
        Me.lblRecSourceID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecSourceName
        '
        Me.txtRecSourceName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRecSourceName.Location = New System.Drawing.Point(91, 34)
        Me.txtRecSourceName.MaxLength = 50
        Me.txtRecSourceName.Name = "txtRecSourceName"
        Me.txtRecSourceName.Size = New System.Drawing.Size(367, 22)
        Me.txtRecSourceName.TabIndex = 4
        '
        'lblRecSourceName
        '
        Me.lblRecSourceName.AutoSize = True
        Me.lblRecSourceName.Location = New System.Drawing.Point(9, 34)
        Me.lblRecSourceName.Name = "lblRecSourceName"
        Me.lblRecSourceName.Size = New System.Drawing.Size(48, 13)
        Me.lblRecSourceName.TabIndex = 3
        Me.lblRecSourceName.Text = "Diễn giải"
        Me.lblRecSourceName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpContact
        '
        Me.grpContact.Controls.Add(Me.txtNote)
        Me.grpContact.Controls.Add(Me.txtContactPhone)
        Me.grpContact.Controls.Add(Me.txtDuty)
        Me.grpContact.Controls.Add(Me.txtContactPerson)
        Me.grpContact.Controls.Add(Me.lblContactPerson)
        Me.grpContact.Controls.Add(Me.lblDuty)
        Me.grpContact.Controls.Add(Me.lblContactPhone)
        Me.grpContact.Controls.Add(Me.lblNote)
        Me.grpContact.Location = New System.Drawing.Point(8, 62)
        Me.grpContact.Name = "grpContact"
        Me.grpContact.Size = New System.Drawing.Size(455, 188)
        Me.grpContact.TabIndex = 5
        Me.grpContact.TabStop = False
        Me.grpContact.Text = "Người liên hệ"
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(80, 103)
        Me.txtNote.MaxLength = 250
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(366, 76)
        Me.txtNote.TabIndex = 3
        '
        'txtContactPhone
        '
        Me.txtContactPhone.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtContactPhone.Location = New System.Drawing.Point(80, 75)
        Me.txtContactPhone.MaxLength = 50
        Me.txtContactPhone.Name = "txtContactPhone"
        Me.txtContactPhone.Size = New System.Drawing.Size(366, 22)
        Me.txtContactPhone.TabIndex = 2
        '
        'txtDuty
        '
        Me.txtDuty.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDuty.Location = New System.Drawing.Point(80, 47)
        Me.txtDuty.MaxLength = 50
        Me.txtDuty.Name = "txtDuty"
        Me.txtDuty.Size = New System.Drawing.Size(366, 22)
        Me.txtDuty.TabIndex = 1
        '
        'txtContactPerson
        '
        Me.txtContactPerson.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtContactPerson.Location = New System.Drawing.Point(80, 19)
        Me.txtContactPerson.MaxLength = 50
        Me.txtContactPerson.Name = "txtContactPerson"
        Me.txtContactPerson.Size = New System.Drawing.Size(366, 22)
        Me.txtContactPerson.TabIndex = 0
        '
        'lblContactPerson
        '
        Me.lblContactPerson.AutoSize = True
        Me.lblContactPerson.Location = New System.Drawing.Point(9, 23)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(54, 13)
        Me.lblContactPerson.TabIndex = 1
        Me.lblContactPerson.Text = "Họ và tên"
        Me.lblContactPerson.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDuty
        '
        Me.lblDuty.AutoSize = True
        Me.lblDuty.Location = New System.Drawing.Point(9, 51)
        Me.lblDuty.Name = "lblDuty"
        Me.lblDuty.Size = New System.Drawing.Size(47, 13)
        Me.lblDuty.TabIndex = 3
        Me.lblDuty.Text = "Chức vụ"
        Me.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblContactPhone
        '
        Me.lblContactPhone.AutoSize = True
        Me.lblContactPhone.Location = New System.Drawing.Point(9, 79)
        Me.lblContactPhone.Name = "lblContactPhone"
        Me.lblContactPhone.Size = New System.Drawing.Size(55, 13)
        Me.lblContactPhone.TabIndex = 5
        Me.lblContactPhone.Text = "Điện thoại"
        Me.lblContactPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Location = New System.Drawing.Point(9, 107)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 7
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(360, 9)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(223, 256)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(305, 256)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 7
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(387, 256)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D25F1011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 284)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.grpContact)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtRecSourceName)
        Me.Controls.Add(Me.txtRecSourceID)
        Me.Controls.Add(Me.lblRecSourceID)
        Me.Controls.Add(Me.lblRecSourceName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1011"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt nguän tuyÓn dóng - D25F1011"
        Me.grpContact.ResumeLayout(False)
        Me.grpContact.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtRecSourceID As System.Windows.Forms.TextBox
    Private WithEvents lblRecSourceID As System.Windows.Forms.Label
    Private WithEvents txtRecSourceName As System.Windows.Forms.TextBox
    Private WithEvents lblRecSourceName As System.Windows.Forms.Label
    Private WithEvents grpContact As System.Windows.Forms.GroupBox
    Private WithEvents txtContactPhone As System.Windows.Forms.TextBox
    Private WithEvents txtDuty As System.Windows.Forms.TextBox
    Private WithEvents txtContactPerson As System.Windows.Forms.TextBox
    Private WithEvents lblContactPerson As System.Windows.Forms.Label
    Private WithEvents lblDuty As System.Windows.Forms.Label
    Private WithEvents lblContactPhone As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
