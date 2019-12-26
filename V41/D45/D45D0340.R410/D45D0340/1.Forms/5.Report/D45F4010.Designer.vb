<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F4010
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F4010))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpReport = New System.Windows.Forms.GroupBox
        Me.tdbcStageID = New C1.Win.C1List.C1Combo
        Me.tdbcProductID = New C1.Win.C1List.C1Combo
        Me.tdbcPriceListID = New C1.Win.C1List.C1Combo
        Me.lblPriceListID = New System.Windows.Forms.Label
        Me.txtPriceListName = New System.Windows.Forms.TextBox
        Me.lblProductID = New System.Windows.Forms.Label
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.lblStageID = New System.Windows.Forms.Label
        Me.txtStageName = New System.Windows.Forms.TextBox
        Me.grpReport.SuspendLayout()
        CType(Me.tdbcStageID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcPriceListID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(269, 110)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(76, 22)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&In"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(351, 110)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpReport
        '
        Me.grpReport.Controls.Add(Me.tdbcStageID)
        Me.grpReport.Controls.Add(Me.tdbcProductID)
        Me.grpReport.Controls.Add(Me.tdbcPriceListID)
        Me.grpReport.Controls.Add(Me.lblPriceListID)
        Me.grpReport.Controls.Add(Me.txtPriceListName)
        Me.grpReport.Controls.Add(Me.lblProductID)
        Me.grpReport.Controls.Add(Me.txtProductName)
        Me.grpReport.Controls.Add(Me.lblStageID)
        Me.grpReport.Controls.Add(Me.txtStageName)
        Me.grpReport.Location = New System.Drawing.Point(8, 2)
        Me.grpReport.Name = "grpReport"
        Me.grpReport.Size = New System.Drawing.Size(419, 102)
        Me.grpReport.TabIndex = 0
        Me.grpReport.TabStop = False
        '
        'tdbcStageID
        '
        Me.tdbcStageID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcStageID.AllowColMove = False
        Me.tdbcStageID.AllowSort = False
        Me.tdbcStageID.AlternatingRows = True
        Me.tdbcStageID.AutoCompletion = True
        Me.tdbcStageID.AutoDropDown = True
        Me.tdbcStageID.Caption = ""
        Me.tdbcStageID.CaptionHeight = 17
        Me.tdbcStageID.CaptionStyle = Style1
        Me.tdbcStageID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcStageID.ColumnCaptionHeight = 17
        Me.tdbcStageID.ColumnFooterHeight = 17
        Me.tdbcStageID.ColumnWidth = 100
        Me.tdbcStageID.ContentHeight = 17
        Me.tdbcStageID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcStageID.DisplayMember = "StageID"
        Me.tdbcStageID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcStageID.DropDownWidth = 300
        Me.tdbcStageID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcStageID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcStageID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcStageID.EditorHeight = 17
        Me.tdbcStageID.EmptyRows = True
        Me.tdbcStageID.EvenRowStyle = Style2
        Me.tdbcStageID.ExtendRightColumn = True
        Me.tdbcStageID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcStageID.FooterStyle = Style3
        Me.tdbcStageID.HeadingStyle = Style4
        Me.tdbcStageID.HighLightRowStyle = Style5
        Me.tdbcStageID.Images.Add(CType(resources.GetObject("tdbcStageID.Images"), System.Drawing.Image))
        Me.tdbcStageID.ItemHeight = 15
        Me.tdbcStageID.Location = New System.Drawing.Point(93, 72)
        Me.tdbcStageID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcStageID.MaxDropDownItems = CType(8, Short)
        Me.tdbcStageID.MaxLength = 32767
        Me.tdbcStageID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcStageID.Name = "tdbcStageID"
        Me.tdbcStageID.OddRowStyle = Style6
        Me.tdbcStageID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcStageID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcStageID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcStageID.SelectedStyle = Style7
        Me.tdbcStageID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcStageID.Style = Style8
        Me.tdbcStageID.TabIndex = 2
        Me.tdbcStageID.ValueMember = "StageID"
        Me.tdbcStageID.PropBag = resources.GetString("tdbcStageID.PropBag")
        '
        'tdbcProductID
        '
        Me.tdbcProductID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcProductID.AllowColMove = False
        Me.tdbcProductID.AllowSort = False
        Me.tdbcProductID.AlternatingRows = True
        Me.tdbcProductID.AutoCompletion = True
        Me.tdbcProductID.AutoDropDown = True
        Me.tdbcProductID.Caption = ""
        Me.tdbcProductID.CaptionHeight = 17
        Me.tdbcProductID.CaptionStyle = Style9
        Me.tdbcProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcProductID.ColumnCaptionHeight = 17
        Me.tdbcProductID.ColumnFooterHeight = 17
        Me.tdbcProductID.ColumnWidth = 100
        Me.tdbcProductID.ContentHeight = 17
        Me.tdbcProductID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcProductID.DisplayMember = "ProductID"
        Me.tdbcProductID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcProductID.DropDownWidth = 300
        Me.tdbcProductID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcProductID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcProductID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcProductID.EditorHeight = 17
        Me.tdbcProductID.EmptyRows = True
        Me.tdbcProductID.EvenRowStyle = Style10
        Me.tdbcProductID.ExtendRightColumn = True
        Me.tdbcProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcProductID.FooterStyle = Style11
        Me.tdbcProductID.HeadingStyle = Style12
        Me.tdbcProductID.HighLightRowStyle = Style13
        Me.tdbcProductID.Images.Add(CType(resources.GetObject("tdbcProductID.Images"), System.Drawing.Image))
        Me.tdbcProductID.ItemHeight = 15
        Me.tdbcProductID.Location = New System.Drawing.Point(93, 43)
        Me.tdbcProductID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcProductID.MaxDropDownItems = CType(8, Short)
        Me.tdbcProductID.MaxLength = 32767
        Me.tdbcProductID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcProductID.Name = "tdbcProductID"
        Me.tdbcProductID.OddRowStyle = Style14
        Me.tdbcProductID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcProductID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcProductID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcProductID.SelectedStyle = Style15
        Me.tdbcProductID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcProductID.Style = Style16
        Me.tdbcProductID.TabIndex = 1
        Me.tdbcProductID.ValueMember = "ProductID"
        Me.tdbcProductID.PropBag = resources.GetString("tdbcProductID.PropBag")
        '
        'tdbcPriceListID
        '
        Me.tdbcPriceListID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcPriceListID.AllowColMove = False
        Me.tdbcPriceListID.AllowSort = False
        Me.tdbcPriceListID.AlternatingRows = True
        Me.tdbcPriceListID.AutoCompletion = True
        Me.tdbcPriceListID.AutoDropDown = True
        Me.tdbcPriceListID.Caption = ""
        Me.tdbcPriceListID.CaptionHeight = 17
        Me.tdbcPriceListID.CaptionStyle = Style17
        Me.tdbcPriceListID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcPriceListID.ColumnCaptionHeight = 17
        Me.tdbcPriceListID.ColumnFooterHeight = 17
        Me.tdbcPriceListID.ColumnWidth = 100
        Me.tdbcPriceListID.ContentHeight = 17
        Me.tdbcPriceListID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcPriceListID.DisplayMember = "PriceListID"
        Me.tdbcPriceListID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcPriceListID.DropDownWidth = 300
        Me.tdbcPriceListID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcPriceListID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPriceListID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcPriceListID.EditorHeight = 17
        Me.tdbcPriceListID.EmptyRows = True
        Me.tdbcPriceListID.EvenRowStyle = Style18
        Me.tdbcPriceListID.ExtendRightColumn = True
        Me.tdbcPriceListID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcPriceListID.FooterStyle = Style19
        Me.tdbcPriceListID.HeadingStyle = Style20
        Me.tdbcPriceListID.HighLightRowStyle = Style21
        Me.tdbcPriceListID.Images.Add(CType(resources.GetObject("tdbcPriceListID.Images"), System.Drawing.Image))
        Me.tdbcPriceListID.ItemHeight = 15
        Me.tdbcPriceListID.Location = New System.Drawing.Point(93, 14)
        Me.tdbcPriceListID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcPriceListID.MaxDropDownItems = CType(8, Short)
        Me.tdbcPriceListID.MaxLength = 32767
        Me.tdbcPriceListID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcPriceListID.Name = "tdbcPriceListID"
        Me.tdbcPriceListID.OddRowStyle = Style22
        Me.tdbcPriceListID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcPriceListID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcPriceListID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcPriceListID.SelectedStyle = Style23
        Me.tdbcPriceListID.Size = New System.Drawing.Size(128, 23)
        Me.tdbcPriceListID.Style = Style24
        Me.tdbcPriceListID.TabIndex = 0
        Me.tdbcPriceListID.ValueMember = "PriceListID"
        Me.tdbcPriceListID.PropBag = resources.GetString("tdbcPriceListID.PropBag")
        '
        'lblPriceListID
        '
        Me.lblPriceListID.AutoSize = True
        Me.lblPriceListID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPriceListID.Location = New System.Drawing.Point(16, 19)
        Me.lblPriceListID.Name = "lblPriceListID"
        Me.lblPriceListID.Size = New System.Drawing.Size(49, 13)
        Me.lblPriceListID.TabIndex = 10
        Me.lblPriceListID.Text = "Bảng giá"
        Me.lblPriceListID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPriceListName
        '
        Me.txtPriceListName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtPriceListName.Location = New System.Drawing.Point(226, 14)
        Me.txtPriceListName.Name = "txtPriceListName"
        Me.txtPriceListName.ReadOnly = True
        Me.txtPriceListName.Size = New System.Drawing.Size(183, 22)
        Me.txtPriceListName.TabIndex = 11
        Me.txtPriceListName.TabStop = False
        '
        'lblProductID
        '
        Me.lblProductID.AutoSize = True
        Me.lblProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProductID.Location = New System.Drawing.Point(16, 48)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(55, 13)
        Me.lblProductID.TabIndex = 13
        Me.lblProductID.Text = "Sản phẩm"
        Me.lblProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductName
        '
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtProductName.Location = New System.Drawing.Point(226, 43)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(183, 22)
        Me.txtProductName.TabIndex = 14
        Me.txtProductName.TabStop = False
        '
        'lblStageID
        '
        Me.lblStageID.AutoSize = True
        Me.lblStageID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStageID.Location = New System.Drawing.Point(16, 77)
        Me.lblStageID.Name = "lblStageID"
        Me.lblStageID.Size = New System.Drawing.Size(60, 13)
        Me.lblStageID.TabIndex = 16
        Me.lblStageID.Text = "Công đoạn"
        Me.lblStageID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtStageName
        '
        Me.txtStageName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtStageName.Location = New System.Drawing.Point(226, 72)
        Me.txtStageName.Name = "txtStageName"
        Me.txtStageName.ReadOnly = True
        Me.txtStageName.Size = New System.Drawing.Size(183, 22)
        Me.txtStageName.TabIndex = 17
        Me.txtStageName.TabStop = False
        '
        'D45F4010
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 139)
        Me.Controls.Add(Me.grpReport)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F4010"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "BÀo cÀo b¶ng giÀ - D45F4010"
        Me.grpReport.ResumeLayout(False)
        Me.grpReport.PerformLayout()
        CType(Me.tdbcStageID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcPriceListID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnPrint As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents grpReport As System.Windows.Forms.GroupBox
    Private WithEvents tdbcProductID As C1.Win.C1List.C1Combo
    Private WithEvents tdbcPriceListID As C1.Win.C1List.C1Combo
    Private WithEvents lblPriceListID As System.Windows.Forms.Label
    Private WithEvents txtPriceListName As System.Windows.Forms.TextBox
    Private WithEvents lblProductID As System.Windows.Forms.Label
    Private WithEvents txtProductName As System.Windows.Forms.TextBox
    Private WithEvents lblStageID As System.Windows.Forms.Label
    Private WithEvents txtStageName As System.Windows.Forms.TextBox
    Private WithEvents tdbcStageID As C1.Win.C1List.C1Combo
End Class