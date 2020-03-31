<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrctrlTextBox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.txtXXX = New System.Windows.Forms.TextBox
        Me.lblXXX = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtXXX
        '
        Me.txtXXX.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtXXX.Location = New System.Drawing.Point(125, 0)
        Me.txtXXX.Name = "txtXXX"
        Me.txtXXX.Size = New System.Drawing.Size(190, 22)
        Me.txtXXX.TabIndex = 0
        '
        'lblXXX
        '
        Me.lblXXX.AutoSize = True
        Me.lblXXX.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXXX.Location = New System.Drawing.Point(0, 4)
        Me.lblXXX.Name = "lblXXX"
        Me.lblXXX.Size = New System.Drawing.Size(31, 14)
        Me.lblXXX.TabIndex = 1
        Me.lblXXX.Text = "XXX"
        Me.lblXXX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'usrctrlTextBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtXXX)
        Me.Controls.Add(Me.lblXXX)
        Me.Name = "usrctrlTextBox"
        Me.Size = New System.Drawing.Size(315, 22)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtXXX As System.Windows.Forms.TextBox
    Private WithEvents lblXXX As System.Windows.Forms.Label

End Class
