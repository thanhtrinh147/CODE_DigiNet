<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnection
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConnection))
        Me.txtServerName = New System.Windows.Forms.TextBox
        Me.lblServerName = New System.Windows.Forms.Label
        Me.txtDBUserName = New System.Windows.Forms.TextBox
        Me.lblDBUserName = New System.Windows.Forms.Label
        Me.txtDBPassword = New System.Windows.Forms.TextBox
        Me.lblDBPassword = New System.Windows.Forms.Label
        Me.txtCompanyID = New System.Windows.Forms.TextBox
        Me.lblCompanyID = New System.Windows.Forms.Label
        Me.txtUserLogin = New System.Windows.Forms.TextBox
        Me.lblUserLogin = New System.Windows.Forms.Label
        Me.grpLine = New System.Windows.Forms.GroupBox
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtServerName
        '
        Me.txtServerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtServerName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtServerName.Location = New System.Drawing.Point(121, 12)
        Me.txtServerName.Name = "txtServerName"
        Me.txtServerName.Size = New System.Drawing.Size(128, 22)
        Me.txtServerName.TabIndex = 0
        '
        'lblServerName
        '
        Me.lblServerName.AutoSize = True
        Me.lblServerName.Location = New System.Drawing.Point(22, 17)
        Me.lblServerName.Name = "lblServerName"
        Me.lblServerName.Size = New System.Drawing.Size(69, 13)
        Me.lblServerName.TabIndex = 1
        Me.lblServerName.Text = "Tên máy chủ"
        Me.lblServerName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDBUserName
        '
        Me.txtDBUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDBUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtDBUserName.Location = New System.Drawing.Point(121, 39)
        Me.txtDBUserName.Name = "txtDBUserName"
        Me.txtDBUserName.Size = New System.Drawing.Size(128, 22)
        Me.txtDBUserName.TabIndex = 1
        '
        'lblDBUserName
        '
        Me.lblDBUserName.AutoSize = True
        Me.lblDBUserName.Location = New System.Drawing.Point(22, 44)
        Me.lblDBUserName.Name = "lblDBUserName"
        Me.lblDBUserName.Size = New System.Drawing.Size(62, 13)
        Me.lblDBUserName.TabIndex = 3
        Me.lblDBUserName.Text = "Người dùng"
        Me.lblDBUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDBPassword
        '
        Me.txtDBPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtDBPassword.Location = New System.Drawing.Point(121, 66)
        Me.txtDBPassword.Name = "txtDBPassword"
        Me.txtDBPassword.Size = New System.Drawing.Size(128, 22)
        Me.txtDBPassword.TabIndex = 2
        '
        'lblDBPassword
        '
        Me.lblDBPassword.AutoSize = True
        Me.lblDBPassword.Location = New System.Drawing.Point(22, 71)
        Me.lblDBPassword.Name = "lblDBPassword"
        Me.lblDBPassword.Size = New System.Drawing.Size(52, 13)
        Me.lblDBPassword.TabIndex = 5
        Me.lblDBPassword.Text = "Mật khẩu"
        Me.lblDBPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompanyID
        '
        Me.txtCompanyID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCompanyID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtCompanyID.Location = New System.Drawing.Point(121, 115)
        Me.txtCompanyID.Name = "txtCompanyID"
        Me.txtCompanyID.Size = New System.Drawing.Size(128, 22)
        Me.txtCompanyID.TabIndex = 3
        '
        'lblCompanyID
        '
        Me.lblCompanyID.AutoSize = True
        Me.lblCompanyID.Location = New System.Drawing.Point(22, 120)
        Me.lblCompanyID.Name = "lblCompanyID"
        Me.lblCompanyID.Size = New System.Drawing.Size(74, 13)
        Me.lblCompanyID.TabIndex = 7
        Me.lblCompanyID.Text = "Doanh nghiệp"
        Me.lblCompanyID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUserLogin
        '
        Me.txtUserLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserLogin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtUserLogin.Location = New System.Drawing.Point(121, 143)
        Me.txtUserLogin.Name = "txtUserLogin"
        Me.txtUserLogin.Size = New System.Drawing.Size(128, 22)
        Me.txtUserLogin.TabIndex = 4
        '
        'lblUserLogin
        '
        Me.lblUserLogin.AutoSize = True
        Me.lblUserLogin.Location = New System.Drawing.Point(22, 148)
        Me.lblUserLogin.Name = "lblUserLogin"
        Me.lblUserLogin.Size = New System.Drawing.Size(62, 13)
        Me.lblUserLogin.TabIndex = 9
        Me.lblUserLogin.Text = "Người dùng"
        Me.lblUserLogin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpLine
        '
        Me.grpLine.Location = New System.Drawing.Point(24, 96)
        Me.grpLine.Name = "grpLine"
        Me.grpLine.Size = New System.Drawing.Size(226, 7)
        Me.grpLine.TabIndex = 10
        Me.grpLine.TabStop = False
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(76, 199)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(84, 22)
        Me.btnYes.TabIndex = 5
        Me.btnYes.Text = "Đồng ý"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(166, 199)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đóng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmConnection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(280, 229)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.grpLine)
        Me.Controls.Add(Me.txtUserLogin)
        Me.Controls.Add(Me.txtCompanyID)
        Me.Controls.Add(Me.txtDBPassword)
        Me.Controls.Add(Me.txtDBUserName)
        Me.Controls.Add(Me.txtServerName)
        Me.Controls.Add(Me.lblServerName)
        Me.Controls.Add(Me.lblDBUserName)
        Me.Controls.Add(Me.lblDBPassword)
        Me.Controls.Add(Me.lblCompanyID)
        Me.Controls.Add(Me.lblUserLogin)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnection"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕt nçi hÖ thçng -  frmConnection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtServerName As System.Windows.Forms.TextBox
    Private WithEvents lblServerName As System.Windows.Forms.Label
    Private WithEvents txtDBUserName As System.Windows.Forms.TextBox
    Private WithEvents lblDBUserName As System.Windows.Forms.Label
    Private WithEvents txtDBPassword As System.Windows.Forms.TextBox
    Private WithEvents lblDBPassword As System.Windows.Forms.Label
    Private WithEvents txtCompanyID As System.Windows.Forms.TextBox
    Private WithEvents lblCompanyID As System.Windows.Forms.Label
    Private WithEvents txtUserLogin As System.Windows.Forms.TextBox
    Private WithEvents lblUserLogin As System.Windows.Forms.Label
    Private WithEvents grpLine As System.Windows.Forms.GroupBox
    Private WithEvents btnYes As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class