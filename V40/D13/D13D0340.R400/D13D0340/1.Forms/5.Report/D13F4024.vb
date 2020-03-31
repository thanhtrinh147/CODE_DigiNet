Imports System
Public Class D13F4024

#Region "Const of tdbg"
    Private Const COL_OrderNum As Integer = 0  ' STT
    Private Const COL_CodeID As Integer = 1    ' Mã
    Private Const COL_CodeName As Integer = 2  ' Diễn giải
    Private Const COL_FieldName As Integer = 3 ' FieldName
#End Region
    Private _codeID As String = ""
    Public Property CodeID() As String 
        Get
            Return _codeID
        End Get
        Set(ByVal Value As String )
            _codeID = Value
        End Set
    End Property
    Private _formID As String = "D13F4020"
    Public WriteOnly Property FormID() As String 
        Set(ByVal Value As String )
            _formID = Value
        End Set
    End Property
    Private _codeName As String
    Public Property  CodeName() As String
        Get
            Return _codeName
        End Get
        Set(ByVal Value As String)
            _codeName = Value
        End Set
    End Property
    Private _fieldName As String
    Public Property  FieldName() As String
        Get
            Return _fieldName
        End Get
        Set(ByVal Value As String)
            _fieldName = Value
        End Set
    End Property

    Private Sub D13F4024_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInfoGeneral()
        Loadlanguage()
        ResetColorGrid(tdbg, 0, 0)
        LoadTDBGrid()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tron_thu_-_D13F4024") & UnicodeCaption(gbUnicode) 'Trèn th§ - D13F4024
        '================================================================ 
        btnChoose.Text = rl3("_Chon") '&Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbg.Columns("OrderNum").Caption = rl3("STT") 'STT
        tdbg.Columns("CodeID").Caption = rl3("Ma") 'Mã
        tdbg.Columns("CodeName").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        sSQL = "SELECT OrderNum, CodeID, CodeName" & UnicodeJoin(gbUnicode) & " as CodeName, FieldName FROM D13V4022 Where FormID = " & SQLString(_formID)
        LoadDataSource(tdbg, sSQL, gbUnicode)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        _codeID = tdbg.Columns(COL_CodeID).Text
        _codeName = tdbg.Columns(COL_CodeName).Text
        _fieldName = tdbg.Columns(COL_FieldName).Text
        Me.Close()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        tdbg_DoubleClick(Nothing, Nothing)
    End Sub

End Class