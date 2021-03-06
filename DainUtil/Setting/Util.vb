﻿Imports System.Xml
Imports System.Data.SqlClient
Imports System.IO
Module Util
    Function MsgBoxOK(ByVal message As String)
        WriteLog(message, S)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
        )
    End Function

    Function MsgBoxFail(ByVal message As String)
        WriteLog(message, E)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
        )
    End Function

    Function MsgBoxExclamation(ByVal message As String)
        WriteLog(message, N)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Exclamation
        )
    End Function

    Function MsgBoxInformation(ByVal message As String)
        WriteLog(message, N)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
        )
    End Function

    Function MsgBoxConfirm(ByVal message As String)
        Return MessageBox.Show(message,
    G_APPNAME,
    MessageBoxButtons.YesNo,
                               MessageBoxIcon.Information
    )
    End Function
    Function ColumnSet(ByVal column As String)

        If column IsNot Nothing Then
            If column = "" Then
                Return "''"
            Else
                Return "'" & column.Replace("'", "''") & "'"
            End If
        Else
            Return "NULL"
        End If

    End Function
    Function ColumnSet2(ByVal column As Object)
        If IsDBNull(column) = False Then
            If column IsNot Nothing Then
                If column = "" Then
                    Return "''"
                Else
                    Return "'" & column.Replace("'", "''") & "'"
                End If
            Else
                Return "NULL"
            End If
        Else
            Return "NULL"
        End If


    End Function

    Function ColumnSet_Item(ByVal column As String)

        If column IsNot Nothing Then
            If column = "" Then
                Return "''"
            Else
                Return "'" & column.Replace("'", "''").ToUpper & "'"
            End If
        Else
            Return "NULL"
        End If

    End Function
    Function GetConventionCode(ByVal PartNo As String) As String
        Dim strSQL As String = "SELECT TOP 1 ISNULL(CONVENTIONCODE,'') AS CONVENTIONCODE FROM M_ITEM WHERE PARTNO = '" & PartNo & "'"
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dataCount As Integer

        cmd = New SqlCommand(strSQL, dbConn)
        dr = cmd.ExecuteReader
        While dr.Read()
            GetConventionCode = "'" & dr("CONVENTIONCODE") & "'"
            dataCount = dataCount + 1
        End While
        dr.Close()
        cmd.Dispose()

        If dataCount = 0 Then
            GetConventionCode = "''"
        End If
    End Function

    Function GetHSCode(ByVal PartNo As String) As String
        Dim strSQL As String = "SELECT TOP 1 ISNULL(HSCODE,'') AS HSCODE FROM M_ITEM WHERE PARTNO = '" & PartNo & "'"
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dataCount As Integer

        cmd = New SqlCommand(strSQL, dbConn)
        dr = cmd.ExecuteReader
        While dr.Read()
            GetHSCode = "'" & dr("HSCODE") & "'"
            dataCount = dataCount + 1
        End While
        dr.Close()
        cmd.Dispose()

        If dataCount = 0 Then
            GetHSCode = "''"
        End If
    End Function
    Public Function getFiles(ByVal SourceFolder As String, ByVal Filter As String,
 ByVal searchOption As System.IO.SearchOption) As String()
        ' ArrayList will hold all file names
        Dim alFiles As ArrayList = New ArrayList()

        ' Create an array of filter string
        Dim MultipleFilters() As String = Filter.Split("|")

        ' for each filter find mathing file names
        For Each FileFilter As String In MultipleFilters
            ' add found file names to array list
            alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption))
        Next

        ' returns string array of relevant file names
        Return alFiles.ToArray(Type.GetType("System.String"))
    End Function

#Region "　LeftB メソッド　"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の左端から指定したバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。<param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     左端から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function LeftB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
        Return MidB(stTarget, 1, iByteSize)
    End Function

#End Region


#Region "　MidB メソッド (+1)　"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の指定されたバイト位置以降のすべての文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iStart">
    '''     取り出しを開始する位置。</param>
    ''' <returns>
    '''     指定されたバイト位置以降のすべての文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function MidB(ByVal stTarget As String, ByVal iStart As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, btBytes.Length - iStart + 1)
    End Function


    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の指定されたバイト位置から、指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iStart">
    '''     取り出しを開始する位置。</param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     指定されたバイト位置から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function MidB _
        (ByVal stTarget As String, ByVal iStart As Integer, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, iStart - 1, iByteSize)
    End Function

#End Region


#Region "　RightB メソッド　"

    ''' -----------------------------------------------------------------------------------------
    ''' <summary>
    '''     文字列の右端から指定されたバイト数分の文字列を返します。</summary>
    ''' <param name="stTarget">
    '''     取り出す元になる文字列。</param>
    ''' <param name="iByteSize">
    '''     取り出すバイト数。</param>
    ''' <returns>
    '''     右端から指定されたバイト数分の文字列。</returns>
    ''' -----------------------------------------------------------------------------------------
    Public Function RightB(ByVal stTarget As String, ByVal iByteSize As Integer) As String
        Dim hEncoding As System.Text.Encoding = System.Text.Encoding.GetEncoding("Shift_JIS")
        Dim btBytes As Byte() = hEncoding.GetBytes(stTarget)

        Return hEncoding.GetString(btBytes, btBytes.Length - iByteSize, iByteSize)
    End Function

#End Region

    Public Function XmlReadVal(ByVal filePath As String, ByVal nodePath As String) As String

        Dim xmlDoc As New XmlDocument
        Dim xmlNode As Xml.XmlNode  'ノードパスから値を取得

        Try
            xmlDoc.Load(filePath)  'xmlドキュメントのLoad
            xmlNode = xmlDoc.SelectSingleNode(nodePath)
            If xmlNode IsNot Nothing Then
                XmlReadVal = xmlNode.InnerText '項目値を取得
            Else
                XmlReadVal = ""
            End If
        Catch ex As Exception
            XmlReadVal = ""
        Finally
            xmlNode = Nothing
            xmlDoc = Nothing
        End Try

    End Function

    Public Function XmlReadAttribute(ByVal filePath As String, ByVal nodePath As String) As String

        Dim xmlDoc As New XmlDocument
        Dim xmlNode As Xml.XmlNode  'ノードパスから値を取得

        Try
            xmlDoc.Load(filePath)  'xmlドキュメントのLoad
            xmlNode = xmlDoc.SelectSingleNode(nodePath)
            XmlReadAttribute = xmlNode.Attributes("NAME").Value
        Catch ex As Exception
            XmlReadAttribute = ""
        Finally
            xmlNode = Nothing
            xmlDoc = Nothing
        End Try

    End Function


    Public Function DirYenFix(ByVal sDir As String) As String
        If Len(Trim(sDir)) > 0 Then
            DirYenFix = sDir & IIf(Right(sDir, 1) = "\", "", "\")
        Else
            DirYenFix = ""
        End If
    End Function

    Public E As Integer = 3
    Public S As Integer = 2
    Public W As Integer = 1
    Public N As Integer = 0
    Public Function WriteLog(ByVal Log As String, Optional ByVal processnumber As Integer = 0) As Boolean
        Dim file As StreamWriter
        Dim process As String

        Try
            Select Case processnumber
                Case 3
                    process = "E"           'Error
                Case 2
                    process = "S"           'Success
                Case 1
                    process = "W"           'Working
                Case Else
                    process = "N"           'Notify
            End Select

            If System.IO.Directory.Exists(G_APPPath & "\LOG") = False Then
                System.IO.Directory.CreateDirectory(G_APPPath & "\LOG")

            End If

            file = My.Computer.FileSystem.OpenTextFileWriter(G_APPPath & "\LOG\" & DateTime.Now.ToString("MMdd") & ".txt", True)
            file.WriteLine("[" & DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") & "] " & G_IPUser & " [" & process & "] : " & Log)
            file.Close()

        Catch ex As Exception
            If file IsNot Nothing Then
                file.Close()
            End If
        End Try
    End Function

    Public Function LTrim(ByVal pString As String) As String
        LTrim = ""
        Dim ByteCount As Integer = 0

        Try
            ByteCount = pString.Length
            For i As Integer = 0 To ByteCount - 1
                If pString.ToString.Substring(i, 1) <> " " Then
                    LTrim = pString.ToString.Substring(i, ByteCount - i)
                    Exit For
                End If
            Next
        Catch ex As Exception
            LTrim = ""
        End Try

    End Function

    Public Function ColumnSetLine(ByVal column As String)
        If column = "" Then
            Return column
        Else
            Return column.Replace("'", "''") & vbCrLf
        End If
    End Function

    Public Function RTrim(ByVal pString As String) As String
        RTrim = ""
        Dim ByteCount As Integer = 0

        Try
            ByteCount = pString.Length
            For i As Integer = ByteCount - 1 To 0 Step -1
                If pString.ToString.Substring(i, 1) <> " " Then
                    RTrim = pString.ToString.Substring(0, i + 1)
                    Exit For
                End If
            Next
        Catch ex As Exception
            RTrim = ""
        End Try

    End Function
    Public Function GetInvoiceTypeFromFile(ByVal FileName As String) As String
        Dim strSQL As String
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand
        strSQL = " SELECT TOP 1 * FROM M_CUSTOMCODESET "
        strSQL &= " WHERE CODEDIV = 'INVOICEIMPORT' "
        strSQL &= " AND '" & FileName & "' LIKE '%' + CONTENTSCODE + '%' "
        cmd = New SqlCommand(strSQL, dbConn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            GetInvoiceTypeFromFile = dr("REFERENCE")
        Else
            GetInvoiceTypeFromFile = "KCP"
        End If
        dr.Close()
        cmd.Dispose()
    End Function

    Public Function GetInvoiceType(ByVal InvoiceNo As String) As String
        Dim strSQL As String
        Dim dr As SqlDataReader
        Dim cmd As SqlCommand

        If IsNumeric(InvoiceNo.Substring(3, 1)) Then
            GetInvoiceType = InvoiceNo.Substring(0, 3)
        Else
            GetInvoiceType = InvoiceNo.Substring(0, 4)
        End If

        strSQL = "SELECT * FROM M_CUSTOMCODESET WHERE CODEDIV = 'INVOICEIMPORT' AND CONTENTSCODE = '" & GetInvoiceType & "'"
        cmd = New SqlCommand(strSQL, dbConn)
        dr = cmd.ExecuteReader
        If dr.HasRows Then
            dr.Read()
            GetInvoiceType = dr("REFERENCE")
        Else
            GetInvoiceType = "KCP"
        End If
        dr.Close()
        cmd.Dispose()

        'Select Case True
        '    Case GetInvoiceType.Substring(0.3) = "KCP"
        '        GetInvoiceType = "KCP"
        '    Case GetInvoiceType = "KVPA"
        '        GetInvoiceType = "KVPA"
        '    Case GetInvoiceType = "KVPO"
        '        GetInvoiceType = "KVPO"
        '    Case Else
        '        GetInvoiceType = "KCP"
        'End Select

    End Function



    Public Sub ExcelProcessKill()
        Dim excelProcess() As System.Diagnostics.Process = System.Diagnostics.Process.GetProcessesByName("EXCEL")
        Try
            If excelProcess.Length > 0 Then
                For i As Integer = 0 To excelProcess.Length - 1
                    If excelProcess(i).MainWindowTitle = "" Then
                        excelProcess(i).Kill()
                    End If
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

End Module
