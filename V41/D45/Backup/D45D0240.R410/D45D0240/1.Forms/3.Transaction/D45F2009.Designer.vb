<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2009
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2009))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.txtProductID = New System.Windows.Forms.TextBox
        Me.lblProductID = New System.Windows.Forms.Label
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.tdbcRoutingID = New C1.Win.C1List.C1Combo
        Me.lblRoutingID = New System.Windows.Forms.Label
        Me.txtRoutingName = New System.Windows.Forms.TextBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnChoose = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbcRoutingID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtProductID
        '
        Me.txtProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtProductID.Location = New System.Drawing.Point(100, 13)
        Me.txtProductID.MaxLength = 20
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.ReadOnly = True
        Me.txtProductID.Size = New System.Drawing.Size(157, 22)
        Me.txtProductID.TabIndex = 0
        Me.txtProductID.TabStop = False
        '
        'lblProductID
        '
        Me.lblProductID.AutoSize = True
        Me.lblProductID.Location = New System.Drawing.Point(16, 18)
        Me.lblProductID.Name = "lblProductID"
        Me.lblProductID.Size = New System.Drawing.Size(55, 13)
        Me.lblProductID.TabIndex = 1
        Me.lblProductID.Text = "Sản phẩm"
        Me.lblProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtProductName
        '
        Me.txtProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtProductName.Location = New System.Drawing.Point(263, 13)
        Me.txtProductName.MaxLength = 250
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.ReadOnly = True
        Me.txtProductName.Size = New System.Drawing.Size(313, 22)
        Me.txtProductName.TabIndex = 2
        Me.txtProductName.TabStop = False
        '
        'tdbcRoutingID
        '
        Me.tdbcRoutingID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcRoutingID.AllowColMove = False
        Me.tdbcRoutingID.AllowSort = False
        Me.tdbcRoutingID.AlternatingRows = True
        Me.tdbcRoutingID.AutoCompletion = True
        Me.tdbcRoutingID.AutoDropDown = True
        Me.tdbcRoutingID.Caption = ""
        Me.tdbcRoutingID.CaptionHeight = 17
        Me.tdbcRoutingID.CaptionStyle = Style1
        Me.tdbcRoutingID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcRoutingID.ColumnCaptionHeight = 17
        Me.tdbcRoutingID.ColumnFooterHeight = 17
        Me.tdbcRoutingID.ColumnWidth = 100
        Me.tdbcRoutingID.ContentHeight = 17
        Me.tdbcRoutingID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcRoutingID.DisplayMember = "RoutingNum"
        Me.tdbcRoutingID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcRoutingID.DropDownWidth = 350
        Me.tdbcRoutingID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcRoutingID.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcRoutingID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcRoutingID.EditorHeight = 17
        Me.tdbcRoutingID.EmptyRows = True
        Me.tdbcRoutingID.EvenRowStyle = Style2
        Me.tdbcRoutingID.ExtendRightColumn = True
        Me.tdbcRoutingID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbcRoutingID.FooterStyle = Style3
        Me.tdbcRoutingID.HeadingStyle = Style4
        Me.tdbcRoutingID.HighLightRowStyle = Style5
        Me.tdbcRoutingID.Images.Add(CType(resources.GetObject("tdbcRoutingID.Images"), System.Drawing.Image))
        Me.tdbcRoutingID.ItemHeight = 15
        Me.tdbcRoutingID.Location = New System.Drawing.Point(100, 41)
        Me.tdbcRoutingID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcRoutingID.MaxDropDownItems = CType(8, Short)
        Me.tdbcRoutingID.MaxLength = 32767
        Me.tdbcRoutingID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcRoutingID.Name = "tdbcRoutingID"
        Me.tdbcRoutingID.OddRowStyle = Style6
        Me.tdbcRoutingID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcRoutingID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcRoutingID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcRoutingID.SelectedStyle = Style7
        Me.tdbcRoutingID.Size = New System.Drawing.Size(157, 23)
        Me.tdbcRoutingID.Style = Style8
        Me.tdbcRoutingID.TabIndex = 3
        Me.tdbcRoutingID.ValueMember = "RoutingID"
        Me.tdbcRoutingID.PropBag = resources.GetString("tdbcRoutingID.PropBag")
        '
        'lblRoutingID
        '
        Me.lblRoutingID.AutoSize = True
        Me.lblRoutingID.Location = New System.Drawing.Point(16, 46)
        Me.lblRoutingID.Name = "lblRoutingID"
        Me.lblRoutingID.Size = New System.Drawing.Size(49, 13)
        Me.lblRoutingID.TabIndex = 4
        Me.lblRoutingID.Text = "Quy trình"
        Me.lblRoutingID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRoutingName
        '
        Me.txtRoutingName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.txtRoutingName.Location = New System.Drawing.Point(263, 41)
        Me.txtRoutingName.Name = "txtRoutingName"
        Me.txtRoutingName.ReadOnly = True
        Me.txtRoutingName.Size = New System.Drawing.Size(313, 22)
        Me.txtRoutingName.TabIndex = 5
        Me.txtRoutingName.TabStop = False
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 86)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(567, 287)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 6
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(418, 380)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(76, 22)
        Me.btnChoose.TabIndex = 7
        Me.btnChoose.Text = "&Chọn"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(500, 380)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D45F2009
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 408)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.tdbcRoutingID)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.txtProductID)
        Me.Controls.Add(Me.lblProductID)
        Me.Controls.Add(Me.lblRoutingID)
        Me.Controls.Add(Me.txtRoutingName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2009"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chãn quy trØnh - D45F2009"
        CType(Me.tdbcRoutingID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtProductID As System.Windows.Forms.TextBox
    Private WithEvents lblProductID As System.Windows.Forms.Label
    Private WithEvents txtProductName As System.Windows.Forms.TextBox
    Private WithEvents tdbcRoutingID As C1.Win.C1List.C1Combo
    Private WithEvents lblRoutingID As System.Windows.Forms.Label
    Private WithEvents txtRoutingName As System.Windows.Forms.TextBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class