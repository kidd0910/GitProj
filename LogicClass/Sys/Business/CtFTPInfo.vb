'----------------------------------------------------------------------------------
'File Name		: CtFTPInfo
'Author			: CM Huang
'Description		: CtFTPInfo FTP資訊
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2013/12/21	CM Huang   	Source Create
'0.0.2      2014/01/01  CM Huang    Add ExtractZipFile
'----------------------------------------------------------------------------------

Imports Sys.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.Util
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports Comm.Business

#Region "匯入元件 for FTP"
Imports System.Text
Imports System.Net
Imports System.IO
#End Region

#Region "匯入元件 for Zip"
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.Core
#End Region

Namespace Sys.Business
    ''' <summary>
    ''' CtFTPInfo
    ''' </summary>
    Partial Public Class CtFTPInfo
        Inherits Acer.Base.ControlBase

#Region "屬性"

#Region "ACC"
        '' <summary>
        '' SYS_PRTID
        '' </summary>
        Public Property ACC() As String
            Get
                Return Me.PropertyMap("ACC")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACC") = value
            End Set
        End Property
#End Region

#Region "PW"
        '' <summary>
        '' PW
        '' </summary>
        Public Property PW() As String
            Get
                Return Me.PropertyMap("PW")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PW") = value
            End Set
        End Property
#End Region

#Region "FTPURL"
        '' <summary>
        '' FTPURL
        '' </summary>
        Public Property FTPURL() As String
            Get
                Return Me.PropertyMap("FTPURL")
            End Get
            Set(ByVal value As String)
                If Right(value, 1) = "/" Or Right(value, 1) = "\" Then
                    value = Left(value, Len(value) - 1)
                End If
                Me.PropertyMap("FTPURL") = value
            End Set
        End Property
#End Region

#Region "LastErr"
        '' <summary>
        '' LastErr
        '' </summary>
        Public Property LastErr() As String
            Get
                Return Me.PropertyMap("LastErr")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("LastErr") = value
            End Set
        End Property
#End Region

#Region "Detail"
        '' <summary>
        '' Detail
        '' </summary>
        Public Property Detail() As Hashtable
            Get
                Return Me.PropertyMap("Detail")
            End Get
            Set(ByVal value As Hashtable)
                Me.PropertyMap("Detail") = value
            End Set
        End Property
#End Region

#Region "LocalPath"
        '' <summary>
        '' LocalPath
        '' </summary>
        Public Property LocalPath() As String
            Get
                Return Me.PropertyMap("LocalPath")
            End Get
            Set(ByVal value As String)
                If Right(value, 1) = "/" Or Right(value, 1) = "\" Then
                    value = Left(value, Len(value) - 1)
                End If
                Me.PropertyMap("LocalPath") = value
            End Set
        End Property
#End Region

#Region "FileName"
        '' <summary>
        '' FileName
        '' </summary>
        Public Property FileName() As String
            Get
                Return Me.PropertyMap("FileName")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FileName") = value
            End Set
        End Property
#End Region

#Region "Buffer"
        '' <summary>
        '' Buffer
        '' </summary>
        Public Property Buffer() As Integer
            Get
                Return Me.PropertyMap("Buffer")
            End Get
            Set(ByVal value As Integer)
                Me.PropertyMap("Buffer") = value
            End Set
        End Property
#End Region

#End Region

#Region "建構子"
        ''' <summary>
        ''' 建構子
        ''' </summary>
        ''' <param name="dbManager">dbManager 物件</param>
        ''' <param name="logUtil">logUtil 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            'Default 102400
            Me.Buffer = 1024 * 100
            '=== 關聯 Class ===

        End Sub
#End Region

#Region "方法"


#Region "取回檔案清單 FTPInfo"
        ''' <summary>
        ''' 取回FTP檔案清單
        ''' 1. 設定FTP,ACC,PW
        ''' 2. 若LastErr為空表登入成功, 用從Detail(hashTable)取出清單
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 CM Huang 新增方法
        ''' </remarks>
        Public Sub FTPInfo()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.FTPURL) Then
                    faileArguments.Add("FTPURL")
                End If

                If String.IsNullOrEmpty(Me.ACC) Then
                    faileArguments.Add("ACC")
                End If

                If String.IsNullOrEmpty(Me.PW) Then
                    faileArguments.Add("PW")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== FTP登入處理 ===
                Dim FTP As FtpWebRequest = DirectCast(WebRequest.Create(Me.FTPURL), FtpWebRequest)
                FTP.KeepAlive = False

                '清空錯誤記錄
                Me.LastErr = ""

                If Me.ACC.Length > 0 Then
                    '如果需要帳號登入
                    Dim nc As NetworkCredential = login()
                    '設定帳號
                    FTP.Credentials = nc
                End If

                FTP.Method = WebRequestMethods.Ftp.ListDirectory

                ' //設定Method取得目錄資訊
                Dim listResponse As FtpWebResponse = DirectCast(FTP.GetResponse(), FtpWebResponse)

                '取得檔案清單(System.Text.Encoding.Default 修正顯示中文為亂碼)
                Dim reader As StreamReader = New StreamReader(listResponse.GetResponseStream(), System.Text.Encoding.Default)

                Dim ht As New Hashtable()
                Dim i As Integer = 0
                While reader.Peek() >= 0
                    '開始讀取回傳資訊
                    ht(i) = reader.ReadLine()
                    i += 1
                End While

                If reader IsNot Nothing Then
                    reader.Close()
                End If

                '回傳目前清單
                Me.Detail = ht

            Catch ex As Exception
                Throw ex
                'Me.LastErr = ex.ToString()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try

        End Sub
#End Region


#Region "檔案下載 DownLoad"
        ''' <summary>
        ''' FTP檔案下載
        ''' 1. 設定 FTP,ACC,PW,FileName,Local
        ''' 2. 下載檔案若已存在則覆蓋
        ''' </summary>
        ''' <param name="mSec">Int 下載時延遲秒數(1/1000)</param>
        ''' <returns>Boolean true(成功) or false(失敗)</returns>
        ''' <remarks></remarks>
        Public Function DownLoad(Optional ByVal mSec As Integer = 1000) As Boolean

            Dim flag As Boolean = False

            Try

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.FTPURL) Then
                    faileArguments.Add("FTPURL")
                End If

                If String.IsNullOrEmpty(Me.ACC) Then
                    faileArguments.Add("ACC")
                End If

                If String.IsNullOrEmpty(Me.PW) Then
                    faileArguments.Add("PW")
                End If

                If String.IsNullOrEmpty(Me.FileName) Then
                    faileArguments.Add("FileName")
                End If

                If String.IsNullOrEmpty(Me.LocalPath) Then
                    faileArguments.Add("LocalPath")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 檢核欄位結束 ===

                Dim FileURL As String = Me.FTPURL & "/" & Me.FileName
                Dim FtpRequest As FtpWebRequest = DirectCast(WebRequest.Create(FileURL), FtpWebRequest)
                FtpRequest.Credentials = login()
                FtpRequest.Method = WebRequestMethods.Ftp.DownloadFile
                FtpRequest.UseBinary = True
                FtpRequest.UsePassive = True
                Dim WriteStream As FileStream = New FileStream(Me.LocalPath & "\" & Me.FileName, FileMode.Create, FileAccess.ReadWrite)
                Dim FtpResponse As WebResponse = FtpRequest.GetResponse
                Dim ReadStream As Stream = FtpResponse.GetResponseStream
                Dim IOLen As Integer = Me.Buffer
                Dim IOBuf(IOLen) As Byte

                Do
                    IOLen = ReadStream.Read(IOBuf, 0, Me.Buffer)
                    WriteStream.Write(IOBuf, 0, IOLen)
                Loop While IOLen > 0

                'Application.DoEvents()

                System.Threading.Thread.Sleep(mSec)
                ReadStream.Close()
                ReadStream.Dispose()
                WriteStream.Close()
                WriteStream.Dispose()
                Dim RespDesc As String = CType(FtpResponse, FtpWebResponse).StatusDescription

                If Mid(RespDesc, 1, 3) <> "226" Then
                    flag = False
                Else
                    flag = True
                End If

            Catch ex As Exception
                Me.LastErr = ex.ToString()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try

            Return flag
        End Function
#End Region


#Region "刪除檔案 DelFile"
        ''' <summary>
        ''' 刪除FTP檔案
        ''' 設定 FTP,ACC,PW,FileName
        ''' </summary>
        ''' <param name="mSec">Int 延遲秒數</param>
        ''' <returns>Boolean true:成功 or false:失敗</returns>
        ''' <remarks></remarks>
        Public Function DelFile(Optional ByVal mSec As Integer = 100) As Boolean

            Dim flag As Boolean = False

            Try

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.FTPURL) Then
                    faileArguments.Add("FTPURL")
                End If

                If String.IsNullOrEmpty(Me.ACC) Then
                    faileArguments.Add("ACC")
                End If

                If String.IsNullOrEmpty(Me.PW) Then
                    faileArguments.Add("PW")
                End If

                If String.IsNullOrEmpty(Me.FileName) Then
                    faileArguments.Add("FileName")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===



                Dim FileURL As String = Me.FTPURL & "/" & Me.FileName
                Dim FtpRequest As FtpWebRequest = CType(WebRequest.Create(FileURL), FtpWebRequest)
                FtpRequest.Credentials = login()
                FtpRequest.Method = WebRequestMethods.Ftp.DeleteFile
                Dim FtpResponse As WebResponse = FtpRequest.GetResponse

                'Application.DoEvents()

                System.Threading.Thread.Sleep(mSec)
                Dim RespDesc As String = CType(FtpResponse, FtpWebResponse).StatusDescription

                If Mid(RespDesc, 1, 3) <> "250" Then
                    flag = False
                Else
                    flag = True
                End If

            Catch ex As Exception
                Me.LastErr = ex.ToString()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try

            Return flag
        End Function
#End Region


#Region "FTP檔案上傳 Upload"
        ''' <summary>
        ''' FTP檔案上傳
        ''' 1. 設定 FTP,ACC,PW,FileName,Local
        ''' 2. 下載檔案若已存在則覆蓋
        ''' </summary>
        ''' <param name="mSec">Int 上傳時延遲秒數(1/1000)</param>
        ''' <returns>Boolean true(成功) or false(失敗)</returns>
        ''' <remarks></remarks>
        Public Function Upload(Optional ByVal mSec As Integer = 1000) As Boolean

            Dim flag As Boolean = False

            Try

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If String.IsNullOrEmpty(Me.FTPURL) Then
                    faileArguments.Add("FTPURL")
                End If

                If String.IsNullOrEmpty(Me.ACC) Then
                    faileArguments.Add("ACC")
                End If

                If String.IsNullOrEmpty(Me.PW) Then
                    faileArguments.Add("PW")
                End If

                If String.IsNullOrEmpty(Me.FileName) Then
                    faileArguments.Add("FileName")
                End If

                If String.IsNullOrEmpty(Me.LocalPath) Then
                    faileArguments.Add("LocalPath")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 檢核欄位結束 ===

                Dim FileURL As String = Me.FTPURL & "/ " & Me.FileName
                Dim FtpRequest As FtpWebRequest = CType(WebRequest.Create(FileURL), FtpWebRequest) '
                Dim IOLen As Integer = Me.Buffer
                Dim IOBuf(IOLen) As Byte
                FtpRequest.Credentials = login()
                FtpRequest.Method = WebRequestMethods.Ftp.UploadFile
                FtpRequest.UseBinary = True
                FtpRequest.UsePassive = True
                Dim ReadStream As FileStream = New FileStream(Me.LocalPath & "/" & Me.FileName, FileMode.Open, FileAccess.Read)
                Dim WriteStream As Stream = FtpRequest.GetRequestStream
                Do
                    IOLen = ReadStream.Read(IOBuf, 0, Me.Buffer)
                    WriteStream.Write(IOBuf, 0, IOLen)
                Loop While IOLen > 0

                'Application.DoEvents()

                System.Threading.Thread.Sleep(mSec)
                ReadStream.Close()
                ReadStream.Dispose()
                WriteStream.Close()
                WriteStream.Dispose()
                Dim FtpResponse As WebResponse = FtpRequest.GetResponse
                Dim RespDesc As String = CType(FtpResponse, FtpWebResponse).StatusDescription
                If Mid(RespDesc, 1, 3) <> "226" Then
                    flag = False
                Else
                    flag = True
                End If

            Catch ex As Exception
                Me.LastErr = ex.ToString()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try

            Return flag
        End Function
#End Region


#Region "傳回登入資訊 login"
        ''' <summary>
        ''' 傳回登入資訊 login
        ''' </summary>
        ''' <returns>NetworkCredential</returns>
        ''' <remarks>用解密過的帳號與密碼傳回登入資訊</remarks>
        Private Function login() As NetworkCredential

            Dim NC As NetworkCredential = Nothing
            Try

                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                NC = New NetworkCredential(Me.ACC, Me.PW)

            Catch ex As Exception
                Me.LastErr = ex.ToString()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try

            Return NC
        End Function
#End Region


#Region "顯示清單所有資料 showDetail"

        ''' <summary>
        ''' 顯示清單所有資料
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub showDetail()
            Console.WriteLine("=== FTP 檔案清單 ===")
            For Each Table As DictionaryEntry In Me.Detail
                Console.WriteLine("Key:[{0}], Value:[{1}]", Table.Key, Table.Value)
            Next
            Console.WriteLine()
        End Sub
#End Region


#Region "重設參數 reset"

        ''' <summary>
        ''' 重設參數
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub reset()
            Me.ResetColumnProperty()
            Me.Detail = New Hashtable()
        End Sub
#End Region


#Region "Zip解壓縮 ExtractZipFile"
        ''' <summary>
        ''' Zip解壓縮
        ''' </summary>
        ''' <param name="archiveFilenameIn">String Path + FileName</param>
        ''' <param name="password">String password</param>
        ''' <param name="outFolder">String path for Extract Folder</param>
        ''' <returns >String Exception Message</returns>
        ''' <remarks></remarks>
        Public Function ExtractZipFile(ByVal archiveFilenameIn As String, ByVal password As String, ByVal outFolder As String) As String
            'Dim rlt As String = ""
            'Dim zf As ZipFile = Nothing
            'Try
            '    Dim fs As FileStream = System.IO.File.OpenRead(archiveFilenameIn)
            '    zf = New ZipFile(fs)
            '    If Not [String].IsNullOrEmpty(password) Then    ' AES encrypted entries are handled automatically
            '        zf.Password = password
            '    End If
            '    For Each zipEntry As ZipEntry In zf
            '        If Not zipEntry.IsFile Then     ' Ignore directories
            '            Continue For
            '        End If
            '        Dim entryFileName As [String] = zipEntry.Name
            '        ' to remove the folder from the entry:- entryFileName = Path.GetFileName(entryFileName);
            '        ' Optionally match entrynames against a selection list here to skip as desired.
            '        ' The unpacked length is available in the zipEntry.Size property.

            '        Dim buffer As Byte() = New Byte(4095) {}    ' 4K is optimum
            '        Dim zipStream As Stream = zf.GetInputStream(zipEntry)

            '        ' Manipulate the output filename here as desired.
            '        Dim fullZipToPath As [String] = Path.Combine(outFolder, entryFileName)
            '        Dim directoryName As String = Path.GetDirectoryName(fullZipToPath)
            '        If directoryName.Length > 0 Then
            '            Directory.CreateDirectory(directoryName)
            '        End If

            '        ' Unzip file in buffered chunks. This is just as fast as unpacking to a buffer the full size
            '        ' of the file, but does not waste memory.
            '        ' The "Using" will close the stream even if an exception occurs.
            '        Using streamWriter As FileStream = System.IO.File.Create(fullZipToPath)
            '            StreamUtils.Copy(zipStream, streamWriter, buffer)
            '        End Using
            '    Next

            'Catch ex As Exception
            '    rlt = ex.ToString()
            'Finally
            '    If zf IsNot Nothing Then
            '        zf.IsStreamOwner = True     ' Makes close also shut the underlying stream
            '        ' Ensure we release resources
            '        zf.Close()
            '    End If
            'End Try

            'Return rlt
        End Function
#End Region


#End Region
    End Class
End Namespace