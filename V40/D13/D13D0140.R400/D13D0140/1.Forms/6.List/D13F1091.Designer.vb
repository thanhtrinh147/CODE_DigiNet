<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F1091
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F1091))
        Me.txtPAnaCategoryID = New System.Windows.Forms.TextBox
        Me.lblPAnaCategoryID = New System.Windows.Forms.Label
        Me.txtPAnaCategoryName01 = New System.Windows.Forms.TextBox
        Me.lblPAnaCategoryName01 = New System.Windows.Forms.Label
        Me.txtPAnaCategoryName84 = New System.Windows.Forms.TextBox
        Me.tdbgDetail = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtPAnaCategoryID
        '
        Me.txtPAnaCategoryID.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPAnaCategoryID.Location = New System.Drawing.Point(114, 12)
        Me.txtPAnaCategoryID.Name = "txtPAnaCategoryID"
        Me.txtPAnaCategoryID.Size = New System.Drawing.Size(157, 22)
        Me.txtPAnaCategoryID.TabIndex = 0
        '
        'lblPAnaCategoryID
        '
        Me.lblPAnaCategoryID.AutoSize = True
        Me.lblPAnaCategoryID.Location = New System.Drawing.Point(9, 16)
        Me.lblPAnaCategoryID.Name = "lblPAnaCategoryID"
        Me.lblPAnaCategoryID.Size = New System.Drawing.Size(90, 13)
        Me.lblPAnaCategoryID.TabIndex = 1
        Me.lblPAnaCategoryID.Text = "Mã loại phân tích"
        Me.lblPAnaCategoryID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPAnaCategoryName01
        '
        Me.txtPAnaCategoryName01.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPAnaCategoryName01.Location = New System.Drawing.Point(114, 40)
        Me.txtPAnaCategoryName01.Name = "txtPAnaCategoryName01"
        Me.txtPAnaCategoryName01.Size = New System.Drawing.Size(594, 22)
        Me.txtPAnaCategoryName01.TabIndex = 2
        '
        'lblPAnaCategoryName01
        '
        Me.lblPAnaCategoryName01.AutoSize = True
        Me.lblPAnaCategoryName01.Location = New System.Drawing.Point(9, 44)
        Me.lblPAnaCategoryName01.Name = "lblPAnaCategoryName01"
        Me.lblPAnaCategoryName01.Size = New System.Drawing.Size(94, 13)
        Me.lblPAnaCategoryName01.TabIndex = 3
        Me.lblPAnaCategoryName01.Text = "Tên loại phân tích"
        Me.lblPAnaCategoryName01.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPAnaCategoryName84
        '
        Me.txtPAnaCategoryName84.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtPAnaCategoryName84.Location = New System.Drawing.Point(114, 40)
        Me.txtPAnaCategoryName84.Name = "txtPAnaCategoryName84"
        Me.txtPAnaCategoryName84.Size = New System.Drawing.Size(593, 22)
        Me.txtPAnaCategoryName84.TabIndex = 4
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
        Me.tdbgDetail.Location = New System.Drawing.Point(11, 68)
        Me.tdbgDetail.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgDetail.Name = "tdbgDetail"
        Me.tdbgDetail.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgDetail.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgDetail.PreviewInfo.ZoomFactor = 75
        Me.tdbgDetail.PrintInfo.PageSettings = CType(resources.GetObject("tdbgDetail.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgDetail.RowHeight = 15
        Me.tdbgDetail.Size = New System.Drawing.Size(696, 287)
        Me.tdbgDetail.TabAcrossSplits = True
        Me.tdbgDetail.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgDetail.TabIndex = 5
        Me.tdbgDetail.Tag = "COL"
        Me.tdbgDetail.WrapCellPointer = True
        Me.tdbgDetail.PropBag = resources.GetString("tdbgDetail.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(553, 362)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 22)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(633, 362)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 22)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D13F1091
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 392)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbgDetail)
        Me.Controls.Add(Me.txtPAnaCategoryName84)
        Me.Controls.Add(Me.txtPAnaCategoryName01)
        Me.Controls.Add(Me.txtPAnaCategoryID)
        Me.Controls.Add(Me.lblPAnaCategoryID)
        Me.Controls.Add(Me.lblPAnaCategoryName01)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F1091"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CËp nhËt mº ph¡n tÛch tiÒn l§¥ng - D13F1091"
        CType(Me.tdbgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtPAnaCategoryID As System.Windows.Forms.TextBox
    Private WithEvents lblPAnaCategoryID As System.Windows.Forms.Label
    Private WithEvents txtPAnaCategoryName01 As System.Windows.Forms.TextBox
    Private WithEvents lblPAnaCategoryName01 As System.Windows.Forms.Label
    Private WithEvents txtPAnaCategoryName84 As System.Windows.Forms.TextBox
    Private WithEvents tdbgDetail As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
