<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1251
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1251))
        Me.txtRefResultID = New System.Windows.Forms.TextBox()
        Me.lblRefResultID = New System.Windows.Forms.Label()
        Me.txtRefResultName = New System.Windows.Forms.TextBox()
        Me.lblRefResultName = New System.Windows.Forms.Label()
        Me.pnlB = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.pnlB.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRefResultID
        '
        Me.txtRefResultID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRefResultID.Location = New System.Drawing.Point(98, 13)
        Me.txtRefResultID.MaxLength = 20
        Me.txtRefResultID.Name = "txtRefResultID"
        Me.txtRefResultID.Size = New System.Drawing.Size(128, 22)
        Me.txtRefResultID.TabIndex = 1
        '
        'lblRefResultID
        '
        Me.lblRefResultID.AutoSize = True
        Me.lblRefResultID.Location = New System.Drawing.Point(11, 18)
        Me.lblRefResultID.Name = "lblRefResultID"
        Me.lblRefResultID.Size = New System.Drawing.Size(77, 13)
        Me.lblRefResultID.TabIndex = 0
        Me.lblRefResultID.Text = "Mã tham chiếu"
        Me.lblRefResultID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRefResultName
        '
        Me.txtRefResultName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRefResultName.Location = New System.Drawing.Point(98, 42)
        Me.txtRefResultName.MaxLength = 250
        Me.txtRefResultName.Name = "txtRefResultName"
        Me.txtRefResultName.Size = New System.Drawing.Size(381, 22)
        Me.txtRefResultName.TabIndex = 4
        '
        'lblRefResultName
        '
        Me.lblRefResultName.AutoSize = True
        Me.lblRefResultName.Location = New System.Drawing.Point(11, 47)
        Me.lblRefResultName.Name = "lblRefResultName"
        Me.lblRefResultName.Size = New System.Drawing.Size(81, 13)
        Me.lblRefResultName.TabIndex = 3
        Me.lblRefResultName.Text = "Tên tham chiếu"
        Me.lblRefResultName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlB
        '
        Me.pnlB.Controls.Add(Me.btnClose)
        Me.pnlB.Controls.Add(Me.btnNext)
        Me.pnlB.Controls.Add(Me.btnSave)
        Me.pnlB.Location = New System.Drawing.Point(139, 84)
        Me.pnlB.Name = "pnlB"
        Me.pnlB.Size = New System.Drawing.Size(346, 32)
        Me.pnlB.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(267, 3)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(74, 27)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Location = New System.Drawing.Point(179, 3)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(86, 27)
        Me.btnNext.TabIndex = 1
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.ImageIndex = 0
        Me.btnSave.Location = New System.Drawing.Point(96, 3)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(81, 27)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(233, 17)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'D13F1251
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 119)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.pnlB)
        Me.Controls.Add(Me.txtRefResultName)
        Me.Controls.Add(Me.txtRefResultID)
        Me.Controls.Add(Me.lblRefResultID)
        Me.Controls.Add(Me.lblRefResultName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1251"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Danh móc mº tham chiÕu theo théi gian - D13F1251"
        Me.pnlB.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtRefResultID As System.Windows.Forms.TextBox
    Private WithEvents lblRefResultID As System.Windows.Forms.Label
    Private WithEvents txtRefResultName As System.Windows.Forms.TextBox
    Private WithEvents lblRefResultName As System.Windows.Forms.Label
    Private WithEvents pnlB As System.Windows.Forms.Panel
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
