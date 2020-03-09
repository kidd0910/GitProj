Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Acer.Form
Imports System.Data.Common
Imports System.Reflection.MethodBase
Imports System.Collections
Imports System.Data.OleDb
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Checksums
Imports WebChart
Imports System.Drawing
Imports Comm.Business
Imports Acer.Apps
Imports System.Net
Imports WinSCP




Namespace Comm.Common

    Public Class Common
        ''' <summary>
        ''' Excel �� Datatable
        ''' </summary>
        ''' <param name="filePath">�ɮ׸��|</param>
        ''' <param name="sheetName">Sheet �W��</param>
        ''' <returns>�^�ǵ��G(Datatable)</returns>
        Public Shared Function ExcelToDt(ByVal filePath As String, Optional ByVal sheetName As String = "Sheet1") As DataTable
            Dim myDataset As New DataSet
            Dim strConn As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
            "Data Source=" & filePath & ";" & _
            "Extended Properties='Excel 8.0;IMEX=1;'"

            Dim myData As New OleDbDataAdapter("SELECT * FROM [" & sheetName & "$]", strConn)
            myData.TableMappings.Add("Table", "ExcelTest")
            myData.Fill(myDataset)

            ExcelToDt = myDataset.Tables(0)
        End Function
        'Public Shared Sub ZipOneFilesbyArr(ByVal strFile As ArrayList, ByVal strFileName As ArrayList, ByVal strOutputFile As String)
        '    Dim crc As New Crc32()
        '    Using zs As ZipOutputStream = New ZipOutputStream(System.IO.File.Create(strOutputFile))

        '        'make sure level in range 
        '        Dim _zipLevel As Integer
        '        _zipLevel = System.Math.Max(0, _zipLevel)
        '        _zipLevel = System.Math.Min(9, _zipLevel)
        '        zs.SetLevel(_zipLevel)

        '        Dim buffer(32768) As Byte
        '        For iCount As Int32 = 0 To strFile.Count - 1
        '            Dim File As System.IO.FileInfo = New FileInfo(strFile(iCount))
        '            If (File.Exists) Then
        '                Dim name As String = ZipEntry.CleanName(strFileName(iCount).ToString())

        '                Dim entry As ZipEntry = New ZipEntry(name)
        '                entry.DateTime = File.LastWriteTime
        '                entry.Size = File.Length

        '                Using fs As System.IO.FileStream = File.OpenRead()
        '                    crc.Reset()
        '                    Dim len1 As Long = fs.Length
        '                    While len1 > 0
        '                        Dim readSoFar As Integer = fs.Read(buffer, 0, buffer.Length)
        '                        crc.Update(buffer, 0, readSoFar)
        '                        len1 -= readSoFar
        '                    End While
        '                    entry.Crc = crc.Value
        '                    zs.PutNextEntry(entry)

        '                    len1 = fs.Length
        '                    fs.Seek(0, SeekOrigin.Begin)
        '                    While len1 > 0
        '                        Dim readSoFar As Integer = fs.Read(buffer, 0, buffer.Length)
        '                        zs.Write(buffer, 0, readSoFar)
        '                        len1 -= readSoFar
        '                    End While
        '                End Using

        '            End If
        '        Next
        '        zs.Finish()
        '        zs.Close()
        '    End Using


        'End Sub
        'Public Shared Sub ZipOneFilesbyArr1(ByVal strFile As ArrayList, ByVal strFileName As ArrayList, ByVal strOutputFile As String)
        '    Dim zip As ZipOutputStream = New ZipOutputStream(System.IO.File.Create(strOutputFile))
        '    '=== �]�w���Y���� ===
        '    Dim _zipLevel As Integer
        '    _zipLevel = System.Math.Max(0, _zipLevel)
        '    _zipLevel = System.Math.Min(9, _zipLevel)
        '    zip.SetLevel(_zipLevel) ' 0 - store only to 9 - means best compression

        '    For iCount As Int32 = 0 To strFile.Count - 1
        '        Dim entry As ZipEntry = New ZipEntry(strFileName(iCount).ToString())
        '        entry.DateTime = DateTime.Now
        '        zip.PutNextEntry(entry)
        '        Dim fs As FileStream = System.IO.File.OpenRead(strFile(iCount))
        '        Dim sourceBytes As Integer = 1
        '        Dim bBuffer(fs.Length) As Byte
        '        sourceBytes = fs.Read(bBuffer, 0, bBuffer.Length)
        '        fs.Close()

        '        zip.Write(bBuffer, 0, sourceBytes)
        '    Next
        '    zip.Finish()
        '    zip.Close()
        'End Sub

        'Public Shared chartNameIndex As Integer = 0

        'Public Shared Function DrawPieChart(ByVal dataMap As Hashtable) As String
        '    Dim wcEng As ChartEngine = New ChartEngine()
        '    wcEng.Size = New Drawing.Size(400, 300)
        '    wcEng.GridLines = GridLines.None
        '    wcEng.HasChartLegend = True

        '    Dim wcCharts As ChartCollection = New ChartCollection(wcEng)
        '    wcEng.Charts = wcCharts

        '    Dim chart As PieChart = New PieChart()
        '    chart.Explosion = 2
        '    chart.DataLabels.Visible = True

        '    For Each key As String In dataMap.Keys
        '        chart.Data.Add(New ChartPoint(key, dataMap(key)))
        '    Next
        '    wcCharts.Add(chart)

        '    Dim bmp As Drawing.Bitmap
        '    Dim memStream As System.IO.MemoryStream = New System.IO.MemoryStream()
        '    bmp = wcEng.GetBitmap()

        '    chartNameIndex += 1

        '    Dim fileName As String = Acer.Apps.APConfig.RealPath & "\Temp\" + DateUtil.GetCurrTimeMillis.ToString() & "_" & chartNameIndex.ToString() + ".jpg"
        '    bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        '    bmp.Dispose()

        '    Return fileName
        'End Function

        'Public Shared Function DrawColumnChart(ByVal data As DataTable, ByVal xColumn As String, ByVal yColumn As String, Optional ByVal yEnd As Integer = -1, Optional ByVal yInterval As Integer = -1) As String
        '    Dim wcEng As ChartEngine = New ChartEngine()
        '    wcEng.Size = New Drawing.Size(450, 250)
        '    wcEng.ShowXValues = True
        '    wcEng.ShowYValues = True
        '    wcEng.GridLines = GridLines.None
        '    wcEng.Padding = 10
        '    wcEng.ChartPadding = 20
        '    wcEng.BottomChartPadding = 10
        '    wcEng.TopPadding = 10
        '    If yEnd <> -1 Then
        '        wcEng.YCustomEnd = yEnd
        '    End If
        '    If yInterval <> -1 Then
        '        wcEng.YValuesInterval = yInterval
        '    End If

        '    Dim wcCharts As ChartCollection = New ChartCollection(wcEng)
        '    wcEng.Charts = wcCharts

        '    Dim chart As ColumnChart = New WebChart.ColumnChart()
        '    chart.MaxColumnWidth = 30
        '    chart.Fill.Color = Color.FromArgb(100, Color.Red)
        '    chart.DataLabels.Visible = True
        '    chart.DataXValueField = xColumn
        '    chart.DataYValueField = yColumn
        '    chart.DataLabels.Visible = True
        '    chart.DataSource = data.DefaultView
        '    chart.DataBind()

        '    wcCharts.Add(chart)

        '    Dim bmp As Drawing.Bitmap
        '    Dim memStream As System.IO.MemoryStream = New System.IO.MemoryStream()
        '    bmp = wcEng.GetBitmap()

        '    chartNameIndex += 1

        '    Dim fileName As String = Acer.Apps.APConfig.RealPath & "\Temp\" + DateUtil.GetCurrTimeMillis.ToString() & "_" & chartNameIndex.ToString() + ".jpg"
        '    bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        '    bmp.Dispose()

        '    Return fileName
        'End Function

        Public Shared Function CheckIDCard_CHT(ByVal IDCard As String) As Boolean
            Dim strFirstCode As String = ""  'BRAIN ���Ѯw ����
            If IDCard.Length <> 10 Then
                '?�ץ���?10 
                Return False
            End If
            If IDCard.Substring(1, 1) <> "1" AndAlso IDCard.Substring(1, 1) <> "2" Then
                '�ĤG�쥲�ݬO1=�k�Ϊ�2=�k 
                Return False
            End If
            Select Case IDCard.Substring(0, 1)
                Case "A"
                    strFirstCode = "10"
                    Exit Select
                Case "B"
                    strFirstCode = "11"
                    Exit Select
                Case "C"
                    strFirstCode = "12"
                    Exit Select
                Case "D"
                    strFirstCode = "13"
                    Exit Select
                Case "E"
                    strFirstCode = "14"
                    Exit Select
                Case "F"
                    strFirstCode = "15"
                    Exit Select
                Case "G"
                    strFirstCode = "16"
                    Exit Select
                Case "H"
                    strFirstCode = "17"
                    Exit Select
                Case "I"
                    strFirstCode = "34"
                    Exit Select
                Case "J"
                    strFirstCode = "18"
                    Exit Select
                Case "K"
                    strFirstCode = "19"
                    Exit Select
                Case "L"
                    strFirstCode = "20"
                    Exit Select
                Case "M"
                    strFirstCode = "21"
                    Exit Select
                Case "N"
                    strFirstCode = "22"
                    Exit Select
                Case "O"
                    strFirstCode = "35"
                    Exit Select
                Case "P"
                    strFirstCode = "23"
                    Exit Select
                Case "Q"
                    strFirstCode = "24"
                    Exit Select
                Case "R"
                    strFirstCode = "25"
                    Exit Select
                Case "S"
                    strFirstCode = "26"
                    Exit Select
                Case "T"
                    strFirstCode = "27"
                    Exit Select
                Case "U"
                    strFirstCode = "28"
                    Exit Select
                Case "V"
                    strFirstCode = "29"
                    Exit Select
                Case "W"
                    strFirstCode = "32"
                    Exit Select
                Case "X"
                    strFirstCode = "30"
                    Exit Select
                Case "Y"
                    strFirstCode = "31"
                    Exit Select
                Case "Z"
                    strFirstCode = "33"
                    Exit Select
                Case Else
                    Return False
            End Select
            Dim iAllNum As Integer = 0
            iAllNum += Convert.ToInt32(strFirstCode.Substring(0, 1))
            iAllNum += Convert.ToInt32(strFirstCode.Substring(1, 1)) * 9
            iAllNum += Convert.ToInt32(IDCard.Substring(1, 1)) * 8
            iAllNum += Convert.ToInt32(IDCard.Substring(2, 1)) * 7
            iAllNum += Convert.ToInt32(IDCard.Substring(3, 1)) * 6
            iAllNum += Convert.ToInt32(IDCard.Substring(4, 1)) * 5
            iAllNum += Convert.ToInt32(IDCard.Substring(5, 1)) * 4
            iAllNum += Convert.ToInt32(IDCard.Substring(6, 1)) * 3
            iAllNum += Convert.ToInt32(IDCard.Substring(7, 1)) * 2
            iAllNum += Convert.ToInt32(IDCard.Substring(8, 1)) * 1
            iAllNum += Convert.ToInt32(IDCard.Substring(9, 1)) * 1

            If iAllNum Mod 10 <> 0 Then
                Return False
            End If
            Return True
        End Function

        ''' <summary>
        ''' ��R��J�r��A�N URL �������令 HTML ���W�s���C 
        ''' </summary>
        ''' <param name="s">��J�r��</param>
        ''' <param name="openInNewWindow">�W�s���O�_�n�}�ҩ�s����</param>
        ''' <remarks></remarks>
        Public Shared Function ParseAndEmbedHyperlink(ByVal s As String, ByVal openInNewWindow As Boolean) As String
            Dim sb As New StringBuilder

            Dim pattern As String = "(http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"
            Dim regexp As RegularExpressions.Regex = New RegularExpressions.Regex(pattern)
            Dim matches As RegularExpressions.MatchCollection = RegularExpressions.Regex.Matches(s, pattern)
            Dim from As Integer = 0
            Dim i As Integer
            Dim url As String
            Dim redundant As String  ' Regular expression �~�P�� URL �᭱�s��������r�C 

            Dim item As RegularExpressions.Match

            For Each item In matches
                ' ��X Regular expression ��R�X�Ӫ� URL �᭱�����D ASCII �r�� 
                i = item.Length - 1
                While i >= 0
                    If IsAsciiLetter(item.Value(i)) Then
                        Exit While
                    End If
                    i = i - 1
                End While
                url = item.Value.Substring(0, i + 1)
                redundant = item.Value.Substring(i + 1)

                sb.Append(s.Substring(from, item.Index - from))
                sb.Append("<a href='")
                sb.Append(url & "'")
                If openInNewWindow Then
                    sb.Append(" target='_blank' ")
                End If
                sb.Append(">")
                sb.Append(url)
                sb.Append("</a>")
                sb.Append(redundant)
                from = item.Index + item.Length

            Next

            sb.Append(s.Substring(from))

            Return sb.ToString()
        End Function

        ''' <summary>
        ''' �ˬd�ǤJ���r���O�_�� ASCII ���^��r���C 
        ''' �ѩ� Char.IsLetter ��k�|�⤤��r�]�����r���A�]�����ǻݭn 
        ''' �P�_ ASCII �^��r�������X�A�N�i�H�Φ���k�C 
        ''' </summary>
        ''' <param name="ch"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function IsAsciiLetter(ByVal ch As Char) As Boolean
            Dim value As Integer = Convert.ToInt32(ch)
            If value >= 41 And value <= 90 Then
                Return True
            End If
            If value >= 97 And value <= 122 Then
                Return True
            End If
            Return False
        End Function
#Region "DataTable Distinct"
        ''' <summary>
        ''' DataTable Distinct
        ''' </summary>
        ''' <param name="SourceTable"></param>
        ''' <param name="FieldNames"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
            Dim lastValues() As Object
            Dim newTable As DataTable

            If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
                Throw New ArgumentNullException("FieldNames")
            End If

            lastValues = New Object(FieldNames.Length - 1) {}
            newTable = New DataTable

            For Each field As String In FieldNames
                newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
            Next

            For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
                If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
                    newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

                    setLastValues(lastValues, Row, FieldNames)
                End If
            Next

            Return newTable
        End Function

        Private Shared Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
            Dim areEqual As Boolean = True

            For i As Integer = 0 To fieldNames.Length - 1
                If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
                    areEqual = False
                    Exit For
                End If
            Next

            Return areEqual
        End Function

        Private Shared Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
            For Each field As String In fieldNames
                newRow(field) = sourceRow(field)
            Next

            Return newRow
        End Function

        Private Shared Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
            For i As Integer = 0 To fieldNames.Length - 1
                lastValues(i) = sourceRow(fieldNames(i))
            Next
        End Sub
#End Region

#Region "GetFilterCondition ���o��ƿz�ﵲ�G"
        ''' <summary>
        ''' ���o��ƿz�ﵲ�G
        ''' </summary>
        ''' <param name="filterColumnName">��ƿz�����</param>
        ''' <param name="columnAliasName">�O�W</param>
        ''' <returns>���� Exp: " AND xx='xx' "</returns>
        Public Shared Function GetFilterCondition(ByVal filterColumnName As String, ByVal columnAliasName As String) As String
            Dim condition As String = ""
            If Not SessionClass.����v�� Is Nothing Then
                Dim dtX As DataTable = CType(SessionClass.����v��, DataTable)
                Dim dw As DataRow() = dtX.Select("DATA_FIELD_ENG = '" & filterColumnName & "'")

                If dw.Length > 0 Then
                    If dw(0)("SQL_VALUE").ToString() <> "" Then
                        condition = " AND " & columnAliasName & "." & filterColumnName & " IN (" & dw(0)("SQL_VALUE").ToString() & ") "
                    Else
                        Select Case dw(0)("DATA_RANGE_LABEL").ToString().ToUpper()
                            Case "IN"
                                Dim tmp As StringBuilder = New StringBuilder()
                                Dim ary As String() = dw(0)("DATA_RANGE_VALUE").ToString().Split(",")
                                For i As Integer = 0 To ary.Length - 1
                                    tmp.Append(",'" & ary(i) & "'")
                                Next
                                tmp.Remove(0, 1)
                                condition = " AND " & columnAliasName & "." & filterColumnName & " IN (" & tmp.ToString() & ") "
                            Case Else
                                condition = " AND " & columnAliasName & "." & filterColumnName & " " & dw(0)("DATA_RANGE_LABEL").ToString() & " '" & dw(0)("DATA_RANGE_VALUE").ToString() & "' "
                        End Select

                    End If
                End If
            End If

            Return condition
        End Function
#End Region

#Region "���o�P���X"
        Public Shared Function GetWeek(day As String) As String
            Select Case Convert.ToByte(Convert.ToDateTime(day).DayOfWeek).ToString
                Case "0"
                    Return "��"
                Case "1"
                    Return "�@"
                Case "2"
                    Return "�G"
                Case "3"
                    Return "�T"
                Case "4"
                    Return "�|"
                Case "5"
                    Return "��"
                Case "6"
                    Return "��"
                Case Else
                    Return ""
            End Select

        End Function
#End Region

#Region "FTP �����B�z"
#Region "FTP �U��"
        ''' <summary>
        ''' FTP �U��
        ''' </summary>
        ''' <param name="downloadFile">�U���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub FtpDownload(ByVal downloadFile As String, ByVal savePath As String)
            Dim ftpAddress As String = APConfig.GetProperty("FTP_ADDRESS")
            Dim ftpID As String = APConfig.GetProperty("FTP_ID")
            Dim ftpPWD As String = APConfig.GetProperty("FTP_PWD")
            '���]�w FTP(�}�o���ҩάO��������)�ɤ��B�z
            If ftpAddress = "" Then
                Return
            End If

            If downloadFile.StartsWith("//") Then
                downloadFile.Remove(0, 1)
            End If

            If savePath.StartsWith("//") Then
                savePath.Remove(0, 1)
            End If

            Dim ftpRequest As FtpWebRequest = FtpWebRequest.Create("ftp://" & ftpAddress & ":21" & downloadFile)
            ftpRequest.Credentials = New NetworkCredential(ftpID, ftpPWD)
            ftpRequest.KeepAlive = False
            ftpRequest.UseBinary = True
            ftpRequest.UsePassive = True
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile

            '���oFTP���A�����^��
            Dim ftpResponse As FtpWebResponse = ftpRequest.GetResponse()

            '���o�ʸ�FTP���A���^����ƪ���Ƭy
            Dim ftpStream As Stream = ftpResponse.GetResponseStream()

            'Ū����Ƭy
            Dim contentLen As Long = ftpResponse.ContentLength
            Dim bufferSize As Integer = 2048
            Dim readCount As Integer

            Dim outputStream As FileStream = New FileStream(savePath, FileMode.Create)
            Dim buff(bufferSize) As Byte

            readCount = ftpStream.Read(buff, 0, bufferSize)
            While (readCount > 0)
                outputStream.Write(buff, 0, readCount)
                readCount = ftpStream.Read(buff, 0, bufferSize)
            End While
            outputStream.Close()
            ftpStream.Close()
            ftpResponse.Close()
        End Sub
#End Region

#Region "FTP �W��"
        ''' <summary>
        ''' FTP �W��
        ''' </summary>
        ''' <param name="uploadFile">�W���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub FtpUpload(ByVal uploadFile As String, ByVal savePath As String)
            Dim ftpAddress As String = APConfig.GetProperty("FTP_ADDRESS")
            Dim ftpID As String = APConfig.GetProperty("FTP_ID")
            Dim ftpPWD As String = APConfig.GetProperty("FTP_PWD")
            '���]�w FTP(�}�o���ҩάO��������)�ɤ��B�z
            If ftpAddress = "" Then
                Return
            End If

            If savePath.StartsWith("//") Then
                savePath.Remove(0, 1)
            End If

            Dim uldFileInfo As FileInfo = New FileInfo(uploadFile)
            Dim ftpRequest As FtpWebRequest = FtpWebRequest.Create("ftp://" & ftpAddress & ":21" & savePath)
            ftpRequest.Credentials = New NetworkCredential(ftpID, ftpPWD)
            ftpRequest.KeepAlive = False
            ftpRequest.UseBinary = True
            ftpRequest.UsePassive = True
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile
            ftpRequest.ContentLength = uldFileInfo.Length

            Dim buffLength As Integer = 2048
            Dim buff(buffLength) As Byte
            Dim contentLen As Integer

            Dim fileStream As FileStream = uldFileInfo.OpenRead()
            Dim strm As Stream = ftpRequest.GetRequestStream()

            contentLen = fileStream.Read(buff, 0, buffLength)
            While (contentLen <> 0)
                strm.Write(buff, 0, contentLen)
                contentLen = fileStream.Read(buff, 0, buffLength)
            End While
            strm.Close()
            fileStream.Close()
        End Sub
#End Region

#Region "�إߥؿ�"
        ''' <summary>
        ''' �إߥؿ�
        ''' </summary>
        ''' <param name="folder">�ؿ��W��</param>
        ''' <remarks></remarks>
        Public Shared Sub CreateFolder(ByVal folder As String)
            Try
                Dim folderAry As String() = folder.Split("/")
                Dim currFolder As StringBuilder = New StringBuilder()
                If Not folder.StartsWith("/") Then
                    currFolder.Append("/")
                End If
                For i As Integer = 0 To folderAry.Length - 1
                    If folderAry(i) = "" Then
                        Continue For
                    End If
                    currFolder.Append(folderAry(i) & "/")
                    Common.CreateSubFolder(currFolder.ToString())
                Next
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw
                End If
            End Try
        End Sub
#End Region

#Region "�إߤl�ؿ�"
        ''' <summary>
        ''' �إߤl�ؿ�
        ''' </summary>
        ''' <param name="folder">�ؿ��W��</param>
        ''' <remarks></remarks>
        Private Shared Sub CreateSubFolder(ByVal folder As String)
            Dim ftpAddress As String = APConfig.GetProperty("FTP_ADDRESS")
            Dim ftpID As String = APConfig.GetProperty("FTP_ID")
            Dim ftpPWD As String = APConfig.GetProperty("FTP_PWD")

            '���]�w FTP(�}�o���ҩάO��������)�ɤ��B�z
            If ftpAddress = "" Then
                Return
            End If

            folder = folder.Replace("\", "")

            If Not folder.StartsWith("/") Then
                folder = "/" & folder
            End If
            Try
                Dim ftpRequest As FtpWebRequest = FtpWebRequest.Create("ftp://" & ftpAddress & ":21" & folder)
                ftpRequest.Credentials = New NetworkCredential(ftpID, ftpPWD)
                ftpRequest.KeepAlive = False
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory
                ftpRequest.GetResponse.Close()
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw New Exception(ex.Message & vbCrLf & "ftp://" & ftpAddress & ":21" & folder)
                End If
            End Try
        End Sub
#End Region

#Region "FTP �R��"
        ''' <summary>
        ''' FTP �R��
        ''' </summary>
        ''' <param name="deleteFile">�R���ɮ�</param>
        ''' <remarks></remarks>
        Public Shared Sub FtpDelete(ByVal deleteFile As String)
            Dim ftpAddress As String = APConfig.GetProperty("FTP_ADDRESS")
            Dim ftpID As String = APConfig.GetProperty("FTP_ID")
            Dim ftpPWD As String = APConfig.GetProperty("FTP_PWD")

            '���]�w FTP(�}�o���ҩάO��������)�ɤ��B�z
            If ftpAddress = "" Then
                Return
            End If

            Try
                Dim ftpRequest As FtpWebRequest = FtpWebRequest.Create("ftp://" & ftpAddress & ":21" & deleteFile)
                ftpRequest.Credentials = New NetworkCredential(ftpID, ftpPWD)
                ftpRequest.KeepAlive = False
                ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile
                ftpRequest.GetResponse.Close()
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw New Exception(ex.Message & vbCrLf & "ftp://" & ftpAddress & ":21" & deleteFile)
                End If
            End Try
        End Sub
#End Region
#End Region

#Region "SFTP �����B�z"
#Region "SFTP �U��"
        ''' <summary>
        ''' SFTP �U��
        ''' </summary>
        ''' <param name="downloadFile">�U���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub SFtpDownload(ByVal downloadFile As String, ByVal savePath As String)
            Dim sftpAddress As String = APConfig.GetProperty("SFTP_ADDRESS")
            Dim sftpID As String = APConfig.GetProperty("SFTP_ID")
            Dim sftpPWD As String = APConfig.GetProperty("SFTP_PWD")
            Dim sftpFingerPrint As String = APConfig.GetProperty("SFTP_FINGERPRINT")

            '���]�w SFTP(�}�o���ҩάO��������)�ɤ��B�z
            If sftpAddress = "" Then
                Return
            End If

            If downloadFile.StartsWith("//") Then
                downloadFile.Remove(0, 1)
            End If

            If savePath.StartsWith("//") Then
                savePath.Remove(0, 1)
            End If

            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = sftpAddress
                .PortNumber = "22"
                .UserName = sftpID
                .Password = sftpPWD
                .SshHostKeyFingerprint = sftpFingerPrint
            End With

            Using session As New WinSCP.Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                transferResult = session.GetFiles(downloadFile, savePath, False, transferOptions)
                'transferResult = session.GetFiles(APConfig.GetProperty("SFTP_FILE") & downloadFile, savePath, False, transferOptions)
                'transferResult = session.GetFiles(downloadFile, savePath, False, transferOptions)
                ' Throw on any error
                transferResult.Check()
            End Using

        End Sub
#End Region

#Region "FTPS �U��"
        ''' <summary>
        ''' FTPS �U��
        ''' </summary>
        ''' <param name="downloadFile">�U���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub FTPSDownload(ByVal downloadFile As String, ByVal savePath As String)
            Try
                Dim FTPSAddress As String = APConfig.GetProperty("FTPS_ADDRESS")
                Dim FTPSID As String = APConfig.GetProperty("FTPS_ID")
                Dim FTPSPWD As String = APConfig.GetProperty("FTPS_PWD")
                Dim FTPSFingerPrint As String = APConfig.GetProperty("FTPS_FINGERPRINT")

                '���]�w FTPS(�}�o���ҩάO��������)�ɤ��B�z
                If FTPSAddress = "" Then
                    Return
                End If

                If downloadFile.StartsWith("//") Then
                    downloadFile = downloadFile.Remove(0, 1)
                End If

                If savePath.StartsWith("//") Then
                    savePath = savePath.Remove(0, 1)
                End If

                ' Setup session options
                Dim sessionOptions As New SessionOptions
                With sessionOptions
                    .Protocol = Protocol.Ftp
                    .HostName = FTPSAddress
                    .PortNumber = 10990
                    .UserName = FTPSID
                    .Password = FTPSPWD
                    .FtpSecure = FtpSecure.Explicit
                    .TlsHostCertificateFingerprint = FTPSFingerPrint
                    .GiveUpSecurityAndAcceptAnyTlsHostCertificate = True
                End With

                Using session As New WinSCP.Session
                    ' Connect
                    session.Open(sessionOptions)

                    ' Upload files
                    Dim transferOptions As New TransferOptions
                    transferOptions.TransferMode = TransferMode.Binary

                    Dim transferResult As TransferOperationResult
                    'transferResult = session.GetFiles(APConfig.GetProperty("FTPS_FILE") & downloadFile, savePath, False, transferOptions)
                    transferResult = session.GetFiles(downloadFile, savePath, False, transferOptions)
                    ' Throw on any error
                    transferResult.Check()
                End Using
            Catch e As Exception
                Console.WriteLine("Error: {0}", e)
            End Try
        End Sub
#End Region

#Region "SFTP �W��"
        ''' <summary>
        ''' SFTP �W��
        ''' </summary>
        ''' <param name="uploadFile">�W���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub SFtpUpload(ByVal uploadFile As String, ByVal savePath As String)
            Dim sftpAddress As String = APConfig.GetProperty("SFTP_ADDRESS")
            Dim sftpID As String = APConfig.GetProperty("SFTP_ID")
            Dim sftpPWD As String = APConfig.GetProperty("SFTP_PWD")
            Dim sftpFingerPrint As String = APConfig.GetProperty("SFTP_FINGERPRINT")

            '���]�w SFTP(�}�o���ҩάO��������)�ɤ��B�z
            If sftpAddress = "" Then
                Return
            End If

            If savePath.StartsWith("//") Then
                savePath.Remove(0, 1)
            End If

            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Sftp
                .HostName = sftpAddress
                .PortNumber = "22"
                .UserName = sftpID
                .Password = sftpPWD
                .SshHostKeyFingerprint = sftpFingerPrint

            End With

            Using session As New WinSCP.Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                transferResult = session.PutFiles(uploadFile, savePath, False, transferOptions)
                'transferResult = session.PutFiles(uploadFile, APConfig.GetProperty("SFTP_FILE") & savePath, False, transferOptions)
                'transferResult = session.PutFiles(uploadFile, savePath, False, transferOptions)

                ' Throw on any error
                transferResult.Check()
            End Using
        End Sub
#End Region

#Region "FTPS �W��"
        ''' <summary>
        ''' FTPS �W��
        ''' </summary>
        ''' <param name="uploadFile">�W���ɦW</param>
        ''' <param name="savePath">�s����|</param>
        ''' <remarks></remarks>
        Public Shared Sub FtpSUpload(ByVal uploadFile As String, ByVal savePath As String)
            Dim ftpsAddress As String = APConfig.GetProperty("FTPS_ADDRESS")
            Dim ftpsID As String = APConfig.GetProperty("FTPS_ID")
            Dim ftpsPWD As String = APConfig.GetProperty("FTPS_PWD")
            Dim ftpsFingerPrint As String = APConfig.GetProperty("FTPS_FINGERPRINT")

            If ftpsAddress = "" Then
                Return
            End If

            If savePath.StartsWith("//") Then
                savePath.Remove(0, 1)
            End If

            ' Setup session options
            Dim sessionOptions As New SessionOptions
            With sessionOptions
                .Protocol = Protocol.Ftp
                .HostName = ftpsAddress
                .PortNumber = "10990"
                .UserName = ftpsID
                .Password = ftpsPWD
                .TlsHostCertificateFingerprint = ftpsFingerPrint
                .FtpSecure = FtpSecure.Explicit
                .GiveUpSecurityAndAcceptAnyTlsHostCertificate = True
            End With

            Using session As New WinSCP.Session
                ' Connect
                session.Open(sessionOptions)

                ' Upload files
                Dim transferOptions As New TransferOptions
                transferOptions.TransferMode = TransferMode.Binary

                Dim transferResult As TransferOperationResult
                transferResult = session.PutFiles(uploadFile, savePath, False, transferOptions)
                'transferResult = session.PutFiles(uploadFile, APConfig.GetProperty("SFTP_FILE") & savePath, False, transferOptions)
                'transferResult = session.PutFiles(uploadFile, savePath, False, transferOptions)

                ' Throw on any error
                transferResult.Check()
            End Using
        End Sub
#End Region

#Region "�إߥؿ�"
        ''' <summary>
        ''' �إߥؿ�
        ''' </summary>
        ''' <param name="folder">�ؿ��W��</param>
        ''' <remarks></remarks>
        Public Shared Sub CreateSFTPFolder(ByVal folder As String)
            Try
                Dim folderAry As String() = folder.Split("/")
                Dim currFolder As StringBuilder = New StringBuilder()
                If Not folder.StartsWith("/") Then
                    currFolder.Append("/")
                End If
                For i As Integer = 0 To folderAry.Length - 1
                    If folderAry(i) = "" Then
                        Continue For
                    End If
                    currFolder.Append(folderAry(i) & "/")
                    Common.CreateSFTPSubFolder(currFolder.ToString())
                Next
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw
                End If
            End Try
        End Sub
#End Region

#Region "�إߤl�ؿ�"
        ''' <summary>
        ''' �إߤl�ؿ�
        ''' </summary>
        ''' <param name="folder">�ؿ��W��</param>
        ''' <remarks></remarks>
        Private Shared Sub CreateSFTPSubFolder(ByVal folder As String)

            Try
                Dim sftpAddress As String = APConfig.GetProperty("SFTP_ADDRESS")
                Dim sftpID As String = APConfig.GetProperty("SFTP_ID")
                Dim sftpPWD As String = APConfig.GetProperty("SFTP_PWD")
                Dim sftpFingerPrint As String = APConfig.GetProperty("SFTP_FINGERPRINT")

                '���]�w FTP(�}�o���ҩάO��������)�ɤ��B�z
                If sftpAddress = "" Then
                    Return
                End If

                folder = folder.Replace("\", "")

                If Not folder.StartsWith("/") Then
                    folder = "/" & folder
                End If

                ' Setup session options
                Dim sessionOptions As New SessionOptions
                With sessionOptions
                    .Protocol = Protocol.Sftp
                    .HostName = sftpAddress
                    .PortNumber = "22"
                    .UserName = sftpID
                    .Password = sftpPWD
                    .SshHostKeyFingerprint = sftpFingerPrint
                End With
                Using session As New WinSCP.Session
                    ' Connect
                    session.Open(sessionOptions)
                    session.CreateDirectory((APConfig.GetProperty("SFTP_FILE") & folder).Replace("//", "/"))
                End Using

            Catch
                'folder exist
            End Try

        End Sub
#End Region

#Region "SFTP �R��"
        Public Shared Function FtpSDelete(ByVal deleteFile As String) As String
            Try
                Dim ftpsAddress As String = APConfig.GetProperty("FTPS_ADDRESS")
                Dim ftpsID As String = APConfig.GetProperty("FTPS_ID")
                Dim ftpsPWD As String = APConfig.GetProperty("FTPS_PWD")
                Dim ftpsFingerPrint As String = APConfig.GetProperty("FTPS_FINGERPRINT")

                If ftpsAddress = "" Then
                    Return ""
                End If

                If deleteFile.StartsWith("//") Then
                    deleteFile.Remove(0, 1)
                End If

                ' Setup session options
                Dim sessionOptions As New SessionOptions
                With sessionOptions
                    .Protocol = Protocol.Ftp
                    .HostName = ftpsAddress
                    .PortNumber = "10990"
                    .UserName = ftpsID
                    .Password = ftpsPWD
                    .TlsHostCertificateFingerprint = ftpsFingerPrint
                    .FtpSecure = FtpSecure.Explicit
                    .GiveUpSecurityAndAcceptAnyTlsHostCertificate = True
                End With

                Using session As New WinSCP.Session
                    ' Connect
                    session.Open(sessionOptions)

                    Dim removalResult As RemovalOperationResult
                    removalResult = session.RemoveFiles(deleteFile)

                    ' Throw on any error
                    removalResult.Check()
                End Using

                Return ""
            Catch ex As SessionRemoteException
                Return ex.Message.ToString
            End Try
        End Function


        ''' <summary>
        ''' SFTP �R��
        ''' </summary>
        ''' <param name="deleteFile">�R���ɮ�</param>
        ''' <remarks></remarks>
        Public Shared Function SFtpDelete(ByVal deleteFile As String) As String
            Try
                Dim sftpAddress As String = APConfig.GetProperty("SFTP_ADDRESS")
                Dim sftpID As String = APConfig.GetProperty("SFTP_ID")
                Dim sftpPWD As String = APConfig.GetProperty("SFTP_PWD")
                Dim sftpFingerPrint As String = APConfig.GetProperty("SFTP_FINGERPRINT")

                '���]�w SFTP(�}�o���ҩάO��������)�ɤ��B�z
                If sftpAddress = "" Then
                    Return ""
                End If

                ' Setup session options
                Dim sessionOptions As New SessionOptions
                With sessionOptions
                    .Protocol = Protocol.Sftp
                    .HostName = sftpAddress
                    .PortNumber = "22"
                    .UserName = sftpID
                    .Password = sftpPWD
                    .SshHostKeyFingerprint = sftpFingerPrint
                End With

                Using session As New WinSCP.Session
                    ' Connect
                    session.Open(sessionOptions)

                    Dim removalResult As RemovalOperationResult
                    removalResult = session.RemoveFiles(deleteFile)
                    'removalResult = session.RemoveFiles((APConfig.GetProperty("SFTP_FILE") & deleteFile))
                    'removalResult = session.RemoveFiles(deleteFile)
                    ' Throw on any error
                    removalResult.Check()

                End Using
                Return ""
            Catch ex As SessionRemoteException
                '�ثe�����쬰file server�� �L�ɮװ��D
                Return "���A���W�ɮפ��s�b"
            End Try
        End Function


#End Region
#End Region

#Region "�R���ɮ�"
        ''' <summary>
        ''' �R���ɮ�
        ''' </summary>
        ''' <param name="filePath">�ɮ׸��|</param>
        ''' <remarks></remarks>
        Public Shared Sub DeleteFile(ByVal filePath As String)
            Try
                If APConfig.GetProperty("SFTP_ADDRESS") <> "" Then
                    Comm.Common.Common.SFtpDelete(filePath)
                ElseIf APConfig.GetProperty("FTP_ADDRESS") <> "" Then
                    Comm.Common.Common.FtpDelete(filePath)
                Else
                    System.IO.File.Delete(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & filePath)
                End If
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw
                End If
            End Try
        End Sub
#End Region

#Region "�W���ɮ�"
        ''' <summary>
        ''' �W���ɮ�
        ''' </summary>
        ''' <param name="folder">�ɮ׸��|</param>
        ''' <param name="filepath">�ɮצW��</param>
        ''' <remarks></remarks>
        Public Shared Sub UploadFile(ByVal folder As String, ByVal filepath As String)
            Try
                If APConfig.GetProperty("SFTP_ADDRESS") <> "" Then
                    '=== �إߥؿ� ===
                    Comm.Common.Common.CreateSFTPFolder(folder)
                    '=== �N�ɮפW�Ǧ� SFTP �� ===
                    Comm.Common.Common.SFtpUpload((APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & filepath).Replace("\\", "\").Replace("\/", "\").Replace("/", "\"), filepath)
                    '�R��temp��
                    System.IO.File.Delete(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & filepath)
                ElseIf APConfig.GetProperty("FTP_ADDRESS") <> "" Then
                    '=== �إߥؿ� ===
                    Comm.Common.Common.CreateFolder(folder)
                    '=== �N�ɮפW�Ǧ� SFTP �� ===
                    Comm.Common.Common.FtpUpload((APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & filepath).Replace("\\", "\").Replace("\/", "\").Replace("/", "\"), filepath)
                    '�R��temp��
                    System.IO.File.Delete(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & filepath)
                End If
            Catch ex As WebException
                '=== ����~���䤣��ӥؿ����ɮש����ӿ��~, (���ըC�����|�X�{�����D�ҥH����) ===
                If ex.Message.IndexOf("550") = -1 Then
                    Throw
                End If
            End Try
        End Sub

#End Region

#Region "�����~��"
        ''' <summary>
        ''' �O�~��(�e�T�X��"10.") reutrn true
        ''' ��L false
        ''' </summary>
        Public Shared Function IsExternInternet(ByVal ipList) As Boolean
            Try
                Dim IPAddress As String = ""

                For Each ip As Object In ipList
                    IPAddress &= ip.ToString() + " "
                    If IPAddress.Substring(0, 3) <> "10." Then
                        Return True
                    End If
                Next

                Return False

            Catch ex As Exception
                Throw ex
            End Try
        End Function
#End Region

#Region "String to Base64 String"
        Public Shared Function StrToBas64Str(ByVal str As String)

            If str IsNot Nothing Then
                If str.Length = 0 Then
                    Throw New Exception("StrToBas64Str �ǤJ�Ȭ���")
                End If
            Else
                Throw New Exception("StrToBas64Str �ǤJ�Ȭ���")
            End If

            Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(str)
            Dim base64_str As String = Convert.ToBase64String(byt)
            Return base64_str

        End Function
#End Region
#Region "Base64 String to String"
        Public Shared Function Base64StrToStr(ByVal base64Str As String)

            If base64Str IsNot Nothing Then
                If base64Str.Length = 0 Then
                    Throw New Exception("Base64StrToStr �ǤJ�Ȭ���")
                End If
            Else
                Throw New Exception("Base64StrToStr �ǤJ�Ȭ���")
            End If

            Dim byt As Byte() = Convert.FromBase64String(base64Str)
            Dim decodeBase64_uid As String = System.Text.Encoding.UTF8.GetString(byt)
            Return decodeBase64_uid

        End Function
#End Region

#Region "String To Decimal"
        Public Shared Function ToDecimal(ByVal strValue As String) As Decimal
            Dim d As Decimal
            If strValue.Length > 0 Then
                If Decimal.TryParse(strValue, d) Then Return d
            End If
            Return 0
        End Function

        ''' <summary>
        ''' �r����Ʀr�A�f���榡��
        ''' </summary>
        Public Shared Function ToFormattedDecimal(ByVal strValue As String) As String
            Dim d As Decimal
            Dim s As String = "0"

            If strValue.Length > 0 Then
                If Decimal.TryParse(strValue, d) Then
                    s = String.Format("{0:#,#;0;0}", d)
                End If
            End If

            Return s

        End Function
#End Region

        ''' <summary>
        ''' �m����XWord�ɪ�����Ÿ��A�ϥi�H���T����
        ''' </summary>
        Public Shared Function NewLineFormated(ByVal str As String) As String
            Try
                If str.Length > 0 Then
                    str = str.Replace(vbLf, vbCrLf)
                    str = str.Replace("  ", "�@")
                End If

                Return str
            Catch e As Exception
                Return e.Message
            End Try
        End Function


        Public Shared Sub ZipFileEntity(ByVal sourceDirectory As String, ByVal outputFileName As String)
            Try
                System.IO.Compression.ZipFile.CreateFromDirectory(sourceDirectory, outputFileName, IO.Compression.CompressionLevel.NoCompression, includeBaseDirectory:=False)

            Finally
            End Try
        End Sub

    End Class
End Namespace