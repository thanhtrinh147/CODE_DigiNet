<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F1055
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F1055))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.txtFullName = New System.Windows.Forms.TextBox
        Me.tdbcEmployeeID = New C1.Win.C1List.C1Combo
        Me.lblEmployeeID = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnOk = New System.Windows.Forms.Button
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(539, 68)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtFullName.Location = New System.Drawing.Point(233, 19)
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(360, 22)
        Me.txtFullName.TabIndex = 2
        Me.txtFullName.TabStop = False
        '
        'tdbcEmployeeID
        '
        Me.tdbcEmployeeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcEmployeeID.AllowColMove = False
        Me.tdbcEmployeeID.AllowSort = False
        Me.tdbcEmployeeID.AlternatingRows = True
        Me.tdbcEmployeeID.AutoCompletion = True
        Me.tdbcEmployeeID.AutoDropDown = True
        Me.tdbcEmployeeID.Caption = ""
        Me.tdbcEmployeeID.CaptionHeight = 17
        Me.tdbcEmployeeID.CaptionStyle = Style1
        Me.tdbcEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcEmployeeID.ColumnCaptionHeight = 17
        Me.tdbcEmployeeID.ColumnFooterHeight = 17
        Me.tdbcEmployeeID.ColumnWidth = 100
        Me.tdbcEmployeeID.ContentHeight = 17
        Me.tdbcEmployeeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcEmployeeID.DisplayMember = "EmployeeID"
        Me.tdbcEmployeeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcEmployeeID.DropDownWidth = 350
        Me.tdbcEmployeeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcEmployeeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcEmployeeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcEmployeeID.EditorHeight = 17
        Me.tdbcEmployeeID.EmptyRows = True
        Me.tdbcEmployeeID.EvenRowStyle = Style2
        Me.tdbcEmployeeID.ExtendRightColumn = True
        Me.tdbcEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcEmployeeID.FooterStyle = Style3
        Me.tdbcEmployeeID.HeadingStyle = Style4
        Me.tdbcEmployeeID.HighLightRowStyle = Style5
        Me.tdbcEmployeeID.Images.Add(CType(resources.GetObject("tdbcEmployeeID.Images"), System.Drawing.Image))
        Me.tdbcEmployeeID.ItemHeight = 15
        Me.tdbcEmployeeID.Location = New System.Drawing.Point(99, 19)
        Me.tdbcEmployeeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcEmployeeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcEmployeeID.MaxLength = 32767
        Me.tdbcEmployeeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcEmployeeID.Name = "tdbcEmployeeID"
        Me.tdbcEmployeeID.OddRowStyle = Style6
        Me.tdbcEmployeeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcEmployeeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcEmployeeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcEmployeeID.SelectedStyle = Style7
        Me.tdbcEmployeeID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcEmployeeID.Style = Style8
        Me.tdbcEmployeeID.TabIndex = 1
        Me.tdbcEmployeeID.ValueMember = "EmployeeID"
        Me.tdbcEmployeeID.PropBag = resources.GetString("tdbcEmployeeID.PropBag")
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeID.Location = New System.Drawing.Point(10, 24)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(56, 13)
        Me.lblEmployeeID.TabIndex = 0
        Me.lblEmployeeID.Text = "Nhân viên"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtFullName)
        Me.GroupBox1.Controls.Add(Me.lblEmployeeID)
        Me.GroupBox1.Controls.Add(Me.tdbcEmployeeID)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(603, 57)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(447, 68)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 22)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Chấp nhận"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'D25F1055
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 97)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F1055"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa nh¡n vi£n nghÙ viÖc - D25F1055"
        CType(Me.tdbcEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents txtFullName As System.Windows.Forms.TextBox
    Private WithEvents tdbcEmployeeID As C1.Win.C1List.C1Combo
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents btnOk As System.Windows.Forms.Button

End Class
