<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrameUpdateSalary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrameUpdateSalary))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.grp1 = New System.Windows.Forms.GroupBox
        Me.tdbcPayrollVoucherID = New C1.Win.C1List.C1Combo
        Me.lblPayrollVoucherID = New System.Windows.Forms.Label
        Me.txtPayrollVoucherName = New System.Windows.Forms.TextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.grp1.SuspendLayout()
        CType(Me.tdbcPayrollVoucherID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grp1
        '
        Me.grp1.Controls.Add(Me.tdbcPayrollVoucherID)
        Me.grp1.Controls.Add(Me.lblPayrollVoucherID)
        Me.grp1.Controls.Add(Me.txtPayrollVoucherName)
        Me.grp1.Location = New System.Drawing.Point(7, 2)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(553, 47)
        Me.grp1.TabIndex = 0
        Me.grp1.TabStop = False
        '
        'tdbcPayrollVoucherID
        '
        Me.tdbcPayrollVoucherID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPayrollVoucherID.AllowColMove = False
        Me.tdbcPayrollVoucherID.AllowSort = False
        Me.tdbcPayrollVoucherID.AlternatingRows = True
        Me.tdbcPayrollVoucherID.AutoCompletion = True
        Me.tdbcPayrollVoucherID.AutoDropDown = True
        Me.tdbcPayrollVoucherID.Caption = ""
        Me.tdbcPayrollVoucherID.CaptionHeight = 17
        Me.tdbcPayrollVoucherID.CaptionStyle = Style1
        Me.tdbcPayrollVoucherID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPayrollVoucherID.ColumnCaptionHeight = 17
        Me.tdbcPayrollVoucherID.ColumnFooterHeight = 17
        Me.tdbcPayrollVoucherID.ContentHeight = 17
        Me.tdbcPayrollVoucherID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPayrollVoucherID.DisplayMember = "PayrollVoucherNo"
        Me.tdbcPayrollVoucherID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPayrollVoucherID.DropDownWidth = 350
        Me.tdbcPayrollVoucherID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPayrollVoucherID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPayrollVoucherID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPayrollVoucherID.EditorHeight = 17
        Me.tdbcPayrollVoucherID.EmptyRows = True
        Me.tdbcPayrollVoucherID.EvenRowStyle = Style2
        Me.tdbcPayrollVoucherID.ExtendRightColumn = True
        Me.tdbcPayrollVoucherID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcPayrollVoucherID.FooterStyle = Style3
        Me.tdbcPayrollVoucherID.HeadingStyle = Style4
        Me.tdbcPayrollVoucherID.HighLightRowStyle = Style5
        Me.tdbcPayrollVoucherID.Images.Add(CType(resources.GetObject("tdbcPayrollVoucherID.Images"), System.Drawing.Image))
        Me.tdbcPayrollVoucherID.ItemHeight = 15
        Me.tdbcPayrollVoucherID.Location = New System.Drawing.Point(98, 16)
        Me.tdbcPayrollVoucherID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPayrollVoucherID.MaxDropDownItems = CType(8, Short)
        Me.tdbcPayrollVoucherID.MaxLength = 32767
        Me.tdbcPayrollVoucherID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPayrollVoucherID.Name = "tdbcPayrollVoucherID"
        Me.tdbcPayrollVoucherID.OddRowStyle = Style6
        Me.tdbcPayrollVoucherID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPayrollVoucherID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPayrollVoucherID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPayrollVoucherID.SelectedStyle = Style7
        Me.tdbcPayrollVoucherID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcPayrollVoucherID.Style = Style8
        Me.tdbcPayrollVoucherID.TabIndex = 0
        Me.tdbcPayrollVoucherID.ValueMember = "PayrollVoucherID"
        Me.tdbcPayrollVoucherID.PropBag = resources.GetString("tdbcPayrollVoucherID.PropBag")
        '
        'lblPayrollVoucherID
        '
        Me.lblPayrollVoucherID.AutoSize = True
        Me.lblPayrollVoucherID.Location = New System.Drawing.Point(13, 21)
        Me.lblPayrollVoucherID.Name = "lblPayrollVoucherID"
        Me.lblPayrollVoucherID.Size = New System.Drawing.Size(64, 13)
        Me.lblPayrollVoucherID.TabIndex = 1
        Me.lblPayrollVoucherID.Text = "Hồ sơ lương"
        Me.lblPayrollVoucherID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPayrollVoucherName
        '
        Me.txtPayrollVoucherName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtPayrollVoucherName.Location = New System.Drawing.Point(231, 16)
        Me.txtPayrollVoucherName.Name = "txtPayrollVoucherName"
        Me.txtPayrollVoucherName.ReadOnly = True
        Me.txtPayrollVoucherName.Size = New System.Drawing.Size(316, 22)
        Me.txtPayrollVoucherName.TabIndex = 2
        Me.txtPayrollVoucherName.TabStop = False
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(484, 57)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(402, 57)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FrameUpdateSalary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 86)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grp1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrameUpdateSalary"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt hä s¥ l§¥ng thÀng"
        Me.grp1.ResumeLayout(False)
        Me.grp1.PerformLayout()
        CType(Me.tdbcPayrollVoucherID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbcPayrollVoucherID As C1.Win.C1List.C1Combo
    Private WithEvents lblPayrollVoucherID As System.Windows.Forms.Label
    Private WithEvents txtPayrollVoucherName As System.Windows.Forms.TextBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
End Class
