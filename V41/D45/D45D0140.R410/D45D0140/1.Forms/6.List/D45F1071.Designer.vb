<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F1071
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
        Dim Style9 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style10 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style11 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style12 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style13 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F1071))
        Dim Style14 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style15 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style16 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.txtGroupProductID = New System.Windows.Forms.TextBox
        Me.lblGroupProductID = New System.Windows.Forms.Label
        Me.txtGroupProductName = New System.Windows.Forms.TextBox
        Me.lblGroupProductName = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.txtGroupProductDesc = New System.Windows.Forms.TextBox
        Me.lblGroupProductDesc = New System.Windows.Forms.Label
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpList = New System.Windows.Forms.GroupBox
        Me.tdbdProductID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grpList.SuspendLayout()
        CType(Me.tdbdProductID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtGroupProductID
        '
        Me.txtGroupProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGroupProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtGroupProductID.Location = New System.Drawing.Point(148, 12)
        Me.txtGroupProductID.MaxLength = 20
        Me.txtGroupProductID.Name = "txtGroupProductID"
        Me.txtGroupProductID.Size = New System.Drawing.Size(218, 22)
        Me.txtGroupProductID.TabIndex = 0
        '
        'lblGroupProductID
        '
        Me.lblGroupProductID.AutoSize = True
        Me.lblGroupProductID.Location = New System.Drawing.Point(27, 17)
        Me.lblGroupProductID.Name = "lblGroupProductID"
        Me.lblGroupProductID.Size = New System.Drawing.Size(22, 13)
        Me.lblGroupProductID.TabIndex = 0
        Me.lblGroupProductID.Text = "Mã"
        Me.lblGroupProductID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGroupProductName
        '
        Me.txtGroupProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtGroupProductName.Location = New System.Drawing.Point(148, 40)
        Me.txtGroupProductName.MaxLength = 50
        Me.txtGroupProductName.Name = "txtGroupProductName"
        Me.txtGroupProductName.Size = New System.Drawing.Size(514, 22)
        Me.txtGroupProductName.TabIndex = 2
        '
        'lblGroupProductName
        '
        Me.lblGroupProductName.AutoSize = True
        Me.lblGroupProductName.Location = New System.Drawing.Point(27, 45)
        Me.lblGroupProductName.Name = "lblGroupProductName"
        Me.lblGroupProductName.Size = New System.Drawing.Size(26, 13)
        Me.lblGroupProductName.TabIndex = 3
        Me.lblGroupProductName.Text = "Tên"
        Me.lblGroupProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(564, 15)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtGroupProductDesc
        '
        Me.txtGroupProductDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.249999!)
        Me.txtGroupProductDesc.Location = New System.Drawing.Point(148, 68)
        Me.txtGroupProductDesc.MaxLength = 150
        Me.txtGroupProductDesc.Name = "txtGroupProductDesc"
        Me.txtGroupProductDesc.Size = New System.Drawing.Size(514, 22)
        Me.txtGroupProductDesc.TabIndex = 3
        '
        'lblGroupProductDesc
        '
        Me.lblGroupProductDesc.AutoSize = True
        Me.lblGroupProductDesc.Location = New System.Drawing.Point(27, 73)
        Me.lblGroupProductDesc.Name = "lblGroupProductDesc"
        Me.lblGroupProductDesc.Size = New System.Drawing.Size(44, 13)
        Me.lblGroupProductDesc.TabIndex = 12
        Me.lblGroupProductDesc.Text = "Ghi chú"
        Me.lblGroupProductDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(446, 446)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 5
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(528, 446)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 6
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(610, 446)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'grpList
        '
        Me.grpList.Controls.Add(Me.tdbdProductID)
        Me.grpList.Controls.Add(Me.tdbg)
        Me.grpList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpList.Location = New System.Drawing.Point(8, 105)
        Me.grpList.Name = "grpList"
        Me.grpList.Size = New System.Drawing.Size(678, 333)
        Me.grpList.TabIndex = 4
        Me.grpList.TabStop = False
        Me.grpList.Text = "Danh sách sản phẩm"
        '
        'tdbdProductID
        '
        Me.tdbdProductID.AllowColMove = False
        Me.tdbdProductID.AllowColSelect = False
        Me.tdbdProductID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdProductID.AllowSort = False
        Me.tdbdProductID.AlternatingRows = True
        Me.tdbdProductID.CaptionHeight = 17
        Me.tdbdProductID.CaptionStyle = Style9
        Me.tdbdProductID.ColumnCaptionHeight = 17
        Me.tdbdProductID.ColumnFooterHeight = 17
        Me.tdbdProductID.DisplayMember = "ProductID"
        Me.tdbdProductID.EmptyRows = True
        Me.tdbdProductID.EvenRowStyle = Style10
        Me.tdbdProductID.ExtendRightColumn = True
        Me.tdbdProductID.FetchRowStyles = False
        Me.tdbdProductID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbdProductID.FooterStyle = Style11
        Me.tdbdProductID.HeadingStyle = Style12
        Me.tdbdProductID.HighLightRowStyle = Style13
        Me.tdbdProductID.Images.Add(CType(resources.GetObject("tdbdProductID.Images"), System.Drawing.Image))
        Me.tdbdProductID.Location = New System.Drawing.Point(58, 70)
        Me.tdbdProductID.Name = "tdbdProductID"
        Me.tdbdProductID.OddRowStyle = Style14
        Me.tdbdProductID.RecordSelectorStyle = Style15
        Me.tdbdProductID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdProductID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdProductID.RowHeight = 15
        Me.tdbdProductID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdProductID.ScrollTips = False
        Me.tdbdProductID.Size = New System.Drawing.Size(350, 147)
        Me.tdbdProductID.Style = Style16
        Me.tdbdProductID.TabIndex = 1
        Me.tdbdProductID.TabStop = False
        Me.tdbdProductID.ValueMember = "ProductID"
        Me.tdbdProductID.Visible = False
        Me.tdbdProductID.PropBag = resources.GetString("tdbdProductID.PropBag")
        '
        'tdbg
        '
        Me.tdbg.AllowAddNew = True
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowDelete = True
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 22)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(661, 303)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'D45F1071
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 478)
        Me.Controls.Add(Me.grpList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtGroupProductDesc)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtGroupProductName)
        Me.Controls.Add(Me.txtGroupProductID)
        Me.Controls.Add(Me.lblGroupProductID)
        Me.Controls.Add(Me.lblGroupProductName)
        Me.Controls.Add(Me.lblGroupProductDesc)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F1071"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt nhâm s¶n phÈm- D45F1071"
        Me.grpList.ResumeLayout(False)
        CType(Me.tdbdProductID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtGroupProductID As System.Windows.Forms.TextBox
    Private WithEvents lblGroupProductID As System.Windows.Forms.Label
    Private WithEvents txtGroupProductName As System.Windows.Forms.TextBox
    Private WithEvents lblGroupProductName As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtGroupProductDesc As System.Windows.Forms.TextBox
    Private WithEvents lblGroupProductDesc As System.Windows.Forms.Label
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents grpList As System.Windows.Forms.GroupBox
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdProductID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class