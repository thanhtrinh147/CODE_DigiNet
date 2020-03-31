<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D13F0050
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D13F0050))
        Me.tdbgMaster = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        CType(Me.tdbgMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbgMaster
        '
        Me.tdbgMaster.AllowColMove = False
        Me.tdbgMaster.AllowColSelect = False
        Me.tdbgMaster.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbgMaster.AllowSort = False
        Me.tdbgMaster.AlternatingRows = True
        Me.tdbgMaster.CaptionHeight = 17
        Me.tdbgMaster.EmptyRows = True
        Me.tdbgMaster.ExtendRightColumn = True
        Me.tdbgMaster.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbgMaster.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbgMaster.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbgMaster.Images.Add(CType(resources.GetObject("tdbgMaster.Images"), System.Drawing.Image))
        Me.tdbgMaster.Location = New System.Drawing.Point(12, 12)
        Me.tdbgMaster.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbgMaster.Name = "tdbgMaster"
        Me.tdbgMaster.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbgMaster.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbgMaster.PreviewInfo.ZoomFactor = 75
        Me.tdbgMaster.PrintInfo.PageSettings = CType(resources.GetObject("tdbgMaster.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbgMaster.RecordSelectorWidth = 19
        Me.tdbgMaster.RowHeight = 15
        Me.tdbgMaster.Size = New System.Drawing.Size(568, 350)
        Me.tdbgMaster.TabAcrossSplits = True
        Me.tdbgMaster.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbgMaster.TabIndex = 0
        Me.tdbgMaster.Tag = "COL"
        Me.tdbgMaster.PropBag = resources.GetString("tdbgMaster.PropBag")
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(425, 370)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 22)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "&Lưu"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(505, 370)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 22)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D13F0050
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 399)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbgMaster)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D13F0050"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mº loÁi ph¡n tÛch tiÒn l§¥ng - D13F0050"
        CType(Me.tdbgMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbgMaster As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
