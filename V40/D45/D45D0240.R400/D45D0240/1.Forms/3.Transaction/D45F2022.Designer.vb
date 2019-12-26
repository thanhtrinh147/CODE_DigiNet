<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D45F2022
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D45F2022))
        Me.grpData = New System.Windows.Forms.GroupBox
        Me.optMode2 = New System.Windows.Forms.RadioButton
        Me.optMode1 = New System.Windows.Forms.RadioButton
        Me.optMode0 = New System.Windows.Forms.RadioButton
        Me.btnChoose = New System.Windows.Forms.Button
        Me.btnCaculate = New System.Windows.Forms.Button
        Me.tdbg = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.btnContinue = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.grpData.SuspendLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpData
        '
        Me.grpData.Controls.Add(Me.optMode2)
        Me.grpData.Controls.Add(Me.optMode1)
        Me.grpData.Controls.Add(Me.optMode0)
        Me.grpData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpData.Location = New System.Drawing.Point(12, 7)
        Me.grpData.Name = "grpData"
        Me.grpData.Size = New System.Drawing.Size(994, 50)
        Me.grpData.TabIndex = 0
        Me.grpData.TabStop = False
        Me.grpData.Text = "Chuyển dữ liệu"
        '
        'optMode2
        '
        Me.optMode2.AutoSize = True
        Me.optMode2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMode2.Location = New System.Drawing.Point(721, 25)
        Me.optMode2.Name = "optMode2"
        Me.optMode2.Size = New System.Drawing.Size(114, 17)
        Me.optMode2.TabIndex = 2
        Me.optMode2.Text = "Tổng hợp số lượng"
        Me.optMode2.UseVisualStyleBackColor = True
        '
        'optMode1
        '
        Me.optMode1.AutoSize = True
        Me.optMode1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMode1.Location = New System.Drawing.Point(351, 25)
        Me.optMode1.Name = "optMode1"
        Me.optMode1.Size = New System.Drawing.Size(144, 17)
        Me.optMode1.TabIndex = 1
        Me.optMode1.Text = "Tổng hợp theo sản phẩm"
        Me.optMode1.UseVisualStyleBackColor = True
        '
        'optMode0
        '
        Me.optMode0.AutoSize = True
        Me.optMode0.Checked = True
        Me.optMode0.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.optMode0.Location = New System.Drawing.Point(68, 25)
        Me.optMode0.Name = "optMode0"
        Me.optMode0.Size = New System.Drawing.Size(57, 17)
        Me.optMode0.TabIndex = 0
        Me.optMode0.TabStop = True
        Me.optMode0.Text = "Chi tiết"
        Me.optMode0.UseVisualStyleBackColor = True
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(12, 71)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(100, 22)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "&Chọn sản phẩm"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'btnCaculate
        '
        Me.btnCaculate.Location = New System.Drawing.Point(922, 71)
        Me.btnCaculate.Name = "btnCaculate"
        Me.btnCaculate.Size = New System.Drawing.Size(84, 22)
        Me.btnCaculate.TabIndex = 2
        Me.btnCaculate.Text = "Tín&h"
        Me.btnCaculate.UseVisualStyleBackColor = True
        '
        'tdbg
        '
        Me.tdbg.AllowColMove = False
        Me.tdbg.AllowColSelect = False
        Me.tdbg.AllowFilter = False
        Me.tdbg.AllowRowSizing = C1.Win.C1TrueDBGrid.RowSizingEnum.None
        Me.tdbg.AllowUpdate = False
        Me.tdbg.AlternatingRows = True
        Me.tdbg.CaptionHeight = 17
        Me.tdbg.ColumnFooters = True
        Me.tdbg.EmptyRows = True
        Me.tdbg.ExtendRightColumn = True
        Me.tdbg.FilterBar = True
        Me.tdbg.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Standard
        Me.tdbg.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbg.GroupByCaption = "Drag a column header here to group by that column"
        Me.tdbg.Images.Add(CType(resources.GetObject("tdbg.Images"), System.Drawing.Image))
        Me.tdbg.Location = New System.Drawing.Point(12, 102)
        Me.tdbg.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.tdbg.Name = "tdbg"
        Me.tdbg.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.tdbg.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.tdbg.PreviewInfo.ZoomFactor = 75
        Me.tdbg.PrintInfo.PageSettings = CType(resources.GetObject("tdbg.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.tdbg.RowHeight = 15
        Me.tdbg.Size = New System.Drawing.Size(994, 517)
        Me.tdbg.TabAcrossSplits = True
        Me.tdbg.TabAction = C1.Win.C1TrueDBGrid.TabActionEnum.ColumnNavigation
        Me.tdbg.TabIndex = 3
        Me.tdbg.Tag = "COL"
        Me.tdbg.PropBag = resources.GetString("tdbg.PropBag")
        '
        'btnContinue
        '
        Me.btnContinue.Location = New System.Drawing.Point(841, 626)
        Me.btnContinue.Name = "btnContinue"
        Me.btnContinue.Size = New System.Drawing.Size(83, 22)
        Me.btnContinue.TabIndex = 4
        Me.btnContinue.Text = "&Tiếp tục"
        Me.btnContinue.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(930, 626)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'D45F2022
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 655)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnContinue)
        Me.Controls.Add(Me.tdbg)
        Me.Controls.Add(Me.btnCaculate)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.grpData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D45F2022"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ph§¥ng th÷c tÁo phiÕu chÊm c¤ng - D45F2022"
        Me.grpData.ResumeLayout(False)
        Me.grpData.PerformLayout()
        CType(Me.tdbg, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpData As System.Windows.Forms.GroupBox
    Private WithEvents optMode2 As System.Windows.Forms.RadioButton
    Private WithEvents optMode1 As System.Windows.Forms.RadioButton
    Private WithEvents optMode0 As System.Windows.Forms.RadioButton
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents btnCaculate As System.Windows.Forms.Button
    Private WithEvents tdbg As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents btnContinue As System.Windows.Forms.Button
    Private WithEvents btnClose As System.Windows.Forms.Button
End Class
