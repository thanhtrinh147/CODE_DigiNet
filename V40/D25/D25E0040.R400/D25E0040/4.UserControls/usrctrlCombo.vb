Imports System
Public Class usrctrlCombo
    Private _sQLSource As String
    Public Property SQLSource() As String
        Get
            Return _sQLSource
        End Get
        Set(ByVal Value As String)
            _sQLSource = Value
        End Set
    End Property

    Private _saveType As String
    Public WriteOnly Property SaveType() As String
        Set(ByVal Value As String)
            _saveType = Value
        End Set
    End Property

    Public FormID As String

    Public FieldName As String
    Public bAllowListSelectedValueChange2 As Boolean = False

#Region "Events tdbcXXX"

    Private Sub tdbcXXX_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcXXX.Close
       
        If _saveType <> "1" Then
            If tdbcXXX.FindStringExact(tdbcXXX.Text) = -1 Then tdbcXXX.Text = ""
        End If

    End Sub

    Private Sub tdbcXXX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcXXX.KeyDown
        If _saveType <> "1" Then
            If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcXXX.Text = ""
        End If

       
        If e.KeyCode = Keys.F2 Then
            If FieldName = "FileReceiver" Then
                '                Dim f As New D91F6010
                '                f.InListID = "39"
                '                f.InWhere = ""
                '                f.ShowDialog()
                '
                '                tdbcXXX.SelectedValue = f.OutPut01
                Try
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "InListID", "39")
                    SetProperties(arrPro, "InWhere", "")
                    Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                    Dim sKey As String = GetProperties(frm, "Output01").ToString
                    If sKey <> "" Then
                        tdbcXXX.SelectedValue = sKey
                    End If
                Catch ex As Exception
                    D99C0008.MsgL3(ex.Message)
                End Try
            End If
        End If
    End Sub

#End Region

    Public Sub LoadCombosource()
        LoadDataSource(tdbcXXX, _sQLSource, gbUnicode)
    End Sub



    Private Sub tdbcXXX_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcXXX.SelectedValueChanged
        Try

            With tdbcXXX

                If ComboValue(tdbcXXX) = "+" Then
                    .Text = ""
                    Select Case FieldName
                        Case "Relationship"
                            If ReturnPermission_OldVersion("D09F0128") < EnumPermission.Add Then
                                MsgNoPermissionAdd()
                            Else
                                Dim arrPro() As StructureProperties = Nothing
                                '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                                SetProperties(arrPro, "FormIDPermission", "D09F0128")
                                Dim frm As Form = CallFormShow(Me.ParentForm, "D09D0140", "D09F0129", arrPro)
                                If L3Bool(GetProperties(frm, "bSaved")) Then
                                    LoadCombosource()
                                    .SelectedValue = L3String(GetProperties(frm, "RelationID"))
                                End If


                                '                                Dim f As New D09F0129
                                '                                f.ShowDialog()
                                '                                f.Dispose()
                                '                                'If gbSavedOk = True Then
                                '                                LoadCombosource()
                                '                                .SelectedValue = f.RelationID
                                '                                .Focus()
                                
                            End If


                        Case "ShiftID"
                            If ReturnPermission_OldVersion("D29F1010") < EnumPermission.Add Then
                                MsgNoPermissionAdd()
                            Else
                                Dim arrPro() As StructureProperties = Nothing
                                '  SetProperties(arrPro, xxxxxx, DxxFxxxxx)
                                SetProperties(arrPro, "FormIDPermission", "D29F1010")
                                Dim frm As Form = CallFormShow(Me.ParentForm, "D29D0140", "D29F1011", arrPro)
                                If L3Bool(GetProperties(frm, "bSaved")) Then
                                    LoadCombosource()
                                    .SelectedValue = L3String(GetProperties(frm, "ShiftID"))
                                Else
                                    .SelectedValue = ""
                                End If
                                '                                Dim f As New D29F1010
                                '                                f.ShowDialog()
                                '                                f.Dispose()
                                '                                If f.SuccessfulSave = True Then
                                '                                    LoadCombosource()
                                '                                    .SelectedValue = f.ShiftID
                                '                                Else
                                '                                    .SelectedValue = ""
                                '                                End If
                            End If

                    End Select
                    .Focus()
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub
End Class
