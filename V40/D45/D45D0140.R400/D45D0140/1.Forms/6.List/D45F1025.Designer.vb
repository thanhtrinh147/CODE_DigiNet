<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1025
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1025))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.txtValue2 = New System.Windows.Forms.TextBox
        Me.txtValue1 = New System.Windows.Forms.TextBox
        Me.cboSign2 = New System.Windows.Forms.ComboBox
        Me.cboSign1 = New System.Windows.Forms.ComboBox
        Me.optPercent = New System.Windows.Forms.RadioButton
        Me.optValue = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblMethod = New System.Windows.Forms.Label
        Me.txtOldPriceListID = New System.Windows.Forms.TextBox
        Me.txtNewPriceListID = New System.Windows.Forms.TextBox
        Me.lblNewPriceListID = New System.Windows.Forms.Label
        Me.lblOldPriceListID = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lbl1)
        Me.GroupBox1.Controls.Add(Me.txtValue2)
        Me.GroupBox1.Controls.Add(Me.txtValue1)
        Me.GroupBox1.Controls.Add(Me.cboSign2)
        Me.GroupBox1.Controls.Add(Me.cboSign1)
        Me.GroupBox1.Controls.Add(Me.optPercent)
        Me.GroupBox1.Controls.Add(Me.optValue)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.lblMethod)
        Me.GroupBox1.Controls.Add(Me.txtOldPriceListID)
        Me.GroupBox1.Controls.Add(Me.txtNewPriceListID)
        Me.GroupBox1.Controls.Add(Me.lblNewPriceListID)
        Me.GroupBox1.Controls.Add(Me.lblOldPriceListID)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(464, 156)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(408, 133)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(21, 13)
        Me.lbl1.TabIndex = 12
        Me.lbl1.Text = "(%)"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValue2
        '
        Me.txtValue2.Enabled = False
        Me.txtValue2.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtValue2.Location = New System.Drawing.Point(271, 126)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(131, 22)
        Me.txtValue2.TabIndex = 8
        Me.txtValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValue1
        '
        Me.txtValue1.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtValue1.Location = New System.Drawing.Point(271, 94)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(131, 22)
        Me.txtValue1.TabIndex = 5
        Me.txtValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboSign2
        '
        Me.cboSign2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSign2.Enabled = False
        Me.cboSign2.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboSign2.FormattingEnabled = True
        Me.cboSign2.Items.AddRange(New Object() {"+", "-"})
        Me.cboSign2.Location = New System.Drawing.Point(216, 126)
        Me.cboSign2.Name = "cboSign2"
        Me.cboSign2.Size = New System.Drawing.Size(49, 22)
        Me.cboSign2.TabIndex = 7
        '
        'cboSign1
        '
        Me.cboSign1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSign1.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboSign1.FormattingEnabled = True
        Me.cboSign1.Items.AddRange(New Object() {"+", "-"})
        Me.cboSign1.Location = New System.Drawing.Point(216, 94)
        Me.cboSign1.Name = "cboSign1"
        Me.cboSign1.Size = New System.Drawing.Size(49, 22)
        Me.cboSign1.TabIndex = 4
        '
        'optPercent
        '
        Me.optPercent.AutoSize = True
        Me.optPercent.Location = New System.Drawing.Point(44, 131)
        Me.optPercent.Name = "optPercent"
        Me.optPercent.Size = New System.Drawing.Size(122, 17)
        Me.optPercent.TabIndex = 6
        Me.optPercent.Text = "Theo tỷ lệ phần trăm"
        Me.optPercent.UseVisualStyleBackColor = True
        '
        'optValue
        '
        Me.optValue.AutoSize = True
        Me.optValue.Checked = True
        Me.optValue.Location = New System.Drawing.Point(44, 99)
        Me.optValue.Name = "optValue"
        Me.optValue.Size = New System.Drawing.Size(122, 17)
        Me.optValue.TabIndex = 3
        Me.optValue.TabStop = True
        Me.optValue.Text = "Theo giá trị tuyệt đối"
        Me.optValue.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(129, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(326, 3)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'lblMethod
        '
        Me.lblMethod.AutoSize = True
        Me.lblMethod.Location = New System.Drawing.Point(8, 75)
        Me.lblMethod.Name = "lblMethod"
        Me.lblMethod.Size = New System.Drawing.Size(107, 13)
        Me.lblMethod.TabIndex = 4
        Me.lblMethod.Text = "Phương thức kế thừa"
        Me.lblMethod.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOldPriceListID
        '
        Me.txtOldPriceListID.Enabled = False
        Me.txtOldPriceListID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtOldPriceListID.Location = New System.Drawing.Point(216, 41)
        Me.txtOldPriceListID.Name = "txtOldPriceListID"
        Me.txtOldPriceListID.Size = New System.Drawing.Size(186, 22)
        Me.txtOldPriceListID.TabIndex = 2
        '
        'txtNewPriceListID
        '
        Me.txtNewPriceListID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNewPriceListID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtNewPriceListID.Location = New System.Drawing.Point(216, 13)
        Me.txtNewPriceListID.MaxLength = 20
        Me.txtNewPriceListID.Name = "txtNewPriceListID"
        Me.txtNewPriceListID.Size = New System.Drawing.Size(186, 22)
        Me.txtNewPriceListID.TabIndex = 0
        '
        'lblNewPriceListID
        '
        Me.lblNewPriceListID.AutoSize = True
        Me.lblNewPriceListID.Location = New System.Drawing.Point(41, 18)
        Me.lblNewPriceListID.Name = "lblNewPriceListID"
        Me.lblNewPriceListID.Size = New System.Drawing.Size(85, 13)
        Me.lblNewPriceListID.TabIndex = 1
        Me.lblNewPriceListID.Text = "Mã bảng giá mới"
        Me.lblNewPriceListID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOldPriceListID
        '
        Me.lblOldPriceListID.AutoSize = True
        Me.lblOldPriceListID.Location = New System.Drawing.Point(41, 45)
        Me.lblOldPriceListID.Name = "lblOldPriceListID"
        Me.lblOldPriceListID.Size = New System.Drawing.Size(108, 13)
        Me.lblOldPriceListID.TabIndex = 3
        Me.lblOldPriceListID.Text = "Mã bảng  giá kế thừa"
        Me.lblOldPriceListID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(392, 168)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(310, 168)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'D45F1025
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 196)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1025"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa b¶ng giÀ - D45F1025"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents lblMethod As System.Windows.Forms.Label
    Private WithEvents txtOldPriceListID As System.Windows.Forms.TextBox
    Private WithEvents txtNewPriceListID As System.Windows.Forms.TextBox
    Private WithEvents lblNewPriceListID As System.Windows.Forms.Label
    Private WithEvents lblOldPriceListID As System.Windows.Forms.Label
    Private WithEvents cboSign2 As System.Windows.Forms.ComboBox
    Private WithEvents cboSign1 As System.Windows.Forms.ComboBox
    Private WithEvents optPercent As System.Windows.Forms.RadioButton
    Private WithEvents optValue As System.Windows.Forms.RadioButton
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents txtValue2 As System.Windows.Forms.TextBox
    Private WithEvents txtValue1 As System.Windows.Forms.TextBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
