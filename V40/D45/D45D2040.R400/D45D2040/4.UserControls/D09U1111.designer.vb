<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D09U1111
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D09U1111))
        Me.btnSave = New System.Windows.Forms.Button
        Me.lbl1 = New System.Windows.Forms.Label
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.picClose = New System.Windows.Forms.PictureBox
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(182, 356)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(76, 22)
        Me.btnSave.TabIndex = 3
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
        Me.btnRefresh.Location = New System.Drawing.Point(100, 356)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(76, 22)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "&Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'picClose
        '
        Me.picClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picClose.Image = CType(resources.GetObject("picClose.Image"), System.Drawing.Image)
        Me.picClose.Location = New System.Drawing.Point(251, 3)
        Me.picClose.Name = "picClose"
        Me.picClose.Size = New System.Drawing.Size(14, 15)
        Me.picClose.TabIndex = 20
        Me.picClose.TabStop = False
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
        Me.tdbg.Location = New System.Drawing.Point(8, 26)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(250, 324)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabIndex = 1
        Me.tdbg.Tag = "COL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'D09U1111
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.picClose)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.lbl1)
        Me.Name = "D09U1111"
        Me.Size = New System.Drawing.Size(265, 385)
        CType(Me.picClose, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents picClose As System.Windows.Forms.PictureBox
    Private WithEvents btnSave As System.Windows.Forms.Button
    Private WithEvents lbl1 As System.Windows.Forms.Label
    Private WithEvents btnRefresh As System.Windows.Forms.Button

End Class
