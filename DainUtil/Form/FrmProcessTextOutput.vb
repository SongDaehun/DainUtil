Imports System.Data.SqlClient

Public Class FrmProcessTextOutput
    Dim load_flag As Boolean = False
    Dim gWhere As String = ""
    Dim SeqNoTable As DataTable
    Private Sub FrmProcessTextOutput_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        load_flag = True
        Try
            cmbSearch.Items.Clear()
            cmbSearch.Items.Add("미출력분")
            cmbSearch.Items.Add("전체출력")
            cmbSearch.SelectedIndex = 0

            DataCounting()

        Catch ex As Exception

        End Try
        load_flag = False
    End Sub

    Private Sub FrmProcessTextOutput_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown

    End Sub

    Private Sub cmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearch.SelectedIndexChanged
        If load_flag Then Exit Sub
        DataCounting()
    End Sub

    Private Sub DataCounting()
        Dim strSQL As String
        Dim cmd As SqlCommand

        lblDataCount.Text = "0 건"
        strSQL = " SELECT SeqNo FROM " & D_CIPL_H & "  WHERE 1 =1 "
        If cmbSearch.SelectedIndex = 0 Then
            strSQL &= " AND OUTPUTFLAG <> '1'"
            gWhere = " AND OUTPUTFLAG <> '1'"
        Else
            strSQL &= " "
            gWhere = " "
        End If
        cmd = New SqlCommand(strSQL, dbConn)
        SeqNoTable = New DataTable
        SeqNoTable.Load(cmd.ExecuteReader())
        lblDataCount.Text = SeqNoTable.Rows.Count & " 건"
        ProgressBar1.Maximum = SeqNoTable.Rows.Count * 2
        cmd.Dispose()



    End Sub

    Private Sub btnOutput_Click(sender As Object, e As EventArgs) Handles btnOutput.Click
        ProgressBar1.Value = 0

        If SeqNoTable.Rows.Count = 0 Then
            addlog("출력할 데이타가 없습니다.", 2)
            MsgBoxInformation("출력할 데이타가 없습니다.")
            Exit Sub
        End If

        Dim file As System.IO.StreamWriter
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim OutText As String = ""
        Dim SecondFileFlag As Boolean

        'Dim CUSDEC830A1 As String   '[수출신고서 신고내역 - CUSDEC830A1] ''
        'Dim CUSDEC830B1 As String   '[수출신고서 란내역 - CUSDEC830B1]  ''
        'Dim CUSDEC830B5 As String   '[수출신고서 컨테이너내역 - CUSDEC830B5    ''
        'Dim CUSDEC830C1 As String   '[수출신고서 규격내역 - CUSDEC830C1] 반복횟수 0..50 -> (4G) 0..99
        'Dim CUSDEC830D1 As String   '[수출신고서 요건내역 - CUSDEC830D1]  4G - 모델규격 단위 기재사항으로 변경
        'Dim CUSDEC830D2 As String   '[수출신고서 차대관리번호내역 - CUSDEC830D2]  4G - 모델규격 단위 기재사항으로 변경
        Dim REPORTSEQNO As String = ""
        Dim INVOICENO As String = ""
        Dim INVOICETYPE As String = ""
        Dim OUTPUTFILENAME As String
        Dim DataCount As Integer = 0

        Try
            WriteLog("파일출력", N)
            Dim files As String()
            files = System.IO.Directory.GetFiles(G_TextoutPath, "*.*", System.IO.SearchOption.TopDirectoryOnly)
            For i As Integer = 0 To files.Length - 1
                If System.IO.File.Exists(files(i)) Then
                    System.IO.File.Delete(files(i))
                End If
            Next

            For i As Integer = 0 To SeqNoTable.Rows.Count - 1
                strSQL = "  SELECT INVOICENO FROM D_CIPL_H  WHERE  SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "'"
                cmd = New SqlCommand(strSQL, dbConn)
                dr = cmd.ExecuteReader
                dr.Read()
                INVOICENO = dr("INVOICENO")
                dr.Close()
                cmd.Dispose()

                INVOICETYPE = GetInvoiceType(INVOICENO)

                OUTPUTFILENAME = G_TextoutPath & "EXPORT" & "_" & INVOICENO & ".txt"
                For l As Integer = 0 To 1
                    strSQL = XmlReadVal(GetQueryFullPath, "root/OUTPUT/" & INVOICETYPE & "/CUSDEC830A1")
                    ''데이터 존재 체크
                    strSQL &= gWhere
                    strSQL &= " AND HD.SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "'"
                    If l = 0 Then
                        strSQL &= " AND DD.PRODUCT  LIKE '%케피코%' "

                    Else
                        strSQL &= " AND DD.PRODUCT NOT LIKE '%케피코%' "

                    End If
                    cmd = New SqlCommand(strSQL, dbConn)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        DataCount = DataCount + 1
                    End While
                    dr.Close()
                    cmd.Dispose()

                    If DataCount = 0 Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                        Continue For
                    End If

                    ''데이터 존재 체크

                    If System.IO.File.Exists(OUTPUTFILENAME) Then
                        If OUTPUTFILENAME.Contains("-1.txt") = False Then
                            OUTPUTFILENAME = OUTPUTFILENAME.Replace(INVOICENO, INVOICENO & "-1")
                        Else

                        End If
                    End If

                    file = My.Computer.FileSystem.OpenTextFileWriter(OUTPUTFILENAME, False, System.Text.Encoding.Default)

                    For k As Integer = 0 To 5
                        strSQL = ""
                        Select Case k
                            Case 1
                                'CUSDEC830B1
                                strSQL = XmlReadVal(GetQueryFullPath, "root/OUTPUT/" & INVOICETYPE & "/CUSDEC830B1")
                            Case 2
                                'CUSDEC830B5 - 보고 안함
                                'strSQL = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlQuery), "root/CUSDEC830B5")
                            Case 3
                                'CUSDEC830C1
                                strSQL = XmlReadVal(GetQueryFullPath, "root/OUTPUT/" & INVOICETYPE & "/CUSDEC830C1")
                            Case 4
                                'CUSDEC830D1
                                strSQL = XmlReadVal(GetQueryFullPath, "root/OUTPUT/" & INVOICETYPE & "/CUSDEC830D1")
                            Case 5
                                'CUSDEC830D2 - 보고안함
                                'strSQL = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlQuery), "root/CUSDEC830D2")
                            Case Else
                                'CUSDEC830A1'
                                strSQL = XmlReadVal(GetQueryFullPath, "root/OUTPUT/" & INVOICETYPE & "/CUSDEC830A1")
                        End Select

                        If strSQL <> "" Then
                            strSQL &= gWhere
                            strSQL &= " AND HD.SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "'"

                            If l = 0 Then
                                strSQL &= " AND DD.PRODUCT LIKE '%케피코%' "
                            Else
                                strSQL &= " AND DD.PRODUCT NOT LIKE '%케피코%' "
                            End If

                            Select Case k
                                Case 1
                                    If OUTPUTFILENAME.Contains("-1.txt") = False Then
                                        strSQL = strSQL.Replace("%1", " HD.PACKINGLISTNO ")
                                    Else
                                        strSQL = strSQL.Replace("%1", " HD.PACKINGLISTNO + '-1' ")
                                    End If

                                    If l = 0 Then
                                        strSQL = strSQL.Replace("%2", " AND DD2.PRODUCT LIKE '%케피코%' ")
                                        strSQL = strSQL.Replace("%3", " AND DD3.PRODUCT LIKE '%케피코%' ")
                                    Else
                                        strSQL = strSQL.Replace("%2", " AND DD2.PRODUCT NOT LIKE '%케피코%' ")
                                        strSQL = strSQL.Replace("%3", " AND DD3.PRODUCT NOT LIKE '%케피코%' ")
                                    End If
                                Case 2, 3, 4, 5
                                Case Else
                                    If l = 0 Then
                                        strSQL = strSQL.Replace("%1", " AND DD2.PRODUCT LIKE '%케피코%' ")
                                    Else
                                        strSQL = strSQL.Replace("%1", " AND DD2.PRODUCT NOT LIKE '%케피코%' ")
                                    End If
                            End Select

                            'ORDER BY
                            Select Case k
                                Case 1
                                    strSQL &= " ORDER BY RANNUMBER "
                                Case Else
                                    strSQL &= " ORDER BY HD.SEQNO,DD.SEQNO"
                            End Select

                            'ORDER BY

                            'strSQL &= " ORDER BY RANNUMBER"
                            WriteLog(strSQL, W)
                            cmd = New SqlCommand(strSQL, dbConn)
                            dr = cmd.ExecuteReader
                            While dr.Read()
                                If OutText <> "" Then OutText &= vbCrLf
                                For j As Integer = 0 To dr.FieldCount - 1
                                    If j <> 0 Then
                                        OutText &= "^"
                                    End If
                                    OutText &= dr(j)
                                Next
                            End While

                            dr.Close()
                            cmd.Dispose()
                        End If

                    Next
                    If OutText <> "" Then file.WriteLine(OutText)

                    file.Close()

                    If OutText = "" Then
                        System.IO.File.Delete(OUTPUTFILENAME)
                    End If

                    'cmd = New SqlCommand(" UPDATE D_CIPL_H SET OUTPUTFLAG = '1' , OUTPUTDATEANDTIME = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,GETDATE(),120),' ',''),'-',''),':','') WHERE SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "' ", dbConn)
                    'cmd.ExecuteNonQuery()
                    'cmd.Dispose()

                    cmd = New SqlCommand(" UPDATE F_GENENV SET REPORTSEQNO = REPORTSEQNO + 1", dbConn)
                    cmd.ExecuteNonQuery()
                    cmd.Dispose()

                    If OutText <> "" Then
                        strSQL = " SELECT ISNULL(INVOICENO,'') AS INVOICENO FROM D_CIPL_H HD WHERE 1=1  AND HD.SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "'"
                        cmd = New SqlCommand(strSQL, dbConn)
                        dr = cmd.ExecuteReader
                        dr.Read()
                        addlog("[" & dr("INVOICENO") & "] 의 내용을 " & OUTPUTFILENAME & " 에 출력했습니다.", 1)
                        dr.Close()
                        cmd.Dispose()
                    Else
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    OutText = ""
                    'ProgressBar1.Value = ProgressBar1.Value + 1
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    Me.Refresh()
                Next
            Next

            For i As Integer = 0 To SeqNoTable.Rows.Count - 1
                cmd = New SqlCommand(" UPDATE D_CIPL_H SET OUTPUTFLAG = '1' , OUTPUTDATEANDTIME = REPLACE(REPLACE(REPLACE(CONVERT(VARCHAR,GETDATE(),120),' ',''),'-',''),':','') WHERE SEQNO = '" & SeqNoTable.Rows(i)("SEQNO") & "' ", dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Next

            addlog("파일출력을 성공했습니다.", 3)
            MsgBoxOK("파일출력을 성공했습니다.")
        Catch ex As Exception
            addlog("파일출력을 실패했습니다.", 2)
            MsgBoxFail("파일출력을 실패했습니다." & vbCrLf & ex.Message)
        End Try

        btnClose.Visible = True

    End Sub
    Private Sub addlog(ByVal log As String, ByVal type As Integer)
        If txtLog.Text <> "" Then
            Select Case type
                Case 0      '검증
                    txtLog.Text = txtLog.Text & vbCrLf & "[검증]" & log
                    WriteLog(log, W)
                Case 1      '추가`
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = txtLog.Text & vbCrLf & "[추가]" & log
                    WriteLog(log, S)
                Case 2     '실패
                    txtLog.Text = txtLog.Text & vbCrLf & "[실패]" & log
                    WriteLog(log, E)
                Case 3     '알림
                    txtLog.Text = txtLog.Text & vbCrLf & "[알림]" & log
                    WriteLog(log, N)
            End Select

        Else
            Select Case type
                Case 0      '검증
                    txtLog.Text = "[검증]" & log
                    WriteLog(log, W)
                Case 1      '추가
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = "[추가]" & log
                    WriteLog(log, N)
                Case 2     '실패
                    txtLog.Text = "[실패]" & log
                    WriteLog(log, E)
                Case 3     '알림
                    txtLog.Text = "[알림]" & log
                    WriteLog(log, N)
            End Select
        End If
        txtLog.SelectionStart = txtLog.Text.Length
        txtLog.Focus()
        txtLog.ScrollToCaret()
        Me.Refresh()
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class