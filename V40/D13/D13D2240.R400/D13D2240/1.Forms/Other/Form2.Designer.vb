<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Me.C1FlexGrid1 = New C1.Win.C1FlexGrid.C1FlexGrid
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1FlexGrid1
        '
        Me.C1FlexGrid1.ColumnInfo = "11,1,0,0,0,85,Columns:0{Caption:""Cột 1"";Style:""DataType:System.Double;TextAlign:R" & _
            "ightCenter;ImageAlign:CenterCenter;"";StyleFixed:""ImageAlign:LeftTop;"";}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.C1FlexGrid1.Location = New System.Drawing.Point(81, 43)
        Me.C1FlexGrid1.Name = "C1FlexGrid1"
        Me.C1FlexGrid1.Rows.Count = 13
        Me.C1FlexGrid1.Rows.DefaultSize = 17
        Me.C1FlexGrid1.Size = New System.Drawing.Size(596, 340)
        Me.C1FlexGrid1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 479)
        Me.Controls.Add(Me.C1FlexGrid1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        CType(Me.C1FlexGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1FlexGrid1 As C1.Win.C1FlexGrid.C1FlexGrid
End Class
