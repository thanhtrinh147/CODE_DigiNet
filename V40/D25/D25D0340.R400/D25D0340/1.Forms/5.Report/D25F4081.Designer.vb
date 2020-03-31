<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F4081
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F4081))
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.tdbcTypeID = New C1.Win.C1List.C1Combo()
        Me.lblTypeID = New System.Windows.Forms.Label()
        Me.txtSubject = New System.Windows.Forms.TextBox()
        Me.lblSubject = New System.Windows.Forms.Label()
        Me.txtEmailContent = New System.Windows.Forms.TextBox()
        Me.lblEmailContent = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnInfoCandidate = New System.Windows.Forms.Button()
        Me.btnChoose = New System.Windows.Forms.Button()
        CType(Me.tdbcTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbcTypeID
        '
        Me.tdbcTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTypeID.AllowColMove = False
        Me.tdbcTypeID.AllowSort = False
        Me.tdbcTypeID.AlternatingRows = True
        Me.tdbcTypeID.AutoCompletion = True
        Me.tdbcTypeID.AutoDropDown = True
        Me.tdbcTypeID.Caption = ""
        Me.tdbcTypeID.CaptionHeight = 17
        Me.tdbcTypeID.CaptionStyle = Style9
        Me.tdbcTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTypeID.ColumnCaptionHeight = 17
        Me.tdbcTypeID.ColumnFooterHeight = 17
        Me.tdbcTypeID.ColumnHeaders = False
        Me.tdbcTypeID.ColumnWidth = 100
        Me.tdbcTypeID.ContentHeight = 17
        Me.tdbcTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTypeID.DisplayMember = "TypeName"
        Me.tdbcTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTypeID.DropDownWidth = 350
        Me.tdbcTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTypeID.EditorHeight = 17
        Me.tdbcTypeID.EmptyRows = True
        Me.tdbcTypeID.EvenRowStyle = Style10
        Me.tdbcTypeID.ExtendRightColumn = True
        Me.tdbcTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTypeID.FooterStyle = Style11
        Me.tdbcTypeID.HeadingStyle = Style12
        Me.tdbcTypeID.HighLightRowStyle = Style13
        Me.tdbcTypeID.Images.Add(CType(resources.GetObject("tdbcTypeID.Images"), System.Drawing.Image))
        Me.tdbcTypeID.ItemHeight = 15
        Me.tdbcTypeID.Location = New System.Drawing.Point(147, 12)
        Me.tdbcTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTypeID.MaxLength = 32767
        Me.tdbcTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTypeID.Name = "tdbcTypeID"
        Me.tdbcTypeID.OddRowStyle = Style14
        Me.tdbcTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTypeID.SelectedStyle = Style15
        Me.tdbcTypeID.Size = New System.Drawing.Size(241, 23)
        Me.tdbcTypeID.Style = Style16
        Me.tdbcTypeID.TabIndex = 0
        Me.tdbcTypeID.ValueMember = "TypeID"
        Me.tdbcTypeID.PropBag = resources.GetString("tdbcTypeID.PropBag")
        '
        'lblTypeID
        '
        Me.lblTypeID.AutoSize = True
        Me.lblTypeID.Location = New System.Drawing.Point(13, 16)
        Me.lblTypeID.Name = "lblTypeID"
        Me.lblTypeID.Size = New System.Drawing.Size(114, 13)
        Me.lblTypeID.TabIndex = 0
        Me.lblTypeID.Text = "Kết quả PV/Trạng thái"
        Me.lblTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSubject
        '
        Me.txtSubject.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSubject.Location = New System.Drawing.Point(147, 45)
        Me.txtSubject.MaxLength = 500
        Me.txtSubject.Name = "txtSubject"
        Me.txtSubject.Size = New System.Drawing.Size(427, 22)
        Me.txtSubject.TabIndex = 1
        '
        'lblSubject
        '
        Me.lblSubject.AutoSize = True
        Me.lblSubject.Location = New System.Drawing.Point(12, 50)
        Me.lblSubject.Name = "lblSubject"
        Me.lblSubject.Size = New System.Drawing.Size(44, 13)
        Me.lblSubject.TabIndex = 2
        Me.lblSubject.Text = "Tiêu đề"
        Me.lblSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmailContent
        '
        Me.txtEmailContent.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtEmailContent.Location = New System.Drawing.Point(147, 82)
        Me.txtEmailContent.MaxLength = 8000
        Me.txtEmailContent.Multiline = True
        Me.txtEmailContent.Name = "txtEmailContent"
        Me.txtEmailContent.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtEmailContent.Size = New System.Drawing.Size(427, 193)
        Me.txtEmailContent.TabIndex = 2
        '
        'lblEmailContent
        '
        Me.lblEmailContent.AutoSize = True
        Me.lblEmailContent.Location = New System.Drawing.Point(12, 86)
        Me.lblEmailContent.Name = "lblEmailContent"
        Me.lblEmailContent.Size = New System.Drawing.Size(50, 13)
        Me.lblEmailContent.TabIndex = 4
        Me.lblEmailContent.Text = "Nội dung"
        Me.lblEmailContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(498, 284)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(416, 284)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Lưu"
        '
        'btnInfoCandidate
        '
        Me.btnInfoCandidate.Location = New System.Drawing.Point(12, 284)
        Me.btnInfoCandidate.Name = "btnInfoCandidate"
        Me.btnInfoCandidate.Size = New System.Drawing.Size(132, 22)
        Me.btnInfoCandidate.TabIndex = 3
        Me.btnInfoCandidate.Text = "&Thông tin ứng viên"
        Me.btnInfoCandidate.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(147, 284)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(76, 22)
        Me.btnChoose.TabIndex = 4
        Me.btnChoose.Text = "Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'D25F4081
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 312)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.btnInfoCandidate)
        Me.Controls.Add(Me.txtEmailContent)
        Me.Controls.Add(Me.txtSubject)
        Me.Controls.Add(Me.tdbcTypeID)
        Me.Controls.Add(Me.lblTypeID)
        Me.Controls.Add(Me.lblSubject)
        Me.Controls.Add(Me.lblEmailContent)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F4081"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ThiÕt lËp nèi dung mail - D25F4081"
        CType(Me.tdbcTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTypeID As System.Windows.Forms.Label
    Private WithEvents txtSubject As System.Windows.Forms.TextBox
    Private WithEvents lblSubject As System.Windows.Forms.Label
    Private WithEvents txtEmailContent As System.Windows.Forms.TextBox
    Private WithEvents lblEmailContent As System.Windows.Forms.Label
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnInfoCandidate As System.Windows.Forms.Button
    Private WithEvents btnChoose As System.Windows.Forms.Button
End Class
