<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2053
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2053))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.tdbcSalCalMethodID = New C1.Win.C1List.C1Combo
        Me.lblSalCalMethodID = New System.Windows.Forms.Label
        Me.txtSalCalMethodName = New System.Windows.Forms.TextBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grp1.SuspendLayout()
        CType(Me.tdbcSalCalMethodID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbcSalCalMethodID)
        Me.grp1.Controls.Add(Me.lblSalCalMethodID)
        Me.grp1.Controls.Add(Me.txtSalCalMethodName)
        Me.grp1.Location = New System.Drawing.Point(4, 0)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(463, 56)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'tdbcSalCalMethodID
        '
        Me.tdbcSalCalMethodID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcSalCalMethodID.AllowColMove = False
        Me.tdbcSalCalMethodID.AllowSort = False
        Me.tdbcSalCalMethodID.AlternatingRows = True
        Me.tdbcSalCalMethodID.AutoCompletion = True
        Me.tdbcSalCalMethodID.AutoDropDown = True
        Me.tdbcSalCalMethodID.Caption = ""
        Me.tdbcSalCalMethodID.CaptionHeight = 17
        Me.tdbcSalCalMethodID.CaptionStyle = Style1
        Me.tdbcSalCalMethodID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcSalCalMethodID.ColumnCaptionHeight = 17
        Me.tdbcSalCalMethodID.ColumnFooterHeight = 17
        Me.tdbcSalCalMethodID.ColumnWidth = 100
        Me.tdbcSalCalMethodID.ContentHeight = 17
        Me.tdbcSalCalMethodID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcSalCalMethodID.DisplayMember = "SalCalMethodID"
        Me.tdbcSalCalMethodID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcSalCalMethodID.DropDownWidth = 300
        Me.tdbcSalCalMethodID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcSalCalMethodID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcSalCalMethodID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcSalCalMethodID.EditorHeight = 17
        Me.tdbcSalCalMethodID.EmptyRows = True
        Me.tdbcSalCalMethodID.EvenRowStyle = Style2
        Me.tdbcSalCalMethodID.ExtendRightColumn = True
        Me.tdbcSalCalMethodID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcSalCalMethodID.FooterStyle = Style3
        Me.tdbcSalCalMethodID.HeadingStyle = Style4
        Me.tdbcSalCalMethodID.HighLightRowStyle = Style5
        Me.tdbcSalCalMethodID.Images.Add(CType(resources.GetObject("tdbcSalCalMethodID.Images"), System.Drawing.Image))
        Me.tdbcSalCalMethodID.ItemHeight = 15
        Me.tdbcSalCalMethodID.Location = New System.Drawing.Point(98, 20)
        Me.tdbcSalCalMethodID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcSalCalMethodID.MaxDropDownItems = CType(8, Short)
        Me.tdbcSalCalMethodID.MaxLength = 32767
        Me.tdbcSalCalMethodID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcSalCalMethodID.Name = "tdbcSalCalMethodID"
        Me.tdbcSalCalMethodID.OddRowStyle = Style6
        Me.tdbcSalCalMethodID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcSalCalMethodID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcSalCalMethodID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcSalCalMethodID.SelectedStyle = Style7
        Me.tdbcSalCalMethodID.Size = New System.Drawing.Size(122, 23)
        Me.tdbcSalCalMethodID.Style = Style8
        Me.tdbcSalCalMethodID.TabIndex = 0
        Me.tdbcSalCalMethodID.ValueMember = "SalCalMethodID"
        Me.tdbcSalCalMethodID.PropBag = resources.GetString("tdbcSalCalMethodID.PropBag")
        '
        'lblSalCalMethodID
        '
        Me.lblSalCalMethodID.AutoSize = True
        Me.lblSalCalMethodID.Location = New System.Drawing.Point(6, 24)
        Me.lblSalCalMethodID.Name = "lblSalCalMethodID"
        Me.lblSalCalMethodID.Size = New System.Drawing.Size(60, 13)
        Me.lblSalCalMethodID.TabIndex = 1
        Me.lblSalCalMethodID.Text = "PP kế thừa"
        Me.lblSalCalMethodID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSalCalMethodName
        '
        Me.txtSalCalMethodName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtSalCalMethodName.Location = New System.Drawing.Point(226, 20)
        Me.txtSalCalMethodName.Name = "txtSalCalMethodName"
        Me.txtSalCalMethodName.ReadOnly = True
        Me.txtSalCalMethodName.Size = New System.Drawing.Size(230, 22)
        Me.txtSalCalMethodName.TabIndex = 1
        Me.txtSalCalMethodName.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(311, 63)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(391, 63)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D13F2053
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 91)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(20, 20)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2053"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "KÕ thôa ph§¥ng phÀp tÛnh l§¥ng - D13F2053"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcSalCalMethodID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcSalCalMethodID As C1.Win.C1List.C1Combo
    Private WithEvents lblSalCalMethodID As System.Windows.Forms.Label
    Private WithEvents txtSalCalMethodName As System.Windows.Forms.TextBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
