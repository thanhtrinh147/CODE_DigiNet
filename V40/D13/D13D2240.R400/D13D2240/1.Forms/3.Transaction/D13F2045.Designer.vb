<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F2045
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F2045))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbcBankID = New C1.Win.C1List.C1Combo
        Me.lblBankID = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnUpdate = New System.Windows.Forms.Button
        Me.txtEmployeeID = New System.Windows.Forms.TextBox
        Me.lblEmployeeID = New System.Windows.Forms.Label
        Me.txtBankAccountNo = New System.Windows.Forms.TextBox
        Me.lblBankAccountNo = New System.Windows.Forms.Label
        CType(Me.tdbcBankID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbcBankID
        '
        Me.tdbcBankID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcBankID.AllowColMove = False
        Me.tdbcBankID.AllowSort = False
        Me.tdbcBankID.AlternatingRows = True
        Me.tdbcBankID.AutoDropDown = True
        Me.tdbcBankID.Caption = ""
        Me.tdbcBankID.CaptionHeight = 17
        Me.tdbcBankID.CaptionStyle = Style1
        Me.tdbcBankID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcBankID.ColumnCaptionHeight = 17
        Me.tdbcBankID.ColumnFooterHeight = 17
        Me.tdbcBankID.ColumnWidth = 100
        Me.tdbcBankID.ContentHeight = 17
        Me.tdbcBankID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcBankID.DisplayMember = "BankName"
        Me.tdbcBankID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcBankID.DropDownWidth = 399
        Me.tdbcBankID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcBankID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcBankID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcBankID.EditorHeight = 17
        Me.tdbcBankID.EmptyRows = True
        Me.tdbcBankID.EvenRowStyle = Style2
        Me.tdbcBankID.ExtendRightColumn = True
        Me.tdbcBankID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcBankID.FooterStyle = Style3
        Me.tdbcBankID.HeadingStyle = Style4
        Me.tdbcBankID.HighLightRowStyle = Style5
        Me.tdbcBankID.Images.Add(CType(resources.GetObject("tdbcBankID.Images"), System.Drawing.Image))
        Me.tdbcBankID.ItemHeight = 15
        Me.tdbcBankID.Location = New System.Drawing.Point(102, 40)
        Me.tdbcBankID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcBankID.MaxDropDownItems = CType(8, Short)
        Me.tdbcBankID.MaxLength = 32767
        Me.tdbcBankID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcBankID.Name = "tdbcBankID"
        Me.tdbcBankID.OddRowStyle = Style6
        Me.tdbcBankID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcBankID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcBankID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcBankID.SelectedStyle = Style7
        Me.tdbcBankID.Size = New System.Drawing.Size(405, 23)
        Me.tdbcBankID.Style = Style8
        Me.tdbcBankID.TabIndex = 1
        Me.tdbcBankID.ValueMember = "BankID"
        Me.tdbcBankID.PropBag = resources.GetString("tdbcBankID.PropBag")
        '
        'lblBankID
        '
        Me.lblBankID.AutoSize = True
        Me.lblBankID.Location = New System.Drawing.Point(13, 45)
        Me.lblBankID.Name = "lblBankID"
        Me.lblBankID.Size = New System.Drawing.Size(60, 13)
        Me.lblBankID.TabIndex = 0
        Me.lblBankID.Text = "Ngân hàng"
        Me.lblBankID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(431, 100)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(349, 100)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(76, 22)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "&Cập nhật"
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(102, 11)
        Me.txtEmployeeID.MaxLength = 50
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(244, 22)
        Me.txtEmployeeID.TabIndex = 4
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(13, 15)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(22, 13)
        Me.lblEmployeeID.TabIndex = 5
        Me.lblEmployeeID.Text = "Mã"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtBankAccountNo
        '
        Me.txtBankAccountNo.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtBankAccountNo.Location = New System.Drawing.Point(102, 70)
        Me.txtBankAccountNo.Name = "txtBankAccountNo"
        Me.txtBankAccountNo.Size = New System.Drawing.Size(244, 22)
        Me.txtBankAccountNo.TabIndex = 6
        '
        'lblBankAccountNo
        '
        Me.lblBankAccountNo.AutoSize = True
        Me.lblBankAccountNo.Location = New System.Drawing.Point(13, 74)
        Me.lblBankAccountNo.Name = "lblBankAccountNo"
        Me.lblBankAccountNo.Size = New System.Drawing.Size(67, 13)
        Me.lblBankAccountNo.TabIndex = 7
        Me.lblBankAccountNo.Text = "Số tài khoản"
        Me.lblBankAccountNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'D13F2045
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 127)
        Me.Controls.Add(Me.txtBankAccountNo)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.tdbcBankID)
        Me.Controls.Add(Me.lblBankID)
        Me.Controls.Add(Me.lblEmployeeID)
        Me.Controls.Add(Me.lblBankAccountNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F2045"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt ng¡n hªng chuyÓn kho¶n - D13F2045"
        CType(Me.tdbcBankID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcBankID As C1.Win.C1List.C1Combo
    Private WithEvents lblBankID As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnUpdate As System.Windows.Forms.Button
    Private WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Private WithEvents txtBankAccountNo As System.Windows.Forms.TextBox
    Private WithEvents lblBankAccountNo As System.Windows.Forms.Label
End Class
