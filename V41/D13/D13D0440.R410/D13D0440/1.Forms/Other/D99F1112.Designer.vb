<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D99F1112
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D99F1112))
        Me.txtVoucherNo = New System.Windows.Forms.TextBox
        Me.lblVoucherNo = New System.Windows.Forms.Label
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'txtVoucherNo
        '
        Me.txtVoucherNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtVoucherNo.Location = New System.Drawing.Point(75, 12)
        Me.txtVoucherNo.MaxLength = 20
        Me.txtVoucherNo.Name = "txtVoucherNo"
        Me.txtVoucherNo.Size = New System.Drawing.Size(186, 22)
        Me.txtVoucherNo.TabIndex = 1
        '
        'lblVoucherNo
        '
        Me.lblVoucherNo.AutoSize = True
        Me.lblVoucherNo.Location = New System.Drawing.Point(10, 17)
        Me.lblVoucherNo.Name = "lblVoucherNo"
        Me.lblVoucherNo.Size = New System.Drawing.Size(49, 13)
        Me.lblVoucherNo.TabIndex = 0
        Me.lblVoucherNo.Text = "Số phiếu"
        Me.lblVoucherNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(107, 50)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(76, 22)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Đồn&g ý"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(185, 50)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D99F1112
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 87)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtVoucherNo)
        Me.Controls.Add(Me.lblVoucherNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D99F1112"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt sç phiÕu - D99F1112"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtVoucherNo As System.Windows.Forms.TextBox
    Private WithEvents lblVoucherNo As System.Windows.Forms.Label
    Private WithEvents btnOK As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
