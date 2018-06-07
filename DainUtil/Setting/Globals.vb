Imports System.Data.SqlClient
Imports System.Net
Module Globals
    Public G_IPUser As String = ""

    Public G_APPNAME As String
    Public G_Version As String
    Public G_APPPath As String = Application.StartupPath()
    Public G_ExcelInPath As String = G_APPPath + "\Import\"
    Public G_TextoutPath As String = G_APPPath + "\Export\"
    Public G_ReportPath As String = G_APPPath + "\Report\"
    Public G_Image As String = G_APPPath + "\source\image\"
    Public R_Whare As String = ""
    'Public G_DBPath As String = G_APPPath + "\db\dain.accdb"

    Public Const gsXmlSetting As String = "SET.xml"                     '設定ﾌｧｲﾙ(得意先個別)

    Public Const gsXmlQuery As String = "QUERY.xml"
    Public iHostName As String = ""            'ｻｰﾊﾞ名
    Public iDataBaseName As String = ""        'DB名
    Public iUserID As String = ""              'ﾕｰｻﾞID
    Public iPassword As String = ""            'ﾊﾟｽﾜｰﾄﾞ
    Public iDriverName As String = ""          'ﾄﾞﾗｲﾊﾞ名
    Public QueryTimeout As String = ""         'ｸｴﾘｰﾀｲﾑｱｳﾄ

    Public dbConn As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public ConnectionString As String

    'Env start
    Public G_ReporterCode As String
    Public G_ReporterName As String
    Public G_DATAKEEPDAYS As Integer
    Public G_FILEOUTFLAG As Boolean
    'Env End

    Public D_CIPL_H As String = "D_CIPL_H"
    Public D_CIPL_D As String = "D_CIPL_D"
    Public W_CIPL_H As String = "W_CIPL_H"
    Public W_CIPL_D As String = "W_CIPL_D"
    Public M_ITEM As String = "M_ITEM"

    Public R_CIPL_LIST As Integer = 101
    Public R_ITEM As Integer = 901
    Public R_STNDARDMASTER As Integer = 900
    Public R_CUSTOMMASTER As Integer = 902

    Public ProccessExcelImport As FrmProcessExcelImport = New FrmProcessExcelImport


    Public Sub GetIPUser()
        G_IPUser = ""
        Dim hostname As String = Dns.GetHostName()
        Dim adrList As IPAddress() = Dns.GetHostAddresses(hostname)
        Try
            For Each address As IPAddress In adrList
                G_IPUser = address.ToString()
            Next
        Catch ex As Exception
            G_IPUser = ""
        End Try

    End Sub
    Public Function DbConnect() As Boolean

        Dim builder_sql As New System.Data.SqlClient.SqlConnectionStringBuilder
        DbConnect = False
        Try
            If System.IO.File.Exists(DirYenFix(Application.StartupPath) & gsXmlSetting) = False Then
                MsgBoxFail("설정파일이 없습니다." & System.IO.File.Exists(DirYenFix(Application.StartupPath) & gsXmlSetting) & " 이 존재하는지 확인해주세요.")
                Application.Exit()
            End If

            If System.IO.File.Exists(DirYenFix(Application.StartupPath) & gsXmlSetting) = False Then
                MsgBoxFail("설정파일이 없습니다." & System.IO.File.Exists(GetQueryFullPath) & " 이 존재하는지 확인해주세요.")
                Application.Exit()
            End If

            iHostName = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/HostName")      'HostName
            iDataBaseName = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/DataBaseName")   'DataBaseName
            iUserID = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/UserId")   'UserID
            iPassword = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/Password")   'Password
            iDriverName = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/DriverName")   'DriverName
            QueryTimeout = XmlReadVal((DirYenFix(Application.StartupPath) & gsXmlSetting), "root/DataBase/QueryTimeout")   'QueryTimeout

            builder_sql.DataSource = iHostName
            builder_sql.UserID = iUserID
            builder_sql.Password = iPassword
            builder_sql.InitialCatalog = iDataBaseName
            builder_sql.ConnectTimeout = QueryTimeout
            builder_sql.MultipleActiveResultSets = True

            dbConn = New System.Data.SqlClient.SqlConnection(builder_sql.ConnectionString)
            dbConn.Open()
        Catch ex As Exception
            MessageBox.Show("데이타베이스 연결에 실패했습니다." & ex.Message, "DbConnect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()
            Exit Function
        End Try
        DbConnect = True

    End Function
    Public Function GetEnv() As Boolean
        Dim strSQL As String
        'Dim cmd As OleDb.OleDbCommand
        'Dim dr As OleDb.OleDbDataReader
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try
            'Call Interval()

            Dim asmttl As System.Reflection.AssemblyTitleAttribute =
CType(Attribute.GetCustomAttribute(
    System.Reflection.Assembly.GetExecutingAssembly(),
    GetType(System.Reflection.AssemblyTitleAttribute)),
        System.Reflection.AssemblyTitleAttribute)
            G_APPNAME = asmttl.Title

            Dim asm As System.Reflection.Assembly =
    System.Reflection.Assembly.GetExecutingAssembly()
            G_Version = asm.GetName().Version.Major.ToString + "." + asm.GetName().Version.Minor.ToString

            If System.IO.Directory.Exists(G_ExcelInPath) <> True Then
                System.IO.Directory.CreateDirectory(G_ExcelInPath)
            End If

            If System.IO.Directory.Exists(G_TextoutPath) <> True Then
                System.IO.Directory.CreateDirectory(G_TextoutPath)
            End If


            strSQL = "SELECT TOP 1 * FROM F_GENENV"
            'cmd = New OleDb.OleDbCommand(strSQL, dbConn)
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                G_DATAKEEPDAYS = dr("DATAKEEPDAYS")
                G_FILEOUTFLAG = dr("FILEOUTFLAG")
                G_ReporterCode = dr("ReportCode")
                G_ReporterName = dr("ReportName")
            End While
            dr.Close()
            cmd.Dispose()

            If System.IO.Directory.Exists(G_ExcelInPath) = False Then
                System.IO.Directory.CreateDirectory(G_ExcelInPath)
            End If

            If System.IO.Directory.Exists(G_TextoutPath) = False Then
                System.IO.Directory.CreateDirectory(G_TextoutPath)
            End If
            GetEnv = True
        Catch ex As Exception
            MsgBoxFail(ex.Message)
            GetEnv = False
        Finally
            dr.Close()
            cmd.Dispose()
        End Try
    End Function

    Public Function GetQueryFullPath()
        If Debugger.IsAttached Then
            Return DirYenFix(G_APPPath) & "../../initial/" & gsXmlQuery
        Else
            Return DirYenFix(G_APPPath) & gsXmlQuery
        End If
    End Function

End Module
