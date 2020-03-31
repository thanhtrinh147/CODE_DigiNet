<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1011
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1011))
        Me.grp3 = New System.Windows.Forms.GroupBox()
        Me.optIsPercent2 = New System.Windows.Forms.RadioButton()
        Me.optIsPercent1 = New System.Windows.Forms.RadioButton()
        Me.optFullIsProgressive = New System.Windows.Forms.RadioButton()
        Me.optPartIsProgressive = New System.Windows.Forms.RadioButton()
        Me.chkDisabled = New System.Windows.Forms.CheckBox()
        Me.txtTaxObjectName = New System.Windows.Forms.TextBox()
        Me.txtTaxObjectID = New System.Windows.Forms.TextBox()
        Me.lblTaxObjectID = New System.Windows.Forms.Label()
        Me.lblTaxObjectName = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.grp5 = New System.Windows.Forms.GroupBox()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grpMethodCalTax = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkIsDefault = New System.Windows.Forms.CheckBox()
        Me.grp3.SuspendLayout()
        Me.grp5.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpMethodCalTax.SuspendLayout()
        Me.SuspendLayout()
        '
        'grp3
        '
        Me.grp3.BackColor = System.Drawing.SystemColors.Control
        Me.grp3.Controls.Add(Me.optIsPercent2)
        Me.grp3.Controls.Add(Me.optIsPercent1)
        Me.grp3.Location = New System.Drawing.Point(317, 19)
        Me.grp3.Name = "grp3"
        Me.grp3.Size = New System.Drawing.Size(200, 78)
        Me.grp3.TabIndex = 2
        Me.grp3.TabStop = False
        Me.grp3.Text = "Phương pháp xác định trị thuế"
        Me.grp3.Visible = False
        '
        'optIsPercent2
        '
        Me.optIsPercent2.AutoSize = True
        Me.optIsPercent2.Location = New System.Drawing.Point(9, 42)
        Me.optIsPercent2.Name = "optIsPercent2"
        Me.optIsPercent2.Size = New System.Drawing.Size(78, 17)
        Me.optIsPercent2.TabIndex = 1
        Me.optIsPercent2.Text = "Theo giá trị"
        Me.optIsPercent2.UseVisualStyleBackColor = True
        '
        'optIsPercent1
        '
        Me.optIsPercent1.AutoSize = True
        Me.optIsPercent1.Checked = True
        Me.optIsPercent1.Location = New System.Drawing.Point(9, 19)
        Me.optIsPercent1.Name = "optIsPercent1"
        Me.optIsPercent1.Size = New System.Drawing.Size(69, 17)
        Me.optIsPercent1.TabIndex = 0
        Me.optIsPercent1.TabStop = True
        Me.optIsPercent1.Text = "Theo tỉ lệ"
        Me.optIsPercent1.UseVisualStyleBackColor = True
        '
        'optFullIsProgressive
        '
        Me.optFullIsProgressive.AutoSize = True
        Me.optFullIsProgressive.Location = New System.Drawing.Point(6, 48)
        Me.optFullIsProgressive.Name = "optFullIsProgressive"
        Me.optFullIsProgressive.Size = New System.Drawing.Size(113, 17)
        Me.optFullIsProgressive.TabIndex = 1
        Me.optFullIsProgressive.Text = "Lũy tiến toàn phần"
        Me.optFullIsProgressive.UseVisualStyleBackColor = True
        '
        'optPartIsProgressive
        '
        Me.optPartIsProgressive.AutoSize = True
        Me.optPartIsProgressive.Checked = True
        Me.optPartIsProgressive.Location = New System.Drawing.Point(6, 19)
        Me.optPartIsProgressive.Name = "optPartIsProgressive"
        Me.optPartIsProgressive.Size = New System.Drawing.Size(113, 17)
        Me.optPartIsProgressive.TabIndex = 0
        Me.optPartIsProgressive.TabStop = True
        Me.optPartIsProgressive.Text = "Lũy tiến từng phần"
        Me.optPartIsProgressive.UseVisualStyleBackColor = True
        '
        'chkDisabled
        '
        Me.chkDisabled.AutoSize = True
        Me.chkDisabled.Location = New System.Drawing.Point(443, 11)
        Me.chkDisabled.Name = "chkDisabled"
        Me.chkDisabled.Size = New System.Drawing.Size(98, 17)
        Me.chkDisabled.TabIndex = 3
        Me.chkDisabled.Text = "Không sử dụng"
        Me.chkDisabled.UseVisualStyleBackColor = True
        '
        'txtTaxObjectName
        '
        Me.txtTaxObjectName.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTaxObjectName.Location = New System.Drawing.Point(98, 35)
        Me.txtTaxObjectName.MaxLength = 50
        Me.txtTaxObjectName.Name = "txtTaxObjectName"
        Me.txtTaxObjectName.Size = New System.Drawing.Size(443, 22)
        Me.txtTaxObjectName.TabIndex = 5
        '
        'txtTaxObjectID
        '
        Me.txtTaxObjectID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTaxObjectID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtTaxObjectID.Location = New System.Drawing.Point(98, 8)
        Me.txtTaxObjectID.MaxLength = 20
        Me.txtTaxObjectID.Name = "txtTaxObjectID"
        Me.txtTaxObjectID.Size = New System.Drawing.Size(184, 22)
        Me.txtTaxObjectID.TabIndex = 1
        '
        'lblTaxObjectID
        '
        Me.lblTaxObjectID.AutoSize = True
        Me.lblTaxObjectID.Location = New System.Drawing.Point(12, 13)
        Me.lblTaxObjectID.Name = "lblTaxObjectID"
        Me.lblTaxObjectID.Size = New System.Drawing.Size(22, 13)
        Me.lblTaxObjectID.TabIndex = 0
        Me.lblTaxObjectID.Text = "Mã"
        Me.lblTaxObjectID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTaxObjectName
        '
        Me.lblTaxObjectName.AutoSize = True
        Me.lblTaxObjectName.Location = New System.Drawing.Point(12, 40)
        Me.lblTaxObjectName.Name = "lblTaxObjectName"
        Me.lblTaxObjectName.Size = New System.Drawing.Size(48, 13)
        Me.lblTaxObjectName.TabIndex = 4
        Me.lblTaxObjectName.Text = "Diễn giải"
        Me.lblTaxObjectName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(467, 388)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(387, 388)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(76, 22)
        Me.btnNext.TabIndex = 8
        Me.btnNext.Text = "Nhập &tiếp"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'grp5
        '
        Me.grp5.Controls.Add(Me.tdbg)
        Me.grp5.Controls.Add(Me.grpMethodCalTax)
        Me.grp5.Controls.Add(Me.grp3)
        Me.grp5.Location = New System.Drawing.Point(13, 60)
        Me.grp5.Name = "grp5"
        Me.grp5.Size = New System.Drawing.Size(528, 322)
        Me.grp5.TabIndex = 6
        Me.grp5.TabStop = False
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
        Me.tdbg.Location = New System.Drawing.Point(8, 14)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(512, 301)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 0
        Me.tdbg.Tag = "COLD"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'grpMethodCalTax
        '
        Me.grpMethodCalTax.Controls.Add(Me.optPartIsProgressive)
        Me.grpMethodCalTax.Controls.Add(Me.optFullIsProgressive)
        Me.grpMethodCalTax.Location = New System.Drawing.Point(11, 19)
        Me.grpMethodCalTax.Name = "grpMethodCalTax"
        Me.grpMethodCalTax.Size = New System.Drawing.Size(200, 78)
        Me.grpMethodCalTax.TabIndex = 1
        Me.grpMethodCalTax.TabStop = False
        Me.grpMethodCalTax.Text = "Phương pháp tính thuế"
        Me.grpMethodCalTax.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(307, 388)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkIsDefault
        '
        Me.chkIsDefault.AutoSize = True
        Me.chkIsDefault.Location = New System.Drawing.Point(297, 11)
        Me.chkIsDefault.Name = "chkIsDefault"
        Me.chkIsDefault.Size = New System.Drawing.Size(71, 17)
        Me.chkIsDefault.TabIndex = 2
        Me.chkIsDefault.Text = "Mặc định"
        Me.chkIsDefault.UseVisualStyleBackColor = True
        '
        'D13F1011
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(555, 423)
        Me.Controls.Add(Me.chkIsDefault)
        Me.Controls.Add(Me.grp5)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.chkDisabled)
        Me.Controls.Add(Me.txtTaxObjectName)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtTaxObjectID)
        Me.Controls.Add(Me.lblTaxObjectID)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.lblTaxObjectName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1011"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt ¢çi t§íng nèp thuÕ thu nhËp - D13F1011"
        Me.grp3.ResumeLayout(False)
        Me.grp3.PerformLayout()
        Me.grp5.ResumeLayout(False)
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpMethodCalTax.ResumeLayout(False)
        Me.grpMethodCalTax.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents chkDisabled As System.Windows.Forms.CheckBox
    Private WithEvents txtTaxObjectName As System.Windows.Forms.TextBox
    Private WithEvents txtTaxObjectID As System.Windows.Forms.TextBox
    Private WithEvents lblTaxObjectID As System.Windows.Forms.Label
    Private WithEvents lblTaxObjectName As System.Windows.Forms.Label
    Private WithEvents optFullIsProgressive As System.Windows.Forms.RadioButton
    Private WithEvents optPartIsProgressive As System.Windows.Forms.RadioButton

    Friend WithEvents grp3 As System.Windows.Forms.GroupBox
    Private WithEvents optIsPercent1 As System.Windows.Forms.RadioButton
    Private WithEvents optIsPercent2 As System.Windows.Forms.RadioButton
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents grp5 As System.Windows.Forms.GroupBox
    Private WithEvents grpMethodCalTax As System.Windows.Forms.GroupBox
    Private WithEvents chkIsDefault As System.Windows.Forms.CheckBox
End Class
