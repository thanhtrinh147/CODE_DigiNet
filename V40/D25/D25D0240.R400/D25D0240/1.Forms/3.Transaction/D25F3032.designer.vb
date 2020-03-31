<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D25F3032
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D25F3032))
        Dim Style1 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style2 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style3 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style4 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style5 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style6 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style7 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Dim Style8 As C1.Win.C1TrueDBGrid.Style = New C1.Win.C1TrueDBGrid.Style()
        Me.txtEmployeeID = New System.Windows.Forms.TextBox()
        Me.lblEmployeeID = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.txtSexName = New System.Windows.Forms.TextBox()
        Me.lblSexName = New System.Windows.Forms.Label()
        Me.c1dateBirthDate = New C1.Win.C1Input.C1DateEdit()
        Me.lblteBirthDate = New System.Windows.Forms.Label()
        Me.txtRecPositionName = New System.Windows.Forms.TextBox()
        Me.lblRecPositionname = New System.Windows.Forms.Label()
        Me.grpEvaluationElement = New System.Windows.Forms.GroupBox()
        Me.lblEvaluationElement = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.tdbdEvaluationLevelID = New C1.Win.C1TrueDBGrid.C1TrueDBDropdown()
        CType(Me.c1dateBirthDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbdEvaluationLevelID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtEmployeeID
        '
        Me.txtEmployeeID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtEmployeeID.Location = New System.Drawing.Point(105, 9)
        Me.txtEmployeeID.MaxLength = 20
        Me.txtEmployeeID.Name = "txtEmployeeID"
        Me.txtEmployeeID.ReadOnly = True
        Me.txtEmployeeID.Size = New System.Drawing.Size(141, 22)
        Me.txtEmployeeID.TabIndex = 0
        '
        'lblEmployeeID
        '
        Me.lblEmployeeID.AutoSize = True
        Me.lblEmployeeID.Location = New System.Drawing.Point(13, 14)
        Me.lblEmployeeID.Name = "lblEmployeeID"
        Me.lblEmployeeID.Size = New System.Drawing.Size(72, 13)
        Me.lblEmployeeID.TabIndex = 1
        Me.lblEmployeeID.Text = "Mã nhân viên"
        Me.lblEmployeeID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFullName
        '
        Me.txtFullName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtFullName.Location = New System.Drawing.Point(105, 37)
        Me.txtFullName.MaxLength = 250
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.ReadOnly = True
        Me.txtFullName.Size = New System.Drawing.Size(290, 22)
        Me.txtFullName.TabIndex = 2
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Location = New System.Drawing.Point(13, 42)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(76, 13)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Tên nhân viên"
        Me.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSexName
        '
        Me.txtSexName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtSexName.Location = New System.Drawing.Point(488, 37)
        Me.txtSexName.Name = "txtSexName"
        Me.txtSexName.ReadOnly = True
        Me.txtSexName.Size = New System.Drawing.Size(72, 22)
        Me.txtSexName.TabIndex = 4
        '
        'lblSexName
        '
        Me.lblSexName.AutoSize = True
        Me.lblSexName.Location = New System.Drawing.Point(419, 42)
        Me.lblSexName.Name = "lblSexName"
        Me.lblSexName.Size = New System.Drawing.Size(47, 13)
        Me.lblSexName.TabIndex = 5
        Me.lblSexName.Text = "Giới tính"
        Me.lblSexName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'c1dateBirthDate
        '
        Me.c1dateBirthDate.AutoSize = False
        Me.c1dateBirthDate.CustomFormat = "dd/MM/yyyy"
        Me.c1dateBirthDate.EmptyAsNull = True
        Me.c1dateBirthDate.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateBirthDate.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateBirthDate.Location = New System.Drawing.Point(105, 65)
        Me.c1dateBirthDate.Name = "c1dateBirthDate"
        Me.c1dateBirthDate.Size = New System.Drawing.Size(141, 22)
        Me.c1dateBirthDate.TabIndex = 6
        Me.c1dateBirthDate.Tag = Nothing
        Me.c1dateBirthDate.TrimStart = True
        Me.c1dateBirthDate.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteBirthDate
        '
        Me.lblteBirthDate.AutoSize = True
        Me.lblteBirthDate.Location = New System.Drawing.Point(13, 70)
        Me.lblteBirthDate.Name = "lblteBirthDate"
        Me.lblteBirthDate.Size = New System.Drawing.Size(54, 13)
        Me.lblteBirthDate.TabIndex = 7
        Me.lblteBirthDate.Text = "Ngày sinh"
        Me.lblteBirthDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecPositionName
        '
        Me.txtRecPositionName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtRecPositionName.Location = New System.Drawing.Point(314, 65)
        Me.txtRecPositionName.Name = "txtRecPositionName"
        Me.txtRecPositionName.ReadOnly = True
        Me.txtRecPositionName.Size = New System.Drawing.Size(246, 22)
        Me.txtRecPositionName.TabIndex = 8
        '
        'lblRecPositionname
        '
        Me.lblRecPositionname.AutoSize = True
        Me.lblRecPositionname.Location = New System.Drawing.Point(265, 70)
        Me.lblRecPositionname.Name = "lblRecPositionname"
        Me.lblRecPositionname.Size = New System.Drawing.Size(29, 13)
        Me.lblRecPositionname.TabIndex = 9
        Me.lblRecPositionname.Text = "Vị trí"
        Me.lblRecPositionname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpEvaluationElement
        '
        Me.grpEvaluationElement.Location = New System.Drawing.Point(117, 103)
        Me.grpEvaluationElement.Name = "grpEvaluationElement"
        Me.grpEvaluationElement.Size = New System.Drawing.Size(446, 5)
        Me.grpEvaluationElement.TabIndex = 10
        Me.grpEvaluationElement.TabStop = False
        '
        'lblEvaluationElement
        '
        Me.lblEvaluationElement.AutoSize = True
        Me.lblEvaluationElement.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEvaluationElement.Location = New System.Drawing.Point(9, 100)
        Me.lblEvaluationElement.Name = "lblEvaluationElement"
        Me.lblEvaluationElement.Size = New System.Drawing.Size(99, 13)
        Me.lblEvaluationElement.TabIndex = 11
        Me.lblEvaluationElement.Text = "Chỉ tiêu yêu cầu"
        Me.lblEvaluationElement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(16, 122)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightCell
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(544, 206)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 12
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(421, 334)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(68, 22)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(492, 334)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(68, 22)
        Me.btnClose.TabIndex = 14
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'tdbdEvaluationLevelID
        '
        Me.tdbdEvaluationLevelID.AllowColMove = False
        Me.tdbdEvaluationLevelID.AllowColSelect = False
        Me.tdbdEvaluationLevelID.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbdEvaluationLevelID.AllowSort = False
        Me.tdbdEvaluationLevelID.AlternatingRows = True
        Me.tdbdEvaluationLevelID.CaptionHeight = 17
        Me.tdbdEvaluationLevelID.CaptionStyle = Style1
        Me.tdbdEvaluationLevelID.ColumnCaptionHeight = 17
        Me.tdbdEvaluationLevelID.ColumnFooterHeight = 17
        Me.tdbdEvaluationLevelID.DisplayMember = "EvaluationLevelName"
        Me.tdbdEvaluationLevelID.EmptyRows = True
        Me.tdbdEvaluationLevelID.EvenRowStyle = Style2
        Me.tdbdEvaluationLevelID.ExtendRightColumn = True
        Me.tdbdEvaluationLevelID.FetchRowStyles = False
        Me.tdbdEvaluationLevelID.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbdEvaluationLevelID.FooterStyle = Style3
        Me.tdbdEvaluationLevelID.HeadingStyle = Style4
        Me.tdbdEvaluationLevelID.HighLightRowStyle = Style5
        Me.tdbdEvaluationLevelID.Images.Add(CType(resources.GetObject("tdbdEvaluationLevelID.Images"), System.Drawing.Image))
        Me.tdbdEvaluationLevelID.Location = New System.Drawing.Point(246, 161)
        Me.tdbdEvaluationLevelID.Name = "tdbdEvaluationLevelID"
        Me.tdbdEvaluationLevelID.OddRowStyle = Style6
        Me.tdbdEvaluationLevelID.RecordSelectorStyle = Style7
        Me.tdbdEvaluationLevelID.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbdEvaluationLevelID.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.[Single]
        Me.tdbdEvaluationLevelID.RowHeight = 15
        Me.tdbdEvaluationLevelID.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbdEvaluationLevelID.ScrollTips = False
        Me.tdbdEvaluationLevelID.Size = New System.Drawing.Size(314, 147)
        Me.tdbdEvaluationLevelID.Style = Style8
        Me.tdbdEvaluationLevelID.TabIndex = 15
        Me.tdbdEvaluationLevelID.TabStop = False
        Me.tdbdEvaluationLevelID.ValueMember = "EvaluationLevelName"
        Me.tdbdEvaluationLevelID.ValueTranslate = True
        Me.tdbdEvaluationLevelID.Visible = False
        Me.tdbdEvaluationLevelID.PropBag = resources.GetString("tdbdEvaluationLevelID.PropBag")
        '
        'D25F3032
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 367)
        Me.Controls.Add(Me.tdbdEvaluationLevelID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lblEvaluationElement)
        Me.Controls.Add(Me.grpEvaluationElement)
        Me.Controls.Add(Me.txtRecPositionName)
        Me.Controls.Add(Me.c1dateBirthDate)
        Me.Controls.Add(Me.txtSexName)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtEmployeeID)
        Me.Controls.Add(Me.lblEmployeeID)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblSexName)
        Me.Controls.Add(Me.lblteBirthDate)
        Me.Controls.Add(Me.lblRecPositionname)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D25F3032"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "˜Ành giÀ theo chÙ ti£u y£u cÇu - D25F3032"
        CType(Me.c1dateBirthDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbdEvaluationLevelID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtEmployeeID As System.Windows.Forms.TextBox
    Private WithEvents lblEmployeeID As System.Windows.Forms.Label
    Private WithEvents txtFullName As System.Windows.Forms.TextBox
    Private WithEvents lblFullName As System.Windows.Forms.Label
    Private WithEvents txtSexName As System.Windows.Forms.TextBox
    Private WithEvents lblSexName As System.Windows.Forms.Label
    Private WithEvents c1dateBirthDate As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteBirthDate As System.Windows.Forms.Label
    Private WithEvents txtRecPositionName As System.Windows.Forms.TextBox
    Private WithEvents lblRecPositionname As System.Windows.Forms.Label
    Private WithEvents grpEvaluationElement As System.Windows.Forms.GroupBox
    Private WithEvents lblEvaluationElement As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents tdbdEvaluationLevelID As C1.Win.C1TrueDBGrid.C1TrueDBDropdown
End Class
