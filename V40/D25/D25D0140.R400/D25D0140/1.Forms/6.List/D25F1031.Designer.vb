<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1031
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1031))
        Me.grpq = New System.Windows.Forms.GroupBox
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.txtRecCostName = New System.Windows.Forms.TextBox
        Me.txtRecCostID = New System.Windows.Forms.TextBox
        Me.lblRecCostID = New System.Windows.Forms.Label
        Me.lblRecCostName = New System.Windows.Forms.Label
        Me.lblNote = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpq.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpq
        '
        Me.grpq.Controls.Add(Me.chkDisabled)
        Me.grpq.Controls.Add(Me.txtNote)
        Me.grpq.Controls.Add(Me.txtRecCostName)
        Me.grpq.Controls.Add(Me.txtRecCostID)
        Me.grpq.Controls.Add(Me.lblRecCostID)
        Me.grpq.Controls.Add(Me.lblRecCostName)
        Me.grpq.Controls.Add(Me.lblNote)
        Me.grpq.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpq.Location = New System.Drawing.Point(9, 3)
        Me.grpq.Name = "grpq"
        Me.grpq.Size = New System.Drawing.Size(469, 184)
        Me.grpq.TabIndex = 0
        Me.grpq.TabStop = False
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDisabled.Location = New System.Drawing.Point(356, 20)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 2
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNote.Location = New System.Drawing.Point(84, 71)
        Me.txtNote.MaxLength = 250
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(370, 105)
        Me.txtNote.TabIndex = 6
        '
        'txtRecCostName
        '
        Me.txtRecCostName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRecCostName.Location = New System.Drawing.Point(84, 43)
        Me.txtRecCostName.MaxLength = 50
        Me.txtRecCostName.Name = "txtRecCostName"
        Me.txtRecCostName.Size = New System.Drawing.Size(370, 22)
        Me.txtRecCostName.TabIndex = 4
        '
        'txtRecCostID
        '
        Me.txtRecCostID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRecCostID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRecCostID.Location = New System.Drawing.Point(84, 17)
        Me.txtRecCostID.MaxLength = 20
        Me.txtRecCostID.Name = "txtRecCostID"
        Me.txtRecCostID.Size = New System.Drawing.Size(150, 22)
        Me.txtRecCostID.TabIndex = 1
        '
        'lblRecCostID
        '
        Me.lblRecCostID.AutoSize = True
        Me.lblRecCostID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecCostID.Location = New System.Drawing.Point(13, 22)
        Me.lblRecCostID.Name = "lblRecCostID"
        Me.lblRecCostID.Size = New System.Drawing.Size(22, 13)
        Me.lblRecCostID.TabIndex = 0
        Me.lblRecCostID.Text = "Mã"
        Me.lblRecCostID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecCostName
        '
        Me.lblRecCostName.AutoSize = True
        Me.lblRecCostName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecCostName.Location = New System.Drawing.Point(13, 48)
        Me.lblRecCostName.Name = "lblRecCostName"
        Me.lblRecCostName.Size = New System.Drawing.Size(48, 13)
        Me.lblRecCostName.TabIndex = 3
        Me.lblRecCostName.Text = "Diễn giải"
        Me.lblRecCostName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNote
        '
        Me.lblNote.AutoSize = True
        Me.lblNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNote.Location = New System.Drawing.Point(13, 75)
        Me.lblNote.Name = "lblNote"
        Me.lblNote.Size = New System.Drawing.Size(44, 13)
        Me.lblNote.TabIndex = 5
        Me.lblNote.Text = "Ghi chú"
        Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(238, 193)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(320, 193)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 2
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(402, 193)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D25F1031
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 221)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grpq)
        Me.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1031"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt chi phÛ tuyÓn dóng - D25F1031"
        Me.grpq.ResumeLayout(False)
        Me.grpq.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grpq As System.Windows.Forms.GroupBox
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtNote As System.Windows.Forms.TextBox
    Private WithEvents txtRecCostName As System.Windows.Forms.TextBox
    Private WithEvents txtRecCostID As System.Windows.Forms.TextBox
    Private WithEvents lblRecCostID As System.Windows.Forms.Label
    Private WithEvents lblRecCostName As System.Windows.Forms.Label
    Private WithEvents lblNote As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
