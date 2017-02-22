Imports System.Data.SqlClient
Module Globals

    Public G_APPNAME As String
    Public G_Version As String
    Public G_APPPath As String = Application.StartupPath()
    Public G_ExcelInPath As String = G_APPPath + "\Import\"
    Public G_TextoutPath As String = G_APPPath + "\Export\"
    Public G_DBPath As String = G_APPPath + "\db\dain.accdb"

    Public Const gsXmlSetting As String = "SET.xml"                     '設定ﾌｧｲﾙ(得意先個別)
    Public iHostName As String = ""            'ｻｰﾊﾞ名
    Public iDataBaseName As String = ""        'DB名
    Public iUserID As String = ""              'ﾕｰｻﾞID
    Public iPassword As String = ""            'ﾊﾟｽﾜｰﾄﾞ
    Public iDriverName As String = ""          'ﾄﾞﾗｲﾊﾞ名
    Public QueryTimeout As String = ""         'ｸｴﾘｰﾀｲﾑｱｳﾄ

    Public connMDB As OleDb.OleDbConnection = New OleDb.OleDbConnection
    Public ConnectionStringMDB As String

    Public dbConn As SqlClient.SqlConnection = New SqlClient.SqlConnection
    Public ConnectionString As String

    'Env start
    Public G_ReporterCode As String
    Public G_ReporterName As String
    'Env End

    Public Const P_ITEM As Integer = 901
    Public Const P_CIPLList As Integer = 101

    Public Sub initial()

        'ConnectionStringMDB = "Provider=Microsoft.ACE.OLEDB.12.0;" &
        '                  "Data Source=" & G_DBPath & ";"

        DbConnect()

        Call Interval()

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

    End Sub
    Public Function DbConnect() As Boolean
        Dim builder_sql As New System.Data.SqlClient.SqlConnectionStringBuilder
        DbConnect = False
        Try
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
            MessageBox.Show(ex.Message, "DbConnect", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()
            Exit Function
        End Try
        DbConnect = True

    End Function
    Public Sub GetEnv()
        Dim strSQL As String
        'Dim cmd As OleDb.OleDbCommand
        'Dim dr As OleDb.OleDbDataReader
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader

        Try

            strSQL = "SELECT TOP 1 * FROM F_GENENV"
            'cmd = New OleDb.OleDbCommand(strSQL, dbConn)
            cmd = New SqlCommand(strSQL, dbConn)
            dr = cmd.ExecuteReader
            While dr.Read
                G_ReporterCode = dr("ReportCode")
                G_ReporterName = dr("ReportName")
            End While
            dr.Close()
            cmd.Dispose()

        Catch ex As Exception
            MsgBoxFail(ex.Message)
        Finally
            dr.Close()
            cmd.Dispose()
        End Try
    End Sub
    'Public Function Interval() As Boolean
    '    Dim strSQL As String = ""
    '    Dim cmd As SqlCommand
    '    Dim dr As SqlDataReader
    '    Dim vmenteStep As Integer
    '    Dim Count As Integer = 0
    '    Try
    '        strSQL = "SELECT * FROM dbo.sysobjects WHERE NAME = 'F_GENENV'"
    '        cmd = New SqlCommand(strSQL, dbConn)
    '        dr = cmd.ExecuteReader
    '        While dr.Read()
    '            Count = Count + 1
    '        End While
    '        dr.Close()
    '        cmd.Dispose()

    '        If Count = 0 Then
    '            vmenteStep = 0
    '        Else
    '            strSQL = " SELECT * FROM F_GENENV "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            dr = cmd.ExecuteReader
    '            While dr.Read()
    '                vmenteStep = dr("MenteStep")
    '            End While
    '            dr.Close()
    '            cmd.Dispose()
    '        End If



    '        If vmenteStep < 1 Then
    '            strSQL = "CREATE TABLE F_GENENV ( "
    '            strSQL &= "MenteStep  int "
    '            strSQL &= ",ReportCode nvarchar(100)"
    '            strSQL &= ",ReportName NVARCHAR(255)"
    '            strSQL &= ")"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "INSERT INTO F_GENENV VALUES('1', '22130','다인안양합동관세사무소')"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 2 Then
    '            strSQL = " CREATE TABLE D_PACKING_LIST_H ( "
    '            strSQL &= " SEQNO INT Not NULL"
    '            strSQL &= " ,INVOICENO NVARCHAR(20) Not NULL"
    '            strSQL &= " ,PACKINGLISTNO NVARCHAR(20) Not NULL"
    '            strSQL &= " ,INVOICEDATE NVARCHAR(8) "

    '            strSQL &= " ,SHIPPEREXPORTER NVARCHAR(100) "
    '            strSQL &= " ,SHIPPEREXPORTERADDRESS NVARCHAR(255) "

    '            strSQL &= " ,CONSIGNEE NVARCHAR(100) "
    '            strSQL &= " ,CONSIGNEEADDRESS NVARCHAR(255) "

    '            strSQL &= " ,PAYMENTTERMS NVARCHAR(100) "
    '            strSQL &= " ,DELIVERYTERMS NVARCHAR(10) "
    '            strSQL &= " ,SHIPPINGMETHOD NVARCHAR(10) "
    '            strSQL &= " ,SHIPPINGPORT NVARCHAR(255) "
    '            strSQL &= " ,DESTINATIONPORT NVARCHAR(255) "
    '            strSQL &= " ,CONTACTPERSON NVARCHAR(255) "
    '            strSQL &= " ,CONTACTPERSONEMAIL NVARCHAR(255) "
    '            strSQL &= " ,ETD NVARCHAR(8) "
    '            strSQL &= " ,ETA NVARCHAR(8) "
    '            strSQL &= " ,PRIMARY KEY(SEQNO, INVOICENO) "
    '            strSQL &= " ) "

    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = " CREATE TABLE D_PACKING_LIST_D("
    '            strSQL &= " SEQNO Int Not NULL"
    '            strSQL &= " ,PARTNO NVARCHAR(20) Not NULL"
    '            strSQL &= " ,PARTNAME NVARCHAR(100)"
    '            strSQL &= " ,RANNUMBER NVARCHAR(3)"
    '            strSQL &= " ,SUPPLIERCODE NVARCHAR(10)"
    '            strSQL &= " ,PUN NVARCHAR(5)"
    '            strSQL &= " ,CBM NVARCHAR(10)"
    '            strSQL &= " ,TOTALQTY Decimal(14,0)"
    '            strSQL &= " ,NWEIGHT_KGS Decimal(14,2)"
    '            strSQL &= " ,GWEIGHT_KGS Decimal(14,2)"
    '            strSQL &= " ,PRIMARY KEY(SEQNO, PACKINGLIST)"
    '            strSQL &= " )"

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '2'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 3 Then
    '            strSQL = " CREATE TABLE D_INVOICE_H( "
    '            strSQL &= " SEQNO BIGINT NOT NULL"
    '            strSQL &= " ,INVOICENO NVARCHAR(20)"
    '            strSQL &= " ,PACKINGLISTNO NVARCHAR(20)"
    '            strSQL &= " ,INVOICEDATE NVARCHAR(8)"
    '            strSQL &= " ,SHIPPEREXPORTER NVARCHAR(100)"
    '            strSQL &= " ,SHIPPEREXPORTERADDRESS NVARCHAR(255)"
    '            strSQL &= " ,CONSIGNEE NVARCHAR(100)"
    '            strSQL &= " ,CONSIGNEEADDRESS NVARCHAR(255)"
    '            strSQL &= " ,TERMSOFDELIVERY NVARCHAR(10)"
    '            strSQL &= " ,SHIPPINGMODE NVARCHAR(30)"
    '            strSQL &= " ,PAYMENT NVARCHAR(255)"
    '            strSQL &= " ,PAYMENTBANK NVARCHAR(255)"
    '            strSQL &= " ,ACCOUNTNO NVARCHAR(50)"
    '            strSQL &= " ,PURCHASEORDER NVARCHAR(30)"
    '            strSQL &= " ,LOADINGPORT NVARCHAR(100)"
    '            strSQL &= " ,DESTINATION NVARCHAR(100)"
    '            strSQL &= " ,NOTIFY NVARCHAR(255)"
    '            strSQL &= " ,PRIMARY KEY(SEQNO, INVOICENO) "
    '            strSQL &= " )"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = " CREATE TABLE D_INVOICE_D( "
    '            strSQL &= " SEQNO BIGINT  Not NULL "
    '            strSQL &= " ,DETAILSEQNO INT NOT NULL"
    '            strSQL &= " ,DECLARERATIONNUMBER NVARCHAR(4) "
    '            strSQL &= " ,RANNUMBER NVARCHAR(3) "
    '            strSQL &= " ,PARTNO NVARCHAR(20) Not NULL"
    '            strSQL &= " ,PARTNAME NVARCHAR(100) "
    '            strSQL &= " ,REV NVARCHAR(10) "
    '            strSQL &= " ,PUN NVARCHAR(5) "
    '            strSQL &= " ,MPQ NVARCHAR(10) "
    '            strSQL &= " ,TOTALQTY Decimal(14,0) "
    '            strSQL &= " ,TOTALKGS Decimal(14,1) "
    '            strSQL &= " ,UPRICE_USD Decimal(14,2) "
    '            strSQL &= " ,AMOUNT_USD Decimal(14,2) "
    '            strSQL &= " ,PRIMARY KEY(SEQNO, DETAILSEQNO) "
    '            strSQL &= " ) "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '4'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 5 Then
    '            strSQL = " CREATE TABLE M_ITEM( "
    '            strSQL &= " PARTNO NVARCHAR(20) Not NULL"
    '            strSQL &= " ,PARTNAME NVARCHAR(100) "
    '            strSQL &= " ,HSCODE NVARCHAR(20) "
    '            strSQL &= " ,PRODUCT  NVARCHAR(255) "
    '            strSQL &= " ,CONVENTIONCODE NVARCHAR(4) "
    '            strSQL &= " ,STANDARDPARTNAME NVARCHAR(100) "
    '            strSQL &= " ,TRADEPARTNAME NVARCHAR(100) "
    '            strSQL &= " ,PRIMARY KEY (PARTNO) "
    '            strSQL &= " ) "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = " CREATE TABLE M_STANDARDCODESET "
    '            strSQL &= " ( "
    '            strSQL &= " STANDARDCODE                          NVARCHAR(30)             Not NULL, "
    '            strSQL &= " CONTENTSCODE                                NVARCHAR(14)    Not NULL, "
    '            strSQL &= " CONTENTSNAME                                NVARCHAR(40)    Not NULL, "
    '            strSQL &= " CONVERTCODE                                 NVARCHAR(255), "
    '            strSQL &= " CREATEUSERID                            	NVARCHAR(10), "
    '            strSQL &= " CREATEDATEANDTIME                           NVARCHAR(14), "
    '            strSQL &= " UPDATEUSERID                            	NVARCHAR(10), "
    '            strSQL &= " UPDATEDATEANDTIME                           NVARCHAR(14), "
    '            strSQL &= " PRIMARY KEY (STANDARDCODE, CONTENTSCODE) "
    '            strSQL &= " ) "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '5'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 6 Then
    '            strSQL = " CREATE TABLE M_STANDARDCODENAME "
    '            strSQL &= " ( "
    '            strSQL &= " STANDARDCODE                          NVARCHAR(30)             Not NULL, "
    '            strSQL &= " STANDARDNAME                          NVARCHAR(40)             Not NULL, "
    '            strSQL &= " PRIMARY KEY (STANDARDCODE, STANDARDNAME) "
    '            strSQL &= " ) "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '6'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 7 Then
    '            strSQL = " CREATE TABLE F_LISTOUTITEM "
    '            strSQL &= " ( "
    '            strSQL &= " MESSAGEID INT NOT NULL "
    '            strSQL &= " ,PRECESSINGCLASS NVARCHAR(1) "
    '            strSQL &= " ,COLUMNNAME NVARCHAR(30) "
    '            strSQL &= " ,INDICATIONNAME NVARCHAR(30) "
    '            strSQL &= " ,INDICATIONWITH INT "
    '            strSQL &= " ,INDICATIONWIDEPOSITION INT"
    '            strSQL &= " ,INDICATIONORDER INT "
    '            strSQL &= " ,VISIBLE INT "
    '            strSQL &= " ,PRIMARY KEY (MESSAGEID,PRECESSINGCLASS,INDICATIONORDER) "
    '            strSQL &= " ) "
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "INSERT INTO F_LISTOUTITEM VALUES('1','H','SEQNO','SEQNO','100','0','0','0') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','INVOICENO','INVOICENO','100','0','1','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','PACKINGLISTNO','PACKINGLISTNO','100','0','2','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','INVOICEDATE','INVOICEDATE','100','0','3','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','SHIPPEREXPORTER','SHIPPEREXPORTER','100','0','4','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','SHIPPEREXPORTERADDRESS','SHIPPEREXPORTERADDRESS','100','0','5','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','CONSIGNEE','CONSIGNEE','100','0','6','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','CONSIGNEEADDRESS','CONSIGNEEADDRESS','100','0','7','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','TERMSOFDELIVERY','TERMSOFDELIVERY','100','0','8','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','SHIPPINGMODE','SHIPPINGMODE','100','0','9','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','PAYMENT','PAYMENT','100','0','10','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','PAYMENTBANK','PAYMENTBANK','100','0','11','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','ACCOUNTNO','ACCOUNTNO','100','0','12','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','PURCHASEORDER','PURCHASEORDER','100','0','13','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','LOADINGPORT','LOADINGPORT','100','0','14','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','DESTINATION','DESTINATION','100','0','15','1') "
    '            strSQL &= "INSERT INTO F_LISTOUTITEM VALUES('1','H','NOTIFY','NOTIFY','100','0','16','1') "

    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '7'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If

    '        If vmenteStep < 8 Then
    '            strSQL = "SELECT * INTO F_LISTOUTITEM_INI FROM F_LISTOUTITEM"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()

    '            strSQL = "UPDATE F_GENENV Set MENTESTEP = '8'"
    '            cmd = New SqlCommand(strSQL, dbConn)
    '            cmd.ExecuteNonQuery()
    '            cmd.Dispose()
    '        End If
    '    Catch ex As Exception
    '        MsgBoxFail(ex.Message)
    '        Application.Exit()
    '    End Try


    'End Function
End Module
