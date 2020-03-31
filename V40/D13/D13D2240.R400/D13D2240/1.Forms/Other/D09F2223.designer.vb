<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class D09F2223
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(D09F2223))
        Me.txtDefaultFolder = New System.Windows.Forms.TextBox
        Me.lblDefaultFolder = New System.Windows.Forms.Label
        Me.btnChoose = New System.Windows.Forms.Button
        Me.lblSheet = New System.Windows.Forms.Label
        Me.cboDefaultSheet = New System.Windows.Forms.ComboBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnExportToExcel = New System.Windows.Forms.Button
        Me.tipSheet = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDisplayColumn = New System.Windows.Forms.TextBox
        Me.lblDisplayColumn = New System.Windows.Forms.Label
        Me.txtDisplayRow = New System.Windows.Forms.TextBox
        Me.lblDisplayRow = New System.Windows.Forms.Label
        Me.chkDisplayHeader = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'txtDefaultFolder
        '
        Me.txtDefaultFolder.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDefaultFolder.Location = New System.Drawing.Point(104, 38)
        Me.txtDefaultFolder.MaxLength = 2000
        Me.txtDefaultFolder.Name = "txtDefaultFolder"
        Me.txtDefaultFolder.Size = New System.Drawing.Size(278, 22)
        Me.txtDefaultFolder.TabIndex = 5
        '
        'lblDefaultFolder
        '
        Me.lblDefaultFolder.AutoSize = True
        Me.lblDefaultFolder.Location = New System.Drawing.Point(13, 43)
        Me.lblDefaultFolder.Name = "lblDefaultFolder"
        Me.lblDefaultFolder.Size = New System.Drawing.Size(60, 13)
        Me.lblDefaultFolder.TabIndex = 4
        Me.lblDefaultFolder.Text = "Đường dẫn"
        Me.lblDefaultFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(388, 38)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(28, 22)
        Me.btnChoose.TabIndex = 6
        Me.btnChoose.Text = "..."
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'lblSheet
        '
        Me.lblSheet.AutoSize = True
        Me.lblSheet.Location = New System.Drawing.Point(434, 43)
        Me.lblSheet.Name = "lblSheet"
        Me.lblSheet.Size = New System.Drawing.Size(35, 13)
        Me.lblSheet.TabIndex = 7
        Me.lblSheet.Text = "Sheet"
        Me.lblSheet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboDefaultSheet
        '
        Me.cboDefaultSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultSheet.DropDownWidth = 88
        Me.cboDefaultSheet.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.cboDefaultSheet.FormattingEnabled = True
        Me.cboDefaultSheet.Location = New System.Drawing.Point(501, 38)
        Me.cboDefaultSheet.Name = "cboDefaultSheet"
        Me.cboDefaultSheet.Size = New System.Drawing.Size(76, 22)
        Me.cboDefaultSheet.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(501, 76)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(76, 22)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Đó&ng"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnExportToExcel
        '
        Me.btnExportToExcel.Location = New System.Drawing.Point(403, 76)
        Me.btnExportToExcel.Name = "btnExportToExcel"
        Me.btnExportToExcel.Size = New System.Drawing.Size(92, 22)
        Me.btnExportToExcel.TabIndex = 9
        Me.btnExportToExcel.Text = "Xuất Excel"
        Me.btnExportToExcel.UseVisualStyleBackColor = True
        '
        'txtDisplayColumn
        '
        Me.txtDisplayColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDisplayColumn.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDisplayColumn.Location = New System.Drawing.Point(104, 10)
        Me.txtDisplayColumn.MaxLength = 20
        Me.txtDisplayColumn.Name = "txtDisplayColumn"
        Me.txtDisplayColumn.Size = New System.Drawing.Size(88, 22)
        Me.txtDisplayColumn.TabIndex = 1
        Me.txtDisplayColumn.TabStop = False
        Me.txtDisplayColumn.Text = "A"
        '
        'lblDisplayColumn
        '
        Me.lblDisplayColumn.AutoSize = True
        Me.lblDisplayColumn.Location = New System.Drawing.Point(13, 15)
        Me.lblDisplayColumn.Name = "lblDisplayColumn"
        Me.lblDisplayColumn.Size = New System.Drawing.Size(60, 13)
        Me.lblDisplayColumn.TabIndex = 0
        Me.lblDisplayColumn.Text = "Cột hiển thị"
        Me.lblDisplayColumn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDisplayRow
        '
        Me.txtDisplayRow.Font = New System.Drawing.Font("Lemon3", 8.249999!)
        Me.txtDisplayRow.Location = New System.Drawing.Point(294, 10)
        Me.txtDisplayRow.Name = "txtDisplayRow"
        Me.txtDisplayRow.Size = New System.Drawing.Size(88, 22)
        Me.txtDisplayRow.TabIndex = 3
        Me.txtDisplayRow.TabStop = False
        Me.txtDisplayRow.Text = "11"
        Me.txtDisplayRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblDisplayRow
        '
        Me.lblDisplayRow.AutoSize = True
        Me.lblDisplayRow.Location = New System.Drawing.Point(205, 15)
        Me.lblDisplayRow.Name = "lblDisplayRow"
        Me.lblDisplayRow.Size = New System.Drawing.Size(70, 13)
        Me.lblDisplayRow.TabIndex = 2
        Me.lblDisplayRow.Text = "Dòng hiển thị"
        Me.lblDisplayRow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDisplayHeader
        '
        Me.chkDisplayHeader.AutoSize = True
        Me.chkDisplayHeader.Location = New System.Drawing.Point(437, 14)
        Me.chkDisplayHeader.Name = "chkDisplayHeader"
        Me.chkDisplayHeader.Size = New System.Drawing.Size(116, 17)
        Me.chkDisplayHeader.TabIndex = 11
        Me.chkDisplayHeader.Text = "Hiển thị tiêu đề cột"
        Me.chkDisplayHeader.UseVisualStyleBackColor = True
        '
        'D09F2223
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 105)
        Me.Controls.Add(Me.chkDisplayHeader)
        Me.Controls.Add(Me.txtDisplayRow)
        Me.Controls.Add(Me.txtDisplayColumn)
        Me.Controls.Add(Me.btnExportToExcel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblSheet)
        Me.Controls.Add(Me.cboDefaultSheet)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.txtDefaultFolder)
        Me.Controls.Add(Me.lblDefaultFolder)
        Me.Controls.Add(Me.lblDisplayColumn)
        Me.Controls.Add(Me.lblDisplayRow)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "D09F2223"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "XuÊt Excel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtDefaultFolder As System.Windows.Forms.TextBox
    Private WithEvents lblDefaultFolder As System.Windows.Forms.Label
    Private WithEvents btnChoose As System.Windows.Forms.Button
    Private WithEvents lblSheet As System.Windows.Forms.Label
    Private WithEvents cboDefaultSheet As System.Windows.Forms.ComboBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExportToExcel As System.Windows.Forms.Button
    Friend WithEvents tipSheet As System.Windows.Forms.ToolTip
    Private WithEvents txtDisplayColumn As System.Windows.Forms.TextBox
    Private WithEvents lblDisplayColumn As System.Windows.Forms.Label
    Private WithEvents txtDisplayRow As System.Windows.Forms.TextBox
    Private WithEvents lblDisplayRow As System.Windows.Forms.Label
    Private WithEvents chkDisplayHeader As System.Windows.Forms.CheckBox
End Class
