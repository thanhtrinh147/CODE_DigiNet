Imports System

Public Class usrctrlTextBox
    Public sFieldName As String

    Private _sCandidateID As String
    Public Property  sCandidateID() As String
        Get
            Return _sCandidateID
        End Get
        Set(ByVal Value As String)
            _sCandidateID = Value
        End Set
    End Property

    Private _txt As TextBox
    Public Property Txt() As TextBox
        Get
            Return _txt
        End Get
        Set(ByVal value As TextBox)
            _txt = value
        End Set
    End Property

    Private Sub txtXXX_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtXXX.KeyPress
        If txtXXX.TextAlign = HorizontalAlignment.Right Then
            e.Handled = CheckKeyPress(e.KeyChar, EnumKey.NumberDot)
        End If

    End Sub

    Private Sub txtXXX_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXXX.LostFocus
        If txtXXX.TextAlign = HorizontalAlignment.Right Then
            txtXXX.Text = Format(Number(txtXXX.Text), D25Format.DefaultNumber2)
        End If
    End Sub

    Private Sub txtXXX_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtXXX.Validated
        With txtXXX
            Select Case sFieldName
                Case "Telephone"
                    If txtXXX.Text <> "" Then
                        If L3String(txtXXX.Tag) <> txtXXX.Text Then
                            txtXXX.Tag = txtXXX.Text
                            If CheckStore(SQLStoreD25P5555("D25F1051", txtXXX.Text, Txt.Text, 2, 1)) = False Then txtXXX.Focus()
                        End If
                    End If
                Case "Mobile"
                    If txtXXX.Text <> "" Then
                        If L3String(txtXXX.Tag) <> txtXXX.Text Then
                            txtXXX.Tag = txtXXX.Text
                            If CheckStore(SQLStoreD25P5555("D25F1051", txtXXX.Text, Txt.Text, 2, 2)) = False Then txtXXX.Focus()
                        End If
                    End If
            End Select

        End With
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal clr As Color)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        txtXXX.BackColor = clr
        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class
