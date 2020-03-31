'#------------------------------------------------------
'#Title: D99C1004
'#CreateUser: NGUYEN NGOC THANH
'#CreateDate: 24/03/2004
'#ModifiedUser: Nguyễn Thị Minh Hòa
'#ModifiedDate: 17/06/2008
'#Description: Gởi qua email
'#------------------------------------------------------

Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail

Public Class D99C1004

    'Mảng sử dụng lưu trữ Parameter của Main
    Private arrPName() As Object
    Private arrPValue() As Object

    'Mảng sử dụng lưu trữ Parameter của  Sub
    Private arrPSubName() As Object
    Private arrPSubValue() As Object

    'Mảng sử dụng lưu trữ của Sub Report truyền vào bằng câu SQL
    Private arrSubSQL() As Object
    Private arrSubName() As Object

    'Mảng sử dụng lưu trữ của Sub Report truyền vào bằng Table
    Private arrSubTable() As Object
    Private arrSubNameTable() As Object

    Private PathTemp As String = Application.StartupPath & "\Temp\"
    Private PathExport As String = PathTemp & "Exported\"

    Private myDiskFileDestinationOptions As DiskFileDestinationOptions
    Private myExportOptions As ExportOptions
    Private sExportFileName As String

    Private sMailServer As String
    Private sFrom As String
    Private sTo As String
    Private sCC As String
    Private sBCC As String
    Private sSubject As String
    Private sBody As String

    Public Sub New()

        arrPName = Nothing
        arrPValue = Nothing
        arrPSubName = Nothing
        arrPSubValue = Nothing
        arrSubSQL = Nothing
        arrSubName = Nothing
        arrSubTable = Nothing
        arrSubNameTable = Nothing
        gsMainStrData1 = ""

        rpt1 = New CrystalDecisions.CrystalReports.Engine.ReportDocument

        gbFlagPrint1 = False

        sMailServer = ""
        sFrom = ""
        sTo = ""
        sCC = ""
        sBCC = ""
        sSubject = ""
        sBody = ""

    End Sub

    Public Sub OpenConnection(ByVal mConnection As SqlConnection)
        gcConPrint = mConnection ' gcCon1 = mConnection
    End Sub

    Public Sub AddParameter(ByVal ParameterName As String, ByVal ParameterValue As Object, Optional ByVal TypeParameter As ReportDataType = ReportDataType.lmReportString)

        Try
            If arrPName Is Nothing Then
                ReDim arrPName(0)
                ReDim arrPValue(0)
            Else
                ReDim Preserve arrPName(UBound(arrPName) + 1)
                ReDim Preserve arrPValue(UBound(arrPValue) + 1)
            End If

            arrPName(UBound(arrPName)) = ParameterName
            Select Case TypeParameter
                Case ReportDataType.lmReportDate
                    arrPValue(UBound(arrPValue)) = CDate(ParameterValue)
                Case ReportDataType.lmReportNumber
                    arrPValue(UBound(arrPValue)) = Val(ParameterValue)
                Case ReportDataType.lmReportString
                    arrPValue(UBound(arrPValue)) = CStr(ParameterValue)
                Case ReportDataType.lmReportBoolean
                    arrPValue(UBound(arrPValue)) = CBool(ParameterValue)
            End Select


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

    End Sub

    Public Sub AddParameterSub(ByVal ParameterName As String, ByVal ParameterValue As Object, Optional ByVal TypeParameter As ReportDataType = ReportDataType.lmReportString)
        Try
            If arrPSubName Is Nothing Then
                ReDim arrPSubName(0)
                ReDim arrPSubValue(0)
            Else
                ReDim Preserve arrPSubName(UBound(arrPSubName) + 1)
                ReDim Preserve arrPSubValue(UBound(arrPSubValue) + 1)
            End If

            arrPSubName(UBound(arrPSubName)) = ParameterName
            Select Case TypeParameter
                Case ReportDataType.lmReportDate
                    arrPSubValue(UBound(arrPSubValue)) = CDate(ParameterValue)
                Case ReportDataType.lmReportNumber
                    arrPSubValue(UBound(arrPSubValue)) = Val(ParameterValue)
                Case ReportDataType.lmReportString
                    arrPSubValue(UBound(arrPSubValue)) = CStr(ParameterValue)
                Case ReportDataType.lmReportBoolean
                    arrPSubValue(UBound(arrPSubValue)) = CBool(ParameterValue)
            End Select

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

    End Sub

    Public Sub AddMain(ByVal MainStrSQL As String)
        gsMainStrData1 = MainStrSQL
    End Sub

    Public Sub AddMain(ByVal dt As DataTable)
        'Minh Hòa update: 20/5/2008
        dtReportMain = dt
    End Sub

    Public Sub AddSub(ByVal SubStrSQL As String, ByVal SubReportName As String)

        Try
            If arrSubSQL Is Nothing Then
                ReDim arrSubSQL(0)
                ReDim arrSubName(0)
            Else
                ReDim Preserve arrSubSQL(UBound(arrSubSQL) + 1)
                ReDim Preserve arrSubName(UBound(arrSubName) + 1)
            End If
            arrSubSQL(UBound(arrSubSQL)) = SubStrSQL
            arrSubName(UBound(arrSubName)) = SubReportName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

    End Sub

    Public Sub AddSub(ByVal dt As DataTable, ByVal SubReportName As String)
        'Minh Hòa update: 20/5/2008

        Try
            If arrSubTable Is Nothing Then
                ReDim arrSubTable(0)
                ReDim arrSubNameTable(0)
            Else
                ReDim Preserve arrSubTable(UBound(arrSubTable) + 1)
                ReDim Preserve arrSubNameTable(UBound(arrSubNameTable) + 1)
            End If
            arrSubTable(UBound(arrSubTable)) = dt
            arrSubNameTable(UBound(arrSubNameTable)) = SubReportName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try

    End Sub

    Public Sub AddMailServer(ByVal MailServer As String)
        sMailServer = MailServer
    End Sub

    Public Sub AddSender(ByVal Sender As String)
        sFrom = Sender
    End Sub

    Public Sub AddReceiver(ByVal Receiver As String)
        sTo = Receiver
    End Sub

    Public Sub AddCC_Receiver(ByVal CC_Receiver As String)
        sCC = CC_Receiver
    End Sub

    Public Sub AddBCC_Receiver(ByVal BCC_Receiver As String)
        sBCC = BCC_Receiver
    End Sub

    Public Sub AddSubject(ByVal Subject As String)
        sSubject = Subject
    End Sub

    Public Sub AddBody(ByVal Body As String)
        sBody = Body
    End Sub


    Private _reportCode As String
    Public WriteOnly Property ReportCode() As String
        Set(ByVal Value As String)
            _reportCode = Value
        End Set
    End Property

    Private _employeeID As String
    Public WriteOnly Property EmployeeID() As String
        Set(ByVal Value As String)
            _employeeID = Value
        End Set
    End Property

    Public Function SendMail(ByVal MainReportName As String) As Boolean

        Try

            'Lấy đường dẫn Main report
            gsMainReportName1 = MainReportName

            'Thực hiện dữ liệu in
            Print()

            If gbFlagPrint1 Then 'Lỗi in
                Exit Function
            End If
            'Xuất ra file pdf

            ExportToPDF()

            'Gởi mail
            Return Send()

            'Exit Function

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
            'Exit Function
        End Try

    End Function

    Private Sub Print()

        Dim i As Integer
        Dim i1 As Integer
        Dim j As Integer
        Dim j1 As Integer

        'Contain String Error
        Dim StrError As String

        'Main Report ---------------------------------------------------------------
        Try
            'Update 10/07/2012: đã đưa ra ngoài Form kiểm tra trước
            'If My.Computer.FileSystem.FileExists(gsMainReportName1) = False Then
            '    StrError = "Not exist file report: " & vbCrLf & gsMainReportName1
            '    GoTo Err_Handlling
            'Else
            rpt1.Load(gsMainReportName1, CrystalDecisions.[Shared].OpenReportMethod.OpenReportByTempCopy)
            'End If

        Catch ex As Exception
            StrError = "Open report error." & vbCrLf & "(" & ex.Message & ")"
            GoTo Err_Handlling
        End Try

        Try
            Dim dtMain As DataTable
            If gsMainStrData1 <> "" Then 'Truyền vào Main là câu SQL
                dtMain = GetDataTable(gsMainStrData1)
            Else ' Truyền vào Main là Table
                'Minh Hòa update: 20/5/2008
                dtMain = dtReportMain
            End If
            nRowMaximum = dtMain.Rows.Count
            rpt1.SetDataSource(dtMain)

        Catch ex As Exception
            StrError = "Set data source error." & vbCrLf & "(" & ex.Message & ")"
            GoTo Err_Handlling
        End Try

        'Sub Report ---------------------------------------------------------------
        If arrSubName IsNot Nothing Or arrSubNameTable IsNot Nothing Then
            Dim rptSub() As CrystalDecisions.CrystalReports.Engine.ReportDocument
            'Minh Hòa update: 20/5/2008
            If arrSubName IsNot Nothing And arrSubNameTable Is Nothing Then 'Truyền vào Sub là câu SQL
                ReDim rptSub(UBound(arrSubName))
                For i = 0 To UBound(arrSubName)
                    If CheckExistSubReport(arrSubName(i).ToString) = True Then

                        Try
                            rptSub(i) = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            rptSub(i) = rpt1.OpenSubreport(arrSubName(i).ToString)
                        Catch ex As Exception
                            StrError = "Open sub report <" & rptSub(i).ToString & "> error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                        Try
                            Dim dtSub As DataTable
                            dtSub = GetDataTable(arrSubSQL(i).ToString)
                            rptSub(i).SetDataSource(dtSub)
                        Catch ex As Exception
                            StrError = "Set data source sub error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                    End If
                Next i

            ElseIf arrSubName Is Nothing And arrSubNameTable IsNot Nothing Then 'Truyền vào Sub là Table
                ReDim rptSub(UBound(arrSubNameTable))
                For i = 0 To UBound(arrSubNameTable)
                    If CheckExistSubReport(arrSubNameTable(i).ToString) = True Then

                        Try
                            rptSub(i) = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            rptSub(i) = rpt1.OpenSubreport(arrSubNameTable(i).ToString)
                        Catch ex As Exception
                            StrError = "Open sub report <" & rptSub(i).ToString & "> error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                        Try
                            Dim dtSub As DataTable
                            dtSub = CType(arrSubTable(i), DataTable)
                            rptSub(i).SetDataSource(dtSub)
                        Catch ex As Exception
                            StrError = "Set data source sub error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                    End If
                Next i

            Else 'Truyền vào Sub vừa là câu SQL vừa là Table
                ReDim rptSub(UBound(arrSubName) + UBound(arrSubNameTable))
                For i = 0 To UBound(arrSubName)
                    If CheckExistSubReport(arrSubName(i).ToString) = True Then

                        Try
                            rptSub(i) = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            rptSub(i) = rpt1.OpenSubreport(arrSubName(i).ToString)
                        Catch ex As Exception
                            StrError = "Open sub report <" & rptSub(i).ToString & "> error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                        Try
                            Dim dtSub As DataTable
                            dtSub = GetDataTable(arrSubSQL(i).ToString)
                            rptSub(i).SetDataSource(dtSub)
                        Catch ex As Exception
                            StrError = "Set data source sub error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                    End If
                Next i

                For j = 0 To UBound(arrSubNameTable)
                    If CheckExistSubReport(arrSubNameTable(j).ToString) = True Then

                        Try
                            rptSub(i + j) = New CrystalDecisions.CrystalReports.Engine.ReportDocument
                            rptSub(i + j) = rpt1.OpenSubreport(arrSubNameTable(j).ToString)
                        Catch ex As Exception
                            StrError = "Open sub report <" & rptSub(i + j).ToString & "> error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                        Try
                            Dim dtSub As DataTable
                            dtSub = CType(arrSubTable(j), DataTable)
                            rptSub(i + j).SetDataSource(dtSub)
                        Catch ex As Exception
                            StrError = "Set data source sub error." & vbCrLf & "(" & ex.Message & ")"
                            GoTo Err_Handlling
                        End Try

                    End If
                Next j

            End If

            'Sub Parameter ---------------------------------------------------------------
            If arrPSubName IsNot Nothing Then
                Dim pvCollectionSub As New CrystalDecisions.Shared.ParameterValues
                Dim pdvValueIDSub As New CrystalDecisions.Shared.ParameterDiscreteValue

                Try
                    j1 = 0
NextParaSub:
                    For j = j1 To UBound(arrPSubName)
                        pdvValueIDSub.Value = arrPSubValue(i)
                        pvCollectionSub.Add(pdvValueIDSub)
                        rpt1.DataDefinition.ParameterFields(arrPSubName(i).ToString).ApplyCurrentValues(pvCollectionSub)
                        pvCollectionSub.Clear()
                    Next

                Catch ex As Exception
                    j1 = j + 1
                    GoTo NextParaSub
                End Try

            End If

        End If

        'Main Parameter ---------------------------------------------------------------
        If arrPName IsNot Nothing Then
            Dim pvCollection As New CrystalDecisions.Shared.ParameterValues
            Dim pdvValueID As New CrystalDecisions.Shared.ParameterDiscreteValue
            Try
                i1 = 0
NextParaMain:
                For i = i1 To UBound(arrPName)
                    pdvValueID.Value = arrPValue(i)
                    pvCollection.Add(pdvValueID)
                    rpt1.DataDefinition.ParameterFields(arrPName(i).ToString).ApplyCurrentValues(pvCollection)
                    pvCollection.Clear()
                Next
            Catch ex As Exception
                i1 = i + 1
                GoTo NextParaMain
            End Try
        End If

        Exit Sub

Err_Handlling:

        MessageBox.Show(StrError, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        gbFlagPrint1 = True

    End Sub

    Private Sub ExportToPDF()

        Try

            'Tạo thư mục chứa file Export tạm
            If Not My.Computer.FileSystem.DirectoryExists(PathTemp) Then
                My.Computer.FileSystem.CreateDirectory(PathTemp)
                My.Computer.FileSystem.CreateDirectory(PathExport)
            Else
                If Not My.Computer.FileSystem.DirectoryExists(PathExport) Then
                    My.Computer.FileSystem.CreateDirectory(PathExport)
                End If
            End If

            myDiskFileDestinationOptions = New DiskFileDestinationOptions()
            myExportOptions = rpt1.ExportOptions
            myExportOptions.ExportDestinationType = ExportDestinationType.DiskFile
            myExportOptions.FormatOptions = Nothing

            'Update 10/07/2012: file đính kèm pdf có dạng Tên report + ReportCode + EmployeeID
            'sExportFileName = PathExport & My.Computer.FileSystem.GetName(gsMainReportName1).Substring(0, 8) & ".pdf"
            sExportFileName = PathExport & My.Computer.FileSystem.GetName(gsMainReportName1).Substring(0, 8) & "_" & _reportCode & "_" & _employeeID & ".pdf"

            If My.Computer.FileSystem.FileExists(sExportFileName) Then
                My.Computer.FileSystem.DeleteFile(sExportFileName)
            End If

            myExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat
            myDiskFileDestinationOptions.DiskFileName = sExportFileName
            myExportOptions.DestinationOptions = myDiskFileDestinationOptions

            rpt1.Export()

            'MsgBox("Pass Export")

            Exit Sub

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try

    End Sub

    'Gởi mail
    Private Function Send() As Boolean
        Dim objMsg As New MailMessage
        Dim Objadd As MailAddress
        Dim myAttachment As Attachment = New Attachment(sExportFileName)

        Try
            'MsgBox("Before Add InfoMail, From: " & sFrom & ", To: " & sTo & ", Attachments:" & sExportFileName)

            Objadd = New MailAddress(sFrom)
            With objMsg

                .From = Objadd
                .To.Add(sTo)
                If sCC <> "" Then .CC.Add(sCC)
                If sBCC <> "" Then .Bcc.Add(sBCC)

                .Subject = sSubject
                .Body = sBody
                .Attachments.Add(myAttachment)

            End With

            'MsgBox("Pass Add InfoMail")
            ' MessageBox.Show("Send() 1: sFrom = " & sFrom & " - sTo = " & sTo) ''''

            Dim strHost As String = sMailServer.Substring(0, sMailServer.Length - sMailServer.Substring(sMailServer.IndexOf(":")).Length)
            Dim sPort As Integer = Convert.ToInt32(sMailServer.Substring(sMailServer.IndexOf(":") + 1))

            '   MessageBox.Show("Send() 2: strHost=" & strHost & " - sPort=" & sPort) ''''

            Dim ObjSending As New SmtpClient(strHost, sPort)
            With ObjSending
                .UseDefaultCredentials = True
                'MsgBox("Before Send, MailServer: " & strHost & ":" & sPort)

                .Send(objMsg)
                'MsgBox("Pass Send")
            End With

            objMsg.Dispose()
            Return True
            'Exit Function

        Catch ex As Exception
            '  MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End Try

    End Function

    Private Function GetDataTable(ByVal StrSql As String) As Data.DataTable
        Dim ds As New DataSet

        Try
            'Modify: MinhHoa 28/02/2008
            'Dim cmd As SqlCommand = New SqlCommand(StrSql, gcCon1)
            Dim cmd As SqlCommand = New SqlCommand(StrSql, gcConPrint)
            'Dim Sda As New SqlDataAdapter(StrSql, gcCon1)
            Dim Sda As New SqlDataAdapter(cmd)
            cmd.CommandTimeout = 0
            Sda.Fill(ds)
            Return ds.Tables(0)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End Try

    End Function

    'Kiểm tra sự tồn tại của Sub Report trên báo cáo
    Private Function CheckExistSubReport(ByVal sSubNameSource As String) As Boolean
        Dim i As Integer

        For i = 0 To rpt1.Subreports.Count - 1
            If rpt1.Subreports(i).Name = sSubNameSource Then
                Return True
            End If
        Next

        Return False

    End Function

End Class
