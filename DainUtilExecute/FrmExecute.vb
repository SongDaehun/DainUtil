Imports System.IO
Imports System.Text.RegularExpressions

Public Class FrmExecute

    Public PGID As String = "DAINUTIL"
    Public VERSION As String = ""
    Public USEDATE As Date
    Public EXEFILENAME As String = ""
    Public DownloadURL As String = ""

    Dim Load_Flag As Boolean
    Dim Logtable As DataTable
    Dim downloadClient As System.Net.WebClient = Nothing

    Private Sub btnExecute_Click(sender As Object, e As EventArgs) Handles btnExecute.Click

    End Sub

    Private Sub FrmExecute_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            Load_Flag = True
            Dim client As System.Net.WebClient = New System.Net.WebClient()
            Dim url As String = "https://docs.google.com/spreadsheets/d/e/2PACX-1vSh8QujNauDRaqeVt3LaLFXPpzj_2Dm07-CR3C4dGYudeEd_mC7eIa9JxdzYwOWLCL_ZZnwNheDJ0uE/pubhtml?gid=0&single=true"

            '指定したURLからデータを取得する
            Dim wkStream As System.IO.Stream = client.OpenRead(url)
            Dim sr As StreamReader = New StreamReader(wkStream, System.Text.Encoding.GetEncoding("utf-8"))
            Dim html As String = sr.ReadToEnd()
            sr.Close()
            wkStream.Close()
            Debug.WriteLine(html)

            html = html.Replace(html.Substring(0,
            html.ToUpper.IndexOf("<TABLE CLASS=""WAFFLE"" CELLSPACING=""0"" CELLPADDING=""0"">")
            ), "")

            html = html.Substring(0,
            html.ToUpper.IndexOf("</TABLE>")
            )
            html = Regex.Replace(html, "<.*?>", " ")
            html = LTrim(html)
            html = RTrim(html)
            html = html.Replace("     ", vbCrLf)
            html = html.Replace("  ", " ")
            html = html.Replace(" ", vbTab)
            html = html.Replace(vbTab & vbTab, vbTab)
            html = html.Replace(vbCrLf & vbTab, vbCrLf)
            txtLog.Text = html



            Dim Temp() As String
            Dim HeaderArray() As String
            Dim DetailArray() As String

            Temp = html.Split(vbCrLf)
            HeaderArray = Temp(0).Split(vbTab)

            Logtable = New DataTable
            For i As Integer = 1 To HeaderArray.Length - 1
                Logtable.Columns.Add(HeaderArray(i), GetType(String))
            Next

            For i As Integer = 1 To Temp.Length - 1
                DetailArray = Temp(i).Split(vbTab)
                Logtable.Rows.Add()
                For j As Integer = 1 To DetailArray.Length - 1

                    If DetailArray(j) IsNot Nothing Then
                        Logtable.Rows(Logtable.Rows.Count - 1).Item(j - 1) = DetailArray(j)
                    Else
                        Logtable.Rows(Logtable.Rows.Count - 1).Item(j - 1) = ""
                    End If
                Next
            Next

            For i As Integer = 0 To Logtable.Rows.Count - 1
                If PGID = Logtable.Rows(i).Item("PGID") Then

                    If IsDBNull(Logtable.Rows(i).Item("VERSION")) = False Then VERSION = Logtable.Rows(i).Item("VERSION")
                    If IsDBNull(Logtable.Rows(i).Item("USEDATE")) = False Then USEDATE = New Date(Logtable.Rows(i).Item("USEDATE").substring(0, 4), Logtable.Rows(i).Item("USEDATE").substring(4, 2), Logtable.Rows(i).Item("USEDATE").substring(6, 2))
                    If IsDBNull(Logtable.Rows(i).Item("EXEFILENAME")) = False Then EXEFILENAME = Logtable.Rows(i).Item("EXEFILENAME")
                    If IsDBNull(Logtable.Rows(i).Item("DOWNLOADURL")) = False Then DownloadURL = Logtable.Rows(i).Item("DOWNLOADURL")
                End If
            Next

            ''보수기간 체크

            btnExecute.Enabled = False
            ''EXE파일 체크
            If System.IO.File.Exists(EXEFILENAME) Then
                FileVersionInfo.GetVersionInfo(Path.Combine(Environment.SystemDirectory, EXEFILENAME))
                Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Environment.SystemDirectory + EXEFILENAME)
                MsgBox(myFileVersionInfo.FileVersion)
            End If

            'WebClientの作成
            Dim dn = New System.Net.WebClient
            dn.DownloadFile(DownloadURL, EXEFILENAME)
            'downloadClient.DownloadFileAsync(u, fileName)

            ''버전비교 체크

        Catch ex As Exception
            Application.Exit()
        Finally
            Load_Flag = False
        End Try
    End Sub



End Class

