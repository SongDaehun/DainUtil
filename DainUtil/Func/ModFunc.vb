Imports System.Xml

Public Module ModFunc
    Public Function XmlReadVal(ByVal filePath As String, ByVal nodePath As String) As String

        Dim xmlDoc As New XmlDocument
        Dim xmlNode As Xml.XmlNode  'ノードパスから値を取得

        Try
            xmlDoc.Load(filePath)  'xmlドキュメントのLoad
            xmlNode = xmlDoc.SelectSingleNode(nodePath)

            XmlReadVal = xmlNode.InnerText '項目値を取得

        Catch ex As Exception
            XmlReadVal = ""

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
End Module
