'#-------------------------------------------------------------------------------------
'# Created Date: 01/08/2006 4:34:17 PM
'# Created User: Nguyễn Thị Minh Hòa
'# Modify Date: 01/08/2006 4:34:17 PM
'# Modify User: Nguyễn Thị Minh Hòa
'#-------------------------------------------------------------------------------------
Public Class D45F5556

    Private iNextMonth As Integer = -1
    Private iNextYear As Integer = -1

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub D45F5554_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadLanguage()
        LoadEdit()
        SetResolutionForm(Me)
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Tao_ky_moi_-_D45F5556") 'TÁo kù mìi - D45F5556
        '================================================================ 
        lblDivisionCaption.Text = rl3("Don_vi") 'Đơn vị:

        lblPeriodCaption.Text = rl3("Ky") 'Kỳ kế toán:

        lblQuestion.Text = rl3("Ban_co_muon_tao_ky_moi_khong") 'Bạn có muốn tạo kỳ mới không?
        
    End Sub



    Private Sub LoadEdit()
        Dim sSQL As String = ""
        sSQL = "Select PeriodNumber From D91T0025 WITH(NOLOCK) "
        Dim iPeriodNumber As Integer = Convert.ToInt16(ReturnScalar(sSQL))

        sSQL = "Select Top 1 TranMonth, TranYear From D09T9999  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & "Order By TranYear * 100 + TranMonth Desc"
        Dim dt As DataTable = ReturnDataTable(sSQL)
        If Convert.ToInt16(dt.Rows(0).Item("TranMonth")) = iPeriodNumber Then
            iNextMonth = 1
            iNextYear = Convert.ToInt16(dt.Rows(0).Item("TranYear")) + 1
        Else
            iNextMonth = Convert.ToInt16(dt.Rows(0).Item("TranMonth")) + 1
            iNextYear = Convert.ToInt16(dt.Rows(0).Item("TranYear"))
        End If
        dt.Dispose()

        lblDivisionID.Text = gsDivisionID
        lblPeriod.Text = iNextMonth.ToString("00") & "/" & iNextYear.ToString
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Dim sSQL As String = ""
        sSQL = "Select 1 From D09T9999  WITH(NOLOCK) Where DivisionID = " & SQLString(gsDivisionID) & " And TranMonth = " & SQLNumber(iNextMonth) & " And TranYear = " & SQLNumber(iNextYear)
        If ReturnScalar(sSQL) = "" Then
            sSQL = SQLInsertD45T9999()
            If ExecuteSQL(sSQL) Then
                D99C0008.MsgL3(rl3("Ky") & " " & lblPeriod.Text & " " & rl3("_da_duoc_tao")) 'đã được tạo
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                D99C0008.MsgL3(rl3("Co_loi_khi_tao_ky_moi"))
                Me.DialogResult = Windows.Forms.DialogResult.Cancel
                Me.Close()
            End If
        End If
    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLInsertD45T9999
    '# Create User: 
    '# Create Date: 
    '# Modified User: 
    '# Modified Date: 
    '# Description: 
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLInsertD45T9999() As String
        Dim sSQL As String = ""
        sSQL &= "Insert Into D09T9999("
        sSQL &= "TranMonth, TranYear, DivisionID, Quarter, Closing"
        sSQL &= ") Values ("
        sSQL &= SQLNumber(iNextMonth) & COMMA 'TranMonth [KEY], Int, NOT NULL
        sSQL &= SQLNumber(iNextYear) & COMMA 'TranYear [KEY], Int, NOT NULL
        sSQL &= SQLString(gsDivisionID) & COMMA 'DivisionID [KEY], VarChar[20], NOT NULL
        sSQL &= "Ceiling(" & iNextMonth & "/3.00)" & COMMA 'Quarter, VarChar[20], NOT NULL
        sSQL &= SQLNumber("0") 'Closing, Bit, NOT NULL
        sSQL &= ")"
        Return sSQL
    End Function

End Class