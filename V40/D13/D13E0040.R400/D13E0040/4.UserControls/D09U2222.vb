Imports System
'#-------------------------------------------------------------------------------------
'# Title: D09U2222
'# Created User: Nguyễn Hoàng Long
'# Created Date: 15/07/2009 1:53:09 PM
'# Modify User: Nguyễn Thị Minh Hòa
'# Modify Date: 30/09/2009 1:53:09 PM
'# Description: UserControl D09U2222 (dùng chung cho nhóm G4) chứa khung cảnh báo
'#-------------------------------------------------------------------------------------
Public Class D09U2222

    Private WithEvents Frame1, Frame2, Frame3, Frame4 As D09U2223
    Dim iFrame As New D09U2223
    Private _isFrame As Boolean = False
    Dim iCount As Integer = 0
    Private Dispose1, Dispose2, Dispose3, Dispose4 As Boolean
    Dim dtTemp As DataTable 'Bang chua du lieu cac Frame duoc add

    Public Property IsFrame() As Boolean
        Get
            Return _isFrame
        End Get
        Set(ByVal Value As Boolean)
            _isFrame = Value
        End Set
    End Property

    Private _moduleID As String
    Public Property ModuleID() As String
        Get
            Return _moduleID
        End Get
        Set(ByVal Value As String)
            _moduleID = Value
        End Set
    End Property

    Private _formPermision As String
    Public Property FormPermision() As String
        Get
            Return _formPermision
        End Get
        Set(ByVal Value As String)
            _formPermision = Value
        End Set
    End Property

    Private Sub D09U2222_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub D09U0000_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Align()
        Dispose1 = True
        Dispose2 = True
        Dispose3 = True
        Dispose4 = True
        LoadFrames()
    End Sub

    Private Sub LoadFrames()
        Dim sSQL As String = SQLStoreD09P8200()
        dtTemp = ReturnDataTable(sSQL)
        If dtTemp.Rows.Count > 0 Then
            AddFrames(dtTemp)
        End If
    End Sub

    ''' <summary>
    ''' Ham nay duoc goi khi chon ngon ngu tai man hinh D09F0000
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadLanguage_D09U2222()
        Dim dtTemp As DataTable = ReturnDataTable(SQLStoreD09P8200())
        Dim sAlertBase As String = ""
        Dim sAlertCode As String = ""

        If dtTemp.Rows.Count > 0 Then


            If Frame1 Is Nothing Then
            Else
                Frame1.FieldCaption()
                Frame1.LoadLanguage()
                For i As Integer = 0 To dtTemp.Rows.Count - 1
                    If Frame1.AlertBaseID = dtTemp.Rows(i).Item("AlertBaseID").ToString And Frame1.AlertCode = dtTemp.Rows(i).Item("AlertCode").ToString Then
                        Frame1.AlertMessage = dtTemp.Rows(i).Item("AlertMessage").ToString
                        Exit For
                    End If
                Next i
            End If


            If Frame2 Is Nothing Then
            Else
                Frame2.FieldCaption()
                Frame2.LoadLanguage()
                For i As Integer = 0 To dtTemp.Rows.Count - 1
                    If Frame2.AlertBaseID = dtTemp.Rows(i).Item("AlertBaseID").ToString And Frame2.AlertCode = dtTemp.Rows(i).Item("AlertCode").ToString Then
                        Frame2.AlertMessage = dtTemp.Rows(i).Item("AlertMessage").ToString
                        Exit For
                    End If
                Next i
            End If


            If Frame3 Is Nothing Then
            Else
                Frame3.FieldCaption()
                Frame3.LoadLanguage()
                For i As Integer = 0 To dtTemp.Rows.Count - 1
                    If Frame3.AlertBaseID = dtTemp.Rows(i).Item("AlertBaseID").ToString And Frame3.AlertCode = dtTemp.Rows(i).Item("AlertCode").ToString Then
                        Frame3.AlertMessage = dtTemp.Rows(i).Item("AlertMessage").ToString
                        Exit For
                    End If
                Next i
            End If

            If Frame4 Is Nothing Then
            Else
                Frame4.FieldCaption()
                Frame4.LoadLanguage()
                For i As Integer = 0 To dtTemp.Rows.Count - 1
                    If Frame4.AlertBaseID = dtTemp.Rows(i).Item("AlertBaseID").ToString And Frame4.AlertCode = dtTemp.Rows(i).Item("AlertCode").ToString Then
                        Frame4.AlertMessage = dtTemp.Rows(i).Item("AlertMessage").ToString
                        Exit For
                    End If
                Next i
            End If
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD09P8200
    '# Created User: Nguyễn Lê Phương
    '# Created Date: 16/09/2009 02:57:53
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD09P8200() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D09P8200 "
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID, varchar[20], NOT NULL
        sSQL &= SQLString(gsUserID) & COMMA 'UserID, varchar[20], NOT NULL
        sSQL &= SQLString(My.Computer.Name) & COMMA 'HostID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[20], NOT NULL
        sSQL &= SQLString(_moduleID) '& COMMA 'ModuleID, varchar[20], NOT NULL
        'sSQL &= SQLNumber(giTranMonth) & COMMA
        'sSQL &= SQLNumber(giTranYear)
        Return sSQL
    End Function

    Private Sub Align()
        Dim Width, Height As Integer
        Width = CInt(Me.Width / 2)
        Height = CInt(Me.Height / 2)
        SplitMain.SplitterDistance = Height
        SplitSubTop.SplitterDistance = Width
        SplitSubBottom.SplitterDistance = Width
    End Sub

    Private Sub AddFrames(ByVal dtTemp As DataTable)
        For i As Integer = 0 To dtTemp.Rows.Count - 1

            iFrame = New D09U2223
            iFrame.Dock = DockStyle.Fill
            iFrame.AlertBaseID = dtTemp.Rows(i).Item("AlertBaseID").ToString
            iFrame.AlertCode = dtTemp.Rows(i).Item("AlertCode").ToString
            iFrame.AlertMessage = dtTemp.Rows(i).Item("AlertMessage").ToString
            iFrame.SQLQuery = dtTemp.Rows(i).Item("SQLQuery").ToString
            iFrame.ModuleID = _moduleID
            iFrame.FormPermision = _formPermision

            If iFrame.LoadTDBGrid() Then
                iCount += 1
                Select Case iCount
                    Case 1
                        Frame1 = iFrame
                        Dispose1 = False
                    Case 2
                        Frame2 = iFrame
                        Dispose2 = False
                    Case 3
                        Frame3 = iFrame
                        Dispose3 = False
                    Case 4
                        Frame4 = iFrame
                        Dispose4 = False
                        Exit For
                End Select
            Else
                iFrame = Nothing
            End If
        Next
        If iCount >= 2 Then
            If iCount > 3 Then
                'Add Frame3                
                SplitSubTop.Panel1.Controls.Add(Frame3)
                'Add Frame4                
                SplitSubTop.Panel2.Controls.Add(Frame4)
            ElseIf iCount > 2 Then
                SplitSubTop.Panel2Collapsed = True
                'Add Frame3                
                SplitSubTop.Panel1.Controls.Add(Frame3)
            End If
            If iCount = 2 Then
                SplitSubBottom.Panel2Collapsed = True
                SplitSubTop.Panel2Collapsed = True
                SplitSubBottom.Panel1.Controls.Add(Frame1)
                SplitSubTop.Panel1.Controls.Add(Frame2)
            Else
                SplitSubBottom.Panel1.Controls.Add(Frame1)
                SplitSubBottom.Panel2.Controls.Add(Frame2)
            End If
        Else
            SplitMain.Panel1Collapsed = True
            SplitSubBottom.Panel2Collapsed = True
            'Add Frame1            
            SplitSubBottom.Panel1.Controls.Add(Frame1)
        End If

        _isFrame = iCount > 0
        
    End Sub

    Private Sub LoadFrames_Again()
        'Try
        Select Case GetNumFrame()
            Case 1
                SplitMain.Panel2Collapsed = False
                SplitMain.Panel1Collapsed = True
                SplitSubBottom.Panel2Collapsed = True
                SplitSubBottom.Panel1Collapsed = False
                If Not Dispose1 Then SplitSubBottom.Panel1.Controls.Add(Frame1)
                If Not Dispose2 Then SplitSubBottom.Panel1.Controls.Add(Frame2)
                If Not Dispose3 Then SplitSubBottom.Panel1.Controls.Add(Frame3)
                If Not Dispose4 Then SplitSubBottom.Panel1.Controls.Add(Frame4)
            Case 2
                SplitMain.Panel2Collapsed = False
                SplitMain.Panel1Collapsed = False
                SplitSubBottom.Panel2Collapsed = True
                SplitSubTop.Panel2Collapsed = True
                SplitSubBottom.Panel1Collapsed = False
                SplitSubTop.Panel1Collapsed = False

                Dim bFlag As Boolean = False
                If Not Dispose1 Then
                    SplitSubBottom.Panel1.Controls.Add(Frame1)
                    bFlag = True
                End If

                If Not Dispose2 Then
                    If bFlag Then
                        SplitSubTop.Panel1.Controls.Add(Frame2)
                    Else
                        SplitSubBottom.Panel1.Controls.Add(Frame2)
                    End If
                    bFlag = True
                End If

                If Not Dispose3 Then
                    If bFlag Then
                        SplitSubTop.Panel1.Controls.Add(Frame3)
                    Else
                        SplitSubBottom.Panel1.Controls.Add(Frame3)
                    End If
                    bFlag = True
                End If

                If Not Dispose4 Then
                    If bFlag Then
                        SplitSubTop.Panel1.Controls.Add(Frame4)
                    Else
                        SplitSubBottom.Panel1.Controls.Add(Frame4)
                    End If
                    bFlag = True
                End If

            Case 3
                If Dispose1 Then SplitSubBottom.Panel1Collapsed = True
                If Dispose2 Then SplitSubBottom.Panel2Collapsed = True
                If Dispose3 Then SplitSubTop.Panel1Collapsed = True
                If Dispose4 Then SplitSubTop.Panel2Collapsed = True
        End Select
        'Catch ex As Exception
        'End Try
    End Sub

    Private Function GetNumFrame() As Integer
        Dim iNumFrame As Integer = 0
        If Not Dispose1 Then iNumFrame += 1
        If Not Dispose2 Then iNumFrame += 1
        If Not Dispose3 Then iNumFrame += 1
        If Not Dispose4 Then iNumFrame += 1
        Return iNumFrame
    End Function

    Private Sub ClearWarningScreen()
        If Dispose1 And Dispose2 And Dispose3 And Dispose4 Then
            SplitMain.Panel1Collapsed = True
            SplitMain.Panel2Collapsed = True
            Me.Dispose()
        End If
    End Sub

    Private Sub Frame1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame1.Disposed
        Dispose1 = True
        If Frame1.IsDispose Then
            LoadFrames_Again()
            ClearWarningScreen()
        End If
    End Sub

    Private Sub Frame2_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame2.Disposed
        Dispose2 = True
        If Frame2.IsDispose Then
            LoadFrames_Again()
            ClearWarningScreen()
        End If
    End Sub

    Private Sub Frame3_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame3.Disposed
        Dispose3 = True

        If Frame3.IsDispose Then


            LoadFrames_Again()
            ClearWarningScreen()
        End If
    End Sub

    Private Sub Frame4_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Frame4.Disposed
        Dispose4 = True

        If Frame4.IsDispose Then
            LoadFrames_Again()
            ClearWarningScreen()
        End If
    End Sub

End Class
