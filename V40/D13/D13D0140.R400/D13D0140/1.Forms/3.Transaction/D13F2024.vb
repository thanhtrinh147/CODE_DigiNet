Public Class D13F2024

#Region "Const of tdbg"
    Private Const COL_Orders As Integer = 0     ' STT
    Private Const COL_RewardID As Integer = 1   ' Mã số
    Private Const COL_RewardName As Integer = 2 ' Diễn giải
#End Region

    Private _Formular As String = ""
    Public Property Formular() As String
        Get
            Return _Formular
        End Get
        Set(ByVal Value As String)
            If _Formular = Value Then
                _Formular = ""
                Return
            End If
            _Formular = Value
        End Set
    End Property

    Private Sub D13F2024_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        ResetColorGrid(tdbg)
        LoadLanguage()
        gbEnabledUseFind = False
        LoadTDBGrid()

        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_thuong_-_D13F2024") & UnicodeCaption(gbUnicode) 'Danh móc th§êng - D13F2024
        '================================================================ 
        tdbg.Columns("Orders").Caption = rl3("STT") 'STT
        tdbg.Columns("RewardID").Caption = rl3("Ma_so") 'Mã số
        tdbg.Columns("RewardName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadTDBGrid(Optional ByVal FlagAdd As Boolean = False)
        Dim sSQL As String = ""
        sSQL = "Select '' as Orders,RewardID,RewardName" & UnicodeJoin(gbUnicode) & " as RewardName" & vbCrLf
        sSQL &= "From D13T0301 WITH (NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 Order by RewardID Asc"
        LoadDataSource(tdbg, sSQL, gbUnicode)
        For i As Integer = 0 To tdbg.RowCount - 1
            tdbg(i, COL_Orders) = i + 1
        Next
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        _Formular = "[" & tdbg.Columns(COL_RewardID).Text & "]"
        Me.Close()
    End Sub

End Class