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

    Private _divisionIDValue As String
    Public WriteOnly Property DivisionIDValue() As String
        Set(ByVal Value As String)
            _divisionIDValue = Value
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

    Private Sub tdbcXXX_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcXXX.GotFocus
        Select Case FieldName
            'Case "RecDepartmentID"
            '    If gsDivisionIDValue = gsOldDivisionIDValue Then Exit Sub
            '    gsOldDivisionIDValue = gsDivisionIDValue
            '    Try
            '        Try
            '            Dim sSQL1 As New StringBuilder
            '            sSQL1.Append("Select DepartmentID as Code, DepartmentName" & UnicodeJoin(gbUnicode) & " as Name, DivisionID, BlockID")
            '            sSQL1.Append(" From 	D91T0012 WITH(NOLOCK) ")
            '            sSQL1.Append(" Where 	Disabled= 0 And DivisionID=" & SQLString(gsDivisionIDValue))
            '            '*******************************
            '            _sQLSource = sSQL1.ToString
            '            LoadCombosource()
            '        Catch ex As Exception

            '        End Try
            '    Catch ex As Exception

            '    End Try
        End Select
    End Sub

    Private Sub tdbcXXX_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcXXX.KeyDown
        'If _saveType <> "1" Then
        '    If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then tdbcXXX.Text = ""
        'End If


        If e.KeyCode = Keys.F2 Then
            If FieldName = "FileReceiver" Then
                'Dim f As New D91F6010
                'f.InListID = "39"
                'f.InWhere = ""
                'f.ShowDialog()

                'tdbcXXX.SelectedValue = f.OutPut01

                'ID 79397 4/9/2015
                Try
                    Dim arrPro() As StructureProperties = Nothing
                    SetProperties(arrPro, "InListID", "39")
                    SetProperties(arrPro, "InWhere", "")
                    Dim frm As Form = CallFormShowDialog("D91D0240", "D91F6010", arrPro)
                    Dim sKey As String = GetProperties(frm, "Output01").ToString
                    If sKey <> "" Then
                        'Load dữ liệu
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
                If ReturnValueC1Combo(tdbcXXX) = "+" Then
                    .Text = ""
                    Select Case FieldName
                        Case "Relationship"
                            If ReturnPermission("D09F0128") < EnumPermission.Add Then
                                MsgNoPermissionAdd()
                            Else
                                Dim arrPro() As StructureProperties = Nothing
                                SetProperties(arrPro, "FormIDPermission", "D09F0128")
                                Dim frm As Form = CallFormShowDialog("D09D0140", "D09F0129", arrPro)
                                If L3Bool(GetProperties(frm, "bSaved")) Then
                                    LoadCombosource()
                                    .SelectedValue = L3String(GetProperties(frm, "RelationID"))
                                End If
                            End If
                        Case "ShiftID"
                            If ReturnPermission("D29F1010") < EnumPermission.Add Then
                                MsgNoPermissionAdd()
                            Else
                                Dim arrPro() As StructureProperties = Nothing
                                SetProperties(arrPro, "FormIDPermission", "D29F1010")
                                Dim frm As Form = CallFormShowDialog("D29D0140", "D29F1011", arrPro)
                                If L3Bool(GetProperties(frm, "bSaved")) Then
                                    LoadCombosource()
                                    .SelectedValue = L3String(GetProperties(frm, "ShiftID"))
                                Else
                                    .SelectedValue = ""
                                End If
                            End If
                        Case "SuggesterRelationID"
                            Dim sKey As String = ShowFormD09F0129(tdbcXXX) 'CalExeAddNew("D09E0140", "D09F0129", "D09F0128")
                            If sKey <> "" Then
                                LoadCombosource()
                                .SelectedValue = sKey
                            End If
                    End Select
                    .Focus()
                Else
                    Select Case FieldName
                        Case "DivisionID"
                            _DivisionIDValue = .SelectedValue.ToString
                            Try
                                If tdbcXXX.TopLevelControl.Name.ToLower = D25F1051_NN.Name.ToLower Then
                                    Dim tabControl As Control = .Parent.Parent
                                    If TypeOf (tabControl) Is TabPage Then
                                        Dim control() As Control = tabControl.Controls.Find("tdbcRecDepartmentID", True)
                                        If control.Length > 0 Then
                                            D25F1051_NN.LoadtdbcDepartment(CType(control(0).Controls(0), C1.Win.C1List.C1Combo), _divisionIDValue)
                                        End If
                                    End If

                                End If
                            Catch ex As Exception
                                D99C0008.MsgL3(ex.Message)
                            End Try
                    End Select
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub usrctrlCombo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'SetResolutionForm(Me)
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal clr As Color)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        tdbcXXX.EditorBackColor = clr
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub tdbcName_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcXXX.Close
        tdbcName_Validated(sender, Nothing)
    End Sub

    Private Sub tdbcName_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcXXX.Validated
        Dim tdbc As C1.Win.C1List.C1Combo = CType(sender, C1.Win.C1List.C1Combo)
        tdbc.Text = tdbc.WillChangeToText
    End Sub
End Class
