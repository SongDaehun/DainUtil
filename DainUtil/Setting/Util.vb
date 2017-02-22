Imports System.Data.SqlClient
Imports System.IO
Module Util
    Function MsgBoxOK(ByVal message As String)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Information
        )
    End Function

    Function MsgBoxFail(ByVal message As String)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Error
        )
    End Function

    Function MsgBoxExclamation(ByVal message As String)
        MessageBox.Show(message,
        G_APPNAME,
        MessageBoxButtons.OK,
        MessageBoxIcon.Exclamation
        )
    End Function

    Function MsgBoxInformation(ByVal message As String)
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

End Module
