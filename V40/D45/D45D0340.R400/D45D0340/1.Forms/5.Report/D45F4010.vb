Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 03/10/2007 08:53:11
'# Created User: Nguyễn Trần Phương Nam
'# Modify Date: 03/10/2007 08:53:11
'# Modify User: Nguyễn Trần Phương Nam
'#-------------------------------------------------------------------------------------

Public Class D45F4010
	Dim report As D99C2003

    Private _priceListID As String
    Public WriteOnly Property PriceListID() As String
        Set(ByVal Value As String)
            _priceListID = Value
        End Set
    End Property

    Private Sub D45F4010_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        End If
    End Sub

    Private Sub D45F4010_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Me.Cursor = Cursors.WaitCursor
        Loadlanguage()
        LoadTDBCombo()
        SetBackColorObligatory()
        LoadDefault()
        InputbyUnicode(Me, gbUnicode)
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Bao_cao_bang_gia_-_D45F4010") & UnicodeCaption(gbUnicode) 'BÀo cÀo b¶ng giÀ - D45F4010
        '================================================================ 
        lblPriceListID.Text = rl3("Bang_gia") 'Bảng giá
        lblProductID.Text = rl3("San_pham") 'Sản phẩm
        lblStageID.Text = rl3("Cong_doan") 'Công đoạn
        '================================================================ 
        btnPrint.Text = rl3("_In") '&In
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcPriceListID.Columns("PriceListID").Caption = rl3("Ma") 'Mã
        tdbcPriceListID.Columns("PriceListName").Caption = rl3("Ten") 'Tên
        tdbcProductID.Columns("ProductID").Caption = rl3("Ma") 'Mã
        tdbcProductID.Columns("ProductName").Caption = rl3("Ten") 'Tên
        tdbcStageID.Columns("StageID").Caption = rl3("Ma") 'Mã
        tdbcStageID.Columns("StageName").Caption = rl3("Ten") 'Tên
    End Sub

    Private Sub SetBackColorObligatory()
        tdbcPriceListID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcProductID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
        tdbcStageID.EditorBackColor = COLOR_BACKCOLOROBLIGATORY
    End Sub

    Private Sub LoadDefault()
        If _priceListID <> "" Then
            tdbcPriceListID.Text = _priceListID
        Else
            tdbcPriceListID.SelectedIndex = 0
        End If

        tdbcProductID.SelectedIndex = 0
        tdbcStageID.SelectedIndex = 0
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Bổ sung Field Unicode
        Dim sUnicode As String = ""
        Dim sLanguage As String = ""
        UnicodeAllString(sUnicode, sLanguage, gbUnicode)

        'Load tdbcPriceListID
        sSQL = "Select PriceListID, PriceListName" & sUnicode & " as PriceListName From D45T1020  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled =0" & vbCrLf
        sSQL &= "Order By PriceListID"
        LoadDataSource(tdbcPriceListID, sSQL, gbUnicode)

        'Load tdbcProductID
        sSQL = "Select 1 AS DisplayOrder,ProductID, ProductName" & sUnicode & " as ProductName From D45T1000  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled =0" & vbCrLf
        sSQL &= " Union" & vbCrLf
        sSQL &= "Select 0 AS DisplayOrder,'%' as ProductID, " & sLanguage & " as ProductName" & vbCrLf
        sSQL &= " Order by DisplayOrder,ProductID"
        LoadDataSource(tdbcProductID, sSQL, gbUnicode)

        'Load tdbcStageID
        sSQL = "Select 1 AS DisplayOrder,StageID, StageName" & sUnicode & " as StageName From D45T1010  WITH(NOLOCK) " & vbCrLf
        sSQL &= "Where Disabled =0" & vbCrLf
        sSQL &= "Union" & vbCrLf
        sSQL &= "Select 0 AS DisplayOrder,'%' as StageID, " & sLanguage & " as StageName" & vbCrLf
        sSQL &= " Order by DisplayOrder,StageID"
        LoadDataSource(tdbcStageID, sSQL, gbUnicode)
    End Sub

#Region "Events tdbcPriceListID with txtPriceListName"

    Private Sub tdbcPriceListID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceListID.Close
        If tdbcPriceListID.FindStringExact(tdbcPriceListID.Text) = -1 Then
            tdbcPriceListID.Text = ""
            txtPriceListName.Text = ""
        End If
    End Sub

    Private Sub tdbcPriceListID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcPriceListID.SelectedValueChanged
        txtPriceListName.Text = tdbcPriceListID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcPriceListID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcPriceListID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcPriceListID.Text = ""
            txtPriceListName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcProductID with txtProductName"

    Private Sub tdbcProductID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.Close
        If tdbcProductID.FindStringExact(tdbcProductID.Text) = -1 Then
            tdbcProductID.Text = ""
            txtProductName.Text = ""
        End If
    End Sub

    Private Sub tdbcProductID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcProductID.SelectedValueChanged
        txtProductName.Text = tdbcProductID.Columns(1).Value.ToString
    End Sub

    Private Sub tdbcProductID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcProductID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcProductID.Text = ""
            txtProductName.Text = ""
        End If
    End Sub

#End Region

#Region "Events tdbcStageID with txtStageName"

    Private Sub tdbcStageID_Close(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.Close
        If tdbcStageID.FindStringExact(tdbcStageID.Text) = -1 Then
            tdbcStageID.Text = ""
            txtStageName.Text = ""
        End If
    End Sub

    Private Sub tdbcStageID_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcStageID.SelectedValueChanged
        If tdbcStageID.SelectedValue IsNot Nothing Then
            txtStageName.Text = tdbcStageID.Columns(1).Value.ToString
        End If
    End Sub

    Private Sub tdbcStageID_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbcStageID.KeyDown
        If e.KeyCode = Keys.Delete OrElse e.KeyCode = Keys.Back Then
            tdbcStageID.Text = ""
            txtStageName.Text = ""
        End If
    End Sub

#End Region

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'Đưa vể đầu tiên hàm In trước khi gọi AllowPrint()
        If Not AllowNewD99C2003(report, Me) Then Exit Sub
        If Not AllowPrint() Then Exit Sub
        btnPrint.Enabled = False
        Me.Cursor = Cursors.WaitCursor

        'Dim report As New D99C1003
		
		'************************************
        Dim conn As New SqlConnection(gsConnectionString)
        Dim sReportName As String = "D45R4010"
        Dim sSubReportName As String = "D09R6000"
        Dim sReportCaption As String = ""
        Dim sPathReport As String = ""
        Dim sSQL As String = ""
        Dim sSQLSub As String = ""

        sReportCaption = rl3("Bao_cao_bang_gia") & " - " & sReportName
        'sPathReport = Application.StartupPath & "\XReports\" & sReportName & ".rpt"
        sPathReport = UnicodeGetReportPath(gbUnicode, 0, "") & sReportName & ".rpt"
        sSQL = SQLStoreD45P4010()
        sSQLSub = "Select * From D09V0009"
        UnicodeSubReport(sSubReportName, sSQLSub, gsDivisionID, gbUnicode)
        With report
            .OpenConnection(conn)
            .AddSub(sSQLSub, sSubReportName & ".rpt")
            .AddMain(sSQL)
            .PrintReport(sPathReport, sReportCaption)
        End With
        Me.Cursor = Cursors.Default
        btnPrint.Enabled = True
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD45P4010
    '# Created User: Nguyễn Trần Phương Nam
    '# Created Date: 03/10/2007 07:44:43
    '# Modified User: 
    '# Modified Date: 
    '# Description: Đổ nguồn cho MainReport
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD45P4010() As String
        Dim sSQL As String = ""
        sSQL &= "Exec D45P4010 "
        sSQL &= SQLString(tdbcPriceListID.Text) & COMMA 'PriceListID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcProductID.Text) & COMMA 'ProductID, varchar[20], NOT NULL
        sSQL &= SQLString(tdbcStageID.Text) & COMMA 'StageID, varchar[20], NOT NULL
        sSQL &= SQLNumber(gbUnicode)
        Return sSQL
    End Function

    Private Function AllowPrint() As Boolean
        If tdbcPriceListID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rl3("Bang_gia"))
            tdbcPriceListID.Focus()
            Return False
        End If
        If tdbcProductID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("San_pham"))
            tdbcProductID.Focus()
            Return False
        End If
        If tdbcStageID.Text.Trim = "" Then
            D99C0008.MsgNotYetChoose(rL3("Cong_doan"))
            tdbcStageID.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class