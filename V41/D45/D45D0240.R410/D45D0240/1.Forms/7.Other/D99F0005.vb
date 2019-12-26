
Friend Class D99F0005
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents TxtCreateUser As System.Windows.Forms.TextBox
    Friend WithEvents TxtCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents TxtModifyDate As System.Windows.Forms.TextBox
    Friend WithEvents TxtModifyUser As System.Windows.Forms.TextBox
    Friend WithEvents LblCreateUser As System.Windows.Forms.Label
    Friend WithEvents LblCreateDate As System.Windows.Forms.Label
    Friend WithEvents LblModifyDate As System.Windows.Forms.Label
    Friend WithEvents LblModifyUser As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D99F0005))
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LblModifyDate = New System.Windows.Forms.Label
        Me.LblModifyUser = New System.Windows.Forms.Label
        Me.LblCreateDate = New System.Windows.Forms.Label
        Me.LblCreateUser = New System.Windows.Forms.Label
        Me.TxtModifyDate = New System.Windows.Forms.TextBox
        Me.TxtModifyUser = New System.Windows.Forms.TextBox
        Me.TxtCreateDate = New System.Windows.Forms.TextBox
        Me.TxtCreateUser = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.SystemColors.Control
        Me.BtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.BtnClose.Location = New System.Drawing.Point(318, 160)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 25)
        Me.BtnClose.TabIndex = 7
        Me.BtnClose.Text = "Đó&ng"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.LblModifyDate)
        Me.GroupBox1.Controls.Add(Me.LblModifyUser)
        Me.GroupBox1.Controls.Add(Me.LblCreateDate)
        Me.GroupBox1.Controls.Add(Me.LblCreateUser)
        Me.GroupBox1.Controls.Add(Me.TxtModifyDate)
        Me.GroupBox1.Controls.Add(Me.TxtModifyUser)
        Me.GroupBox1.Controls.Add(Me.TxtCreateDate)
        Me.GroupBox1.Controls.Add(Me.TxtCreateUser)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(4, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 148)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'LblModifyDate
        '
        Me.LblModifyDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModifyDate.Location = New System.Drawing.Point(14, 114)
        Me.LblModifyDate.Name = "LblModifyDate"
        Me.LblModifyDate.Size = New System.Drawing.Size(134, 23)
        Me.LblModifyDate.TabIndex = 14
        Me.LblModifyDate.Text = "Ngày cập nhật cuối cùng"
        '
        'LblModifyUser
        '
        Me.LblModifyUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblModifyUser.Location = New System.Drawing.Point(14, 84)
        Me.LblModifyUser.Name = "LblModifyUser"
        Me.LblModifyUser.Size = New System.Drawing.Size(134, 23)
        Me.LblModifyUser.TabIndex = 13
        Me.LblModifyUser.Text = "Người cập nhật cuối cùng"
        '
        'LblCreateDate
        '
        Me.LblCreateDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreateDate.Location = New System.Drawing.Point(14, 55)
        Me.LblCreateDate.Name = "LblCreateDate"
        Me.LblCreateDate.Size = New System.Drawing.Size(134, 23)
        Me.LblCreateDate.TabIndex = 12
        Me.LblCreateDate.Text = "Ngày tạo"
        '
        'LblCreateUser
        '
        Me.LblCreateUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreateUser.Location = New System.Drawing.Point(14, 26)
        Me.LblCreateUser.Name = "LblCreateUser"
        Me.LblCreateUser.Size = New System.Drawing.Size(134, 23)
        Me.LblCreateUser.TabIndex = 11
        Me.LblCreateUser.Text = "Người tạo"
        '
        'TxtModifyDate
        '
        Me.TxtModifyDate.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TxtModifyDate.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModifyDate.Location = New System.Drawing.Point(156, 110)
        Me.TxtModifyDate.Name = "TxtModifyDate"
        Me.TxtModifyDate.ReadOnly = True
        Me.TxtModifyDate.Size = New System.Drawing.Size(211, 22)
        Me.TxtModifyDate.TabIndex = 10
        '
        'TxtModifyUser
        '
        Me.TxtModifyUser.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TxtModifyUser.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModifyUser.Location = New System.Drawing.Point(156, 80)
        Me.TxtModifyUser.Name = "TxtModifyUser"
        Me.TxtModifyUser.ReadOnly = True
        Me.TxtModifyUser.Size = New System.Drawing.Size(211, 22)
        Me.TxtModifyUser.TabIndex = 9
        '
        'TxtCreateDate
        '
        Me.TxtCreateDate.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TxtCreateDate.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCreateDate.Location = New System.Drawing.Point(156, 50)
        Me.TxtCreateDate.Name = "TxtCreateDate"
        Me.TxtCreateDate.ReadOnly = True
        Me.TxtCreateDate.Size = New System.Drawing.Size(211, 22)
        Me.TxtCreateDate.TabIndex = 8
        '
        'TxtCreateUser
        '
        Me.TxtCreateUser.BackColor = System.Drawing.SystemColors.HighlightText
        Me.TxtCreateUser.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCreateUser.Location = New System.Drawing.Point(156, 20)
        Me.TxtCreateUser.Name = "TxtCreateUser"
        Me.TxtCreateUser.ReadOnly = True
        Me.TxtCreateUser.Size = New System.Drawing.Size(211, 22)
        Me.TxtCreateUser.TabIndex = 7
        '
        'D99F0005
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(398, 193)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D99F0005"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "D99F0005"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub D99F0005_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        SetResolutionForm(Me)
    End Sub
End Class
