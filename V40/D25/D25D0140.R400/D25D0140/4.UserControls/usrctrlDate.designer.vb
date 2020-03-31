<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class usrctrlDate
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
        Me.c1dateXXX = New C1.Win.C1Input.C1DateEdit
        Me.lblteXXX = New System.Windows.Forms.Label
        CType(Me.c1dateXXX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'c1dateXXX
        '
        Me.c1dateXXX.AutoSize = False
        Me.c1dateXXX.CustomFormat = "dd/MM/yyyy"
        Me.c1dateXXX.EmptyAsNull = True
        Me.c1dateXXX.Font = New System.Drawing.Font("Lemon3", 8.25!)
        Me.c1dateXXX.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.c1dateXXX.Location = New System.Drawing.Point(125, 0)
        Me.c1dateXXX.Name = "c1dateXXX"
        Me.c1dateXXX.Size = New System.Drawing.Size(100, 22)
        Me.c1dateXXX.TabIndex = 0
        Me.c1dateXXX.Tag = Nothing
        Me.c1dateXXX.TrimStart = True
        Me.c1dateXXX.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblteXXX
        '
        Me.lblteXXX.AutoSize = True
        Me.lblteXXX.Font = New System.Drawing.Font("Lemon3", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblteXXX.Location = New System.Drawing.Point(0, 4)
        Me.lblteXXX.Name = "lblteXXX"
        Me.lblteXXX.Size = New System.Drawing.Size(31, 14)
        Me.lblteXXX.TabIndex = 1
        Me.lblteXXX.Text = "XXX"
        Me.lblteXXX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'usrctrlDate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.c1dateXXX)
        Me.Controls.Add(Me.lblteXXX)
        Me.Name = "usrctrlDate"
        Me.Size = New System.Drawing.Size(225, 22)
        CType(Me.c1dateXXX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents c1dateXXX As C1.Win.C1Input.C1DateEdit
    Private WithEvents lblteXXX As System.Windows.Forms.Label

End Class
