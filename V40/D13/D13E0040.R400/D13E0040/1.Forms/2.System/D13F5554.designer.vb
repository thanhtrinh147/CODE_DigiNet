<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F5554
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F5554))
        Me.lblDivisionCaption = New System.Windows.Forms.Label
        Me.lblDivisionID = New System.Windows.Forms.Label
        Me.lblPeriodCaption = New System.Windows.Forms.Label
        Me.lblPeriod = New System.Windows.Forms.Label
        Me.lblQuestion = New System.Windows.Forms.Label
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnNo = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblDivisionCaption
        '
        Me.lblDivisionCaption.AutoSize = True
        Me.lblDivisionCaption.Location = New System.Drawing.Point(33, 9)
        Me.lblDivisionCaption.Name = "lblDivisionCaption"
        Me.lblDivisionCaption.Size = New System.Drawing.Size(41, 13)
        Me.lblDivisionCaption.TabIndex = 2
        Me.lblDivisionCaption.Text = "Đơn vị:"
        Me.lblDivisionCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDivisionID
        '
        Me.lblDivisionID.AutoSize = True
        Me.lblDivisionID.Location = New System.Drawing.Point(106, 9)
        Me.lblDivisionID.Name = "lblDivisionID"
        Me.lblDivisionID.Size = New System.Drawing.Size(66, 13)
        Me.lblDivisionID.TabIndex = 3
        Me.lblDivisionID.Text = "gsDivisionID"
        Me.lblDivisionID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriodCaption
        '
        Me.lblPeriodCaption.AutoSize = True
        Me.lblPeriodCaption.Location = New System.Drawing.Point(33, 39)
        Me.lblPeriodCaption.Name = "lblPeriodCaption"
        Me.lblPeriodCaption.Size = New System.Drawing.Size(61, 13)
        Me.lblPeriodCaption.TabIndex = 4
        Me.lblPeriodCaption.Text = "Kỳ kế toán:"
        Me.lblPeriodCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPeriod
        '
        Me.lblPeriod.AutoSize = True
        Me.lblPeriod.Location = New System.Drawing.Point(106, 39)
        Me.lblPeriod.Name = "lblPeriod"
        Me.lblPeriod.Size = New System.Drawing.Size(37, 13)
        Me.lblPeriod.TabIndex = 5
        Me.lblPeriod.Text = "Period"
        Me.lblPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(33, 71)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(184, 13)
        Me.lblQuestion.TabIndex = 6
        Me.lblQuestion.Text = "Bạn có muốn khóa sổ kỳ này không?"
        Me.lblQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(41, 107)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(76, 22)
        Me.btnYes.TabIndex = 0
        Me.btnYes.Text = "&Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(125, 107)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(76, 22)
        Me.btnNo.TabIndex = 1
        Me.btnNo.Text = "&No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'D13F5554
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 141)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.lblPeriod)
        Me.Controls.Add(Me.lblPeriodCaption)
        Me.Controls.Add(Me.lblDivisionID)
        Me.Controls.Add(Me.lblDivisionCaption)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F5554"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Khâa så - D13F5554"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblDivisionCaption As System.Windows.Forms.Label
    Private WithEvents lblDivisionID As System.Windows.Forms.Label
    Private WithEvents lblPeriodCaption As System.Windows.Forms.Label
    Private WithEvents lblPeriod As System.Windows.Forms.Label
    Private WithEvents lblQuestion As System.Windows.Forms.Label
    Private WithEvents btnYes As System.Windows.Forms.Button
    Private WithEvents btnNo As System.Windows.Forms.Button
End Class
