<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrctrlCombo
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
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(usrctrlCombo))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.tdbcXXX = New C1.Win.C1List.C1Combo
        Me.lblXXX = New System.Windows.Forms.Label
        CType(Me.tdbcXXX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tdbcXXX
        '
        Me.tdbcXXX.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.tdbcXXX.AllowColMove = False
        Me.tdbcXXX.AllowSort = False
        Me.tdbcXXX.AlternatingRows = True
        Me.tdbcXXX.AutoCompletion = True
        Me.tdbcXXX.AutoDropDown = True
        Me.tdbcXXX.Caption = ""
        Me.tdbcXXX.CaptionHeight = 17
        Me.tdbcXXX.CaptionStyle = Style1
        Me.tdbcXXX.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.tdbcXXX.ColumnCaptionHeight = 17
        Me.tdbcXXX.ColumnFooterHeight = 17
        Me.tdbcXXX.ColumnWidth = 100
        Me.tdbcXXX.ContentHeight = 17
        Me.tdbcXXX.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.tdbcXXX.DisplayMember = "Name"
        Me.tdbcXXX.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.tdbcXXX.DropDownWidth = 300
        Me.tdbcXXX.EditorBackColor = System.Drawing.SystemColors.Window
        Me.tdbcXXX.EditorFont = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcXXX.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.tdbcXXX.EditorHeight = 17
        Me.tdbcXXX.EmptyRows = True
        Me.tdbcXXX.EvenRowStyle = Style2
        Me.tdbcXXX.ExtendRightColumn = True
        Me.tdbcXXX.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.tdbcXXX.FooterStyle = Style3
        Me.tdbcXXX.HeadingStyle = Style4
        Me.tdbcXXX.HighLightRowStyle = Style5
        Me.tdbcXXX.Images.Add(CType(resources.GetObject("tdbcXXX.Images"), System.Drawing.Image))
        Me.tdbcXXX.ItemHeight = 15
        Me.tdbcXXX.Location = New System.Drawing.Point(125, 0)
        Me.tdbcXXX.MatchEntryTimeout = CType(2000, Long)
        Me.tdbcXXX.MaxDropDownItems = CType(8, Short)
        Me.tdbcXXX.MaxLength = 32767
        Me.tdbcXXX.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.tdbcXXX.Name = "tdbcXXX"
        Me.tdbcXXX.OddRowStyle = Style6
        Me.tdbcXXX.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.tdbcXXX.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.tdbcXXX.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.tdbcXXX.SelectedStyle = Style7
        Me.tdbcXXX.Size = New System.Drawing.Size(190, 23)
        Me.tdbcXXX.Style = Style8
        Me.tdbcXXX.TabIndex = 2
        Me.tdbcXXX.ValueMember = "Code"
        Me.tdbcXXX.PropBag = resources.GetString("tdbcXXX.PropBag")
        '
        'lblXXX
        '
        Me.lblXXX.AutoSize = True
        Me.lblXXX.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblXXX.Location = New System.Drawing.Point(0, 4)
        Me.lblXXX.Name = "lblXXX"
        Me.lblXXX.Size = New System.Drawing.Size(31, 14)
        Me.lblXXX.TabIndex = 3
        Me.lblXXX.Text = "XXX"
        Me.lblXXX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'usrctrlCombo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.tdbcXXX)
        Me.Controls.Add(Me.lblXXX)
        Me.Name = "usrctrlCombo"
        Me.Size = New System.Drawing.Size(315, 23)
        CType(Me.tdbcXXX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tdbcXXX As C1.Win.C1List.C1Combo
    Private WithEvents lblXXX As System.Windows.Forms.Label

End Class
