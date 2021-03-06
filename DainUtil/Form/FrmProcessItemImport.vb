﻿Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmProcessItemImport
    Dim FilePath As String
    Dim DataCount As Integer
    Public Sub New(ByVal pFilePath As String)

        ' 디자이너에서 이 호출이 필요합니다.
        InitializeComponent()
        FilePath = pFilePath
        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하세요.

    End Sub
    Private Sub FrmProcessItemImport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub addlog(ByVal log As String, ByVal type As Integer)
        If txtLog.Text <> "" Then
            Select Case type
                Case 0      '검증
                    txtLog.Text = txtLog.Text & vbCrLf & "[검증]" & log
                Case 1      '추가
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    txtLog.Text = txtLog.Text & vbCrLf & "[추가]" & log
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                Case 2     '실패
                    txtLog.Text = txtLog.Text & vbCrLf & "[실패]" & log
                Case 3     '알림
                    txtLog.Text = txtLog.Text & vbCrLf & "[알림]" & log
            End Select

        Else
            Select Case type
                Case 0      '검증
                    txtLog.Text = "[검증]" & log
                Case 1      '추가
                    If ProgressBar1.Value + 1 <= ProgressBar1.Maximum Then
                        ProgressBar1.Value = ProgressBar1.Value + 1
                    End If
                    lblPercent.Text = CInt(ProgressBar1.Value / ProgressBar1.Maximum * 100).ToString & "%"
                    txtLog.Text = "[추가]" & log
                Case 2     '실패
                    txtLog.Text = "[실패]" & log
                Case 3     '알림
                    txtLog.Text = "[알림]" & log
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

    Private Sub FrmProcessItemImport_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim strSQL As String
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim Partno_Exist As String = ""

        Dim Excel As Excel.Application = New Excel.Application
        Dim Workbook As Excel.Workbook
        Dim WorksheetMITEM As Excel.Worksheet
        Dim i As Integer = 2
        Dim SeqNO As Integer = 0

        Try
            'strSQL = " IF EXISTS (SELECT * FROM SYSOBJECTS   WHERE ID = OBJECT_ID('W_M_ITEM') ) "
            'strSQL &= " DROP TABLE W_M_ITEM "
            'cmd = New SqlCommand(strSQL, dbConn)
            'cmd.ExecuteNonQuery()

            'strSQL = " CREATE TABLE W_M_ITEM( "
            'strSQL &= " SEQNO BIGINT NOT NULL"
            'strSQL &= " ,PARTNO NVARCHAR(20) Not NULL"
            'strSQL &= " ,PARTNAME NVARCHAR(255) "
            'strSQL &= " ,HSCODE NVARCHAR(20) "
            'strSQL &= " ,PRODUCT  NVARCHAR(255) "
            'strSQL &= " ,CONVENTIONCODE NVARCHAR(100) "
            'strSQL &= " ,STANDARDPARTNAME NVARCHAR(255) "
            'strSQL &= " ,TRADEPARTNAME NVARCHAR(255) "
            'strSQL &= " ) "
            strSQL = " TRUNCATE TABLE W_M_ITEM "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            Excel = New Excel.Application
            Workbook = Excel.Workbooks.Open(FilePath)
            WorksheetMITEM = Workbook.Worksheets(1)

            While WorksheetMITEM.Cells(i, 1).Value IsNot Nothing
                DataCount = DataCount + 1
                i = i + 1
            End While
            ProgressBar1.Maximum = DataCount

            i = 2

            While WorksheetMITEM.Cells(i, 1).Value IsNot Nothing
                SeqNO = SeqNO + 1
                strSQL = "INSERT INTO W_M_ITEM VALUES( "
                strSQL &= " '" & SeqNO & "'"
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 1).Value).ToUpper                                                        ''제품코드  
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 2).Value).ToUpper                                                        ''품명규격1 
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 3).Value).ToUpper                                                        ''품명규격2 
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 4).Value).ToUpper                                                        ''세번부호
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 5).Value).ToUpper                                                        ''제조사
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 6).Value).ToString().Replace("-2146826246", "해당없음")        ''협정
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 7).Value).ToUpper                                                        ''표준품명
                strSQL &= " ," & ColumnSet(WorksheetMITEM.Cells(i, 8).Value).ToUpper                                                        ''거래품명
                strSQL &= ")"
                cmd = New SqlCommand(strSQL, dbConn)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
                addlog("[" & WorksheetMITEM.Cells(i, 1).Value & "] 을 추가했습니다.", 1)

                i = i + 1
            End While
            WorksheetMITEM = Nothing
            Workbook.Close(False)
            Excel.Quit()

            strSQL = " SELECT X.* FROM (SELECT  PARTNO, COUNT(*) AS COUNT FROM W_M_ITEM GROUP BY PARTNO) X WHERE X.COUNT > 1 "
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                If Partno_Exist <> "" Then
                    Partno_Exist &= vbCrLf
                End If
                Partno_Exist &= dr("PARTNO")
            End While
            dr.Close()
            cmd.Dispose()

            If Partno_Exist <> "" Then
                addlog(" 아래의  Partno가 중복되어 임포트에 실패했습니다. " & vbCrLf & Partno_Exist, 2)
                Exit Sub
            End If


            strSQL = " UPDATE W_M_ITEM SET CONVENTIONCODE = '해당없음' WHERE CONVENTIONCODE = '' "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            cmd.Dispose()

            strSQL = " DELETE FROM M_ITEM"
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            addlog("상품마스터를 초기화했습니다.", 3)

            strSQL = " INSERT INTO M_ITEM SELECT * FROM W_M_ITEM "
            cmd = New SqlCommand(strSQL, dbConn)
            cmd.ExecuteNonQuery()
            addlog("상품마스터를 반영처리했습니다. .", 3)

            'strSQL = " DROP TABLE W_M_ITEM "
            'cmd = New SqlCommand(strSQL, dbConn)
            'cmd.ExecuteNonQuery()

            MsgBoxInformation("엑셀 임포트가 성공했습니다.")
            addlog("엑셀 임포트가 성공했습니다.", 3)
        Catch ex As Exception
            MsgBoxFail("데이타 갱신에 실패했습니다." & vbCrLf & ex.Message)
            addlog("엑셀 임포트가 성공했습니다.", 2)
        End Try
    End Sub
End Class