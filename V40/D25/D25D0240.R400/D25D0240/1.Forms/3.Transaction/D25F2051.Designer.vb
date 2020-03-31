<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F2051
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F2051))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tdbdInterviewerID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.c1dateInterviewDate = New C1.Win.C1Input.C1DateEdit
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdInterviewerID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1dateInterviewDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(9, 10)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(1000, 607)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'tdbdInterviewerID
        '
        Me.tdbdInterviewerID.AllowColMove = False
        Me.tdbdInterviewerID.AllowColSelect = False
        Me.tdbdInterviewerID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdInterviewerID.AllowSort = False
        Me.tdbdInterviewerID.AlternatingRows = True
        Me.tdbdInterviewerID.CaptionHeight = 17
        Me.tdbdInterviewerID.CaptionStyle = Style1
        Me.tdbdInterviewerID.ColumnCaptionHeight = 17
        Me.tdbdInterviewerID.ColumnFooterHeight = 17
        Me.tdbdInterviewerID.DisplayMember = "InterviewerName"
        Me.tdbdInterviewerID.EmptyRows = True
        Me.tdbdInterviewerID.EvenRowStyle = Style2
        Me.tdbdInterviewerID.ExtendRightColumn = True
        Me.tdbdInterviewerID.FetchRowStyles = False
        Me.tdbdInterviewerID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdInterviewerID.FooterStyle = Style3
        Me.tdbdInterviewerID.HeadingStyle = Style4
        Me.tdbdInterviewerID.HighLightRowStyle = Style5
        Me.tdbdInterviewerID.Images.Add(CType(resources.GetObject("tdbdInterviewerID.Images"), System.Drawing.Image))
        Me.tdbdInterviewerID.Location = New System.Drawing.Point(345, 60)
        Me.tdbdInterviewerID.Name = "tdbdInterviewerID"
        Me.tdbdInterviewerID.OddRowStyle = Style6
        Me.tdbdInterviewerID.RecordSelectorStyle = Style7
        Me.tdbdInterviewerID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdInterviewerID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdInterviewerID.RowHeight = 15
        Me.tdbdInterviewerID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdInterviewerID.ScrollTips = False
        Me.tdbdInterviewerID.Size = New System.Drawing.Size(300, 147)
        Me.tdbdInterviewerID.Style = Style8
        Me.tdbdInterviewerID.TabIndex = 1
        Me.tdbdInterviewerID.TabStop = False
        Me.tdbdInterviewerID.ValueMember = "InterviewerName"
        Me.tdbdInterviewerID.ValueTranslate = True
        Me.tdbdInterviewerID.Visible = False
        Me.tdbdInterviewerID.PropBag = resources.GetString("tdbdInterviewerID.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(851, 626)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(933, 626)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'c1dateInterviewDate
        '
        Me.c1dateInterviewDate.AutoSize = False
        Me.c1dateInterviewDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateInterviewDate.EmptyAsNull = True
        Me.c1dateInterviewDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateInterviewDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateInterviewDate.Location = New System.Drawing.Point(111, 81)
        Me.c1dateInterviewDate.Name = "c1dateInterviewDate"
        Me.c1dateInterviewDate.Size = New System.Drawing.Size(100, 22)
        Me.c1dateInterviewDate.TabIndex = 4
        Me.c1dateInterviewDate.Tag = Nothing
        Me.c1dateInterviewDate.TrimStart = True
        Me.c1dateInterviewDate.Visible = False
        Me.c1dateInterviewDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'D25F2051
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.c1dateInterviewDate)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbdInterviewerID)
        Me.Controls.Add(Me.tdbg)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F2051"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chi tiÕt kÕt qu¶ phàng vÊn - D25F2051"
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdInterviewerID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1dateInterviewDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents tdbdInterviewerID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents c1dateInterviewDate As C1.Win.C1Input.C1DateEdit
End Class
