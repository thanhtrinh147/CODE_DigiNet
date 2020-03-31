<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectTransactionType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectTransactionType))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnClose = New System.Windows.Forms.Button
        Me.tdbcTransTypeID = New C1.Win.C1List.C1Combo
        Me.lblTransTypeID = New System.Windows.Forms.Label
        Me.txtTransTypeName = New System.Windows.Forms.TextBox
        Me.btnNext = New System.Windows.Forms.Button
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(428, 77)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbcTransTypeID
        '
        Me.tdbcTransTypeID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcTransTypeID.AllowColMove = False
        Me.tdbcTransTypeID.AllowSort = False
        Me.tdbcTransTypeID.AlternatingRows = True
        Me.tdbcTransTypeID.AutoCompletion = True
        Me.tdbcTransTypeID.AutoDropDown = True
        Me.tdbcTransTypeID.Caption = ""
        Me.tdbcTransTypeID.CaptionHeight = 17
        Me.tdbcTransTypeID.CaptionStyle = Style1
        Me.tdbcTransTypeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcTransTypeID.ColumnCaptionHeight = 17
        Me.tdbcTransTypeID.ColumnFooterHeight = 17
        Me.tdbcTransTypeID.ColumnWidth = 100
        Me.tdbcTransTypeID.ContentHeight = 17
        Me.tdbcTransTypeID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcTransTypeID.DisplayMember = "TransTypeID"
        Me.tdbcTransTypeID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcTransTypeID.DropDownWidth = 300
        Me.tdbcTransTypeID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcTransTypeID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcTransTypeID.EditorHeight = 17
        Me.tdbcTransTypeID.EmptyRows = True
        Me.tdbcTransTypeID.EvenRowStyle = Style2
        Me.tdbcTransTypeID.ExtendRightColumn = True
        Me.tdbcTransTypeID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcTransTypeID.FooterStyle = Style3
        Me.tdbcTransTypeID.HeadingStyle = Style4
        Me.tdbcTransTypeID.HighLightRowStyle = Style5
        Me.tdbcTransTypeID.Images.Add(CType(resources.GetObject("tdbcTransTypeID.Images"), System.Drawing.Image))
        Me.tdbcTransTypeID.ItemHeight = 15
        Me.tdbcTransTypeID.Location = New System.Drawing.Point(116, 22)
        Me.tdbcTransTypeID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcTransTypeID.MaxDropDownItems = CType(8, Short)
        Me.tdbcTransTypeID.MaxLength = 32767
        Me.tdbcTransTypeID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcTransTypeID.Name = "tdbcTransTypeID"
        Me.tdbcTransTypeID.OddRowStyle = Style6
        Me.tdbcTransTypeID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcTransTypeID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcTransTypeID.SelectedStyle = Style7
        Me.tdbcTransTypeID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcTransTypeID.Style = Style8
        Me.tdbcTransTypeID.TabIndex = 1
        Me.tdbcTransTypeID.ValueMember = "TransTypeID"
        Me.tdbcTransTypeID.PropBag = resources.GetString("tdbcTransTypeID.PropBag")
        '
        'lblTransTypeID
        '
        Me.lblTransTypeID.AutoSize = True
        Me.lblTransTypeID.Location = New System.Drawing.Point(14, 27)
        Me.lblTransTypeID.Name = "lblTransTypeID"
        Me.lblTransTypeID.Size = New System.Drawing.Size(77, 13)
        Me.lblTransTypeID.TabIndex = 0
        Me.lblTransTypeID.Text = "Loại nghiệp vụ"
        Me.lblTransTypeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTransTypeName
        '
        Me.txtTransTypeName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtTransTypeName.Location = New System.Drawing.Point(249, 22)
        Me.txtTransTypeName.Name = "txtTransTypeName"
        Me.txtTransTypeName.ReadOnly = True
        Me.txtTransTypeName.Size = New System.Drawing.Size(253, 22)
        Me.txtTransTypeName.TabIndex = 2
        Me.txtTransTypeName.TabStop = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(346, 77)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 3
        Me.btnNext.Text = "&Tiếp tục"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'SelectTransactionType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 111)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.tdbcTransTypeID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblTransTypeID)
        Me.Controls.Add(Me.txtTransTypeName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectTransactionType"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn loÁi nghi£p vó  HS ÷ng cõ vi£n"
        CType(Me.tdbcTransTypeID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbcTransTypeID As C1.Win.C1List.C1Combo
    Private WithEvents lblTransTypeID As System.Windows.Forms.Label
    Private WithEvents txtTransTypeName As System.Windows.Forms.TextBox
    Private WithEvents btnNext As System.Windows.Forms.Button

End Class
