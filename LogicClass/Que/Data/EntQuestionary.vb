'----------------------------------------------------------------------------------
'File Name		: EntQuestionary
'Author			:  
'Description		: EntQuestionary 問卷ENT
'Modification Log	:
'
'Vers		Date       	By		Notes
'--------------	--------------	--------------	----------------------------------
'0.0.1     2016/11/11       Source Create COPY FROM
'----------------------------------------------------------------------------------

Imports System.Data.Common
Imports Acer.Apps
Imports Acer.DB
Imports Acer.DB.Query
Imports Acer.Util
Imports Acer.Log
Imports File.Data
Imports System.Reflection.MethodBase
Imports Comm.Business

Namespace Que.Data
    '' <summary>
    '' EntQuestionary 問卷ENT
    '' </summary>
    Public Class EntQuestionary
        Inherits Acer.Base.EntityBase
        Implements Acer.Base.IEntityInterface

#Region "建構子"
        '' <summary>
        '' 建構子/處理屬性對應處理
        '' </summary>
        '' <param name="dt">DataTable 物件</param>
        Public Sub New(ByVal dt As DataTable)
            MyBase.New(dt)
        End Sub

        '' <summary>
        '' 建構子/處理異動處理
        '' </summary>
        '' <param name="dbManager">DBManager 物件</param>
        Public Sub New(ByVal dbManager As DBManager, ByVal logUtil As LogUtil)
            MyBase.New(dbManager, logUtil)
            Me.TableName = "QUET010"
            Me.SysName = "QUE"
            Me.ConnName = "TSBA"

            MyBase.SET_NULL_FIELD = "DEADLINE_TIME,DEADLINE_DATE,UPDRAFT_DATE,DODRAFT_DATE,CREATE_TIME,UPDATE_TIME,START_DATE,QSTNNR_FORMAT,IS_SIGN,IS_REPEAT,IS_DISP_RESULT,QSTNNR_SEQ,IS_ANNOUNCE_OUTER,ANSWER_RATE,IS_USE_SUBJECT_VECTOR"


            '=== 關聯 Class ===
            Me.EntAttachFile = New EntAttachFile(Me.DBManager, Me.LogUtil)
            '       Me.EntHeadingDegree = New EntHeadingDegree(Me.DBManager, Me.LogUtil)
            '       Me.EntQuestionaryHeading = New EntQuestionaryHeading(Me.DBManager, Me.LogUtil)
            '           Me.EntQuestionaryObj = New EntQuestionaryObj(Me.DBManager, Me.LogUtil)
            '
            '=== 處理別名 ===
        End Sub
#End Region

#Region "屬性"

#Region "ACCE_SOURCE 附件來源"
        ''' <summary>
        ''' ACCE_SOURCE 附件來源
        ''' </summary>
        Public Property ACCE_SOURCE() As String
            Get
                Return Me.ColumnyMap("ACCE_SOURCE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACCE_SOURCE") = value
            End Set
        End Property
#End Region

#Region "ACTUAL_FILENAME 實際檔名"
        ''' <summary>
        ''' ACTUAL_FILENAME 實際檔名
        ''' </summary>
        Public Property ACTUAL_FILENAME() As String
            Get
                Return Me.ColumnyMap("ACTUAL_FILENAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ACTUAL_FILENAME") = value
            End Set
        End Property
#End Region

#Region "ANSWER_RATE 答案比率"
        ''' <summary>
        ''' ANSWER_RATE 答案比率
        ''' </summary>
        Public Property ANSWER_RATE() As String
            Get
                Return Me.ColumnyMap("ANSWER_RATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ANSWER_RATE") = value
            End Set
        End Property
#End Region

#Region "CREATE_UNIT 建立單位"
        ''' <summary>
        ''' CREATE_UNIT 建立單位
        ''' </summary>
        Public Property CREATE_UNIT() As String
            Get
                Return Me.ColumnyMap("CREATE_UNIT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_UNIT") = value
            End Set
        End Property
#End Region

#Region "CREATE_UNIT_NAME 建立單位名稱"
        ''' <summary>
        ''' CREATE_UNIT_NAME 建立單位名稱
        ''' </summary>
        Public Property CREATE_UNIT_NAME() As String
            Get
                Return Me.ColumnyMap("CREATE_UNIT_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("CREATE_UNIT_NAME") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_DATE 截止日期"
        ''' <summary>
        ''' DEADLINE_DATE 截止日期
        ''' </summary>
        Public Property DEADLINE_DATE() As String
            Get
                Return Me.ColumnyMap("DEADLINE_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE_DATE") = value
            End Set
        End Property
#End Region

#Region "DEADLINE_TIME 截止時間"
        ''' <summary>
        ''' DEADLINE_TIME 截止時間
        ''' </summary>
        Public Property DEADLINE_TIME() As String
            Get
                Return Me.ColumnyMap("DEADLINE_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEADLINE_TIME") = value
            End Set
        End Property
#End Region

#Region "DEP_NAME 單位名稱"
        ''' <summary>
        ''' DEP_NAME 單位名稱
        ''' </summary>
        Public Property DEP_NAME() As String
            Get
                Return Me.ColumnyMap("DEP_NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DEP_NAME") = value
            End Set
        End Property
#End Region

#Region "DODRAFT_DATE 下稿日期"
        ''' <summary>
        ''' DODRAFT_DATE 下稿日期
        ''' </summary>
        Public Property DODRAFT_DATE() As String
            Get
                Return Me.ColumnyMap("DODRAFT_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DODRAFT_DATE") = value
            End Set
        End Property
#End Region

#Region "DOWNLOAD_ADDR 參考網址"
        ''' <summary>
        ''' DOWNLOAD_ADDR 參考網址
        ''' </summary>
        Public Property DOWNLOAD_ADDR() As String
            Get
                Return Me.ColumnyMap("DOWNLOAD_ADDR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("DOWNLOAD_ADDR") = value
            End Set
        End Property
#End Region

#Region "EntAttachFile 共用附加檔案ENT[]"
        ''' <summary>
        ''' EntAttachFile 共用附加檔案ENT[]
        ''' </summary>
        Public Property EntAttachFile() As EntAttachFile
            Get
                Return Me.PropertyMap("EntAttachFile")
            End Get
            Set(ByVal value As EntAttachFile)
                Me.PropertyMap("EntAttachFile") = value
            End Set
        End Property
#End Region

#Region "EntHeadingDegree 題目向度ENT[]"
        ''' <summary>
        ''' EntHeadingDegree 題目向度ENT[]
        ''' </summary>
        Public Property EntHeadingDegree() As EntHeadingDegree
            Get
                Return Me.PropertyMap("EntHeadingDegree")
            End Get
            Set(ByVal value As EntHeadingDegree)
                Me.PropertyMap("EntHeadingDegree") = value
            End Set
        End Property
#End Region

#Region "EntQuestionaryHeading 問卷單題目ENT[]"
        ''' <summary>
        ''' EntQuestionaryHeading 問卷單題目ENT[]
        ''' </summary>
        Public Property EntQuestionaryHeading() As EntQuestionaryHeading
            Get
                Return Me.PropertyMap("EntQuestionaryHeading")
            End Get
            Set(ByVal value As EntQuestionaryHeading)
                Me.PropertyMap("EntQuestionaryHeading") = value
            End Set
        End Property
#End Region

#Region "EntQuestionaryObj 問卷對象ENT[]"
        ''' <summary>
        ''' EntQuestionaryObj 問卷對象ENT[]
        ''' </summary>
        Public Property EntQuestionaryObj() As EntQuestionaryObj
            Get
                Return Me.PropertyMap("EntQuestionaryObj")
            End Get
            Set(ByVal value As EntQuestionaryObj)
                Me.PropertyMap("EntQuestionaryObj") = value
            End Set
        End Property
#End Region

#Region "FILE_ACCESS_PATH 檔案存取路徑"
        ''' <summary>
        ''' FILE_ACCESS_PATH 檔案存取路徑
        ''' </summary>
        Public Property FILE_ACCESS_PATH() As String
            Get
                Return Me.ColumnyMap("FILE_ACCESS_PATH")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_ACCESS_PATH") = value
            End Set
        End Property
#End Region

#Region "FILE_EXPL 檔案說明"
        ''' <summary>
        ''' FILE_EXPL 檔案說明
        ''' </summary>
        Public Property FILE_EXPL() As String
            Get
                Return Me.ColumnyMap("FILE_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_EXPL") = value
            End Set
        End Property
#End Region

#Region "FILE_NO 檔案號碼"
        ''' <summary>
        ''' FILE_NO 檔案號碼
        ''' </summary>
        Public Property FILE_NO() As String
            Get
                Return Me.ColumnyMap("FILE_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("FILE_NO") = value
            End Set
        End Property
#End Region

#Region "ID_TYPE 身份類別"
        ''' <summary>
        ''' ID_TYPE 身份類別
        ''' </summary>
        Public Property ID_TYPE() As String
            Get
                Return Me.ColumnyMap("ID_TYPE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("ID_TYPE") = value
            End Set
        End Property
#End Region

#Region "IS_ANNOUNCE_OUTER 是否發佈校外"
        ''' <summary>
        ''' IS_ANNOUNCE_OUTER 是否發佈校外
        ''' </summary>
        Public Property IS_ANNOUNCE_OUTER() As String
            Get
                Return Me.ColumnyMap("IS_ANNOUNCE_OUTER")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_ANNOUNCE_OUTER") = value
            End Set
        End Property
#End Region

#Region "IS_DISP_RESULT 是否顯示結果"
        ''' <summary>
        ''' IS_DISP_RESULT 是否顯示結果
        ''' </summary>
        Public Property IS_DISP_RESULT() As String
            Get
                Return Me.ColumnyMap("IS_DISP_RESULT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_DISP_RESULT") = value
            End Set
        End Property
#End Region

#Region "IS_REPEAT 是否重複"
        ''' <summary>
        ''' IS_REPEAT 是否重複
        ''' </summary>
        Public Property IS_REPEAT() As String
            Get
                Return Me.ColumnyMap("IS_REPEAT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_REPEAT") = value
            End Set
        End Property
#End Region

#Region "IS_SIGN 是否記名"
        ''' <summary>
        ''' IS_SIGN 是否記名
        ''' </summary>
        Public Property IS_SIGN() As String
            Get
                Return Me.ColumnyMap("IS_SIGN")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_SIGN") = value
            End Set
        End Property
#End Region

#Region "IS_USE_SUBJECT_VECTOR 是否使用題目向度"
        ''' <summary>
        ''' IS_USE_SUBJECT_VECTOR 是否使用題目向度
        ''' </summary>
        Public Property IS_USE_SUBJECT_VECTOR() As String
            Get
                Return Me.ColumnyMap("IS_USE_SUBJECT_VECTOR")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("IS_USE_SUBJECT_VECTOR") = value
            End Set
        End Property
#End Region

#Region "JUMP_CONTENT 跳題內容"
        ''' <summary>
        ''' JUMP_CONTENT 跳題內容
        ''' </summary>
        Public Property JUMP_CONTENT() As String
            Get
                Return Me.ColumnyMap("JUMP_CONTENT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_CONTENT") = value
            End Set
        End Property
#End Region

#Region "JUMP_NO 跳題號碼"
        ''' <summary>
        ''' JUMP_NO 跳題號碼
        ''' </summary>
        Public Property JUMP_NO() As String
            Get
                Return Me.ColumnyMap("JUMP_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("JUMP_NO") = value
            End Set
        End Property
#End Region

#Region "MENU_NO 選單號碼"
        ''' <summary>
        ''' MENU_NO 選單號碼
        ''' </summary>
        Public Property MENU_NO() As String
            Get
                Return Me.ColumnyMap("MENU_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("MENU_NO") = value
            End Set
        End Property
#End Region

#Region "NAME 姓名"
        ''' <summary>
        ''' NAME 姓名
        ''' </summary>
        Public Property NAME() As String
            Get
                Return Me.ColumnyMap("NAME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("NAME") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_EXPL 問卷說明"
        ''' <summary>
        ''' QSTNNR_EXPL 問卷說明
        ''' </summary>
        Public Property QSTNNR_EXPL() As String
            Get
                Return Me.ColumnyMap("QSTNNR_EXPL")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_EXPL") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_FORMAT 問卷格式"
        ''' <summary>
        ''' QSTNNR_FORMAT 問卷格式
        ''' </summary>
        Public Property QSTNNR_FORMAT() As String
            Get
                Return Me.ColumnyMap("QSTNNR_FORMAT")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_FORMAT") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_NO 問卷號碼"
        ''' <summary>
        ''' QSTNNR_NO 問卷號碼
        ''' </summary>
        Public Property QSTNNR_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_NO") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_SEQ 問卷排序"
        ''' <summary>
        ''' QSTNNR_SEQ 問卷排序
        ''' </summary>
        Public Property QSTNNR_SEQ() As String
            Get
                Return Me.ColumnyMap("QSTNNR_SEQ")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_SEQ") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_TARGET_NO 問卷對象號碼"
        ''' <summary>
        ''' QSTNNR_TARGET_NO 問卷對象號碼
        ''' </summary>
        Public Property QSTNNR_TARGET_NO() As String
            Get
                Return Me.ColumnyMap("QSTNNR_TARGET_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_TARGET_NO") = value
            End Set
        End Property
#End Region

#Region "QSTNNR_TITLE 問卷標題"
        ''' <summary>
        ''' QSTNNR_TITLE 問卷標題
        ''' </summary>
        Public Property QSTNNR_TITLE() As String
            Get
                Return Me.ColumnyMap("QSTNNR_TITLE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("QSTNNR_TITLE") = value
            End Set
        End Property
#End Region

#Region "START_DATE 開始日期"
        ''' <summary>
        ''' START_DATE 開始日期
        ''' </summary>
        Public Property START_DATE() As String
            Get
                Return Me.ColumnyMap("START_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("START_DATE") = value
            End Set
        End Property
#End Region

#Region "START_TIME 開始時間"
        ''' <summary>
        ''' START_TIME 開始時間
        ''' </summary>
        Public Property START_TIME() As String
            Get
                Return Me.ColumnyMap("START_TIME")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("START_TIME") = value
            End Set
        End Property
#End Region

#Region "SUBJECT_NO 題目號碼"
        ''' <summary>
        ''' SUBJECT_NO 題目號碼
        ''' </summary>
        Public Property SUBJECT_NO() As String
            Get
                Return Me.ColumnyMap("SUBJECT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("SUBJECT_NO") = value
            End Set
        End Property
#End Region

#Region "UNIT_NO 單位號碼"
        ''' <summary>
        ''' UNIT_NO 單位號碼
        ''' </summary>
        Public Property UNIT_NO() As String
            Get
                Return Me.ColumnyMap("UNIT_NO")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UNIT_NO") = value
            End Set
        End Property
#End Region

#Region "UPDRAFT_DATE 上稿日期"
        ''' <summary>
        ''' UPDRAFT_DATE 上稿日期
        ''' </summary>
        Public Property UPDRAFT_DATE() As String
            Get
                Return Me.ColumnyMap("UPDRAFT_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPDRAFT_DATE") = value
            End Set
        End Property
#End Region

#Region "UPLD_DATE 上傳日期"
        ''' <summary>
        ''' UPLD_DATE 上傳日期
        ''' </summary>
        Public Property UPLD_DATE() As String
            Get
                Return Me.ColumnyMap("UPLD_DATE")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("UPLD_DATE") = value
            End Set
        End Property
#End Region

#Region "STATUS 狀態"
        ''' <summary>
        ''' STATUS 狀態
        ''' </summary>
        Public Property STATUS() As String
            Get
                Return Me.ColumnyMap("STATUS")
            End Get
            Set(ByVal value As String)
                Me.ColumnyMap("STATUS") = value
            End Set
        End Property
#End Region

#Region "DTQstTar 問卷對象"
        ''' <summary>
        ''' DTQstTar 問卷對象
        ''' </summary>
        Public Property DTQstTar() As DataTable
            Get
                Return Me.PropertyMap("DTQstTar")
            End Get
            Set(ByVal value As DataTable)
                Me.PropertyMap("DTQstTar") = value
            End Set
        End Property
#End Region
#End Region

#Region "自訂方法"
#Region "AddAttachFile 新增問卷檔案 "
        ''' <summary>
        ''' 新增問卷檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Sub AddAttachFile()
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


                '=== 處理別名轉換 ===
                '  Me.ParserAlias()


                '=== 處理說明 ===
                'EntAttachFile New EntAttachFile
                '
                EntAttachFile.ACCE_SOURCE = Me.ACCE_SOURCE
                EntAttachFile.ACTUAL_FILENAME = Me.ACTUAL_FILENAME
                EntAttachFile.UPLD_DATE = Me.UPLD_DATE
                EntAttachFile.FILE_EXPL = Me.FILE_EXPL
                EntAttachFile.FILE_NO = Me.FILE_NO
                EntAttachFile.FILE_ACCESS_PATH = Me.FILE_ACCESS_PATH
                EntAttachFile.Insert()
                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddQuestionaryObj 新增問卷對象 "

        ''' <summary>
        ''' 新增問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddQuestionaryObj()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                '=== 姓名 ===
                'If String.IsNullOrEmpty(Me.NAME) Then
                '    faileArguments.Add("NAME")
                'End If
                '=== 單位號碼 ===
                If String.IsNullOrEmpty(Me.UNIT_NO) Then
                    faileArguments.Add("UNIT_NO")
                End If
                '=== 問卷對象號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_TARGET_NO) Then
                    faileArguments.Add("QSTNNR_TARGET_NO")
                End If
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()
                Dim EntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(DBManager, LogUtil)
                EntQuestionaryObj.QSTNNR_NO = Me.QSTNNR_NO
                EntQuestionaryObj.ID_TYPE = Me.ID_TYPE
                EntQuestionaryObj.DEP_NAME = Me.DEP_NAME
                EntQuestionaryObj.NAME = Me.NAME
                EntQuestionaryObj.QSTNNR_TARGET_NO = Me.QSTNNR_TARGET_NO
                EntQuestionaryObj.UNIT_NO = Me.UNIT_NO
                EntQuestionaryObj.Insert()
                '=== 處理說明 ===
                'EntQuestionaryObj=New EntQuestionaryObj
                '
                'EntQuestionaryObj.Insert()


                Me.ResetColumnProperty()


            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "AddQuestionaryObj2 新增問卷對象 "

        ''' <summary>
        ''' 新增問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddQuestionaryObj2()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If
                '=== 問卷對象 ===
                If Me.DTQstTar.Rows.Count = 0 Then
                    faileArguments.Add("DTQstTar")
                End If
                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                'Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                'Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)
                'Dim sql As StringBuilder = New StringBuilder
                'Dim qstnnrNo As String = Me.QSTNNR_NO
                'Dim dt As DataTable = Me.DTQstTar
                'For i As Integer = 0 To dt.Rows.Count - 1
                '	sql.Append("INSERT INTO QUET020 ( QSTNNR_NO, QSTNNR_TARGET_NO, NAME, UNIT_NO, DEP_NAME, ID_TYPE, PKNO, CREATE_TIME, CREATE_USER, UPDATE_TIME, UPDATE_USER, ROWSTAMP)")
                '	sql.Append("VALUES( '" & qstnnrNo & "', '" & dt.Rows(i)("QSTNNR_TARGET_NO").ToString & "', '" & dt.Rows(i)("NAME").ToString & "', '" & dt.Rows(i)("UNIT_NO").ToString & "', '" & dt.Rows(i)("DEP_NAME").ToString & "', '" & dt.Rows(i)("ID_TYPE").ToString & "', SEQ_QUE.NEXTVAL, SYSDATE, '" & Comm.Business.SessionClass.登入帳號 & "', SYSDATE, '" & Comm.Business.SessionClass.登入帳號 & "', '" & DateUtil.GetNowTimeMS & "');")
                '	If (i + 1) Mod 500 = 0 OrElse (i + 1) = dt.Rows.Count Then
                '		dba.Execute("BEGIN " & sql.ToString & " END;")
                '		sql.Length = 0
                '	End If
                'Next

                Dim qstnnrNo As String = Me.QSTNNR_NO
                Dim dt As DataTable = Me.DTQstTar
                Dim AEntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(Me.DBManager, Me.LogUtil)
                Dim columns As String() = "QSTNNR_NO,QSTNNR_TARGET_NO,NAME,UNIT_NO,DEP_NAME,ID_TYPE,PKNO".Split(",")
                Dim dt1 As DataTable = New DataTable
                For j As Integer = 0 To columns.Length - 1
                    dt1.Columns.Add(columns(j))
                Next
                Dim dr As DataRow = dt1.NewRow
                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dt1.NewRow
                    For j As Integer = 0 To columns.Length - 1
                        Select Case columns(j)
                            Case "QSTNNR_NO"
                                dr(columns(j)) = qstnnrNo
                            Case "PKNO"
                                dr(columns(j)) = AEntQuestionaryObj.GetSequence
                            Case Else
                                dr(columns(j)) = dt.Rows(i)(columns(j)).ToString
                        End Select
                    Next
                    dt1.Rows.Add(dr)
                Next

                AEntQuestionaryObj.BatchInsert(dt1)

                Me.ResetColumnProperty()
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "DeleteAttachFile 刪除問卷檔案 "
        ''' <summary>
        ''' 刪除問卷檔案 
        ''' </summary>
        Public Function DeleteAttachFile() As DataTable
            Return Me.DeleteAttachFile(0, 0)
        End Function

        ''' <summary>
        ''' 刪除問卷檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function DeleteAttachFile(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
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


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                'EntAttachFile New EntAttachFile
                '
                'EntAttachFile.Delete()

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "DeleteQuestionaryObj 刪除問卷對象 "
        ''' <summary>
        ''' 刪除問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Sub DeleteQuestionaryObj()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理說明 ===
                'EntQuestionaryObj New EntQuestionaryObj
                '
                Dim EntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(DBManager, LogUtil)
                EntQuestionaryObj.SqlRetrictions = " QSTNNR_NO= '" & Me.QSTNNR_NO & "'"
                EntQuestionaryObj.Delete()

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "QueryAttachFile 查詢問卷檔案 "
        ''' <summary>
        ''' 查詢問卷檔案 
        ''' </summary>
        Public Function QueryAttachFile() As DataTable
            Return Me.QueryAttachFile(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷檔案 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 楊智能 新增方法
        ''' </remarks>
        Public Function QueryAttachFile(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 問卷號碼 ===
                If String.IsNullOrEmpty(Me.QSTNNR_NO) Then
                    faileArguments.Add("QSTNNR_NO")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===

                Return EntAttachFile.Query(pageNo, pageSize)

                'EntAttachFile.Query()

                Me.ResetColumnProperty()


            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryHeading 查詢問卷題目資料 "
        ''' <summary>
        ''' 查詢問卷題目資料 
        ''' </summary>
        Public Function QueryQuestionaryHeading() As DataTable
            Return Me.QueryQuestionaryHeading(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷題目資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryHeading(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    faileArguments.Add("SqlRetrictions")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                '抓取問卷跟題目資料跟已有填寫人有多少筆
                '
                '使用table 
                '問卷主檔QUET010,
                '問卷題目QUET040,
                '問卷對象QUET060
                'table join 關係 ;3個table都以問卷號碼當P-key

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryHeadingDegree 查詢問卷題目向度資料 "
        ''' <summary>
        ''' 查詢問卷題目向度資料 
        ''' </summary>
        Public Function QueryQuestionaryHeadingDegree() As DataTable
            Return Me.QueryQuestionaryHeadingDegree(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷題目向度資料 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryHeadingDegree(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()
                '=== 查詢條件 ===
                If String.IsNullOrEmpty(Me.SqlRetrictions) Then
                    faileArguments.Add("SqlRetrictions")
                End If

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                '抓取這筆問卷有幾筆問卷題目跟問卷題目向度
                '
                '問卷題目=count(QUET030 where (QSTNNR_NO(問卷號碼))
                '問卷題目向度=count(QUET040 where (QSTNNR_NO(問卷號碼))

                Dim sql As String = ""

                Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryMaxNo 查詢問卷最大編號 "
        ''' <summary>
        ''' 查詢問卷最大編號 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryMaxNo() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                Me.ParserAlias()

                '=== 處理說明 ===
                '最大問卷號碼+1 
                Dim sql As String = "select (ISNULL(MAX(CONVERT(INT,QSTNNR_NO)),0) + 1) AS MAXNO FROM " & Me.TableName

                Dim dt As DataTable = Me.QueryBySql(sql)
                Dim result As String = String.Empty
                If dt.Rows.Count > 0 Then
                    result = dt.Rows(0)("MAXNO")
                Else
                    result = "1"
                End If

                Return result
                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryQuestionaryObj 查詢問卷對象 "
        ''' <summary>
        ''' 查詢問卷對象 
        ''' </summary>
        Public Function QueryQuestionaryObj() As DataTable
            Return Me.QueryQuestionaryObj(0, 0)
        End Function

        ''' <summary>
        ''' 查詢問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryObj(ByVal pageNo As Integer, ByVal pageSize As Integer) As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                '=== 處理說明 ===
                Dim EntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(DBManager, LogUtil)
                EntQuestionaryObj.SqlRetrictions = Me.SqlRetrictions

                Dim dt As DataTable = EntQuestionaryObj.Query()

                Me.ResetColumnProperty()

                Return dt

                'Dim sql As String = ""

                'Dim dt As DataTable = Me.QueryBySql(sql, pageNo, pageSize)


                'Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "QueryItemDDL 查詢文字框下拉 "
        ''' <summary>
        ''' 查詢文字框下拉 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryItemDDL() As DataTable
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===

                '=== 處理別名轉換 ===
                'Me.ParserAlias()

                ''=== 處理說明 ===
                ''EntQuestionaryHeading.QueryItemDDL_查詢文字框下拉()

                'Dim sql As String = ""

                Dim entQueHead As EntQuestionaryHeading = New EntQuestionaryHeading(Me.DBManager, Me.LogUtil)

                Dim dt As DataTable = entQueHead.QueryItemDDL()

                Me.ResetColumnProperty()

                Return dt
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateJumpHeading 修改跳題題目 "
        ''' <summary>
        ''' 修改跳題題目 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateJumpHeading() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理說明 ===
                'AEntQuestionaryHeading =New EntQuestionaryHeading()
                '
                'AEntQuestionaryHeading.Update()
                Dim aEntQuestionaryHeading As EntQuestionaryHeading = New EntQuestionaryHeading(Me.DBManager, Me.LogUtil)

                aEntQuestionaryHeading.SqlRetrictions = Me.ProcessCondition(Me.SqlRetrictions)

                aEntQuestionaryHeading.JUMP_NO = Me.JUMP_NO

                Dim updateCount As Integer = aEntQuestionaryHeading.Update()

                Me.ResetColumnProperty()

                Return updateCount

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "UpdateItem 設定跳題 "
        ''' <summary>
        ''' 設定跳題 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function UpdateItem() As Integer
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===



                '=== 處理說明 ===
                'AEntQuestionaryHeading = NEW EntQuestionaryHeading()
                '
                'AEntQuestionaryHeading.UpdateItem_設定跳題

                Dim aEntQuestionaryHeading As EntQuestionaryHeading = New EntQuestionaryHeading(Me.DBManager, Me.LogUtil)

                aEntQuestionaryHeading.SqlRetrictions = Me.ProcessCondition(Me.SqlRetrictions)

                aEntQuestionaryHeading.JUMP_NO = Me.JUMP_NO
                aEntQuestionaryHeading.JUMP_CONTENT = Me.JUMP_CONTENT
                Dim updateCount As Integer = aEntQuestionaryHeading.UpdateItem

                Me.ResetColumnProperty()

                Return updateCount
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#Region "AddSpeQuestionaryObj 新增特定問卷對象 "
        ''' <summary>
        ''' 新增特定問卷對象 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Sub AddSpeQuestionaryObj()
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===


                '=== 處理說明 ===
                'select case STATUS(狀態)
                '
                'case STATUS(狀態)=1
                '///全校教職員
                '抓不是虛擬單位的 and 在職的 and 重複只抓第一筆
                '利用SELECT INTO的方式
                '使用table post020,post030(select disitinct)
                'table join,post020.acnt=post030.acnt
                'and 
                'post020任別>=1 and <=2 and post020.OJOB_STATUS(在職狀態)=1
                '
                '
                'end select

                'Dim conn As DbConnection = Me.DBManager.GetIConnection(Me.ConnName)
                'Dim dba As DBAccess = Me.DBManager.GetDBAccess(conn)

                'Dim sql As StringBuilder = New StringBuilder

                'sql.Append("INSERT INTO QUET020 ")
                'sql.Append("(PKNO,QSTNNR_NO,QSTNNR_TARGET_NO,NAME,UNIT_NO,DEP_NAME,ID_TYPE,CREATE_TIME,CREATE_USER,UPDATE_TIME,UPDATE_USER,ROWSTAMP)")
                'sql.Append("SELECT SEQ_QUE.NEXTVAL AS PKNO,M1.QSTNNR_NO,M1.QSTNNR_TARGET_NO,M1.NAME,M1.UNIT_NO,M1.DEP_NAME,")
                'sql.Append("M1.ID_TYPE,M1.CREATE_TIME,M1.CREATE_USER,M1.UPDATE_TIME,M1.UPDATE_USER,M1.ROWSTAMP ")
                'sql.Append("FROM (")
                'sql.Append("SELECT '")
                'sql.Append(Me.QSTNNR_NO)
                'sql.Append("' AS QSTNNR_NO,M.ACNT AS QSTNNR_TARGET_NO,M.CH_NAME AS NAME,R1.DEP_CODE AS UNIT_NO,R2.DEP_NAME,'01' AS ID_TYPE,")
                'sql.Append(Utility.DateTimeStr(Now.ToString("yyyy/MM/dd HH:mm:ss")))
                'sql.Append(" AS CREATE_TIME,'")
                'sql.Append(SessionClass.登入帳號)
                'sql.Append("' AS CREATE_USER,")
                'sql.Append(Utility.DateTimeStr(Now.ToString("yyyy/MM/dd HH:mm:ss")))
                'sql.Append(" AS UPDATE_TIME,'")
                'sql.Append(SessionClass.登入帳號)
                'sql.Append("' AS UPDATE_USER,'")
                'sql.Append(DateUtil.GetNowTimeMS)
                'sql.Append("' AS ROWSTAMP ")
                'sql.Append("FROM POST020 M ")
                'sql.Append("LEFT JOIN POST030 R1 ON M.ACNT=R1.ACNT ")
                'sql.Append("LEFT JOIN ORGT010 R2 ON R1.DEP_CODE=R2.DEP_CODE ")
                'sql.Append("WHERE M.OCCUP>=1 AND M.OCCUP <=2 AND M.OJOB_STATUS='1' AND R1.PTTCH_FT='1' ")
                'sql.Append("GROUP BY M.ACNT,M.CH_NAME,R1.DEP_CODE,R2.DEP_NAME ) M1")

                'dba.Execute(sql.ToString)

                Dim qstnnrNo As String = Me.QSTNNR_NO
                Dim sql As StringBuilder = New StringBuilder
                sql.Append(" SELECT '' AS QSTNNR_NO,M.ACNT AS QSTNNR_TARGET_NO,M.CH_NAME AS NAME,R1.DEP_CODE AS UNIT_NO,R2.DEP_NAME,'01' AS ID_TYPE ")
                sql.Append(" FROM POST020 M ")
                sql.Append(" LEFT JOIN POST030 R1 ON M.ACNT=R1.ACNT ")
                sql.Append(" LEFT JOIN ORGT010 R2 ON R1.DEP_CODE=R2.DEP_CODE ")
                sql.Append(" WHERE M.OCCUP>=1 AND M.OCCUP <=2 AND M.OJOB_STATUS='1' AND R1.PTTCH_FT='1' ")
                sql.Append(" GROUP BY M.ACNT,M.CH_NAME,R1.DEP_CODE,R2.DEP_NAME  ")
                Dim dt As DataTable = Me.QueryBySql(sql.ToString)

                Dim AEntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(Me.DBManager, Me.LogUtil)
                Dim columns As String() = "QSTNNR_NO,QSTNNR_TARGET_NO,NAME,UNIT_NO,DEP_NAME,ID_TYPE,PKNO".Split(",")
                Dim dt1 As DataTable = New DataTable
                For j As Integer = 0 To columns.Length - 1
                    dt1.Columns.Add(columns(j))
                Next
                Dim dr As DataRow = dt1.NewRow
                For i As Integer = 0 To dt.Rows.Count - 1
                    dr = dt1.NewRow
                    For j As Integer = 0 To columns.Length - 1
                        Select Case columns(j)
                            Case "QSTNNR_NO"
                                dr(columns(j)) = qstnnrNo
                            Case "PKNO"
                                dr(columns(j)) = AEntQuestionaryObj.GetSequence
                            Case Else
                                dr(columns(j)) = dt.Rows(i)(columns(j)).ToString
                        End Select
                    Next
                    dt1.Rows.Add(dr)
                Next

                AEntQuestionaryObj.BatchInsert(dt1)

                Me.ResetColumnProperty()

            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Sub
#End Region

#Region "QueryQuestionaryObjSQL 查詢問卷對象結構 "
        ''' <summary>
        ''' 查詢問卷對象結構 
        ''' </summary>
        ''' <remarks>
        ''' 0.0.1 作者 新增方法
        ''' </remarks>
        Public Function QueryQuestionaryObjSQL() As String
            Try
                Me.LogUtil.MethodStart(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
                Me.LogProperty()

                '=== 檢核欄位起始 ===
                Dim faileArguments As ArrayList = New ArrayList()

                If faileArguments.Count > 0 Then
                    Throw New ArgumentException("屬性資料不可為空", Utility.ArrayListToString(faileArguments))
                End If
                '=== 檢核欄位結束 ===



                '=== 處理說明 ===
                'AEntQuestionaryObj = NEW EntQuestionaryObj()
                '
                'AEntQuestionaryObj.QueryQuestionaryObjSQL_查詢問卷對象結構()

                Dim aEntQuestionaryObj As EntQuestionaryObj = New EntQuestionaryObj(Me.DBManager, Me.LogUtil)

                aEntQuestionaryObj.SqlRetrictions = Me.SqlRetrictions
                aEntQuestionaryObj.STATUS = Me.STATUS

                Dim result As String = aEntQuestionaryObj.QueryQuestionaryObjSQL

                Me.ResetColumnProperty()

                Return result
            Finally
                Me.LogUtil.MethodEnd(GetCurrentMethod.DeclaringType.FullName & "." & GetCurrentMethod.Name)
            End Try
        End Function
#End Region

#End Region

    End Class
End Namespace


