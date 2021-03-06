﻿Imports System
Public Class D13F2030
    Private WithEvents backgroundWorker1 As System.ComponentModel.BackgroundWorker

    Private ChildName As String = "D13E0140"
    Dim exe As D13E0140

    Private _absentVoucherNo As String = ""
    Public WriteOnly Property AbsentVoucherNo() As String
        Set(ByVal Value As String)
            _absentVoucherNo = Value
        End Set
    End Property

    Private _absentVoucherID As String = ""
    Public WriteOnly Property AbsentVoucherID() As String
        Set(ByVal Value As String)
            _absentVoucherID = Value
        End Set
    End Property

    Private _remark As String = ""
    Public WriteOnly Property Remark() As String
        Set(ByVal Value As String)
            _remark = Value
        End Set
    End Property

    Private _enabledMenu As String = ""
    Public WriteOnly Property EnabledMenu() As String
        Set(ByVal Value As String)
            _enabledMenu = Value
        End Set
    End Property

    Private Sub backgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles backgroundWorker1.DoWork
        'Tạo một process gắn với exe con, process này sẽ quan sát exe con.
        Dim p As New System.Diagnostics.Process
        Try
            p = Process.GetProcessesByName(ChildName)(0)
        Catch ex As Exception
        End Try
        If p Is Nothing Then
            'D99C0008.MsgL3("Process " & ChildName & " is not running")
            Exit Sub
        End If

        'Chờ đợi exe con tắt tiến trình 
        p.EnableRaisingEvents = True
        p.WaitForExit()
    End Sub

    Private Sub FormLock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Ẩn form trung gian
        Me.Size = New Size(0, 0)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None

        '----Truyền tham số exe con------
        gbSavedOK = False
        exe = New D13E0140(gsServer, gsCompanyID, gsConnectionUser, gsPassword, gsUserID, IIf(geLanguage = EnumLanguage.Vietnamese, "0", "10000").ToString, gsDivisionID, giTranMonth, giTranYear)
        exe.FormActive = enumD13E0140Form.D13F2030 '"D13F2030"
        exe.FormPermission = "D13F2030"
        exe.ID01 = _absentVoucherNo
        exe.ID02 = _absentVoucherID
        exe.ID03 = _remark
        exe.ID04 = _enabledMenu
        exe.CodeTable = gbUnicode.ToString
        exe.Run()
        '------------------------------------

        'Bắt đầu chạy cơ chế background
        backgroundWorker1 = New System.ComponentModel.BackgroundWorker
        backgroundWorker1.RunWorkerAsync()
    End Sub

    'sự kiện hoàn thành và dừng của Background
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles backgroundWorker1.RunWorkerCompleted
        gbSavedOK = CBool(exe.Out_SavedOK)
        Me.Close()
    End Sub

End Class