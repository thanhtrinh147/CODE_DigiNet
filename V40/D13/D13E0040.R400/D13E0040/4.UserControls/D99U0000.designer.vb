<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D99U0000
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D99U0000))
        Me.tvw1 = New System.Windows.Forms.TreeView
        Me.imgTree = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlSetup = New System.Windows.Forms.Panel
        Me.pnl1 = New System.Windows.Forms.Panel
        Me.btnSetup = New System.Windows.Forms.Button
        Me.optStandard = New System.Windows.Forms.RadioButton
        Me.optPersonal = New System.Windows.Forms.RadioButton
        Me.pnlSetup.SuspendLayout()
        Me.pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tvw1
        '
        Me.tvw1.Dock = System.Windows.Forms.DockStyle.Top
        Me.tvw1.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tvw1.ItemHeight = 25
        Me.tvw1.Location = New System.Drawing.Point(0, 0)
        Me.tvw1.Name = "tvw1"
        Me.tvw1.Size = New System.Drawing.Size(968, 637)
        Me.tvw1.TabIndex = 3
        '
        'imgTree
        '
        Me.imgTree.ImageStream = CType(resources.GetObject("imgTree.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTree.TransparentColor = System.Drawing.Color.Transparent
        Me.imgTree.Images.SetKeyName(0, "Folder_D91.gif")
        Me.imgTree.Images.SetKeyName(1, "File_D91.gif")
        '
        'pnlSetup
        '
        Me.pnlSetup.Controls.Add(Me.pnl1)
        Me.pnlSetup.Controls.Add(Me.tvw1)
        Me.pnlSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlSetup.Location = New System.Drawing.Point(0, 0)
        Me.pnlSetup.Name = "pnlSetup"
        Me.pnlSetup.Size = New System.Drawing.Size(968, 600)
        Me.pnlSetup.TabIndex = 9
        '
        'pnl1
        '
        Me.pnl1.Controls.Add(Me.btnSetup)
        Me.pnl1.Controls.Add(Me.optStandard)
        Me.pnl1.Controls.Add(Me.optPersonal)
        Me.pnl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnl1.Location = New System.Drawing.Point(0, 573)
        Me.pnl1.Name = "pnl1"
        Me.pnl1.Size = New System.Drawing.Size(968, 27)
        Me.pnl1.TabIndex = 10
        '
        'btnSetup
        '
        Me.btnSetup.Location = New System.Drawing.Point(154, 3)
        Me.btnSetup.Name = "btnSetup"
        Me.btnSetup.Size = New System.Drawing.Size(81, 22)
        Me.btnSetup.TabIndex = 9
        Me.btnSetup.Text = "Thiết lập"
        Me.btnSetup.UseVisualStyleBackColor = True
        '
        'optStandard
        '
        Me.optStandard.AutoSize = True
        Me.optStandard.Checked = True
        Me.optStandard.Location = New System.Drawing.Point(8, 8)
        Me.optStandard.Name = "optStandard"
        Me.optStandard.Size = New System.Drawing.Size(56, 17)
        Me.optStandard.TabIndex = 7
        Me.optStandard.TabStop = True
        Me.optStandard.Text = "Chuẩn"
        Me.optStandard.UseVisualStyleBackColor = True
        '
        'optPersonal
        '
        Me.optPersonal.AutoSize = True
        Me.optPersonal.Location = New System.Drawing.Point(83, 8)
        Me.optPersonal.Name = "optPersonal"
        Me.optPersonal.Size = New System.Drawing.Size(65, 17)
        Me.optPersonal.TabIndex = 8
        Me.optPersonal.Text = "Cá nhân"
        Me.optPersonal.UseVisualStyleBackColor = True
        '
        'D99U0000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.pnlSetup)
        Me.Name = "D99U0000"
        Me.Size = New System.Drawing.Size(968, 600)
        Me.pnlSetup.ResumeLayout(False)
        Me.pnl1.ResumeLayout(False)
        Me.pnl1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tvw1 As System.Windows.Forms.TreeView
    Friend WithEvents imgTree As System.Windows.Forms.ImageList
    Friend WithEvents pnlSetup As System.Windows.Forms.Panel
    Private WithEvents btnSetup As System.Windows.Forms.Button
    Private WithEvents optPersonal As System.Windows.Forms.RadioButton
    Private WithEvents optStandard As System.Windows.Forms.RadioButton
    Private WithEvents pnl1 As System.Windows.Forms.Panel

End Class
