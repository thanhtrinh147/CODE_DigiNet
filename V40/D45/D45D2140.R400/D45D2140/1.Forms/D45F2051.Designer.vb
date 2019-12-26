<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2051
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2051))
        Me.lblPartProductName = New System.Windows.Forms.Label()
        Me.lblSelect = New System.Windows.Forms.Label()
        Me.cneSumQuantity = New C1.Win.C1Input.C1NumericEdit()
        Me.lblSumQuantity = New System.Windows.Forms.Label()
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.lblEmpQuantity = New System.Windows.Forms.Label()
        Me.grp1 = New System.Windows.Forms.GroupBox()
        Me.tdbg1 = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.cneSumQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblPartProductName
        '
        Me.lblPartProductName.AutoSize = True
        Me.lblPartProductName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPartProductName.Location = New System.Drawing.Point(6, 16)
        Me.lblPartProductName.Name = "lblPartProductName"
        Me.lblPartProductName.Size = New System.Drawing.Size(123, 13)
        Me.lblPartProductName.TabIndex = 0
        Me.lblPartProductName.Text = "Sao chép từ tiểu tác"
        Me.lblPartProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSelect
        '
        Me.lblSelect.AutoSize = True
        Me.lblSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelect.Location = New System.Drawing.Point(6, 44)
        Me.lblSelect.Name = "lblSelect"
        Me.lblSelect.Size = New System.Drawing.Size(189, 13)
        Me.lblSelect.TabIndex = 1
        Me.lblSelect.Text = "Chọn các tiểu tác cần sao chép"
        Me.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cneSumQuantity
        '
        Me.cneSumQuantity.AutoSize = False
        Me.cneSumQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cneSumQuantity.Location = New System.Drawing.Point(872, 11)
        Me.cneSumQuantity.Name = "cneSumQuantity"
        Me.cneSumQuantity.ReadOnly = True
        Me.cneSumQuantity.Size = New System.Drawing.Size(127, 22)
        Me.cneSumQuantity.TabIndex = 2
        Me.cneSumQuantity.Tag = Nothing
        Me.cneSumQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneSumQuantity.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblSumQuantity
        '
        Me.lblSumQuantity.AutoSize = True
        Me.lblSumQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSumQuantity.Location = New System.Drawing.Point(793, 16)
        Me.lblSumQuantity.Name = "lblSumQuantity"
        Me.lblSumQuantity.Size = New System.Drawing.Size(64, 13)
        Me.lblSumQuantity.TabIndex = 3
        Me.lblSumQuantity.Text = "Sản lượng"
        Me.lblSumQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowSort = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FetchRowStyles = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(7, 72)
        Me.tdbg.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(995, 213)
        Me.tdbg.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 4
        Me.tdbg.Tag = "sCOL"
        Me.tdbg.WrapCellPointer = True
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'lblEmpQuantity
        '
        Me.lblEmpQuantity.AutoSize = True
        Me.lblEmpQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpQuantity.Location = New System.Drawing.Point(4, 298)
        Me.lblEmpQuantity.Name = "lblEmpQuantity"
        Me.lblEmpQuantity.Size = New System.Drawing.Size(146, 13)
        Me.lblEmpQuantity.TabIndex = 5
        Me.lblEmpQuantity.Text = "Sản lượng cần thực hiện"
        Me.lblEmpQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grp1
        '
        Me.grp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grp1.Location = New System.Drawing.Point(112, 305)
        Me.grp1.Name = "grp1"
        Me.grp1.Size = New System.Drawing.Size(900, 3)
        Me.grp1.TabIndex = 6
        Me.grp1.TabStop = False
        '
        'tdbg1
        '
        Me.tdbg1.AllowColMove = False
        Me.tdbg1.AllowColSelect = False
        Me.tdbg1.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg1.AllowSort = False
        Me.tdbg1.AlternatingRows = True
        Me.tdbg1.CaptionHeight = 17
        Me.tdbg1.ColumnFooters = True
        Me.tdbg1.EmptyRows = True
        Me.tdbg1.ExtendRightColumn = True
        Me.tdbg1.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg1.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg1.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg1.Images.Add(CType(resources.GetObject("tdbg1.Images"), System.Drawing.Image))
        Me.tdbg1.Location = New System.Drawing.Point(7, 325)
        Me.tdbg1.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.FloatingEditor
        Me.tdbg1.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg1.Name = "tdbg1"
        Me.tdbg1.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg1.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg1.PreviewInfo.ZoomFactor = 75.0R
        Me.tdbg1.PrintInfo.PageSettings = CType(resources.GetObject("tdbg1.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg1.RowHeight = 15
        Me.tdbg1.Size = New System.Drawing.Size(995, 287)
        Me.tdbg1.SplitDividerSize = New System.Drawing.Size(1, 1)
        Me.tdbg1.TabAcrossSplits = True
        Me.tdbg1.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg1.TabIndex = 7
        Me.tdbg1.Tag = "sCOL1"
        Me.tdbg1.WrapCellPointer = True
        Me.tdbg1.PropBag = resources.GetString("tdbg1.PropBag")
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(926, 618)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(76, 22)
        Me.btnCopy.TabIndex = 8
        Me.btnCopy.Text = "&Sao chép"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(128, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(900, 3)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'D45F2051
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 645)
        Me.Controls.Add(Me.lblSelect)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.tdbg1)
        Me.Controls.Add(Me.lblEmpQuantity)
        Me.Controls.Add(Me.grp1)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.cneSumQuantity)
        Me.Controls.Add(Me.lblPartProductName)
        Me.Controls.Add(Me.lblSumQuantity)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2051"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sao chÏp nh¡n vi£n tô tiÓu tÀc - D45F2051"
        CType(Me.cneSumQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tdbg1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblPartProductName As System.Windows.Forms.Label
    Private WithEvents lblSelect As System.Windows.Forms.Label
    Private WithEvents cneSumQuantity As C1.Win.C1Input.C1NumericEdit
    Private WithEvents lblSumQuantity As System.Windows.Forms.Label
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents lblEmpQuantity As System.Windows.Forms.Label
    Private WithEvents grp1 As System.Windows.Forms.GroupBox
    Private WithEvents tdbg1 As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnCopy As System.Windows.Forms.Button
    Private WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
