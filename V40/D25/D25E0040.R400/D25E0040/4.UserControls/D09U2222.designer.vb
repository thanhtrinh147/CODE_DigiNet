<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D09U2222
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
        Me.SplitMain = New System.Windows.Forms.SplitContainer
        Me.SplitSubTop = New System.Windows.Forms.SplitContainer
        Me.SplitSubBottom = New System.Windows.Forms.SplitContainer
        Me.SplitMain.Panel1.SuspendLayout()
        Me.SplitMain.Panel2.SuspendLayout()
        Me.SplitMain.SuspendLayout()
        Me.SplitSubTop.SuspendLayout()
        Me.SplitSubBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitMain
        '
        Me.SplitMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitMain.Name = "SplitMain"
        Me.SplitMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitMain.Panel1
        '
        Me.SplitMain.Panel1.Controls.Add(Me.SplitSubTop)
        '
        'SplitMain.Panel2
        '
        Me.SplitMain.Panel2.Controls.Add(Me.SplitSubBottom)
        Me.SplitMain.Size = New System.Drawing.Size(726, 527)
        Me.SplitMain.SplitterDistance = 263
        Me.SplitMain.SplitterWidth = 1
        Me.SplitMain.TabIndex = 0
        '
        'SplitSubTop
        '
        Me.SplitSubTop.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitSubTop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitSubTop.Location = New System.Drawing.Point(0, 0)
        Me.SplitSubTop.Name = "SplitSubTop"
        '
        'SplitSubTop.Panel1
        '
        Me.SplitSubTop.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitSubTop.Panel1MinSize = 0
        '
        'SplitSubTop.Panel2
        '
        Me.SplitSubTop.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitSubTop.Panel2MinSize = 0
        Me.SplitSubTop.Size = New System.Drawing.Size(726, 263)
        Me.SplitSubTop.SplitterDistance = 242
        Me.SplitSubTop.SplitterWidth = 1
        Me.SplitSubTop.TabIndex = 0
        '
        'SplitSubBottom
        '
        Me.SplitSubBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitSubBottom.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitSubBottom.Location = New System.Drawing.Point(0, 0)
        Me.SplitSubBottom.Name = "SplitSubBottom"
        '
        'SplitSubBottom.Panel1
        '
        Me.SplitSubBottom.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.SplitSubBottom.Panel1MinSize = 0
        '
        'SplitSubBottom.Panel2
        '
        Me.SplitSubBottom.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.SplitSubBottom.Panel2MinSize = 0
        Me.SplitSubBottom.Size = New System.Drawing.Size(726, 263)
        Me.SplitSubBottom.SplitterDistance = 242
        Me.SplitSubBottom.SplitterWidth = 1
        Me.SplitSubBottom.TabIndex = 0
        '
        'D09U2222
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitMain)
        Me.Name = "D09U2222"
        Me.Size = New System.Drawing.Size(726, 527)
        Me.SplitMain.Panel1.ResumeLayout(False)
        Me.SplitMain.Panel2.ResumeLayout(False)
        Me.SplitMain.ResumeLayout(False)
        Me.SplitSubTop.ResumeLayout(False)
        Me.SplitSubBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitSubTop As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitSubBottom As System.Windows.Forms.SplitContainer

End Class
