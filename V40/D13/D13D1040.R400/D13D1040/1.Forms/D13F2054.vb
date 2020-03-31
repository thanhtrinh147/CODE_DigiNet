Imports System
'#-------------------------------------------------------------------------------------
'# Created Date: 08/05/2007 4:38:24 PM
'# Created User: Trần Thị Ái Trâm
'# Modify Date: 30/06/2010 - modify => Danh mục hàm tính lương
'# Modify User: Đỗ Minh Dũng
'#-------------------------------------------------------------------------------------
Public Class D13F2054
    Private _returnFormular As String = ""

    Private _formID As String = "D13F2054"
    Public WriteOnly Property FormID() As String 
        Set(ByVal Value As String )
            _formID = Value
        End Set
    End Property

    Public ReadOnly Property ReturnFormular() As String
        Get
            Return _returnFormular
        End Get
    End Property

#Region "Const of tdbg"
    Private Const COL_Formula As Integer = 0 ' Công thức
    Private Const COL_Desc As Integer = 1    ' Diễn giải
#End Region

    Private Sub D13F2054_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            UseEnterAsTab(Me)
        ElseIf e.KeyCode = Keys.F11 Then
            HotKeyF11(Me, tdbg)
        End If
    End Sub

    Private Sub D13F2054_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
	LoadInfoGeneral()
        Loadlanguage()
        ResetFooterGrid(tdbg)
        InputbyUnicode(Me, gbUnicode)
        LoadTDBGrid()
        ResetColorGrid(tdbg)
        LoadTDBCombo()
        SetResolutionForm(Me)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Danh_muc_ham_tinh_luong_-_D13F2054") & UnicodeCaption(gbUnicode) 'Danh móc hªm tÛnh l§¥ng - D13F2054
        '================================================================ 
        lblTypeFormula.Text = rl3("Loai") 'Loại
        '================================================================ 
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        tdbcTypeFormula.Columns("FormulaTypeID").Caption = rl3("Ma") 'Mã
        tdbcTypeFormula.Columns("FormulaTypeName").Caption = rl3("Ten") 'Tên
        '================================================================ 
        tdbg.Columns("FormulaID").Caption = rl3("Cong_thuc") 'Công thức
        tdbg.Columns("Description").Caption = rl3("Dien_giai") 'Diễn giải
    End Sub

    Private Sub LoadTDBCombo()
        Dim sSQL As String = ""
        'Load tdbcTypeFormula
        sSQL = "Select FormulaTypeID, " & IIf(gbUnicode, IIf(geLanguage = EnumLanguage.Vietnamese, "FormulaTypeName84U", "FormulaTypeName01U"), IIf(geLanguage = EnumLanguage.Vietnamese, "FormulaTypeName84", "FormulaTypeName01")).ToString & " as FormulaTypeName " & vbCrLf
        sSQL &= " from D13V2500 where FormID = " & SQLString(_formID)
        LoadDataSource(tdbcTypeFormula, sSQL, gbUnicode)
    End Sub

    Dim dtGrid As DataTable
    Private Sub LoadTDBGrid()
        Dim sSQL As String = ""
        '  sSQL = "Select FormulaID, Description, DescriptionU, FormulaTypeID, TransID From D13V1010 Order By FormulaTypeID, TransID, FormulaID "
        sSQL = SQLStoreD13P1010() ' 22/1/2014 id 53503
        dtGrid = ReturnDataTable(sSQL)
        LoadDataSource(tdbg, dtGrid, gbUnicode)
        FooterTotalGrid(tdbg, COL_Formula)
    End Sub

    Private Sub tdbg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.DoubleClick
        If tdbg.FilterActive Then Exit Sub
        If tdbg.RowCount > 0 Then
            _returnFormular = tdbg.Columns(COL_Formula).Text
            Me.Close()
        End If
    End Sub

    Dim sFilter As New System.Text.StringBuilder()
    Private Sub tdbg_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbg.FilterChange
        Try
            If (dtGrid Is Nothing) Then Exit Sub
            'sFilter = New StringBuilder("")
            'Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
            'For Each dc In Me.tdbg.Columns
            '    Select Case dc.DataType.Name
            '        Case "DateTime"
            '            If dc.FilterText.Length = 10 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                Dim sClause As String = ""
            '                sClause = "(" & dc.DataField & " >= #" & DateSave(CDate(dc.FilterText)) & "#"
            '                sClause &= " And " & dc.DataField & " < #" & DateSave(CDate(dc.FilterText).AddDays(1)) & "# )"
            '                sFilter.Append(sClause)
            '            End If

            '        Case "Boolean"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " = " + "'" + dc.FilterText + "'"))
            '            End If

            '        Case "String"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " like " + "'%" + dc.FilterText.Replace("'", "''") + "%'"))
            '            End If

            '        Case "Decimal", "Byte", "Integer"
            '            If dc.FilterText.Length > 0 Then
            '                If sFilter.Length > 0 Then sFilter.Append(" AND ")
            '                sFilter.Append((dc.DataField + " = " + "" + dc.FilterText + ""))
            '            End If
            '    End Select
            'Next

            '13/04/2015 Gọi về hàm chung
            FilterChangeGrid(tdbg, sFilter)

            'Filter the data           
            dtGrid.DefaultView.RowFilter = FilterGrid()
            FooterTotalGrid(tdbg, COL_Formula)
        Catch ex As Exception
            'MessageBox.Show(ex.Message & " - " & ex.Source)
            WriteLogFile(ex.Message)
        End Try
    End Sub


    Private Function FilterGrid() As String
        Dim sFind As String = ""
        If sFilterCombo <> "" And sFilter.ToString <> "" Then
            sFind = sFilter.ToString & " and " & sFilterCombo
        ElseIf sFilterCombo = "" Then
            sFind = sFilter.ToString
        Else
            sFind = sFilterCombo
        End If
        Return sFind
    End Function

#Region "Events tdbcTypeFormula"

    Private Sub tdbcTypeFormula_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tdbcTypeFormula.LostFocus
        If tdbcTypeFormula.FindStringExact(tdbcTypeFormula.Text) = -1 Then tdbcTypeFormula.SelectedIndex = 0
    End Sub

    Dim sFilterCombo As String = ""
    Private Sub tdbcTypeFormula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tdbcTypeFormula.SelectedValueChanged
        If tdbcTypeFormula.SelectedValue.ToString <> "" Then
            sFilterCombo = "FormulaTypeID = " & SQLString(tdbcTypeFormula.SelectedValue.ToString)
        Else
            sFilterCombo = ""
        End If
        MessageBox.Show("")
        dtGrid.DefaultView.RowFilter = FilterGrid()
        FooterTotalGrid(tdbg, COL_Formula)
    End Sub
#End Region

    Private Sub tdbg_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tdbg.KeyDown
        If e.KeyCode = Keys.Enter Then
            If tdbg.FilterActive Then Exit Sub
            If tdbg.RowCount > 0 Then
                _returnFormular = tdbg.Columns(COL_Formula).Text
                Me.Close()
            End If
        End If

    End Sub

    '#---------------------------------------------------------------------------------------------------
    '# Title: SQLStoreD13P1010
    '# Created User: Hoàng Nhân
    '# Created Date: 22/01/2014 03:30:05
    '#---------------------------------------------------------------------------------------------------
    Private Function SQLStoreD13P1010() As String
        Dim sSQL As String = ""
        sSQL &= ("-- Do nguon luoi" & vbCrlf)
        sSQL &= "Exec D13P1010 "
        sSQL &= SQLString(_formID) & COMMA 'FormID, varchar[20], NOT NULL
        sSQL &= SQLString(gsLanguage) & COMMA 'Language, varchar[2], NOT NULL
        sSQL &= SQLNumber(gbUnicode) 'CodeTable, tinyint, NOT NULL
        Return sSQL
    End Function

    Private Sub D13F2054_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        tdbg.Splits(0).DisplayColumns(COL_Desc).AutoSize()
    End Sub
End Class