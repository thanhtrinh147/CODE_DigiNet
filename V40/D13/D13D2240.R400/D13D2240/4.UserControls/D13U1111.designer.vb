<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13U1111
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13U1111))
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.picClose = New System.Windows.Forms.PictureBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.lbl1 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.tdbcDisplayTempID = New C1.Win.C1List.C1Combo
        Me.lblDisplayTempID = New System.Windows.Forms.Label
        Me.txtDisplayTempName = New System.Windows.Forms.TextBox
        Me.lblDisplayTempName = New System.Windows.Forms.Label
        Me.txtDisplayTempID = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.Button
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbcDisplayTempID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(7, 86)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(250, 324)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabIndex = 6
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'picClose
        '
        Me.picClose.Image = CType(resources.GetObject("picClose.Image"), System.Drawing.Image)
        Me.picClose.Location = New System.Drawing.Point(251, 3)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(14, 15)
        Me.picClose.TabIndex = 20
        Me.picClose.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(181, 416)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lbl1
        '
        Me.lbl1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lbl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lbl1.Location = New System.Drawing.Point(0, 0)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(265, 21)
        Me.lbl1.TabIndex = 0
        Me.lbl1.Text = "Chọn cột hiển thị"
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(99, 416)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(76, 22)
        Me.btnRefresh.TabIndex = 8
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'tdbcDisplayTempID
        '
        Me.tdbcDisplayTempID.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcDisplayTempID.AllowColMove = False
        Me.tdbcDisplayTempID.AllowSort = False
        Me.tdbcDisplayTempID.AlternatingRows = True
        Me.tdbcDisplayTempID.AutoCompletion = True
        Me.tdbcDisplayTempID.AutoDropDown = True
        Me.tdbcDisplayTempID.Caption = ""
        Me.tdbcDisplayTempID.CaptionHeight = 17
        Me.tdbcDisplayTempID.CaptionStyle = Style1
        Me.tdbcDisplayTempID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcDisplayTempID.ColumnCaptionHeight = 17
        Me.tdbcDisplayTempID.ColumnFooterHeight = 17
        Me.tdbcDisplayTempID.ColumnWidth = 100
        Me.tdbcDisplayTempID.ContentHeight = 17
        Me.tdbcDisplayTempID.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcDisplayTempID.DisplayMember = "DisplayTempID"
        Me.tdbcDisplayTempID.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcDisplayTempID.DropDownWidth = 350
        Me.tdbcDisplayTempID.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcDisplayTempID.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDisplayTempID.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcDisplayTempID.EditorHeight = 17
        Me.tdbcDisplayTempID.EmptyRows = True
        Me.tdbcDisplayTempID.EvenRowStyle = Style2
        Me.tdbcDisplayTempID.ExtendRightColumn = True
        Me.tdbcDisplayTempID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcDisplayTempID.FooterStyle = Style3
        Me.tdbcDisplayTempID.HeadingStyle = Style4
        Me.tdbcDisplayTempID.HighLightRowStyle = Style5
        Me.tdbcDisplayTempID.Images.Add(CType(resources.GetObject("tdbcDisplayTempID.Images"), System.Drawing.Image))
        Me.tdbcDisplayTempID.ItemHeight = 15
        Me.tdbcDisplayTempID.Location = New System.Drawing.Point(93, 28)
        Me.tdbcDisplayTempID.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcDisplayTempID.MaxDropDownItems = CType(8, Short)
        Me.tdbcDisplayTempID.MaxLength = 32767
        Me.tdbcDisplayTempID.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcDisplayTempID.Name = "tdbcDisplayTempID"
        Me.tdbcDisplayTempID.OddRowStyle = Style6
        Me.tdbcDisplayTempID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcDisplayTempID.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcDisplayTempID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcDisplayTempID.SelectedStyle = Style7
        Me.tdbcDisplayTempID.Size = New System.Drawing.Size(132, 23)
        Me.tdbcDisplayTempID.Style = Style8
        Me.tdbcDisplayTempID.TabIndex = 2
        Me.tdbcDisplayTempID.ValueMember = "DisplayTempID"
        Me.tdbcDisplayTempID.PropBag = resources.GetString("tdbcDisplayTempID.PropBag")
        '
        'lblDisplayTempID
        '
        Me.lblDisplayTempID.AutoSize = True
        Me.lblDisplayTempID.Location = New System.Drawing.Point(4, 32)
        Me.lblDisplayTempID.Name = "lblDisplayTempID"
        Me.lblDisplayTempID.Size = New System.Drawing.Size(65, 13)
        Me.lblDisplayTempID.TabIndex = 1
        Me.lblDisplayTempID.Text = "Mẫu hiển thị"
        Me.lblDisplayTempID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDisplayTempName
        '
        Me.txtDisplayTempName.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.txtDisplayTempName.Location = New System.Drawing.Point(93, 56)
        Me.txtDisplayTempName.MaxLength = 250
        Me.txtDisplayTempName.Name = "txtDisplayTempName"
        Me.txtDisplayTempName.Size = New System.Drawing.Size(161, 22)
        Me.txtDisplayTempName.TabIndex = 5
        '
        'lblDisplayTempName
        '
        Me.lblDisplayTempName.AutoSize = True
        Me.lblDisplayTempName.Location = New System.Drawing.Point(4, 56)
        Me.lblDisplayTempName.Name = "lblDisplayTempName"
        Me.lblDisplayTempName.Size = New System.Drawing.Size(48, 13)
        Me.lblDisplayTempName.TabIndex = 4
        Me.lblDisplayTempName.Text = "Diễn giải"
        Me.lblDisplayTempName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDisplayTempID
        '
        Me.txtDisplayTempID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDisplayTempID.Location = New System.Drawing.Point(93, 28)
        Me.txtDisplayTempID.MaxLength = 20
        Me.txtDisplayTempID.Name = "txtDisplayTempID"
        Me.txtDisplayTempID.Size = New System.Drawing.Size(132, 22)
        Me.txtDisplayTempID.TabIndex = 3
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(17, 416)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(76, 22)
        Me.btnDelete.TabIndex = 7
        Me.btnDelete.Text = "Xóa"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'D09U1111
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.tdbcDisplayTempID)
        Me.Controls.Add(Me.picClose)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.lblDisplayTempName)
        Me.Controls.Add(Me.lblDisplayTempID)
        Me.Controls.Add(Me.txtDisplayTempName)
        Me.Controls.Add(Me.txtDisplayTempID)
        Me.Name = "D09U1111"
        Me.Size = New System.Drawing.Size(265, 443)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbcDisplayTempID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents picClose As System.Windows.Forms.PictureBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents btnRefresh As System.Windows.Forms.Button
    Private WithEvents tdbcDisplayTempID As C1.Win.C1List.C1Combo
    Private WithEvents lblDisplayTempID As System.Windows.Forms.Label
    Private WithEvents txtDisplayTempName As System.Windows.Forms.TextBox
    Private WithEvents lblDisplayTempName As System.Windows.Forms.Label
    Private WithEvents txtDisplayTempID As System.Windows.Forms.TextBox
    Private WithEvents btnDelete As System.Windows.Forms.Button

End Class
