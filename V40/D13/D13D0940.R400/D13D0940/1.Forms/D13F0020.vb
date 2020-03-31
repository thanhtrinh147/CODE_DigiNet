Public Class D13F0020
    Dim sSQL As String
    Dim dtInc As DataTable
    Dim i As Integer

    Private Sub LoadInc()
        sSQL = ""
        sSQL &= "Select Code,Description, DescriptionU,Short, ShortU,Disabled From D13T9000  WITH (NOLOCK) Where Type='PRMAS' order by Code "
        dtInc = ReturnDataTable(sSQL)
        If dtInc.Rows.Count > 0 Then
            For i = 0 To 29
                With dtInc.Rows(i)
                    Select Case .Item("Code").ToString
                        Case "INC01"
                            txtDescription1.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName1.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse1.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC02"
                            txtDescription2.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName2.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse2.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC03"
                            txtDescription3.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName3.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse3.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC04"
                            txtDescription4.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName4.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse4.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC05"
                            txtDescription5.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName5.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse5.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC06"
                            txtDescription6.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName6.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse6.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC07"
                            txtDescription7.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName7.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse7.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC08"
                            txtDescription8.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName8.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse8.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC09"
                            txtDescription9.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName9.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse9.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC10"
                            txtDescription10.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName10.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse10.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC11"
                            txtDescription11.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName11.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse11.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC12"
                            txtDescription12.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName12.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse12.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC13"
                            txtDescription13.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName13.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse13.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC14"
                            txtDescription14.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName14.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse14.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC15"
                            txtDescription15.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName15.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse15.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC16"
                            txtDescription16.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName16.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse16.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC17"
                            txtDescription17.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName17.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse17.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC18"
                            txtDescription18.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName18.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse18.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC19"
                            txtDescription19.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName19.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse19.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC20"
                            txtDescription20.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName20.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse20.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC21"
                            txtDescription21.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName21.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse21.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC22"
                            txtDescription22.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName22.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse22.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC23"
                            txtDescription23.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName23.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse23.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC24"
                            txtDescription24.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName24.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse24.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC25"
                            txtDescription25.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName25.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse25.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC26"
                            txtDescription26.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName26.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse26.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC27"
                            txtDescription27.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName27.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse27.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC28"
                            txtDescription28.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName28.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse28.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC29"
                            txtDescription29.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName29.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse29.Checked = Not (CBool(.Item("Disabled")))
                        Case "INC30"
                            txtDescription30.Text = .Item("Description" & UnicodeJoin(gbUnicode)).ToString
                            txtShortName30.Text = .Item("Short" & UnicodeJoin(gbUnicode)).ToString
                            chkUse30.Checked = Not (CBool(.Item("Disabled")))
                    End Select
                End With

            Next
        End If
    End Sub

    Private Sub D13F0020_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        FormKeyPress(sender, e)
    End Sub

    Private Sub D13F0020_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
	LoadInfoGeneral()
        Loadlanguage()
        LoadInc()
        CheckPermission()
        SetResolutionForm(Me)
        InputbyUnicode(Me, gbUnicode)
    End Sub

    Protected Sub CheckPermission()
        Dim per As Integer = ReturnPermission(Me.Name) 'Dùng kiểm tra form đang ở quyền nào
        If per = 1 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub
    Private Function SQLUpdateD13T9000() As String
        Dim sSQL As String
        sSQL = ""
        'INC01
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription1, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription1, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName1, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName1, True)
        sSQL &= " , Disabled= " & IIf(chkUse1.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC01' " & vbCrLf

        'INC02
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription2, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription2, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName2, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName2, True)
        sSQL &= " , Disabled= " & IIf(chkUse2.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC02' " & vbCrLf

        'INC03
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription3, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription3, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName3, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName3, True)
        sSQL &= " , Disabled= " & IIf(chkUse3.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC03' " & vbCrLf

        'INC04
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription4, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription4, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName4, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName4, True)
        sSQL &= " , Disabled= " & IIf(chkUse4.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC04' " & vbCrLf

        'INC05
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription5, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription5, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName5, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName5, True)
        sSQL &= " , Disabled= " & IIf(chkUse5.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC05' " & vbCrLf

        'INC06
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription6, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription6, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName6, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName6, True)
        sSQL &= " , Disabled= " & IIf(chkUse6.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC06' " & vbCrLf

        'INC07
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription7, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription7, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName7, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName7, True)
        sSQL &= " , Disabled= " & IIf(chkUse7.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC07' " & vbCrLf

        'INC08
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription8, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription8, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName8, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName8, True)
        sSQL &= " , Disabled= " & IIf(chkUse8.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC08' " & vbCrLf

        'INC09
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription9, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription9, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName9, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName9, True)
        sSQL &= " , Disabled= " & IIf(chkUse9.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC09' " & vbCrLf

        'INC10
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription10, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription10, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName10, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName10, True)
        sSQL &= " , Disabled= " & IIf(chkUse10.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC10' " & vbCrLf

        'INC11
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription11, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription11, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName11, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName11, True)
        sSQL &= " , Disabled= " & IIf(chkUse11.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC11' " & vbCrLf

        'INC12
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription12, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription12, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName12, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName12, True)
        sSQL &= " , Disabled= " & IIf(chkUse12.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC12' " & vbCrLf

        'INC13
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription13, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription13, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName13, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName13, True)
        sSQL &= " , Disabled= " & IIf(chkUse13.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC13' " & vbCrLf

        'INC14
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription14, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription14, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName14, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName14, True)
        sSQL &= " , Disabled= " & IIf(chkUse14.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC14' " & vbCrLf

        'INC15
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription15, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription15, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName15, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName15, True)
        sSQL &= " , Disabled= " & IIf(chkUse15.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC15' " & vbCrLf

        'INC16
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription16, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription16, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName16, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName16, True)
        sSQL &= " , Disabled= " & IIf(chkUse16.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC16' " & vbCrLf

        'INC17
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription17, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription17, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName17, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName17, True)
        sSQL &= " , Disabled= " & IIf(chkUse17.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC17' " & vbCrLf

        'INC18
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription18, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription18, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName18, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName18, True)
        sSQL &= " , Disabled= " & IIf(chkUse18.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC18' " & vbCrLf

        'INC19
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription19, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription19, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName19, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName19, True)
        sSQL &= " , Disabled= " & IIf(chkUse19.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC19' " & vbCrLf

        'INC20
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription20, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription20, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName20, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName20, True)
        sSQL &= " , Disabled= " & IIf(chkUse20.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC20' " & vbCrLf

        'INC21
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription21, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription21, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName21, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName21, True)
        sSQL &= " , Disabled= " & IIf(chkUse21.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC21' " & vbCrLf

        'INC22
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription22, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription22, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName22, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName22, True)
        sSQL &= " , Disabled= " & IIf(chkUse22.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC22' " & vbCrLf

        'INC23
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription23, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription23, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName23, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName23, True)
        sSQL &= " , Disabled= " & IIf(chkUse23.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC23' " & vbCrLf

        'INC24
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription24, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription24, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName24, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName24, True)
        sSQL &= " , Disabled= " & IIf(chkUse24.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC24' " & vbCrLf

        'INC25
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription25, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription25, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName25, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName25, True)
        sSQL &= " , Disabled= " & IIf(chkUse25.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC25' " & vbCrLf

        'INC26
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription26, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription26, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName26, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName26, True)
        sSQL &= " , Disabled= " & IIf(chkUse26.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC26' " & vbCrLf

        'INC27
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription27, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription27, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName27, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName27, True)
        sSQL &= " , Disabled= " & IIf(chkUse27.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC27' " & vbCrLf

        'INC28
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription28, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription28, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName28, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName28, True)
        sSQL &= " , Disabled= " & IIf(chkUse28.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC28' " & vbCrLf

        'INC29
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription29, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription29, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName29, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName29, True)
        sSQL &= " , Disabled= " & IIf(chkUse29.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC29' " & vbCrLf

        'INC30
        sSQL &= " Update  D13T9000 Set "
        sSQL &= " Description=" & SQLStringUnicode(txtDescription30, False)
        sSQL &= " , DescriptionU=" & SQLStringUnicode(txtDescription30, True)
        sSQL &= " , Short= " & SQLStringUnicode(txtShortName30, False)
        sSQL &= " , ShortU= " & SQLStringUnicode(txtShortName30, True)
        sSQL &= " , Disabled= " & IIf(chkUse30.Checked = True, 0, 1).ToString
        sSQL &= " Where Type='PRMAS' AND Code='INC30' " & vbCrLf
        Return sSQL
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If AskSave() = Windows.Forms.DialogResult.No Then Exit Sub
        If Not AllowSave() Then Exit Sub
        Dim sSQL As String = ""

        Me.Cursor = Cursors.WaitCursor
        sSQL = SQLUpdateD13T9000()
        Dim bRunSQL As Boolean = ExecuteSQL(sSQL)
        Me.Cursor = Cursors.Default
        If bRunSQL Then
            SaveOK()
            btnClose.Focus()
        Else
            SaveNotOK()
        End If
    End Sub

    Private Function AllowSave() As Boolean
        AllowSave = False
        'INC01
        If chkUse1.Checked Then
            If Trim(txtDescription1.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription1.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription1.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription1.Focus()
                Exit Function
            End If
            If Trim(txtShortName1.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName1.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName1.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName1.Focus()
                Exit Function
            End If
        End If

        'INC02
        If chkUse2.Checked Then
            If Trim(txtDescription2.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription2.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription2.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription2.Focus()
                Exit Function
            End If
            If Trim(txtShortName2.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName2.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName2.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName2.Focus()
                Exit Function
            End If
        End If

        'INC03
        If chkUse3.Checked Then
            If Trim(txtDescription3.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription3.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription3.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription3.Focus()
                Exit Function
            End If
            If Trim(txtShortName3.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName3.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName3.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName3.Focus()
                Exit Function
            End If
        End If

        'INC04
        If chkUse4.Checked Then
            If Trim(txtDescription4.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription4.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription4.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription4.Focus()
                Exit Function
            End If
            If Trim(txtShortName4.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName4.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName4.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName4.Focus()
                Exit Function
            End If
        End If

        'INC05
        If chkUse5.Checked Then
            If Trim(txtDescription5.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription5.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription5.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription5.Focus()
                Exit Function
            End If
            If Trim(txtShortName5.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName5.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName5.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName5.Focus()
                Exit Function
            End If
        End If

        'INC06
        If chkUse6.Checked Then
            If Trim(txtDescription6.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription6.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription6.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription6.Focus()
                Exit Function
            End If
            If Trim(txtShortName6.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName6.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName6.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName6.Focus()
                Exit Function
            End If
        End If

        'INC07
        If chkUse7.Checked Then
            If Trim(txtDescription7.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription7.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription7.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription7.Focus()
                Exit Function
            End If
            If Trim(txtShortName7.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName7.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName7.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName7.Focus()
                Exit Function
            End If
        End If

        'INC08
        If chkUse8.Checked Then
            If Trim(txtDescription8.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription8.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription8.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription8.Focus()
                Exit Function
            End If
            If Trim(txtShortName8.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName8.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName8.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName8.Focus()
                Exit Function
            End If
        End If

        'INC09
        If chkUse9.Checked Then
            If Trim(txtDescription9.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription9.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription9.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription9.Focus()
                Exit Function
            End If
            If Trim(txtShortName9.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName9.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName9.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName9.Focus()
                Exit Function
            End If
        End If

        'INC10
        If chkUse10.Checked Then
            If Trim(txtDescription10.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription10.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription10.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription10.Focus()
                Exit Function
            End If
            If Trim(txtShortName10.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName10.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName10.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName10.Focus()
                Exit Function
            End If
        End If

        'INC11
        If chkUse11.Checked Then
            If Trim(txtDescription11.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription11.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription11.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription11.Focus()
                Exit Function
            End If
            If Trim(txtShortName11.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName11.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName11.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName11.Focus()
                Exit Function
            End If
        End If

        'INC12
        If chkUse12.Checked Then
            If Trim(txtDescription12.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription12.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription12.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription12.Focus()
                Exit Function
            End If
            If Trim(txtShortName12.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName12.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName12.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName12.Focus()
                Exit Function
            End If
        End If

        'INC13
        If chkUse13.Checked Then
            If Trim(txtDescription13.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription13.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription13.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription13.Focus()
                Exit Function
            End If
            If Trim(txtShortName13.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName13.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName13.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName13.Focus()
                Exit Function
            End If
        End If

        'INC14
        If chkUse14.Checked Then
            If Trim(txtDescription14.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription14.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription14.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription14.Focus()
                Exit Function
            End If
            If Trim(txtShortName14.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName14.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName14.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName14.Focus()
                Exit Function
            End If
        End If

        'INC15
        If chkUse15.Checked Then
            If Trim(txtDescription15.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription15.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription15.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription15.Focus()
                Exit Function
            End If
            If Trim(txtShortName15.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName15.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName15.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName15.Focus()
                Exit Function
            End If
        End If

        'INC16
        If chkUse16.Checked Then
            If Trim(txtDescription16.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription16.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription16.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription16.Focus()
                Exit Function
            End If
            If Trim(txtShortName16.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName16.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName16.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName16.Focus()
                Exit Function
            End If
        End If

        'INC17
        If chkUse17.Checked Then
            If Trim(txtDescription17.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription17.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription17.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription17.Focus()
                Exit Function
            End If
            If Trim(txtShortName17.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName17.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName17.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName17.Focus()
                Exit Function
            End If
        End If

        'INC18
        If chkUse18.Checked Then
            If Trim(txtDescription18.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription18.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription18.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription18.Focus()
                Exit Function
            End If
            If Trim(txtShortName18.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName18.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName18.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName18.Focus()
                Exit Function
            End If
        End If

        'INC19
        If chkUse19.Checked Then
            If Trim(txtDescription19.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription19.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription19.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription19.Focus()
                Exit Function
            End If
            If Trim(txtShortName19.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName19.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName19.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName19.Focus()
                Exit Function
            End If
        End If

        'INC20
        If chkUse20.Checked Then
            If Trim(txtDescription20.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription20.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription20.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription20.Focus()
                Exit Function
            End If
            If Trim(txtShortName20.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName20.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName20.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName20.Focus()
                Exit Function
            End If
        End If

        'INC21
        If chkUse21.Checked Then
            If Trim(txtDescription21.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription21.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription21.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription21.Focus()
                Exit Function
            End If
            If Trim(txtShortName21.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName21.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName21.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName21.Focus()
                Exit Function
            End If
        End If

        'INC22
        If chkUse22.Checked Then
            If Trim(txtDescription22.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription22.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription22.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription22.Focus()
                Exit Function
            End If
            If Trim(txtShortName22.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName22.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName22.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName22.Focus()
                Exit Function
            End If
        End If

        'INC23
        If chkUse23.Checked Then
            If Trim(txtDescription23.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription23.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription23.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription23.Focus()
                Exit Function
            End If
            If Trim(txtShortName23.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName23.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName23.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName23.Focus()
                Exit Function
            End If
        End If


        'INC24
        If chkUse24.Checked Then
            If Trim(txtDescription24.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription24.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription24.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription24.Focus()
                Exit Function
            End If
            If Trim(txtShortName24.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName24.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName24.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName24.Focus()
                Exit Function
            End If
        End If


        'INC25
        If chkUse25.Checked Then
            If Trim(txtDescription25.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription25.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription25.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription25.Focus()
                Exit Function
            End If
            If Trim(txtShortName25.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName25.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName25.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName25.Focus()
                Exit Function
            End If
        End If


        'INC26
        If chkUse26.Checked Then
            If Trim(txtDescription26.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription26.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription26.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription26.Focus()
                Exit Function
            End If
            If Trim(txtShortName26.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName26.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName26.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName26.Focus()
                Exit Function
            End If
        End If


        'INC27
        If chkUse27.Checked Then
            If Trim(txtDescription27.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription27.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription27.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription27.Focus()
                Exit Function
            End If
            If Trim(txtShortName27.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName27.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName27.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName27.Focus()
                Exit Function
            End If
        End If


        'INC28
        If chkUse28.Checked Then
            If Trim(txtDescription28.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription28.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription28.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription28.Focus()
                Exit Function
            End If
            If Trim(txtShortName28.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName28.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName28.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName28.Focus()
                Exit Function
            End If
        End If


        'INC29
        If chkUse29.Checked Then
            If Trim(txtDescription29.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription29.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription29.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription29.Focus()
                Exit Function
            End If
            If Trim(txtShortName29.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName29.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName29.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName29.Focus()
                Exit Function
            End If
        End If


        'INC30
        If chkUse30.Checked Then
            If Trim(txtDescription30.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_dien_giai"))
                txtDescription30.Focus()
                Exit Function
            End If
            If Len(Trim(txtDescription30.Text)) > 150 Then
                D99C0008.Msg(rl3("Do_dai_dien_giai_khong_vuot_qua_150_ky_tu"))
                txtDescription30.Focus()
                Exit Function
            End If
            If Trim(txtShortName30.Text) = "" Then
                D99C0008.Msg(rl3("Ban_phai_nhap_ten_tat"))
                txtShortName30.Focus()
                Exit Function
            End If
            If Len(Trim(txtShortName30.Text)) > 20 Then
                D99C0008.Msg(rl3("Do_dai_ten_tat_khong_vuot_qua_20_ky_tu"))
                txtShortName30.Focus()
                Exit Function
            End If
        End If

        AllowSave = True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Loadlanguage()
        '================================================================ 
        Me.Text = rl3("Dinh_nghia_cac_khoan_thu_nhap_tai_ho_so_luong_-_D13F0020") & UnicodeCaption(gbUnicode) '˜Ünh nghÚa cÀc kho¶n thu nhËp tÁi hä s¥ l§¥ng - D13F0020
        '================================================================ 
        lblShortName1.Text = rl3("Ten_tat") 'Tên tắt
        lblDescription1.Text = rl3("Dien_giai") 'Diễn giải
        lbluse1.Text = rl3("Su_dung") 'Sử dụng
        lblUsed.Text = rl3("Su_dung") 'Sử dụng
        lblSTT1.Text = rl3("STT") 'STT
        lblShortName.Text = rl3("Ten_tat") 'Tên tắt
        lblDescription.Text = rl3("Dien_giai") 'Diễn giải
        lblNumber.Text = rl3("STT") 'STT
        '================================================================ 
        btnSave.Text = rl3("_Luu") '&Lưu
        btnClose.Text = rl3("Do_ng") 'Đó&ng
        '================================================================ 
        grpIncome.Text = rl3("Dinh_nghia_cac_khoan_thu_nhap_tai_ho_so_luong") 'Định nghĩa các khoản thu nhập tại hồ sơ lương
    End Sub


End Class