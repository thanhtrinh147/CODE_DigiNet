<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1071
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1071))
        Me.txtClassificationID = New System.Windows.Forms.TextBox
        Me.lblClassificationID = New System.Windows.Forms.Label
        Me.txtClassificationName = New System.Windows.Forms.TextBox
        Me.lblClassificationName = New System.Windows.Forms.Label
        Me.chkDisabled = New System.Windows.Forms.CheckBox
        Me.tdbgDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.chkDetail = New System.Windows.Forms.CheckBox
        CType(Me.tdbgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtClassificationID
        '
        Me.txtClassificationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClassificationID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtClassificationID.Location = New System.Drawing.Point(88, 7)
        Me.txtClassificationID.MaxLength = 20
        Me.txtClassificationID.Name = "txtClassificationID"
        Me.txtClassificationID.Size = New System.Drawing.Size(153, 22)
        Me.txtClassificationID.TabIndex = 0
        '
        'lblClassificationID
        '
        Me.lblClassificationID.AutoSize = True
        Me.lblClassificationID.Location = New System.Drawing.Point(4, 12)
        Me.lblClassificationID.Name = "lblClassificationID"
        Me.lblClassificationID.Size = New System.Drawing.Size(22, 13)
        Me.lblClassificationID.TabIndex = 1
        Me.lblClassificationID.Text = "Mã"
        Me.lblClassificationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtClassificationName
        '
        Me.txtClassificationName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtClassificationName.Location = New System.Drawing.Point(88, 35)
        Me.txtClassificationName.MaxLength = 50
        Me.txtClassificationName.Name = "txtClassificationName"
        Me.txtClassificationName.Size = New System.Drawing.Size(442, 22)
        Me.txtClassificationName.TabIndex = 2
        '
        'lblClassificationName
        '
        Me.lblClassificationName.AutoSize = True
        Me.lblClassificationName.Location = New System.Drawing.Point(4, 40)
        Me.lblClassificationName.Name = "lblClassificationName"
        Me.lblClassificationName.Size = New System.Drawing.Size(48, 13)
        Me.lblClassificationName.TabIndex = 3
        Me.lblClassificationName.Text = "Diễn giải"
        Me.lblClassificationName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(432, 11)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 1
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'tdbgDetail
        '
        Me.tdbgDetail.AllowAddNew = True
        Me.tdbgDetail.AllowColMove = False
        Me.tdbgDetail.AllowColSelect = False
        Me.tdbgDetail.AllowDelete = True
        Me.tdbgDetail.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgDetail.AllowSort = False
        Me.tdbgDetail.AlternatingRows = True
        Me.tdbgDetail.CaptionHeight = 17
        Me.tdbgDetail.EmptyRows = True
        Me.tdbgDetail.ExtendRightColumn = True
        Me.tdbgDetail.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgDetail.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgDetail.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgDetail.Images.Add(CType(resources.GetObject("tdbgDetail.Images"), System.Drawing.Image))
        Me.tdbgDetail.Images.Add(CType(resources.GetObject("tdbgDetail.Images1"), System.Drawing.Image))
        Me.tdbgDetail.Location = New System.Drawing.Point(7, 94)
        Me.tdbgDetail.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbgDetail.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgDetail.Name = "tdbgDetail"
        Me.tdbgDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgDetail.PreviewInfo.ZoomFactor = 75
        Me.tdbgDetail.PrintInfo.PageSettings = CType(resources.GetObject("tdbgDetail.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgDetail.RowHeight = 15
        Me.tdbgDetail.Size = New System.Drawing.Size(523, 254)
        Me.tdbgDetail.TabAcrossSplits = True
        Me.tdbgDetail.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgDetail.TabIndex = 3
        Me.tdbgDetail.Tag = "COLS"
        Me.tdbgDetail.PropBag = resources.GetString("tdbgDetail.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(292, 354)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(454, 354)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(373, 354)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'chkDetail
        '
        Me.chkDetail.AutoSize = True
        Me.chkDetail.Location = New System.Drawing.Point(7, 67)
        Me.chkDetail.Name = "chkDetail"
        Me.chkDetail.Size = New System.Drawing.Size(132, 17)
        Me.chkDetail.TabIndex = 8
        Me.chkDetail.Text = "Chi tiết theo nhân viên"
        Me.chkDetail.UseVisualStyleBackColor = True
        '
        'D13F1071
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(536, 385)
        Me.Controls.Add(Me.chkDetail)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbgDetail)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtClassificationName)
        Me.Controls.Add(Me.txtClassificationID)
        Me.Controls.Add(Me.lblClassificationID)
        Me.Controls.Add(Me.lblClassificationName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1071"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt ¢Ành giÀ xÕp loÁi - D13F1071"
        CType(Me.tdbgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtClassificationID As System.Windows.Forms.TextBox
    Private WithEvents lblClassificationID As System.Windows.Forms.Label
    Private WithEvents txtClassificationName As System.Windows.Forms.TextBox
    Private WithEvents lblClassificationName As System.Windows.Forms.Label
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents tdbgDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Private WithEvents chkDetail As System.Windows.Forms.CheckBox
End Class
