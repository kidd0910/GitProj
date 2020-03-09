'----------------------------------------------------------------------------------
'File Name		: CtAttchFile 
'Author			: nono
'Description		: CtAttchFile 管理附加檔案CT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1		2008/08/30	nono   		Source Create
'----------------------------------------------------------------------------------

Imports File.Data
Imports Acer.Log
Imports Acer.DB
Imports Acer.File
Imports Acer.Apps
Imports Acer.Util
Imports System.IO
Imports Comm.Business.CommonMessage
Imports System.Reflection.MethodBase
Imports System.Web

NameSpace File.Business
	''' <summary>
	''' CtAttchFile 管理附加檔案CT
	''' </summary>
	Public partial Class CtAttchFile
		Inherits Acer.Base.ControlBase

#Region "屬性"
#Region "PAGE_NAME 頁面名稱"
        ''' <summary>
        ''' PAGE_NAME 頁面名稱
        ''' </summary>
        Public Property PAGE_NAME() As String
            Get
                Return Me.PropertyMap("PAGE_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("PAGE_NAME") = value
            End Set
        End Property
#End Region

#Region "FILE_NO 檔案號碼"
        ''' <summary>
        ''' FILE_NO 檔案號碼
        ''' </summary>
        Public Property FILE_NO() As String
            Get
                Return Me.PropertyMap("FILE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FILE_NO") = value
            End Set
        End Property
#End Region

#Region "IS_INS 是否新增"
        ''' <summary>
        ''' IS_INS 是否新增
        ''' </summary>
        Public Property IS_INS() As String
            Get
                Return Me.PropertyMap("IS_INS")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("IS_INS") = value
            End Set
        End Property
#End Region

#Region "USE_ID 使用識別"
        ''' <summary>
        ''' USE_ID 使用識別
        ''' </summary>
        Public Property USE_ID() As String
            Get
                Return Me.PropertyMap("USE_ID")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_ID") = value
            End Set
        End Property
#End Region

#Region "UPLD_DATE 上傳日期"
        ''' <summary>
        ''' UPLD_DATE 上傳日期
        ''' </summary>
        Public Property UPLD_DATE() As String
            Get
                Return Me.PropertyMap("UPLD_DATE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("UPLD_DATE") = value
            End Set
        End Property
#End Region

#Region "CONN_NAME 連線名稱"
        ''' <summary>
        ''' CONN_NAME 連線名稱
        ''' </summary>
        Public Property CONN_NAME() As String
            Get
                Return Me.PropertyMap("CONN_NAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("CONN_NAME") = value
            End Set
        End Property
#End Region

#Region "USE_NO 使用號碼"
        ''' <summary>
        ''' USE_NO 使用號碼
        ''' </summary>
        Public Property USE_NO() As String
            Get
                Return Me.PropertyMap("USE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("USE_NO") = value
            End Set
        End Property
#End Region

#Region "ACCE_SOURCE 附件來源"
        ''' <summary>
        ''' ACCE_SOURCE 附件來源
        ''' </summary>
        Public Property ACCE_SOURCE() As String
            Get
                Return Me.PropertyMap("ACCE_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACCE_SOURCE") = value
            End Set
        End Property
#End Region

#Region "ACTUAL_FILENAME 實際檔名"
        ''' <summary>
        ''' ACTUAL_FILENAME 實際檔名
        ''' </summary>
        Public Property ACTUAL_FILENAME() As String
            Get
                Return Me.PropertyMap("ACTUAL_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("ACTUAL_FILENAME") = value
            End Set
        End Property
#End Region

#Region "TEMP_FILE_PATH 暫存檔案路徑"
        ''' <summary>
        ''' TEMP_FILE_PATH 暫存檔案路徑
        ''' </summary>
        Public Property TEMP_FILE_PATH() As String
            Get
                Return Me.PropertyMap("TEMP_FILE_PATH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("TEMP_FILE_PATH") = value
            End Set
        End Property
#End Region

#Region "COMMON_FILE_PATH 共用檔案路徑"
        ''' <summary>
        ''' COMMON_FILE_PATH 共用檔案路徑
        ''' </summary>
        Public Property COMMON_FILE_PATH() As String
            Get
                Return Me.PropertyMap("COMMON_FILE_PATH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("COMMON_FILE_PATH") = value
            End Set
        End Property
#End Region

#Region "FILE_ACCESS_PATH 檔案存取路徑"
        ''' <summary>
        ''' FILE_ACCESS_PATH 檔案存取路徑
        ''' </summary>
        Public Property FILE_ACCESS_PATH() As String
            Get
                Return Me.PropertyMap("FILE_ACCESS_PATH")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FILE_ACCESS_PATH") = value
            End Set
        End Property
#End Region

#Region "FILE_EXPL 檔案說明"
        ''' <summary>
        ''' FILE_EXPL 檔案說明
        ''' </summary>
        Public Property FILE_EXPL() As String
            Get
                Return Me.PropertyMap("FILE_EXPL")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("FILE_EXPL") = value
            End Set
        End Property
#End Region

#Region "OLD_FILE_NO "
        ''' <summary>
        ''' OLD_FILE_NO 
        ''' </summary>
        Public Property OLD_FILE_NO() As String
            Get
                Return Me.PropertyMap("OLD_FILE_NO")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("OLD_FILE_NO") = value
            End Set
        End Property
#End Region

#Region "SKIP_UPDATE_TEMPTABLE "
        ''' <summary>
        ''' SKIP_UPDATE_TEMPTABLE 
        ''' </summary>
        Public Property SKIP_UPDATE_TEMPTABLE() As String
            Get
                Return Me.PropertyMap("SKIP_UPDATE_TEMPTABLE")
            End Get
            Set(ByVal value As String)
                Me.PropertyMap("SKIP_UPDATE_TEMPTABLE") = value
            End Set
        End Property
#End Region

#Region "FILE_NAME "
		''' <summary>
		''' FILE_NAME 
		''' </summary>
		Public Property FILE_NAME() As String
			Get
				Return Me.PropertyMap("FILE_NAME")
			End Get
			Set(ByVal value As String)
				Me.PropertyMap("FILE_NAME") = value
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

            '=== 關聯 Class ===
        End Sub
#End Region

#Region "方法"
#Region "ClearTempFile 清除暫存檔案"
        ''' <summary>
        ''' 清除暫存檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub ClearTempFile()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 頁面名稱 ===
                If String.IsNullOrEmpty(Me.PAGE_NAME) Then
                    faileArguments.Add("PAGE_NAME")
                End If
                '=== 使用識別 ===
                If String.IsNullOrEmpty(Me.USE_ID) Then
                    faileArguments.Add("USE_ID")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                '1.取得暫存檔案
                'EntTempFile = New EntTempFile
                'dt= EntTempFile.Query()
                '
                '2.針對程式名稱跟使用識別刪除暫存檔案
                '
                'EntTempFile.delete()
                '
                '--如果沒有下載至本機免使用
                '3.刪除路徑的實體檔案

                Dim cond As StringBuilder = New StringBuilder()

                '=== 取得此作業暫存的檔案清單 ===
                If Me.USE_NO = "" Then
                    cond.Append("ISNULL(USE_NO,'') ='' ")
                Else
                    cond.Append("USE_NO = '" & Me.USE_NO & "' ")
                End If

                cond.Append("AND PAGE_NAME = '" & Me.PAGE_NAME & "' ")
                cond.Append("AND USE_ID = '" & Me.USE_ID & "'")

                Dim ent As EntTempFile = New EntTempFile(Me.DBManager, Me.LogUtil)
                ent.SqlRetrictions = cond.ToString()
                Dim dt As DataTable = ent.Query()

                '=== 刪除資料庫 ===
                ent.SqlRetrictions = cond.ToString()
                ent.Delete()

                '=== 刪除檔案 ===
                For i As Integer = 0 To dt.Rows.Count - 1
                    Dim file As System.IO.FileInfo = New FileInfo(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME"))
                    If file.Exists Then
                        file.Attributes = System.IO.FileAttributes.Normal
                    End If

                    System.IO.File.Delete(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME"))
                    'FileUtil.DelFile()
                Next
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "MoveFile 搬移至附加檔"
        ''' <summary>
        ''' 搬移至附加檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub MoveFile()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 附件來源 ===
                If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
                    faileArguments.Add("ACCE_SOURCE")
                End If
                '=== 檔案號碼 ===
                If String.IsNullOrEmpty(Me.FILE_NO) Then
                    faileArguments.Add("FILE_NO")
                End If
                '=== 檔案存取路徑 ===
                If String.IsNullOrEmpty(Me.FILE_ACCESS_PATH) Then
                    faileArguments.Add("FILE_ACCESS_PATH")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                Me.PAGE_NAME = Me.ACCE_SOURCE
                Me.USE_NO = Me.FILE_NO

                Dim entTemp As EntTempFile = New EntTempFile(Me.DBManager, Me.LogUtil)
                If Not String.IsNullOrEmpty(Me.OLD_FILE_NO) Then
                    If String.IsNullOrEmpty(Me.SKIP_UPDATE_TEMPTABLE) Then
                        entTemp.USE_NO = Me.FILE_NO
                        entTemp.SqlRetrictions = "USE_NO = '" & Me.OLD_FILE_NO & "'"
                        entTemp.Update()
                    End If
                End If

                Dim cond As String
                Dim cond1 As String

                If Me.IS_INS Then
                    cond = " ISNULL(USE_NO,'') ='' "
                    cond1 = " ISNULL(FILE_NO,'') ='' "
                Else
                    If String.IsNullOrEmpty(Me.SKIP_UPDATE_TEMPTABLE) Then
                        cond = "USE_NO IN ('" & Me.USE_NO & "')"
                    Else
                        cond = "USE_NO IN ('" & Me.OLD_FILE_NO & "')"
                    End If

                    If Not String.IsNullOrEmpty(Me.OLD_FILE_NO) Then
                        cond1 = "FILE_NO IN ('" & Me.OLD_FILE_NO & "')"
                    Else
                        cond1 = "FILE_NO IN ('" & Me.USE_NO & "')"
                    End If
                End If

                '=== 刪除正式環境資料 ===
                Dim entCurr As EntAttachFile = New EntAttachFile(Me.DBManager, Me.LogUtil)
                entCurr.SqlRetrictions = "ACCE_SOURCE = '" & Me.PAGE_NAME & "' AND " & cond1
                entCurr.Delete()

                '=== 取得要搬移的資料清單 ===
                Dim dt As DataTable

                entTemp.SqlRetrictions = "PAGE_NAME = '" & Me.PAGE_NAME & "' AND " & _
                    "USE_ID	= '" & Me.USE_ID & "' AND " & cond.ToString()
                dt = entTemp.Query()

                '=== 搬移至要搬的目錄下 ===	
                Dim path As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH")

                For i As Integer = 0 To dt.Rows.Count - 1

                    '=== 搬移至要搬的目錄下 ===	
                    Try
                        '=== 產生目錄 ===
                        If Not System.IO.Directory.Exists(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & Me.FILE_ACCESS_PATH.ToString.TrimEnd("/")) Then
                            System.IO.Directory.CreateDirectory(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & Me.FILE_ACCESS_PATH.ToString.TrimEnd("/"))
                        End If

                        '=== 複製檔案到伺服器上 ===
                        Dim file As System.IO.FileInfo = New FileInfo(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME"))
                        If file.Exists Then
                            file.Attributes = System.IO.FileAttributes.Normal
                        End If
                        System.IO.File.Move(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME"), APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & Me.FILE_ACCESS_PATH & dt.Rows(i)("ACTUAL_FILENAME"))
                    Catch ex As Exception
                    End Try

                    Comm.Common.Common.UploadFile(Me.FILE_ACCESS_PATH.ToString().TrimStart("/").TrimEnd("/"), Me.FILE_ACCESS_PATH & dt.Rows(i)("ACTUAL_FILENAME"))

                    '=== 寫入新資料庫資料 ===
                    entCurr.ACCE_SOURCE = Me.PAGE_NAME                '附件來源
                    entCurr.FILE_NAME = dt.Rows(i)("FILE_NAME").ToString().Replace("'", "")          '實際檔名
                    entCurr.ACTUAL_FILENAME = dt.Rows(i)("ACTUAL_FILENAME").ToString()        '實際檔名
                    entCurr.FILE_ACCESS_PATH = Me.FILE_ACCESS_PATH         '檔案存取路徑
                    entCurr.FILE_EXPL = dt.Rows(i)("FILE_EXPL").ToString()  '檔案說明
                    entCurr.FILE_NO = Me.USE_NO               '檔案號碼
                    entCurr.UPLD_DATE = Now.ToString("yyyy/MM/dd")      '上傳日期
                    entCurr.FILE_SORT = dt.Rows(i)("FILE_SORT").ToString()        '檔案排序
                    entCurr.Insert()

                Next

                '=== 清除暫存資料 ===
                If Me.IS_INS Then
                    Me.USE_NO = ""
                    Me.ClearTempFile()
                End If

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "MoveFileToTemp 搬移檔案至暫存檔"
        ''' <summary>
        ''' 搬移檔案至暫存檔 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub MoveFileToTemp()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 使用識別 ===
                If String.IsNullOrEmpty(Me.USE_ID) Then
                    faileArguments.Add("USE_ID")
                End If
                '=== 頁面名稱 ===
                If String.IsNullOrEmpty(Me.PAGE_NAME) Then
                    faileArguments.Add("PAGE_NAME")
                End If
                '=== 實體檔案目錄 ===
                If String.IsNullOrEmpty(Me.FILE_ACCESS_PATH) Then
                    faileArguments.Add("FILE_ACCESS_PATH")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If

                '=== 清除暫存 ===
                Me.ClearTempFile()


                '=== 新增不必處理 ===
                If Me.USE_NO = "" Then
                    Exit Sub
                End If

                '=== 取得要搬移的資料清單 ===
                Dim cond As StringBuilder = New StringBuilder()                
                cond.Append("ACCE_SOURCE = '" & Me.PAGE_NAME & "' AND " & _
                  "LTRIM(FILE_NO) IN ('" & Me.USE_NO & "')")
                Dim entCurr As EntAttachFile = New EntAttachFile(Me.DBManager, Me.LogUtil)
                entCurr.SqlRetrictions = cond.ToString()
                Dim dt As DataTable = entCurr.Query()

                Dim newKey As String() = Me.USE_NO.Replace("','", ",").Split(",")
                Dim entTmp As EntTempFile = New EntTempFile(Me.DBManager, Me.LogUtil)

                Dim path As String = APConfig.GetProperty("TEMP_UPLOADFILE_PATH")
                Dim fileName As String = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    '=== 正式目錄 ===
                    fileName = Cf(path & Me.FILE_ACCESS_PATH & dt.Rows(i)("ACTUAL_FILENAME"))

                    '=== 產生目錄 ===
                    If Not System.IO.Directory.Exists(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & Me.FILE_ACCESS_PATH.ToString.TrimEnd("/")) Then
                        System.IO.Directory.CreateDirectory(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & Me.FILE_ACCESS_PATH.ToString.TrimEnd("/"))
                    End If

                    '從Ftp下載
                    '=== 搬移至要搬的目錄下, 2007/06/29 調整為當有設 FTP 時抓取 FTP 目錄資料 ===
                    If APConfig.GetProperty("SFTP_ADDRESS") <> "" Then
                        Comm.Common.Common.SFtpDownload(Me.FILE_ACCESS_PATH.ToString.Replace("\", "/") & dt.Rows(i)("ACTUAL_FILENAME"), Cf(path & Me.FILE_ACCESS_PATH & dt.Rows(i)("ACTUAL_FILENAME")))
                    ElseIf APConfig.GetProperty("FTP_ADDRESS") <> "" Then
                        Comm.Common.Common.FtpDownload(Me.FILE_ACCESS_PATH.ToString.Replace("\", "/") & dt.Rows(i)("ACTUAL_FILENAME"), Cf(path & Me.FILE_ACCESS_PATH & dt.Rows(i)("ACTUAL_FILENAME")))
                    End If

                    If Not System.IO.File.Exists(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME")) Then
                        Try
                            Dim file As System.IO.FileInfo = New FileInfo(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("FILE_ACCESS_PATH") & dt.Rows(i)("ACTUAL_FILENAME"))
                            If file.Exists Then
                                file.Attributes = System.IO.FileAttributes.Normal
                            End If
                            System.IO.File.Copy(APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("FILE_ACCESS_PATH") & dt.Rows(i)("ACTUAL_FILENAME"), APConfig.GetProperty("TEMP_UPLOADFILE_PATH") & dt.Rows(i)("ACTUAL_FILENAME"))
                        Catch ex As Exception
                            Dim msg As String = ex.Message
                        End Try
                    End If

                    '=== 寫入暫存資料庫資料 ===
                    entTmp.USE_ID = Me.USE_ID
                    If USE_NO <> "" Then
                        entTmp.USE_NO = Me.USE_NO
                    End If
                    entTmp.ACTUAL_FILENAME = dt.Rows(i)("ACTUAL_FILENAME")
                    entTmp.FILE_NAME = dt.Rows(i)("FILE_NAME").ToString
                    entTmp.FILE_EXPL = dt.Rows(i)("FILE_EXPL").ToString()
                    entTmp.PAGE_NAME = Me.PAGE_NAME
                    entTmp.FILE_EXPL = dt.Rows(i)("FILE_EXPL").ToString()
                    entTmp.FILE_SORT = dt.Rows(i)("FILE_SORT").ToString()
                    entTmp.Insert()
                Next

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "GetAllFile 取得所有檔案"
        ''' <summary>
        ''' 取得所有檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetAllFile() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 檔案號碼 ===
                If String.IsNullOrEmpty(Me.FILE_NO) Then
                    faileArguments.Add("FILE_NO")
                End If
                '=== 附件來源 ===
                If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
                    faileArguments.Add("ACCE_SOURCE")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "ACCE_SOURCE", Me.ACCE_SOURCE)   '附件來源
                Me.ProcessQueryCondition(condition, "=", "FILE_NO", Me.FILE_NO) '檔案號碼
                Dim EntAttachFile As EntAttachFile = New EntAttachFile(DBManager, LogUtil)
                EntAttachFile.SqlRetrictions = Me.ProcessCondition(condition.ToString())
                Dim ruslt As DataTable = New DataTable
                If Me.PageNo = 0 Then
                    ruslt = EntAttachFile.Query
                Else
                    ruslt = EntAttachFile.Query
                    Me.TotalRowCount = EntAttachFile.TotalRowCount
                End If
                Me.ResetColumnProperty()
                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region


#Region "GetAllFile 取得所有檔案"
        ''' <summary>
        ''' 取得所有檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function GetAllTempFile() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 檔案號碼 ===
                If String.IsNullOrEmpty(Me.PAGE_NAME) Then
                    faileArguments.Add("PAGE_NAME")
                End If
                '=== 附件來源 ===
                If String.IsNullOrEmpty(Me.USE_ID) Then
                    faileArguments.Add("USE_ID")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                Dim condition As StringBuilder = New StringBuilder()
                Me.ProcessQueryCondition(condition, "=", "PAGE_NAME", Me.PAGE_NAME)
                Me.ProcessQueryCondition(condition, "=", "USE_ID", Me.USE_ID)

                Dim cond As String
                If Me.IS_INS Then
                    cond = "USE_NO IS NULL"
                Else
                    cond = "USE_NO IN ('" & Me.USE_NO & "')"
                End If


                Me.ProcessQueryCondition(condition, "=", "USE_NO", Me.USE_NO)
                Dim entTemp As EntTempFile = New EntTempFile(Me.DBManager, Me.LogUtil)
                entTemp.SqlRetrictions = Me.ProcessCondition(condition.ToString()) & " AND " & cond
                Dim ruslt As DataTable = New DataTable
                If Me.PageNo = 0 Then
                    ruslt = entTemp.Query
                Else
                    ruslt = entTemp.Query
                    Me.TotalRowCount = entTemp.TotalRowCount
                End If
                Me.ResetColumnProperty()
                Return ruslt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddCopyFile 新增複製檔案"
        ''' <summary>
        ''' 新增複製檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddCopyFile()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 附件來源 ===
                If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
                    faileArguments.Add("ACCE_SOURCE")
                End If
                '=== 實際檔名 ===
                If String.IsNullOrEmpty(Me.ACTUAL_FILENAME) Then
                    faileArguments.Add("ACTUAL_FILENAME")
                End If
                '=== 上傳日期 ===
                If String.IsNullOrEmpty(Me.UPLD_DATE) Then
                    faileArguments.Add("UPLD_DATE")
                End If
                '=== 檔案說明 ===
                If String.IsNullOrEmpty(Me.FILE_EXPL) Then
                    faileArguments.Add("FILE_EXPL")
                End If
                '=== 檔案號碼 ===
                If String.IsNullOrEmpty(Me.FILE_NO) Then
                    faileArguments.Add("FILE_NO")
                End If
                '=== 檔案存取路徑 ===
                If String.IsNullOrEmpty(Me.FILE_ACCESS_PATH) Then
                    faileArguments.Add("FILE_ACCESS_PATH")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===
                Dim EntAttachFile As EntAttachFile = New EntAttachFile(DBManager, LogUtil)
                '=== 先刪除資料 ===
                EntAttachFile.SqlRetrictions = "FILE_NO = '" & Me.FILE_NO & "' AND ACTUAL_FILENAME = '" & Me.ACTUAL_FILENAME & "' AND ACCE_SOURCE = '" & Me.ACCE_SOURCE & "'"
                EntAttachFile.Delete()

                EntAttachFile.UPLD_DATE = Me.UPLD_DATE    '上傳日期
                EntAttachFile.ACTUAL_FILENAME = Me.ACTUAL_FILENAME  '實際檔名
                EntAttachFile.FILE_ACCESS_PATH = Me.FILE_ACCESS_PATH '檔案存取路徑
                EntAttachFile.FILE_NO = Me.FILE_NO  '檔案號碼
                EntAttachFile.FILE_EXPL = Me.FILE_EXPL    '檔案說明
                EntAttachFile.ACCE_SOURCE = Me.ACCE_SOURCE  '附件來源
				EntAttachFile.FILE_NAME = Me.FILE_NAME
                '=== 處理說明 ===
                EntAttachFile.Insert()

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteFile 刪除檔案"
		''' <summary>
		''' 刪除檔案 
		''' </summary>
		''' <remarks>
		''' 0.0.1 作者 新增方法
		''' </remarks>
		Public Sub DeleteFile()
			Try
				Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
				Me.LogProperty()

				'=== 檢核欄位起始 ===
				Dim faileArguments As ArrayList = New ArrayList()
				'=== 附件來源 ===
				If String.IsNullOrEmpty(Me.ACCE_SOURCE) Then
					faileArguments.Add("ACCE_SOURCE")
				End If
				
				'=== 檔案號碼 ===
				If String.IsNullOrEmpty(Me.FILE_NO) Then
					faileArguments.Add("FILE_NO")
				End If
				
				If faileArguments.Count > 0 Then
					Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
				End If
				'=== 刪除正式環境資料 ===
				Dim entCurr As EntAttachFile = New EntAttachFile(Me.DBManager, Me.LogUtil)
				entCurr.SqlRetrictions = "ACCE_SOURCE = '" & Me.ACCE_SOURCE & "' AND FILE_NO='" & FILE_NO & "'"
				entCurr.Delete()

                Me.ResetColumnProperty()
			Finally
				Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
			End Try
		End Sub
#End Region

#Region "Cf 調整反斜線"
        Private Function Cf(ByVal path As String) As String
            Return path.Replace("\\", "\").Replace("\/", "\").Replace("/", "\")
        End Function
#End Region

#End Region
	End Class
End NameSpace

