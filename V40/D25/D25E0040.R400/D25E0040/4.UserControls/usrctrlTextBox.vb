Public Class usrctrlTextBox

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
End Class
