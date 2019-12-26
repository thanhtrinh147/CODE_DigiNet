Imports System
Public Class D45F2009
	Private _bSaved As Boolean = False
	Public ReadOnly Property bSaved() As Boolean
		Get
			Return _bSaved
		   End Get
	End Property

    Public dtGrid As DataTable

#Region "Const of tdbg"
    Private Const COL_StageID As Integer = 0   ' Mã công đoạn
    Private Const COL_StageName As Integer = 1 ' Tên công đoạn
#End Region

    Private _sProductID As String
    Public WriteOnly Property sProductID() As String
        Set(ByVal Value As String)
            _sProductID = Value
        End Set
    End Property

    Private _sProductName As String
    Public WriteOnly Property sProductName() As String
        Set(ByVal Value As String)
            _sProductName = Value
        End Set
    End Property

    Private Sub D45F2009_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
            Exit Sub
        End If
    End Sub

    Private Sub D45F2009_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        _bSaved = False
        Loadlanguage()
        SetBackColorObligatory()
        LoadTDBCombo()
        ResetColorGrid(tdbg)
        LoadDefault()
        '*****************************************
        InputbyUnicode(Me, gbUnicode)
        '*****************************************
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Chon_quy_trinh_-_D45F2009") & UnicodeCaption(gbUnicode) 'Chãn quy trØnh - D45F2009
        '================================================================ 
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblRoutingID.Text = rl3("Quy_trinh") 'Quy trình
        '================================================================ 
        btnChoose.Text = rl3("_Chon") '&Chọn
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcRoutingID.Columns("RoutingNum").Caption = rl3("Ma") 'Mã
        tdbcRoutingID.Columns("RoutingDesc").Caption = rl3("Dien_giai") 'Diễn giải
        '================================================================ 
        tdbg.Columns("StageID").Caption = rl3("Ma_cong_doan") 'Mã công đoạn
        tdbg.Columns("StageName").Caption = rl3("Ten_cong_doan") 'Tên công đoạn
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcRoutingID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        txtProductID.Text = _sProductID
        txtProductName.Text = _sProductName
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcRoutingID
        sSQL = "Select RoutingID, RoutingNum, RoutingDesc" & UnicodeJoin(gbUnicode) & " As RoutingDesc" & vbCrLf
        sSQL &= "From D45T1080 WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled=0 And ProductID=" & SQLString(_sProductID)
        LoadDataSource(tdbcRoutingID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcRoutingID with txtRoutingName"

    Private Sub tdbcRoutingID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRoutingID.SelectedValueChanged
        If tdbcRoutingID.SelectedValue Is Nothing Then
            txtRoutingName.Text = ""
            LoadTDBGrid("-1")
        Else
            txtRoutingName.Text = tdbcRoutingID.Columns(1).Value.ToString
            LoadTDBGrid(CbVal(tdbcRoutingID))
        End If
    End Sub

    Private Sub tdbcRoutingID_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcRoutingID.LostFocus
        If tdbcRoutingID.FindStringExact(tdbcRoutingID.Text) = -1 Then
            tdbcRoutingID.Text = ""
        End If
    End Sub
#End Region

    Private Sub LoadTDBGrid(ByVal sRoutingID As String)
        Dim sSQL As String = ""
        sSQL = "SELECT T10.StageID, T10.StageName" & UnicodeJoin(gbUnicode) & " as StageName" & vbCrLf
        sSQL &= "FROM D45T1081 T81  WITH(NOLOCK) INNER JOIN D45T1010 T10  WITH(NOLOCK) ON T81.StageID = T10.StageID" & vbCrLf
        sSQL &= "WHERE T81.RoutingID = " & SQLString(sRoutingID) & vbCrLf
        sSQL &= "ORDER BY T81.OrderNum, T10.StageID"
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)

        FooterTotalGrid(tdbg, COL_StageID)
    End Sub

    Private Function AllowSave() As Boolean
        If tdbcRoutingID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Quy_trinh"))
            tdbcRoutingID.Focus()
            Return False
        End If
    
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnChoose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChoose.Click
        If AllowSave() = False Then Exit Sub
        _bSaved = True
        Me.Close()
    End Sub
End Class